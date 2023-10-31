using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace pika.servicios.organizacion.dbcontext.configuraciones
{
    public class ConfiguracionDominio : IEntityTypeConfiguration<Dominio>
    {
        public void Configure(EntityTypeBuilder<Dominio> builder)
        {
            UnidadOrganizacional n = new UnidadOrganizacional();   

            builder.ToTable("org$dominio");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired(true).HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired(true).HasMaxLength(500);
            builder.Property(e => e.Activo).IsRequired(true);


           // builder.HasOne(x => x.UsuarioDominio).WithMany(y => y.).HasForeignKey(z=>z.).OnDelete(DeleteBehavior.Cascade);
           // builder.HasOne(x => x.UnidadesOrganizacionales).WithMany(y => y.).HasForeignKey(z => z).OnDelete(DeleteBehavior.Cascade);

            /*
            [XmlIgnore]
            [JsonIgnore]
            public List<UsuarioDominio> UsuariosDominio { get; set; }
            builder.HasOne(x => x.ModeloForaneo).WithMany(y => y.PropiedadNavegacionForaneaAPrimaria).HasForeignKey(z => z.Llaveprimariasecundaria).OnDelete(DeleteBehavior.Cascade);
            [XmlIgnore]
            [JsonIgnore]
            public List<UnidadOrganizacional> UnidadesOrganizacionales { get; set; }
                     */
        }
    }
}
