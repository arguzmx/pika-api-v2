namespace pika.modelo.gestiondocumental
{
    //public class PermisosUnidadAdministrativaArchivo : Entidad<string>
    public class PermisoArchivo
    {
        /// <summary>
        /// Indetificador único del permiso
        /// </summary>
        public  string Id { get; set; }


        public string UnidadAdministrativaArchivoId { get; set; }

        /// <summary>
        /// Identificador único del ROL destinatario del permiso
        /// </summary>
        public string DestinatarioId { get; set; }


        /// <summary>
        /// Determina el permiso para leer datos del acervo de la unidad
        /// </summary>
        public bool LeerAcervo { get; set; }

        /// <summary>
        /// Determina el permiso para crear acervo en la unidad
        /// </summary>
        public bool CrearAcervo { get; set; }

        /// <summary>
        /// Determina el permiso para actualizar acervo en la unidad
        /// </summary>
        public bool ActualizarAcervo { get; set; }
        
        /// <summary>
        /// Determina el permiso para elminar acervo de la unidad
        /// </summary>
        public bool ElminarAcervo { get; set; }

       // public UnidadAdministrativaArchivo UnidadAdministrativaArchivo { get; set; }
    }
}
