using System.Data.Common;

namespace mysql.comunes;

public interface IRepositorioBase<TDbConnection>
    where TDbConnection : DbConnection
{
    TDbConnection CreateConnection();

    Task<TEntity?> Get<TEntity>(object id) where TEntity : class;
}
