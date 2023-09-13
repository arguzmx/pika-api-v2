namespace api.comunes.modelos.respuestas;

/// <summary>
/// Determina si una operación de validación es exitosa
/// </summary>
public class ResultadoValidacion
{
    /// <summary>
    /// Validación exitosa
    /// </summary>
    public bool Valido { get; set; }

    /// <summary>
    /// Error de validación principal
    /// </summary>
    public ErrorProceso? Error { get; set; }
}
