using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.archivos;
using pika.servicios.gestiondocumental.dbcontext;

namespace pika.servicios.gestiondocumental.transferencias
{
    [ServicioCatalogoEntidadAPI(typeof(EstadoTransferencia))]
    public class ServicioEstadoTransferencia : ServicioCatalogoGenericoBase, IServicioCatalogoAPI, IServicioEstadoTransferencia
    {
        public ServicioEstadoTransferencia(ILogger<ServicioEstadoTransferencia> logger, DbContextGestionDocumental context) : base(context, context.EstadoTransferencia, logger)
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
            ResultadoValidacion resultado = new();

            resultado.Valido = true;
            // Al parecer la restriccion de llave foranea bloqueara la eliminacion
            // si se intenta elimina y es usado en otra entidad

            return resultado;
        }

        #endregion
    }
}

