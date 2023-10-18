using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.comun.metadatos;
using pika.modelo.contenido.Carpeta;
using pika.modelo.contenido.Volumen;
using pika.servicios.contenido.dbcontext;
using System.Text.Json;

namespace pika.servicios.contenido.carpeta;

/// <summary>
/// Servicio de datos para la entidad Carpeta
/// </summary>
[ServicioEntidadAPI(entidad: typeof(Carpeta))]
public class ServicioCarpeta : ServicioEntidadGenericaBase<Carpeta, CarpetaInsertar, CarpetaActualizar, CarpetaDespliegue, string>,
    IServicioEntidadAPI, IServicioCarpeta
{

    public ServicioCarpeta(DbContextContenido context, ILogger<ServicioCarpeta> logger) : base(context, context.Carpeta, logger)
    {
    }


    /// <summary>
    /// Acceso al repositorio de gestipon documental local
    /// </summary>
    private DbContextContenido DB { get { return (DbContextContenido)_db; } }


    public bool RequiereAutenticacion => true;

    public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
    {
        var update = data.Deserialize<CarpetaActualizar>(JsonAPIDefaults());
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
        var add = data.Deserialize<CarpetaInsertar>(JsonAPIDefaults());
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



    #region Overrides para la personalziación de la entidad Archivo

    public override async Task<ResultadoValidacion> ValidarInsertar(CarpetaInsertar data)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.Carpeta.AnyAsync(a => a.Nombre == data.Nombre && a.RepositorioId==data.RepositorioId && a.CarpetaPadreId==data.CarpetaPadreId);

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


    public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Carpeta original)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.Carpeta.AnyAsync(a =>a.Id == id);

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


    public override async Task<ResultadoValidacion> ValidarActualizar(string id, CarpetaActualizar actualizacion, Carpeta original)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.Carpeta.AnyAsync(a =>a.Id == id);

        if (!encontrado)
        {
            resultado.Error = "id".ErrorProcesoNoEncontrado();

        }
        else
        {

            bool duplicado = await DB.Carpeta.AnyAsync(a => a.Id != id
                && a.Nombre == actualizacion.Nombre);

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


    public override Carpeta ADTOFull(CarpetaActualizar actualizacion, Carpeta actual)
    {
        actual.Id = actualizacion.Id;
        actual.Nombre = actualizacion.Nombre;
        actual.CarpetaPadreId = actualizacion.CarpetaPadreId;
        return actual;
    }

    public override Carpeta ADTOFull(CarpetaInsertar data)
    {
        Carpeta archivo = new Carpeta()
        {
            Id = Guid.NewGuid().ToString(),
            RepositorioId = data.RepositorioId,
            CarpetaPadreId = data.CarpetaPadreId,
            FechaCreacion = DateTime.UtcNow,
            Nombre = data.Nombre,
            CreadorId = _contextoUsuario.UsuarioId,
            EsRaiz = string.IsNullOrEmpty(data.CarpetaPadreId) ? true : false
        };
        return archivo;
    }

    public override CarpetaDespliegue ADTODespliegue(Carpeta data)
    {
        CarpetaDespliegue archivo = new CarpetaDespliegue()
        {
            Id = data.Id,
            CreadorId=data.CreadorId,
            FechaCreacion=data.FechaCreacion,
            Nombre = data.Nombre,
            CarpetaPadreId=data.CarpetaPadreId
        };
        return archivo;
    }

    #endregion
}

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8603 // Possible null reference return.

