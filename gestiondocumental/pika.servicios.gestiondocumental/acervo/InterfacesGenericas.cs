

using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.acervo
{

    public interface IServicioActivo : IServicioEntidadGenerica<Activo, ActivoInsertar, ActivoActualizar, ActivoDespliegue, string>
    {
    }

}
