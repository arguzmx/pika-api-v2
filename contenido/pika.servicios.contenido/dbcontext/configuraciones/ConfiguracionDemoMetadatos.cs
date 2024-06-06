using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using pika.modelo.contenido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pika.modelo.contenido.demometadatos;

namespace pika.servicios.contenido.dbcontext.configuraciones
{
    public class ConfiguracionDemoMetadatos : IEntityTypeConfiguration<DemoMetadatos>
    {
        public void Configure(EntityTypeBuilder<DemoMetadatos> builder)
        {
            builder.ToTable(DbContextContenido.TablaDemoMetadatos);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Nombre).HasMaxLength(128);
            builder.Property(e => e.Experiencia); 
            builder.Property(e => e.PrecioPorHora);
            builder.Property(e => e.FechaNacimiento);
            builder.Property(e => e.HoraDeLunch);
            builder.Property(e => e.FechaCreacion);
            builder.Property(e => e.Activo);
            builder.Property(e => e.Genero);

        }
    }
}

