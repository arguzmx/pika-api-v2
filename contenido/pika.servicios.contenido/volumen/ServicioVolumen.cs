using api.comunes.metadatos;
using api.comunes.modelos.interpretes;
using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using pika.modelo.contenido;
using pika.servicios.contenido.dbcontext;
using System.Text.Json;

namespace pika.servicios.contenido.volumen
{

    [ServicioEntidadAPI(entidad: typeof(Volumen))]
    public class ServicioVolumen : ServicioEntidadGenericaBase<Volumen,VolumenInsertar,VolumenActualizar,VolumenDespliegue,string>,
        IServicioEntidadAPI, IServicioVolumen
    {

        private DbContextContenido localContext;

        public ServicioVolumen(DbContextContenido context, ILogger<ServicioVolumen> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.Volumenes, logger, Reflector, cache)
        {
            interpreteConsulta = new InterpreteConsultaMySQL();
            localContext = context;
        }


        /// <summary>
        /// Acceso al repositorio de gestipon documental local
        /// </summary>
        private DbContextContenido DB { get { return (DbContextContenido)_db; } }

        public bool RequiereAutenticacion => true;

        public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            var update = data.Deserialize<VolumenActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<VolumenInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<Volumen> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(Volumen));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextContenido.TablaVolumen);

            int? total = null;
            List<Volumen> elementos = localContext.Volumenes.FromSqlRaw(query).ToList();

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
                return new(new List<Volumen>(), total); ;
            }
        }


        #region Overrides para la personalización de la entidad Volumen

        public override async Task<ResultadoValidacion> ValidarInsertar(VolumenInsertar data)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Volumenes.AnyAsync(a => a.UOrgId == _contextoUsuario!.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Nombre == data.Nombre);

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


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Volumen original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Volumenes.AnyAsync(a => a.UOrgId == _contextoUsuario!.UOrgId
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


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, VolumenActualizar actualizacion, Volumen original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Volumenes.AnyAsync(a => a.UOrgId == _contextoUsuario!.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id == id);

            if (!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {
                // Verifica que no haya un registro con el mismo nombre para el mismo dominio y UO en un resgitrso diferente
                bool duplicado = await DB.Volumenes.AnyAsync(a => a.UOrgId == _contextoUsuario!.UOrgId
                    && a.DominioId == _contextoUsuario.DominioId
                    && a.Id != id
                    && a.Nombre.Equals(actualizacion.Nombre));

                if (duplicado)
                {
                    resultado.Error = "Nombre".ErrorProcesoDuplicado();

                }
                else
                {
                    resultado.Valido = true;
                }
            }

            return resultado;
        }


        public override Volumen ADTOFull(VolumenActualizar actualizacion, Volumen actual)
        {
            actual.Nombre = actualizacion.Nombre;
            actual.TipoGestorESId = actualizacion.TipoGestorESId;
            actual.TamanoMaximo = actualizacion.TamanoMaximo;
            actual.Activo = actualizacion.Activo;
            actual.EscrituraHabilitada = actualizacion.EscrituraHabilitada;
            return actual;
        }

        public override Volumen ADTOFull(VolumenInsertar data)
        {
            Volumen volumen = new()
            {
                Id = Guid.NewGuid().ToString(),
                UOrgId = _contextoUsuario!.UOrgId!,
                DominioId = _contextoUsuario!.DominioId!,
                Nombre = data.Nombre,
                TipoGestorESId = data.TipoGestorESId,
                TamanoMaximo =data.TamanoMaximo,
                Activo = data.Activo,
                EscrituraHabilitada = data.EscrituraHabilitada
            };
            return volumen;
        }

        public override VolumenDespliegue ADTODespliegue(Volumen data)
        {
            VolumenDespliegue volumenDespliegue = new()
            {
                Id = data.Id,
                Nombre = data.Nombre
            };
            return volumenDespliegue;
        }

        #endregion






    }
}
