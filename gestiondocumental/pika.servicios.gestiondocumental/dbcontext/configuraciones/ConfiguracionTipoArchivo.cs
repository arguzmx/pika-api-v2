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
   
    public class ConfiguracionTipoArchivo : IEntityTypeConfiguration<TipoArchivo>
    {
        public void Configure(EntityTypeBuilder<TipoArchivo> builder)
        {

            builder.ToTable("tipoarchivo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).IsRequired();
            builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.UOId).IsRequired().HasMaxLength(128);
            /*
        public ArchivoTipo? Tipo { get; set; }
        public  List<TipoArchivo> Seed()
        {
            List<TipoArchivo> l = new List<TipoArchivo>();
            // l.Add(new TipoArchivo() { Id = IDARCHIVO_CORRESPONDENCIA, Nombre = "Correspondencoia"});
            l.Add(new TipoArchivo() { Id = IDARCHIVO_TRAMITE, Nombre = "Trámite", Tipo = ArchivoTipo.tramite });
            l.Add(new TipoArchivo() { Id = IDARCHIVO_HISTORICO  , Nombre = "Histórico", Tipo = ArchivoTipo.historico});
            l.Add(new TipoArchivo() { Id = IDARCHIVO_CONCENTRACION , Nombre = "Concentración", Tipo = ArchivoTipo.concentracion });
            return l;
        }
        public IEnumerable<Archivo> Archivos { get; set; }
        public IEnumerable<Activo> Activos { get; set; }
             */
        }
    }
}
