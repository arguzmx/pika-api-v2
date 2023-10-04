﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pika.servicios.gestiondocumental.dbcontext;

#nullable disable

namespace pika.servicios.gestiondocumental.data.migrations
{
    [DbContext(typeof(DbContextGestionDocumental))]
    [Migration("20230927174938_ActivoReferencialArchivos")]
    partial class ActivoReferencialArchivos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("pika.modelo.gestiondocumental.Activo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AlmacenArchivoId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<bool>("Ampliado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ArchivoActualId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ArchivoOrigenId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Asunto")
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("CodigoElectronico")
                        .HasMaxLength(5000)
                        .HasColumnType("varchar(5000)");

                    b.Property<string>("CodigoOptico")
                        .HasMaxLength(5000)
                        .HasColumnType("varchar(5000)");

                    b.Property<bool>("Confidencial")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ContenedorAlmacenId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ContenidoId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("CuadroClasificacionId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("DominioId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<bool>("EnPrestamo")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EnTransferencia")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EsElectronico")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaApertura")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FechaCierre")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FechaRetencionAC")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FechaRetencionAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IdentificadorInterno")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<bool>("Reservado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SerieDocumentalId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<bool>("TieneContenido")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TipoArchivoActualId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("UbicacionCaja")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("UbicacionRack")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("UnidadAdministrativaId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("UnidadOrganizacionalId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ZonaAlmacenId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("ArchivoActualId");

                    b.HasIndex("ArchivoOrigenId");

                    b.ToTable("gd$activo", (string)null);
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

            modelBuilder.Entity("pika.modelo.gestiondocumental.Activo", b =>
                {
                    b.HasOne("pika.modelo.gestiondocumental.Archivo", "ArchivoActual")
                        .WithMany("ActivosActuales")
                        .HasForeignKey("ArchivoActualId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("pika.modelo.gestiondocumental.Archivo", "ArchivoOrigen")
                        .WithMany("ActivosOrigen")
                        .HasForeignKey("ArchivoOrigenId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ArchivoActual");

                    b.Navigation("ArchivoOrigen");
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

            modelBuilder.Entity("api.comunes.modelos.modelos.ElementoCatalogo", b =>
                {
                    b.Navigation("Traducciones");
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.Archivo", b =>
                {
                    b.Navigation("ActivosActuales");

                    b.Navigation("ActivosOrigen");
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.TipoArchivo", b =>
                {
                    b.Navigation("Archivos");
                });
#pragma warning restore 612, 618
        }
    }
}
