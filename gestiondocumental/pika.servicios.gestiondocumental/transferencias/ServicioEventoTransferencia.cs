using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.transferencias
{
    public class ServicioEventoTransferencia : IServicioEventoTransferencia
    {

        private readonly ILogger<ServicioEventoTransferencia> _logger;
        private readonly PIKADbContext PikaContext;

        public ServicioEventoTransferencia(ILogger<ServicioEventoTransferencia> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }


        public async Task<string> Crear(EventoTransferencia eventotransferencia)
        {
            var existeMismoId = await PikaContext.EventoTransferencias.AnyAsync(x => x.TransferenciaId == eventotransferencia.TransferenciaId);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.EventoTransferencias.Add(eventotransferencia);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }


        public async Task<ActionResult<List<EventoTransferencia>>> Obtiener()
        {
            return await PikaContext.EventoTransferencias.ToListAsync();
        }


        public async Task<String> Actualizar(string id, EventoTransferencia eventotransferencia)
        {
            var existeMismoId = await PikaContext.EventoTransferencias.AnyAsync(x => x.TransferenciaId == eventotransferencia.TransferenciaId);
            if (existeMismoId != null)
            {
                PikaContext.Entry(eventotransferencia).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }


        public async Task<String> Eliminar(string id, EventoTransferencia eventotransferencia)
        {
            var existeMismoId = await PikaContext.EventoTransferencias.AnyAsync(x => x.TransferenciaId == eventotransferencia.TransferenciaId);
            if (existeMismoId)
            {
                PikaContext.Remove(new EventoTransferencia() { TransferenciaId = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
