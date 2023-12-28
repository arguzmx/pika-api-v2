using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones
{
    public class ConfiguracionTransferencia : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.ToTable(DbContextGestionDocumental.TablaTransferencias);
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.Folio).IsRequired(false).HasMaxLength(500);
            builder.Property(e => e.ArchivoOrigenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ArchivoDestinoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.CuadroClasificacionId).IsRequired(false).HasMaxLength(128);
            builder.Property(e => e.SerieDocumentalId).IsRequired(false).HasMaxLength(128);
            builder.Property(e => e.RangoDias).IsRequired(false);
            builder.Property(e => e.CantidadActivos).IsRequired();
            builder.Property(e => e.FechaCreacion).IsRequired();
            builder.Property(e => e.EstadoTransferenciaId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.UsuarioId).IsRequired().HasMaxLength(128);

            builder.HasOne(x => x.SerieDocumental).WithMany(y => y.Transferencias).HasForeignKey(z => z.SerieDocumentalId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.CuadroClasificacion).WithMany(y => y.Transferencias).HasForeignKey(z => z.CuadroClasificacionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Estado).WithMany(y => y.Transferencias).HasForeignKey(z => z.EstadoTransferenciaId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.ArchivoOrigen).WithMany(y => y.OrigenesTransferencias).HasForeignKey(z => z.ArchivoOrigenId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.ArchivoDestino).WithMany(y => y.DestinosTransferencias).HasForeignKey(z => z.ArchivoDestinoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
