﻿namespace pika.modelo.gestiondocumental;

public class SerieDocumentalInsertar
{
    public string CuadroClasificacionId { get; set; }
    public string Clave { get; set; }
    public string Nombre { get; set; }
    public bool Raiz { get; set; }
    public string? SeriePadreId { get; set; }
    public int MesesArchivoTramite { get; set; }
    public int MesesArchivoConcentracion { get; set; }
    public int MesesArchivoHistorico { get; set; }
}
