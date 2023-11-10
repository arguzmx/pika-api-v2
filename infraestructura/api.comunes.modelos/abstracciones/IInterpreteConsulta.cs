using api.comunes.metadatos;
using api.comunes.modelos.modelos;

namespace api.comunes.modelos.abstracciones;

/// <summary>
/// Interfaz para la  implementación del interprete de consultas de entidad genérica
/// </summary>
public interface IInterpreteConsulta
{

    /// <summary>
    /// Genera una consulta para el repositorio de datos especifico
    /// </summary>
    /// <param name="consulta">Consulta de entidad</param>
    /// <param name="entidad">Entidad y propiedades</param>
    /// <param name="coleccion">Nombre de la tabla o coleccion</param>
    /// <returns></returns>
    string CrearConsulta(Consulta consulta, Entidad entidad, string coleccion);
}
