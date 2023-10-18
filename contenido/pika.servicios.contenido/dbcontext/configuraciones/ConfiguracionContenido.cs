using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.contenido.Contenido;

namespace pika.servicios.contenido.dbcontext.configuraciones;

public class ConfiguracionContenido : IEntityTypeConfiguration<Contenido>
{
    public void Configure(EntityTypeBuilder<Contenido> builder)
    {
        builder.ToTable("contenido$contenido");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
        builder.Property(e => e.RepositorioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.CreadorId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.ConteoAnexos);
        builder.Property(e => e.TamanoBytes);
        builder.Property(e => e.VolumenId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.CarpetaId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.TipoElemento).IsRequired().HasMaxLength(128);
        builder.Property(e => e.IdExterno).IsRequired().HasMaxLength(128);


        builder.HasOne(x => x.Volumen).WithMany(y => y.Contenido).HasForeignKey(z => z.VolumenId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Carpeta).WithMany(y => y.Contenido).HasForeignKey(z => z.CarpetaId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Repositorio).WithMany(y => y.Contenido).HasForeignKey(z => z.RepositorioId).OnDelete(DeleteBehavior.Restrict);

    }
}