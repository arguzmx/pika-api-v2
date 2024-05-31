using System.Diagnostics.CodeAnalysis;

namespace pika.modelo.seguridad;

[ExcludeFromCodeCoverage]
public class PermisoActualizar
{
    /// <summary>
    /// Identificador único del permido
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Nombre del permiso para la UI, esto será calcolado en base al idioa
    /// </summary>
    public required string Nombre { get; set; }


    /// <summary>
    /// Descripción del permiso para la UI, esto será calcolado en base al idioa
    /// </summary>
    public string? Descripcion { get; set; }


    /// <summary>
    /// Determina el ámbito de apliación del permiso
    /// </summary>
    public AmbitoPermiso Ambito { get; set; }
}
