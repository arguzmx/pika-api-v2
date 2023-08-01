using RepoDb.Interfaces;

namespace mysql.comunes;

public class CacheFactory
{
    private static object _syncLock = new object();
    private static ICache _cache = null;

    public static ICache CreateCache()
    {
        if (_cache == null)
        {
            lock (_syncLock)
            {
                if (_cache == null)
                {
                    _cache = new RepoDbCache();
                }
            }
        }
        return _cache;
    }
}
