using api.comunes.modelos.modelos;
using Microsoft.EntityFrameworkCore;
using pika.modelo.contenido;
using pika.servicios.contenido.dbcontext.configuraciones;

namespace pika.servicios.contenido.dbcontext;

public class DbContextContenido : DbContext
{

    public const string TablaVolumen = "cont$volumen";

    public DbContextContenido(DbContextOptions<DbContextContenido> options) : base(options)
    {

    }

    public DbSet<Volumen> Volumenes { get; set; }
    public DbSet <ElementoCatalogo> TipoGestorES { get; set; }
    public DbSet <I18NCatalogo> TraduccionesTipoGestorES { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfiguracionVolumen());
        modelBuilder.ApplyConfiguration(new ConfiguracionElementoCatalogo());
        modelBuilder.ApplyConfiguration(new ConfiguracionI18NCatalogo());
        base.OnModelCreating(modelBuilder);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }


}
