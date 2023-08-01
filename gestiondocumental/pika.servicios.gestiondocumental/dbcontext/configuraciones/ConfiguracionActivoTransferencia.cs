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
    public class ConfiguracionActivoTransferencia : IEntityTypeConfiguration<ActivoTransferencia>
    {
        public void Configure(EntityTypeBuilder<ActivoTransferencia> builder)
        {
            builder.ToTable("activotransferencia");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ActivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Notas).IsRequired();
            builder.Property(e => e.TransferenciaId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Declinado).IsRequired();
            builder.Property(e => e.Aceptado).IsRequired();
            builder.Property(e => e.FechaVoto).IsRequired();
            builder.Property(e => e.FechaRetencion).IsRequired();
            builder.Property(e => e.CuadroClasificacionId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.EntradaClasificacionId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.MotivoDeclinado).IsRequired();
            builder.Property(e => e.UsuarioId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.UsuarioReceptorId).IsRequired().HasMaxLength(128);
            
        }
    }
}
