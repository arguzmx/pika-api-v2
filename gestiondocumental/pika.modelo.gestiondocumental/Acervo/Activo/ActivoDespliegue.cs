using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.modelo.gestiondocumental;

public class ActivoDespliegue
{
    public string Id { get; set; }
    public string CuadroClasificacionId { get; set; }
    public string SerieDocumentalId { get; set; }
    public string ArchivoOrigenId { get; set; }
    public string ArchivoActualId { get; set; } 
    public string TipoArchivoActualId { get; set; }
    public string UnidadAdministrativaId { get; set; }
    public string Nombre { get; set; }
    public string? IdentificadorInterno { get; set; }
    public DateTime FechaApertura { get; set; }
    public DateTime? FechaCierre { get; set; }
    public string? Asunto { get; set; }
    public string? CodigoOptico { get; set; }
    public string? CodigoElectronico { get; set; }
    public bool EsElectronico { get; set; } = false;
    public bool Reservado { get; set; } = false;
    public bool Confidencial { get; set; } = false;
    public string? UbicacionCaja { get; set; }
    public string? UbicacionRack { get; set; }
    public bool EnPrestamo { get; set; } = false;
    public bool EnTransferencia { get; set; } = false;
    public bool Ampliado { get; set; } = false;
    public DateTime? FechaRetencionAT { get; set; }
    public DateTime? FechaRetencionAC { get; set; }
    public string? AlmacenArchivoId { get; set; }
    public string? ZonaAlmacenId { get; set; }
    public string? ContenedorAlmacenId { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public string UsuarioId { get; set; }
}
