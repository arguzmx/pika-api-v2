using api.comunes.metadatos;
using api.comunes.modelos.interpretes;
using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using CouchDB.Driver.DatabaseApiMethodOptions;
using CouchDB.Driver.Query.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using pika.modelo.contenido;
using pika.servicios.contenido.dbcontext;
using System.Text.Json;

namespace pika.servicios.contenido.Version
{
    [ServicioEntidadAPI(entidad: typeof(modelo.contenido.Version))]
    public class ServicioVersion : ServicioEntidadGenericaBase<modelo.contenido.Version, VersionInsertar, VersionActualizar, VersionDespliegue, string>,
IServicioEntidadAPI, IServicioVersion

    {
        private readonly VersionCouchDbContext dbCouch;
        private readonly DbSet<modelo.contenido.Version> _dbSetFull;

        public ServicioVersion(DbContext db, DbSet<modelo.contenido.Version> dbSetFull, ILogger logger, VersionCouchDbContext dbCouch, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(db, dbSetFull, logger, Reflector, cache)
        {
            interpreteConsulta = new InterpreteConsultaMySQL();
            this.dbCouch = dbCouch;
            _dbSetFull = dbSetFull;

        }

        /// <summary>
        /// Acceso al repositorio de gestipon documental local
        /// </summary>
        private DbContextContenido DB { get { return (DbContextContenido)_db; } }


        public bool RequiereAutenticacion => true;

        public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            Respuesta r = new Respuesta();

            var update = data.Deserialize<VersionActualizar>(JsonAPIDefaults());

            modelo.contenido.Version temp = await dbCouch.Versiones.FindAsync((string)id);
            if (temp == null) {
                r.HttpCode =  HttpCode.NotFound;
            } else
            {
                temp.Activa = update.Activa;


                await dbCouch.Versiones.AddOrUpdateAsync(temp);
                r.HttpCode = HttpCode.Ok;
            }

            return r;
 
        }

        public async Task<Respuesta> EliminarAPI(object id)
        {
            Respuesta Resp = new Respuesta();
            modelo.contenido.Version Ver = await dbCouch.Versiones.FindAsync((string)id);

             await dbCouch.Versiones.RemoveAsync(Ver);
           // await dbCouch.Versiones.AddOrUpdateAsync(Ver);
            
            if (Resp == null)
            {
                Resp.HttpCode = HttpCode.ServerError;
            }
            else {
                 Resp.HttpCode = HttpCode.Ok;
            }

            return Resp;
                
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
            var add = data.Deserialize<VersionInsertar>(JsonAPIDefaults());
            var entidad = ADTOFull(add);
            var temp = await dbCouch.Versiones.AddAsync(entidad);


            //var temp = await this.Insertar(add);
            RespuestaPayload<object> respuesta = new RespuestaPayload<object>()
            {
                Ok = temp != null
            };

            if (respuesta.Ok)
            {
                respuesta.Payload = temp;
            }

            return respuesta;

        }

        public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaAPI(Consulta consulta)
        {
            var temp = await this.Pagina(consulta);
            RespuestaPayload<PaginaGenerica<object>> respuesta = System.Text.Json.JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(System.Text.Json.JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaDespliegueAPI(Consulta consulta)
        {

            var temp = await this.PaginaDespliegue(consulta);
           // var get = 
            RespuestaPayload<PaginaGenerica<object>> respuesta = System.Text.Json.JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(System.Text.Json.JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijoAPI(Consulta consulta, string tipoPadre, string id)
        {
            var temp = await this.PaginaHijo(consulta, tipoPadre, id);
            RespuestaPayload<PaginaGenerica<object>> respuesta = System.Text.Json.JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(System.Text.Json.JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<PaginaGenerica<object>>> PaginaHijosDespliegueAPI(Consulta consulta, string tipoPadre, string id)
        {
            var temp = await this.PaginaHijosDespliegue(consulta, tipoPadre, id);
            RespuestaPayload<PaginaGenerica<object>> respuesta = System.Text.Json.JsonSerializer.Deserialize<RespuestaPayload<PaginaGenerica<object>>>(System.Text.Json.JsonSerializer.Serialize(temp));
            return respuesta;
        }


        public async Task<RespuestaPayload<object>> UnicaPorIdAPI(object id)
        {

            var temp = await dbCouch.Versiones.FindAsync((string)id);


            RespuestaPayload<object> respuesta = new RespuestaPayload<object>()
            {
                Ok = temp != null
            };

            if (respuesta.Ok)
            {
                respuesta.Payload = temp;
            }
            return respuesta;
        }

        public async Task<RespuestaPayload<object>> UnicaPorIdDespliegueAPI(object id)
        {
            var temp = await this.UnicaPorIdDespliegue((string)id);

            RespuestaPayload<object> respuesta = System.Text.Json.JsonSerializer.Deserialize<RespuestaPayload<object>>(System.Text.Json.JsonSerializer.Serialize(temp));
            return respuesta;
        }


        #region Overrides para la personalziación de la entidad Archivo

        public override async Task<ResultadoValidacion> ValidarInsertar(VersionInsertar data)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = true;

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


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, modelo.contenido.Version original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = true;

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


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, VersionActualizar actualizacion, modelo.contenido.Version original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = true;

            if (!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {

                bool duplicado = false;

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


        public override modelo.contenido.Version ADTOFull(VersionActualizar actualizacion, modelo.contenido.Version actual)
        {

            actual.Id = actualizacion.Id;
            actual.Activa = actualizacion.Activa;



            return actual;
        }

        public override modelo.contenido.Version ADTOFull(VersionInsertar data)
        {
            modelo.contenido.Version version = new modelo.contenido.Version()
            {
                Id = Guid.NewGuid().ToString(),
                ContenidoId = data.ContenidoId,
                Activa = data.Activa,
                FechaCreacion = DateTime.Now,
                CreadorId = "IdProvicio2222",
                VolumenId = data.VolumenId
            };


            return version;
        }

        public override VersionDespliegue ADTODespliegue(modelo.contenido.Version data)
        {
            VersionDespliegue versionDespliegue = new VersionDespliegue()
            {
                Id = data.Id,
                ContenidoId = data.ContenidoId,
                Activa = data.Activa,
                FechaCreacion = data.FechaCreacion,
                ConteoPartes = data.ConteoPartes,
                TamanoBytes = data.TamanoBytes,
                VolumenId = data.VolumenId
            };
            return versionDespliegue;
        }

        #endregion


    }
}
