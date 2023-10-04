


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

public class ConfiguracionActivo:IEntityTypeConfiguration<modelo.gestiondocumental.Activo>
{
    public void Configure(EntityTypeBuilder<modelo.gestiondocumental.Activo> builder)
    {
        builder.ToTable("gd$activo");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CuadroClasificacionId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.SerieDocumentalId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.ArchivoOrigenId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.ArchivoActualId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.TipoArchivoActualId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UnidadAdministrativaId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Nombre).IsRequired().HasMaxLength(128);
        builder.Property(e => e.IdentificadorInterno).HasMaxLength(500);
        builder.Property(e => e.FechaApertura).IsRequired();
        builder.Property(e => e.FechaCierre);
        builder.Property(e => e.Asunto).HasMaxLength(2000);
        builder.Property(e => e.CodigoOptico).HasMaxLength(5000);
        builder.Property(e => e.CodigoElectronico).HasMaxLength(5000);
        builder.Property(e => e.EsElectronico).IsRequired();
        builder.Property(e => e.Reservado).IsRequired();
        builder.Property(e => e.Confidencial).IsRequired();
        builder.Property(e => e.UbicacionCaja).HasMaxLength(200);
        builder.Property(e => e.UbicacionRack).HasMaxLength(200);
        builder.Property(e => e.EnPrestamo).IsRequired();
        builder.Property(e => e.EnTransferencia).IsRequired();
        builder.Property(e => e.Ampliado).IsRequired();
        builder.Property(e => e.FechaRetencionAT);
        builder.Property(e => e.FechaRetencionAC);
        builder.Property(e => e.AlmacenArchivoId).HasMaxLength(128);
        builder.Property(e => e.ZonaAlmacenId).HasMaxLength(128);
        builder.Property(e => e.ContenedorAlmacenId).HasMaxLength(128);
        builder.Property(e => e.FechaCreacion).IsRequired();
        builder.Property(e => e.UsuarioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UnidadOrganizacionalId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.TieneContenido).IsRequired();
        builder.Property(e => e.ContenidoId).HasMaxLength(128);

        builder.HasOne(x => x.ArchivoActual).WithMany(y => y.ActivosActuales).HasForeignKey(z => z.ArchivoActualId).OnDelete( DeleteBehavior.Restrict);
        builder.HasOne(x => x.ArchivoOrigen).WithMany(y => y.ActivosOrigen).HasForeignKey(z => z.ArchivoOrigenId).OnDelete(DeleteBehavior.Restrict);

    }
}