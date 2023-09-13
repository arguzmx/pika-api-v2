using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.servicios;
using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.dbcontext;

namespace pika.servicios.gestiondocumental.archivos
{
    [ServicioCatalogoEntidadAPI(typeof(TipoArchivo))]
    public class ServicioTipoArchivo : ServicioCatalogoGenericoBase, IServicioCatalogoAPI, IServicioTipoArchivo
    {
        public ServicioTipoArchivo(ILogger<ServicioTipoArchivo> logger, DbContextGestionDocumental context) : base(context, context.TipoArchivo, logger)
        {
        }

        public bool RequiereAutenticacion => true;

        public string IdiomaDefault => throw new NotImplementedException();

        public List<ElementoCatalogo> ElementosDefault()
        {
            return new List<ElementoCatalogo>()
            {

            };
        }
    }
}
