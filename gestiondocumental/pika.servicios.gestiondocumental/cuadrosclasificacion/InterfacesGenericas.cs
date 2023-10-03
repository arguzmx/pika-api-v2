using api.comunes.modelos.servicios;
using pika.modelo.gestiondocumental.Archivos;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pika.modelo.gestiondocumental.CuadrosClasificacion.CuadroClasificacion;

namespace pika.servicios.gestiondocumental.cuadrosclasificacion
{
    /// <summary>
    /// Interfaz para el servicio de archivos
    /// </summary>
    public interface IServicioCuadroClasificacion : IServicioEntidadGenerica<CuadroClasificacion, CuadroClasificacionInsertar, CuadroClasificacionActualizar, CuadroClasificacionDespliegue, string>
    {
    }
}
