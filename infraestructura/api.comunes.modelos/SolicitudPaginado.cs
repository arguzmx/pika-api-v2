namespace api.comunes.modelos;

/// <summary>
/// Solicitu de paginado al backend
/// </summary>
public class SolicitudPaginado
{
    /// <summary>
    /// Identificador único de la consulta generado en el frontend utilizad para tracing y caché
    /// </summary>
    public string? ConsultaId { get; set; }
    
    /// <summary>
    /// Método de ordenamiento de los resultados
    /// </summary>
    public Ordenamiento? Ordenamiento { get; set; }

    /// <summary>
    /// Propiedad de ordenamiento de los resultados
    /// </summary>
    public string? PropiedadOrdenamiento { get; set; }
    
    /// <summary>
    /// INdice de la página solictada base 0
    /// </summary>
    public int Pagina { get; set; } =0;
    
    /// <summary>
    /// Tamaño de la página
    /// </summary>
    public int Tamano { get; set; } = 10;
    
    /// <summary>
    /// Especifica se se desea hacer el conteo del total de resultados existentes
    /// </summary>
    public bool Contar { get; set; } = true;
    
    /// <summary>
    /// Especifica si se debe eliminar el caché existente para la consulta
    /// </summary>
    public bool EliminarCache { get; set; } = false;
}
