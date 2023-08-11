using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.comunes;

public interface IConfiguracionAPIEntidades
{
    List<string> ObtieneRutasControladorGenerico();
    List<ServicioEntidadAPI> ObtienesServiciosIEntidadAPI();
    void RecargarServicios();
}
