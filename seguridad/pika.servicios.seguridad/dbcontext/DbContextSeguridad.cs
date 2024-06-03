using api.comunes.modelos.modelos;
using Microsoft.EntityFrameworkCore;
using pika.modelo.seguridad;
using pika.servicios.seguridad.dbcontext.configuraciones;


namespace pika.servicios.seguridad.dbcontext
{
    public class DbContextSeguridad : DbContext
    {

        public const string TablaAplicacion = "seg$aplicacion";
        public const string TablaModulos = "seg$modulo";
        public const string TablaPermisos = "seg$permiso";
        public const string TablaRoles = "seg$rol";

        public DbContextSeguridad(DbContextOptions<DbContextSeguridad> options) : base(options)
        {

        }

        public DbSet<Aplicacion> Aplicaciones { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfiguracionAplicacion());
            modelBuilder.ApplyConfiguration(new ConfiguracionModulo());
            modelBuilder.ApplyConfiguration(new ConfiguracionPermiso());
            modelBuilder.ApplyConfiguration(new ConfiguracionRol());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

      }
    }