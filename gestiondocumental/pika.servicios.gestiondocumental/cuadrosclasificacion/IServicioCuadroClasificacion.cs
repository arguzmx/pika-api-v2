using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.cuadrosclasificacion
{
    public interface IServicioCuadroClasificacion
    {
        Task<string> Crear(CuadroClasificacion cuadroclasificacion);
        Task<ActionResult<List<CuadroClasificacion>>> Obtiener();
        Task<String> Actualizar(string id, CuadroClasificacion cuadroclasificacion);
        Task<string> Eliminar(string id, CuadroClasificacion cuadroclasificacion);
    }
}
