﻿namespace pika.modelo.gestiondocumental
{
    // public class ReportePrestamo : IProveedorReporte
    public class ReportePrestamo 
    {


        private const string nombre = "Reporte préstamo";
        private const string url = "reporte/prestamo/{id}";
        private const string id = "reporte-prestamo";
        //private List<ParametroReporte> parametroes;
        //private List<FormatoReporte> formatos;

        public ReportePrestamo()
        {
            /*
            parametroes = new List<ParametroReporte>();
            formatos = new List<FormatoReporte>();

            parametroes.Add(new ParametroReporte()
            {
                Id = "id",
                Nombre = "Identificador único del prestamo",
                Tipo = TipoDato.tString,
                Contextual = true,
                IdContextual = ConstantesModelo.PREFIJO_CONEXTO + "Id"
            });

            formatos.Add(new FormatoReporte() { Id = FormatoReporte.CSV, Nombre = "CSV" });

            this.Nombre = nombre;
            this.Url = url;
            this.Id = id;
            this.DatosJson = false;
            this.Parametros = parametroes;
            this.FormatosDisponibles = formatos;
*/
        }

        public bool DatosJson { get; set; }

        public string Id { get; set; }

        public string Nombre { get; set; }
        public string Url { get; set; }

        //public List<ParametroReporte> Parametros { get; set; }

        //public List<FormatoReporte> FormatosDisponibles { get; set; }

    }
}
