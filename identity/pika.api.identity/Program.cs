using pika.api.identity.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quartz;
using pika.api.identity.Services;
using System.Security.Cryptography.X509Certificates;
using api.configuracion;


namespace pika.api.identity;

public class Program
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <param name="configuracion"></param>
    /// <returns></returns>
    private static bool PreProceso(string[] args, ConfiguracionAPI configuracion)
    {
        string EncryptionCertificate = configuracion.EncryptionCertificate ?? "";
        string SigningCertificate = configuracion.SigningCertificate ?? "";


        bool keys = args.Contains("/keys");
        if (keys)
        {

            Extensions.GeneraClaves(SigningCertificate, EncryptionCertificate);
            Console.WriteLine("Los certificados han sido generados satisfactoriamente");
            return false;
        }

        return true;
    }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;

        ConfiguracionAPI configuracionAPI = new ();
        configuration.GetSection("ConfiguracionAPI").Bind(configuracionAPI);


        IWebHostEnvironment environment = builder.Environment;

        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();



        bool continuar = PreProceso(args, configuracionAPI);
        if (!continuar)
        {
            Console.WriteLine("PreProceso finalizado");
            return;
        }

        // Add services to the container.
        builder.Services.AddCors(c =>
        {
            c.AddPolicy("default", p =>
            {
                p.AllowAnyMethod();
                p.AllowAnyOrigin();
                p.AllowAnyHeader();
            });
        });

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            // Configure the context to use mysql.
            var connectionString = builder.Configuration.GetConnectionString("pika-identity");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            // Register the entity sets needed by OpenIddict.
            // Note: use the generic overload if you need
            // to replace the default OpenIddict entities.
            options.UseOpenIddict();
        });

        // Register the Identity services.
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        // OpenIddict offers native integration with Quartz.NET to perform scheduled tasks
        // (like pruning orphaned authorizations/tokens from the database) at regular intervals.
        builder.Services.AddQuartz(options =>
        {
            options.UseMicrosoftDependencyInjectionJobFactory();
            options.UseSimpleTypeLoader();
            options.UseInMemoryStore();
        });

        // Register the Quartz.NET service and configure it to block shutdown until jobs are complete.
        builder.Services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);


        builder.Services.AddOpenIddict()

            // Register the OpenIddict core components.
            .AddCore(options =>
            {
                // Configure OpenIddict to use the Entity Framework Core stores and models.
                // Note: call ReplaceDefaultEntities() to replace the default OpenIddict entities.
                options.UseEntityFrameworkCore()
                       .UseDbContext<ApplicationDbContext>();

                // Enable Quartz.NET integration.
                options.UseQuartz();
            })

            // Register the OpenIddict server components.
            .AddServer(options =>
            {
                // Enable the token endpoint.
                options.SetTokenEndpointUris("connect/token");

                // Enable the password and the refresh token flows.
                options.AllowPasswordFlow()
                       .AllowRefreshTokenFlow()
                       .AllowClientCredentialsFlow();

                // Accept anonymous clients (i.e clients that don't send a client_id).
                options.AcceptAnonymousClients();


                // Register the signing and encryption credentials.
                if(!string.IsNullOrEmpty(configuracionAPI.EncryptionCertificate) && File.Exists(configuracionAPI.EncryptionCertificate) )
                {
                    Console.WriteLine($"Utilizando certificado de cifrado {configuracionAPI.EncryptionCertificate}");
                    X509Certificate2 ec = new (configuracionAPI.EncryptionCertificate);
                    options.AddEncryptionCertificate(ec);
                } else
                {
                    Console.WriteLine("Utilizando certificado de desarrollo para cifrado");
                    options.AddDevelopmentEncryptionCertificate();
                }

                if (!string.IsNullOrEmpty(configuracionAPI.SigningCertificate) && File.Exists(configuracionAPI.SigningCertificate))
                {
                    Console.WriteLine($"Utilizando certificado para firma {configuracionAPI.SigningCertificate}");
                    X509Certificate2 sc = new(configuracionAPI.SigningCertificate);
                    options.AddSigningCertificate(sc);
                }
                else
                {
                    Console.WriteLine("Utilizando certificado de desarrollo para firma");
                    options.AddDevelopmentSigningCertificate();
                }


                // Evita que se encripte el payload del token
                if (!configuracionAPI.JWTCifrado)
                {
                    options.DisableAccessTokenEncryption();
                }
                

                //#endif

                // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                options.UseAspNetCore()
                       .EnableTokenEndpointPassthrough();
            })

            // Register the OpenIddict validation components.
            .AddValidation(options =>
            {
                // Import the configuration from the local OpenIddict server instance.
                options.UseLocalServer();

                // Register the ASP.NET Core host.
                options.UseAspNetCore();
            });

        // Register the worker responsible for seeding the database.
        // Note: in a real world application, this step should be part of a setup script.
        builder.Services.AddHostedService<Worker>();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // app.UseDeveloperExceptionPage();

        app.UseRouting();
        app.UseCors("default");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapDefaultControllerRoute();
        });

        // app.UseWelcomePage();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

        //app.MapControllers();

        app.Run();
    }
}