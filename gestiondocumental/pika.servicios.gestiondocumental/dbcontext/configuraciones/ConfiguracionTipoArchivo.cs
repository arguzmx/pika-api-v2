using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

public class ConfiguracionTipoArchivo : IEntityTypeConfiguration<TipoArchivo>
{
    public void Configure(EntityTypeBuilder<TipoArchivo> builder)
    {

        builder.ToTable("tipoarchivo");
        builder.HasKey(e => new { e.Id, e.Idioma } );

        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Texto).IsRequired();
        builder.Property(e => e.Idioma).IsRequired();
        builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UnidadOrganizacionalId).IsRequired().HasMaxLength(128);

    }
}

