using System.Diagnostics.CodeAnalysis;

namespace pika.modelo.seguridad;

[ExcludeFromCodeCoverage]
public class ModuloDespliegue
{
    /// <summary>
    /// Identificador único del módulo
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Identificador único de la aplicación a la que pertenece el módulo
    /// </summary>
    public Guid AplicacionId { get; set; }

    /// <summary>
    /// Nombre del módulo para la UI, esto será calcolado en base al idioa
    /// </summary>
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del módulo para la UI, esto será calcolado en base al idioa
    /// </summary>
    public string? Descripcion { get; set; }
}
