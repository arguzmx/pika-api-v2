using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.modelo.gestiondocumental;

public class ActivoActualizar
{
    public string Id { get; set; }
    public string CuadroClasificacionId { get; set; }
    public string SerieDocumentalId { get; set; }
    public string ArchivoOrigenId { get; set; }
    public string ArchivoActualId { get; set; }
    public string UnidadAdministrativaId { get; set; }
    public string Nombre { get; set; }
    public string? IdentificadorInterno { get; set; }
    public DateTime FechaApertura { get; set; }
    public DateTime? FechaCierre { get; set; }
    public string? Asunto { get; set; }
    public string? CodigoOptico { get; set; }
    public string? CodigoElectronico { get; set; }
    public bool EsElectronico { get; set; } = false;
    public string? UbicacionCaja { get; set; }
    public string? UbicacionRack { get; set; }
}
