namespace api.comunes.consultas.dto;

/// <summary>
/// Constla básica para los endpoints
/// </summary>
public class Consulta
{
    /// <summary>
    /// Identificador único de la consulta generado por el backend
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Datos del paginado para la consulta
    /// </summary>
    public Paginado Paginado { get; set; }

    /// <summary>
    /// Determina si el cache de datos debe ser anulado para la consulta
    /// </summary>
    public bool AnularCache { get; set; }

    /// <summary>
    /// Filtros utilizados para los datos
    /// </summary>
    public List<Filtro>? Filtros { get; set; }

}
