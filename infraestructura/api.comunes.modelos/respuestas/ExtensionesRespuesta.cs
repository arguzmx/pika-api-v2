using System.Diagnostics.CodeAnalysis;

namespace api.comunes.modelos.respuestas;

[ExcludeFromCodeCoverage]
public static class ExtensionesRespuesta
{
    /// <summary>
    /// Genera un errror de poceso inexistente 404 para la propieda de la entidad
    /// </summary>
    /// <param name="propiedad"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Genera un errror de poceso duplicado 409 para la propieda de la entidad
    /// </summary>
    /// <param name="propiedad"></param>
    /// <returns></returns>
    public static ErrorProceso ErrorProcesoDuplicado(this string propiedad)
    {
        return new ErrorProceso()
        {
            HttpCode = HttpCode.Conflict,
            Codigo = "DUPLICADO",
            Propiedad = propiedad,
            Mensaje = $"{propiedad} se encuentra duplicado en el dominio"
        };
    }
}
