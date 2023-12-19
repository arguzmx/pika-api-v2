using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.gestiondocumental.Topologia;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones
{
    public class ConfiguracionAlmacenArchivo : IEntityTypeConfiguration<AlmacenArchivo>
    {
        public void Configure(EntityTypeBuilder<AlmacenArchivo> builder)
        {
            builder.ToTable(DbContextGestionDocumental.TablaAlmacenArchivo);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.Clave).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Ubicacion).IsRequired().HasMaxLength(500);

            builder.HasOne(x => x.Archivo).WithMany(y => y.Almacenes).HasForeignKey(z => z.ArchivoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
