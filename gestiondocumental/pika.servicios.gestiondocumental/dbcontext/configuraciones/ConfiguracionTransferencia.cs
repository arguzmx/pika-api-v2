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
    public class ConfiguracionTransferencia : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.ToTable("transferencia");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired();
            builder.Property(e => e.Folio).IsRequired();
            builder.Property(e => e.ArchivoDestinoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.CuadroClasificacionId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.EntradaClasificacionId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.RangoDias).IsRequired();
            builder.Property(e => e.TemaId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.EliminarTema).IsRequired();
            builder.Property(e => e.CantidadActivos).IsRequired();
            builder.Property(e => e.FechaCreacion).IsRequired();
            builder.Property(e => e.EstadoTransferenciaId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ArchivoOrigenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.UsuarioId).IsRequired().HasMaxLength(128);
        }
    }
}
