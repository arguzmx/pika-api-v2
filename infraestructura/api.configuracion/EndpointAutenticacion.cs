namespace api.configuracion;

/// <summary>
/// Define un endpoint de autenticación consus credenciales
/// </summary>
public class EndpointAutenticacion
{
    /// <summary>
    /// Identificador único de la configuración
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Url del servicio de autenticación
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// Nombre del cliente de auntenticación
    /// </summary>
    public required string ClientId { get; set; }


    /// <summary>
    /// Secreto para la autenticación
    /// </summary>
    public required string Secret { get; set; }

    /// <summary>
    /// Ruta al certificado de cifrado del servidor de Identidad
    /// </summary>
    public string EncryptionCertificate { get; set; }
}
