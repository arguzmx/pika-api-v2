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
    public class ConfiguracionUnidadOrganizacional : IEntityTypeConfiguration<UnidadOrganizacional>
    {
        public void Configure(EntityTypeBuilder<UnidadOrganizacional> builder)
        {
  

            builder.ToTable("org$unidadorganizacional");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.DominioId).IsRequired(true).HasMaxLength(128);
         
            builder.HasOne(x => x.Dominio).WithMany(y => y.UnidadesOrganizacionales).HasForeignKey(z => z.DominioId).OnDelete(DeleteBehavior.Restrict);
          //  builder.HasMany(x => x.UsuariosUnidad).WithOne(y => y.UnidadOrganizacional).HasForeignKey(z => z.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
