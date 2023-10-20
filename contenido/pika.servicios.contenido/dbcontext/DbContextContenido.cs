using Microsoft.EntityFrameworkCore;
using pika.modelo.contenido.Volumen;
using pika.modelo.contenido.Carpeta;
using pika.modelo.contenido.Contenido;
using pika.modelo.contenido.Repositorio;
using pika.servicios.contenido.dbcontext.configuraciones;
using pika.modelo.contenido;
using pika.modelo.contenido.Permisos;

namespace pika.servicios.contenido.dbcontext;

public class DbContextContenido : DbContext
{
    public DbContextContenido(DbContextOptions<DbContextContenido> options) : base(options)
    {

    }

    public DbSet<Volumen> Volumen { get; set; }
    public DbSet<Carpeta> Carpeta { get; set; }
    public DbSet<Contenido> Contenido { get; set; }
    public DbSet<Repositorio> Repositorio { get; set; }
    public DbSet<Permiso> Permiso { get; set; }
    public DbSet<AsignacionPermiso> AsignacionPermiso { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfiguracionVolumen());
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ConfiguracionCarpeta());
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ConfiguracionContenido());
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ConfiguracionRepositorio());
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ConfiguracionPermiso());
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ConfiguracionAsignacionPermiso());
        base.OnModelCreating(modelBuilder);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
