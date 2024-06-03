using api.comunes.metadatos;
using api.comunes.metadatos.atributos;
using api.comunes.metadatos.configuraciones;
using System.Reflection;


namespace api.comunes.modelos.reflectores;

/// <summary>
/// REfelcto para entidades de API genérica
/// </summary>
public class ReflectorEntidadAPI: IReflectorEntidadesAPI
{

    public Entidad ObtieneEntidad (Type Tipo)
    {
        Entidad entidad = new()
        {
            Nombre = Tipo.Name.ToString(),
            Id = Guid.NewGuid().ToString()
        };

        foreach (var propertyInfo in Tipo.GetProperties())
        {
            Propiedad? propiedad = propertyInfo.ObtieneMetadatos();
            if(propiedad != null)
            {
                entidad.Propiedades.Add(propiedad);
            }
        }
        return entidad;
    }
    public Entidad ObtieneEntidadUI(Type dtoFull,Type dtoInsertar,Type dtoActualizar,Type dtoDespliegue)
    {
        Entidad entidad = ObtieneEntidad(dtoFull);
        List<string> propiedadesFull = dtoFull.GetProperties().ToList().Select(p=>p.Name).ToList();
        List<string> propiedadesInsertar = dtoInsertar.GetProperties().ToList().Select(p => p.Name).ToList();
        List<string> propiedadesActualizar = dtoActualizar.GetProperties().ToList().Select(p => p.Name).ToList();
        List<string> propiedadesDesplegar = dtoDespliegue.GetProperties().ToList().Select(p => p.Name).ToList();

        //foreach(var p in entidad.Propiedades)
        //{
        //    p.Nombre
        //}

        //foreach (var propiedad in dtoFull.GetProperties())
        //{
        //    if (dtoInsertar.GetProperties().Any(_=>_.Name==propiedad.Name) || dtoActualizar.GetProperties().Any(_ => _.Name == propiedad.Name) || dtoDespliegue.GetProperties().Any(_ => _.Name == propiedad.Name))
        //    {
        //        var tmp = GetTipoPropiedad(propiedad);
        //        tmp.HabilitadoCrear = dtoInsertar.GetProperties().Any(_ => _.Name == propiedad.Name);
        //        tmp.HabilitadoEditar = dtoActualizar.GetProperties().Any(_ => _.Name == propiedad.Name);
        //        tmp.HabilitadoDespliegue = dtoDespliegue.GetProperties().Any(_ => _.Name == propiedad.Name);
        //        entidad.Propiedades.Add(tmp);
        //    }

        //}

            return entidad;
    }


}

