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
    public class ConfiguracionCuadroClasificacion : IEntityTypeConfiguration<CuadroClasificacion>
    {
        public void Configure(EntityTypeBuilder<CuadroClasificacion> builder)
        {
                builder.ToTable("gd$cuadroclasificacion");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
                builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
                builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
                builder.Property(e => e.UOrgId).IsRequired().HasMaxLength(128);
           
        }
    }
}
