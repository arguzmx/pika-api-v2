using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext.configuraciones;
namespace pika.servicios.gestiondocumental.dbcontext;

public class PIKADbContext : DbContext
{

   
    ///// <summary>
    ///// Activos del acervo en una unidad administrativa
    ///// </summary>
    //public DbSet<Activo> Activos { get; set; }
    //public DbSet<ActivoContenedorAlmacen> ActivoContenedorAlmacens { get; set; }
    //public DbSet<ActivoPrestamo> ActivoPrestamos { get; set; }
    //public DbSet<ActivoTransferencia> ActivoTransferencias { get; set; }
    //public DbSet<AlmacenArchivo> AlmacenArchivos { get; set; }
    //public DbSet<Ampliacion> Ampliacions { get; set; }
    public DbSet<Archivo> Archivos { get; set; }
    //public DbSet<ComentarioPrestamo> ComentarioPrestamos { get; set; }
    //public DbSet<ComentarioTransferencia> ComentarioTransferencias { get; set; }
    //public DbSet<ContenedorAlmacen> ContenedorAlmacens { get; set; }
    //public DbSet<CuadroClasificacion> CuadroClasificacions { get; set; }
    //public DbSet<ElementoClasificacion> ElementoClasificacions { get; set; }
    //public DbSet<EntradaClasificacion> EntradaClasificacions { get; set; }
    //public DbSet<EventoTransferencia> EventoTransferencias { get; set; }
    //public DbSet<PermisosUnidadAdministrativaArchivo> PermisosUnidadAdministrativaArchivos { get; set; }
    //public DbSet<PosicionAlmacen> PosicionAlmacens { get; set; }
    //public DbSet<Prestamo> Prestamos { get; set; }
    //public DbSet<TipoArchivo> TipoArchivos { get; set; }
    //public DbSet<Transferencia> Transferencias { get; set; }
    //public DbSet<UnidadAdministrativaArchivo> UnidadAdministrativaArchivos { get; set; }
    //public DbSet<ZonaAlmacen> ZonaAlmacens { get; set; }


    public PIKADbContext(DbContextOptions<PIKADbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        //modelBuilder.ApplyConfiguration(new ConfiguracionActivo());
        //modelBuilder.ApplyConfiguration(new ConfiguracionActivoContenedorAlmacen());
        //modelBuilder.ApplyConfiguration(new ConfiguracionActivoPrestamo());
        //modelBuilder.ApplyConfiguration(new ConfiguracionActivoTransferencia());
        //modelBuilder.ApplyConfiguration(new ConfiguracionAlmacenArchivo());
        //modelBuilder.ApplyConfiguration(new ConfiguracionAmpliacion());
        //modelBuilder.ApplyConfiguration(new ConfiguracionArchivo());
        //modelBuilder.ApplyConfiguration(new ConfiguracionComentarioPrestamo());
        //modelBuilder.ApplyConfiguration(new ConfiguracionComentarioTrasnferencia());
        //modelBuilder.ApplyConfiguration(new ConfiguracionContenedorAlmacen());
        //modelBuilder.ApplyConfiguration(new ConfiguracionCuadroClasificacion());
        //modelBuilder.ApplyConfiguration(new ConfiguracionElementoClasificacion());
        //modelBuilder.ApplyConfiguration(new ConfiguracionEntradaClasificacion());
        //modelBuilder.ApplyConfiguration(new ConfiguracionEventoTransferencia());
        //modelBuilder.ApplyConfiguration(new ConfiguracionPermisosUnidadAdministrativaArchivo());
        //modelBuilder.ApplyConfiguration(new ConfiguracionPosicionAlmacen());
        //modelBuilder.ApplyConfiguration(new ConfiguracionPrestamo());
        //modelBuilder.ApplyConfiguration(new ConfiguracionTipoArchivo());
        //modelBuilder.ApplyConfiguration(new ConfiguracionTransferencia());
        //modelBuilder.ApplyConfiguration(new ConfiguracionUnidadAdministrativaArchivo());
        //modelBuilder.ApplyConfiguration(new ConfiguracionZonaAlmacen());

        base.OnModelCreating(modelBuilder);
        
    }
    

}