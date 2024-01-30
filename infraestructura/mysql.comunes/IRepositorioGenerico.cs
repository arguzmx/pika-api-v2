using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mysql.comunes;

/// <summary>
/// Define un repositorio generico 
/// </summary>
/// <typeparam name="TEntidad">Tipo de entidad a almacenar en el repositorii</typeparam>
/// <typeparam name="TId">Tipo del identificador único de la entidad</typeparam>
public interface IRepositorioGenerico<TEntidad, TId>
{
    /// <summary>
    /// OBtine una entidad en base a su identificador único
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntidad?> UnicPorId(TId id);
}
