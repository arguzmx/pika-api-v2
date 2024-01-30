using api.comunes.modelos.modelos;
using api.comunes.modelos.reflectores;
using api.comunes.modelos.respuestas;
using api.comunes.modelos.servicios;
using Microsoft.Extensions.Logging;
using pika.modelo.organizacion.Contacto;
using pika.servicios.organizacion.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pika.servicios.organizacion.contacto.redsocial
{
    [ServicioCatalogoEntidadAPI(typeof(TipoRedSocial))]
    public class ServicioTipoRedSocial : ServicioCatalogoGenericoBase, IServicioCatalogoAPI, IServicioTipoRedSocial
    {


        public ServicioTipoRedSocial(ILogger<ServicioTipoRedSocial> logger, DbContextOrganizacion context) : base(context, context.TipoRedSocial, logger)
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

        private DbContextOrganizacion DB { get { return (DbContextOrganizacion)_db; } }

        public override async Task<ResultadoValidacion> ValidarEliminacion(string id, ElementoCatalogo original)
        {
            ResultadoValidacion resultado = new();

            resultado.Valido = true;
            // Verifica que el Id no esté en uso en la tabla de RedSocial


            


            /*
             * ver si el id de este modelo es usado en otra tabla
             */

            return resultado;
        }

        #endregion

    }
}
