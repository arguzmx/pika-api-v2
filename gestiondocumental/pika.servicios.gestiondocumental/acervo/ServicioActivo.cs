using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext;
using api.comunes.modelos.servicios;
using pika.comun.metadatos;
using api.comunes.modelos.respuestas;
using pika.modelo.gestiondocumental.Acervo;
using api.comunes.modelos.modelos;

namespace pika.servicios.gestiondocumental.acervo;

public class ServicioActivo : IServicioActivo
{
    private readonly ILogger<ServicioActivo> _logger;
    private readonly PIKADbContext _db;
    private ContextoUsuario _contextoUsuario;

    public ServicioActivo(ILogger<ServicioActivo> logger, PIKADbContext PikaContext)
    {
        _logger = logger;
        _db = PikaContext;
    }

    public async Task<Respuesta> Actualizar(string id, ActivoActualizar data)
    {

        var respuesta = new Respuesta();

        if (string.IsNullOrEmpty(id) || data ==null)
        {
            respuesta.HttpCode = HttpCode.BadRequest;
            return respuesta;
        }

        Activo actual = _db.Activos.Find(id);
        if(actual == null)
        {
            respuesta.HttpCode = HttpCode.NotFound;
            return respuesta;
        } 

        var resultadoValidacion = await ValidarActualizar(id, data, actual);
        if (resultadoValidacion.Valido)
        {
            var entidad = ADTOFull(data, actual);
            _db.Activos.Update(entidad);
            await _db.SaveChangesAsync();

            respuesta.HttpCode = HttpCode.Ok;
        }
        else
        {
            respuesta.Error = resultadoValidacion.Error;
            respuesta.HttpCode = resultadoValidacion.Error?.HttpCode ?? HttpCode.None;
        }

        return respuesta;
    }

    public ActivoDespliegue ADTODespliegue(Activo data)
    {
        throw new NotImplementedException();
    }

    public Activo ADTOFull(ActivoInsertar data)
    {
        throw new NotImplementedException();
    }

    public Activo ADTOFull(ActivoActualizar actualizacion, Activo actual)
    {
        throw new NotImplementedException();
    }

    public async Task<Respuesta> Eliminar(string id)
    {
        var respuesta = new Respuesta();

        if (string.IsNullOrEmpty(id))
        {
            respuesta.HttpCode = HttpCode.BadRequest;
            return respuesta;
        }

        Activo actual = _db.Activos.Find(id);
        if (actual == null)
        {
            respuesta.HttpCode = HttpCode.NotFound;
            return respuesta;
        }

        var resultadoValidacion = await ValidarEliminacion(id, actual);
        if (resultadoValidacion.Valido)
        {
            _db.Activos.Remove(actual); 
            await _db.SaveChangesAsync();

            respuesta.HttpCode = HttpCode.Ok;
        }
        else
        {
            respuesta.Error = resultadoValidacion.Error;
            respuesta.HttpCode = resultadoValidacion.Error?.HttpCode ?? HttpCode.None;
        }

        return respuesta;
    }

    public Entidad EntidadDespliegue()
    {
        throw new NotImplementedException();
    }

    public Entidad EntidadInsert()
    {
        throw new NotImplementedException();
    }

    public Entidad EntidadRepo()
    {
        throw new NotImplementedException();
    }

    public Entidad EntidadUpdate()
    {
        throw new NotImplementedException();
    }

    public void EstableceContextoUsuario(ContextoUsuario contexto)
    {
        _contextoUsuario = contexto;
    }

    public async Task<RespuestaPayload<Activo>> Insertar(ActivoInsertar data)
    {
        var respuesta = new RespuestaPayload<Activo>();

        var resultadoValidacion = await ValidarInsertar(data);
        if (resultadoValidacion.Valido)
        {
            var entidad = ADTOFull(data);
            entidad.Id = Guid.NewGuid().ToString();
            _db.Activos.Add(entidad);
            await _db.SaveChangesAsync();

            respuesta.HttpCode = HttpCode.Ok;
            respuesta.Payload = entidad;
        }
        else
        {
            respuesta.Error = resultadoValidacion.Error;
            respuesta.HttpCode = resultadoValidacion.Error?.HttpCode ?? HttpCode.None;
        }

        return respuesta;
    }

    public async Task<PaginaGenerica<Activo>> Pagina(Consulta consulta)
    {
        throw new NotImplementedException();
    }

    public Task<PaginaGenerica<ActivoDespliegue>> PaginaDespliegue(Consulta consulta)
    {
        throw new NotImplementedException();
    }

    public async Task<RespuestaPayload<Activo>> UnicaPorId(string id)
    {
        throw new NotImplementedException();
    }

    public Task<RespuestaPayload<ActivoDespliegue>> UnicaPorIdDespliegue(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultadoValidacion> ValidarActualizar(string id, ActivoActualizar actualizacion, Activo actual)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultadoValidacion> ValidarEliminacion(string id, Activo actual)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultadoValidacion> ValidarInsertar(ActivoInsertar data)
    {
        throw new NotImplementedException();
    }

    Task<RespuestaPayload<PaginaGenerica<Activo>>> IServicioEntidadGenerica<Activo, ActivoInsertar, ActivoActualizar, ActivoDespliegue, string>.Pagina(Consulta consulta)
    {
        throw new NotImplementedException();
    }

    Task<RespuestaPayload<PaginaGenerica<ActivoDespliegue>>> IServicioEntidadGenerica<Activo, ActivoInsertar, ActivoActualizar, ActivoDespliegue, string>.PaginaDespliegue(Consulta consulta)
    {
        throw new NotImplementedException();
    }
}
