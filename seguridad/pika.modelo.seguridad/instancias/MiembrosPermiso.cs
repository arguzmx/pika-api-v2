namespace pika.modelo.seguridad.instancias;

/// <summary>
/// Espeifica los usuarios/grupos con un permiso individual asociado
/// </summary>
public class MiembrosPermiso
{
    /// <summary>
    /// IDentificador unico del permiso
    /// </summary>
    public required string RolId { get; set; }

    /// <summary>
    /// Lista de los usuarios asociados al permiso
    /// </summary>
    public List<string> UsuarioId { get; set; } = [];

    /// <summary>
    /// Lista de los grupos asociados al permiso
    /// </summary>
    public List<string> GrupoId { get; set; } = [];
}
