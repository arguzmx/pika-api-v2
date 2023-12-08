using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.cuadroclasificacion
{
    public interface IServicioCuadroclasificacion : IServicioEntidadGenerica<CuadroClasificacion,CuadroClasificacionInsertar,CuadroClasificacionActualizar, CuadroClasificacionDespliegue, string>
    {
    }
}
