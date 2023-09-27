using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental.Acervo;

namespace pika.servicios.gestiondocumental.Activo;

/// <summary>
/// Interfaz para el servicio de activo
/// </summary>
public interface IServicoActivo : IServicioEntidadGenerica<modelo.gestiondocumental.Activo, ActivoInsertar, ActivoActualizar, ActivoDespliegue, string>
{
}
