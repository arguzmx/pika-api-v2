namespace pika.modelo.gestiondocumental
{
    //   public class PosicionAlmacen : Entidad<string>, IEntidadNombrada
    public class PosicionAlmacen 
    {
        public PosicionAlmacen()
        {
            /*
            Posiciones = new List<PosicionAlmacen>();
            Contenedores = new List<ContenedorAlmacen>();
            IncrementoContenedor = 0;
            Ocupacion = 0;
            */
        }


        public string Id { get; set; }

        /// <summary>
        /// Nombre único de la posición de almacé
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Indice de la posicion en la osición padre
        /// </summary>
        public int Indice { get; set; }

        /// <summary>
        /// Nombre único de la posición de almacé
        /// </summary>
        public string Localizacion { get; set; }


        /// <summary>
        /// Codigo de barras asociado
        /// </summary>
        public string CodigoBarras { get; set; }

        /// <summary>
        /// Codigo electrónico asociado
        /// </summary>
        public string CodigoElectronico { get; set; }

        /// <summary>
        /// Porcentaje de ocupación de la posición
        /// </summary>
        public decimal Ocupacion { get; set; }


        /// <summary>
        /// Incremento automático de porcentaje de ocupación de la posición al adiconar o remover un contenedor
        /// </summary>
        public decimal IncrementoContenedor { get; set; }


        /// <summary>
        /// Identificaodr único del archivo al qu pertenece la posición
        /// </summary>
        public string ArchivoId { get; set; }


        /// <summary>
        /// Identificador unico del almacen al que pertenece la posición
        /// </summary>
        public string AlmacenArchivoId { get; set; }


        /// <summary>
        /// Identificador unico de la zona a la que pertenece la posición
        /// </summary>
        public string ZonaAlmacenId { get; set; }



        /// <summary>
        /// Identificador unico de la posición padre para el elemento
        /// NO APLICA, PARA FACILITAR EL MANTENIMIENTO LOS POSICIONES HIJAS DE UN ALMACEN SE BASAN EN EL CAMPO INDICE
        /// </summary>
        public string PosicionPadreId { get; set; }



        public PosicionAlmacen PosicionPadre { get; set; }



        public ZonaAlmacen Zona { get; set; }


        public AlmacenArchivo Almacen { get; set; }


        public Archivo Archivo { get; set; }
        

        public List<PosicionAlmacen> Posiciones { get; set; }


        public List<ContenedorAlmacen> Contenedores { get; set; }
    }
}
