using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenIddict.Validation.AspNetCore;
using Serilog;
using System.Security.Cryptography.X509Certificates;

namespace api.configuracion.extensiones;

/// <summary>
/// Utilerías para la configuración del servicio de itdentidad
/// </summary>
public static class ExtensionesBuilder
{

    /// <summary>
    /// Inyecta el servicio de Identidad de OpenIdDict
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration">Configuracion para ConfiguracionAPI utiliza clave ConfiguracionAPI </param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static void InyectaOpenIdDict(this IServiceCollection services, ConfigurationManager configuration)
    {

        ConfiguracionAPI configuracionAPI = new();
        configuration.GetSection(ConfiguracionAPI.ClaveConfiguracionBase).Bind(configuracionAPI);

        services.AddOpenIddict()
            .AddValidation(options =>
            {
                var auth = configuracionAPI.EndpointsAutenticacion.FirstOrDefault(x => x.Id == ConfiguracionAPI.ClaveConfiguracionDefault);
                if (auth != null)
                {
                    options.SetIssuer(auth.Url);
                    // Añade la clave de cifrado si es necesaria
                    if (configuracionAPI.JWTCifrado)
                    {
                        X509Certificate2 ec = new(auth.EncryptionCertificate);
                        options.AddEncryptionCertificate(ec);

                    }
                    options.UseSystemNetHttp();
                    options.UseAspNetCore();

                }
                else
                {
                    throw new Exception("Configuración de auntenticación no válida");
                }
            });

        services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        services.AddAuthorization();
    }


    /// <summary>
    /// INicializa la configuracion estándar de Seriog
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="configuration"></param>
    public static void InicializaSerilog(this WebApplicationBuilder builder, ConfigurationManager configuration)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);
    }

}
