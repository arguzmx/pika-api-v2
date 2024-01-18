using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental.UnidadesAdministrativas;

/// <summary>
/// Define la unidad adminsirtativa donde los usuarios que no forman parte del grupo de archivónomos mantienen el inventario de trámite
/// </summary>
public class UnidadAdministrativa
{

    /// <summary>
    /// Identificador único de la unidad administrativa
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// NOmbre de la unidad administrativa
    /// </summary>
    public string Nombre { get; set; }

        
    /// <summary>
    /// Nombre del responsable de la unidad
    /// </summary>
    public string Responsable { get; set; }


    /// <summary>
    /// CArgo del responsable de la unidad
    /// </summary>
    public string Cargo { get; set; }


    /// <summary>
    /// TElédono de contacto de la unidad
    /// </summary>
    public string Telefono { get; set; }


    /// <summary>
    /// Email de contacto de la unidad
    /// </summary>
    public string Email { get; set; }



    /// <summary>
    /// Domicilio de la unidad
    /// </summary>
    public string Domicilio { get; set; }

    
    /// <summary>
    /// Ubicación de la unidad en el domicilio
    /// </summary>
    public string UbicacionFisica { get; set; }


    /// <summary>
    /// Identificador único del archivo de trámite donde se crearán los activos del acervo
    /// </summary>
    public string ArchivoTramiteId { get; set; }

    /// <summary>
    /// Identificador único del archivo de concentración donde se crearán los activos del acervo
    /// </summary>
    public string ArchivoConcentracionId { get; set; }

    /// <summary>
    /// Identificador único del archivo histórico donde se crearán los activos del acervo
    /// </summary>
    public string ArchivoHistoricoId { get; set; }

    

    //[JsonIgnore]
    //[XmlIgnore]
    //public Archivo ArchivoTramite { get; set; }

    //[JsonIgnore]
    //[XmlIgnore]
    //public Archivo ArchivoConcentracion { get; set; }

    //[JsonIgnore]
    //[XmlIgnore]
    //public Archivo ArchivoHistorico { get; set; }

    //[JsonIgnore]
    //[XmlIgnore]
    //public ICollection<Activo> Activos { get; set; }

    //[JsonIgnore]
    //[XmlIgnore]
    //public ICollection<PermisosUnidadAdministrativaArchivo> Permisos { get; set; }

    //[JsonIgnore]
    //[XmlIgnore]
    //public List<EstadisticaClasificacionAcervo> EstadisticasClasificacionAcervo { get; set; }
}
