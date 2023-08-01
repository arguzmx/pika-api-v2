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
    public class ServicioTransferencia : IServicioTransferencia
    {
        private readonly ILogger<ServicioTransferencia> _logger;
        private readonly PIKADbContext PikaContext;

        public ServicioTransferencia(ILogger<ServicioTransferencia> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }


        public async Task<string> Crear(Transferencia transferencia)
        {
            var existeMismoId = await PikaContext.Transferencias.AnyAsync(x => x.Id == transferencia.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.Transferencias.Add(transferencia);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }


        public async Task<ActionResult<List<Transferencia>>> Obtiener()
        {
            return await PikaContext.Transferencias.ToListAsync();
        }


        public async Task<String> Actualizar(string id, Transferencia transferencia)
        {
            var existeMismoId = await PikaContext.Transferencias.AnyAsync(x => x.Id == transferencia.Id);
            if (existeMismoId != null)
            {
                PikaContext.Entry(transferencia).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }


        public async Task<String> Eliminar(string id, Transferencia transferencia)
        {
            var existeMismoId = await PikaContext.Transferencias.AnyAsync(x => x.Id == transferencia.Id);
            if (existeMismoId)
            {
                PikaContext.Remove(new Transferencia() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }
    }
}
