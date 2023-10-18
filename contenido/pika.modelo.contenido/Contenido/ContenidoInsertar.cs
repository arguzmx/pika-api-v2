namespace pika.modelo.contenido.Contenido;

public class ContenidoInsertar
{

    /// <summary>
    /// Nombre común dado al elemento de contenido
    /// </summary>
    public string Nombre { get; set; }


    /// <summary>
    /// Identificador del punto de montaje asociado a la carpeta
    /// </summary>
    public string RepositorioId { get; set; }

    /// <summary>
    /// IDentificador único del volumen al que se añadió el contenido
    /// </summary>
    public string VolumenId { get; set; }


    /// <summary>
    /// Identificador de la carpeta donde se creó el contenido
    /// </summary>
    public string CarpetaId { get; set; }


    /// <summary>
    /// Identifica el tipo del elemento mostrado, nulo para tipo defautl
    /// o un tipo asociado al visor por ejemplo, expediente, cfdi, entro otros
    /// puede utilizarse también para determinarl el ícono del elemento
    /// </summary>
    public string? TipoElemento { get; set; }


    /// <summary>
    /// Esta Identificador permite asociar el elemento a un sistema externo
    /// como clave de búsqueda
    /// </summary>
    public string? IdExterno { get; set; }

}
