using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.comunes.modelos.reflectores;

/// <summary>
/// Define los atributos de API para la entidad
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class EntidadAPIAttribute: Attribute
{
    private string _NombreEntidad;

    /// <summary>
    /// Crea una instancia del atributo de entidades
    /// </summary>
    /// <param name="NombreEntidad">Nombre asociado a la entidad para el ruteo en el comtrolador</param>
    public EntidadAPIAttribute(string NombreEntidad) { 
        _NombreEntidad = NombreEntidad;
    }

    /// <summary>
    /// Nombre asociado a la entidad para el ruteo en el comtrolador
    /// </summary>
    public virtual string NombreEntidad
    {
        get { return _NombreEntidad; }
    }

}
