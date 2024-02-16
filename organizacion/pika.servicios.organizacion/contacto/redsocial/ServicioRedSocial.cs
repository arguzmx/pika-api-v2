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
using pika.servicios.organizacion.puesto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pika.servicios.organizacion.contacto.redsocial
{
    [ServicioEntidadAPI(entidad: typeof(RedSocial))]
    public class ServicioRedSocial : ServicioEntidadGenericaBase<RedSocial, RedSocialInsertar, RedSocialActualizar, RedSocialDespliegue, string>,
        IServicioEntidadAPI, IServicioRedSocial
    {


        private DbContextOrganizacion localContext;

        public ServicioRedSocial(DbContextOrganizacion context, ILogger<ServicioRedSocial> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.RedesSociales, logger, Reflector, cache)
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
            var update = data.Deserialize<RedSocialActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<RedSocialInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<RedSocial> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(RedSocial));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextOrganizacion.TABLA_REDSOCIAL);

            int? total = null;
            List<RedSocial> elementos = localContext.RedesSociales.FromSqlRaw(query).ToList();

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
                return new(new List<RedSocial>(), total); ;
            }
        }


        #region Overrides para la personalización de la entidad RedSocial

        public override async Task<ResultadoValidacion> ValidarInsertar(RedSocialInsertar data)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.RedesSociales.AnyAsync(a => a.Url == data.Url && a.UOrgId == _contextoUsuario!.UOrgId && a.DominioId == _contextoUsuario.DominioId);

            if (encontrado)
            {
                resultado.Error = "Url".ErrorProcesoDuplicado();
            }
            else
            {
                resultado.Valido = true;
            }

            return resultado;
        }


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, RedSocial original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.RedesSociales.AnyAsync(a => a.Id == id && a.UOrgId == _contextoUsuario!.UOrgId && a.DominioId == _contextoUsuario.DominioId);

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


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, RedSocialActualizar actualizacion, RedSocial original)
        {
            ResultadoValidacion resultado = new();

            bool duplicado = await DB.RedesSociales.AnyAsync(a => a.Id != id && a.Url == actualizacion.Url && a.UOrgId == _contextoUsuario!.UOrgId && a.DominioId == _contextoUsuario.DominioId);

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

        // :)
        public override RedSocial ADTOFull(RedSocialActualizar actualizacion, RedSocial actual)
        {
            actual.Id = actualizacion.Id;
            actual.Url = actualizacion.Url;
            actual.TipoRedSocialId = actualizacion.TipoRedSocialId;
            return actual;
        }

        public override RedSocial ADTOFull(RedSocialInsertar data)
        {
            RedSocial contenido = new()
            {
                Id = Guid.NewGuid().ToString(),
                Url = data.Url,
                TipoRedSocialId = data.TipoRedSocialId,
                DominioId = _contextoUsuario.DominioId,
                UOrgId = _contextoUsuario.UOrgId


            };
            return contenido;
        }

        public override RedSocialDespliegue ADTODespliegue(RedSocial data)
        {
            RedSocialDespliegue redSocialDespliegue = new()
            {
                Id = data.Id,
                Url = data.Url
            };
            return redSocialDespliegue;
        }

        #endregion



    }
}
