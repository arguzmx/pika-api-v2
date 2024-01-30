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
using pika.servicios.organizacion.dominio;
using pika.servicios.organizacion.puesto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pika.servicios.organizacion.contacto.telefono
{


    [ServicioEntidadAPI(entidad: typeof(Telefono))]
    public class ServicioTelefono : ServicioEntidadGenericaBase<Telefono, TelefonoInsertar, TelefonoActualizar, TelefonoDespliegue, string>,
        IServicioEntidadAPI, IServicioTelefono
    {

        private DbContextOrganizacion localContext;

        public ServicioTelefono(DbContextOrganizacion context, ILogger<ServicioTelefono> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.Telefonos, logger, Reflector, cache)
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
            var update = data.Deserialize<TelefonoActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<TelefonoInsertar>(JsonAPIDefaults());
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



        public override async Task<(List<Telefono> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(Telefono));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextOrganizacion.TABLA_TELEFONO);

            int? total = null;
            List<Telefono> elementos = localContext.Telefonos.FromSqlRaw(query).ToList();

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
                return new(new List<Telefono>(), total); ;
            }
        }



        #region Overrides para la personalizacion de la entidad telefono

        public override async Task<ResultadoValidacion> ValidarInsertar(TelefonoInsertar data)
        {
            ResultadoValidacion resultado = new();

            // VErifica que el usuario no tengo otro dominio con el mismo nombre en un registro diferente al de actualizacion
            bool encontrado = await DB.Telefonos.AnyAsync(a => _contextoUsuario.DominioId != _contextoUsuario.DominioId);

            if (encontrado)
            {
                resultado.Error = "DominioId".ErrorProcesoNoEncontrado();

            }
            else
            {
                resultado.Valido = true;
            }

            return resultado;
        }


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Telefono original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Telefonos.AnyAsync(a => a.Id == id);

            if (!encontrado)
            {

                resultado.Error = "Id".ErrorProcesoNoEncontrado();

            }
            else
            {
                resultado.Valido = true;
            }

            return resultado;
        }



        public override async Task<ResultadoValidacion> ValidarActualizar(string id, TelefonoActualizar actualizacion, Telefono original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Telefonos.AnyAsync(a => a.Id == id);

            resultado.Valido = false;
            if (!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {

                // VErifica que el usuario no tengo otro dominio con el mismo nombre en un registro diferente al de actualizacion
                
                    resultado.Valido = true;
                
            }

            return resultado;
        }


        public override Telefono ADTOFull(TelefonoActualizar actualizacion, Telefono actual)
        {
           
            actual.Numero = actualizacion.Numero;
            actual.Extension = actualizacion.Extension;
            actual.Horario = actualizacion.Horario;
            return actual;
        }

        public override Telefono ADTOFull(TelefonoInsertar data)
        {
            Telefono telefono = new Telefono()
            {
                Id = Guid.NewGuid().ToString(),
                Numero = data.Numero,
                Extension = data.Extension,
                Horario = data.Horario,
                DominioId = _contextoUsuario.DominioId,
                UOrgId = _contextoUsuario.UOrgId
            };
            return telefono;
        }

        public override TelefonoDespliegue ADTODespliegue(Telefono data)
        {
            TelefonoDespliegue telefonoDespliegue = new TelefonoDespliegue()
            {
                Id = data.Id,
                Numero = data.Numero,
                Extension = data.Extension,
                Horario = data.Horario
            };
            return telefonoDespliegue;
        }

        #endregion

    }
}
