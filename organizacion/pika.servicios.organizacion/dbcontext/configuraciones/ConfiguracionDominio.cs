using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.organizacion;




namespace pika.servicios.organizacion.dbcontext.configuraciones
{
    public class ConfiguracionDominio : IEntityTypeConfiguration<Dominio>
    {
        public void Configure(EntityTypeBuilder<Dominio> builder)
        {
            builder.ToTable("org$dominio");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired(true).HasMaxLength(500);
            builder.Property(e => e.Activo).IsRequired(true);
          //  builder.HasMany(x => x.UsuarioDominio).WithOne(y => y.Dominios).HasForeignKey(z => z.Id).OnDelete(DeleteBehavior.Cascade);
          //  builder.HasMany(x => x.UnidadesOrganizacionales).WithOne(y => y.Dominio).HasForeignKey(z => z.).OnDelete(DeleteBehavior.Cascade);
        }
    }
}