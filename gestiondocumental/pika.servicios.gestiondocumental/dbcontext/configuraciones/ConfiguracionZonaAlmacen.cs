using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;
public class ConfiguracionZonaAlmacen : IEntityTypeConfiguration<ZonaAlmacen>
    {
        public void Configure(EntityTypeBuilder<ZonaAlmacen> builder)
        {

            builder.ToTable("zonaalmacen");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired();
            builder.Property(e => e.ArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.AlmacenArchivoId).IsRequired().HasMaxLength(128);
        }
    }

