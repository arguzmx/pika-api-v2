using api.comunes.metadatos;
using api.comunes.modelos.abstracciones;
using api.comunes.modelos.interpretes;
using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using pika.modelo.seguridad;
using pika.servicios.seguridad.dbcontext;
using System.Text.Json;

namespace pika.servicios.seguridad.aplicacion
{
    [ServicioEntidadAPI(entidad: typeof(Aplicacion))]
    public class ServicioAplicacion : ServicioEntidadGenericaBase<Aplicacion, AplicacionInsertar, AplicacionActualizar, AplicacionDespliegue, string>,
    IServicioEntidadAPI, IServicioAplicacion
    {

        private DbContextSeguridad localContext;

        public ServicioAplicacion(DbContextSeguridad context, ILogger<ServicioAplicacion> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.Aplicaciones, logger, Reflector, cache)
        {
            interpreteConsulta = new InterpreteConsultaMySQL();
            localContext = context;
        }


        /// <summary>
        /// Acceso al repositorio de gestipon documental local
        /// </summary>
        private DbContextSeguridad DB { get { return (DbContextSeguridad)_db; } }

        public bool RequiereAutenticacion => true;



        public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            var update = data.Deserialize<AplicacionActualizar>(JsonAPIDefaults());
            return await ActualizarAplicacion((string)id, update);
        }

        public async Task<Respuesta> EliminarAPI(object id)
        {
            return await Eliminar((string)id);
        }

        public Entidad EntidadDespliegueAPI()
        {
            return EntidadDespliegue();
        }

        public Entidad EntidadInsertAPI()
        {
            return EntidadInsert();
        }

        public Entidad EntidadRepoAPI()
        {
            return EntidadRepo();
        }

        public Entidad EntidadUpdateAPI()
        {
            return EntidadUpdate();
        }

        public void EstableceContextoUsuarioAPI(ContextoUsuario contexto)
        {
            EstableceContextoUsuario(contexto);
        }

        public ContextoUsuario? ObtieneContextoUsuarioAPI()
        {
            return _contextoUsuario;
        }

        public async Task<RespuestaPayload<object>> InsertarAPI(JsonElement data)
        {
            var add = data.Deserialize<AplicacionInsertar>(JsonAPIDefaults());
            
            var temp = await Insertar(add);
            
            RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaAPI(Consulta consulta)
        {
            var temp = await Pagina(consulta);
            RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaDespliegueAPI(Consulta consulta)
        {
            var temp = await PaginaDespliegue(consulta);
            RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijoAPI(Consulta consulta, string tipoPadre, string id)
        {
            var temp = await PaginaHijo(consulta, tipoPadre, id);
            RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijosDespliegueAPI(Consulta consulta, string tipoPadre, string id)
        {
            var temp = await PaginaHijosDespliegue(consulta, tipoPadre, id);
            RespuestaPayload<PaginaGenerica<object>> respuesta = JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }


        public async Task<RespuestaPayload<object>> UnicaPorIdAPI(object id)
        {
            var temp = await UnicaPorId((string)id);
            RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<object>> UnicaPorIdDespliegueAPI(object id)
        {
            var temp = await UnicaPorIdDespliegue((string)id);

            RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }


        public override async Task<(List<Aplicacion> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(Aplicacion));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextSeguridad.TablaAplicacion);

            int? total = null;
            List<Aplicacion> elementos = localContext.Aplicaciones.FromSqlRaw(query).ToList();

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
                return new(new List<Aplicacion>(), total); ;
            }
        }


        #region Overrides para la personalización de la entidad Repositorio

        public override async Task<ResultadoValidacion> ValidarInsertar(AplicacionInsertar data)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Aplicaciones.AnyAsync(a => a.Nombre == data.Nombre);

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


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Aplicacion original)
        {

            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Aplicaciones.AnyAsync(a => a.Id == id);

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


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, AplicacionActualizar actualizacion, Aplicacion original)
        {
            ResultadoValidacion resultado = new();

            bool duplicado = await DB.Aplicaciones.AnyAsync(a => a.Id != id && a.Nombre.Equals(actualizacion.Nombre));

            if (duplicado)
            {
                resultado.Error = "Nombre".ErrorProcesoDuplicado();

            }
            else
            {
                resultado.Valido = true;
            }


            return resultado;
        }


        public override Aplicacion ADTOFull(AplicacionActualizar actualizacion, Aplicacion actual)
        {
            actual.Nombre = actualizacion.Nombre;
            return actual;
        }

        public override Aplicacion ADTOFull(AplicacionInsertar data)
        {
            Aplicacion Aplicacion = new()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = data.Nombre,
                Descripcion = data.Descripcion,

            };
            return Aplicacion;
        }

        public override AplicacionDespliegue ADTODespliegue(Aplicacion data)
        {
            AplicacionDespliegue AplicacionDespliegue = new()
            {
                Id = data.Id,
                Nombre = data.Nombre,
                Descripcion = data.Descripcion
            };
            return AplicacionDespliegue;
        }

        private async Task<Respuesta> ActualizarAplicacion(string id, AplicacionActualizar data)
        {
            var respuesta = new Respuesta();
            try
            {
                if (string.IsNullOrEmpty(id) || data == null)
                {
                    respuesta.HttpCode = HttpCode.BadRequest;
                    return respuesta;
                }

                Guid idGuid = Guid.Parse(id);
                Aplicacion actual = _dbSetFull.Find(idGuid);

                if (actual == null)
                {
                    respuesta.HttpCode = HttpCode.NotFound;
                    return respuesta;
                }

                var resultadoValidacion = await ValidarActualizar(id, data, actual);
                if (resultadoValidacion.Valido)
                {
                    var entidad = ADTOFull(data, actual);
                    _dbSetFull.Update(entidad);
                    await _db.SaveChangesAsync();

                    respuesta.Ok = true;
                    respuesta.HttpCode = HttpCode.Ok;
                }
                else
                {
                    respuesta.Error = resultadoValidacion.Error;
                    respuesta.HttpCode = resultadoValidacion.Error?.HttpCode ?? HttpCode.None;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Insertar {ex.Message}");
                _logger.LogError($"{ex}");

                respuesta.Error = new ErrorProceso() { Codigo = "", HttpCode = HttpCode.ServerError, Mensaje = ex.Message };
                respuesta.HttpCode = HttpCode.ServerError;
            }

            return respuesta;
        }



        #endregion


    }
}

