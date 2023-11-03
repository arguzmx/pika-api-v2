using api.comunes.metadatos;
using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.Archivos;
using pika.servicios.gestiondocumental.dbcontext;
using System.Text.Json;
using pika.servicios.gestiondocumental.archivos;

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

        public ServicioArchivo(DbContextGestionDocumental context, ILogger<ServicioArchivo> logger) : base (context, context.Archivos, logger)
        {
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


            RespuestaPayload<PaginaGenerica<Archivo>> respuesta = new RespuestaPayload<PaginaGenerica<Archivo>>();
          
       
            string consultaBaseSQL = "SELECT * FROM gd$archivo";
            string condicionSQL = consulta.Filtros.SQL();
            if (!string.IsNullOrEmpty(condicionSQL))
            {
                consultaBaseSQL += $" WHERE {condicionSQL}";
            }
            PaginaGenerica<Archivo> paginado = (PaginaGenerica<Archivo>)respuesta.Payload;
            string consultaQuery = $"{consultaBaseSQL} {consulta.OrdenarConsulta()} {paginado.PaginarConsulta(consulta)};";
            var resultadoConsulta = DB.Archivos.FromSqlRaw(consultaQuery).ToList();

            PaginaGenerica<Archivo> pagina = (PaginaGenerica<Archivo>)(respuesta.Payload = new PaginaGenerica<Archivo>
            {
                ConsultaId = Guid.NewGuid().ToString(),
                Elementos = resultadoConsulta,
                Milisegundos = 0L,
                Paginado = new Paginado
                {
                    Indice = consulta.Paginado.Indice,
                    Tamano = consulta.Paginado.Tamano,
                    Ordenamiento=consulta.Paginado.Ordenamiento,
                    ColumnaOrdenamiento=consulta.Paginado.ColumnaOrdenamiento
                },
                Total = resultadoConsulta.Count
              
            });
            respuesta.Payload = pagina;
            respuesta.Ok = true;
            respuesta.HttpCode = HttpCode.Ok;

            RespuestaPayload<PaginaGenerica<object>> r = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(respuesta));
            return r;


            var temp = await this.Pagina(consulta);
            //RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));

            //return respuesta;
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



        #region Overrides para la personalziación de la entidad Archivo

        public override async Task<ResultadoValidacion> ValidarInsertar(ArchivoInsertar data)
        {   
            ResultadoValidacion resultado = new ();
            bool encontrado = await DB.Archivos.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Nombre == data.Nombre);

            if (encontrado)
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
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Archivos.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id == id);

            if(!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            } else
            {
                resultado.Valido = true;
            }

            return resultado;
        }


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, ArchivoActualizar actualizacion, Archivo original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Archivos.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id == id);

            if (!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {

                bool duplicado = await DB.Archivos.AnyAsync(a => a.UOrgId == _contextoUsuario.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id != id 
                    && a.Nombre.Equals( actualizacion.Nombre));

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
            Archivo archivo = new Archivo()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = data.Nombre,
                TipoArchivoId = data.TipoArchivoId,
                UOrgId = _contextoUsuario.UOrgId,
                DominioId = _contextoUsuario.DominioId,
            };
            return archivo;
        }

        public override ArchivoDespliegue ADTODespliegue(Archivo data)
        {
            ArchivoDespliegue archivo = new ArchivoDespliegue()
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
