namespace pika.modelo.gestiondocumental;
public class PrestamoDespliegue
{
    /// <summary>
    /// IDentificador único oel préstamo
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// Fecha de creación del regiustro debe ser la fecha del sistema UTC, sin intervención del usuario
    /// </summary>
    public DateTime FechaCreacion { get; set; }
    /// <summary>
    /// Número de fplio del préstamo
    /// </summary>
    public string Folio { get; set; }
    /// <summary>
    ///  Número de elementos involucrados en el préstamo, se calcula automáticamente
    /// </summary>
    public int CantidadActivos { get; set; } = 0;
    /// <summary>
    /// Identificador único del usuario origen del prestamo, se calcula de la sesión
    /// </summary>
    public string UsuarioOrigenId { get; set; }
    /// <summary>
    /// Identificador del usuario destinatario del préstamo
    /// </summary>
    public string UsuarioDestinoId { get; set; }
    /// <summary>
    /// Fecha programda parala devolucion del preátsmo en formato UTC
    /// </summary>
    public DateTime FechaProgramadaDevolucion { get; set; }
    /// <summary>
    /// Fecha de devolución real del préstamo, este valor se establece sin intervención del  usuario 
    /// </summary>
    public DateTime? FechaDevolucion { get; set; }
    /// <summary>
    /// Descripción opcional del contenido del préstamo
    /// </summary>
    public string? Descripcion { get; set; }
    /// <summary>
    /// Indica si el préstamo ha sido etregado
    /// </summary>
    public bool Entregado { get; set; } = false;
    /// <summary>
    /// Estupila si el préstamo ha sico devuelto en su totalidad
    /// </summary>
    public bool Devuelto { get; set; }
    /// <summary>
    /// Indica si ha habido devoluciones parciales del préstamo, sin intervención del usuario
    /// </summary>
    public bool TieneDevolucionesParciales { get; set; } = false;
    /// <summary>
    /// Identificador único del archivo actual del activo
    /// </summary>
    public string ArchivoId { get; set; }

}
