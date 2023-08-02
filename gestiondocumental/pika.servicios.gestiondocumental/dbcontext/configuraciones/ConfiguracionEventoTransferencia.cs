using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;
public class ConfiguracionEventoTransferencia : IEntityTypeConfiguration<EventoTransferencia>
    {
        public void Configure(EntityTypeBuilder<EventoTransferencia> builder)
        {
            builder.ToTable("eventotransferencia");
            builder.HasKey(e => e.TransferenciaId);

            builder.Property(e => e.TransferenciaId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Fecha).IsRequired();
            builder.Property(e => e.EstadoTransferenciaId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Comentario).IsRequired();
            builder.Property(e => e.UsuarioId).IsRequired().HasMaxLength(128);
  
        }
    }

