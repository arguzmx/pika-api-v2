using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental;

namespace pika.servicios.gestiondocumental.topologia
{
    public interface InterfaceServicioAlmacenArchivo  : IServicioEntidadGenerica<AlmacenArchivo, AlmacenArchivoInsertar,AlmacenArchivoActualizar,AlmacenArchivoDespliegue,string>  
    {
    }

    public interface InterfaceServicioZonaAlmacen : IServicioEntidadGenerica<ZonaAlmacen, ZonaAlmacenInsertar, ZonaAlmacenActualizar, ZonaAlmacenDespliegue, string>
    {
    }

    public interface InterfaceServicioPosicionAlmacen : IServicioEntidadGenerica<PosicionAlmacen, PosicionAlmacenInsertar, PosicionAlmacenActualizar, PosicionAlmacenDespliegue, string>
    {
    }

    public interface InterfaceServicioCajaAlmacen : IServicioEntidadGenerica<CajaAlmacen, CajaAlmacenInsertar, CajaAlmacenActualizar, CajaAlmacenDespliegue, string>
    {
    }
}


