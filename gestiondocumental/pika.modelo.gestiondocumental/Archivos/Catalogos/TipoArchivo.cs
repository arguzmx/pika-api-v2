using api.comunes.modelos.modelos;

namespace pika.modelo.gestiondocumental;


/// <summary>
/// Catlagos de tipos de archivo
/// </summary>
public class TipoArchivo : ElementoCatalogo
{
    /// <summary>
    /// Propiedades de nevegacion
    /// </summary>
    public List<Archivo>? Archivos { get; set; }
}
