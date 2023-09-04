using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace api.comunes;

/// La api generica utiliza el parámetro {entidad} con propósitos asignación de servicion el em Middleware
#pragma warning disable IDE0060 // Quitar el parámetro no utilizado

/// <summary>
/// Controlador base para API de cetálogos genérica
/// </summary>
[ApiController]
[SwaggerTag(description: "Controlador Genérico Catálogos")]
public abstract class ControladorCatalogoGenerico : ControladorBaseGenerico
{

    /// <summary>
    /// Servicio para el catálogo de la entidad
    /// </summary>
    protected IServicioCatalogoAPI catalogoAPI;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpContextAccessor"></param>
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    public ControladorCatalogoGenerico(IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    {

        // Esta valos se asigna en el middleware si la lladada continua en el pipeline

#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
#pragma warning disable CS8601 // Posible asignación de referencia nula
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
        catalogoAPI = (IServicioCatalogoAPI)httpContextAccessor.HttpContext.Items[EntidadAPIMiddleware.GenericCatalogAPIServiceKey];
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
#pragma warning restore CS8601 // Posible asignación de referencia nula
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
    }


    /// <summary>
    /// Obtiene el idioma para la obtención del catálogo
    /// </summary>
    /// <param name="idioma">otro posible valor para el idioma</param>
    /// <returns></returns>
    private string? IdiomaCatalogo(string? idioma)
    {

        string? i = idioma ?? Idioma();
        
        if(!string.IsNullOrEmpty(i))
        {
            if(!catalogoAPI.Idiomas(DominioId(), UnidadOrgId()).Contains(i, StringComparer.InvariantCultureIgnoreCase))
            {
                // Si el idioma no esta en la lista se hace null para asiganr el default
                i = null;
            }
        } 
        
        if(string.IsNullOrEmpty(i)) {
            i = catalogoAPI.IdiomaDefault;
        }

        return i; 
    }


    /// <summary>
    /// Obtiene los elemento del catálogo en base al idioma y texto de búsqueda
    /// </summary>
    /// <param name="entidad">Nombre de entidad del catálogo</param>
    /// <param name="idioma">Idioma establecido por la llamada, supersede al del encabezado Accept-Language</param>
    /// <param name="buscar">Texto a buscar en las entradas de catálogo</param>
    /// <param name="dominioId">Identificador del dominio del usuario en sesión</param>
    /// <param name="uOrgID">Identificador de unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpGet("/api/catalogo/{entidad}")]
    [SwaggerOperation("Obtiene los elemento del catálogo en base al idioma y texto de búsqueda")]
    [SwaggerResponse(statusCode: 200, type: typeof(List<ParClaveTexto>), description: "Lista de valores par texto del catálogo")]
    [SwaggerResponse(statusCode: 404, description: "El idioma solciitado no se encuentra disponible para el catálogo")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    public async Task<ActionResult<List<ParClaveTexto>>> ObtieneCatalogo(string entidad, [FromQuery(Name = "idioma")] string? idioma, [FromQuery(Name = "buscar")] string? buscar, [FromHeader(Name = DOMINIOHEADER)] string? dominioId, [FromHeader(Name = UORGHEADER)] string? uOrgID)
    {
        string? idiomaCatalogo = IdiomaCatalogo(idioma);
        if(string.IsNullOrEmpty(idiomaCatalogo))
        {
            return NotFound();
        }

        RespuestaPayload<List<ParClaveTexto>>? response;
        if (!string.IsNullOrEmpty(buscar))
        {
            response = await catalogoAPI.PorTexto(IdiomaCatalogo(idioma), buscar, dominioId, uOrgID);
        } else
        {
            response = await catalogoAPI.Todo(IdiomaCatalogo(idioma), dominioId, uOrgID);
        }
        
        if (response.Ok)
        {
            return Ok(response.Payload);
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }


    /// <summary>
    /// Crea un elemento de catalogo, como el Id es proporcionada en la llamada el retorno existoso es 204
    /// </summary>
    /// <param name="entidad">Nombre de entidad del catálogo</param>
    /// <param name="elemento">Payload para la creación de la entidad</param>
    /// <param name="dominioId">Identificador del dominio del usuario en sesión</param>
    /// <param name="uOrgID">Identificador de unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpPost("/api/catalogo/{entidad}")]
    [SwaggerOperation("Crea un elemento de catalogo, como el Id es proporcionada en la llamada el retorno existoso es 204")]
    [SwaggerResponse(statusCode: 204, description: "La entrada del catálogo ha sido adicionada")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    public async Task<IActionResult> CrearElementoCatalogo(string entidad, [FromBody] ElementoCatalogoInsertar elemento, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        ElementoCatalogo e = new ()
        {
            Id  = elemento.Clave,
            Idioma = elemento.Idioma,
            Texto = elemento.Texto,
            UnidadOrganizacionalId = uOrgID,
            DominioId = dominioId
        };

        var response = await catalogoAPI.CreaEntrada(e, dominioId, uOrgID);
        if (response.Ok)
        {
            return NoContent();
        }

        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }

    /// <summary>
    /// Elimina una entrada del catálogo
    /// </summary>
    /// <param name="entidad">Nombre de entidad del catálogo</param>
    /// <param name="clave"></param>
    /// <param name="dominioId">Identificador del dominio del usuario en sesión</param>
    /// <param name="uOrgID">Identificador de unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpDelete("/api/catalogo/{entidad}/{clave}")]
    [SwaggerOperation("Elimina una entrada del catálogo")]
    [SwaggerResponse(statusCode: 204, description: "La entrada del catálogo ha sido eliminada")]
    [SwaggerResponse(statusCode: 404, description: "Elemento de catálogo inexistente")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    public async Task<IActionResult> EliminaEntradaCatalogo(string entidad, string clave, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        var response = await catalogoAPI.EliminaEntrada(clave, dominioId, uOrgID);
        if(response.Ok)
        {
            return NoContent();
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }

    /// <summary>
    /// Actualiza una entrada del catálogo
    /// </summary>
    /// <param name="entidad">Nombre de entidad del catálogo</param>
    /// <param name="clave">Clave de la entidad a actualizar</param>
    /// <param name="elemento">Payload para la actualización</param>
    /// <param name="dominioId">Identificador del dominio del usuario en sesión</param>
    /// <param name="uOrgID">Identificador de unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpPut("/api/catalogo/{entidad}/{clave}")]
    [SwaggerOperation("Actualiza una entrada del catálogo")]
    [SwaggerResponse(statusCode: 204, description: "La entrada del catálogo ha sido actualizada")]
    [SwaggerResponse(statusCode: 404, description: "La clave no coresponde con el cuerpo de la llamada")]
    [SwaggerResponse(statusCode: 404, description: "Elemento de catálogo inexistente")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    public async Task<IActionResult> ActualizaEntradaCatalogo(string entidad, string clave, [FromBody] ElementoCatalogoActualizar elemento, [FromHeader(Name = DOMINIOHEADER)] string dominioId, [FromHeader(Name = UORGHEADER)] string uOrgID)
    {
        if(clave!=elemento.Clave)
        {
            return BadRequest();
        }

        var response = await catalogoAPI.ActualizaEntrada(elemento.Clave, elemento.Idioma, elemento.Texto, dominioId, uOrgID);
        if (response.Ok)
        {
            return NoContent();
        }
        return StatusCode(response.HttpCode.GetHashCode(), response.Error);
    }


    /// <summary>
    /// Obtiene la lista de idiomas disponibles para el catálogo
    /// </summary>
    /// <param name="entidad">Nombre de entidad del catálogo</param>
    /// <param name="dominioId">Identificador del dominio del usuario en sesión</param>
    /// <param name="uOrgID">Identificador de unidad organizacional del usuario en sesión</param>
    /// <returns></returns>
    [HttpGet("/api/catalogo/{entidad}/idiomas")]
    [SwaggerOperation("Obtiene la lista de idiomas disponibles para el catálogo")]
    [SwaggerResponse(statusCode: 200, type: typeof(List<string>), description: "Idiomas disponibles para el catalogo")]
    [SwaggerResponse(statusCode: 404, description: "Elemento de catálogo inexistente")]
    [SwaggerResponse(statusCode: 403, description: "El usuario en sesión no tiene acceso a la operación")]
    [SwaggerResponse(statusCode: 401, description: "Usuario no autenticado")]
    public ActionResult<List<ParClaveTexto>> ObtieneIdiomasCatalogo(string entidad, [FromHeader(Name = DOMINIOHEADER)] string? dominioId, [FromHeader(Name = UORGHEADER)] string? uOrgID)
    {
        List<string> response = catalogoAPI.Idiomas(dominioId, uOrgID);
        return Ok(response);
        
    }
}
#pragma warning restore IDE0060 // Quitar el parámetro no utilizado