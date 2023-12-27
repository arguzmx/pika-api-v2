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

namespace pika.servicios.gestiondocumental.seriedocumental
{
    [ServicioEntidadAPI(entidad: typeof(SerieDocumental))]
    public class ServicioSerieDocumental : ServicioEntidadGenericaBase<SerieDocumental, SerieDocumentalInsertar, SerieDocumentalActualizar, SerieDocumentalDespliegue, string>,
        IServicioEntidadAPI, IServicioSerieDocumental
    {
        private DbContextGestionDocumental localContext;
        public ServicioSerieDocumental(DbContextGestionDocumental context, ILogger<ServicioSerieDocumental> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.SerieDocumentales, logger, Reflector, cache)
        {
            interpreteConsulta = new InterpreteConsultaMySQL();
            localContext = context;
        }

        private DbContextGestionDocumental DB { get { return (DbContextGestionDocumental)_db; } }

        public bool RequiereAutenticacion => true;

        public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            var update = data.Deserialize<SerieDocumentalActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<SerieDocumentalInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<SerieDocumental> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(SerieDocumental));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextGestionDocumental.TablaSerieDocumental);

            int? total = null;
            List<SerieDocumental> elementos = localContext.SerieDocumentales.FromSqlRaw(query).ToList();

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
                return new(new List<SerieDocumental>(), total); ;
            }
        }

        #region Overrides para la personalización de la entidad SerieDocumental

        public override async Task<ResultadoValidacion> ValidarInsertar(SerieDocumentalInsertar data)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.SerieDocumentales.AnyAsync(a => a.Nombre == data.Nombre);

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


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, SerieDocumental original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.SerieDocumentales.AnyAsync(a => a.Id == id);

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


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, SerieDocumentalActualizar actualizacion, SerieDocumental original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.SerieDocumentales.AnyAsync(a => a.Id == id);

            if (!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {
                // Verifica que no haya un registro con el mismo nombre para el mismo dominio y UO en un resgitrso diferente
                bool duplicado = await DB.SerieDocumentales.AnyAsync(a => a.Nombre.Equals(actualizacion.Nombre));

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




        public override SerieDocumental ADTOFull(SerieDocumentalActualizar actualizacion, SerieDocumental actual)
        {
            actual.Clave = actualizacion.Clave;
            actual.Nombre = actualizacion.Nombre;
            actual.Raiz = actualizacion.Raiz;
            actual.SeriePadreId = actualizacion.SeriePadreId;
            actual.MesesArchivoTramite = actualizacion.MesesArchivoTramite;
            actual.MesesArchivoConcentracion = actualizacion.MesesArchivoConcentracion;
            actual.MesesArchivoHistorico = actualizacion.MesesArchivoHistorico;
            return actual;
        }


        public override SerieDocumental ADTOFull(SerieDocumentalInsertar data)
        {
            
            SerieDocumental seriedocumental = new()
            {
                Id = Guid.NewGuid().ToString(),
                CuadroClasificacionId = data.CuadroClasificacionId,
                Clave = data.Clave,
                Nombre = data.Nombre,
                Raiz = data.Raiz,
                SeriePadreId = data.SeriePadreId,
                MesesArchivoTramite = data.MesesArchivoTramite,
                MesesArchivoConcentracion = data.MesesArchivoConcentracion,
                MesesArchivoHistorico = data.MesesArchivoHistorico
               
            };
            return seriedocumental;
        }

       
        public override SerieDocumentalDespliegue ADTODespliegue(SerieDocumental data)
        {
            SerieDocumentalDespliegue seriedocumental = new()
            {
                Id = data.Id,
                CuadroClasificacionId = data.CuadroClasificacionId,
                Clave = data.Clave,
                Nombre = data.Nombre,
                Raiz = data.Raiz,
                SeriePadreId = data.SeriePadreId,
                MesesArchivoTramite = data.MesesArchivoTramite,
                MesesArchivoConcentracion = data.MesesArchivoConcentracion,
                MesesArchivoHistorico = data.MesesArchivoHistorico
            };
            return seriedocumental;
        }

        #endregion
    }
}
