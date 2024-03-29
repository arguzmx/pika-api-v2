﻿using System.Text.Json.Serialization;

namespace api.comunes.metadatos
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoDatos
    {
        Desconocido = 0, Texto = 1, TextoIndexado = 2, Decimal = 3, Entero = 4,
        Logico = 5, Fecha = 6, Hora = 7, FechaHora = 8, ListaSeleccionSimple = 9, ListaSeleccionMultiple = 10 
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrdenamientoLista
    {
        Ninguno =0, Alfabetico=1, Numerico =2
    }


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoDespliegue
    {
        Default = 0, Oculto = 1
    }
}
