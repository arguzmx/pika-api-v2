using Microsoft.Extensions.Options;
using RepoDb;
using RepoDb.Interfaces;
using System.Data.Common;
using System.Linq;

namespace mysql.comunes;

public class RepositorioBase<TDbConnection> : IRepositorioBase<TDbConnection>
    where TDbConnection : DbConnection
{
    private IOptions<MySqlConfig> _settings;
    public ITrace Trace { get; }
    public ICache Cache { get; }

    public RepositorioBase(IOptions<MySqlConfig> settings, ICache cache, ITrace trace)
    {
        _settings = settings;
        Cache = cache;
        Trace = trace;
    }


    public TDbConnection CreateConnection()
    {
        var connection = Activator.CreateInstance<TDbConnection>();
        connection.ConnectionString = _settings.Value.ConnectionString;
        return connection;
    }



    public async Task<TEntity?> Get<TEntity>(object id)  where TEntity : class
    {
        using (var connection = CreateConnection())
        {
     
            var a = await connection.QueryAsync<TEntity?>(id);
            return a.FirstOrDefault();
        }
    }
}
