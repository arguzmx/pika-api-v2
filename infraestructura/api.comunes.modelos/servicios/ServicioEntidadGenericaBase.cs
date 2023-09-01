using api.comunes.modelos.modelos;
using api.comunes.modelos.respuestas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.comun.metadatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace api.comunes.modelos.servicios;

/// <summary>
/// Definición para la API genérica de entidades
/// </summary>
/// <typeparam name="DTOFull">Objeto tal como se almacena en el repositorio</typeparam>
/// <typeparam name="DTOInsert">DTO utilizado para insertar</typeparam>
/// <typeparam name="DTOUpdate">DTO utilizado para actualizar</typeparam>
/// <typeparam name="DTODespliegue">DTO utilizado para el despligue neutral en UI</typeparam>
/// <typeparam name="TipoId">Tipo de dato utilizado para el identificador de la entidad</typeparam>
public abstract class ServicioEntidadGenericaBase<DTOFull, DTOInsert, DTOUpdate, DTODespliegue, TipoId>
    where DTOFull : class
    where DTODespliegue : class
    where DTOUpdate : class
    where DTOInsert : class
{

    protected DbSet<DTOFull> _dbSetFull;
    protected DbContext _db;
    protected ContextoUsuario _contextoUsuario;
    protected ILogger _logger;

    public ServicioEntidadGenericaBase(DbContext db, DbSet<DTOFull> dbSetFull) {
        _dbSetFull = dbSetFull;
        _db = db;
    }

    public JsonSerializerOptions JsonAPIDefaults()
    {
        return new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    public virtual async Task<RespuestaPayload<DTODespliegue>> Insertar(DTOInsert data)
    {
        var respuesta = new RespuestaPayload<DTODespliegue>();

        var resultadoValidacion = await ValidarInsertar(data);
        if (resultadoValidacion.Valido)
        {
            var entidad = ADTOFull(data);
            _dbSetFull.Add(entidad);
            await _db.SaveChangesAsync();

            respuesta.HttpCode = HttpCode.Ok;
            respuesta.Payload = ADTODespliegue( entidad);
        }
        else
        {
            respuesta.Error = resultadoValidacion.Error;
            respuesta.HttpCode = resultadoValidacion.Error?.HttpCode ?? HttpCode.None;
        }
        return respuesta;
    }

    public virtual async Task<Respuesta> Actualizar(string id, DTOUpdate data)
    {
        var respuesta = new Respuesta();

        if (string.IsNullOrEmpty(id) || data == null)
        {
            respuesta.HttpCode = HttpCode.BadRequest;
            return respuesta;
        }

        DTOFull actual = _dbSetFull.Find(id);
        if (actual == null)
        {
            respuesta.HttpCode = HttpCode.NotFound;
            return respuesta;
        }

        var resultadoValidacion = await ValidarActualizar(id, data, actual);
        if (resultadoValidacion.Valido)
        {
            var entidad = ADTOFull(data, actual);
            _dbSetFull.Update(entidad);
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

    public virtual async Task<Respuesta> Eliminar(string id)
    {
        var respuesta = new Respuesta();

        if (string.IsNullOrEmpty(id))
        {
            respuesta.HttpCode = HttpCode.BadRequest;
            return respuesta;
        }

        DTOFull actual = _dbSetFull.Find(id);
        if (actual == null)
        {
            respuesta.HttpCode = HttpCode.NotFound;
            return respuesta;
        }

        var resultadoValidacion = await ValidarEliminacion(id, actual);
        if (resultadoValidacion.Valido)
        {

            _dbSetFull.Remove(actual);
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

    public virtual async Task<RespuestaPayload<DTOFull>> UnicaPorId(string id)
    {
        var respuesta = new RespuestaPayload<DTOFull>();
        DTOFull actual = await _dbSetFull.FindAsync(id);
        if (actual == null)
        {
            respuesta.HttpCode = HttpCode.NotFound;
            return respuesta;
        }

        respuesta.HttpCode = HttpCode.Ok;
        respuesta.Payload = actual;

        return respuesta;
    }

    public virtual async Task<RespuestaPayload<PaginaGenerica<DTOFull>>> Pagina(Consulta consulta)
    {
        RespuestaPayload<PaginaGenerica<DTOFull>> respuesta = new();

        var elementos = await _dbSetFull.ToListAsync();

        PaginaGenerica<DTOFull> pagina = new()
        {
            ConsultaId = Guid.NewGuid().ToString(),
            Elementos = elementos,
            Milisegundos = 0,
            Paginado = new Paginado() { Indice = 0, Tamano = elementos.Count },
            Total = elementos.Count
        };

        respuesta.Payload = pagina;
        respuesta.Ok = true;
        return respuesta;
    }

    public virtual void EstableceContextoUsuario(ContextoUsuario contexto)
    {
        _contextoUsuario = contexto;
    }

    public virtual async Task<ResultadoValidacion> ValidarActualizar(string id, DTOUpdate actualizacion, DTOFull original)
    {
        return new ResultadoValidacion() { Valido = true };
    }

    public virtual async Task<ResultadoValidacion> ValidarEliminacion(string id, DTOFull original)
    {
        return new ResultadoValidacion() { Valido = true };
    }

    public virtual async Task<ResultadoValidacion> ValidarInsertar(DTOInsert data)
    {
        return new ResultadoValidacion() { Valido = true };
    }


    public virtual async Task<RespuestaPayload<DTODespliegue>> UnicaPorIdDespliegue(string id)
    {
        RespuestaPayload<DTODespliegue> respuesta = new RespuestaPayload<DTODespliegue>();
        var resultado = await UnicaPorId(id);

        respuesta.Ok = resultado.Ok;

        if (resultado.Ok)
        {
            respuesta.Payload = ADTODespliegue((DTOFull)resultado.Payload);
        }

        return respuesta;
    }

    public virtual async Task<RespuestaPayload<PaginaGenerica<DTODespliegue>>> PaginaDespliegue(Consulta consulta)
    {
        RespuestaPayload<PaginaGenerica<DTODespliegue>> respuesta = new RespuestaPayload<PaginaGenerica<DTODespliegue>>();
        var resultado = await Pagina(consulta);

        respuesta.Ok = resultado.Ok;

        if (resultado.Ok)
        {
            PaginaGenerica<DTODespliegue> pagina = new()
            {
                ConsultaId = Guid.NewGuid().ToString(),
                Elementos = new List<DTODespliegue>(),
                Milisegundos = 0,
                Paginado = new Paginado() { Indice = 0, Tamano = ((PaginaGenerica<DTOFull>)resultado.Payload).Paginado.Tamano },
                Total = ((PaginaGenerica<DTOFull>)resultado.Payload).Total
            };

            foreach (DTOFull item in ((PaginaGenerica<DTOFull>)resultado.Payload).Elementos)
            {
                pagina.Elementos.Add(ADTODespliegue(item));
            }
            respuesta.Payload = pagina;
        }

        return respuesta;
    }


    public virtual DTOFull ADTOFull(DTOInsert data)
    {
        throw new NotImplementedException();
    }

    public virtual DTOFull ADTOFull(DTOUpdate actualizacion, DTOFull actual)
    {
        throw new NotImplementedException();
    }


    public virtual DTODespliegue ADTODespliegue(DTOFull data)
    {
        throw new NotImplementedException();
    }


    public virtual Entidad EntidadInsert()
    {
        throw new NotImplementedException();
    }

    public virtual Entidad EntidadRepo()
    {
        throw new NotImplementedException();
    }

    public virtual Entidad EntidadUpdate()
    {
        throw new NotImplementedException();
    }

    public virtual Entidad EntidadDespliegue()
    {
        throw new NotImplementedException();
    }




}
