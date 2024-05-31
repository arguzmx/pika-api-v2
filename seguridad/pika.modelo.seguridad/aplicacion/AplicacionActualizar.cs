using System.Diagnostics.CodeAnalysis;

namespace pika.modelo.seguridad;

/// <summary>
/// DTO par ala actualziación de aplicaciones
/// </summary>
[ExcludeFromCodeCoverage]
public class AplicacionActualizar
{

    /// <summary>
    /// ID único de la aplicaión
    /// </summary>
    public required string Id { get; set; }
    /// <summary>
    /// Nombre del módulo para la UI
    /// </summary>
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del módulo para la UI
    /// </summary>
    public string? Descripcion { get; set; }
}
