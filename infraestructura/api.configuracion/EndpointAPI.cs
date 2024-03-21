namespace api.configuracion;

/// <summary>
/// DEfine un endpoint de API
/// </summary>
public class EndpointAPI
{
    /// <summary>
    /// Identificador único del endpoint
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Url del servicio
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// Determina si la autenticación es requerida
    /// </summary>
    public bool Autenticado { get; set; }


    /// <summary>
    /// Nombre de la configuración de autenticación
    /// </summary>
    public string? AuntenticacionId { get; set; }
}
