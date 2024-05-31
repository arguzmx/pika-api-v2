using api.comunes.metadatos;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pika.servicios.seguridad.modulo
{
    public class ServicioModulo : ServicioEntidadGenericaBase<Modulo, ModuloInsertar, ModuloActualizar, ModuloDespliegue, string>,
    IServicioEntidadAPI, IServicioModulo
    {

        private DbContextSeguridad localContext;

        public ServicioModulo(DbContextSeguridad context, ILogger<ServicioModulo> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.Modulos, logger, Reflector, cache)
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
            var update = data.Deserialize<ModuloActualizar>(JsonAPIDefaults());
            return await Actualizar((string)id, update);
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
            var add = data.Deserialize<ModuloInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<Modulo> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(Modulo));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextSeguridad.TablaModulos);

            int? total = null;
            List<Modulo> elementos = localContext.Modulos.FromSqlRaw(query).ToList();

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
                return new(new List<Modulo>(), total); ;
            }
        }


        #region Overrides para la personalización de la entidad Repositorio

        public override async Task<ResultadoValidacion> ValidarInsertar(ModuloInsertar data)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Modulos.AnyAsync(a => a.Nombre == data.Nombre);

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


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Modulo original)
        {

            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Modulos.AnyAsync(a => a.Id == new Guid(id));

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


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, ModuloActualizar actualizacion, Modulo original)
        {
            ResultadoValidacion resultado = new();

            bool duplicado = await DB.Modulos.AnyAsync(a => a.Id != new Guid(id) && a.Nombre.Equals(actualizacion.Nombre));

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


        public override Modulo ADTOFull(ModuloActualizar actualizacion, Modulo actual)
        {
            actual.Nombre = actualizacion.Nombre;
            return actual;
        }

        public override Modulo ADTOFull(ModuloInsertar data)
        {
            Modulo Modulo = new()
            {
                Id = Guid.NewGuid(),
                Nombre = data.Nombre,
                Descripcion = data.Descripcion,

            };
            return Modulo;
        }

        public override ModuloDespliegue ADTODespliegue(Modulo data)
        {
            ModuloDespliegue ModuloDespliegue = new()
            {
                Id = data.Id,
                Nombre = data.Nombre,
                Descripcion = data.Descripcion
            };
            return ModuloDespliegue;
        }



        #endregion


    }
}
