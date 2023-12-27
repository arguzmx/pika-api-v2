namespace pika.modelo.gestiondocumental;

public class TransferenciaInsertar
{
    public string Nombre { get; set; }
    public string Folio { get; set; }
    public string ArchivoOrigenId { get; set; }
    public string ArchivoDestinoId { get; set; }
    public string? CuadroClasificacionId { get; set; }
    public string? SerieDocumentalId { get; set; }
    public int? RangoDias { get; set; }
    public string EstadoTransferenciaId { get; set; }
}
