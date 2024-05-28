using System.Diagnostics.CodeAnalysis;

namespace pika.seguridad.modelo;

/// <summary>
/// DTO de despliegue de la apkciación
/// </summary>
[ExcludeFromCodeCoverage]
public class AplicacionDesplegar
{
    /// <summary>
    /// ID único de la aplicaión
    /// </summary>
    public required Guid Id { get; set; }

    /// <summary>
    /// Nombre del módulo para la UI
    /// </summary>
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del módulo para la UI
    /// </summary>
    public string? Descripcion { get; set; }
}
