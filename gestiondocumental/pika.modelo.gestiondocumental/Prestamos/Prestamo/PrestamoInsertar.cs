namespace pika.modelo.gestiondocumental;

public class PrestamoInsertar
{
    public string Folio { get; set; }
    public string UsuarioDestinoId { get; set; }
    public DateTime FechaProgramadaDevolucion { get; set; }
    public string Descripcion { get; set; }
    public string ArchivoId { get; set; }
    public string UsuarioOrigenId { get; set; }
}
