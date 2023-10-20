using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental.Acervo.Activo.Activo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.acervo
{
    public interface IServicioActivo : IServicioEntidadGenerica<Activo,ActivoInsertar,ActivoActualizar,ActivoDespliegue, string>
    {
    }
}
