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
    [Migration("20231207215117_seriedocumental")]
    partial class seriedocumental
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("gd$catalogos", (string)null);

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

                    b.ToTable("gd$i18ncatalogos", (string)null);

                    b.HasDiscriminator<int>("Discriminator").HasValue(0);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.Activo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AlmacenArchivoId")
                        .HasColumnType("longtext");

                    b.Property<bool>("Ampliado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ArchivoActualId")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ArchivoOrigenId")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Asunto")
                        .HasColumnType("longtext");

                    b.Property<string>("CodigoElectronico")
                        .HasColumnType("longtext");

                    b.Property<string>("CodigoOptico")
                        .HasColumnType("longtext");

                    b.Property<bool>("Confidencial")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ContenedorAlmacenId")
                        .HasColumnType("longtext");

                    b.Property<string>("ContenidoId")
                        .HasColumnType("longtext");

                    b.Property<string>("CuadroClasificacionId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DominioId")
                        .IsRequired()
                        .HasColumnType("longtext");

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
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Reservado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SerieDocumentalId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("TieneContenido")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TipoArchivoActualId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UbicacionCaja")
                        .HasColumnType("longtext");

                    b.Property<string>("UbicacionRack")
                        .HasColumnType("longtext");

                    b.Property<string>("UnidadAdministrativaId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UnidadOrganizacionalId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ZonaAlmacenId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ArchivoActualId");

                    b.HasIndex("ArchivoOrigenId");

                    b.HasIndex("CuadroClasificacionId");

                    b.ToTable("Activo");
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

            modelBuilder.Entity("pika.modelo.gestiondocumental.CuadroClasificacion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DominioId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UOrgId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CuadroClasificacion");
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.SerieDocumental.SerieDocumental", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CuadroClasificacionId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("MesesArchivoConcentracion")
                        .HasColumnType("int");

                    b.Property<int>("MesesArchivoHistorico")
                        .HasColumnType("int");

                    b.Property<int>("MesesArchivoTramite")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("Raiz")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SeriePadreId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("CuadroClasificacionId");

                    b.HasIndex("SeriePadreId");

                    b.ToTable("gd$seriedocumental", (string)null);
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.TipoArchivo", b =>
                {
                    b.HasBaseType("api.comunes.modelos.modelos.ElementoCatalogo");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.TipoDisposicionDocumental", b =>
                {
                    b.HasBaseType("api.comunes.modelos.modelos.ElementoCatalogo");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.TipoValoracionDocumental", b =>
                {
                    b.HasBaseType("api.comunes.modelos.modelos.ElementoCatalogo");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.Archivos.Catalogos.TraduccionesTipoArchivo", b =>
                {
                    b.HasBaseType("api.comunes.modelos.modelos.I18NCatalogo");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.SerieDocumental.TraduccionesCatalogos.TraduccionesTipoDisposicionDocumental", b =>
                {
                    b.HasBaseType("api.comunes.modelos.modelos.I18NCatalogo");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.SerieDocumental.TraduccionesCatalogos.TraduccionesTipoValoracionDocumental", b =>
                {
                    b.HasBaseType("api.comunes.modelos.modelos.I18NCatalogo");

                    b.HasDiscriminator().HasValue(3);
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
                        .WithMany()
                        .HasForeignKey("ArchivoActualId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pika.modelo.gestiondocumental.Archivo", "ArchivoOrigen")
                        .WithMany()
                        .HasForeignKey("ArchivoOrigenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pika.modelo.gestiondocumental.CuadroClasificacion", "CuadroClasificacion")
                        .WithMany("Activos")
                        .HasForeignKey("CuadroClasificacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArchivoActual");

                    b.Navigation("ArchivoOrigen");

                    b.Navigation("CuadroClasificacion");
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

            modelBuilder.Entity("pika.modelo.gestiondocumental.SerieDocumental.SerieDocumental", b =>
                {
                    b.HasOne("pika.modelo.gestiondocumental.CuadroClasificacion", "CuadroClasificacion")
                        .WithMany("Series")
                        .HasForeignKey("CuadroClasificacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("pika.modelo.gestiondocumental.SerieDocumental.SerieDocumental", "SeriePadre")
                        .WithMany("Subseries")
                        .HasForeignKey("SeriePadreId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CuadroClasificacion");

                    b.Navigation("SeriePadre");
                });

            modelBuilder.Entity("api.comunes.modelos.modelos.ElementoCatalogo", b =>
                {
                    b.Navigation("Traducciones");
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.CuadroClasificacion", b =>
                {
                    b.Navigation("Activos");

                    b.Navigation("Series");
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.SerieDocumental.SerieDocumental", b =>
                {
                    b.Navigation("Subseries");
                });

            modelBuilder.Entity("pika.modelo.gestiondocumental.TipoArchivo", b =>
                {
                    b.Navigation("Archivos");
                });
#pragma warning restore 612, 618
        }
    }
}
