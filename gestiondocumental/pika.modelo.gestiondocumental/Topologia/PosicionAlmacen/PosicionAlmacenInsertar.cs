namespace pika.modelo.gestiondocumental;

public class PosicionAlmacenInsertar
{
    public string Nombre { get; set; }
    public int Indice { get; set; } = 0;
    public string? Localizacion { get; set; }
    public string? CodigoBarras { get; set; }
    public string? CodigoElectronico { get; set; }
    public decimal Ocupacion { get; set; } = 0;
    public decimal IncrementoContenedor { get; set; } = 0;
    public string ArchivoId { get; set; }
    public string AlmacenArchivoId { get; set; }
    public string ZonaAlmacenId { get; set; }
}
