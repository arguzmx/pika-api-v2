using api.comunes.modelos.servicios;
using CouchDB.Driver;
using pika.modelo.contenido;

namespace pika.servicios.contenido.Version;

public interface IServicioVersion : IServicioEntidadGenerica<modelo.contenido.Version, VersionInsertar, VersionActualizar, VersionDespliegue, string>
{
}

/*
public interface ICouchServiciosVersion
{
    Task<VersionRespuesta> PostVersionAsync(VersionInsertar version);
    Task <VersionRespuesta> PutVersionAsync(VersionActualizar versionActualizar);
    Task<VersionRespuesta> GetVersionAsync(string id);
    Task<VersionRespuesta> DeleteVersionAsync(string id, string rev);
}
*/