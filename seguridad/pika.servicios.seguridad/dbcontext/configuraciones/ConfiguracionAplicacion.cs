

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.seguridad;

namespace pika.servicios.seguridad.dbcontext.configuraciones
{
    public class ConfiguracionAplicacion : IEntityTypeConfiguration<Aplicacion>
    {
        public void Configure(EntityTypeBuilder<Aplicacion> builder)
        {
            builder.ToTable(DbContextSeguridad.TablaAplicacion);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.Descripcion).IsRequired().HasMaxLength(500);

        }
    }
}
