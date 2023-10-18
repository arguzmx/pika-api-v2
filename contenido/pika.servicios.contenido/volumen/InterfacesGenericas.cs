using api.comunes.modelos.servicios;
using pika.modelo.contenido.Volumen;

namespace pika.servicios.contenido.volumen;

/// <summary>
/// Interfaz para el servicio de volumen
/// </summary>
public interface IServicioVolumen : IServicioEntidadGenerica<Volumen, VolumenInsertar, VolumenActualizar, VolumenDespliegue, string>
{
}
