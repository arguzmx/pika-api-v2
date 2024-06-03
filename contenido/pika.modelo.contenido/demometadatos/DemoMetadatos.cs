
using api.comunes.metadatos;
using api.comunes.metadatos.atributos;
using api.comunes.metadatos.validadores;

namespace pika.modelo.contenido.demometadatos;

[Entidad(nameof(DemoMetadatos))]
public class DemoMetadatos
{
    [Id]
    [Propiedad(tipoDato: TipoDatos.Texto, tipoDespliegue: TipoDespliegue.Oculto )]
    [Formulario(indice: 1, visible: false)]
    [ValidarRequerida(requerida: RequeridaOperacion.Actualizar)]
    [Tabla(indice: 1, visible: false, ancho: 10)]
    public Guid Id { get; set; }

    [Propiedad(tipoDato: TipoDatos.Texto, tipoDespliegue: TipoDespliegue.TextoLargo)]
    [ValidarRequerida(requerida: RequeridaOperacion.Insertar), ValidarRequerida(requerida: RequeridaOperacion.Actualizar)]
    // [ValidarTexto(0, 10, null  )]
    public string Nobre { get; set; }
}
