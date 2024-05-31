﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pika.servicios.seguridad.dbcontext;

#nullable disable

namespace pika.servicios.seguridad.data.migrations
{
    [DbContext(typeof(DbContextSeguridad))]
    [Migration("20240530210405_creaciondelosModelosdeSeguridad")]
    partial class creaciondelosModelosdeSeguridad
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("pika.seguridad.modelo.Aplicacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("char(128)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("seg$aplicacion", (string)null);
                });

            modelBuilder.Entity("pika.seguridad.modelo.Modulo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("char(128)");

                    b.Property<Guid>("AplicacionId")
                        .HasColumnType("char(128)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("AplicacionId");

                    b.ToTable("seg$modulo", (string)null);
                });

            modelBuilder.Entity("pika.seguridad.modelo.Permiso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("char(128)");

                    b.Property<int>("Ambito")
                        .HasColumnType("int");

                    b.Property<Guid>("AplicacionId")
                        .HasColumnType("char(128)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("ModuloId")
                        .HasColumnType("char(128)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("AplicacionId");

                    b.HasIndex("ModuloId");

                    b.ToTable("seg$permiso", (string)null);
                });

            modelBuilder.Entity("pika.seguridad.modelo.Rol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("char(128)");

                    b.Property<Guid>("AplicacionId")
                        .HasColumnType("char(128)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("ModuloId")
                        .HasColumnType("char(128)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Permisos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Personalizado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("AplicacionId");

                    b.HasIndex("ModuloId");

                    b.ToTable("seg$rol", (string)null);
                });

            modelBuilder.Entity("pika.seguridad.modelo.Modulo", b =>
                {
                    b.HasOne("pika.seguridad.modelo.Aplicacion", "Aplicacion")
                        .WithMany("Modulos")
                        .HasForeignKey("AplicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aplicacion");
                });

            modelBuilder.Entity("pika.seguridad.modelo.Permiso", b =>
                {
                    b.HasOne("pika.seguridad.modelo.Aplicacion", "Aplicacion")
                        .WithMany("Permisos")
                        .HasForeignKey("AplicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pika.seguridad.modelo.Modulo", "Modulo")
                        .WithMany("Permisos")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aplicacion");

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("pika.seguridad.modelo.Rol", b =>
                {
                    b.HasOne("pika.seguridad.modelo.Aplicacion", "Aplicacion")
                        .WithMany("Roles")
                        .HasForeignKey("AplicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pika.seguridad.modelo.Modulo", "Modulo")
                        .WithMany("RolesPredefinidos")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aplicacion");

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("pika.seguridad.modelo.Aplicacion", b =>
                {
                    b.Navigation("Modulos");

                    b.Navigation("Permisos");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("pika.seguridad.modelo.Modulo", b =>
                {
                    b.Navigation("Permisos");

                    b.Navigation("RolesPredefinidos");
                });
#pragma warning restore 612, 618
        }
    }
}
