namespace api.comunes;

/// <summary>
/// Proporiciona los servicios para la configuración de entidades de API
/// </summary>
public class ConfiguracionAPIEntidades : IConfiguracionAPIEntidades
{

    private List<ServicioEntidadAPI> servicios = null;
    private List<string> rutasGenericas = null;


    public List<string> ObtieneRutasControladorGenerico()
    {
        if(rutasGenericas == null)
        {
            rutasGenericas = IntrospeccionEnsamblados.OntieneRutasControladorGenrico();
        }
        return rutasGenericas; 
    }

    /// <summary>
    /// DEvulve una lista de servicios de entidad  con datos de ruteo
    /// </summary>
    /// <returns></returns>
    public List<ServicioEntidadAPI> ObtienesServiciosIEntidadAPI()
    {
        if (servicios == null)
        {
            servicios = IntrospeccionEnsamblados.ObtienesServiciosIEntidadAPI();
        }
        return servicios;
    }

    /// <summary>
    /// Recarga la lista de servicios de entidad para la API genérica
    /// </summary>
    public void RecargarServicios()
    {
        servicios = IntrospeccionEnsamblados.ObtienesServiciosIEntidadAPI();
    }
}
