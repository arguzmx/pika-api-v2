using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext.configuraciones;

namespace pika.servicios.gestiondocumental.dbcontext;

public class PIKADbContext: DbContext
{
    public PIKADbContext(DbContextOptions<PIKADbContext> options)
            : base(options)
    {
    }

    /// <summary>
    /// Activos del acervo en una unidad administrativa
    /// </summary>
    public DbSet<Activo> Activos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfiguracionActivo());
        base.OnModelCreating(modelBuilder);
    }
}
