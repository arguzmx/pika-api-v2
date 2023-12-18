using api.comunes.modelos.modelos;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.SerieDocumental;
using pika.servicios.gestiondocumental.dbcontext.configuraciones;


namespace pika.servicios.gestiondocumental.dbcontext;

public class DbContextGestionDocumental : DbContext
{

    public const string TablaArchivos = "gd$archivo";
<<<<<<< HEAD
<<<<<<< HEAD
    public const string TablaCuadrosClasificacion = "gd$cuadroclasificacion";
    public const string TablaActivo = "gd$activo";
=======
    public const string TablaSerieDocumental = "gd$seriedocumental";
>>>>>>> 2895171 (ImplementarServiciosGenericosSeriDocumentalCatalogos)
=======
    public const string TablaSerieDocumental = "gd$seriedocumental";
>>>>>>> 2895171451b52c89a85a30cc10ad7c01ec62702d

    public DbContextGestionDocumental(DbContextOptions<DbContextGestionDocumental> options) : base(options)
    {

    }

    public DbSet<Archivo> Archivos { get; set; }
    public DbSet<SerieDocumental> SerieDocumentales { get; set; }
    public DbSet<ElementoCatalogo> TipoArchivo { get; set; }
    public DbSet<I18NCatalogo> TraduccionesTipoArchivo { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
    public DbSet<CuadroClasificacion> CuadrosClasificacion { get; set; }

    public DbSet<Activo> Activos { get; set; }
=======
=======
>>>>>>> 2895171451b52c89a85a30cc10ad7c01ec62702d
    public DbSet<ElementoCatalogo> TipoDisposicionDocumental { get; set; }
    public DbSet<I18NCatalogo> TraduccionesTipoDisposicionDocumental { get; set; }
    public DbSet<ElementoCatalogo> TipoValoracionDocumental { get; set; }
    public DbSet<I18NCatalogo> TraduccionesTipoValoracionDocumental { get; set; }
<<<<<<< HEAD
>>>>>>> 2895171 (ImplementarServiciosGenericosSeriDocumentalCatalogos)
=======
>>>>>>> 2895171451b52c89a85a30cc10ad7c01ec62702d

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfiguracionArchivo());
        modelBuilder.ApplyConfiguration(new ConfiguracionElementoCatalogo());
        modelBuilder.ApplyConfiguration(new ConfiguracionI18NCatalogo());
<<<<<<< HEAD
<<<<<<< HEAD
        modelBuilder.ApplyConfiguration(new ConfiguracionCuadroClasificacion());
        modelBuilder.ApplyConfiguration(new ConfiguracionActivo());
=======
        modelBuilder.ApplyConfiguration(new ConfiguracionSerieDocumental());
>>>>>>> 2895171 (ImplementarServiciosGenericosSeriDocumentalCatalogos)
=======
        modelBuilder.ApplyConfiguration(new ConfiguracionSerieDocumental());
>>>>>>> 2895171451b52c89a85a30cc10ad7c01ec62702d
        base.OnModelCreating(modelBuilder); 
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
