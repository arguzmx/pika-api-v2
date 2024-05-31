using api.comunes.modelos.servicios;
using pika.modelo.seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.seguridad.rol
{
    public interface IServicioRol : IServicioEntidadGenerica<Rol, RolInsertar, RolActualizar, RolDespliegue, string>
    {
    }
}
