using api.comunes.modelos.modelos;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental;

/// <summary>
/// Catálogo para la disposición documental
/// </summary>
[ExcludeFromCodeCoverage]
public class EstadoTransferencia : ElementoCatalogo
{
    [XmlIgnore, JsonIgnore]
    public List<Transferencia> Transferencias { get; set; }
}
