using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

internal class ConfiguracionActivo: IEntityTypeConfiguration<Activo>
{
    public void Configure(EntityTypeBuilder<Activo> builder)
    {
        builder.ToTable("activo");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.CuadroClasificacionId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.SerieDocumentalId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
        builder.Property(e => e.IDunico).IsRequired(false).HasMaxLength(200);
        builder.Property(e => e.FechaApertura).IsRequired();
        builder.Property(e => e.FechaCierre).IsRequired(false);
        builder.Property(e => e.Asunto).IsRequired(false).HasMaxLength(500);
        builder.Property(e => e.CodigoOptico).IsRequired(false).HasMaxLength(200);
        builder.Property(e => e.CodigoElectronico).IsRequired(false).HasMaxLength(200);
        builder.Property(e => e.EsElectronico).IsRequired();
        builder.Property(e => e.Reservado).IsRequired();
        builder.Property(e => e.EnPrestamo).IsRequired();
        builder.Property(e => e.EnTransferencia).IsRequired();
        builder.Property(e => e.Ampliado).IsRequired();
        builder.Property(e => e.Confidencial).IsRequired();
        builder.Property(e => e.UbicacionCaja).IsRequired(false).HasMaxLength(200);
        builder.Property(e => e.UbicacionRack).IsRequired(false).HasMaxLength(200);
        builder.Property(e => e.ArchivoOrigenId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.ArchivoActualId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UnidadAdministrativaArchivoId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.FechaRetencionAT).IsRequired(false);
        builder.Property(e => e.FechaRetencionAC).IsRequired(false);
        builder.Property(e => e.AlmacenArchivoId).IsRequired(false).HasMaxLength(128);
        builder.Property(e => e.ZonaAlmacenId).IsRequired(false).HasMaxLength(128);
        builder.Property(e => e.ContenedorAlmacenId).IsRequired(false).HasMaxLength(128);
        builder.Property(e => e.FechaCreacion).IsRequired();
        builder.Property(e => e.UsuarioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UnidadOrganizacionalId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.TipoArchivoActualId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Vencidos).IsRequired(false);
        builder.Property(e => e.TieneContenido).IsRequired();
        builder.Property(e => e.ElementoId).IsRequired().HasMaxLength(128);
    }
}
