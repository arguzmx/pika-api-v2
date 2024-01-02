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

namespace pika.servicios.gestiondocumental.prestamos
{

    [ServicioEntidadAPI(entidad: typeof(Prestamo))]
    public class ServicioPrestamo : ServicioEntidadGenericaBase<Prestamo, PrestamoInsertar, PrestamoActualizar, PrestamoDespliegue, string>,
        IServicioEntidadAPI, IServicioPrestamo
    {


        private DbContextGestionDocumental localContext;
        public ServicioPrestamo(DbContextGestionDocumental context, ILogger<ServicioPrestamo> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.Prestamos, logger, Reflector, cache)
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
            var update = data.Deserialize<PrestamoActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<PrestamoInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<Prestamo> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(Prestamo));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextGestionDocumental.TablaPrestamo);

            int? total = null;
            List<Prestamo> elementos = localContext.Prestamos.FromSqlRaw(query).ToList();

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
                return new(new List<Prestamo>(), total); ;
            }
        }


        #region Overrides para la personalización de la entidad Archivo

        public override async Task<ResultadoValidacion> ValidarInsertar(PrestamoInsertar data)
        {
            ResultadoValidacion resultado = new();


            bool encontrado = false;


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


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Prestamo original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Prestamos.AnyAsync(a => a.Id == id);

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


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, PrestamoActualizar actualizacion, Prestamo original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Prestamos.AnyAsync(a => a.Id == id); 

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


        public override Prestamo ADTOFull(PrestamoActualizar actualizacion, Prestamo actual)
        {
            actual.ArchivoId = actualizacion.ArchivoId;
            actual.UsuarioDestinoId = actualizacion.UsuarioDestinoId;
            actual.FechaDevolucion = actualizacion.FechaDevolucion;
            actual.Descripcion = actualizacion.Descripcion;
            return actual;
        }

        public override Prestamo ADTOFull(PrestamoInsertar data)
        {
            Prestamo prestamo = new()
            {
                Id = Guid.NewGuid().ToString(),
                Folio= data.Folio,
                UsuarioDestinoId = data.UsuarioDestinoId,
                FechaProgramadaDevolucion = data.FechaProgramadaDevolucion,
                Descripcion = data.Descripcion,
                ArchivoId = "af9bf6a8-e66a-4b06-ba5a-93187a188735",
                FechaDevolucion =  DateTime.Now,
                UsuarioOrigenId="UsuarioOrigen321",

            };
            return prestamo;
        }

        public override PrestamoDespliegue ADTODespliegue(Prestamo data)
        {
            PrestamoDespliegue prestamoDespliegue = new()
            {
                Id = data.Id,
                ArchivoId = data.ArchivoId,
                UsuarioOrigenId = data.UsuarioOrigenId,
                UsuarioDestinoId = data.UsuarioDestinoId,
                FechaProgramadaDevolucion = data.FechaProgramadaDevolucion,
                FechaDevolucion = data.FechaDevolucion,
                Descripcion = data.Descripcion,
                CantidadActivos = data.CantidadActivos,
                Entregado = data.Entregado,
                Devuelto = data.Devuelto
                
            };
            return prestamoDespliegue;
        }

        #endregion


    }
}
