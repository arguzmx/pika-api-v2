namespace pika.modelo.gestiondocumental;

public class PrestamoActualizar
{
    public string Id { get; set; }
    public string Folio { get; set; }
    public string ArchivoId { get; set; }
    public string UsuarioDestinoId { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public string Descripcion { get; set; }
    
}
