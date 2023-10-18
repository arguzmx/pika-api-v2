
namespace pika.modelo.contenido.Carpeta;

public class CarpetaInsertar
{


    /// <summary>
    /// Identificador del punto de montaje asociado a la carpeta
    /// </summary>
    public string RepositorioId { get; set; }

    /// <summary>
    /// Nombre para la carpeta 
    /// </summary>
    public string Nombre { get; set; }


    /// <summary>
    /// Identificador de la carpeta padre de la actual 
    /// </summary>
    public string? CarpetaPadreId { get; set; }

}
