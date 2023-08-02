using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;
public class ConfiguracionContenedorAlmacen : IEntityTypeConfiguration<ContenedorAlmacen>
    {
        public void Configure(EntityTypeBuilder<ContenedorAlmacen> builder)
        {
            builder.ToTable("contenedoralmacen");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired();
            builder.Property(e => e.CodigoBarras).IsRequired();
            builder.Property(e => e.CodigoElectronico).IsRequired();
            builder.Property(e => e.Ocupacion).IsRequired();
            builder.Property(e => e.ZonaAlmacenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.PosicionAlmacenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.AlmacenArchivoId).IsRequired().HasMaxLength(128);
        }
    }

