using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.modelo.gestiondocumental.Topologia
{
    public class PosicionAlmacenActualizar
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Indice { get; set; } = 0;
        public string? Localizacion { get; set; }
        public string? CodigoBarras { get; set; }
        public string? CodigoElectronico { get; set; }
        public decimal Ocupacion { get; set; } = 0;
        public decimal IncrementoContenedor { get; set; } = 0;

    }
}
