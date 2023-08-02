using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;


    public class ConfiguracionActivoPrestamo : IEntityTypeConfiguration<ActivoPrestamo>
    {
        public void Configure(EntityTypeBuilder<ActivoPrestamo> builder)
        {
            builder.ToTable("activoprestamo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.PrestamoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ActivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Devuelto).IsRequired();
        }
    }

