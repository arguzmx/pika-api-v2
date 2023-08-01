using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.topologia
{
    public interface IServicioActivoContenedorAlmacen
    {
        Task<string> Crear(ActivoContenedorAlmacen activocontenedoralmacen);
        Task<ActionResult<List<ActivoContenedorAlmacen>>> Obtiener();
        Task<String> Actualizar(string id, ActivoContenedorAlmacen activocontenedoralmacen);
        Task<string> Eliminar(string id, ActivoContenedorAlmacen activocontenedoralmacen);
    }
}
