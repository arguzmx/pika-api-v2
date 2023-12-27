namespace pika.modelo.gestiondocumental;

public class ArchivoActualizar
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
}
