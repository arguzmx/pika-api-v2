using api.comunes.modelos.modelos;
using Microsoft.EntityFrameworkCore;
using pika.modelo.organizacion;
using pika.servicios.organizacion.dbcontext.configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.organizacion.dbcontext
{
    public class DbContextOrganizacion : DbContext
    {
        public DbContextOrganizacion(DbContextOptions<DbContextOrganizacion> options) : base(options) 
        {
            
        }

        public DbSet<Dominio> Dominios { get; set; }

        public DbSet<UnidadOrganizacional> UnidadesOrganizacionales { get; set; }

        public DbSet<UsuarioDominio> UsuarioDominios { get; set; }

        public DbSet<UsuarioUnidadOrganizacional> UsuariosUnidadesOrganizacionales { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfiguracionDominio());
            modelBuilder.ApplyConfiguration(new ConfiguracionUnidadOrganizacional());
            modelBuilder.ApplyConfiguration(new ConfiguracionUsuarioDominio());
            modelBuilder.ApplyConfiguration(new ConfiguracionUsuarioUnidadOrganizacional());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
