using api.comunes.metadatos;
using api.comunes.metadatos.atributos;
using api.comunes.metadatos.configuraciones;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
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
        Propiedad propiedad = ObtenerArgumentos(propiedadObjeto);

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


    protected Propiedad ObtenerArgumentos (PropertyInfo InformacionPropiedad)
    {
        Propiedad propiedad = new Propiedad();
        foreach (var attribute in InformacionPropiedad.CustomAttributes)
        {
            switch (attribute.AttributeType.Name)
            {

                case "TablaAttribute":
                    propiedad.ConfiguracionTabular = ObtenerConfiguracionTabular(attribute);
                    break;

                default:
                    break;
            }
        }

        return propiedad;
    }
    protected ConfiguracionTabular ObtenerConfiguracionTabular(CustomAttributeData atributo)
    {
        ConfiguracionTabular configuracion = new();
        foreach (var argumento in atributo.Constructor.GetParameters())
        {
            var ValorDato = atributo.ConstructorArguments[argumento.Position].Value;
            configuracion.GetType().GetProperty($"{argumento.Name.Substring(0, 1).ToUpper()}{argumento.Name.Substring(1).ToLower()}").SetValue(configuracion, ValorDato);
        }
        return configuracion;
    }

}

