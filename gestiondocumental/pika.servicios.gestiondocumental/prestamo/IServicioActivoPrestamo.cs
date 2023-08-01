using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.prestamo
{
    public interface IServicioActivoPrestamo
    {
        Task<string> Crear(ActivoPrestamo activoprestamo);
        Task<ActionResult<List<ActivoPrestamo>>> Obtiener();
        Task<String> Actualizar(string id, ActivoPrestamo activoprestamo);
        Task<string> Eliminar(string id, ActivoPrestamo activoprestamo);
    }
}
