namespace pika.modelo.gestiondocumental
{
    public class GuiaSimpleArchivo
    {
        public GuiaSimpleArchivo()
        {
            UnidadesAdministrativas = new List<UnidadAdministrativaGuiaSimpleArchivo>();
        }

        public Archivo Archivo { get; set; }
        public List<UnidadAdministrativaGuiaSimpleArchivo> UnidadesAdministrativas { get; set; }

    }
}
