using api.comunes.metadatos;
using api.comunes.modelos.interpretes;
using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using pika.modelo.organizacion;
using pika.modelo.organizacion.Contacto;
using pika.servicios.organizacion.dbcontext;
using System.Text.Json;

namespace pika.servicios.organizacion.contacto.direccionpostal
{
    [ServicioEntidadAPI(entidad: typeof(DireccionPostal))]
    internal class ServicioDireccionPostal : ServicioEntidadGenericaBase<DireccionPostal, DireccionPostalInsertar, DireccionPostalActualizar, DireccionPostalDespliegue, string>,
        IServicioEntidadAPI, IServicioDireccionPostal
    {



        private DbContextOrganizacion localContext;

        public ServicioDireccionPostal(DbContextOrganizacion context, ILogger<ServicioDireccionPostal> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.DireccionesPostales, logger, Reflector, cache)
        {
            interpreteConsulta = new InterpreteConsultaMySQL();
            localContext = context;
        }


        /// <summary>
        /// Acceso al repositorio de gestipon documental local
        /// </summary>
        private DbContextOrganizacion DB { get { return (DbContextOrganizacion)_db; } }

        public bool RequiereAutenticacion => true;



        public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            var update = data.Deserialize<DireccionPostalActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<DireccionPostalInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<DireccionPostal> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(DireccionPostal));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextOrganizacion.TABLA_DIRECCIONPOSTAL);

            int? total = null;
            List<DireccionPostal> elementos = localContext.DireccionesPostales.FromSqlRaw(query).ToList();

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
                return new(new List<DireccionPostal>(), total); ;
            }
        }


        #region Overrides para la personalización de la entidad Puesto

        public override async Task<ResultadoValidacion> ValidarInsertar(DireccionPostalInsertar data)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.DireccionesPostales.AnyAsync(a => a.CP == data.CP && a.NoExterior == data.NoExterior && a.NoInterior == data.NoInterior  && a.UOrgId == _contextoUsuario!.UOrgId && a.DominioId == _contextoUsuario.DominioId);

            if (encontrado)
            {
                resultado.Error = "CodigoPostal , NoInterio, NoExterior ".ErrorProcesoDuplicado();
            }
            else
            {
                resultado.Valido = true;
            }

            return resultado;
        }


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, DireccionPostal original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.DireccionesPostales.AnyAsync(a => a.Id == id && a.UOrgId == _contextoUsuario!.UOrgId && a.DominioId == _contextoUsuario.DominioId);

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


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, DireccionPostalActualizar actualizacion, DireccionPostal original)
        {
            ResultadoValidacion resultado = new();

            bool duplicado = await DB.DireccionesPostales.AnyAsync(a => a.Id != id && a.UOrgId == _contextoUsuario!.UOrgId && a.DominioId == _contextoUsuario.DominioId);

            if (!duplicado)
            {
                resultado.Error = "Id".ErrorProcesoNoEncontrado();

            }
            else
            {
                resultado.Valido = true;
            }


            return resultado;
        }


        public override DireccionPostal ADTOFull(DireccionPostalActualizar actualizacion, DireccionPostal actual)
        {
            actual.Id = actualizacion.Id;
            actual.Calle = actualizacion.Calle;
            actual.NoInterior = actualizacion.NoInterior;
            actual.NoExterior = actualizacion.NoExterior;
            actual.CP = actualizacion.CP;
            actual.Pais = actualizacion.Pais;
            actual.Estado = actualizacion.Estado;
            actual.Ciudad = actualizacion.Ciudad;
            actual.Referencia = actualizacion.Referencia;
            return actual;
        }

        public override DireccionPostal ADTOFull(DireccionPostalInsertar data)
        {
            DireccionPostal direccionPostal = new()
            {
                Id = Guid.NewGuid().ToString(),
                Calle = data.Calle,
                NoInterior = data.NoInterior,
                NoExterior = data.NoExterior,
                CP = data.CP,
                Pais = data.Pais,
                Estado = data.Estado,
                Ciudad = data.Ciudad,
                Referencia = data.Referencia,
                DominioId = _contextoUsuario.DominioId,
                UOrgId = _contextoUsuario.UOrgId


            };
            return direccionPostal;
        }

        public override DireccionPostalDespliegue ADTODespliegue(DireccionPostal data)
        {
            DireccionPostalDespliegue direccionPostalDespliegue = new()
            {
                Id = data.Id,
                Calle = data.Calle,
                NoInterior = data.NoInterior,
                NoExterior = data.NoExterior,
                CP = data.CP,
                Pais = data.Pais,
                Estado = data.Estado,
                Ciudad = data.Ciudad,
                Referencia = data.Referencia

            };
            return direccionPostalDespliegue;
        }

        #endregion



    }
}
