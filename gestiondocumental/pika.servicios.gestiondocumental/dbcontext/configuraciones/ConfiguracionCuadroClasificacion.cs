using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.gestiondocumental;


namespace pika.servicios.gestiondocumental.dbcontext.configuraciones
{
    public class ConfiguracionCuadroClasificacion : IEntityTypeConfiguration<CuadroClasificacion>
    {
        public void Configure(EntityTypeBuilder<CuadroClasificacion> builder)
        {
            builder.ToTable("cuadroclasificacion");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.EstadoCuadroClasificacionId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Eliminada).IsRequired();
            builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.UnidadOrganizacionalId).IsRequired().HasMaxLength(128);

        }
    }
}

    
    


       

    
