using api.comunes.modelos.modelos;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.SerieDocumental;
using pika.modelo.gestiondocumental.Topologia;
using pika.servicios.gestiondocumental.dbcontext.configuraciones;


namespace pika.servicios.gestiondocumental.dbcontext;

public class DbContextGestionDocumental : DbContext
{

    public const string TablaArchivos = "gd$archivo";
    public const string TablaCuadrosClasificacion = "gd$cuadroclasificacion";
    public const string TablaActivo = "gd$activo";
    public const string TablaSerieDocumental = "gd$seriedocumental";
    public const string TablaAlmacenArchivo = "gd$almacenarchivo";

    public DbContextGestionDocumental(DbContextOptions<DbContextGestionDocumental> options) : base(options)
    {

    }

    public DbSet<Archivo> Archivos { get; set; }
    public DbSet<SerieDocumental> SerieDocumentales { get; set; }
    public DbSet<ElementoCatalogo> TipoArchivo { get; set; }
    public DbSet<I18NCatalogo> TraduccionesTipoArchivo { get; set; }
    public DbSet<CuadroClasificacion> CuadrosClasificacion { get; set; }
    public DbSet<Activo> Activos { get; set; }
    public DbSet<ElementoCatalogo> TipoDisposicionDocumental { get; set; }
    public DbSet<I18NCatalogo> TraduccionesTipoDisposicionDocumental { get; set; }
    public DbSet<ElementoCatalogo> TipoValoracionDocumental { get; set; }
    public DbSet<I18NCatalogo> TraduccionesTipoValoracionDocumental { get; set; }
    public DbSet<AlmacenArchivo> AlmacenesArchivos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfiguracionArchivo());
        modelBuilder.ApplyConfiguration(new ConfiguracionElementoCatalogo());
        modelBuilder.ApplyConfiguration(new ConfiguracionI18NCatalogo());
        modelBuilder.ApplyConfiguration(new ConfiguracionCuadroClasificacion());
        modelBuilder.ApplyConfiguration(new ConfiguracionActivo());
        modelBuilder.ApplyConfiguration(new ConfiguracionSerieDocumental());
        modelBuilder.ApplyConfiguration(new ConfiguracionAlmacenArchivo());
        base.OnModelCreating(modelBuilder); 
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
