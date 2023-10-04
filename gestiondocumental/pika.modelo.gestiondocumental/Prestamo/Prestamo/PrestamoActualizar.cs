namespace pika.modelo.gestiondocumental;
public class PrestamoActualizar
{
    /// <summary>
    /// IDentificador único oel préstamo
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// Número de fplio del préstamo
    /// </summary>
    public string Folio { get; set; }
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
    /// Identificador único del archivo actual del activo
    /// </summary>
    public string ArchivoId { get; set; }
}
