using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

public class ConfiguracionArchivo : IEntityTypeConfiguration<Archivo>
{
    public void Configure(EntityTypeBuilder<Archivo> builder)
    {
        builder.ToTable("gd$archivo");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired(true).HasMaxLength(128);
        builder.Property(e => e.Nombre).IsRequired(true).HasMaxLength(500);
        builder.Property(e => e.DominioId).IsRequired(true).HasMaxLength(128);
        builder.Property(e => e.UOrgId).IsRequired(true).HasMaxLength(128);
        builder.Property(e => e.TipoArchivoId).IsRequired(true).HasMaxLength(128);

        builder.HasOne(x => x.TipoArchivo).WithMany(y => y.Archivos).HasForeignKey(z => z.TipoArchivoId).OnDelete(DeleteBehavior.Cascade);
    }
}

