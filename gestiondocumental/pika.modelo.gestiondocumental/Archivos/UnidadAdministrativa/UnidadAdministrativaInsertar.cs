using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.modelo.gestiondocumental.Archivos.UnidadAdministrativa;

public class UnidadAdministrativaInsertar
{
    /// <summary>
    /// Nombre de la unidad
    /// </summary>
    public string Nombre { get; set; }
    /// <summary>
    /// NOmbre del responsable de la unidad
    /// </summary>
    public string Responsable { get; set; }
    /// <summary>
    /// Cargo del responsable de la unidad
    /// </summary>
    public string Cargo { get; set; }
    /// <summary>
    /// Telefono de contacto de la unidad
    /// </summary>
    public string Telefono { get; set; }
    /// <summary>
    /// Email de contacto de la unidad
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Dirección postal de la unidad
    /// </summary>
    public string Domicilio { get; set; }
    /// <summary>
    /// Descripción de la ubicación física de la unidad
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
}
