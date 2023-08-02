using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;


    public class ConfiguracionEntradaClasificacion : IEntityTypeConfiguration<EntradaClasificacion>
    {

        public void Configure(EntityTypeBuilder<EntradaClasificacion> builder)
        {

            builder.ToTable("entradaclasificacion");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Clave).IsRequired();
            builder.Property(e => e.Nombre).IsRequired();         
            builder.Property(e => e.VigenciaTramite).IsRequired();
            builder.Property(e => e.VigenciaConcentracion).IsRequired();
            builder.Property(e => e.Descripcion).IsRequired();
            builder.Property(e => e.AbreCon).IsRequired();
            builder.Property(e => e.CierraCon).IsRequired();
            builder.Property(e => e.Contiene).IsRequired();

            builder.Property(e => e.InstruccionFinal).IsRequired();
            builder.Property(e => e.TipoDisposicionDocumentalId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ElementoClasificacionId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Eliminada).IsRequired();
            builder.Property(e => e.Posicion).IsRequired();
            builder.Property(e => e.CuadroClasifiacionId).IsRequired().HasMaxLength(128);
          
        }
        
    }

