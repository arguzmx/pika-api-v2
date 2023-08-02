using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

public class ConfiguracionTipoArchivo : IEntityTypeConfiguration<TipoArchivo>
    {
        public void Configure(EntityTypeBuilder<TipoArchivo> builder)
        {

            builder.ToTable("tipoarchivo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired();
            builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.UOId).IsRequired().HasMaxLength(128);
         
        }
    }

