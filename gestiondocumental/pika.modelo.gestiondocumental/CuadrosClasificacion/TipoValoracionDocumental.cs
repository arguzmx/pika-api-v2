namespace pika.modelo.gestiondocumental
{
    //  public class TipoValoracionDocumental: EntidadCatalogo<string, TipoValoracionDocumental>
    public class TipoValoracionDocumental
    {
        public const string ADMINISTRATIVA = "admin";
        public const string LEGAL = "legal";
        public const string FISCAL = "fiscal";
        //public const string TESTIMONIAL = "testimonial";
        //public const string EVIDENCIAL = "evidencial";
        //public const string INFORMATIVA = "evidencial";


        public TipoValoracionDocumental()
        {
           // ValoracionEntradas = new HashSet<ValoracionEntradaClasificacion>();
        }

        public  string Id { get; set; }

        public  string Nombre { get; set; }

        /// <summary>
        /// Identificaor único del dominio al que pertenece el catáloco
        /// </summary>
        public string DominioId { get; set; }

        /// <summary>
        /// Identificaor único de la unidad  organizacional al que pertenece el catáloco
        /// </summary>
        public string UOId { get; set; }



        public  List<TipoValoracionDocumental> Seed()
        {
            List<TipoValoracionDocumental> lista = new List<TipoValoracionDocumental>();

            lista.Add(new TipoValoracionDocumental() { Id = ADMINISTRATIVA, Nombre = "Administrativa" });
            lista.Add(new TipoValoracionDocumental() { Id = LEGAL, Nombre = "Legal" });
            lista.Add(new TipoValoracionDocumental() { Id = FISCAL, Nombre = "Fiscal" });
            //lista.Add(new TipoValoracionDocumental() { Id = TESTIMONIAL, Nombre = "Testimonial" });
            //lista.Add(new TipoValoracionDocumental() { Id = EVIDENCIAL, Nombre = "Evidencial" });
            //lista.Add(new TipoValoracionDocumental() { Id = INFORMATIVA, Nombre = "Informativa" });
            
            return lista;
        }

   
        public ICollection<ValoracionEntradaClasificacion> ValoracionEntradas { get; set; }
    }
}
