using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones
{
    public class ConfiguracionComentarioTrasnferencia : IEntityTypeConfiguration<ComentarioTransferencia>
    {
        public void Configure(EntityTypeBuilder<ComentarioTransferencia> builder)
        {
            builder.ToTable("comentariotransferencia");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.TransferenciaId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.UsuarioId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Fecha).IsRequired();
            builder.Property(e => e.Comentario).IsRequired();
            builder.Property(e => e.Publico).IsRequired();
        }
    }
}
