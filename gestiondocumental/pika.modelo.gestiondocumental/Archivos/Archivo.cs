namespace pika.modelo.gestiondocumental
{
     /*
        public class Archivo : Entidad<string>, IEntidadNombrada, IEntidadEliminada, 
        IEntidadRelacionada, IEntidadReportes
     */

    public class Archivo
    {
       // public string TipoOrigenDefault => ConstantesModelo.IDORIGEN_UNIDAD_ORGANIZACIONAL;

        /// <summary>
        /// Espacio físico en el que se deposita la 
        /// documentación que lo conforma, es decir, el archivo como
        /// depósito.
        /// </summary>
        public Archivo()
        {
            /*
            this.Almacenes = new HashSet<AlmacenArchivo>();
            this.Activos = new HashSet<Activo>();
            HistorialArchivosActivo = new HashSet<HistorialArchivoActivo>();
            Prestamos = new HashSet<Prestamo>();
            TransferenciasOrigen = new HashSet<Transferencia>();
            TransferenciasDestino = new HashSet<Transferencia>();
            ZonasAlmacen = new List<ZonaAlmacen>();
            PosicionesAlmacen = new List<PosicionAlmacen>();
            Contenedores = new List<ContenedorAlmacen>();

            this.Reportes = new List<IProveedorReporte>();
            this.Reportes.Add(new ReporteGuiaSimpleArchivo());
            this.Reportes.Add(new ReporteInventario());
            */
        }

        public string Id { get; set; }

        /// <summary>
        /// Nombre único del cuadro de clasificación
        /// </summary>

        public string Nombre { get; set; }

        /// <summary>
        /// Especifica si el elemento ha sido marcado como eliminado
        /// </summary>

        public bool Eliminada { get; set; }

        /// <summary>
        /// El tipo de orígen en para este modelo es el elemento de la unidad organizacional 
        /// Este elemento puede ser unn departamento u oficina que tiene acervo as su cargo
        /// </summary>

        public string TipoOrigenId { get; set; }

        /// <summary>
        /// Identificador de la organización a la que pertenece el archivo
        /// </summary>

        public string OrigenId { get; set; }


        /// <summary>
        /// IDentificador del tipo de archivo
        /// </summary>

        public string TipoArchivoId { get; set; }


        /// <summary>
        /// Tipo de archivo 
        /// </summary>
        public virtual TipoArchivo Tipo { get; set; }



        public string VolumenDefaultId { get; set; }



        public string PuntoMontajeId { get; set; }

        /// <summary>
        /// Alamcenes físicos que tiene al archivo bajo su control
        /// </summary>
        //public virtual ICollection<AlmacenArchivo> Almacenes { get; set; }


        /// <summary>
        /// Historial movimientos de activos en el archivo
        /// </summary>

        public virtual ICollection<HistorialArchivoActivo> HistorialArchivosActivo { get; set; }


        /// <summary>
        /// Todos los activos que se encuentran en un archivo
        /// </summary>

        public virtual ICollection<Activo> Activos { get; set; }

        public virtual ICollection<Activo> ActivosOrigen { get; set; }

        /// <summary>
        /// Prestamos realizados en el archivo
        /// </summary>

        public virtual ICollection<Prestamo> Prestamos { get; set; }

        /// <summary>
        /// Almacenes donde se encuentra en el archivo
        /// </summary>

        public virtual ICollection<AlmacenArchivo> Almacenes { get; set; }

        /// <summary>
        /// Transferencias realizadoas en el archivo
        /// </summary>

        public virtual ICollection<Transferencia> TransferenciasOrigen { get; set; }

        public virtual ICollection<Transferencia> TransferenciasDestino { get; set; }

      //  public List<IProveedorReporte> Reportes { get; set; }


        public List<UnidadAdministrativaArchivo> UnidadesTramite { get; set; }


        public List<UnidadAdministrativaArchivo> UnidadesConcentracion { get; set; }

        public List<UnidadAdministrativaArchivo> UnidadesHistorico { get; set; }


        public List<EstadisticaClasificacionAcervo> EstadisticasClasificacionAcervo { get; set; }


        public List<ZonaAlmacen> ZonasAlmacen { get; set; }

        public List<PosicionAlmacen> PosicionesAlmacen { get; set; }

        public List<ContenedorAlmacen> Contenedores { get; set; }

        public List<PermisosArchivo> PermisosArchivo { get; set; }
    }
}
