using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using pika.servicios.gestiondocumental.acervo;
using pika.servicios.gestiondocumental.archivos;
using pika.servicios.gestiondocumental.cuadrosclasificacion;
using pika.servicios.gestiondocumental.dbcontext;
using pika.servicios.gestiondocumental.prestamo;
using pika.servicios.gestiondocumental.topologia;
using pika.servicios.gestiondocumental.transferencias;
using apicomunes = api.comunes;

namespace pika.api.gestiondocumental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IWebHostEnvironment environment = builder.Environment;

            

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                                .AddEnvironmentVariables();


            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("pika-gestiondocumental");
            builder.Services.AddDbContext<PIKADbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            builder.Services.AddDbContext<DbContextGestionDocumental>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddTransient<IServicioCuadroClasificacion, ServicioCuadroClasificacion>();
            builder.Services.AddTransient<IServicioElementoClasificacion, ServicioElementoClasificacion>();
            builder.Services.AddTransient<IServicioEntradaClasificacion, ServicioEntradaClasificacion>();
            builder.Services.AddTransient<IServicioArchivo, ServicioArchivo>();
            builder.Services.AddTransient<IServicioTipoArchivo, ServicioTipoArchivo>();
            builder.Services.AddTransient<IServicioUnidadAdministrativaArchivo, ServicioUnidadAdministrativaArchivo>();

            

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddTransient<IServicioActivoContenedorAlmacen, ServicioActivoContenedorAlmacen>();
            builder.Services.AddTransient<IServicioAlmacenArchivo, ServicioAlmacenArchivo>();
            builder.Services.AddTransient<IServicioContenedorAlmacen, ServicioContenedorAlmacen>();
            builder.Services.AddTransient<IServicioPosicionAlmacen, ServicioPosicionAlmacen>();
            builder.Services.AddTransient<IServicioZonaAlmacen, ServicioZonaAlmacen>();

            builder.Services.AddTransient<IServicioActivoTranferencia, ServicioActivoTransferencia>();
            builder.Services.AddTransient<IServicioComentarioTrasnferencia, ServicioComentarioTrasnferencia>();
            builder.Services.AddTransient<IServicioEventoTransferencia, ServicioEventoTransferencia>();
            builder.Services.AddTransient<IServicioTransferencia, ServicioTransferencia>();


            builder.Services.AddHttpContextAccessor();

            builder.Services.AddTransient<IServicioAmpliacion, ServicioAmpliacion>();

            builder.Services.AddTransient<IServicioPermisosUnidadAdministrativaArchivo, ServicioPermisosUnidadAdministrativaArchivo>();

            builder.Services.AddTransient<IServicioActivoPrestamo, ServicioActivoPrestamo>();
            builder.Services.AddTransient<IServicioComentarioPrestamo, ServicioComentarioPrestamo>();
            builder.Services.AddTransient<IServicioComentarioPrestamo, ServicioComentarioPrestamo>();

            apicomunes.IntrospeccionEnsamblados.ObtienesServiciosIEntidadAPI();

            var app = builder.Build();

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