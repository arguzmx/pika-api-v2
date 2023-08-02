using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;
public class ConfiguracionPosicionAlmacen : IEntityTypeConfiguration<PosicionAlmacen>
    {
        public void Configure(EntityTypeBuilder<PosicionAlmacen> builder)
        {
            builder.ToTable("posicionalmacen");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired();
            builder.Property(e => e.Indice).IsRequired();
            builder.Property(e => e.Localizacion).IsRequired();
            builder.Property(e => e.CodigoBarras).IsRequired();
            builder.Property(e => e.CodigoElectronico).IsRequired();
            builder.Property(e => e.Ocupacion).IsRequired();
            builder.Property(e => e.IncrementoContenedor).IsRequired();
            builder.Property(e => e.ArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.AlmacenArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ZonaAlmacenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.PosicionPadreId).IsRequired().HasMaxLength(128);
        }
    }

