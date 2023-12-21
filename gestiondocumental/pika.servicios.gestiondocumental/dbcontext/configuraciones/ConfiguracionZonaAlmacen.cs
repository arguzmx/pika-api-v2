using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.Topologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones
{
    public class ConfiguracionZonaAlmacen : IEntityTypeConfiguration<ZonaAlmacen>
    {
        public void Configure(EntityTypeBuilder<ZonaAlmacen> builder)
        {
            builder.ToTable(DbContextGestionDocumental.TablaZonaAlmacen);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.ArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.AlmacenArchivoId).IsRequired().HasMaxLength(128);
       

            builder.HasOne(x => x.Almacen).WithMany(y => y.Zonas).HasForeignKey(z => z.AlmacenArchivoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Archivo).WithMany(y => y.Zonas).HasForeignKey(z => z.ArchivoId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
