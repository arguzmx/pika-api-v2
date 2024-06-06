using api.comunes.metadatos;
using api.comunes.modelos.interpretes;
using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using pika.modelo.contenido.demometadatos;
using pika.servicios.contenido.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pika.servicios.contenido.demometadatos
{
    [ServicioEntidadAPI(entidad: typeof(DemoMetadatos))]
    public class ServicioDemoMetadatos : ServicioEntidadGenericaBase<DemoMetadatos, DemoMetadatosInsertar, DemoMetadatosActualizar, DemoMetadatosDespliegue, string>,
        IServicioEntidadAPI, IServicioDemoMetadatos
    {

        private DbContextContenido localContext;

        public ServicioDemoMetadatos(DbContextContenido context, ILogger<ServicioDemoMetadatos> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.DemoMetadatos, logger, Reflector, cache)
        {
            interpreteConsulta = new InterpreteConsultaMySQL();
            localContext = context;
        }


        /// <summary>
        /// Acceso al repositorio de gestipon documental local
        /// </summary>
        private DbContextContenido DB { get { return (DbContextContenido)_db; } }

        public bool RequiereAutenticacion => true;



        public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            var update = data.Deserialize<DemoMetadatosActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<DemoMetadatosInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<DemoMetadatos> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(DemoMetadatos));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextContenido.TablaDemoMetadatos);

            int? total = null;
            List<DemoMetadatos> elementos = localContext.DemoMetadatos.FromSqlRaw(query).ToList();

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
                return new(new List<DemoMetadatos>(), total); ;
            }
        }


        #region Overrides para la personalización de la entidad Repositorio

        public override async Task<ResultadoValidacion> ValidarInsertar(DemoMetadatosInsertar data)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.DemoMetadatos.AnyAsync(a => a.Nombre == data.Nombre);

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


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, DemoMetadatos original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.DemoMetadatos.AnyAsync(a => a.Id == id);

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


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, DemoMetadatosActualizar actualizacion, DemoMetadatos original)
        {
            ResultadoValidacion resultado = new();

            bool duplicado = await DB.DemoMetadatos.AnyAsync(a => a.Id != id && a.Nombre.Equals(actualizacion.Nombre));

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


        public override DemoMetadatos ADTOFull(DemoMetadatosActualizar actualizacion, DemoMetadatos actual)
        {
            actual.Id = actualizacion.Id;
            actual.Nombre = actualizacion.Nombre;
            actual.Curriculum = actualizacion.Curriculum;
            actual.Activo = actualizacion.Activo;
            actual.FechaNacimiento = actualizacion.FechaNacimiento;
            actual.Genero = actualizacion.Genero;
            actual.Experiencia = actualizacion.Experiencia;
            actual.HoraDeLunch = actualizacion.HoraDeLunch;
            actual.PrecioPorHora  = actualizacion.PrecioPorHora;
            return actual;
        }

        public override DemoMetadatos ADTOFull(DemoMetadatosInsertar data)
        {
            DemoMetadatos contenido = new()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = data.Nombre,
                Experiencia = data.Experiencia,
                PrecioPorHora = data.PrecioPorHora,
                Curriculum = data.Curriculum,
                FechaNacimiento = data.FechaNacimiento,
                HoraDeLunch = data.HoraDeLunch,
                FechaCreacion = DateTime.Now,
                Activo = data.Activo,
                Genero = data.Genero
            };
            return contenido;
        }

        public override DemoMetadatosDespliegue ADTODespliegue(DemoMetadatos data)
        {
            DemoMetadatosDespliegue contenidoDespliegue = new()
            {
                Id = data.Id,
                Nombre = data.Nombre,
                FechaNacimiento = data.FechaNacimiento,
                FechaCreacion = data.FechaCreacion,
                Experiencia = data.Experiencia,
                Activo = data.Activo,
                Genero = data.Genero,
                HoraDeLunch = data.HoraDeLunch,
                PrecioPorHora = data.PrecioPorHora
            };
            return contenidoDespliegue;
        }

        #endregion


    }
}