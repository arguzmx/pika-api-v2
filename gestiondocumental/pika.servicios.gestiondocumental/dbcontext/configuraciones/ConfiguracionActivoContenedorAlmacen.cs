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
    public class ConfiguracionActivoContenedorAlmacen : IEntityTypeConfiguration<ActivoContenedorAlmacen>
    {
        public void Configure(EntityTypeBuilder<ActivoContenedorAlmacen> builder)
        {
            builder.ToTable("activocontenedoralmacen");
            builder.HasKey(e => e.ContenedorAlmacenId);

            builder.Property(e => e.ContenedorAlmacenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ActivoId).IsRequired().HasMaxLength(128);
        }
    }
}
