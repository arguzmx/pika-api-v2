﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using api.comunes.modelos.modelos;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.Archivos.Catalogos;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

public class ConfiguracionElementoCatalogo : IEntityTypeConfiguration<ElementoCatalogo>
{
    public void Configure(EntityTypeBuilder<ElementoCatalogo> builder)
    {
        builder.ToTable("gd$catalogos");
        builder.HasDiscriminator<int>("Discriminator")
            .HasValue<ElementoCatalogo>(0)
            .HasValue<TipoArchivo>(1);

        builder.HasKey(e => new { e.Id } );
        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Texto).IsRequired().HasMaxLength(512); 
        builder.Property(e => e.Idioma).IsRequired().HasMaxLength(10); 
        builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UnidadOrganizacionalId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.CatalogoId).IsRequired().HasMaxLength(128);
        builder.HasIndex(e => e.CatalogoId);
    }
}

public class ConfiguracionI18NCatalogo : IEntityTypeConfiguration<I18NCatalogo>
{
    public void Configure(EntityTypeBuilder<I18NCatalogo> builder)
    {

        builder.ToTable("gd$i18ncatalogos");
        builder.HasDiscriminator<int>("Discriminator")
            .HasValue<I18NCatalogo>(0)
            .HasValue<TraduccionesTipoArchivo>(1); 

        builder.HasKey(e => new { e.Id, e.DominioId, e.UnidadOrganizacionalId, e.Idioma });
        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Texto).IsRequired().HasMaxLength(512);
        builder.Property(e => e.Idioma).IsRequired().HasMaxLength(10);
        builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.CatalogoId).IsRequired().HasMaxLength(128);
        builder.HasIndex(e => new { e.CatalogoId, e.Idioma });

    }
}
