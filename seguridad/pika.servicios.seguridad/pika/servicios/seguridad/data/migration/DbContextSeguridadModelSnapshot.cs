﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pika.servicios.seguridad.dbcontext;

#nullable disable

namespace pika.servicios.seguridad.pika.servicios.seguridad.data.migration
{
    [DbContext(typeof(DbContextSeguridad))]
    partial class DbContextSeguridadModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("pika.modelo.seguridad.Aplicacion", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

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

            modelBuilder.Entity("pika.modelo.seguridad.Modulo", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("AplicacionId")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

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

            modelBuilder.Entity("pika.modelo.seguridad.Permiso", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("Ambito")
                        .HasColumnType("int");

                    b.Property<string>("AplicacionId")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ModuloId")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("AplicacionId");

                    b.HasIndex("ModuloId");

                    b.ToTable("seg$permiso", (string)null);
                });

            modelBuilder.Entity("pika.modelo.seguridad.Rol", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("AplicacionId")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ModuloId")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

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

            modelBuilder.Entity("pika.modelo.seguridad.Modulo", b =>
                {
                    b.HasOne("pika.modelo.seguridad.Aplicacion", "Aplicacion")
                        .WithMany("Modulos")
                        .HasForeignKey("AplicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aplicacion");
                });

            modelBuilder.Entity("pika.modelo.seguridad.Permiso", b =>
                {
                    b.HasOne("pika.modelo.seguridad.Aplicacion", "Aplicacion")
                        .WithMany("Permisos")
                        .HasForeignKey("AplicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pika.modelo.seguridad.Modulo", "Modulo")
                        .WithMany("Permisos")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aplicacion");

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("pika.modelo.seguridad.Rol", b =>
                {
                    b.HasOne("pika.modelo.seguridad.Aplicacion", "Aplicacion")
                        .WithMany("Roles")
                        .HasForeignKey("AplicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pika.modelo.seguridad.Modulo", "Modulo")
                        .WithMany("RolesPredefinidos")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aplicacion");

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("pika.modelo.seguridad.Aplicacion", b =>
                {
                    b.Navigation("Modulos");

                    b.Navigation("Permisos");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("pika.modelo.seguridad.Modulo", b =>
                {
                    b.Navigation("Permisos");

                    b.Navigation("RolesPredefinidos");
                });
#pragma warning restore 612, 618
        }
    }
}
