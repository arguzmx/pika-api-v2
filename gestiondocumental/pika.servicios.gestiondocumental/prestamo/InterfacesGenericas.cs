using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.prestamo
{
    public interface IServicioPrestamo:
    IServicioEntidadGenerica<Prestamo, PrestamoInsertar, PrestamoActualizar, PrestamoDespliegue,string>    
    {
    }
}
