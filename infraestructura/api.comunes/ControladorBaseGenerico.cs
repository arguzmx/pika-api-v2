using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace api.comunes;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
/// <summary>
/// Controlador base para las entidades genéricas
/// </summary>
public abstract class ControladorBaseGenerico: ControllerBase
{
    /// <summary>
    /// Identificador par el encabezado de identficación de dominio
    /// </summary>
    protected const string DOMINIOHEADER = "x-d-id";

    /// <summary>
    /// Identificador par el encabezado de identficación de unidad organizacional
    /// </summary>
    protected const string UORGHEADER = "x-uo-id";

    /// <summary>
    /// Identificador par el encabezado de detección de idioma
    /// </summary>
    protected const string IDIOMAHEADER = "Accept-Language";


    protected readonly IHttpContextAccessor _httpContextAccessor;

    public ControladorBaseGenerico(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }


    /// <summary>
    /// Devuelve el valor del dominio actual para el request
    /// </summary>
    /// <returns></returns>
    protected virtual string? DominioId => _httpContextAccessor?.HttpContext?.Request?.Headers?[DOMINIOHEADER];



    /// <summary>
    /// Devuelve el valor de la unidad organizaciona para el request
    /// </summary>
    /// <returns></returns>
    protected virtual string? UnidadOrgId => _httpContextAccessor?.HttpContext?.Request?.Headers?[UORGHEADER];

    /// <summary>
    /// Devuelve el identificador del usuario en sesion si se ecnuentra autenticado
    /// </summary>
    /// <returns></returns>
    protected virtual string? UsuarioId 
    {
        get
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            }
            return null;
        }
    }

    /// <summary>
    /// CLaims de seguridad del usuario
    /// </summary>
    protected virtual IEnumerable<Claim>? ClaimsUsuario
    {
        get
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return _httpContextAccessor.HttpContext.User.Claims;
            }
            return null;
        }
    }

    /// <summary>
    /// Deveulve el valor del idioa solicitado por el request
    /// </summary>
    /// <returns></returns>
    protected virtual string? Idioma => _httpContextAccessor?.HttpContext?.Request?.Headers?[IDIOMAHEADER];

}
#pragma warning restore CS8602 // Dereference of a possibly null reference.