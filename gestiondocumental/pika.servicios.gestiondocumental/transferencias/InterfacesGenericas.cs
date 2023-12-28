using api.comunes.modelos.reflectores;
using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.transferencias
{

    public interface InterfaceServicioTransferencia : IServicioEntidadGenerica<Transferencia, TransferenciaInsertar, TransferenciaActualizar, TransferenciaDespliegue, string>
    {
    }

    public interface IServicioEstadoTransferencia : IServicioCatalogoAPI
    {
    }
}
