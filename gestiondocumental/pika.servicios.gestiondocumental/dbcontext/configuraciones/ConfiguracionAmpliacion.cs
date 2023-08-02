using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

    public class ConfiguracionAmpliacion : IEntityTypeConfiguration<Ampliacion>
    {
        public void Configure(EntityTypeBuilder<Ampliacion> builder)
        {
            builder.ToTable("ampliacion");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.TipoAmpliacionId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.FechaFija).IsRequired();
            builder.Property(e => e.Vigente).IsRequired();
            builder.Property(e => e.Inicio).IsRequired(false);
            builder.Property(e => e.Fin).IsRequired(false);
            builder.Property(e => e.FundamentoLegal).IsRequired();
            builder.Property(e => e.Anos).IsRequired(false);
            builder.Property(e => e.Meses).IsRequired(false);
            builder.Property(e => e.Dias).IsRequired(false);
            builder.Property(e => e.ActivoId).IsRequired().HasMaxLength(128);
          
        }
    }

