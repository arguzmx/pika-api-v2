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
    [DbContext(typeof(PIKADbContext))]
    [Migration("20230720014942_InicialContenido")]
    partial class InicialContenido
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("pika.modelo.gestiondocumental.Activo", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

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
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("CodigoElectronico")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CodigoOptico")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("Confidencial")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ContenedorAlmacenId")
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

                    b.Property<string>("ElementoId")
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

                    b.Property<string>("IDunico")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

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

                    b.Property<string>("UnidadAdministrativaArchivoId")
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

                    b.Property<int?>("Vencidos")
                        .HasColumnType("int");

                    b.Property<string>("ZonaAlmacenId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.ToTable("activo", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
