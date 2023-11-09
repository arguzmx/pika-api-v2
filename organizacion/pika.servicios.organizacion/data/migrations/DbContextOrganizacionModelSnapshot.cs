﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pika.servicios.organizacion.dbcontext;

#nullable disable

namespace pika.servicios.organizacion.data.migrations
{
    [DbContext(typeof(DbContextOrganizacion))]
    partial class DbContextOrganizacionModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("pika.modelo.organizacion.Dominio", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<bool>("Activo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("org$dominio", (string)null);
                });

            modelBuilder.Entity("pika.modelo.organizacion.UnidadOrganizacional", b =>
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
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("DominioId");

                    b.ToTable("org$unidadorganizacional", (string)null);
                });

            modelBuilder.Entity("pika.modelo.organizacion.UsuarioDominio", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("DominioId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("DominioId");

                    b.ToTable("org$usuariodominio", (string)null);
                });

            modelBuilder.Entity("pika.modelo.organizacion.UsuarioUnidadOrganizacional", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("DominioId")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("UnidadOrganizacionalId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("DominioId");

                    b.HasIndex("UnidadOrganizacionalId");

                    b.ToTable("org$usuariounidadorganizacional", (string)null);
                });

            modelBuilder.Entity("pika.modelo.organizacion.UnidadOrganizacional", b =>
                {
                    b.HasOne("pika.modelo.organizacion.Dominio", "Dominio")
                        .WithMany("UnidadesOrganizacionales")
                        .HasForeignKey("DominioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dominio");
                });

            modelBuilder.Entity("pika.modelo.organizacion.UsuarioDominio", b =>
                {
                    b.HasOne("pika.modelo.organizacion.Dominio", "Dominios")
                        .WithMany("UsuarioDominio")
                        .HasForeignKey("DominioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dominios");
                });

            modelBuilder.Entity("pika.modelo.organizacion.UsuarioUnidadOrganizacional", b =>
                {
                    b.HasOne("pika.modelo.organizacion.Dominio", "Dominio")
                        .WithMany("UsuarioUnidadOrganizacionals")
                        .HasForeignKey("DominioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("pika.modelo.organizacion.UnidadOrganizacional", "UnidadOrganizacional")
                        .WithMany("UsuariosUnidad")
                        .HasForeignKey("UnidadOrganizacionalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dominio");

                    b.Navigation("UnidadOrganizacional");
                });

            modelBuilder.Entity("pika.modelo.organizacion.Dominio", b =>
                {
                    b.Navigation("UnidadesOrganizacionales");

                    b.Navigation("UsuarioDominio");

                    b.Navigation("UsuarioUnidadOrganizacionals");
                });

            modelBuilder.Entity("pika.modelo.organizacion.UnidadOrganizacional", b =>
                {
                    b.Navigation("UsuariosUnidad");
                });
#pragma warning restore 612, 618
        }
    }
}
