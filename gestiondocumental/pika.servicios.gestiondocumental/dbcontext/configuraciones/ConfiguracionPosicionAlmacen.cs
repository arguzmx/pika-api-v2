using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones
{
    public class ConfiguracionPosicionAlmacen : IEntityTypeConfiguration<PosicionAlmacen>
    {

        public void Configure(EntityTypeBuilder<PosicionAlmacen> builder)
        {
            builder.ToTable(DbContextGestionDocumental.TablaPosicionAlmacen);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.Indice).IsRequired();
            builder.Property(e => e.Localizacion).IsRequired(false);
            builder.Property(e => e.CodigoBarras).IsRequired(false);
            builder.Property(e => e.CodigoElectronico).IsRequired(false);
            builder.Property(e => e.Ocupacion).IsRequired();
            builder.Property(e => e.IncrementoContenedor).IsRequired();
            builder.Property(e => e.ArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.AlmacenArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ZonaAlmacenId).IsRequired().HasMaxLength(128);


            builder.HasOne(x => x.Zona).WithMany(y => y.Posiciones).HasForeignKey(z => z.ZonaAlmacenId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Almacen).WithMany(y => y.Posiciones).HasForeignKey(z => z.AlmacenArchivoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Archivo).WithMany(y => y.Posiciones).HasForeignKey(z => z.ArchivoId).OnDelete(DeleteBehavior.Cascade);
           // builder.HasMany(x => x.Cajas).WithOne(y => y.Posicion).HasForeignKey(z => z.CajaAlmacenId).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
