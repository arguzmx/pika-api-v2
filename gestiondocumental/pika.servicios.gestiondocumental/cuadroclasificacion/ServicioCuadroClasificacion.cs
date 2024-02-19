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

namespace pika.servicios.gestiondocumental.cuadroclasificacion
{
    [ServicioEntidadAPI(entidad:typeof(CuadroClasificacion))]
    public class ServicioCuadroClasificacion : ServicioEntidadGenericaBase<CuadroClasificacion,CuadroClasificacionInsertar,CuadroClasificacionActualizar,CuadroClasificacionDespliegue,string>,
        IServicioEntidadAPI, IServicioCuadroclasificacion

    {

        private DbContextGestionDocumental localContext;

        public ServicioCuadroClasificacion(DbContextGestionDocumental context, ILogger<ServicioCuadroClasificacion> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.CuadrosClasificacion, logger,Reflector,cache) 
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
            var update = data.Deserialize<CuadroClasificacionActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<CuadroClasificacionInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<CuadroClasificacion> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(CuadroClasificacion));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextGestionDocumental.TablaCuadrosClasificacion);

            int? total = null;
            List<CuadroClasificacion> elementos = localContext.CuadrosClasificacion.FromSqlRaw(query).ToList();

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
                return new(new List<CuadroClasificacion>(), total); ;
            }
        }








        #region Overrides para la personalizacion de la entidad cuadro clasificacion

        public override async Task<ResultadoValidacion> ValidarInsertar(CuadroClasificacionInsertar insertar)
        {
            
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.CuadrosClasificacion.AnyAsync(a => a.UOrgId == _contextoUsuario!.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Nombre == insertar.Nombre);

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

        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, CuadroClasificacion original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.CuadrosClasificacion.AnyAsync(a => a.UOrgId == _contextoUsuario!.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id == id);

            if (!encontrado)
            {

                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {
                bool EncontradoActivo = await DB.Activos.AnyAsync(a => a.CuadroClasificacionId == id);
                bool EncontradoSerieDocumental = await DB.SerieDocumentales.AnyAsync(a => a.CuadroClasificacionId == id);
                bool EncontradoTransferencia = await DB.Transferencias.AnyAsync(a => a.CuadroClasificacionId == id);
                if (EncontradoActivo || EncontradoSerieDocumental || EncontradoTransferencia)
                {
                    resultado.Error = "Id en uso verifique que este no se encuentre en Activos,SerieDocumental O Transferencia".Error409();
                }
                else
                {
                    resultado.Valido = true;
                }               
            }

            return resultado;
        }

        public override async Task<ResultadoValidacion> ValidarActualizar(string id,CuadroClasificacionActualizar actualizar, CuadroClasificacion original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.CuadrosClasificacion.AnyAsync(a => a.UOrgId == _contextoUsuario!.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id == id);

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

        public override CuadroClasificacion ADTOFull(CuadroClasificacionActualizar actualizacion, CuadroClasificacion actual)
        {
           actual.Nombre = actualizacion.Nombre;
            return actual;
        }

        public override CuadroClasificacion ADTOFull(CuadroClasificacionInsertar insertar)
        {
            CuadroClasificacion cuadroClasificacion = new()
            {
                Id = Guid.NewGuid().ToString(),
                UOrgId = _contextoUsuario!.UOrgId,
                DominioId = _contextoUsuario!.DominioId!,
                Nombre = insertar.Nombre
                
            ,
            };
            return cuadroClasificacion;
        }

        public override CuadroClasificacionDespliegue ADTODespliegue(CuadroClasificacion data)
        {
            CuadroClasificacionDespliegue cuadroclasificacion = new()
            {
               Id = data.Id
            };
            return cuadroclasificacion;
        }

      

        #endregion

    }
}
