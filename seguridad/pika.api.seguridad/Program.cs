using api.comunes;
using api.comunes.modelos.reflectores;
using api.configuracion.extensiones;
using Microsoft.EntityFrameworkCore;
using pika.servicios.seguridad.dbcontext;

namespace pika.api.seguridad
{
    public class Program
    {
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DbContextSeguridad>())
                {
                    context!.Database.Migrate();
                }
            }
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IWebHostEnvironment environment = builder.Environment;
            var configuration = builder.Configuration;


            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();


            builder.InicializaSerilog(configuration);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.InyectaOpenIdDict(builder.Configuration);


            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("pika-seguridad");

            // Contextos de base de datos
            builder.Services.AddDbContext<DbContextSeguridad>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });


            // Servicios locales
            builder.Services.AddTransient<IConfiguracionAPIEntidades, ConfiguracionAPIEntidades>();
            builder.Services.AddTransient<IReflectorEntidadesAPI, ReflectorEntidadAPI>();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddServiciosEntidadAPI();


            var app = builder.Build();

            // Realiza las migraciones si son necesarias
            UpdateDatabase(app);

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
}