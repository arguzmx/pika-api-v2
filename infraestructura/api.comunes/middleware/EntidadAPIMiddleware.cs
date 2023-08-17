using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Net.Http;
using System.Reflection;
using System.Xml.Linq;

namespace api.comunes.middleware;

public class EntidadAPIMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguracionAPIEntidades _configuracionAPI;
    public EntidadAPIMiddleware(RequestDelegate next, IConfiguracionAPIEntidades configuracionAPI)
    {
        _next = next;
        _configuracionAPI=  configuracionAPI;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        
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
                    foreach( var p in ps ) {
                        var s = context.RequestServices.GetService(p.ParameterType);
                    }
                    
                }
            }
        }

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}
