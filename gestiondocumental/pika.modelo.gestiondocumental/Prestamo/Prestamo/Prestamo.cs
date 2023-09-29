namespace pika.modelo.gestiondocumental;
/// <summary>
/// Entidad para el control de préstamo de activos del acervo
/// </summary>
public class Prestamo
{

    /// <summary>
    /// IDentificador único oel préstamo
    /// </summary>
    public string Id { get; set; }
    // [a] [d] 
    // R 128

    /// <summary>
    /// Fecha de creación del regiustro debe ser la fecha del sistema UTC, sin intervención del usuario
    /// </summary>
    public DateTime FechaCreacion { get; set; }
    // [d] 
    // R

    /// <summary>
    /// Número de fplio del préstamo
    /// </summary>
    public string Folio { get; set; }
    // [i] [a] [d] 
    // R 250

    /// <summary>
    ///  Número de elementos involucrados en el préstamo, se calcula automáticamente
    /// </summary>
    public int CantidadActivos { get; set; } = 0;
    // [d] 
    // R

    /// <summary>
    /// Identificador único del usuario origen del prestamo, se calcula de la sesión
    /// </summary>
    public string UsuarioOrigenId { get; set; }
    // [d] 
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
    // [i] [a] [d] 
    // R

    /// <summary>
    /// Fecha de devolución real del préstamo, este valor se establece sin intervención del  usuario 
    /// </summary>
    public DateTime? FechaDevolucion { get; set; }
    // [a] [d] 
    // R

    /// <summary>
    /// Descripción opcional del contenido del préstamo
    /// </summary>
    public string? Descripcion { get; set; }
    // [i] [a] [d] 
    // R 250

    /// <summary>
    /// Indica si el préstamo ha sido etregado
    /// </summary>
    public bool Entregado { get; set; } = false;
    // [d] 
    // R 

    /// <summary>
    /// Estupila si el préstamo ha sico devuelto en su totalidad
    /// </summary>
    public bool Devuelto { get; set; }
    // [d] 
    // R

    /// <summary>
    /// Indica si ha habido devoluciones parciales del préstamo, sin intervención del usuario
    /// </summary>
    public bool TieneDevolucionesParciales { get; set; } = false;
    // [d] 
    // R 

    /// <summary>
    /// Identificador único del archivo actual del activo
    /// </summary>
    public string ArchivoId { get; set; }
    // [i] [a] [d] 
    // R 


    /// <summary>
    /// Propieda de navegacion para el archivo vía ArchivoId
    /// </summary>
    public Archivo Archivo { get; set; }

    //public virtual ICollection<ActivoPrestamo> ActivosRelacionados { get; set; }


    //public virtual ICollection<ComentarioPrestamo> Comentarios { get; set; }

}
