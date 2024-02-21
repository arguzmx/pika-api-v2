using api.comunes.metadatos.atributos;
using pika.modelo.contenido.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace pika.modelo.contenido
{
    public class Permiso
    {
        /// <summary>
        /// Identificador único del permiso
        /// </summary>
        [Id]
        [Formulario(indice: 1, visible: false)]
        [Tabla(indice: 0, visible: false)]
        public string Id { get; set; }

        /// <summary>
        /// PErmiso lectura sobre el elemento
        /// </summary>
        public bool Leer { get; set; }

        /// <summary>
        /// PErmiso escritura sobre el elemento
        /// </summary>
        public bool Escribir { get; set; }

        /// <summary>
        /// PErmiso de creación sobre el elemento
        /// </summary>
        public bool Crear { get; set; }

        /// <summary>
        /// PErmiso eliminación sobre el elemento
        /// </summary>
        public bool Eliminar { get; set; }


        //[XmlIgnore, JsonIgnore]
        //public List<AsignacionPermiso> Asignaciones { get; set; }

        //[XmlIgnore, JsonIgnore]
        //public List<Carpeta> Carpetas { get; set; }

        
        //[XmlIgnore, JsonIgnore]
        //public List<Contenido> Contenidos { get; set; }
    }
}
