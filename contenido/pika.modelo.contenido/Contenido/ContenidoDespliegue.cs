namespace pika.modelo.contenido.Contenido;

public class ContenidoDespliegue
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
    /// Identificador único del creador de la carpeta
    /// </summary>
    public string CreadorId { get; set; }
 

    /// <summary>
    /// FEcha de creación en formato UTC
    /// </summary>
    public DateTime FechaCreacion { get; set; }
  

    /// <summary>
    /// Número de adjuntos en la vesion actual del contenido
    /// </summary>
    public int ConteoAnexos { get; set; } = 0;
    // [d]
  


    /// <summary>
    /// Tamaño en bytes del total de anexos en la versión actual del contenido
    /// </summary>
    public long TamanoBytes { get; set; } = 0;
    // [d]
 

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
