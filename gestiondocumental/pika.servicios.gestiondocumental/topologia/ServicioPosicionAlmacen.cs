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
using System.Text.Json;

namespace pika.servicios.gestiondocumental.topologia
{
    [ServicioEntidadAPI(entidad: typeof(PosicionAlmacen))]
    public class ServicioPosicionAlmacen : ServicioEntidadGenericaBase<PosicionAlmacen, PosicionAlmacenInsertar, PosicionAlmacenActualizar, PosicionAlmacenDespliegue, string>,
        IServicioEntidadAPI, InterfaceServicioPosicionAlmacen
    {


        private DbContextGestionDocumental localContext;

        public ServicioPosicionAlmacen(DbContextGestionDocumental context, ILogger<ServicioPosicionAlmacen> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.PosicionAlmacens, logger, Reflector, cache)
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
            var update = data.Deserialize<PosicionAlmacenActualizar>(JsonAPIDefaults());
            return await this.Actualizar((string)id, update);
        }

        public async Task<Respuesta> EliminarAPI(object id)
        {
            return await this.Eliminar((string)id);
        }

        public Entidad EntidadDespliegueAPI()
        {
            return this.EntidadDespliegue();
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
            var add = data.Deserialize<PosicionAlmacenInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<PosicionAlmacen> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(PosicionAlmacen));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextGestionDocumental.TablaPosicionAlmacen);

            int? total = null;
            List<PosicionAlmacen> elementos = localContext.PosicionAlmacens.FromSqlRaw(query).ToList();

            if (consulta.Contar)
            {
                query = query.Split("ORDER")[0];
                query = $"{query.Replace("*", "count(*)")}";
                total = localContext.Database.SqlQueryRaw<int>(query).ToArray().First();
            }


            if (elementos != null)
            {
                return new(elementos, total);
            }
            else
            {
                return new(new List<PosicionAlmacen>(), total); ;
            }
        }








        #region Overrides para la personalizacion de la entidad posicionalmacen

        public override async Task<ResultadoValidacion> ValidarInsertar(PosicionAlmacenInsertar insertar)
        {

            ResultadoValidacion resultado = new();
            bool encontrado = await DB.PosicionAlmacens.AnyAsync(a => a.Nombre == insertar.Nombre);

            if (encontrado)
            {
                resultado.Error = "Nombre".ErrorProcesoDuplicado();
            }
            else
            {
                resultado.Valido = true;
            }
            return resultado;
        }

        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, PosicionAlmacen original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.PosicionAlmacens.AnyAsync(a => a.Id == id);

            if (!encontrado)
            {

                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {
                bool EncontradoCajaAlmacen = await DB.CajaAlmacens.AnyAsync(a => a.PosicionAlmacenId == id);
                if(EncontradoCajaAlmacen)
                {
                    resultado.Error = "Id en uso verifique que este no se encuentre en CajaAlmacen".Error409();
                }
                else
                {
                    resultado.Valido = true;
                }
            }

            return resultado;
        }

        public override async Task<ResultadoValidacion> ValidarActualizar(string id, PosicionAlmacenActualizar actualizar, PosicionAlmacen original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.CajaAlmacens.AnyAsync(a => a.Nombre == actualizar.Nombre);

            if (encontrado)
            {
                resultado.Error = "Nombre".ErrorProcesoDuplicado();
            }
            else
            {
                resultado.Valido = true;
            }

            return resultado;
        }

        public override PosicionAlmacen ADTOFull(PosicionAlmacenActualizar actualizacion, PosicionAlmacen actual)
        {
            actual.Nombre = actualizacion.Nombre;
            actual.Indice = actualizacion.Indice;
            actual.Localizacion = actualizacion.Localizacion;
            actual.CodigoBarras = actualizacion.CodigoBarras;
            actual.CodigoElectronico = actualizacion.CodigoElectronico;
            actual.Ocupacion = actualizacion.Ocupacion;
            actual.IncrementoContenedor = actualizacion.IncrementoContenedor;
            return actual;
        }

        public override PosicionAlmacen ADTOFull(PosicionAlmacenInsertar insertar)
        {
            PosicionAlmacen posicionAlmacen = new()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = insertar.Nombre,
                Indice = insertar.Indice,
                Localizacion = insertar.Localizacion,
                CodigoBarras = insertar.CodigoBarras,
                CodigoElectronico = insertar.CodigoElectronico,
                Ocupacion = insertar.Ocupacion,
                IncrementoContenedor = insertar.IncrementoContenedor,
                ArchivoId = insertar.ArchivoId,
                AlmacenArchivoId = insertar.AlmacenArchivoId,
                ZonaAlmacenId = insertar.ZonaAlmacenId

            ,
            };
            return posicionAlmacen;
        }

        public override PosicionAlmacenDespliegue ADTODespliegue(PosicionAlmacen data)
        {
            PosicionAlmacenDespliegue posicionAlmacenDespliegue = new()
            {
                Id = data.Id,
                Nombre = data.Nombre,
                Indice = data.Indice,
                Localizacion = data.Localizacion,
                CodigoBarras = data.CodigoBarras,
                CodigoElectronico = data.CodigoElectronico,
                Ocupacion = data.Ocupacion,
                IncrementoContenedor = data.IncrementoContenedor,
                ArchivoId = data.ArchivoId,
                AlmacenArchivoId = data.AlmacenArchivoId,
                ZonaAlmacenId = data.ZonaAlmacenId

            };
            return posicionAlmacenDespliegue;
        }



        #endregion


    }
}
