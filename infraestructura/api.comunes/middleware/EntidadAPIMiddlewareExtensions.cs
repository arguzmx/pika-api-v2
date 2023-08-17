using Microsoft.AspNetCore.Builder;

namespace api.comunes.middleware;

/// <summary>
/// Extensión de resgiro para el middleware de entidad API
/// </summary>
public static class EntidadAPIMiddlewareExtensions
{
    public static IApplicationBuilder UseEntidadAPI(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<EntidadAPIMiddleware>();
    }
}

