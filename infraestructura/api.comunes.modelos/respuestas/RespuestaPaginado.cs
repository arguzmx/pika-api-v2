namespace api.comunes.modelos.respuestas;

/// <summary>
/// REspuesta a una solicitud de paginado
/// </summary>
/// <typeparam name="T">Tipo de entidad paginada</typeparam>
public class RespuestaPaginado<T> where T : class
{
    /// <summary>
    /// CNS 
    /// </summary>
    /// <param name="solicitud"></param>
    public RespuestaPaginado(SolicitudPaginado solicitud)
    {
        Solicitud = solicitud;
        Elementos = new List<T>();
    }

    /// <summary>
    /// Milisegundos transcurridos
    /// </summary>
    public long Milisegundos { get; set; }

    /// <summary>
    /// Arreglo de los elemento encontrados para la página
    /// </summary>
    public List<T> Elementos { get; set; }

    /// <summary>
    /// Total de elementos encontrados
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// DAtos de la solicitud
    /// </summary>
    public SolicitudPaginado Solicitud { get; set; }

}
