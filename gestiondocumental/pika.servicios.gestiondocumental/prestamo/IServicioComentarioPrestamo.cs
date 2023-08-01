using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.prestamo
{
    public interface IServicioComentarioPrestamo
    {
        Task<string> Crear(ComentarioPrestamo comentarioprestamo);
        Task<ActionResult<List<ComentarioPrestamo>>> Obtiener();
        Task<String> Actualizar(string id, ComentarioPrestamo comentarioprestamo);
        Task<string> Eliminar(string id, ComentarioPrestamo comentarioprestamo);
    }
}
