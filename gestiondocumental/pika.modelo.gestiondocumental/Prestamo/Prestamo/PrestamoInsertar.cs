namespace pika.modelo.gestiondocumental;
public class PrestamoInsertar
{
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
    public DateTime FechaProgramadaDevolucion { get; set;}
    /// <summary>
    /// Descripción opcional del contenido del préstamo
    /// </summary>
    public string? Descripcion { get; set; }
    /// <summary>
    /// Identificador único del archivo actual del activo
    /// </summary>
    public string ArchivoId { get; set; }
}
