namespace pika.modelo.gestiondocumental;

public class PosicionAlmacenActualizar
{
    public string Id { get; set; }
    public string Nombre { get; set; }
    public int Indice { get; set; } = 0;
    public string? Localizacion { get; set; }
    public string? CodigoBarras { get; set; }
    public string? CodigoElectronico { get; set; }
    public decimal Ocupacion { get; set; } = 0;
    public decimal IncrementoContenedor { get; set; } = 0;

}
