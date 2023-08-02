using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

    public class ConfiguracionArchivo : IEntityTypeConfiguration<Archivo>
    {
        public void Configure(EntityTypeBuilder<Archivo> builder)
        {

            builder.ToTable("archivo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired();
            builder.Property(e => e.Eliminada).IsRequired();
            builder.Property(e => e.TipoOrigenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.OrigenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.TipoArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.VolumenDefaultId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.PuntoMontajeId).IsRequired().HasMaxLength(128);
          
      
        }
    }

