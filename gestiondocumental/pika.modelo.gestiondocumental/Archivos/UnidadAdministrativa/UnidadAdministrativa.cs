using pika.comun.metadatos.atributos;

namespace pika.modelo.gestiondocumental;


/// <summary>
/// REpresenta una unidad administrativa que produce activos de acervo a gestionar
/// </summary>
[Entidad()]
public class UnidadAdministrativa
{

    /// <summary>
    /// Identificador único de la unidad administrativa
    /// </summary>
    public string Id { get; set; }
    // [a] [d] 
    // R 128

    /// <summary>
    /// Nombre de la unidad
    /// </summary>
    public string Nombre { get; set; }
    // [i] [a] 
    // R 128

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
    /// NOmbre del responsable de la unidad
    /// </summary>
    public string Responsable { get; set; }
    // [i] [a] 
    // 250

    /// <summary>
    /// Cargo del responsable de la unidad
    /// </summary>
    public string Cargo { get; set; }
    // [i] [a] 
    // 250

    /// <summary>
    /// Telefono de contacto de la unidad
    /// </summary>
    public string Telefono { get; set; }
    // [i] [a] 
    // 50

    /// <summary>
    /// Email de contacto de la unidad
    /// </summary>
    public string Email { get; set; }
    // [i] [a] 
    // 250

    /// <summary>
    /// Dirección postal de la unidad
    /// </summary>
    public string Domicilio { get; set; }
    // [i] [a] 
    // 500

    /// <summary>
    /// Descripción de la ubicación física de la unidad
    /// </summary>
    public string UbicacionFisica { get; set; }
    // [i] [a] 
    // 500

    /// <summary>
    /// Identificador único del archivo de trámite donde se crearán los activos del acervo
    /// </summary>
    public string? ArchivoTramiteId { get; set; }
    // [i] [a] 
    // 128

    /// <summary>
    /// Identificador único del archivo de concentración donde se crearán los activos del acervo
    /// </summary>
    public string? ArchivoConcentracionId { get; set; }
    // [i] [a] 
    // 128

    /// <summary>
    /// Identificador único del archivo histórico donde se crearán los activos del acervo
    /// </summary>
    public string? ArchivoHistoricoId { get; set; }
    // [i] [a] 
    // 128


    // Propiedades de navegación
    // ======================================================
    // ======================================================

    /// <summary>
    /// Archivo de trámite asignado
    /// </summary>
    public Archivo? ArchivoTramite { get; set; }

    /// <summary>
    /// Archivo de concentración asignado
    /// </summary>
    public Archivo? ArchivoConcentracion { get; set; }

    /// <summary>
    /// Archivo de histórico asignado
    /// </summary>
    public Archivo? ArchivoHistorico { get; set; }



    // Propiedades de pendientes
    // ======================================================
    // ======================================================


    /*

    public ICollection<Activo> Activos { get; set; }

    public ICollection<PermisosUnidadAdministrativaArchivo> Permisos { get; set; }

    public List<EstadisticaClasificacionAcervo> EstadisticasClasificacionAcervo { get; set; }
    */
}
