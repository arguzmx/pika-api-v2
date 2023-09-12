using api.comunes.modelos.modelos;
using api.comunes.modelos.respuestas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.comunes.modelos.servicios;

public class ServicioCatalogoGenericoBase : IServicioCatalogoGenerico
{
    protected DbSet<ElementoCatalogo> _dbSetFull;
    protected DbContext _db;
    protected ContextoUsuario? _contextoUsuario;
    protected ILogger _logger;


    /// <summary>
    /// COnstructor para el servicio de catálogo
    /// </summary>
    /// <param name="db"></param>
    /// <param name="dbSetFull"></param>
    public ServicioCatalogoGenericoBase(DbContext db, DbSet<ElementoCatalogo> dbSetFull)
    {
        _dbSetFull = dbSetFull;
        _db = db;
    }

    /// <summary>
    /// Establece el contexto del usurio en sesión
    /// </summary>
    /// <param name="contexto"></param>
    public void EstableceContextoUsuario(ContextoUsuario? contexto)
    {
        this._contextoUsuario = contexto;
    }

    public ContextoUsuario? ObtieneContextoUsuario()
    {
        return _contextoUsuario;
    }

    /// <summary>
    /// Devuelve la lista completa de elemntos del catálogo en base al idioma
    /// </summary>
    /// <param name="Idioma">Idioma del catálogo</param>
    /// <returns></returns>
    public async Task<RespuestaPayload<List<ParClaveTexto>>> Todo(string? idioma)
    {
        List<ParClaveTexto> payload = await _dbSetFull.Where
            (c => c.DominioId == _contextoUsuario.DominioId
            && c.UnidadOrganizacionalId == _contextoUsuario.UOrgId
            && c.Idioma == idioma).OrderBy(c => c.Texto)
            .Select(x => new ParClaveTexto() { Clave = x.Id, Texto = x.Texto }).ToListAsync();

        RespuestaPayload<List<ParClaveTexto>> respuesta = new()
        {
            Ok = true,
            HttpCode = HttpCode.Ok,
            Payload = payload
        };
        return respuesta;
    }


    /// <summary>
    /// Devuelve una lista de entradas que contienen el texto buscad
    /// </summary>
    /// <param name="idioma">Idioma del catálogo</param>
    /// <param name="buscar">Texto a buscar</param>
    /// <returns></returns>
    public async Task<RespuestaPayload<List<ParClaveTexto>>> PorTexto(string? idioma, string? buscar) 
    {
        List<ParClaveTexto> payload = new ();
        if (!string.IsNullOrEmpty(buscar))
        {
            payload = await _dbSetFull.Where(c => c.DominioId == _contextoUsuario.DominioId
            && c.UnidadOrganizacionalId == _contextoUsuario.UOrgId
            && c.Idioma == idioma
            && buscar.Contains(c.Texto, StringComparison.InvariantCultureIgnoreCase))
            .OrderBy(c => c.Texto)
            .Select( x => new ParClaveTexto() {  Clave = x.Id, Texto = x.Texto }).ToListAsync();
        };

        RespuestaPayload<List<ParClaveTexto>> respuesta = new()
        {
            Ok = true,
            HttpCode = HttpCode.Ok,
            Payload = payload
        };

        return respuesta;
    }


    /// <summary>
    /// Crea una nueva entrada nueva en el catálogo
    /// </summary>
    /// <param name="elemento"></param>
    /// <returns></returns>
    public async Task<RespuestaPayload<ElementoCatalogo>> CreaEntrada(ElementoCatalogoInsertar elemento) 
    {
        var respuesta = new RespuestaPayload<ElementoCatalogo>();
        var elementoNuevo = ADTOFull(elemento);
        var resultadoValidacion = await ValidarInsertar(elemento);
        if (resultadoValidacion.Valido)
        {
          
            _dbSetFull.Add(elementoNuevo);
            await _db.SaveChangesAsync();

            respuesta.Ok = true;
            respuesta.HttpCode = HttpCode.Ok;
            respuesta.Payload = elementoNuevo;
        }
        else
        {
            respuesta.Error = resultadoValidacion.Error;
            respuesta.HttpCode = resultadoValidacion.Error?.HttpCode ?? HttpCode.None;
        }
        return respuesta;

    }

    /// <summary>
    /// Elimina una entrada del catálogo para todos los idiomas
    /// </summary>
    /// <param name="Id">Identificador único de la entrada</param>
    /// <returns></returns>
    public async Task<Respuesta> EliminaEntrada(string id)
    {
        var elemento = await  _dbSetFull.FirstOrDefaultAsync(x => x.DominioId == _contextoUsuario.DominioId
        && x.UnidadOrganizacionalId == _contextoUsuario.UOrgId && x.Id == id);
        
        if(elemento == null)
        {
            return ElementoNoEncontrado(id);
        }

        var resultado = await ValidarEliminacion(id, elemento);
        if(resultado.Valido)
        {
            _dbSetFull.Remove(elemento);
            await _db.SaveChangesAsync();
            return new Respuesta() {  Ok =  true, HttpCode = HttpCode.Ok };

        } else
        {
            return new Respuesta()
            {
                HttpCode = resultado.Error.HttpCode,
                Ok = false,
                Error = resultado.Error
            };
        }
    }


    /// <summary>
    /// Actualiza una entrada en el catálogo por idioma
    /// </summary>
    /// <param name="Id">Identificador único de la entrada</param>
    /// <param name="idioma">Idioma de la entrada</param>
    /// <param name="texto">texto para la enrada</param>
    /// <returns></returns>
    public async Task<Respuesta> ActualizaEntrada(string id, ElementoCatalogoActualizar elementoActualizar)
    {
        Respuesta respuesta = new ();
        var elemento = await _dbSetFull.FirstOrDefaultAsync(x => x.DominioId == _contextoUsuario.DominioId
            && x.UnidadOrganizacionalId == _contextoUsuario.UOrgId && x.Id == elementoActualizar.Id);

        if (elemento == null)
        {
            return ElementoNoEncontrado(id);
        }

        var resultadoValidacion = await ValidarActualizar(id, elementoActualizar, elemento);
        if (resultadoValidacion.Valido)
        {
            elemento = ADTOFull(elementoActualizar, elemento);
            _dbSetFull.Update(elemento);
            await _db.SaveChangesAsync();

            respuesta.HttpCode = HttpCode.Ok;
            respuesta.Ok = true;
        }
        else
        {
            respuesta.Error = resultadoValidacion.Error;
            respuesta.HttpCode = resultadoValidacion.Error?.HttpCode ?? HttpCode.None;
        }
        return respuesta;
    }


    /// <summary>
    /// Error elemento no eocnontrado
    /// </summary>
    /// <returns></returns>
    private Respuesta ElementoNoEncontrado (string id)
    {
        return new Respuesta()
        {
            HttpCode = HttpCode.NotFound,
            Ok = false,
            Error = new ErrorProceso()
            {
                Codigo = "NO_ENCONTRADO",
                HttpCode = HttpCode.NotFound,
                Mensaje = $"Elemento de catálogo no localizado {id}",
                Propiedad = "Id"
            }
        };
    }

    /// <summary>
    /// Devuelve la lista de idiomas disponibles para el catálogo
    /// </summary>
    /// <returns></returns>
    public async Task<List<string>> Idiomas()
    {
        return await _dbSetFull.Select(x => x.Idioma).Distinct().OrderBy(x=>x).ToListAsync();
    }

    public virtual async Task<ResultadoValidacion> ValidarActualizar(string id, ElementoCatalogoActualizar actualizacion, ElementoCatalogo original)
    {
        return new ResultadoValidacion() { Valido = true };
    }

    public virtual async Task<ResultadoValidacion> ValidarEliminacion(string id, ElementoCatalogo original)
    {
        return new ResultadoValidacion() { Valido = true };
    }

    public virtual async Task<ResultadoValidacion> ValidarInsertar(ElementoCatalogoInsertar data)
    {
        return new ResultadoValidacion() { Valido = true };
    }

    public virtual ElementoCatalogo ADTOFull(ElementoCatalogoInsertar data)
    {
        ElementoCatalogo el = new()
        {
            Id = data.Id ?? Guid.NewGuid().ToString(),
            Texto = data.Texto,
            Idioma = data.Idioma,
            DominioId = _contextoUsuario.DominioId,
            UnidadOrganizacionalId = _contextoUsuario.UOrgId
        };

        return el;
    }


    public virtual ElementoCatalogo ADTOFull(ElementoCatalogoActualizar data, ElementoCatalogo elemento)
    {
        elemento.Texto = data.Texto;
        return elemento;
    }
}
