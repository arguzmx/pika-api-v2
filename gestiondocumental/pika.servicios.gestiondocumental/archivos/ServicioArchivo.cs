﻿using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.Extensions.Logging;
using pika.comun.metadatos;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.Archivos;
using pika.servicios.gestiondocumental.dbcontext;
using System.Text.Json;

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
namespace pika.servicios.gestiondocumental.archivos
{
    /// <summary>
    /// Servicio de datos para la entidad archivo
    /// </summary>
    [ServicioEntidadAPI(entidad: typeof(Archivo) )]
    public class ServicioArchivo : ServicioEntidadGenericaBase<Archivo, ArchivoInsertar, ArchivoActualizar, ArchivoDespliegue, string>,
        IServicioEntidadAPI, IServicioArchivo
    {

        private readonly ILogger<ServicioArchivo> _logger;
        public ServicioArchivo(DbContextGestionDocumental context, ILogger<ServicioArchivo> logger) : base (context, context.Archivos)
        {
            _logger = logger;
        }

        public string? Idioma { get; set; }

        public string? UsuarioId { get; set; }

        public string? DominioId { get; set; }

        public string? UnidadOrganizacionalId { get; set; }

        public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
        {
            var update = data.Deserialize<ArchivoActualizar>(JsonAPIDefaults());
            return await this.Actualizar((string)id, update);
        }

        public async Task<Respuesta> EliminarAPI(object id)
        {
            return await this.Eliminar((string)id);
        }

        public Entidad EntidadDespliegueAPI()
        {
            _logger.LogDebug("aca");
            return  this.EntidadDespliegue();
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

        public async Task<RespuestaPayload<object>> InsertarAPI(JsonElement data)
        {
            var add = data.Deserialize<ArchivoInsertar>(JsonAPIDefaults());
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

        public async Task<RespuestaPayload<object>> UnicaPorIdAPI(object id)
        {
            var temp = await this.UnicaPorIdAPI((string)id);
            RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }

        public async Task<RespuestaPayload<object>> UnicaPorIdDespliegueAPI(object id)
        {
            var temp = await this.UnicaPorIdDespliegue((string)id);

            RespuestaPayload<object> respuesta = JsonSerializer.Deserialize<RespuestaPayload<object>>(JsonSerializer.Serialize(temp));
            return respuesta;
        }



        public override  Task<ResultadoValidacion> ValidarInsertar(ArchivoInsertar data)
        {
            return Task.FromResult(new ResultadoValidacion() { Valido = true });
        }

        public override Task<ResultadoValidacion> ValidarEliminacion(string id, Archivo original)
        {
            return Task.FromResult(new ResultadoValidacion() { Valido = true });
        }


        public override Task<ResultadoValidacion> ValidarActualizar(string id, ArchivoActualizar actualizacion, Archivo original)
        {
            return Task.FromResult(new ResultadoValidacion() { Valido = true });
        }


        public override Archivo ADTOFull(ArchivoActualizar actualizacion, Archivo actual)
        {
            actual.Nombre = actualizacion.Nombre;
            return actual;
        }

        public override Archivo ADTOFull(ArchivoInsertar data)
        {
            Archivo archivo = new Archivo()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = data.Nombre,
                TipoArchivoId = data.TipoArchivoId,
                UOrgId = _contextoUsuario.UOrgId,
                DominioId = _contextoUsuario.DominioId,
            };
            return archivo;
        }

        public override ArchivoDespliegue ADTODespliegue(Archivo data)
        {
            ArchivoDespliegue archivo = new ArchivoDespliegue()
            {
                Id = data.Id,
                Nombre = data.Nombre,
                TipoArchivoId = data.TipoArchivoId,
            };
            return archivo;
        }
    }
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8603 // Possible null reference return.
