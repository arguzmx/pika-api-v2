using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.cuadrosclasificacion
{
    public interface IServicioElementoClasificacion
    {
        Task<string> Crear(ElementoClasificacion elementoclasificacion);
        Task<ActionResult<List<ElementoClasificacion>>> Obtiener();
        Task<String> Actualizar(string id, ElementoClasificacion elementoclasificacion);
        Task<string> Eliminar(string id, ElementoClasificacion elementoclasificacion);

    }
}
