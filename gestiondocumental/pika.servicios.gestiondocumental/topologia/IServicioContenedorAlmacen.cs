using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.topologia
{
    public interface IServicioContenedorAlmacen
    {
        Task<string> Crear(ContenedorAlmacen contenedoralmacen);
        Task<ActionResult<List<ContenedorAlmacen>>> Obtiener();
        Task<String> Actualizar(string id, ContenedorAlmacen contenedoralmacen);
        Task<string> Eliminar(string id, ContenedorAlmacen contenedoralmacen);
    }
}
