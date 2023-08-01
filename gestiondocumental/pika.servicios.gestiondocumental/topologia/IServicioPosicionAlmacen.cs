using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.topologia
{
    public interface IServicioPosicionAlmacen
    {
        Task<string> Crear(PosicionAlmacen posicionalmacen);
        Task<ActionResult<List<PosicionAlmacen>>> Obtiener();
        Task<String> Actualizar(string id, PosicionAlmacen posicionalmacen);
        Task<string> Eliminar(string id, PosicionAlmacen posicionalmacen);
    }
}
