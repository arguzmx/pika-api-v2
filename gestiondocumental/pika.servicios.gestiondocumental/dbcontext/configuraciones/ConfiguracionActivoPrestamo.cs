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
}
