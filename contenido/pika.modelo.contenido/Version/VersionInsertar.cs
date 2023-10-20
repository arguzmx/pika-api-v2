namespace pika.modelo.contenido.Version;

public class VersionInsertar
{
    /// <summary>
    /// Identificador único del elemento al que pertenece la versión
    /// </summary>
    public string ContenidoId { get; set; }
 
    /// <summary>
    /// Indica si la versión es la activa, sólo pude existir una versión activa por elemento
    /// </summary>
    public bool Activa { get; set; } = true;

    /// <summary>
    /// Identificador único del volumen para la version
    /// </summary>
    public string VolumenId { get; set; }

}
