using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.transferencias
{
    public interface IServicioActivoTranferencia
    {
        Task<string> Crear(ActivoTransferencia activotransferencia);
        Task<ActionResult<List<ActivoTransferencia>>> Obtiener();
        Task<String> Actualizar(string id, ActivoTransferencia activotransferencia) ;
        Task<string> Eliminar(string id, ActivoTransferencia activotransferencia);
    }
}
