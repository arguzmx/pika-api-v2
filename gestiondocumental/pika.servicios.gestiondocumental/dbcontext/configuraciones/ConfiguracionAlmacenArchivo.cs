using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

    public class ConfiguracionAlmacenArchivo : IEntityTypeConfiguration<AlmacenArchivo>
    {
        public void Configure(EntityTypeBuilder<AlmacenArchivo> builder)
        {
            builder.ToTable("almacenarchivo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired();
            builder.Property(e => e.Clave).IsRequired();
            builder.Property(e => e.ArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Ubicacion).IsRequired();
            builder.Property(e => e.FolioActualContenedor).IsRequired();
            builder.Property(e => e.MacroFolioContenedor).IsRequired();
            builder.Property(e => e.HabilitarFoliado).IsRequired();
        }
    }

