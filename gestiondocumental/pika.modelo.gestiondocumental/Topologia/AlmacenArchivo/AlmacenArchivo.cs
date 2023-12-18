﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace pika.modelo.gestiondocumental.Topologia
{

    /// <summary>
    /// DEfine un almacén correspondiente a un archivo
    /// </summary>
    public class AlmacenArchivo
    {

        /// <summary>
        /// Identificador único del almacén
        /// </summary>
        public string Id { get; set; }
        // [a] [d] 
        // R 128


        /// <summary>
        /// Nombre único del almacén
        /// </summary>
        public string Nombre { get; set; }
        // [i] [a] [d] 
        // R 500


        /// <summary>
        /// Clave asociada al almacén en la organización
        /// </summary>
        public string Clave { get; set; }
        // [i] [a] [d] 
        // R 100


        /// <summary>
        /// Identificador único del archivo al qu pertenece el almacen
        /// </summary>
        public string ArchivoId { get; set; }
        // [i] [a] [d]
        // R 128


        /// <summary>
        /// Ubicación física del archivo por ejemplo una dirección
        /// </summary>
        public string Ubicacion { get; set; }
        // [i] [a] [d] 
        // R 500


        [XmlIgnore]
        [JsonIgnore]
        public Archivo Archivo { get; set; }
    }
}