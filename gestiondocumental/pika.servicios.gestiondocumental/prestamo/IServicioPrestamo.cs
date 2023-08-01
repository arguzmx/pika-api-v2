using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.prestamo
{
    public interface IServicioPrestamo
    {

        Task<string> Crear(Prestamo prestamo);
        Task<ActionResult<List<Prestamo>>> Obtiener();
        Task<String> Actualizar(string id, Prestamo prestamo);
        Task<string> Eliminar(string id, Prestamo prestamo);
    }
}
