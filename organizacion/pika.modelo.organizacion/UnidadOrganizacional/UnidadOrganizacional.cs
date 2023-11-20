using pika.comun.metadatos.atributos;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.organizacion;

/// <summary>
/// Las unidades organizacionales agrupan recursos para la organización del trabajo
/// </summary>
/// 
[Entidad()]
[ExcludeFromCodeCoverage]
public class UnidadOrganizacional
{
    
    /// <summary>
    /// Identificador único de la UI
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// NOmbre de la unodad organizacional
    /// </summary>
    public string Nombre {get; set;}

    /// <summary>
    /// Identiicador único del dominio al que se asocia la UO, el sominio se lee del header de dominio especifico
    /// </summary>
    public string DominioId { get; set; }


    [JsonIgnore]
    [XmlIgnore]
    public Dominio Dominio { get; set; }


    [XmlIgnore]
    [JsonIgnore]
    public List<UsuarioUnidadOrganizacional> UsuariosUnidad { get; set; }

}
