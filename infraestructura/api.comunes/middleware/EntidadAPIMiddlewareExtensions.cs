using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace api.comunes;

/// <summary>
/// Extensión de resgiro para el middleware de entidad API
/// </summary>
public static class EntidadAPIMiddlewareExtensions
{
    public static IServiceCollection AddServiciosEntidadAPI(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        return services;
    }

    public static IApplicationBuilder UseEntidadAPI(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<EntidadAPIMiddleware>();
    }
}

