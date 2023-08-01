using Microsoft.AspNetCore.Mvc;
using pika.modelo.gestiondocumental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.archivos
{
    public interface IServicioPermisosUnidadAdministrativaArchivo
    {

        Task<string> Crear(PermisosUnidadAdministrativaArchivo permisosunidadadministrativaarchivo);
        Task<ActionResult<List<PermisosUnidadAdministrativaArchivo>>> Obtiener();
        Task<String> Actualizar(string id, PermisosUnidadAdministrativaArchivo permisosunidadadministrativaarchivo);
        Task<string> Eliminar(string id, PermisosUnidadAdministrativaArchivo permisosunidadadministrativaarchivo);

    }
}
