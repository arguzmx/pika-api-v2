
namespace pika.modelo.contenido.Carpeta;

public class CarpetaActualizar
{
    /// <summary>
    ///  Identificdor únio del volumen
    ///  Se obtiene con GUID new
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Nombre para la carpeta 
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Identificador de la carpeta padre de la actual 
    /// </summary>
    public string? CarpetaPadreId { get; set; }
   

}
