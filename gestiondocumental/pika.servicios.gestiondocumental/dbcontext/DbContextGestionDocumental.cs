﻿using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext.configuraciones;


namespace pika.servicios.gestiondocumental.dbcontext;

public class DbContextGestionDocumental : DbContext
{
    public DbContextGestionDocumental(DbContextOptions<DbContextGestionDocumental> options) : base(options)
    {

    }

    public DbSet<Archivo> Archivos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfiguracionArchivo());
        base.OnModelCreating(modelBuilder); 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        base.OnConfiguring(optionsBuilder);
    }
}
