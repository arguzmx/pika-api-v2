﻿using System.Diagnostics.CodeAnalysis;

namespace pika.seguridad.modelo.permiso;

[ExcludeFromCodeCoverage]
public class PermisoInsertar
{    
    /// <summary>
     /// Identificador único del módulo al que pertenece el permiso
     /// </summary>
    public Guid ModuloId { get; set; }

    /// <summary>
    /// Identificador único de la aplicación del módulo con el permiso
    /// </summary>
    public Guid AplicacionId { get; set; }

    /// <summary>
    /// Nombre del permiso para la UI, esto será calcolado en base al idioa
    /// </summary>
    public required string Nombre { get; set; }


    /// <summary>
    /// Descripción del permiso para la UI, esto será calcolado en base al idioa
    /// </summary>
    public string? Descripcion { get; set; }


    /// <summary>
    /// Determina el ámbito de apliación del permiso
    /// </summary>
    public AmbitoPermiso Ambito { get; set; }
}
