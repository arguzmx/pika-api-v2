namespace api.comunes.modelos;

public class ErrorMiddlewareGenerico
{
    public string Entidad { get; set; }
    public int HttpCode { get; set; }
    public string Error { get; set; }
}
