using System.Diagnostics.CodeAnalysis;

namespace pika.seguridad.modelo;

/// <summary>
/// Rol de seguridad asociado a una apliación
/// </summary>
[ExcludeFromCodeCoverage]
public class RolInsertar
{

    /// <summary>
    /// Identificador único del módulo al que pertenece el rol 
    /// </summary>
    public Guid ModuloId { get; set; }

    /// <summary>
    /// Identificador único de la aplicación del módulo con el rol 
    /// </summary>
    public Guid AplicacionId { get; set; }

    /// <summary>
    /// Nombre del rol para la UI, esto será calcolado en base al idioma o bien al crear roles personalizados
    /// </summary>
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del rol para la UI, esto será calcolado en base al idioma o bien al crear roles personalizados
    /// </summary>
    public string? Descripcion { get; set; }

}
