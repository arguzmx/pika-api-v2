using api.comunes.metadatos.atributos;
using pika.modelo.gestiondocumental.UnidadesAdministrativas;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental;

/// <summary>
/// DEfine un archivo para la gestión documental de su acervo
/// </summary>
[Entidad()]
public class Archivo
{
    /// <summary>
    /// Identificador único del archivo
    /// </summary>
    [Id]
    [Formulario(indice: 1, visible: false)]
    [Tabla(indice: 0, visible: false)]
    public string Id { get; set; }
    // [a] [d] 
    // R 128

    /// <summary>
    /// Nombre del archivo
    /// </summary>
    [Nombre]
    [Formulario(indice: 1, ancho: 100)]
    [Tabla(indice: 1)]
    public string Nombre { get; set; }
    // [i] [a] [d] 
    // R 500

    /// <summary>
    /// Dominio al que pertenece el archivo
    /// </summary>
    [Protegido]
    public string DominioId { get; set; }
    // Este valor simpre viene del contexto
    // R 128

    /// <summary>
    /// Unidad organizacional a la que pertenece el archivo
    /// </summary>
    [Protegido]
    public string UOrgId { get; set; }
    //  Este valor simpre viene del contexto
    // R 128

    /// <summary>
    /// Tipo de archivo del catálogo
    /// </summary>
    [Tabla(indice: 0, visible: true)]
    [UsoCatalogoAttribute("TipoArchivo", true)]
    public string TipoArchivoId { get; set; }
    // [i] [a]
    // R 128

    /// <summary>
    /// Propiedades de navegacion
    /// </summary>

    [JsonIgnore]
    [XmlIgnore]
    public TipoArchivo TipoArchivo { get; set; }



    [JsonIgnore]
    [XmlIgnore]
    public List<AlmacenArchivo> Almacenes { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public List<ZonaAlmacen> Zonas { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public List<PosicionAlmacen> Posiciones { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public List<CajaAlmacen> Cajas { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public List<UnidadAdministrativa> UnidadAdministrativasTramite { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public List<UnidadAdministrativa> UnidadAdministrativasConcentracion { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public List<UnidadAdministrativa> UnidadAdministrativasHistorico { get; set; }

    /// <summary>
    /// Seria padre en el  modelo jerárquico
    /// </summary>
    [XmlIgnore, JsonIgnore]
    public List<Transferencia>? OrigenesTransferencias { get; set; }


    /// <summary>
    /// Seria padre en el  modelo jerárquico
    /// </summary>
    [XmlIgnore, JsonIgnore]
    public List<Transferencia>? DestinosTransferencias { get; set; }

    [XmlIgnore, JsonIgnore]
    public List<Prestamo>? Prestamos { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public Activo ActivoActual { get; set; }
    
    [JsonIgnore]
    [XmlIgnore]
    public Activo ActivoOrigen { get; set; }
}
