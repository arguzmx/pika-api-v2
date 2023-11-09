using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.organizacion.dbcontext.configuraciones
{
    public class ConfiguracionUsuarioUnidadOrganizacional : IEntityTypeConfiguration<UsuarioUnidadOrganizacional>
    {

        public void Configure(EntityTypeBuilder<UsuarioUnidadOrganizacional> builder)
        {
            builder.ToTable("org$usuariounidadorganizacional");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.UsuarioId).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.DominioId).IsRequired(true);
            builder.Property(e => e.UnidadOrganizacionalId).IsRequired(true).HasMaxLength(128);
            
            builder.HasOne(x => x.UnidadOrganizacional).WithMany(y => y.UsuariosUnidad).HasForeignKey(z => z.UnidadOrganizacionalId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Dominio).WithMany(y => y.UsuarioUnidadOrganizacionals).HasForeignKey(z => z.DominioId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
