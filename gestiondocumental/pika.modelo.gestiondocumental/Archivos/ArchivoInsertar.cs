namespace pika.modelo.gestiondocumental.Archivos;

public class ArchivoInsertar
{ 
    /// <summary>
    /// Nombre del archivo
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Dominio al que pertenece el archivo
    /// </summary>
    public string DominioId { get; set; }

    /// <summary>
    /// Unidad organizacional a la que pertenece el archivo
    /// </summary>
    public string UOrgId { get; set; }

    /// <summary>
    /// Tipo de archivo del catálogo
    /// </summary>
    public string TipoArchivoId { get; set; }

    /// <summary>
    /// Volument asociado al archivo para el resguardo de contenido eléctrónico
    /// </summary>
    public string? VolumenDefaultId { get; set; }

    /// <summary>
    /// Punto de montaje para mostrar el cotntenido electrónico
    /// </summary>
    public string? PuntoMontajeId { get; set; }
}
