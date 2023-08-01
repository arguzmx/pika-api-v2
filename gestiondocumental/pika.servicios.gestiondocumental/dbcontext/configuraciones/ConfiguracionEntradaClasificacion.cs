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

    public class ConfiguracionEntradaClasificacion : IEntityTypeConfiguration<EntradaClasificacion>
    {

        public void Configure(EntityTypeBuilder<EntradaClasificacion> builder)
        {

            builder.ToTable("entradaclasificacion");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Clave).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);         
            builder.Property(e => e.VigenciaTramite).IsRequired();
            builder.Property(e => e.VigenciaConcentracion).IsRequired();
            builder.Property(e => e.Descripcion).IsRequired();
            builder.Property(e => e.AbreCon).IsRequired();
            builder.Property(e => e.CierraCon).IsRequired();
            builder.Property(e => e.Contiene).IsRequired();

            builder.Property(e => e.InstruccionFinal).IsRequired();
            builder.Property(e => e.TipoDisposicionDocumentalId).IsRequired();
            builder.Property(e => e.ElementoClasificacionId).IsRequired();
            builder.Property(e => e.Eliminada).IsRequired();
            builder.Property(e => e.Posicion).IsRequired();
            builder.Property(e => e.CuadroClasifiacionId).IsRequired();
           // builder.Property(e => e.NombreCompleto).IsRequired();
           // builder.Property(e => e.TipoValoracionDocumentalId).IsRequired();
        }
        /*
        //[XmlIgnore]
        //[JsonIgnore]
        //public string[] Valoracionids { get; set; }
        public ICollection<ValoracionEntradaClasificacion> ValoracionesEntrada { get; set; }
        public virtual ICollection<Activo> Activos { get; set; }
        public List<Transferencia> Transferencias { get; set; }
        public virtual TipoDisposicionDocumental DisposicionEntrada { get; set; }
        public List<EstadisticaClasificacionAcervo> EstadisticasClasificacionAcervo { get; set; }
         */
    }
}
