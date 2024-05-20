using api.comunes.metadatos;
using api.comunes.modelos.interpretes;
using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext;
using RepoDb.Extensions;
using System.Text.Json;

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
namespace pika.servicios.gestiondocumental.archivos
{
    /// <summary>
    /// Servicio de datos para la entidad archivo
    /// </summary>
    [ServicioEntidadAPI(entidad: typeof(Archivo) )]
    public class ServicioArchivo : ServicioEntidadGenericaBase<Archivo, ArchivoInsertar, ArchivoActualizar, ArchivoDespliegue, string>,
        IServicioEntidadAPI, IServicioArchivo
    {
        private DbContextGestionDocumental localContext;
        public ServicioArchivo(DbContextGestionDocumental context, ILogger<ServicioArchivo> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base (context, context.Archivos, logger,Reflector, cache)
        {
            interpreteConsulta = new InterpreteConsultaMySQL();
            localContext = context;
        }


        /// <summary>
        /// Acceso al repositorio de gestipon documental local
        /// </summary>
        private DbContextGestionDocumental DB { get { return (DbContextGestionDocumental)_db; } }


        public bool RequiereAutenticacion => true;

        public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            var update = data.Deserialize<ArchivoActualizar>(JsonAPIDefaults());
            return await this.Actualizar((string)id, update);
        }

        public async Task<Respuesta> EliminarAPI(object id)
        {
            return await this.Eliminar((string)id);
        }

        public Entidad EntidadDespliegueAPI()
        {
            return  this.EntidadDespliegue();
        }

        public Entidad EntidadInsertAPI()
        {
            return this.EntidadInsert();
        }

        public Entidad EntidadRepoAPI()
        {
            return this.EntidadRepo();
        }

        public Entidad EntidadUpdateAPI()
        {
            return this.EntidadUpdate();
        }

        public void EstableceContextoUsuarioAPI(ContextoUsuario contexto)
        {
            this.EstableceContextoUsuario(contexto);
        }

        public ContextoUsuario? ObtieneContextoUsuarioAPI()
        {
            return this._contextoUsuario;
        }

        public async Task<RespuestaPayload<object>> InsertarAPI(JsonElement data)
        {
            var add = data.Deserialize<ArchivoInsertar>(JsonAPIDefaults());
            var temp = await this.Insertar(add);
            RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaAPI(Consulta consulta)
        {
            var temp = await this.Pagina(consulta);
            RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaDespliegueAPI(Consulta consulta)
        {            
            var temp = await this.PaginaDespliegue(consulta);
            RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijoAPI(Consulta consulta, string tipoPadre, string id)
        {
            var temp = await this.PaginaHijo(consulta, tipoPadre, id);
            RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijosDespliegueAPI(Consulta consulta, string tipoPadre, string id)
        {
            var temp = await this.PaginaHijosDespliegue(consulta, tipoPadre, id);
            RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }


        public async Task<RespuestaPayload<object>> UnicaPorIdAPI(object id)
        {
            var temp = await this.UnicaPorId((string)id);
            RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<object>> UnicaPorIdDespliegueAPI(object id)
        {
            var temp = await this.UnicaPorIdDespliegue((string)id);

            RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }


        public override async Task<(List<Archivo> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(Archivo));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextGestionDocumental.TablaArchivos);

            int? total = null;
            List<Archivo> elementos = localContext.Archivos.FromSqlRaw(query).ToList();

            if (consulta.Contar)
            {
                query = query.Split("ORDER")[0];
                query = $"{query.Replace("*", "count(*)")}";
                total = localContext.Database.SqlQueryRaw<int>(query).ToArray().First();
            }


            if (elementos != null)
            {
                return new (elementos, total);
            } else
            {
                return new(new List<Archivo>(), total); ;
            }
        }


        #region Overrides para la personalización de la entidad Archivo

        public override async Task<ResultadoValidacion> ValidarInsertar(ArchivoInsertar data)
        {
            // Reglas 
            // El nombre del archivo debe ser único combindaco con el valor de UOrgId y DominioId

            ResultadoValidacion resultado = new ();
            bool encontrado = await DB.Archivos.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Nombre == data.Nombre);
            bool encontrado2 = await DB.TipoArchivo.AnyAsync(a => a.Id == data.TipoArchivoId);

            if (encontrado )
            {
                resultado.Error = "Nombre".ErrorProcesoDuplicado();
            } else
            {
                resultado.Valido = true;
            }

            return resultado;
        }


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Archivo original)
        {

            // Reglas 
            // Verificar las propieades de navegación y validaa que para cada una de las entidades asociadas no exista un registro con el Id de archivo enviado

            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Archivos.AnyAsync(a => a.UOrgId == _contextoUsuario!.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id == id);

            if(!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            } else
            {
                bool encontradoAlmacenArchivo = await DB.AlmacenesArchivos.AnyAsync(a => a.ArchivoId.Equals(id));
                bool encontradoZonaAlmacenes = await DB.ZonaAlmacenes.AnyAsync(a => a.ArchivoId.Equals(id));
                bool encontradoPosicionAlmanenes = await DB.PosicionAlmacens.AnyAsync(a => a.ArchivoId.Equals(id));
                bool encontradoCajaAlmacenes = await DB.CajaAlmacens.AnyAsync(a => a.ArchivoId.Equals(id));
                bool encontradoUnidadesAdministrativas = await DB.UnidadesAdministrativas.AnyAsync(a => a.ArchivoConcentracionId.Equals(id) || a.ArchivoHistoricoId.Equals(id )|| a.ArchivoTramiteId.Equals(id));
                bool encontradoTransferencias = await DB.Transferencias.AnyAsync(a => a.ArchivoDestinoId.Equals(id) || a.ArchivoOrigenId.Equals(id));//
                bool encontradoPrestamos = await DB.Prestamos.AnyAsync(a => a.ArchivoId.Equals(id));


                if (encontradoAlmacenArchivo||encontradoZonaAlmacenes || encontradoTransferencias||encontradoPrestamos || encontradoPosicionAlmanenes||encontradoCajaAlmacenes || encontradoUnidadesAdministrativas)
                {
                    resultado.Error = "Id en uso verifique que este no se encuentre en AlmacenArchivo,ZonaAlmecen,PosicionAlmacen,CajaAlmacen,UnidadesAdministraticas,Transferencia O Prestamos".Error409();
                }
                else
                {
                    resultado.Valido = true;
                }
            }

            return resultado;
        }


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, ArchivoActualizar actualizacion, Archivo original)
        {
            // Reglas 
            // Verificar que no existe un archivo con el mismo Nombre, UOrgId y DominioId con un Id diferente al recibido


            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Archivos.AnyAsync(a => a.UOrgId == _contextoUsuario!.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id == id);

            if (!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {
                // Verifica que no haya un registro con el mismo nombre para el mismo dominio y UO en un resgitrso diferente
                bool duplicado = await DB.Archivos.AnyAsync(a => a.UOrgId == _contextoUsuario!.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id != id 
                    && a.Nombre.Equals(actualizacion.Nombre));

                if (duplicado)
                {
                    resultado.Error = "Nombre".ErrorProcesoDuplicado();

                } else
                {
                    resultado.Valido = true;
                }
            }

            return resultado;
        }


        public override Archivo ADTOFull(ArchivoActualizar actualizacion, Archivo actual)
        {
            actual.Nombre = actualizacion.Nombre;
            return actual;
        }

        public override Archivo ADTOFull(ArchivoInsertar data)
        {
            Archivo archivo = new ()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = data.Nombre,
                TipoArchivoId = data.TipoArchivoId,
                UOrgId = _contextoUsuario!.UOrgId!,
                DominioId = _contextoUsuario!.DominioId!,
            };
            return archivo;
        }

        public override ArchivoDespliegue ADTODespliegue(Archivo data)
        {
            ArchivoDespliegue archivo = new ()
            {
                Id = data.Id,
                Nombre = data.Nombre,
                TipoArchivoId = data.TipoArchivoId,
            };
            return archivo;
        }

        #endregion
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8603 // Possible null reference return.
