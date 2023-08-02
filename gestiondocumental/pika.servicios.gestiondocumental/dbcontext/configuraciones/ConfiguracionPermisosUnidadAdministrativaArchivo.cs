using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.dbcontext.configuraciones;
public class ConfiguracionPermisosUnidadAdministrativaArchivo : IEntityTypeConfiguration<PermisosUnidadAdministrativaArchivo>
    {
        public void Configure(EntityTypeBuilder<PermisosUnidadAdministrativaArchivo> builder)
        {
            builder.ToTable("permisosunidadadministrativaarchivo");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ArchivoId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.DestinatarioId).IsRequired().HasMaxLength(128);
            builder.Property(e => e.LeerAcervo).IsRequired();
            builder.Property(e => e.CrearAcervo).IsRequired();
            builder.Property(e => e.ActualizarAcervo).IsRequired();
            builder.Property(e => e.ElminarAcervo).IsRequired();
            builder.Property(e => e.CrearTrasnferencia).IsRequired();
            builder.Property(e => e.EliminarTrasnferencia).IsRequired();
            builder.Property(e => e.EnviarTrasnferencia).IsRequired();
            builder.Property(e => e.CancelarTrasnferencia).IsRequired();
            builder.Property(e => e.RecibirTrasnferencia).IsRequired();
        }
    }

