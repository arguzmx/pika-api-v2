using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones
{
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
            builder.Property(e => e.Inicio).IsRequired();
            builder.Property(e => e.Fin).IsRequired();
            builder.Property(e => e.FundamentoLegal).IsRequired();
            builder.Property(e => e.Anos).IsRequired();
            builder.Property(e => e.Meses).IsRequired();
            builder.Property(e => e.Dias).IsRequired();
            builder.Property(e => e.ActivoId).IsRequired().HasMaxLength(128);
          
        }
    }
}
