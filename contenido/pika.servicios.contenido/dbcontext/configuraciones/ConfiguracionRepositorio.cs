using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.contenido;

namespace pika.servicios.contenido.dbcontext.configuraciones
{
    public class ConfiguracionRepositorio : IEntityTypeConfiguration<Repositorio>
    {

        public void Configure(EntityTypeBuilder<Repositorio> builder)
        {
            builder.ToTable(DbContextContenido.TablaRepositorio);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.UOrgId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.VolumenId).IsRequired().HasMaxLength(500);

            builder.HasOne(x => x.Volumen).WithMany(y => y.Repositorios).HasForeignKey(x => x.VolumenId).OnDelete(DeleteBehavior.Cascade);

        }

    }
}
