namespace pika.modelo.gestiondocumental.Archivos;

public class ArchivoDespliegue
{ 
    /// <summary>
    /// Identificador único del archivo
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Nombre del archivo
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Tipo de archivo del catálogo
    /// </summary>
    public string TipoArchivoId { get; set; }

    /// <summary>
    /// Volument asociado al archivo para el resguardo de contenido eléctrónico
    /// </summary>
    public string? VolumenDefaultId { get; set; }

    /// <summary>
    /// Punto de montaje para mostrar el cotntenido electrónico
    /// </summary>
    public string? PuntoMontajeId { get; set; }
}
