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
    
    public class ConfiguracionUnidadAdministrativaArchivo : IEntityTypeConfiguration<UnidadAdministrativaArchivo>
    {
        public void Configure(EntityTypeBuilder<UnidadAdministrativaArchivo> builder)
        {

            builder.ToTable("unidadadministrativaarchivo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.UnidadAdministrativa).IsRequired();
            builder.Property(e => e.AreaProcedenciaArchivo).IsRequired();
            builder.Property(e => e.Responsable).IsRequired();
            builder.Property(e => e.Cargo).IsRequired();
            builder.Property(e => e.Telefono).IsRequired();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Domicilio).IsRequired();
            builder.Property(e => e.UbicacionFisica).IsRequired();
            builder.Property(e => e.ArchivoTramiteId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ArchivoConcentracionId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ArchivoHistoricoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.TipoOrigenId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.OrigenId).IsRequired().HasMaxLength(128);
     
             /*  
             public string OrigenId { get; set; }
             public Archivo ArchivoTramite { get; set; }
             public Archivo ArchivoConcentracion { get; set; }
             public Archivo ArchivoHistorico { get; set; }
             public ICollection<Activo> Activos { get; set; }
             public ICollection<PermisosUnidadAdministrativaArchivo> Permisos { get; set; }
             public List<EstadisticaClasificacionAcervo> EstadisticasClasificacionAcervo { get; set; }
             */
        }
    }
}
