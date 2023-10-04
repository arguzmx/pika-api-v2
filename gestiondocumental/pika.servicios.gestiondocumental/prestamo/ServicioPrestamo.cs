using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.comun.metadatos;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext;
using System.Text.Json;

namespace pika.servicios.gestiondocumental.prestamo;

public class ServicioPrestamo: ServicioEntidadGenericaBase<Prestamo, PrestamoInsertar, PrestamoActualizar, PrestamoDespliegue, string>,
        IServicioEntidadAPI, IServicioPrestamo
{
    //C
    public ServicioPrestamo(DbContextGestionDocumental context, ILogger<ServicioPrestamo> logger) : base(context, context.Prestamos, logger)
    {
    }


    /// <summary>
    /// Acceso al repositorio de gestipon documental local
    /// </summary>
    private DbContextGestionDocumental DB { get { return (DbContextGestionDocumental)_db; } }


    public bool RequiereAutenticacion => true;

    public async Task<Respuesta> ActualizarAPI(object id, JsonElement data)
    {
        var update = data.Deserialize<PrestamoActualizar>(JsonAPIDefaults());
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
        var add = data.Deserialize<PrestamoInsertar>(JsonAPIDefaults());
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

    public override async Task<ResultadoValidacion> ValidarInsertar(PrestamoInsertar data)
    {
        ResultadoValidacion resultado = new()
        {
            Valido = true
        };
        
        return resultado;
    }


    public override async Task<ResultadoValidacion> ValidarEliminacion(string id, Prestamo original)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.Archivos.AnyAsync(a => a.Id == id);

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


    public override async Task<ResultadoValidacion> ValidarActualizar(string id, PrestamoActualizar actualizacion, Prestamo original)
    {
        ResultadoValidacion resultado = new();
        bool encontrado = await DB.Archivos.AnyAsync(a => a.Id == id);

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


    public override Prestamo ADTOFull(PrestamoActualizar actualizacion, Prestamo actual)
    {
        return actual;
    }

    public override Prestamo ADTOFull(PrestamoInsertar data)
    {
        Prestamo prestamo = new Prestamo()
        {
            Folio = data.Folio,
            UsuarioDestinoId = data.UsuarioDestinoId,
            FechaProgramadaDevolucion = data.FechaProgramadaDevolucion,
            Descripcion= data.Descripcion,
            ArchivoId= data.ArchivoId,
        };
        return prestamo;
    }

    public override PrestamoDespliegue ADTODespliegue(Prestamo data)
    {
        PrestamoDespliegue archivo = new PrestamoDespliegue()
        {
            Id = data.Id,
            FechaCreacion = data.FechaCreacion,
            Folio = data.Folio,
            CantidadActivos = data.CantidadActivos,
            UsuarioOrigenId= data.UsuarioOrigenId,
            UsuarioDestinoId= data.UsuarioDestinoId,
            FechaProgramadaDevolucion = data.FechaProgramadaDevolucion,
            FechaDevolucion = data.FechaDevolucion,
            Descripcion = data.Descripcion,
            Entregado = data.Entregado,
            Devuelto = data.Devuelto,
            TieneDevolucionesParciales = data.TieneDevolucionesParciales,
            ArchivoId = data.ArchivoId
            
        };
        return archivo;
    }

        #endregion
}
