namespace pika.modelo.contenido.Contenido;

public class ContenidoActualizar
{
    /// <summary>
    /// Indetificador único del elemento de contenido
    /// </summary>
    public string Id { get; set; }
  

    /// <summary>
    /// Nombre común dado al elemento de contenido
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Esta Identificador permite asociar el elemento a un sistema externo
    /// como clave de búsqueda
    /// </summary>
    public string? IdExterno { get; set; }
    public string? PermisoId { get; set; }

}
