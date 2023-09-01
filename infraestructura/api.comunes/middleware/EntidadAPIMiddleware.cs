using api.comunes.modelos.reflectores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Reflection;

namespace api.comunes;

public class EntidadAPIMiddleware
{
    public const string GenericAPIServiceKey = "GENERICAPISERVICE";
    private readonly RequestDelegate _next;
    private readonly IConfiguracionAPIEntidades _configuracionAPI;
    private ILogger<EntidadAPIMiddleware> _logger;
    public EntidadAPIMiddleware(RequestDelegate next, IConfiguracionAPIEntidades configuracionAPI, 
        ILogger<EntidadAPIMiddleware> logger )
    {
        _next = next;
        _configuracionAPI=  configuracionAPI;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        _logger.LogDebug("Middleware");
        var cultureQuery = context.Request.Query["culture"];
        if (!string.IsNullOrWhiteSpace(cultureQuery))
        {
            var culture = new CultureInfo(cultureQuery);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }


        var controllerName = context.GetRouteData().Values["controller"];
        if(controllerName!=null && controllerName.ToString() == "Generico")
        {
            string entidad = context.GetRouteData().Values["Entidad"].ToString() ?? "";
            var  servicios = _configuracionAPI.ObtienesServiciosIEntidadAPI();
            var servicio = servicios.FirstOrDefault(x => x.NombreRuteo.Equals(entidad, StringComparison.InvariantCultureIgnoreCase));
            if(servicio != null)
            {
                var assembly = Assembly.LoadFrom(servicio.Ruta);
                var tt = assembly.GetType(servicio.NombreEnsamblado);
                if(tt!= null)
                {
                    var ctors = tt.GetConstructors();
                    var ps = ctors[0].GetParameters();
                    object[] paramArray = new object[ps.Length];
                    int i = 0;
                    foreach ( var p in ps ) {
                        var s = context.RequestServices.GetService(p.ParameterType);
                        if(s!=null)
                        {
                            paramArray[i] = s;
                        } else
                        {
                           
                        }
                        i++;
                    }

                    try
                    {
                        _logger.LogDebug("Cool");
                        var service = (IEntidadAPI)Activator.CreateInstance(tt, paramArray);
                        context.Request.HttpContext.Items.Add(GenericAPIServiceKey, service);

                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(message: ex.ToString());
                        throw;
                    }
                }
            }
        }

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}
