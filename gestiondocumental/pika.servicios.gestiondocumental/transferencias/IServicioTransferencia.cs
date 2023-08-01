using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.transferencias
{
    public interface IServicioTransferencia
    {
        Task<string> Crear(Transferencia transferencia);
        Task<ActionResult<List<Transferencia>>> Obtiener();
        Task<String> Actualizar(string id, Transferencia transferencia);
        Task<string> Eliminar(string id, Transferencia transferencia);
    }
}
