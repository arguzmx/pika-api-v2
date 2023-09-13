namespace pika.modelo.gestiondocumental.Archivos;

/// <summary>
/// Modelo para la inserción de la entidad archivo
/// </summary>
public class ArchivoInsertar
{ 
    /// <summary>
    /// Nombre del archivo
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Tipo de archivo del catálogo
    /// </summary>
    public string TipoArchivoId { get; set; }
}
