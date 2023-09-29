using api.comunes.modelos.modelos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental.CuadrosClasificacion.Catalogos;
using pika.modelo.gestiondocumental.CuadrosClasificacion.TraduccionesCatalogos;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

public class ConfiguracionCatalogoTipoDisposicionDocumental : IEntityTypeConfiguration<ElementoCatalogo>
{
    public void Configure(EntityTypeBuilder<ElementoCatalogo> builder)
    {

        builder.ToTable("gd$catalogos");
        builder.HasDiscriminator<string>("Catalogo")
            .HasValue<pika.modelo.gestiondocumental.CuadrosClasificacion.Catalogos.TipoDisposicionDocumental>("TipoDisposicionDocumental");

        builder.HasKey(e => new { e.Id });
        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Texto).IsRequired().HasMaxLength(512);
        builder.Property(e => e.Idioma).IsRequired().HasMaxLength(10);
        builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UnidadOrganizacionalId).IsRequired().HasMaxLength(128);
    }
}

public class ConfiguracionI18NCatalogoTipoDisposicionDocumental : IEntityTypeConfiguration<I18NCatalogo>
{
    public void Configure(EntityTypeBuilder<I18NCatalogo> builder)
    {

        builder.ToTable("gd$i18ncatalogos");
        builder.HasDiscriminator<string>("Catalogo")
            .HasValue<TraduccionesTipoDisposicionDocumental>("TipoDisposicionDocumental");

        builder.HasKey(e => new { e.Id, e.Idioma, e.DominioId, e.UnidadOrganizacionalId });
        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Texto).IsRequired().HasMaxLength(512);
        builder.Property(e => e.Idioma).IsRequired().HasMaxLength(10);
        builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UnidadOrganizacionalId).IsRequired().HasMaxLength(128);

    }
}