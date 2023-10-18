using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.contenido.Carpeta;

namespace pika.servicios.contenido.dbcontext.configuraciones;

public class ConfiguracionCarpeta : IEntityTypeConfiguration<Carpeta>
{
    public void Configure(EntityTypeBuilder<Carpeta> builder)
    {
        builder.ToTable("contenido$carpeta");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.RepositorioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.CreadorId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.FechaCreacion);
        builder.Property(e => e.Nombre).IsRequired().HasMaxLength(512);
        builder.Property(e => e.CarpetaPadreId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.EsRaiz);

        builder.HasOne(x => x.Repositorio).WithMany(y => y.Carpetas).HasForeignKey(z => z.RepositorioId).OnDelete(DeleteBehavior.Restrict);             
    }
}