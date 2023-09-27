﻿using api.comunes.modelos.modelos;
using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.Archivos.Catalogos;
using pika.servicios.gestiondocumental.dbcontext.configuraciones;


namespace pika.servicios.gestiondocumental.dbcontext;

public class DbContextGestionDocumental : DbContext
{
    public DbContextGestionDocumental(DbContextOptions<DbContextGestionDocumental> options) : base(options)
    {

    }
    public DbSet<modelo.gestiondocumental.Activo> Activo { get; set; }
    public DbSet<Archivo> Archivos { get; set; }
    public DbSet<ElementoCatalogo> TipoArchivo { get; set; }
    public DbSet<I18NCatalogo> TraduccionesTipoArchivo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfiguracionActivo());
        modelBuilder.ApplyConfiguration(new ConfiguracionCatalogoTipoArchivo());
        modelBuilder.ApplyConfiguration(new ConfiguracionI18NCatalogoTipoArchivo());

        modelBuilder.ApplyConfiguration(new ConfiguracionArchivo());
        base.OnModelCreating(modelBuilder); 
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
