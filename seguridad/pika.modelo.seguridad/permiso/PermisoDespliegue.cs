namespace pika.modelo.seguridad;

public class PermisoDespliegue
{
    /// <summary>
    /// Identificador único del permido
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Identificador único del módulo al que pertenece el permiso
    /// </summary>
    public string ModuloId { get; set; }

    /// <summary>
    /// Identificador único de la aplicación del módulo con el permiso
    /// </summary>
    public string AplicacionId { get; set; }

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
