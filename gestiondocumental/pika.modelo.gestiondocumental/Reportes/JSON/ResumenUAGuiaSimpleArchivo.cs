namespace pika.modelo.gestiondocumental
{
    // public class UnidadAdministrativaGuiaSimpleArchivo : UnidadAdministrativaArchivo
    public class UnidadAdministrativaGuiaSimpleArchivo 
    {
        public UnidadAdministrativaGuiaSimpleArchivo()
        {
          //  Secciones = new List<SeccionGuiaSimpleArchivo>();
        }
        public int Expedientes { get; set; }
        public List<SeccionGuiaSimpleArchivo> Secciones { get; set; }
    }
}
