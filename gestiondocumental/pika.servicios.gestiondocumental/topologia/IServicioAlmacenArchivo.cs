using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.topologia
{
    public interface IServicioAlmacenArchivo
    {
        Task<string> Crear(AlmacenArchivo almacenarchivo);
        Task<ActionResult<List<AlmacenArchivo>>> Obtiener();
        Task<String> Actualizar(string id, AlmacenArchivo almacenarchivo);
        Task<string> Eliminar(string id, AlmacenArchivo almacenarchivo);
    }
}
