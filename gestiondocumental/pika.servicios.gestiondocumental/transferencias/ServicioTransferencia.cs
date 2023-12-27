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

namespace pika.servicios.gestiondocumental.transferencias
{
    [ServicioEntidadAPI(entidad: typeof(Transferencia))]
    public class ServicioTransferencia : ServicioEntidadGenericaBase<Transferencia, TransferenciaInsertar, TransferenciaActualizar, TransferenciaDespliegue, string>,
        IServicioEntidadAPI, InterfaceServicioTransferencia
    {


        private DbContextGestionDocumental localContext;

        public ServicioTransferencia(DbContextGestionDocumental context, ILogger<ServicioTransferencia> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.Transferencias, logger, Reflector, cache)
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
            var update = data.Deserialize<TransferenciaActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<TransferenciaInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<Transferencia> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(Transferencia));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextGestionDocumental.TablaTransferencias);

            int? total = null;
            List<Transferencia> elementos = localContext.Transferencias.FromSqlRaw(query).ToList();

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
                return new(new List<Transferencia>(), total); ;
            }
        }








        #region Overrides para la personalizacion de la entidad transferencia

        public override async Task<ResultadoValidacion> ValidarInsertar(TransferenciaInsertar insertar)
        {

            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Transferencias.AnyAsync(a => a.Nombre == insertar.Nombre);

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

        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Transferencia original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Transferencias.AnyAsync(a => a.Id == id);

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

        public override async Task<ResultadoValidacion> ValidarActualizar(string id, TransferenciaActualizar actualizar, Transferencia original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Transferencias.AnyAsync(a => a.Id == id);

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

        public override Transferencia ADTOFull(TransferenciaActualizar actualizacion, Transferencia actual)
        {
            actual.Nombre = actualizacion.Nombre;
            actual.Folio = actualizacion.Folio;
            actual.ArchivoOrigenId = actualizacion.ArchivoOrigenId;
            actual.ArchivoDestinoId = actualizacion.ArchivoDestinoId;
            actual.CuadroClasificacionId = actualizacion.CuadroClasificacionId;
            actual.SerieDocumentalId = actualizacion.SerieDocumentalId;
            actual.RangoDias = actualizacion.RangoDias;
            return actual;
        }

        public override Transferencia ADTOFull(TransferenciaInsertar insertar)
        {
            Transferencia transferencia = new()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = insertar.Nombre,
                Folio = insertar.Folio,
                ArchivoOrigenId = insertar.ArchivoOrigenId,
                ArchivoDestinoId = insertar.ArchivoDestinoId,
                CuadroClasificacionId = insertar.CuadroClasificacionId,
                SerieDocumentalId = insertar.SerieDocumentalId,
                EstadoTransferenciaId = insertar.EstadoTransferenciaId,
                RangoDias = insertar.RangoDias,
                UsuarioId="UsuarioDePruieba2rrt5"
            ,
            };
            return transferencia;
        }

        public override TransferenciaDespliegue ADTODespliegue(Transferencia data)
        {
            TransferenciaDespliegue transferenciaDespliegue = new()
            {
                Id = data.Id,
                Nombre = data.Nombre,
                Folio = data.Folio,
                ArchivoOrigenId = data.ArchivoOrigenId,
                ArchivoDestinoId= data.ArchivoDestinoId,
                CuadroClasificacionId = data.CuadroClasificacionId,
                SerieDocumentalId= data.SerieDocumentalId,
                RangoDias = data.RangoDias,
                CantidadActivos= data.CantidadActivos,
                FechaCreacion= data.FechaCreacion,
                EstadoTransferenciaId = data.EstadoTransferenciaId,
                UsuarioId= data.UsuarioId
            };
            return transferenciaDespliegue;
        }



        #endregion


    }
}
