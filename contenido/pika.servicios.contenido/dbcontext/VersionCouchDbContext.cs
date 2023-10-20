using CouchDB.Driver;
using CouchDB.Driver.Options;

namespace pika.servicios.contenido.dbcontext;

public class VersionCouchDbContext : CouchContext
{

    public VersionCouchDbContext(CouchOptions<VersionCouchDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(CouchOptionsBuilder optionsBuilder)
    {

    }

    public CouchDatabase<modelo.contenido.Version.Version> Versiones { get; set; }


    protected override void OnDatabaseCreating(CouchDatabaseBuilder databaseBuilder)
    {
        databaseBuilder.Document<modelo.contenido.Version.Version>().ToDatabase("versiones");

    }


}
