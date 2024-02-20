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
    [ServicioEntidadAPI(entidad: typeof(CajaAlmacen))]
    public class ServicioCajaAlmacen : ServicioEntidadGenericaBase<CajaAlmacen, CajaAlmacenInsertar, CajaAlmacenActualizar, CajaAlmacenDespliegue, string>,
        IServicioEntidadAPI, InterfaceServicioCajaAlmacen
    {


        private DbContextGestionDocumental localContext;

        public ServicioCajaAlmacen(DbContextGestionDocumental context, ILogger<ServicioCajaAlmacen> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.CajaAlmacens, logger, Reflector, cache)
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
            var update = data.Deserialize<CajaAlmacenActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<CajaAlmacenInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<CajaAlmacen> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(CajaAlmacen));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextGestionDocumental.TablaCajaAlmacen);

            int? total = null;
            List<CajaAlmacen> elementos = localContext.CajaAlmacens.FromSqlRaw(query).ToList();

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
                return new(new List<CajaAlmacen>(), total); ;
            }
        }








        #region Overrides para la personalizacion de la entidad posicionalmacen

        public override async Task<ResultadoValidacion> ValidarInsertar(CajaAlmacenInsertar insertar)
        {

            ResultadoValidacion resultado = new();
            bool encontrado = await DB.CajaAlmacens.AnyAsync(a => a.Nombre == insertar.Nombre);

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

        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, CajaAlmacen original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.CajaAlmacens.AnyAsync(a => a.Id == id);

            if (!encontrado)
            {

                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {
                resultado.Valido = true;
            }

            return resultado;
        }

        public override async Task<ResultadoValidacion> ValidarActualizar(string id, CajaAlmacenActualizar actualizar, CajaAlmacen original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.CajaAlmacens.AnyAsync(a => a.Id == id);

            if (!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {
                resultado.Valido = true;
            }

            return resultado;
        }

        public override CajaAlmacen ADTOFull(CajaAlmacenActualizar actualizacion, CajaAlmacen actual)
        {
            actual.Nombre = actualizacion.Nombre;
            actual.CodigoBarras = actualizacion.CodigoBarras;
            actual.CodigoElectronico = actualizacion.CodigoElectronico;
            actual.Ocupacion = actualizacion.Ocupacion;
            return actual;
        }

        public override CajaAlmacen ADTOFull(CajaAlmacenInsertar insertar)
        {
            CajaAlmacen cajaAlmacen = new()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = insertar.Nombre,
                CodigoBarras = insertar.CodigoBarras,
                CodigoElectronico = insertar.CodigoElectronico,
                Ocupacion = insertar.Ocupacion,
                AlmacenArchivoId = insertar.AlmacenArchivoId,
                ZonaAlmacenId = insertar.ZonaAlmacenId,
                PosicionAlmacenId = insertar.PosicionAlmacenId,
                ArchivoId = insertar.ArchivoId

            ,
            };
            return cajaAlmacen;
        }

        public override CajaAlmacenDespliegue ADTODespliegue(CajaAlmacen data)
        {
            CajaAlmacenDespliegue cajaAlmacenDespliegue = new()
            {
                Id = data.Id,
                Nombre = data.Nombre,
                CodigoBarras = data.CodigoBarras,
                CodigoElectronico = data.CodigoElectronico,
                Ocupacion = data.Ocupacion,
                AlmacenArchivoId = data.AlmacenArchivoId,
                ZonaAlmacenId = data.ZonaAlmacenId,
                PosicionAlmacenId = data.PosicionAlmacenId,
                ArchivoId = data.ArchivoId,

            };
            return cajaAlmacenDespliegue;
        }



        #endregion



    }
}
