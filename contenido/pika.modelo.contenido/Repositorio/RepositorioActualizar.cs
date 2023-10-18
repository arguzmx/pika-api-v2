
namespace pika.modelo.contenido.Repositorio;

public class RepositorioActualizar
{
    /// <summary>
    ///  Identificdor únio del repositorio
    ///  Se obtiene con GUID new
    /// </summary>
    public string Id { get; set; }


    /// <summary>
    /// Nombre del repositorio 
    /// </summary>
    public string Nombre { get; set; }



    /// <summary>
    /// Volumen para almacenar los archivos relacionado con el contenido
    /// </summary>
    public string VolumenId { get; set; }

}
