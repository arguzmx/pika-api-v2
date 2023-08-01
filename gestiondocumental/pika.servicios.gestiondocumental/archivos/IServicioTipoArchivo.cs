using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.archivos
{
    public interface IServicioTipoArchivo
    {
        Task<string> Crear(TipoArchivo tipoarchivo);
        Task<ActionResult<List<TipoArchivo>>> Obtiener();
        Task<String> Actualizar(string id, TipoArchivo tipoarchivo);
        Task<string> Eliminar(string id, TipoArchivo tipoarchivo);
    }
}
