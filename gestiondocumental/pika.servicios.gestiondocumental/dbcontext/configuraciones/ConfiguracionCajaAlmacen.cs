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
    public class ConfiguracionCajaAlmacen : IEntityTypeConfiguration<CajaAlmacen>
    {

        public void Configure(EntityTypeBuilder<CajaAlmacen> builder)
        {
            builder.ToTable(DbContextGestionDocumental.TablaCajaAlmacen);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.CodigoBarras).IsRequired(false);
            builder.Property(e => e.CodigoElectronico).IsRequired(false);
            builder.Property(e => e.Ocupacion).IsRequired();
            builder.Property(e => e.AlmacenArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ZonaAlmacenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.PosicionAlmacenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ArchivoId).IsRequired().HasMaxLength(128);
            builder.HasOne(x => x.Zona).WithMany(y => y.Cajas).HasForeignKey(z => z.ZonaAlmacenId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Almacen).WithMany(y => y.Cajas).HasForeignKey(z => z.AlmacenArchivoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Archivo).WithMany(y => y.Cajas).HasForeignKey(z => z.ArchivoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Posicion).WithMany(y => y.Cajas).HasForeignKey(z => z.PosicionAlmacenId).OnDelete(DeleteBehavior.Cascade);
        }


    }
}
