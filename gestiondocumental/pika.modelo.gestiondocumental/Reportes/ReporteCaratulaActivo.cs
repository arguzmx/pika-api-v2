﻿namespace pika.modelo.gestiondocumental
{
    // public class ReporteCaratulaActivo: IProveedorReporte
    public class ReporteCaratulaActivo
    {
        private const string nombre = "Carátula del activo";
        private const string url = "reporte/caratula/{id}";
        private const string id = "caratulaactivo";
       // private List<ParametroReporte> parametroes;
        //private List<FormatoReporte> formatos;

        public ReporteCaratulaActivo()
        {
            /*
            parametroes = new List<ParametroReporte>();
            formatos = new List<FormatoReporte>();

            parametroes.Add(new ParametroReporte()
            {
                Id = "id",
                Nombre = "Identificador único del activo",
                Tipo = TipoDato.tString,
                Contextual = true,
                IdContextual = ConstantesModelo.PREFIJO_CONEXTO + "Id"
            });

            formatos.Add(new FormatoReporte() { Id = FormatoReporte.WORD, Nombre = "Word" });

            this.Nombre = nombre;
            this.Url = url;
            this.Id = id;
            this.DatosJson = true;
            this.Parametros = parametroes;
            this.FormatosDisponibles = formatos;
            */
        }

        public bool DatosJson { get; set; }

        public string Id { get; set; }

        public string Nombre { get; set; }
        public string Url { get; set; }

       // public List<ParametroReporte> Parametros { get; set; }


       // public List<FormatoReporte> FormatosDisponibles { get; set; }
    }
}
