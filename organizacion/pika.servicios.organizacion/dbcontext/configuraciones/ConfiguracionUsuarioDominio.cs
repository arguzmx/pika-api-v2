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
    public class ConfiguracionUsuarioDominio : IEntityTypeConfiguration<UsuarioDominio>
    {
        public void Configure(EntityTypeBuilder<UsuarioDominio> builder)
        {
            builder.ToTable("org$usuariodominio");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.UsuarioId).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.DominioId).IsRequired(true).HasMaxLength(128);

            builder.HasOne(x => x.Dominios).WithMany(y => y.UsuarioDominio).HasForeignKey(z => z.DominioId).OnDelete(DeleteBehavior.Restrict);
            //cascade resstrict
        }
    }
}
