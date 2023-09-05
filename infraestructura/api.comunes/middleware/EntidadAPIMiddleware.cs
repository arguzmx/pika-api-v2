using api.comunes.modelos;
using api.comunes.modelos.reflectores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace api.comunes;

public class EntidadAPIMiddleware
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


    protected const string JWTAHEADER = "Authorization";


    public const string GenericAPIServiceKey = "GENERICAPISERVICE";
    public const string GenericCatalogAPIServiceKey = "GENERICCATALOGAPISERVICE";

    private readonly RequestDelegate _next;
    private readonly IConfiguracionAPIEntidades _configuracionAPI;
    private ILogger<EntidadAPIMiddleware> _logger;
    public EntidadAPIMiddleware(RequestDelegate next, IConfiguracionAPIEntidades configuracionAPI,
        ILogger<EntidadAPIMiddleware> logger)
    {
        _next = next;
        _configuracionAPI = configuracionAPI;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var controllerName = context.GetRouteData().Values["controller"];
        if (controllerName != null && controllerName.ToString() == "Generico")
        {
            string entidad = context.GetRouteData().Values["Entidad"].ToString() ?? "";
            var servicios = _configuracionAPI.ObtienesServiciosIEntidadAPI();
            var servicio = servicios.FirstOrDefault(x => x.NombreRuteo.Equals(entidad, StringComparison.InvariantCultureIgnoreCase));

            if (servicio == null)
            {
                await ReturnMiddlewareError(context, new ErrorMiddlewareGenerico()
                {
                    Entidad = entidad,
                    Error = "SERVICIO-NO-LOCALIZADO",
                    HttpCode = 400
                });
            }

            var assembly = Assembly.LoadFrom(servicio.Ruta);
            var tt = assembly.GetType(servicio.NombreEnsamblado);

            if (tt == null)
            {
                await ReturnMiddlewareError(context, new ErrorMiddlewareGenerico()
                {
                    Entidad = entidad,
                    Error = "ENSAMBLADO-NO-LOCALIZADO",
                    HttpCode = 400
                });
            }

            var ctors = tt.GetConstructors();
            var ps = ctors[0].GetParameters();
            object[] paramArray = new object[ps.Length];
            int i = 0;
            foreach (var p in ps)
            {
                var s = context.RequestServices.GetService(p.ParameterType);
                if (s != null)
                {
                    paramArray[i] = s;
                }
                else
                {

                }
                i++;
            }

            try
            {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                var service = (IServicioEntidadAPI)Activator.CreateInstance(tt, paramArray);
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                if (service != null)
                {
                    service.DominioId = DominioId(context);
                    service.UsuarioId = UsuarioId(context);
                    service.UnidadOrganizacionalId = UnidadOrgId(context);
                    service.Idioma = Idioma(context);
                    context.Request.HttpContext.Items.Add(GenericAPIServiceKey, service);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.ToString());
                throw;
            }

        }

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }


    /// <summary>
    /// Devulve un error en el pipeline para exepciones de entidades genéricas
    /// </summary>
    /// <param name="context"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    private async Task ReturnMiddlewareError(HttpContext context, ErrorMiddlewareGenerico error)
    {
        var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(error));
        await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = error.HttpCode;
        await context.Response.StartAsync();
    }


    /// <summary>
    /// Devuelve el valor del dominio actual para el request
    /// </summary>
    /// <returns></returns>
    private string? DominioId(HttpContext context)
    {
        return context.Request.Headers?[DOMINIOHEADER];
    }


    /// <summary>
    /// Devuelve el valor de la unidad organizaciona para el request
    /// </summary>
    /// <returns></returns>
    protected string? UnidadOrgId(HttpContext context)
    {

        return context.Request.Headers?[UORGHEADER];
    }

    /// <summary>
    /// Devuelve el identificador del usuario en sesion si existe un JWT válido
    /// </summary>
    /// <returns></returns>
    protected string? UsuarioId(HttpContext context)
    {
        string? userId = null;
        string? authHeader = context.Request.Headers?[UORGHEADER];
        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer"))
        {
            var token = authHeader.Split(" ")[1];
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            userId = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        return userId;
    }

    /// <summary>
    /// Deveulve el valor del idioa solicitado por el request
    /// </summary>
    /// <returns></returns>
    protected string? Idioma(HttpContext context)
    {

        return context.Request.Headers?[IDIOMAHEADER];
    }

}
