using api.comunes.modelos.servicios;
using pika.modelo.seguridad;
using pika.modelo.seguridad.permiso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.seguridad.permiso
{
    public interface IServicioPermiso : IServicioEntidadGenerica<Permiso, PermisoInsertar, PermisoActualizar, PermisoDespliegue, string>
    {
    }
}
