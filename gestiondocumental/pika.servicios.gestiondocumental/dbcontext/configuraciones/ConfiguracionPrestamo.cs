using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

public class ConfiguracionPrestamo : IEntityTypeConfiguration<Prestamo>
{
    public void Configure(EntityTypeBuilder<Prestamo> builder)
    {
        builder.ToTable("gd$prestamo");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.FechaCreacion).IsRequired();
        builder.Property(e => e.Folio).IsRequired().HasMaxLength(250);
        builder.Property(e => e.CantidadActivos).IsRequired();
        builder.Property(e => e.UsuarioOrigenId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UsuarioDestinoId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.FechaProgramadaDevolucion).IsRequired();
        builder.Property(e => e.FechaDevolucion).IsRequired();
        builder.Property(e => e.Descripcion).IsRequired().HasMaxLength(250);
        builder.Property(e => e.Entregado).IsRequired();
        builder.Property(e => e.Devuelto).IsRequired();
        builder.Property(e => e.TieneDevolucionesParciales).IsRequired();
        builder.Property(e => e.ArchivoId).IsRequired();
        builder.HasOne(x => x.Archivo).WithMany(y => y.Prestamos).HasForeignKey(z => z.ArchivoId);
    }
}
