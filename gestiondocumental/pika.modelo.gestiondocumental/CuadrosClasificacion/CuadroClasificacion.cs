namespace pika.modelo.gestiondocumental
{
    /*
      public class CuadroClasificacion : Entidad<string>, IEntidadNombrada, IEntidadEliminada, 
         IEntidadRelacionada, IEntidadReportes
     */
    public class CuadroClasificacion 
    {

   
       // public string TipoOrigenDefault => ConstantesModelo.IDORIGEN_DOMINIO;

        public CuadroClasificacion()
        {
            /*
            this.TipoOrigenId = this.TipoOrigenDefault;
            this.Elementos = new HashSet<ElementoClasificacion>();
            this.Reportes = new List<IProveedorReporte>();
            this.Reportes.Add(new ReporteCuadroClasificacion());
            */
        }


        /// <summary>
        /// Identificador únioc del cuadro de clasificación
        /// </summary>

       
        public string Id { get; set; }

        /// <summary>
        /// Nombre único del cuadro de clasificación
        /// </summary>
        public string Nombre { get ; set ; }

        /// <summary>
        /// Identificaidor del estado del cuadro de clasificación
        /// </summary>
        public string EstadoCuadroClasificacionId { get; set; }

        /// <summary>
        /// Especifica si el elemento ha sido marcado como eliminado
        /// </summary>
        public bool Eliminada { get; set; }


        /// <summary>
        /// El tipo de orígen en para este modelo es el dominio a la que pertenece el cuadro de clasificacion
        /// </summary>
        public string TipoOrigenId { get; set; }


        /// <summary>
        /// Identificador de la organización a la que pertenece el cuadro de clasificación
        /// </summary>
        public string OrigenId { get; set; }




        /// <summary>
        /// Esatdo del cuadro de clasificación
        /// </summary>
        public virtual EstadoCuadroClasificacion Estado { get; set; }


        public virtual ICollection<ElementoClasificacion> Elementos { get; set; }



        public List<Transferencia> Transferencias { get; set; }


        public List<Activo> Activos { get; set; }


        //public List<IProveedorReporte> Reportes { get; set; }


        public List<EstadisticaClasificacionAcervo> EstadisticasClasificacionAcervo { get; set; }
    }
}
