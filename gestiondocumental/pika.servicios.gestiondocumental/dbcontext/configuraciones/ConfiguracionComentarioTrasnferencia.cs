using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

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

