namespace pika.modelo.gestiondocumental;

public class PrestamoDespliegue
{
    public string Id { get; set; }
    public string ArchivoId { get; set; }
    public string UsuarioOrigenId { get; set; }
    public string UsuarioDestinoId { get; set; }
    public DateTime FechaProgramadaDevolucion { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public string Descripcion { get; set; }
    public int CantidadActivos { get; set; } = 0;
    public bool Entregado { get; set; } = false;
    public bool Devuelto { get; set; } = false;
}
