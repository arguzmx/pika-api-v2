namespace pika.modelo.gestiondocumental;

public class TransferenciaDespliegue
{
    public string Id { get; set; }
    public string Nombre { get; set; }
    public string Folio { get; set; }
    public string ArchivoOrigenId { get; set; }
    public string ArchivoDestinoId { get; set; }
    public string? CuadroClasificacionId { get; set; }
    public string? SerieDocumentalId { get; set; }
    public int? RangoDias { get; set; }
    public int CantidadActivos { get; set; } = 0;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public string EstadoTransferenciaId { get; set; }
    public string UsuarioId { get; set; }
}
