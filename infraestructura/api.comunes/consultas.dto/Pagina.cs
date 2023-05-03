namespace api.comunes.consultas.dto;

/// <summary>
/// Representa una página de datos
/// </summary>
/// <typeparam name="T"></typeparam>
public class Pagina<T>
{

    /// <summary>
    /// Id de la consulta original, se utiliza para el cache
    /// </summary>
    public string? ConsultaId { get; set; }

    /// <summary>
    /// Lista de elementos en la página
    /// </summary>
    public List<T>? Elementos { get; set; }

    /// <summary>
    /// Total de elementos hallados por la consulta
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// Detalle del paginado 
    /// </summary>
    public Paginado Paginado { get; set; } = new();
}