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
using pika.servicios.gestiondocumental.seriedocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.acervo
{
    [ServicioEntidadAPI(entidad: typeof(Activo))]
    public class ServicioActivo : ServicioEntidadGenericaBase<Activo, ActivoInsertar, ActivoActualizar, ActivoDespliegue, string>,
        IServicioEntidadAPI, IServicioActivo
    {
        private DbContextGestionDocumental localContext;
        public ServicioActivo(DbContextGestionDocumental context, ILogger<ServicioActivo> logger, IReflectorEntidadesAPI Reflector, IDistributedCache cache) : base(context, context.Activos, logger, Reflector, cache)
        {
            interpreteConsulta = new InterpreteConsultaMySQL();
            localContext = context;
        }

        private DbContextGestionDocumental DB { get { return (DbContextGestionDocumental)_db; } }

        public bool RequiereAutenticacion => true;

        public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            var update = data.Deserialize<ActivoActualizar>(JsonAPIDefaults());
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
            var add = data.Deserialize<ActivoInsertar>(JsonAPIDefaults());
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


        public override async Task<(List<Activo> Elementos, int? Total)> ObtienePaginaElementos(Consulta consulta)
        {
            await Task.Delay(0);

            Entidad entidad = reflectorEntidades.ObtieneEntidad(typeof(Activo));
            string query = interpreteConsulta.CrearConsulta(consulta, entidad, DbContextGestionDocumental.TablaActivo);

            int? total = null;
            List<Activo> elementos = localContext.Activos.FromSqlRaw(query).ToList();

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
                return new(new List<Activo>(), total); ;
            }
        }

        #region Overrides para la personalización de la entidad SerieDocumental

        public override async Task<ResultadoValidacion> ValidarInsertar(ActivoInsertar data)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Activos.AnyAsync(a => a.Nombre == data.Nombre);

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


        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Activo original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Activos.AnyAsync(a => a.Id == id);

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


        public override async Task<ResultadoValidacion> ValidarActualizar(string id, ActivoActualizar actualizacion, Activo original)
        {
            ResultadoValidacion resultado = new();
            bool encontrado = await DB.Activos.AnyAsync(a => a.Id == id);

            if (!encontrado)
            {
                resultado.Error = "id".ErrorProcesoNoEncontrado();

            }
            else
            {
                // Verifica que no haya un registro con el mismo nombre para el mismo dominio y UO en un resgitrso diferente
                bool duplicado = await DB.Activos.AnyAsync(a => a.Nombre.Equals(actualizacion.Nombre));

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




        public override Activo ADTOFull(ActivoActualizar actualizacion, Activo actual)
        {
            actual.Nombre = actualizacion.Nombre;
            actual.CuadroClasificacionId = actualizacion.CuadroClasificacionId;
            actual.SerieDocumentalId = actualizacion.SerieDocumentalId;
            actual.ArchivoOrigenId = actualizacion.ArchivoOrigenId;
            actual.ArchivoActualId = actualizacion.ArchivoActualId;
          
            actual.UnidadAdministrativaId = actualizacion.UnidadAdministrativaId;
            return actual;
        }

        public override Activo ADTOFull(ActivoInsertar data)
        {
            Activo activo = new Activo()
            {
                Id = Guid.NewGuid().ToString(),
                CuadroClasificacionId = data.CuadroClasificacionId,
                SerieDocumentalId = data.SerieDocumentalId,
                ArchivoOrigenId = data.ArchivoOrigenId,
                ArchivoActualId = data.ArchivoActualId,
                UnidadAdministrativaId = data.UnidadAdministrativaId,
                Nombre = data.Nombre,
                IdentificadorInterno = data.IdentificadorInterno,
                FechaApertura = data.FechaApertura,
                FechaCierre = data.FechaCierre,
                Asunto = data.Asunto,
                CodigoOptico = data.CodigoOptico,
                CodigoElectronico = data.CodigoElectronico,
                EsElectronico = data.EsElectronico,
                UbicacionCaja = data.UbicacionCaja,
                UbicacionRack = data.UbicacionRack,
                DominioId = _contextoUsuario.DominioId,
                TipoArchivoActualId = "tipo",
                UnidadOrganizacionalId = _contextoUsuario.UOrgId,
                UsuarioId = _contextoUsuario.UsuarioId,
            };
            return activo;
        }

        public override ActivoDespliegue ADTODespliegue(Activo data)
        {
            ActivoDespliegue activoDespliegue = new ActivoDespliegue()
            {
                Id = data.Id,
                CuadroClasificacionId = data.CuadroClasificacionId,
                SerieDocumentalId = data.SerieDocumentalId,
                ArchivoOrigenId = data.ArchivoOrigenId,
                ArchivoActualId = data.ArchivoActualId,
                TipoArchivoActualId = data.TipoArchivoActualId,
                UnidadAdministrativaId = data.UnidadAdministrativaId,
                Nombre = data.Nombre,
                IdentificadorInterno = data.IdentificadorInterno,
                FechaApertura = data.FechaApertura,
                FechaCierre = data.FechaCierre,
                Asunto = data.Asunto,
                CodigoOptico = data.CodigoOptico,
                CodigoElectronico = data.CodigoElectronico,
                EsElectronico = data.EsElectronico,
                Reservado = data.Reservado,
                Confidencial = data.Confidencial,
                UbicacionCaja = data.UbicacionCaja,
                UbicacionRack = data.UbicacionRack,
                EnPrestamo = data.EnPrestamo,
                EnTransferencia = data.EnTransferencia,
                Ampliado = data.Ampliado,
                FechaRetencionAT = data.FechaRetencionAT,
                FechaRetencionAC = data.FechaRetencionAC,
                AlmacenArchivoId = data.AlmacenArchivoId,
                ZonaAlmacenId = data.ZonaAlmacenId,
                ContenedorAlmacenId = data.ContenedorAlmacenId,
                FechaCreacion = data.FechaCreacion,
                UsuarioId = data.UsuarioId
            };
            return activoDespliegue;
        }

        #endregion
    }
}
