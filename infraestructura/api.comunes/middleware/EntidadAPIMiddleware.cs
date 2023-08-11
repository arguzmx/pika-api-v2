using Microsoft.AspNetCore.Http;
using System.Globalization;

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

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}
