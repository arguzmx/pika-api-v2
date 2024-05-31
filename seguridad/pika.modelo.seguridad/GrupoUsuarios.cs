
namespace pika.modelo.seguridad;

/// <summary>
/// Representa un grupo de usuario 
/// </summary>
public class GrupoUsuarios
{
    /// <summary>
    /// Identificador unico del grupo
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Identificador único de la dominio en el que aplica la configuracion, este Id será propoerionado por un sistema externo
    /// </summary>
    public required string DominioId { get; set; }

    /// <summary>
    /// Identificador único de la aplicación, este Id será propoerionado por un sistema externo
    /// </summary>
    public required string ApplicacionId { get; set; }

    /// <summary>
    /// Lista de los usuarios pertenecentes al grupo
    /// </summary>
    public List<string> UsuarioId { get; set; } = [];

    /// <summary>
    /// Nombre del grupo para la UI
    /// </summary>
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del grupo
    /// </summary>
    public string? Descripcion { get; set; }
}
