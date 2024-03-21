
namespace api.configuracion;

/// <summary>
/// Parámetros de configuración comnes de la API 
/// </summary>
public class ConfiguracionAPI
{

    /// <summary>
    /// Define la clave bajo la cual se guarda la configuración de la api en ENV o Appsettings
    /// </summary>
    public const string ClaveConfiguracionBase = "ConfiguracionAPI";

    /// <summary>
    /// Define el nombre del elemento por defaul en la configuración de la api en ENV o Appsettings
    /// </summary>
    public const string ClaveConfiguracionDefault = "default";

    /// <summary>
    /// Ruta al certificado para las operaciones de crifrado de JWT, SOLO SE UTILZIAN POR EL SERVER DE IDENTITY
    /// </summary>
    public string? EncryptionCertificate { get; set; }

    /// <summary>
    /// Ruta al certificado para las operaciones de firma de JWT, SOLO SE UTILZIAN POR EL SERVER DE IDENTITY
    /// </summary>
    public string? SigningCertificate { get; set; }

    /// <summary>
    /// Especifica si el servidor de indentidad cifra el payload del JWT
    /// </summary>
    public bool JWTCifrado { get; set; }

    /// <summary>
    /// Lista de endpoints de la api
    /// </summary>
    public List<EndpointAPI> EndpointsAPI { get; set; }

    /// <summary>
    /// Lista de endpoints de autenticacion
    /// </summary>
    public List<EndpointAutenticacion> EndpointsAutenticacion { get; set; }
}
