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
    public class ConfiguracionPrestamo : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {
            builder.ToTable(DbContextGestionDocumental.TablaPrestamo);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.FechaCreacion).IsRequired();
            builder.Property(e => e.Folio).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.UsuarioOrigenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.UsuarioDestinoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.FechaProgramadaDevolucion).IsRequired().HasMaxLength(128);
            builder.Property(e => e.FechaDevolucion).IsRequired();
            builder.Property(e => e.Descripcion).IsRequired().HasMaxLength(500);
            builder.Property(e => e.CantidadActivos).IsRequired();
            builder.Property(e => e.Entregado).IsRequired();


            builder.HasOne(x => x.Archivo).WithMany(y => y.Prestamos).HasForeignKey(z => z.ArchivoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
