using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext;
using System;
using System.Collections.Generic;
using System.Threading;

namespace pika.servicios.gestiondocumental.acervo;

public class ServicioActivo : IServicioActivo
{
    
    private readonly ILogger<ServicioActivo> _logger;
  
    private readonly PIKADbContext PikaContext;

    public ServicioActivo(ILogger<ServicioActivo> logger, PIKADbContext PikaContext)
    {
        _logger = logger;
        this.PikaContext = PikaContext;
    }

    // Crear el CRUD de API utilizando context


//Crear
public async Task<string> Crear(Activo activo)
    {
        var existeMismoId = await PikaContext.Activos.AnyAsync(x => x.Id == activo.Id);

        if (existeMismoId)
        {
            return null;
        }

        PikaContext.Activos.Add(activo);
        await PikaContext.SaveChangesAsync();
        return ($"+");
    }
    
    //Leer
    public async Task<ActionResult<List<Activo>>> Obtiener()
    {
        return await PikaContext.Activos.ToListAsync();
    }

    //Actualizar
    public async Task<String> Actualizar(string id, Activo activo)
    {
        var existeMismoId = await PikaContext.Activos.AnyAsync(x => x.Id == activo.Id);

        if (existeMismoId != null)
        {
            PikaContext.Entry(activo).State = EntityState.Modified;
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }
        return null;
    }

    //Eliminar

    public async Task<string> Eliminar(string id, Activo activo)
    {
        var existeMismoId = await PikaContext.Activos.AnyAsync(x => x.Id == activo.Id);
        if (existeMismoId)
        {
            PikaContext.Remove(new Activo() { Id = id });
            await PikaContext.SaveChangesAsync();
            return ($"+");
        }
        return null;
    }
}
