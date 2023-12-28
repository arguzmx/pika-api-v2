namespace pika.modelo.gestiondocumental;

public class CajaAlmacenInsertar
{
    public string Nombre { get; set; }
    public string? CodigoBarras { get; set; }
    public string? CodigoElectronico { get; set; }
    public decimal Ocupacion { get; set; } = 0;
    public string AlmacenArchivoId { get; set; }
    public string ZonaAlmacenId { get; set; }
    public string PosicionAlmacenId { get; set; }
    public string ArchivoId { get; set; }
}
