using pika.comun.metadatos.atributos;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.organizacion
{
    /// <summary>
    /// Un dominio de datos es un contenedor lógico para todos los elementos relaciondso 
    /// con una instancia de gestión documental
    /// </summary>
    /// 
    [Entidad()]
public class Dominio
{
    /// <summary>
    ///  Identificdor únio del volumen
    ///  Se obtiene con GUID new
    /// </summary>
    public string Id { get; set; }
    // [a] [d] 
    // R 128

    /// <summary>
    /// Nombre único del volumen
    /// </summary>
    public string Nombre { get; set; }
    // [i] [a]
    // R 500

    /// <summary>
    /// Determina si el dominio se encuentra activo
    /// </summary>
    public bool Activo { get; set; } = true;
    // [i] [a]
    // R 


    [XmlIgnore]
    [JsonIgnore]
    public List<UsuarioDominio> UsuarioDominio { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public List<UnidadOrganizacional> UnidadesOrganizacionales { get; set; }

        //propiedad de navegacion agregaada para relacionar con UsuarioUnidadOrganizacional
        [XmlIgnore]
        [JsonIgnore]
        public List<UsuarioUnidadOrganizacional> UsuarioUnidadOrganizacionals { get; set; }
    }
}