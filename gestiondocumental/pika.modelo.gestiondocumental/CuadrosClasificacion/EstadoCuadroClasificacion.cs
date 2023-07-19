namespace pika.modelo.gestiondocumental
{
    //public class EstadoCuadroClasificacion : EntidadCatalogo<string, EstadoCuadroClasificacion>
    public class EstadoCuadroClasificacion
    {
        public const string ESTADO_ACTIVO = "on";
        public const string ESTADO_INACTIVO = "off";
        

        public EstadoCuadroClasificacion()
        {
            //Cuadros = new HashSet<CuadroClasificacion>();
        }
        public  List<EstadoCuadroClasificacion> Seed() {
            
            List<EstadoCuadroClasificacion> l = new List<EstadoCuadroClasificacion>();
         //   l.Add(new EstadoCuadroClasificacion() { Id = ESTADO_ACTIVO, Nombre = "Activo" });
          //  l.Add(new EstadoCuadroClasificacion() { Id = ESTADO_INACTIVO, Nombre = "Inactivo" });
            return l;
            
        }

        public IEnumerable<CuadroClasificacion> Cuadros { get; set; }
    }
}
