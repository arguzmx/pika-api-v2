﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pika.servicios.gestiondocumental.dbcontext;

#nullable disable

namespace pika.servicios.gestiondocumental.data.migrations
{
    [DbContext(typeof(DbContextGestionDocumental))]
    partial class DbContextGestionDocumentalModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api.comunes.modelos.modelos.ElementoCatalogo", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Catalogo")
                        .IsRequired()
                        .HasColumnType("longtext");

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

                    b.ToTable("gd$catalogos", (string)null);

                    b.HasDiscriminator<string>("Catalogo").HasValue("ElementoCatalogo");
                });

            modelBuilder.Entity("api.comunes.modelos.modelos.I18NCatalogo", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Idioma")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("DominioId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("UnidadOrganizacionalId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Catalogo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ElementoCatalogoId")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.HasKey("Id", "Idioma", "DominioId", "UnidadOrganizacionalId");

                    b.HasIndex("ElementoCatalogoId");

                    b.ToTable("gd$i18ncatalogos", (string)null);

                    b.HasDiscriminator<string>("Catalogo").HasValue("I18NCatalogo");
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.Archivo", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("DominioId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("TipoArchivoId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("UOrgId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("TipoArchivoId");

                    b.ToTable("gd$archivo", (string)null);
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.UnidadAdministrativa", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ArchivoConcentracionId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ArchivoHistoricoId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ArchivoTramiteId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Cargo")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Domicilio")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("DominioId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Responsable")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UOrgId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.ToTable("gd$cuadroclasificacion", (string)null);

                    b.Property<string>("UbicacionFisica")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("ArchivoConcentracionId");

                    b.HasIndex("ArchivoHistoricoId");

                    b.HasIndex("ArchivoTramiteId");

                    b.ToTable("gd$unidadadministrativa", (string)null);
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.Archivos.Catalogos.TraduccionesTipoArchivo", b =>
                {
                    b.HasBaseType("api.comunes.modelos.modelos.I18NCatalogo");

                    b.HasDiscriminator().HasValue("TipoArchivo");
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.TipoArchivo", b =>
                {
                    b.HasBaseType("api.comunes.modelos.modelos.ElementoCatalogo");

                    b.HasDiscriminator().HasValue("TipoArchivo");
                });

            modelBuilder.Entity("api.comunes.modelos.modelos.I18NCatalogo", b =>
                {
                    b.HasOne("api.comunes.modelos.modelos.ElementoCatalogo", null)
                        .WithMany("Traducciones")
                        .HasForeignKey("ElementoCatalogoId");
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.Archivo", b =>
                {
                    b.HasOne("pika.modelo.gestiondocumental.TipoArchivo", "TipoArchivo")
                        .WithMany("Archivos")
                        .HasForeignKey("TipoArchivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoArchivo");
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.UnidadAdministrativa", b =>
                {
                    b.HasOne("pika.modelo.gestiondocumental.Archivo", "ArchivoConcentracion")
                        .WithMany("UnidadesAdministrativasConcentracion")
                        .HasForeignKey("ArchivoConcentracionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("pika.modelo.gestiondocumental.Archivo", "ArchivoHistorico")
                        .WithMany("UnidadesAdministrativasHistorico")
                        .HasForeignKey("ArchivoHistoricoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("pika.modelo.gestiondocumental.Archivo", "ArchivoTramite")
                        .WithMany("UnidadesAdministrativasTramite")
                        .HasForeignKey("ArchivoTramiteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ArchivoConcentracion");

                    b.Navigation("ArchivoHistorico");

                    b.Navigation("ArchivoTramite");
                });

            modelBuilder.Entity("api.comunes.modelos.modelos.ElementoCatalogo", b =>
                {
                    b.Navigation("Traducciones");
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.Archivo", b =>
                {
                    b.Navigation("UnidadesAdministrativasConcentracion");

                    b.Navigation("UnidadesAdministrativasHistorico");

                    b.Navigation("UnidadesAdministrativasTramite");
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.TipoArchivo", b =>
                {
                    b.Navigation("Archivos");
                });
#pragma warning restore 612, 618
        }
    }
}
