using api.comunes.metadatos;
using api.comunes.metadatos.atributos;
using api.comunes.metadatos.validadores;

namespace api.comunes.modelos.reflectores;

/// <summary>
/// REfelcto para entidades de API genérica
/// </summary>
public class ReflectorEntidadAPI : IReflectorEntidadesAPI
{

    public Entidad ObtieneEntidad(Type Tipo)
    {
        Entidad entidad = new()
        {
            Nombre = Tipo.Name.ToString(),
            Id = Guid.NewGuid().ToString()
        };

        foreach (var propertyInfo in Tipo.GetProperties())
        {
            Propiedad? propiedad = propertyInfo.ObtieneMetadatos();
            if (propiedad != null)
            {
                entidad.Propiedades.Add(ConvertDateTimeUTC(propiedad));
            }
        }
        return entidad;
    }
    private Propiedad ConvertDateTimeUTC(Propiedad propiedad)
    {
        Propiedad nuevoFormatoFecha = new Propiedad();
        ValidadorFecha fechaHoy = new ValidadorFecha();
        if (propiedad != null)
        {
            fechaHoy = propiedad.ValidadorFecha;
        }
        switch (propiedad.Tipo)
        {
            case TipoDatos.Fecha:
                
                nuevoFormatoFecha = propiedad;
                nuevoFormatoFecha.ValidadorFecha = FormatoUniversal(propiedad.ValidadorFecha);
                return nuevoFormatoFecha;

            case TipoDatos.Hora:
              
                nuevoFormatoFecha = propiedad;
                nuevoFormatoFecha.ValidadorFecha = FormatoUniversal(propiedad.ValidadorFecha);
                return nuevoFormatoFecha;

            case TipoDatos.FechaHora:
                nuevoFormatoFecha = propiedad;
                nuevoFormatoFecha.ValidadorFecha = FormatoUniversal(propiedad.ValidadorFecha);
                return nuevoFormatoFecha;


            default:
                break;
        }
        return propiedad;

    }

        private ValidadorFecha FormatoUniversal(ValidadorFecha fechaHoy)
    {
        ValidadorFecha fecha = fechaHoy;
        if (fechaHoy.Maximo != null)
            fecha.Maximo = DateTime.Parse(fechaHoy.Maximo.ToString()).ToUniversalTime();
        if (fechaHoy.Minimo != null)
            fecha.Minimo =  DateTime.Parse(fechaHoy.Minimo.ToString()).ToUniversalTime();

        return fecha;
    }

    public Entidad ObtieneEntidadUI(Type dtoFull,Type dtoInsertar,Type dtoActualizar,Type dtoDespliegue)
    {
        Entidad entidad = ObtieneEntidad(dtoFull);

        List<string> propiedadesInsertar = dtoInsertar.GetProperties().ToList().Select(p => p.Name).ToList();
        List<string> propiedadesActualizar = dtoActualizar.GetProperties().ToList().Select(p => p.Name).ToList();
        List<string> propiedadesDesplegar = dtoDespliegue.GetProperties().ToList().Select(p => p.Name).ToList();

        foreach (var p in entidad.Propiedades)
        {
            p.HabilitadoCrear = propiedadesInsertar.Contains(p.Nombre, StringComparer.InvariantCultureIgnoreCase);
            p.HabilitadoEditar = propiedadesActualizar.Contains(p.Nombre, StringComparer.InvariantCultureIgnoreCase);
            p.HabilitadoDespliegue = propiedadesDesplegar.Contains(p.Nombre, StringComparer.InvariantCultureIgnoreCase);
        }

        return entidad;
    }


}

