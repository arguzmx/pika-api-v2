using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.contenido;

namespace pika.servicios.contenido.dbcontext.configuraciones;

public class ConfiguracionPermiso : IEntityTypeConfiguration<Permiso>
{
    public void Configure(EntityTypeBuilder<Permiso> builder)
    {
        builder.ToTable("contenido$permiso");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Leer);
        builder.Property(e => e.Escribir);
        builder.Property(e => e.Crear);
        builder.Property(e => e.Eliminar);

        //builder.HasOne(x => x.Repositorio).WithMany(y => y.Carpetas).HasForeignKey(z => z.RepositorioId).OnDelete(DeleteBehavior.Restrict);
        //builder.HasOne(x => x.Permiso).WithMany(y => y.Carpetas).HasForeignKey(z => z.PermisoId).OnDelete(DeleteBehavior.Restrict);
    }
}