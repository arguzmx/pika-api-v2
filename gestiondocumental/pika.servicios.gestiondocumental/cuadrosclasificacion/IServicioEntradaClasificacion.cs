using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.cuadrosclasificacion
{
    public interface IServicioEntradaClasificacion
    {

        Task<string> Crear(EntradaClasificacion entradaclasificacion);
        Task<ActionResult<List<EntradaClasificacion>>> Obtiener();
        Task<String> Actualizar(string id, EntradaClasificacion entradaclasificacion);
        Task<string> Eliminar(string id, EntradaClasificacion entradaclasificacion);

    }
}
