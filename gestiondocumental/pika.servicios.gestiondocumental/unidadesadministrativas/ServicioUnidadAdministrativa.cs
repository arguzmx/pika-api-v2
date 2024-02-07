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
using pika.modelo.gestiondocumental.UnidadesAdministrativas;
using pika.servicios.gestiondocumental.dbcontext;
using pika.servicios.gestiondocumental.seriedocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.unidadesadministrativas
{
    [ServicioEntidadAPI(entidad: typeof(UnidadAdministrativa))]
    public class ServicioUnidadAdministrativa : ServicioEntidadGenericaBase<UnidadAdministrativa, UnidadAdministrativaInsertar, UnidadAdministrativaActualizar, UnidadAdministrativaDespliegue, string>,
        IServicioEntidadAPI, IServicioUnidadAdministrativa
    {
        private DbContextGestionDocumental localContext;
        public ServicioUnidadAdministrativa(DbContextGestionDocumental context, ILogger<ServicioUnidadAdministrativa> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.UnidadesAdministrativas, logger, Reflector, cache)
        {
            interpreteConsulta = new InterpreteConsultaMySQL();
            localContext = context;
        }

        private DbContextGestionDocumental DB { get { return (DbContextGestionDocumental)_db; } }

        public bool RequiereAutenticacion => true;

        public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            var update = data.Deserialize<UnidadAdministrativaActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<UnidadAdministrativaInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<UnidadAdministrativa> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(UnidadAdministrativa));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextGestionDocumental.TablaUnidadAdministrativa);

            int? total = null;
            List<UnidadAdministrativa> elementos = localContext.UnidadesAdministrativas.FromSqlRaw(query).ToList();

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
                return new(new List<UnidadAdministrativa>(), total); ;
            }
        }

        #region Overrides para la personalización de la entidad UnidadAdministrativa

        public override async Task<ResultadoValidacion> ValidarInsertar(UnidadAdministrativaInsertar data)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.UnidadesAdministrativas.AnyAsync(a => a.Nombre == data.Nombre);

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


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, UnidadAdministrativa original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.UnidadesAdministrativas.AnyAsync(a => a.Id == id);

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


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, UnidadAdministrativaActualizar actualizacion, UnidadAdministrativa original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.UnidadesAdministrativas.AnyAsync(a => a.Id == id);

            if (!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {
                // Verifica que no haya un registro con el mismo nombre para el mismo dominio y UO en un resgitrso diferente
                bool duplicado = await DB.UnidadesAdministrativas.AnyAsync(a => a.Nombre.Equals(actualizacion.Nombre));

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




        public override UnidadAdministrativa ADTOFull(UnidadAdministrativaActualizar actualizacion, UnidadAdministrativa actual)
        {
            actual.Nombre = actualizacion.Nombre;
            actual.Responsable = actualizacion.Responsable;
            actual.Cargo = actualizacion.Cargo;
            actual.Telefono = actualizacion.Telefono;
            actual.Email = actualizacion.Email;
            actual.Domicilio = actualizacion.Domicilio;
            actual.UbicacionFisica = actualizacion.UbicacionFisica;
            actual.ArchivoTramiteId = actualizacion.ArchivoTramiteId;
            actual.ArchivoConcentracionId = actualizacion.ArchivoConcentracionId;
            actual.ArchivoHistoricoId = actualizacion.ArchivoConcentracionId;
            return actual;
        }


        public override UnidadAdministrativa ADTOFull(UnidadAdministrativaInsertar data)
        {

            UnidadAdministrativa unidadAdministrativa = new()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = data.Nombre,
                Responsable = data.Responsable,
                Cargo = data.Cargo,
                Telefono = data.Telefono,
                Email = data.Email,
                Domicilio = data.Domicilio,
                UbicacionFisica = data.UbicacionFisica,
                ArchivoTramiteId = data.ArchivoTramiteId,
                ArchivoConcentracionId = data.ArchivoConcentracionId,
                ArchivoHistoricoId = data.ArchivoHistoricoId

            };
            return unidadAdministrativa;
        }


        public override UnidadAdministrativaDespliegue ADTODespliegue(UnidadAdministrativa data)
        {
            UnidadAdministrativaDespliegue unidadAdministrativaDespliegue = new()
            {
                Nombre = data.Nombre,
                Responsable = data.Responsable,
                Cargo = data.Cargo,
                Telefono = data.Telefono,
                Email = data.Email,
                Domicilio = data.Domicilio,
                UbicacionFisica = data.UbicacionFisica,
                ArchivoTramiteId = data.ArchivoTramiteId,
                ArchivoConcentracionId = data.ArchivoConcentracionId,
                ArchivoHistoricoId = data.ArchivoHistoricoId
            };
            return unidadAdministrativaDespliegue;
        }

        #endregion
    }
}
