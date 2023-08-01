using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.archivos
{
    public interface IServicioArchivo
    {
        Task<string> Crear(Archivo archivo);
        Task<ActionResult<List<Archivo>>> Obtiener();
        Task<String> Actualizar(string id, Archivo archivo);
        Task<string> Eliminar(string id, Archivo archivo);
    }
}
