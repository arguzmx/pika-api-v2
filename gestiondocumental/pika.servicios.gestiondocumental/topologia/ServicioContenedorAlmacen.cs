﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.topologia
{
    public class ServicioContenedorAlmacen : IServicioContenedorAlmacen
    {

        private readonly ILogger<ServicioContenedorAlmacen> _logger;

        private readonly PIKADbContext PikaContext;

        public ServicioContenedorAlmacen(ILogger<ServicioContenedorAlmacen> logger, PIKADbContext PikaContext)
        {
            _logger = logger;
            this.PikaContext = PikaContext;
        }

        // Crear el CRUD de API utilizando context

        //Crear
        public async Task<string> Crear(ContenedorAlmacen contenedoralmacen)
        {
            var existeMismoId = await PikaContext.ContenedorAlmacens.AnyAsync(x => x.Id == contenedoralmacen.Id);

            if (existeMismoId)
            {
                return null;
            }

            PikaContext.ContenedorAlmacens.Add(contenedoralmacen);
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }

        //Leer
        public async Task<ActionResult<List<ContenedorAlmacen>>> Obtiener()
        {
            return await PikaContext.ContenedorAlmacens.ToListAsync();
        }

        //Actualizar
        public async Task<String> Actualizar(string id, ContenedorAlmacen contenedoralmacen)
        {
            var existeMismoId = await PikaContext.ContenedorAlmacens.AnyAsync(x => x.Id == contenedoralmacen.Id);

            if (existeMismoId != null)
            {
                PikaContext.Entry(contenedoralmacen).State = EntityState.Modified;
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

        //Eliminar

        public async Task<string> Eliminar(string id, ContenedorAlmacen contenedoralmacen)
        {
            var existeMismoId = await PikaContext.ContenedorAlmacens.AnyAsync(x => x.Id == contenedoralmacen.Id);
            if (existeMismoId)
            {
                PikaContext.Remove(new ContenedorAlmacen() { Id = id });
                await PikaContext.SaveChangesAsync();
                return ($"+");
            }
            return null;
        }

    }
}
