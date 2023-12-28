
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental;

/// <summary>
/// Regisro de control para el préstamo de activos del acervo
/// </summary>
public class Prestamo
{

    /// <summary>
    /// Identificador único del présstamo
    /// </summary>
    public string Id { get; set; }
    // [a] [d] 
    // R 128

    /// <summary>
    /// FEcha de creación del registro debe ser la fecha del sistema UTC, sin intervención del usuario
    /// </summary>
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Número de fplio del préstamo
    /// </summary>
    public string Folio { get; set; }


    /// <summary>
    /// Identificador único del archivo actual del activo
    /// </summary>
    public string ArchivoId { get; set; }
    // [a] [d] 
    // R 128


    /// <summary>
    /// Identificador único del usuario origen del prestamo
    /// </summary>
    public string UsuarioOrigenId { get; set; }
    // [d]  Este dato se va a leer desde el conteto de la propiedad UsuarioId
    // R 128

    /// <summary>
    /// Identificador del usuario destinatario del préstamo
    /// </summary>
    public string UsuarioDestinoId { get; set; }
    // [i] [a] [d] 
    // R 128

    /// <summary>
    /// Fecha programda parala devolucion del preátsmo en formato UTC
    /// </summary>
    public DateTime FechaProgramadaDevolucion { get; set; }
    // [i] [d] 
    // R 128


    /// <summary>
    /// Fecha de devolución real del préstamo, este valor se establece sin intervención del  usuario 
    /// </summary>
    public DateTime? FechaDevolucion { get; set; }
    // [a] [d] 
    // R


    /// <summary>
    /// Descripción adiconal para el préstamo
    /// </summary>
    public string Descripcion { get; set; }
    // [i] [a] [d] 
    // 500

    /// <summary>
    ///  Número de elementos involucrados en el préstamo
    /// </summary>
    public int CantidadActivos { get; set; } = 0;
    // [d] 
    // R

    /// <summary>
    /// Indica si el prestamo ha sido entregado
    /// </summary>
    public bool Entregado { get; set; } = false;
    // [d] 
    // R

    /// <summary>
    /// Indica si el préstamo ha sico devuelto en su totalidad
    /// </summary>
    public bool Devuelto { get; set; } = false;
    // [d] 
    // R

    [XmlIgnore]
    [JsonIgnore]
    public Archivo Archivo { get; set; }

}
