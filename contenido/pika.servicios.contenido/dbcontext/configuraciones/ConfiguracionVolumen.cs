using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pika.modelo.contenido.Repositorio;
using pika.modelo.contenido.Volumen;

namespace pika.servicios.contenido.dbcontext.configuraciones;

public class ConfiguracionVolumen:IEntityTypeConfiguration<Volumen>
{
    public void Configure(EntityTypeBuilder<Volumen> builder)
    {
        builder.ToTable("contenido$volumen");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
        builder.Property(e => e.DominioId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.UOrgId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Nombre).IsRequired().HasMaxLength(500);
        builder.Property(e => e.TipoGestorESId).IsRequired().HasMaxLength(128);
        builder.Property(e => e.TamanoMaximo).IsRequired();
        builder.Property(e => e.Activo).IsRequired();
        builder.Property(e => e.Nombre).IsRequired().HasMaxLength(128);
        builder.Property(e => e.EscrituraHabilitada).IsRequired();
        builder.Property(e => e.ConsecutivoVolumen).IsRequired();
        builder.Property(e => e.CanidadPartes).IsRequired();
        builder.Property(e => e.CanidadElementos).IsRequired();
        builder.Property(e => e.Tamano).IsRequired();
        builder.Property(e => e.ConfiguracionValida).IsRequired();
    }
}