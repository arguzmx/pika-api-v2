using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;

    public class ConfiguracionComentarioPrestamo : IEntityTypeConfiguration<ComentarioPrestamo>
    {
        public void Configure(EntityTypeBuilder<ComentarioPrestamo> builder)
        {
            builder.ToTable("comentarioprestamo");
            builder.HasKey(e => e.PrestamoId);

            builder.Property(e => e.PrestamoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Fecha).IsRequired();
            builder.Property(e => e.Comentario).IsRequired();
        }
    }

