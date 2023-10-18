using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.contenido.Repositorio;

namespace pika.servicios.contenido.dbcontext.configuraciones;

public class ConfiguracionRepositorio : IEntityTypeConfiguration<Repositorio>
{
    public void Configure(EntityTypeBuilder<Repositorio> builder)
    {
        builder.ToTable("contenido$repositorio");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UOrgId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
        builder.Property(e => e.VolumenId).IsRequired().HasMaxLength(128);

        builder.HasOne(x => x.Volumen).WithMany(y => y.Repositorios).HasForeignKey(z => z.VolumenId).OnDelete(DeleteBehavior.Restrict);
    }
}