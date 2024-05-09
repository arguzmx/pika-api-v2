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
        private DbContextOrganizacion localContext;
        public ServicioDominio(DbContextOrganizacion context, ILogger<ServicioDominio> logger,
            IReflectorEntidadesAPI Reflector, IDistributedCache cache) 
            : base(context, context.Dominios, logger, Reflector, cache)
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
            try
            {
                var add = data.Deserialize<DominioInsertar>(JsonAPIDefaults());
                var temp = await this.Insertar(add);
                RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
                return respuesta;
            }
            catch (Exception ex)
            {

                throw;
            }
            
            
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
            ResultadoValidacion resultado = new ();

            // VErifica que el usuario no tengo otro dominio con el mismo nombre en un registro diferente al de actualizacion
            bool encontrado = await DB.Dominios.AnyAsync(a => a.Nombre == data.Nombre
            && a.UsuarioId == this._contextoUsuario!.UsuarioId);

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
            bool encontrado = await DB.Dominios.AnyAsync(a => a.Id==id);
            
            if (!encontrado)
            {
                
                resultado.Error = "Id".ErrorProcesoNoEncontrado();

            }
            else
            {
                bool EncontradoUsuarioDominio = await DB.UsuarioDominios.AnyAsync(a => a.DominioId == id);
                bool EncontradoUnidadOrganizacional = await DB.UnidadesOrganizacionales.AnyAsync(a => a.DominioId == id);
                bool EncontradoUsuarioUnidadOrganizacional = await DB.UsuariosUnidadesOrganizacionales.AnyAsync(a => a.DominioId == id);

                if (EncontradoUsuarioDominio || EncontradoUnidadOrganizacional || EncontradoUsuarioUnidadOrganizacional)
                {
                    resultado.Error = "Id en uso verifique que este no se encuentre en UsuarioDominio,UnidadOrganizacional O UsuarioUnidadOrganizacional".Error409();
                }
                else
                { resultado.Valido = true; }
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

                // VErifica que el usuario no tengo otro dominio con el mismo nombre en un registro diferente al de actualizacion
                bool duplicado = await DB.Dominios.AnyAsync(a => a.Nombre== actualizacion.Nombre 
                && a.UsuarioId == this._contextoUsuario!.UsuarioId && a.Id != id);

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
                UsuarioId = _contextoUsuario.UsuarioId
            };
            return archivo;
        }

        public override DominioDespliegue ADTODespliegue(Dominio data)
        {
            DominioDespliegue archivo = new DominioDespliegue()
            {
                Id = data.Id,
                Activo = data.Activo,
                FechaCreacion = data.FechaCreacion,
                Nombre = data.Nombre,
                UsuarioId = data.UsuarioId
            };
            return archivo;
        }
        public override async Task<(List<Dominio> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(Dominio));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextOrganizacion.TABLA_DOMINIO);

            int? total = null;
            List<Dominio> elementos = localContext.Dominios.FromSqlRaw(query).ToList();

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
                return new(new List<Dominio>(), total); ;
            }
        }
        #endregion

    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8603 // Possible null reference return.