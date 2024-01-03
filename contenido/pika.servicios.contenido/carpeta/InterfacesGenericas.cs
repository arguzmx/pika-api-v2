using api.comunes.modelos.servicios;
using pika.modelo.contenido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.contenido.carpeta;

/// <summary>
/// Interface servicio carpeta
/// </summary>
public interface IServicioCarpeta : IServicioEntidadGenerica<Carpeta, CarpetaInsertar, CarpetaActualizar, CarpetaDespliegue, string>
{
}
