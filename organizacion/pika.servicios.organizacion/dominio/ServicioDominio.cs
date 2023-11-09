using api.comunes.metadatos;
using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.modelo.organizacion;
using pika.servicios.organizacion.dbcontext;
using System.Text.Json;


#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
namespace pika.servicios.organizacion.dominio
{


    [ServicioEntidadAPI(entidad: typeof(Dominio))]
    public class ServicioDominio : ServicioEntidadGenericaBase<Dominio, DominioInsertar, DominioActualizar, DominioDespliegue, string>,
        IServicioEntidadAPI, IServicioDominio
    {

        public ServicioDominio(DbContextOrganizacion context, ILogger<ServicioDominio> logger) : base(context, context.Dominios, logger)
        {
        }


        /// <summary>
        /// Acceso al repositorio de gestipon documental local
        /// </summary>
        private DbContextOrganizacion DB { get { return (DbContextOrganizacion)_db; } }

        public bool RequiereAutenticacion => true;

        public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            var update = data.Deserialize<DominioActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<DominioInsertar>(JsonAPIDefaults());
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
   



        #region Overrides para la personalizacion de la entidad dominio

        public override async Task<ResultadoValidacion> ValidarInsertar(DominioInsertar data)
        {
            ResultadoValidacion resultado = new();

            resultado.Valido = false;
            bool encontrado = await DB.Dominios.AnyAsync(a =>  a.Nombre == data.Nombre);

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


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Dominio original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.UnidadesOrganizacionales.AnyAsync(a => a.DominioId==original.Id);
            bool encontrado2 = await DB.UsuarioDominios.AnyAsync(a => a.DominioId==original.Id);

            resultado.Valido = false;
            if (encontrado || encontrado2)
            {
                
                resultado.Error = "Id".Error409();

            }
            else
            {
                resultado.Valido = true;
            }

            return resultado;
        }
     
        

        public override async Task<ResultadoValidacion> ValidarActualizar(string id, DominioActualizar actualizacion, Dominio original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Dominios.AnyAsync(a => a.Id == id);

            resultado.Valido = false;
            if (!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {

                bool duplicado = await DB.Dominios.AnyAsync(a => a.Nombre== actualizacion.Nombre);

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


        public override Dominio ADTOFull(DominioActualizar actualizacion, Dominio actual)
        {
            actual.Nombre = actualizacion.Nombre;
            actual.Activo = actualizacion.Activo;
            return actual;
        }

        public override Dominio ADTOFull(DominioInsertar data)
        {
            Dominio archivo = new Dominio()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = data.Nombre,
                Activo = data.Activo,
            };
            return archivo;
        }

        public override DominioDespliegue ADTODespliegue(Dominio data)
        {
            DominioDespliegue archivo = new DominioDespliegue()
            {
                Id = data.Id,
            };
            return archivo;
        }

        #endregion

    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8603 // Possible null reference return.