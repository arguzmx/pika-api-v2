namespace api.comunes.modelos.modelos;

/// <summary>
/// Almacena los identificadores relacionados con el contexto del usuario en sesión
/// </summary>
public class ContextoUsuario
{
    /// <summary>
    /// Identificador único del usuario
    /// </summary>
    public string UsuarioId { get; set; }
    
    /// <summary>
    /// Dominio del usuario en sesión
    /// </summary>
    public string? DominioId { get; set; }
    
    /// <summary>
    /// Unidad organizacional del usuario en sesión
    /// </summary>
    public string? UOrgId { get; set; }
}
