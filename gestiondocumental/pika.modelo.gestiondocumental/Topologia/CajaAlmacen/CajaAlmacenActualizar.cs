namespace pika.modelo.gestiondocumental;

public class CajaAlmacenActualizar
{
    public string Id { get; set; }
    public string Nombre { get; set; }
    public string? CodigoBarras { get; set; }
    public string? CodigoElectronico { get; set; }
    public decimal Ocupacion { get; set; } = 0;
}
