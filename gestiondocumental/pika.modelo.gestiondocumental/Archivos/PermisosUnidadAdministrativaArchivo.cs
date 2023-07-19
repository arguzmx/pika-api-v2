namespace pika.modelo.gestiondocumental
{
    // public class PermisosArchivo : Entidad<string>
    public class PermisosArchivo
    {
        /// <summary>
        /// Indetificador único del permiso
        /// </summary>
      
        public string Id { get; set; }

        
        public string ArchivoId { get; set; }

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


       
        public bool CrearTrasnferencia { get; set; }

        
        public bool EliminarTrasnferencia { get; set; }


        public bool EnviarTrasnferencia { get; set; }


       
        public bool CancelarTrasnferencia { get; set; }


      
        public bool RecibirTrasnferencia { get; set; }


        public Archivo Archivo { get; set; }

    }
}
