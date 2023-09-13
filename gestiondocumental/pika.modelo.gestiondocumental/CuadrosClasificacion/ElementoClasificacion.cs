namespace pika.modelo.gestiondocumental
{

    /// <summary>
    /// Los elementos de clasificación consituyen la estructura jerárquca para acaomodar las entradas del cuadro
    /// </summary>
    /*
     public class ElementoClasificacion : Entidad<string>, IEntidadNombrada, 
        IEntidadEliminada, IEntidadJerarquica
    */

    public class ElementoClasificacion 
    {

        public ElementoClasificacion() {
            /*
            Padre = null;
            Hijos = new HashSet<ElementoClasificacion>();
            Entradas = new HashSet<EntradaClasificacion>();
            */
        }

     
        public string Id { get; set; }


        /// <summary>
        /// Clave asociada el elemento de clasifaición por ejemplo 1.S
        /// </summary>
        public string Clave { get; set; }

        /// <summary>
        /// Nombre del elemento de clasifiación debe ser único en para los elemntos de un mismo padre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Indica si el elemento ha sido marcado para eliminaciónrai
        /// </summary>
        public bool Eliminada { get; set; }

        /// <summary>
        /// Determina la posición relativa del elemento en relación con los elementos del mismo nivle
        /// </summary>
        public int Posicion { get; set; }

        /// <summary>
        /// Cuadro de clasificación al que pertenecen los elementos
        /// </summary>
        public string CuadroClasifiacionId { get; set; }


        /// <summary>
        /// Padre  del elemento actual 
        /// </summary>
        public string ElementoClasificacionId { get; set; }

        /// <summary>
        /// Indica si el elemento es un elemnto raiz
        /// </summary>
        public bool EsRaiz { get; set; }

        /*
        public string NombreJerarquico { get {
                return this.Nombre;
            } }
        /*

        /// <summary>
        /// Elemento padre del actual
        /// </summary>
        public virtual ElementoClasificacion Padre { get; set; }

        /// <summary>
        /// Elementos descencientes del elemento actual
        /// </summary>
        public virtual ICollection<ElementoClasificacion> Hijos { get; set; }

        /// <summary>
        /// Instancia del cuadro de clasificación
        /// </summary>
        public virtual CuadroClasificacion CuadroClasificacion { get; set; }


        /// <summary>
        /// Activos del elemento clasificacion
        /// </summary>
        public virtual ICollection<EntradaClasificacion> Entradas { get; set; }
        */
    }
}
