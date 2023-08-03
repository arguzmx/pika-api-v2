namespace api.comunes.modelos.respuestas;

/// <summary>
/// Define un error de validacion 
/// </summary>
public class ErrorProceso
{
    public string Codigo { get; set; }
    public string Mensaje { get; set; }
    public string Propiedad { get; set; }
    public HttpCode HttpCode { get; set; } = HttpCode.None;

}
