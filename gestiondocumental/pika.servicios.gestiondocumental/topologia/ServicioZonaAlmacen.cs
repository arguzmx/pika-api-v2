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
    [ServicioEntidadAPI(entidad: typeof(ZonaAlmacen))]
    public class ServicioZonaAlmacen : ServicioEntidadGenericaBase<ZonaAlmacen, ZonaAlmacenInsertar, ZonaAlmacenActualizar, ZonaAlmacenDespliegue, string>,
        IServicioEntidadAPI, InterfaceServicioZonaAlmacen
    {


        private DbContextGestionDocumental localContext;

        public ServicioZonaAlmacen(DbContextGestionDocumental context, ILogger<ServicioZonaAlmacen> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.ZonaAlmacenes, logger, Reflector, cache)
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
            var update = data.Deserialize<ZonaAlmacenActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<ZonaAlmacenInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<ZonaAlmacen> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(ZonaAlmacen));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextGestionDocumental.TablaZonaAlmacen);

            int? total = null;
            List<ZonaAlmacen> elementos = localContext.ZonaAlmacenes.FromSqlRaw(query).ToList();

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
                return new(new List<ZonaAlmacen>(), total); ;
            }
        }








        #region Overrides para la personalizacion de la entidad zonaalmacen

        public override async Task<ResultadoValidacion> ValidarInsertar(ZonaAlmacenInsertar insertar)
        {

            ResultadoValidacion resultado = new();
            bool encontrado = await DB.ZonaAlmacenes.AnyAsync(a => a.Nombre == insertar.Nombre);

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

        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, ZonaAlmacen original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.ZonaAlmacenes.AnyAsync(a => a.Id == id);

            if (!encontrado)
            {

                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {
                bool EncontradoPosicionAlmacen = await DB.PosicionAlmacens.AnyAsync(a => a.ZonaAlmacenId == id);
                bool EncontradoCajaAlmacen = await DB.CajaAlmacens.AnyAsync(a => a.ZonaAlmacenId == id);
                if(EncontradoPosicionAlmacen || EncontradoCajaAlmacen)
                    {
                    resultado.Error = "Id en uso verifique que este no se encuentre en PosicionAlmacen O CajaAlmacen".Error409();
                }
                else
                {
                    resultado.Valido = true;
                }
            }

            return resultado;
        }

        public override async Task<ResultadoValidacion> ValidarActualizar(string id, ZonaAlmacenActualizar actualizar, ZonaAlmacen original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.ZonaAlmacenes.AnyAsync(a => a.Nombre == actualizar.Nombre);

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

        public override ZonaAlmacen ADTOFull(ZonaAlmacenActualizar actualizacion, ZonaAlmacen actual)
        {
            actual.Nombre = actualizacion.Nombre;
            actual.ArchivoId = actualizacion.ArchivoId;
            actual.AlmacenArchivoId = actualizacion.AlmacenArchivoId;
            return actual;
        }

        public override ZonaAlmacen ADTOFull(ZonaAlmacenInsertar insertar)
        {
            ZonaAlmacen zonaAlmacen = new()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = insertar.Nombre,
                ArchivoId = insertar.ArchivoId,
                AlmacenArchivoId = insertar.AlmacenArchivoId

            ,
            };
            return zonaAlmacen;
        }

        public override ZonaAlmacenDespliegue ADTODespliegue(ZonaAlmacen data)
        {
            ZonaAlmacenDespliegue zonaAlmacen = new()
            {
                Id = data.Id,
                Nombre= data.Nombre,
                ArchivoId= data.ArchivoId,
                AlmacenArchivoId=data.AlmacenArchivoId,
                
            };
            return zonaAlmacen;
        }



        #endregion



    }
}
