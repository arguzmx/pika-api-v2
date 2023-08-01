namespace pika.modelo.gestiondocumental
{
    // public class UnidadAdministrativaArchivo : Entidad<string>, IEntidadRelacionada
    public class UnidadAdministrativaArchivo 
    {
        public UnidadAdministrativaArchivo()
        {
            //Permisos = new HashSet<PermisosUnidadAdministrativaArchivo>();
        }

        //public string TipoOrigenDefault => ConstantesModelo.IDORIGEN_UNIDAD_ORGANIZACIONAL;

   
        public  string Id { get; set; }

 
        public string UnidadAdministrativa { get; set; }

       
        public string AreaProcedenciaArchivo { get; set; }

      
        public string Responsable { get; set; }

        
        public string Cargo { get; set; }


       
        public string Telefono { get; set; }


       
        public string Email { get; set; }


   
        public string Domicilio { get; set; }

    
        public string UbicacionFisica { get; set; }


        /// <summary>
        /// Identificador único del archivo de trámite donde se crearán los activos del acervo
        /// </summary>
        public string ArchivoTramiteId { get; set; }

        /// <summary>
        /// Identificador único del archivo de concentración donde se crearán los activos del acervo
        /// </summary>
        public string ArchivoConcentracionId { get; set; }

        /// <summary>
        /// Identificador único del archivo histórico donde se crearán los activos del acervo
        /// </summary>
        public string ArchivoHistoricoId { get; set; }

        /// <summary>
        /// El tipo de orígen en para este modelo es el elemento de la unidad organizacional 
        /// Este elemento puede ser unn departamento u oficina que tiene acervo as su cargo
        /// </summary>
        public string TipoOrigenId { get; set; }

        /// <summary>
        /// Identificador de la organización a la que pertenece el cuadro de clasificación
        /// </summary>
        public string OrigenId { get; set; }

        /*
        public Archivo ArchivoTramite { get; set; }

        public Archivo ArchivoConcentracion { get; set; }

        public Archivo ArchivoHistorico { get; set; }

        public ICollection<Activo> Activos { get; set; }

        public ICollection<PermisosUnidadAdministrativaArchivo> Permisos { get; set; }

        public List<EstadisticaClasificacionAcervo> EstadisticasClasificacionAcervo { get; set; }
        */
    }
}
