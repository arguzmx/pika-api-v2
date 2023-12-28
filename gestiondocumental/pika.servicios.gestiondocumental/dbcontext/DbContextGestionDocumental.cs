using api.comunes.modelos.modelos;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext.configuraciones;


namespace pika.servicios.gestiondocumental.dbcontext;

public class DbContextGestionDocumental : DbContext
{

    public const string TablaArchivos = "gd$archivo";
    public const string TablaCuadrosClasificacion = "gd$cuadroclasificacion";
    public const string TablaActivo = "gd$activo";
    public const string TablaSerieDocumental = "gd$seriedocumental";
    public const string TablaAlmacenArchivo = "gd$almacenarchivo";
    public const string TablaZonaAlmacen = "gd$zonaalmacen";
    public const string TablaPosicionAlmacen = "gd$posicionalmacen";
    public const string TablaCajaAlmacen = "gd$cajaalmacen";
    public const string TablaTransferencias = "gd$transferencias";
    public const string TablaPrestamo = "gd$prestamo";

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
    public DbSet<ZonaAlmacen> ZonaAlmacenes { get; set; }
    public DbSet<PosicionAlmacen> PosicionAlmacens { get; set; }
    public DbSet<CajaAlmacen> CajaAlmacens { get; set; }
    public DbSet<ElementoCatalogo> EstadoTransferencia { get; set; }
    public DbSet<I18NCatalogo> TraduccionesEstadoTransferencia { get; set; }
    public DbSet<Transferencia> Transferencias { get; set; }
    public DbSet<Prestamo> Prestamos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfiguracionArchivo());
        modelBuilder.ApplyConfiguration(new ConfiguracionElementoCatalogo());
        modelBuilder.ApplyConfiguration(new ConfiguracionI18NCatalogo());
        modelBuilder.ApplyConfiguration(new ConfiguracionCuadroClasificacion());
        modelBuilder.ApplyConfiguration(new ConfiguracionActivo());
        modelBuilder.ApplyConfiguration(new ConfiguracionSerieDocumental());
        modelBuilder.ApplyConfiguration(new ConfiguracionAlmacenArchivo());
        modelBuilder.ApplyConfiguration(new ConfiguracionZonaAlmacen());
        modelBuilder.ApplyConfiguration(new ConfiguracionPosicionAlmacen());
        modelBuilder.ApplyConfiguration(new ConfiguracionCajaAlmacen());
        modelBuilder.ApplyConfiguration(new ConfiguracionTransferencia());
        modelBuilder.ApplyConfiguration(new ConfiguracionPrestamo());
        base.OnModelCreating(modelBuilder); 
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
