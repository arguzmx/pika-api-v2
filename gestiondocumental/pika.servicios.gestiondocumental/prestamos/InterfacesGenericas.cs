using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.prestamos
{
    public interface IServicioPrestamo : IServicioEntidadGenerica<Prestamo, PrestamoInsertar, PrestamoActualizar, PrestamoDespliegue, string>
    {
    }
}
