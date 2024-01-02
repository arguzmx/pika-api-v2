﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pika.servicios.contenido.dbcontext;

#nullable disable

namespace pika.servicios.contenido.data.migrations
{
    [DbContext(typeof(DbContextContenido))]
    partial class DbContextContenidoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api.comunes.modelos.modelos.ElementoCatalogo", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("CatalogoId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("Discriminator")
                        .HasColumnType("int");

                    b.Property<string>("DominioId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Idioma")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("UnidadOrganizacionalId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("CatalogoId");

                    b.ToTable("cont$catalogos", (string)null);

                    b.HasDiscriminator<int>("Discriminator").HasValue(0);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("api.comunes.modelos.modelos.I18NCatalogo", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("DominioId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("UnidadOrganizacionalId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Idioma")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CatalogoId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("Discriminator")
                        .HasColumnType("int");

                    b.Property<string>("ElementoCatalogoId")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.HasKey("Id", "DominioId", "UnidadOrganizacionalId", "Idioma");

                    b.HasIndex("ElementoCatalogoId");

                    b.HasIndex("CatalogoId", "Idioma");

                    b.ToTable("cont$i18ncatalogos", (string)null);

                    b.HasDiscriminator<int>("Discriminator").HasValue(0);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("pika.modelo.contenido.Volumen", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<bool>("Activo")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("CanidadElementos")
                        .HasColumnType("bigint");

                    b.Property<long>("CanidadPartes")
                        .HasColumnType("bigint");

                    b.Property<bool>("ConfiguracionValida")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("ConsecutivoVolumen")
                        .HasColumnType("bigint");

                    b.Property<string>("DominioId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<bool>("EscrituraHabilitada")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<long>("Tamano")
                        .HasColumnType("bigint");

                    b.Property<long>("TamanoMaximo")
                        .HasColumnType("bigint");

                    b.Property<string>("TipoGestorESId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("UOrgId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("TipoGestorESId");

                    b.ToTable("cont$volumen", (string)null);
                });

            modelBuilder.Entity("pika.modelo.contenido.TipoGestorES", b =>
                {
                    b.HasBaseType("api.comunes.modelos.modelos.ElementoCatalogo");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("pika.modelo.contenido.TraduccionesTipoGestorES", b =>
                {
                    b.HasBaseType("api.comunes.modelos.modelos.I18NCatalogo");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("api.comunes.modelos.modelos.I18NCatalogo", b =>
                {
                    b.HasOne("api.comunes.modelos.modelos.ElementoCatalogo", null)
                        .WithMany("Traducciones")
                        .HasForeignKey("ElementoCatalogoId");
                });

            modelBuilder.Entity("pika.modelo.contenido.Volumen", b =>
                {
                    b.HasOne("pika.modelo.contenido.TipoGestorES", "TipoGestorES")
                        .WithMany("Volumenes")
                        .HasForeignKey("TipoGestorESId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoGestorES");
                });

            modelBuilder.Entity("api.comunes.modelos.modelos.ElementoCatalogo", b =>
                {
                    b.Navigation("Traducciones");
                });

            modelBuilder.Entity("pika.modelo.contenido.TipoGestorES", b =>
                {
                    b.Navigation("Volumenes");
                });
#pragma warning restore 612, 618
        }
    }
}
