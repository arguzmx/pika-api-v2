using api.comunes.modelos.modelos;
using Microsoft.EntityFrameworkCore;
using pika.modelo.contenido;
using pika.modelo.contenido.demometadatos;
using pika.servicios.contenido.dbcontext.configuraciones;

namespace pika.servicios.contenido.dbcontext;

public class DbContextContenido : DbContext
{

    public const string TablaVolumen = "cont$volumen";
    public const string TablaRepositorio = "cont$repositorio";
    public const string TablaCarpeta = "cont$carpeta";
    public const string TablaContenido = "cont$contenido";
    public const string TablaDemoMetadatos = "cont$demometadatos";

    public DbContextContenido(DbContextOptions<DbContextContenido> options) : base(options)
    {

    }

    public DbSet<Volumen> Volumenes { get; set; }
    public DbSet <ElementoCatalogo> TipoGestorES { get; set; }
    public DbSet <I18NCatalogo> TraduccionesTipoGestorES { get; set; }
    public DbSet <Repositorio> Repositorios { get; set; }
    public DbSet <Carpeta> Carpetas { get; set; }
    public DbSet <Contenido> Contenidos { get; set; }
    public DbSet <DemoMetadatos> DemoMetadatos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfiguracionVolumen());
        modelBuilder.ApplyConfiguration(new ConfiguracionElementoCatalogo());
        modelBuilder.ApplyConfiguration(new ConfiguracionI18NCatalogo());
        modelBuilder.ApplyConfiguration(new ConfiguracionRepositorio());
        modelBuilder.ApplyConfiguration(new ConfiguracionCarpeta());
        modelBuilder.ApplyConfiguration(new ConfiguracionContenido());
        modelBuilder.ApplyConfiguration(new ConfiguracionDemoMetadatos());
        base.OnModelCreating(modelBuilder);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }


}
