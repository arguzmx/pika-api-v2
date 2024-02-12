using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental;
using pika.modelo.gestiondocumental.UnidadesAdministrativas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.unidadesadministrativas
{
    public interface IServicioUnidadAdministrativa : IServicioEntidadGenerica<UnidadAdministrativa, UnidadAdministrativaInsertar, UnidadAdministrativaActualizar, UnidadAdministrativaDespliegue, string>
    {

    }
}
