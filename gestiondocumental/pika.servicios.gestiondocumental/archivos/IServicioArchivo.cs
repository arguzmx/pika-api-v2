using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.Archivos;

namespace pika.servicios.gestiondocumental.archivos;

public interface IServicioArchivo : IServicioEntidadGenerica<Archivo, ArchivoInsertar, ArchivoActualizar, ArchivoDespliegue, string>
{
}
