

namespace pika.modelo.contenido.Carpeta;

public class CarpetaDespliegue
{
    /// <summary>
    ///  Identificdor únio del volumen
    ///  Se obtiene con GUID new
    /// </summary>
    public string Id { get; set; }


    /// <summary>
    /// Identificador único del creador de la carpeta
    /// </summary>
    public string CreadorId { get; set; }

    /// <summary>
    /// FEcha de creación en formato UTC
    /// </summary>
    public DateTime FechaCreacion { get; set; }

    /// <summary>
    /// Nombre para la carpeta 
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Identificador de la carpeta padre de la actual 
    /// </summary>
    public string? CarpetaPadreId { get; set; }

}
