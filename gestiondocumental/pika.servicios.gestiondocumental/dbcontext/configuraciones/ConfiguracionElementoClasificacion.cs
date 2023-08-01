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
   
    public class ConfiguracionElementoClasificacion : IEntityTypeConfiguration<ElementoClasificacion>
    {
        public void Configure(EntityTypeBuilder<ElementoClasificacion> builder)
        {

            builder.ToTable("elementoclasificacion");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Clave).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.Eliminada).IsRequired();
            builder.Property(e => e.Posicion).IsRequired();
            builder.Property(e => e.CuadroClasifiacionId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ElementoClasificacionId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.EsRaiz).IsRequired();
          //  builder.Property(e => e.NombreJerarquico).IsRequired();


            /*
        public virtual ElementoClasificacion Padre { get; set; }
        public virtual ICollection<ElementoClasificacion> Hijos { get; set; }
        public virtual CuadroClasificacion CuadroClasificacion { get; set; }
        public virtual ICollection<EntradaClasificacion> Entradas { get; set; }
             */
        }

    }
}
