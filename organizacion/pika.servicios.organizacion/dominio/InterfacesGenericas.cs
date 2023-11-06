using api.comunes.modelos.servicios;
using pika.modelo.organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.organizacion.dominio
{
    public interface IServicioDominio : IServicioEntidadGenerica<Dominio,DominioInsertar,DominioActualizar,DominioDespliegue,string>
        { 
        }

    
    
}
