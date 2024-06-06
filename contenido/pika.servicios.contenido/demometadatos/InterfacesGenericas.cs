using api.comunes.modelos.servicios;
using pika.modelo.contenido;
using pika.modelo.contenido.demometadatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.contenido.demometadatos
{
    public interface IServicioDemoMetadatos : IServicioEntidadGenerica<DemoMetadatos, DemoMetadatosInsertar, DemoMetadatosActualizar, DemoMetadatosDespliegue, string>
    {
    }

}
