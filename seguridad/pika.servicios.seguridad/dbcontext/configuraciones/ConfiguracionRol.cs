using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.seguridad.dbcontext.configuraciones
{
    public class ConfiguracionRol : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable(DbContextSeguridad.TablaRoles);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.Descripcion).IsRequired().HasMaxLength(500);
            builder.HasOne(e => e.Modulo).WithMany(z => z.RolesPredefinidos).HasForeignKey(y => y.ModuloId);

        }
    }
}