using api.comunes.modelos.modelos;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.SerieDocumental;
using pika.servicios.gestiondocumental.dbcontext.configuraciones;


namespace pika.servicios.gestiondocumental.dbcontext;

public class DbContextGestionDocumental : DbContext
{

    public const string TablaArchivos = "gd$archivo";
    public const string TablaSerieDocumental = "gd$seriedocumental";

    public DbContextGestionDocumental(DbContextOptions<DbContextGestionDocumental> options) : base(options)
    {

    }

    public DbSet<Archivo> Archivos { get; set; }
    public DbSet<SerieDocumental> SerieDocumentales { get; set; }
    public DbSet<ElementoCatalogo> TipoArchivo { get; set; }
    public DbSet<I18NCatalogo> TraduccionesTipoArchivo { get; set; }
    public DbSet<ElementoCatalogo> TipoDisposicionDocumental { get; set; }
    public DbSet<I18NCatalogo> TraduccionesTipoDisposicionDocumental { get; set; }
    public DbSet<ElementoCatalogo> TipoValoracionDocumental { get; set; }
    public DbSet<I18NCatalogo> TraduccionesTipoValoracionDocumental { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfiguracionArchivo());
        modelBuilder.ApplyConfiguration(new ConfiguracionElementoCatalogo());
        modelBuilder.ApplyConfiguration(new ConfiguracionI18NCatalogo());
        modelBuilder.ApplyConfiguration(new ConfiguracionSerieDocumental());
        base.OnModelCreating(modelBuilder); 
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
