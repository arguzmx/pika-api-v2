using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mysql.comunes;

public class RepositorioGenerico<TEntidad, TId> : IRepositorioGenerico<TEntidad, TId> where TEntidad : class
{
    private readonly DbContext db;
    internal DbSet<TEntidad> dbSet;

    public RepositorioGenerico(DbContext context)
    {
        this.db = context;
        this.dbSet = context.Set<TEntidad>();
    }

    public async Task<TEntidad?> UnicPorId(TId id)
    {
        return await dbSet.FindAsync(id);
    }


}
