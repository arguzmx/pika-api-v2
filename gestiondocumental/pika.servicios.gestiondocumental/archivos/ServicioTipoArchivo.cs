using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.EntityFrameworkCore;
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

        public string IdiomaDefault => "es-MX";

        public List<ElementoCatalogo> ElementosDefault()
        {
            return new List<ElementoCatalogo>()
            {

            };
        }

        #region Override

        private DbContextGestionDocumental DB { get { return (DbContextGestionDocumental)_db; } }

        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, ElementoCatalogo original)
        {
            ResultadoValidacion resultado = new ();

            resultado.Valido = true;
            
            // Verifica que el Id no esté en uso en la tabla de Archivos
            if (DB.Archivos.Any(
                a=>a.TipoArchivoId == id
                && a.DominioId == _contextoUsuario.DominioId
                && a.UOrgId == _contextoUsuario.UOrgId))
            {
                resultado.Valido = false;
            }

            return resultado;
        }

        #endregion
    }
}
