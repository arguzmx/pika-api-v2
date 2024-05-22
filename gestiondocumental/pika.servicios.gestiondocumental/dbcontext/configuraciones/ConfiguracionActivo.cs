using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones
{
    public class ConfiguracionActivo : IEntityTypeConfiguration<Activo>
    {
        public void Configure(EntityTypeBuilder<Activo> builder)
        {
            builder.ToTable(DbContextGestionDocumental.TablaActivo);
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.CuadroClasificacionId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.SerieDocumentalId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ArchivoOrigenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ArchivoActualId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.TipoArchivoActualId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.UnidadAdministrativaId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.IdentificadorInterno).HasMaxLength(500);
            builder.Property(e => e.FechaApertura).IsRequired();
            builder.Property(e => e.FechaCierre);
            builder.Property(e => e.Asunto).HasMaxLength(2000);
            builder.Property(e => e.CodigoOptico).HasMaxLength(500);
            builder.Property(e => e.CodigoElectronico).HasMaxLength(500);
            builder.Property(e => e.EsElectronico).IsRequired();
            builder.Property(e => e.Reservado).IsRequired();
            builder.Property(e => e.Confidencial).IsRequired();
            builder.Property(e => e.UbicacionCaja).IsRequired().HasMaxLength(200);
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
            builder.Property(e => e.DiasTransferir);
            builder.Property(e => e.TieneContenido).IsRequired();
            builder.Property(e => e.ContenidoId).HasMaxLength(128);
            builder.HasOne(x => x.ArchivoActual).WithOne(y => y.ActivoActual);
            builder.HasOne(x => x.ArchivoOrigen).WithOne(y=>y.ActivoOrigen);
            //falta que archivo tenga propiedad de navegacion a activo
            ////falta que archivo tenga propiedad de navegacion a activo
            builder.HasOne(x => x.CuadroClasificacion).WithMany(y => y.Activos).HasForeignKey(z => z.CuadroClasificacionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}