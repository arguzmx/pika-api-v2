using System.Diagnostics.CodeAnalysis;

namespace pika.seguridad.modelo;

/// <summary>
/// Rol de seguridad asociado a una apliación
/// </summary>
[ExcludeFromCodeCoverage]
public class RolActualizar
{
    /// <summary>
    /// Identificador único del rol
    /// </summary>
    public Guid Id { get; set; }
   
    /// <summary>
    /// Nombre del rol para la UI, esto será calcolado en base al idioma o bien al crear roles personalizados
    /// </summary>
    public required string Nombre { get; set; }

    /// <summary>
    /// Descripción del rol para la UI, esto será calcolado en base al idioma o bien al crear roles personalizados
    /// </summary>
    public string? Descripcion { get; set; }

}
