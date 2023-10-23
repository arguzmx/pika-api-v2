using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;


namespace pika.servicios.gestiondocumental.dbcontext.configuraciones
{
    public class ConfiguracionActivo : IEntityTypeConfiguration<Activo>
    {



        public void Configure(EntityTypeBuilder<Activo> builder)
        {
            builder.ToTable("gd$activo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.CuadroClasificacionId).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.SerieDocumentalId).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.ArchivoOrigenId).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.ArchivoActualId).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.TipoArchivoActualId).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.UnidadAdministrativaId).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired(true).HasMaxLength(500);
            builder.Property(e => e.IdentificadorInterno).IsRequired(false).HasMaxLength(500);
            builder.Property(e => e.FechaApertura).IsRequired(true);
            builder.Property(e => e.FechaCierre).IsRequired(false);
            builder.Property(e => e.Asunto).IsRequired(false).HasMaxLength(2000);
            builder.Property(e => e.CodigoOptico).IsRequired(false).HasMaxLength(500);
            builder.Property(e => e.CodigoElectronico).IsRequired(false).HasMaxLength(500);
            builder.Property(e => e.EsElectronico).IsRequired(true);
            builder.Property(e => e.Reservado).IsRequired(true);
            builder.Property(e => e.Confidencial).IsRequired(true);
            builder.Property(e => e.UbicacionCaja).IsRequired().HasMaxLength(200);
            builder.Property(e => e.UbicacionRack).IsRequired().HasMaxLength(200);
            builder.Property(e => e.EnPrestamo).IsRequired(true);
            builder.Property(e => e.EnTransferencia).IsRequired(true);
            builder.Property(e => e.Ampliado).IsRequired(true);
            builder.Property(e => e.FechaRetencionAT).IsRequired(false);
            builder.Property(e => e.FechaRetencionAC).IsRequired(false);
            builder.Property(e => e.AlmacenArchivoId).IsRequired(false).HasMaxLength(128);
            builder.Property(e => e.ZonaAlmacenId).IsRequired(false).HasMaxLength(128);
            builder.Property(e => e.ContenedorAlmacenId).IsRequired(false).HasMaxLength(128);
            builder.Property(e => e.FechaCreacion).IsRequired(true);
            builder.Property(e => e.UsuarioId).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.UnidadOrganizacionalId).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.DominioId).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.TieneContenido).IsRequired(true);
            builder.Property(e => e.ContenidoId).IsRequired(false).HasMaxLength(128);

            builder.HasOne(x => x.ArchivoActual).WithMany(y => y.ActivosActuales).HasForeignKey(z => z.ArchivoActualId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ArchivoOrigen).WithMany(y => y.ActivosOrigen).HasForeignKey(z => z.ArchivoOrigenId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
