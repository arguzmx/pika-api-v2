namespace api.comunes.metadatos.configuraciones;

/// <summary>
/// Especifica las la configuración tabulre de una propiedad de metadatos
/// </summary>
public class ConfiguracionTabular
{
    /// <summary>
    /// Posición o número de columna en el despliegue tabular si MostrarEnTabla es true 
    /// </summary>
    public int Indice { get; set; }

    /// <summary>
    /// Determina si la propiedad se muestra en el despliegue tabular
    /// </summary>
    public bool MostrarEnTabla { get; set; }

    /// <summary>
    /// Determina si la propiedad puede alternar su visibilidad en el despliegue tabular
    /// </summary>
    public bool AlternarEnTabla { get; set; }
}
