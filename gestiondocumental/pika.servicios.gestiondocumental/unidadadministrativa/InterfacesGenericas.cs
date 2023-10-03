using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental.Archivos;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pika.modelo.gestiondocumental.Archivos.UnidadAdministrativa;

namespace pika.servicios.gestiondocumental.unidadadministrativa;

/// <summary>
/// Interfaz para el servicio de archivos
/// </summary>
public interface IServicioUnidadAdministrativa : IServicioEntidadGenerica<UnidadAdministrativa, UnidadAdministrativaInsertar, UnidadAdministrativaActualizar, UnidadAdministrativaDespliegue, string>
{
}
