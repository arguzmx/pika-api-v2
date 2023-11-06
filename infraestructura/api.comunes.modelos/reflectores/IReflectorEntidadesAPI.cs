using api.comunes.metadatos;

namespace api.comunes.modelos.reflectores;

public interface IReflectorEntidadesAPI
{

    Entidad ObtieneEntidad(Type Tipo);
    Entidad ObtieneEntidadUI(Type dtoInsertar, Type dtoActualizar, Type dtoDespliegue);
}
