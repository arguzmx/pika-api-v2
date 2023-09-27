using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

public class ConfiguracionUnidadAdministrativa : IEntityTypeConfiguration<UnidadAdministrativa>
{
    public void Configure(EntityTypeBuilder<UnidadAdministrativa> builder)
    {
        builder.ToTable("gd$unidadadministrativa");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Nombre).IsRequired().HasMaxLength(128);
        builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UOrgId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Responsable).IsRequired(false).HasMaxLength(250);
        builder.Property(e => e.Cargo).IsRequired(false).HasMaxLength(250);
        builder.Property(e => e.Telefono).IsRequired(false).HasMaxLength(50);
        builder.Property(e => e.Email).IsRequired(false).HasMaxLength(250);
        builder.Property(e => e.Domicilio).IsRequired(false).HasMaxLength(500);
        builder.Property(e => e.UbicacionFisica).IsRequired(false).HasMaxLength(500);
        builder.Property(e => e.ArchivoTramiteId).IsRequired(false).HasMaxLength(128);
        builder.Property(e => e.ArchivoConcentracionId).IsRequired(false).HasMaxLength(128);
        builder.Property(e => e.ArchivoHistoricoId).IsRequired(false).HasMaxLength(128);

        builder.HasOne(x => x.ArchivoTramite).WithMany(y=>y.UnidadesAdministrativasTramite).HasForeignKey(z=>z.ArchivoTramiteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ArchivoConcentracion).WithMany(y => y.UnidadesAdministrativasConcentracion).HasForeignKey(z => z.ArchivoConcentracionId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ArchivoHistorico).WithMany(y => y.UnidadesAdministrativasHistorico).HasForeignKey(z => z.ArchivoHistoricoId).OnDelete(DeleteBehavior.Restrict);
    }
}
