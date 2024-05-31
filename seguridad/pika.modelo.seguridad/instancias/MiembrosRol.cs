namespace pika.modelo.seguridad.instancias;

/// <summary>
/// Almacena el vínculo entre usuarios y roles
/// </summary>
public class MiembrosRol
{
    /// <summary>
    /// IDentificador unico del rol
    /// </summary>
    public required string RolId { get; set; }

    /// <summary>
    /// Lista de los usuarios asociados al rol
    /// </summary>
    public List<string> UsuarioId { get; set; } = [];

    /// <summary>
    /// Lista de los grupos asociados al rol
    /// </summary>
    public List<string> GrupoId { get; set; } = [];
}
