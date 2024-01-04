using api.comunes.modelos.servicios;
using pika.modelo.contenido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.contenido.contenido;
/// <summary>
/// Interface servicio contenido
/// </summary>
public interface IServicioContenido : IServicioEntidadGenerica<Contenido, ContenidoInsertar, ContenidoActualizar, ContenidoDespliegue, string>
{
}
