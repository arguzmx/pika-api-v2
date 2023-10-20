using api.comunes;
using Microsoft.EntityFrameworkCore;
using Serilog;
using pika.servicios.contenido.dbcontext;
using CouchDB.Driver.DependencyInjection;

namespace pika.api.contenido;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        IWebHostEnvironment environment = builder.Environment;

        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                            .AddEnvironmentVariables();

        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("pika-contenido");

        builder.Services.AddDbContext<DbContextContenido>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        builder.Services.AddCouchContext<VersionCouchDbContext>(builder => builder
    .EnsureDatabaseExists()
    .UseEndpoint(configuration.GetValue<string>("promodeldrivers:couchdb:endpoint"))
    .UseBasicAuthentication(username: configuration.GetValue<string>("promodeldrivers:couchdb:username"),
    password: configuration.GetValue<string>("promodeldrivers:couchdb:password")));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddTransient<IConfiguracionAPIEntidades, ConfiguracionAPIEntidades>();
        builder.Services.AddDistributedMemoryCache();

        // Añadir la extensión para los servicios de API genérica
        builder.Services.AddServiciosEntidadAPI();

        var app = builder.Build();

        // Añadir la extensión para los servicios de API genérica
        app.UseEntidadAPI();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}