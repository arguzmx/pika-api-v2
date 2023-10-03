using api.comunes.modelos.modelos;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.Archivos.Catalogos;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext.configuraciones;


namespace pika.servicios.gestiondocumental.dbcontext;

public class DbContextGestionDocumental : DbContext
{
    public DbContextGestionDocumental(DbContextOptions<DbContextGestionDocumental> options) : base(options)
    {

    }
<<<<<<< HEAD
    public DbSet<Prestamo> Prestamos { get; set; }
=======
    public DbSet<UnidadAdministrativa> UnidadesAdministrativas{ get; set; }
>>>>>>> main
    public DbSet<Archivo> Archivos { get; set; }
    public DbSet<ElementoCatalogo> TipoArchivo { get; set; }
    public DbSet<TraduccionesTipoArchivo> TraduccionesTipoArchivo { get; set; }
    public DbSet<CuadroClasificacion> CuadrosClasificacion { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
<<<<<<< HEAD
        modelBuilder.ApplyConfiguration(new ConfiguracionCatalogoTipoArchivo());
        modelBuilder.ApplyConfiguration(new ConfiguracionI18NCatalogoTipoArchivo());
        modelBuilder.ApplyConfiguration(new ConfiguracionPrestamo());
=======
<<<<<<< HEAD
      
=======
>>>>>>> 857ffacdbde21228efaa9662705c9ec716c235ee
        modelBuilder.ApplyConfiguration(new ConfiguracionUnidadAdministrativa());
>>>>>>> main
        modelBuilder.ApplyConfiguration(new ConfiguracionArchivo());
        modelBuilder.ApplyConfiguration(new ConfiguracionElementoCatalogo());
        modelBuilder.ApplyConfiguration(new ConfiguracionI18NCatalogo());
        modelBuilder.ApplyConfiguration(new ConfiguracionCuadroClasificacion());

        base.OnModelCreating(modelBuilder); 
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
