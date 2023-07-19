using Microsoft.EntityFrameworkCore;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.dbcontext
{
    public class bdcontext : DbContext
    {
        public DbSet<Activo> Activos { get; set; }

        private string DbPath;

        public bdcontext()
        {
            DbPath = "ds.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }


    }
}
