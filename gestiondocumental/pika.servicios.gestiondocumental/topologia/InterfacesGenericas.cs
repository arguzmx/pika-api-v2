using api.comunes.modelos.reflectores;
using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental.Archivos;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pika.modelo.gestiondocumental.Topologia;

namespace pika.servicios.gestiondocumental.topologia
{
    public interface InterfaceServicioAlmacenArchivo  : IServicioEntidadGenerica<AlmacenArchivo, AlmacenArchivoInsertar,AlmacenArchivoActualizar,AlmacenArchivoDespliegue,string>  
    {
    }
}


