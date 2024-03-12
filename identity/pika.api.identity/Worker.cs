using pika.api.identity.models;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;
using OpenIddict.EntityFrameworkCore.Models;

namespace pika.api.identity;

public class Worker : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;
    public Worker(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await context.Database.EnsureCreatedAsync();

        var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();
        var clienteInterproceso = await manager.FindByClientIdAsync("pika-interservicio");
        var clienteUsuarioContrasena = await manager.FindByClientIdAsync("pika-usuario-contrasena");
        var secretoInterproceso = _configuration.GetValue<string>("secretos:cliente-interproceso");

        if (clienteInterproceso == null)
        {
            await manager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "pika-interservicio",
                ClientSecret = secretoInterproceso,
                DisplayName = "Servicio interproceso PIKA",
                Permissions =
                {
                    Permissions.Endpoints.Token,
                    Permissions.GrantTypes.ClientCredentials
                }
            }, cancellationToken);
        } else
        {
            var def  = (OpenIddictEntityFrameworkCoreApplication)clienteInterproceso;
            def.ClientSecret = secretoInterproceso;
            await manager.UpdateAsync(def, cancellationToken);
        }

        if (clienteUsuarioContrasena == null)
        {
            await manager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "pika-usuario-contrasena",
                DisplayName = "Servicio usuarios PIKA",
                Permissions =
                {
                    Permissions.Endpoints.Token,
                    Permissions.GrantTypes.Password
                }
            }, cancellationToken);
        }
        else
        {
            var def = (OpenIddictEntityFrameworkCoreApplication)clienteUsuarioContrasena;
            await manager.UpdateAsync(def, cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
