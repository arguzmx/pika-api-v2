using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.transferencias
{
    public interface IServicioEventoTransferencia
    {

        Task<string> Crear(EventoTransferencia eventotransferencia);
        Task<ActionResult<List<EventoTransferencia>>> Obtiener();
        Task<String> Actualizar(string id, EventoTransferencia eventotransferencia);
        Task<string> Eliminar(string id, EventoTransferencia eventotransferencia);

    }
}
