using api.comunes.metadatos.configuraciones;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace api.comunes.metadatos.atributos;

public static class ExtensionesAtributos
{

    public static Propiedad? ObtieneMetadatos(this PropertyInfo propertyInfo)
    {
        Propiedad propiedad = new Propiedad();

        Attribute[] attrs = propertyInfo.GetCustomAttributes().ToArray();

        foreach (Attribute attr in attrs)
        {
            if (attr is ProtegidoAttribute p)
            {
                // Los atributos protegidos no se exponen a la API
                return null;
            }

            if (attr is PropiedadAttribute a)
            {
                propiedad = a.ObtieneDatosPropiedad(propertyInfo, propiedad);
            }

            if (attr is TablaAttribute t)
            {
                propiedad.ConfiguracionTabular = t.ObtieneConfiguracionTabular();
             }
        }

        return propiedad;
    }

    private static Propiedad ObtieneDatosPropiedad(this PropiedadAttribute a, PropertyInfo propertyInfo, Propiedad propiedad)
    {
        propiedad.Nombre = propertyInfo.Name;
        propiedad.Id = propertyInfo.Name;

        if (a.TipoDatos != TipoDatos.SinAsignar)
        {
            propiedad.Tipo = a.TipoDatos;
            propiedad.TipoDespliegue = a.TipoDespliegue;
            propiedad.Buscable = a.Buscable;

        }
        else
        {
            // Fallback si la propiedad no esta anotada
            propiedad.Tipo = GetTipoDato(propertyInfo);
            propiedad.TipoDespliegue = TipoDespliegue.Default;
            propiedad.Buscable = true;
        }
        return propiedad;
    }

    private static ConfiguracionTabular? ObtieneConfiguracionTabular(this TablaAttribute t)
    {
        return new ConfiguracionTabular()
        {
            Alternable = t.Alternable,
            Ancho = t.Ancho,
            Indice = t.Indice,
            Ordenable = t.Ordenable,
            Visible = t.Visible
        };
    }

    private static TipoDatos GetTipoDato(PropertyInfo propiedadObjeto)
    {
        switch (propiedadObjeto.PropertyType)
        {
            case Type type when type == typeof(string):
                return TipoDatos.Texto;

            case Type type when type == typeof(decimal) || type == typeof(decimal?):
                return TipoDatos.Decimal;


            case Type type when type == typeof(DateTime):
                return TipoDatos.FechaHora;

            case Type type when type == typeof(int):
                return TipoDatos.Entero;

            case Type type when type == typeof(bool):
                return TipoDatos.Logico;

            case Type type when type == typeof(List<string>):
                return TipoDatos.ListaSeleccionMultiple;

            default:
                return TipoDatos.SinAsignar;
        }
    }


}
