namespace api.comunes.modelos.respuestas;

public static class ExtensionesRespuesta
{
    public static ErrorProceso ErrorProcesoNoEncontrado(this string propiedad)
    {
        return new ErrorProceso()
        {
            HttpCode = HttpCode.NotFound,
            Codigo = "INEXISTENTE",
            Propiedad = propiedad,
            Mensaje = "El elemento no fue localizado"
        };
    }
}
