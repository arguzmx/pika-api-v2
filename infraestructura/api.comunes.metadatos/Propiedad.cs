﻿using api.comunes.metadatos.configuraciones;
using api.comunes.metadatos.validadores;

namespace api.comunes.metadatos;

public class Propiedad
{
    /// <summary>
    /// Identificador único de la propiedad, para reflexi{on es el nombre completo del objeto + nombre de la propiedad
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Nombre de la propiedad o clave para internacionalización en la UI
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Determina si el valor es requerido para su llenado
    /// </summary>
    public bool Requerida { get; set; }

    /// <summary>
    /// Determina si es posible realizar bpsuquedas sobre la propiedad
    /// </summary>
    public bool Buscable { get; set; }

    /// <summary>
    /// Determina si es posible realizar ordenamiento sobre la propiedad
    /// </summary>
    public bool Ordenable { get; set; }

    /// <summary>
    /// Determina si la propieda es visible
    /// </summary>
    public bool Visible { get; set; }

    /// <summary>
    /// Tipo de datos para la propiedad
    /// </summary>
    public TipoDatos Tipo { get; set; }

    /// <summary>
    /// Determina si el campo se muestra al crear
    /// </summary>
    public bool HabilitadoCrear { get; set; }


    /// <summary>
    /// Determina si el campo se muestra al editar
    /// </summary>
    public bool HabilitadoEditar { get; set; }

    /// <summary>
    /// Determina si el campo se muestra al desplegar
    /// </summary>
    public bool HabilitadoDespliegue { get; set; }


    /// <summary>
    /// Establace el tipo de control para el despligue en la UI
    /// </summary>
    public TipoDespliegue TipoDespliegue { get; set; }

    /// <summary>
    /// Url del script de validación del lado del cliente 
    /// </summary>
    public string? UrlMacroCliente { get; set; }

    /// <summary>
    /// Valor default para la propiedad expresado como el valor serializado en javascript
    /// </summary>
    public string? ValorDefault { get; set; }

    /// <summary>
    /// Configuración de la propiedad en la vista tabular
    /// </summary>
    public ConfiguracionTabular? ConfiguracionTabular { get; set; }

    /// <summary>
    /// Validador opcional para propiedades texto
    /// </summary>
    public ValidadorTexto? ValidadorTexto { get; set; }

    /// <summary>
    /// Validador opcional para propiedades numericas
    /// </summary>
    public ValidadorNumerico? ValidadorNumerico { get; set; }

    /// <summary>
    /// Validador opcional para propiedades fecha, fechahora y hora
    /// </summary>
    public ValidadorFecha? ValidadorFecha { get; set; }

    /// <summary>
    /// Elementos de la lista para el tipo lista
    /// </summary>
    public Lista? Lista { get; set; }
}
