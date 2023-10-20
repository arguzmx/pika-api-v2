using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.contenido.Permisos;

namespace pika.servicios.contenido.dbcontext.configuraciones;

public class ConfiguracionAsignacionPermiso : IEntityTypeConfiguration<AsignacionPermiso>
{
    public void Configure(EntityTypeBuilder<AsignacionPermiso> builder)
    {
        builder.ToTable("contenido$asignacionpermiso");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.RolId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UsuarioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.PermisoId).IsRequired().HasMaxLength(128);

        builder.HasOne(x => x.Permiso).WithMany(y => y.Asignaciones).HasForeignKey(z => z.PermisoId).OnDelete(DeleteBehavior.Restrict);
    }
}