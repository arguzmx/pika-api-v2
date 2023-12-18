using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.Extensions.Logging;
using pika.modelo.gestiondocumental;
using pika.servicios.gestiondocumental.archivos;
using pika.servicios.gestiondocumental.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.gestiondocumental.seriedocumental
{
    [ServicioCatalogoEntidadAPI(typeof(TipoDisposicionDocumental))]
    public class ServicioTipoDisposicionDocumental : ServicioCatalogoGenericoBase, IServicioCatalogoAPI,IServicioTipoDisposicionDocumental
    {
        public ServicioTipoDisposicionDocumental(ILogger<ServicioTipoDisposicionDocumental> logger, DbContextGestionDocumental context) : base(context, context.TipoDisposicionDocumental, logger)
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
            // Verifica que el Id no esté en uso en la tabla de DisposicionDocumental
            /*
             * ver si el id de este modelo es usado en otra tabla
             */

            return resultado;
        }

        #endregion
    }
}
