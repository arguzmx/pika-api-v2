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
    public class ConfiguracionArchivo : IEntityTypeConfiguration<Archivo>
    {
        public void Configure(EntityTypeBuilder<Archivo> builder)
        {

            builder.ToTable("archivo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.Eliminada).IsRequired();
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
            builder.Property(e => e.TipoOrigenId).IsRequired();
            builder.Property(e => e.OrigenId).IsRequired();
            builder.Property(e => e.TipoArchivoId).IsRequired();
            builder.Property(e => e.VolumenDefaultId).IsRequired();
            builder.Property(e => e.PuntoMontajeId).IsRequired();
          
       /*
        //
        public string TipoArchivoId { get; set; }
        public virtual ICollection<AlmacenArchivo> Almacenes { get; set; }
        public virtual ICollection<HistorialArchivoActivo> HistorialArchivosActivo { get; set; }
        public virtual ICollection<Activo> Activos { get; set; }
        public virtual ICollection<Activo> ActivosOrigen { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
        public virtual ICollection<AlmacenArchivo> Almacenes { get; set; }
        public virtual ICollection<Transferencia> TransferenciasOrigen { get; set; }
        public virtual ICollection<Transferencia> TransferenciasDestino { get; set; }
        public List<IProveedorReporte> Reportes { get; set; }
        public List<UnidadAdministrativaArchivo> UnidadesTramite { get; set; }
        public List<UnidadAdministrativaArchivo> UnidadesConcentracion { get; set; }
        public List<UnidadAdministrativaArchivo> UnidadesHistorico { get; set; }
        public List<EstadisticaClasificacionAcervo> EstadisticasClasificacionAcervo { get; set; }
        public List<ZonaAlmacen> ZonasAlmacen { get; set; }
        public List<PosicionAlmacen> PosicionesAlmacen { get; set; }
        public List<ContenedorAlmacen> Contenedores { get; set; }
        public List<PermisosArchivo> PermisosArchivo { get; set; }
       */
        }
    }
}
