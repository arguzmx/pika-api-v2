using api.comunes.metadatos;
using api.comunes.metadatos.configuraciones;
using System;
using System.Reflection;
using static System.Formats.Asn1.AsnWriter;

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
            var propiedad = GetTipoPropiedad(propertyInfo);

            foreach (var attribute in propertyInfo.CustomAttributes)
            {
                switch (attribute.AttributeType.Name)
                {

                    case "TablaAttribute":

                        propiedad.ConfiguracionTabular = ObtenerConfiguracionTabular(attribute.ConstructorArguments);
                        break;

                    default:
                        break;
                }
            }

            entidad.Propiedades.Add(propiedad);
        }
        return entidad;
    }
    public Entidad ObtieneEntidadUI(Type dtoInsertar,Type dtoActualizar,Type dtoDespliegue)
    {
        Entidad entidad = new ();

        foreach (var propiedad in dtoInsertar.GetProperties())
        {
            var propiedadEncontrada = entidad.Propiedades.FirstOrDefault(_ => _.Nombre == propiedad.Name);
            if (propiedadEncontrada==null)
            {
                var tmp = GetTipoPropiedad(propiedad);
                tmp.HabilitadoCrear = true;
                entidad.Propiedades.Add(tmp);
            }
            else
            {
                var index =entidad.Propiedades.FindIndex(_=>_.Nombre==propiedadEncontrada.Nombre);
                propiedadEncontrada.HabilitadoCrear = true;
                entidad.Propiedades[index]=propiedadEncontrada;
            }
        }
        foreach (var propiedad in dtoActualizar.GetProperties())
        {
            var propiedadEncontrada = entidad.Propiedades.FirstOrDefault(_ => _.Nombre == propiedad.Name);
            if (propiedadEncontrada == null)
            {
                var tmp = GetTipoPropiedad(propiedad);
                tmp.HabilitadoEditar = true;
                entidad.Propiedades.Add(tmp);
            }
            else
            {
                var index = entidad.Propiedades.FindIndex(_ => _.Nombre == propiedadEncontrada.Nombre);
                propiedadEncontrada.HabilitadoEditar = true;
                entidad.Propiedades[index] = propiedadEncontrada;
            }
        }
        foreach (var propiedad in dtoDespliegue.GetProperties())
        {
            var propiedadEncontrada = entidad.Propiedades.FirstOrDefault(_ => _.Nombre == propiedad.Name);
            if (propiedadEncontrada == null)
            {
                var tmp = GetTipoPropiedad(propiedad);
                tmp.HabilitadoDespliegue = true;
                entidad.Propiedades.Add(tmp);
            }
            else
            {
                var index = entidad.Propiedades.FindIndex(_ => _.Nombre == propiedadEncontrada.Nombre);
                propiedadEncontrada.HabilitadoDespliegue = true;
                entidad.Propiedades[index] = propiedadEncontrada;
            }
        }
        return entidad;
    }

    protected Propiedad GetTipoPropiedad(PropertyInfo propiedadObjeto)
    {
        Propiedad propiedad = new();
        switch (propiedadObjeto.PropertyType)
        {
            case Type type when type == typeof(string):

                propiedad.Nombre = propiedadObjeto.Name;
                propiedad.Tipo = TipoDatos.Texto;

                break;

            case Type type when type == typeof(decimal) || type == typeof(decimal?):

                propiedad.Nombre = propiedadObjeto.Name;
                propiedad.Tipo = TipoDatos.Decimal;
                break;

            case Type type when type == typeof(DateTime):

                propiedad.Nombre = propiedadObjeto.Name;
                propiedad.Tipo = TipoDatos.FechaHora;
                break;
            case Type type when type == typeof(int):

                propiedad.Nombre = propiedadObjeto.Name;
                propiedad.Tipo = TipoDatos.Entero;
                break;


            case Type type when type == typeof(bool):

                propiedad.Nombre = propiedadObjeto.Name;
                propiedad.Tipo = TipoDatos.Logico;
                break;

            case Type type when type == typeof(List<string>):

                propiedad.Nombre = propiedadObjeto.Name;
                propiedad.Tipo = TipoDatos.ListaSeleccionMultiple;
                break;
            default:

                propiedad.Nombre = propiedadObjeto.Name;
                propiedad.Tipo = TipoDatos.Desconocido;
                break;
        }
        return propiedad;
    }
    protected ConfiguracionTabular ObtenerConfiguracionTabular(IList<CustomAttributeTypedArgument> argumentosConstructor)
    {
        return new ConfiguracionTabular()
        {
            Indice = (int)argumentosConstructor[0].Value,
            MostrarEnTabla = (bool)argumentosConstructor[1].Value,
            Ancho = (int)argumentosConstructor[2].Value,
            Ordenable = (bool)argumentosConstructor[3].Value,
            AlternarEnTabla = (bool)argumentosConstructor[4].Value         
        };
    }

}

