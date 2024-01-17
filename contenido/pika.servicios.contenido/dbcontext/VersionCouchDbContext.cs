using CouchDB.Driver;
using CouchDB.Driver.Options;
using pika.modelo.contenido;

namespace pika.servicios.contenido.dbcontext
{
    public class VersionCouchDbContext : CouchContext //
    {
        public VersionCouchDbContext(CouchOptions<VersionCouchDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(CouchOptionsBuilder optionsBuilder)
        {
         
        }

        public CouchDatabase<modelo.contenido.Version> Versiones { get; set; } //


        protected override void OnDatabaseCreating(CouchDatabaseBuilder databaseBuilder)
        {
            databaseBuilder.Document<modelo.contenido.Version>().ToDatabase("versiones");
        }

    }
}
