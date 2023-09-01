using pika.comun.metadatos.atributos;

namespace pika.modelo.gestiondocumental
{
    [Entidad()]
    public class Archivo
    {
      
        public Archivo()
        {
        }


        /// <summary>
        /// Identificador único del archivo
        /// </summary>
        [Id]
        public string Id { get; set; }

        /// <summary>
        /// Nombre del archivo
        /// </summary>
        [Nombre]
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


        /// <summary>
        /// Tipo de archivo 
        /// </summary>
        // public virtual TipoArchivo Tipo { get; set; }


        /// <summary>
        /// Alamcenes físicos que tiene al archivo bajo su control
        /// </summary>


        /*
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
        */
    }
}
