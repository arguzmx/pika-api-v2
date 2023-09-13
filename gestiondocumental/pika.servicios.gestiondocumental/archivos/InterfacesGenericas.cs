using api.comunes.modelos.reflectores;
using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.Archivos;

namespace pika.servicios.gestiondocumental.archivos;

/// <summary>
/// Interfaz para el servicio de archivos
/// </summary>
public interface IServicioArchivo : IServicioEntidadGenerica<Archivo, ArchivoInsertar, ArchivoActualizar, ArchivoDespliegue, string>
{
}


/// <summary>
/// Interfaz para el servicio catálogo tipo archivo
/// </summary>
public interface IServicioTipoArchivo : IServicioCatalogoAPI
{
}