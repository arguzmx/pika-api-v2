using api.comunes;
using api.comunes.modelos.reflectores;
using CouchDB.Driver.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using pika.servicios.contenido.dbcontext;
using pika.servicios.contenido.Version;
using Serilog;

namespace pika.api.contenido
{
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


         /*   builder.Services.AddHttpClient();
            builder.Services.AddTransient<ICouchServiciosVersion, ServicioVersion>();*/

            builder.Services.AddCouchContext<VersionCouchDbContext>(builder => builder
        .EnsureDatabaseExists()
        .UseEndpoint(configuration.GetValue<string>("CouchDB:endpoint"))
        .UseBasicAuthentication(username: configuration.GetValue<string>("CouchDB:username"),
        password: configuration.GetValue<string>("CouchDB:password")));

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddTransient<IConfiguracionAPIEntidades, ConfiguracionAPIEntidades>();
            builder.Services.AddTransient<IReflectorEntidadesAPI, ReflectorEntidadAPI>();
            builder.Services.AddDistributedMemoryCache();

            // A�adir la extensi�n para los servicios de API gen�rica
            builder.Services.AddServiciosEntidadAPI();

            var app = builder.Build();

            // A�adir la extensi�n para los servicios de API gen�rica
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
}