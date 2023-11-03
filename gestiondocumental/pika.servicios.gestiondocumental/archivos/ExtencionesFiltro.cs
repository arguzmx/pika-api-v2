using api.comunes.modelos.modelos;
using pika.modelo.gestiondocumental;
using System.Globalization;

namespace pika.servicios.gestiondocumental.archivos;
public enum TipoDato
{
    Desconocido = 0, Texto = 1, Numero = 2, Booleano = 3, Fecha = 4
}

public static class ExtensionesFiltro
{
    /// <summary>
    /// Crea el diccionario de los tipos de datos para cada entidad de la clase CFDI
    /// </summary>
    /// <returns></returns>
    public static Dictionary<string, TipoDato> TipoDatoCFDI
    {
        get
        {
            return new()
            {
                { "Id",                 TipoDato.Texto},
                { "Nombre",             TipoDato.Texto},
                { "DominioId",          TipoDato.Texto},
                { "UOrgId",             TipoDato.Texto},
                { "TipoArchivoId",      TipoDato.Texto},
                { "FechaCFDI",          TipoDato.Fecha},
                { "iano",               TipoDato.Numero},
                { "imes",               TipoDato.Numero},
                { "idia",               TipoDato.Numero},
                { "RFCId",              TipoDato.Numero},
                { "SubTotal",           TipoDato.Numero},
                { "Total",              TipoDato.Numero},
                { "TotalIRetenidos",    TipoDato.Numero},
                { "TotalITrasladados",  TipoDato.Numero},
                { "Uso",                TipoDato.Texto},
                { "TieneIRetenidos",    TipoDato.Booleano},
                { "TieneITrasladados",  TipoDato.Booleano},
                { "TieneRelacionados",  TipoDato.Booleano},
                { "TieneI3os" ,         TipoDato.Booleano},
                { "TieneInfoAduanera",  TipoDato.Booleano},
                { "TieneCPredial",      TipoDato.Booleano},
                { "TieneComplementos" , TipoDato.Booleano},
                { "TieneAddenda",       TipoDato.Booleano},
                { "Serie",              TipoDato.Texto},
                { "Folio",              TipoDato.Texto},
                { "FormaPago",          TipoDato.Texto},
                { "Moneda",             TipoDato.Texto},
                { "TipoDeComprobante",  TipoDato.Texto},
                { "MetodoPago",         TipoDato.Texto},
                { "LugarExpedicion",    TipoDato.Texto}
            };
        }

    }

    /// <summary>
    /// Devuelve el tipo de campo para cada propiedad
    /// </summary>
    /// <param name="nombre"></param>
    /// <returns></returns>
    public static TipoDato TipoParaCampo(this string nombre)
    {
        if (TipoDatoCFDI.ContainsKey(nombre))
        {
            return TipoDatoCFDI[nombre];
        }

        return TipoDato.Desconocido;
    }


    /// <summary>
    /// Genera el query de SQL para los filtros enviados
    /// </summary>
    /// <param name="filtros"></param>
    /// <returns></returns>
    public static string SQL(this List<Filtro>? filtros)
    {

        if (filtros != null)
        {
            List<string> condiciones = new();

            filtros.ForEach(filtro =>
            {
                TipoDato tipo = filtro.Campo.TipoParaCampo();
                if (tipo != TipoDato.Desconocido)
                {
                    string condicion = filtro.CondidionSQL(tipo);
                    if (!string.IsNullOrEmpty(condicion))
                    {
                        condiciones.Add(condicion);
                    }
                }
            });

            if (condiciones.Count > 0)
            {
                if (condiciones.Count == 1)
                {
                    return condiciones.First();
                }
                else
                {
                    return string.Join(" AND ", condiciones);
                }
            }
        }

        return "";
    }

    /// <summary>
    /// Creea una condicion a partir de un elemento filtro
    /// </summary>
    /// <param name="filtro"></param>
    /// <param name="tipo"></param>
    /// <returns></returns>
    public static string CondidionSQL(this Filtro filtro, TipoDato tipo)
    {
        string condicion = string.Empty;
        switch (tipo)
        {//Agregar los tipos de sentencias de sql dependiendo de que tipo de dato sea ******

            case TipoDato.Fecha:
                condicion = filtro.CondicionFechaSQL();
                break;
            case TipoDato.Numero:
                condicion = filtro.CondicionNumeroSQL();
                break;
            case TipoDato.Texto:
                condicion = filtro.CondicionTextoSQL();
                break;
            case TipoDato.Booleano:
                condicion = filtro.CondicionBoolSQL();
                break;
        }
        if (!String.IsNullOrEmpty(condicion))
        {
            return $"{filtro.VerificarNegacion()}{condicion})";
        }
        return condicion;
    }

    /// <summary>
    /// Convierte un filtro de tipo bool a su representación SQL.
    /// En el caso de sqlite, los bool se almacenan como Integer.
    /// Por lo que se valida -> 0 = No tiene, 1 = Tiene.
    /// </summary>
    /// <param name="filtro"></param>
    /// <returns></returns>
    public static string CondicionBoolSQL(this Filtro filtro)
    {
        int numero;
        if (filtro.Valores.Count == 0 || !int.TryParse(filtro.Valores[0], out numero))
        {
            return string.Empty;
        }
        if (numero < 0 || numero > 1)
        {
            return string.Empty;
        }

        switch (filtro.Operador)
        {
            case OperadorFiltro.Igual:
                return $"{filtro.Campo} = {filtro.Valores[0]}";
        }
        return string.Empty;
    }

    /// <summary>
    /// Convierte un filtro de tipo texto a su representación SQL.
    /// </summary>
    /// <param name="filtro"></param>
    /// <returns></returns>
    public static string CondicionTextoSQL(this Filtro filtro)
    {
        foreach (var valor in filtro.Valores)
        {
            if (filtro.Valores.Count == 0 || string.IsNullOrEmpty(valor))
            {
                return string.Empty;
            }
        }

        switch (filtro.Operador)
        {
            case OperadorFiltro.Igual:
                return $"{filtro.Campo} = '{filtro.Valores[0]}'";
            case OperadorFiltro.ComienzaCon:
                return $"{filtro.Campo} LIKE '{filtro.Valores[0]}%'";
            case OperadorFiltro.TerminaCon:
                return $"{filtro.Campo} LIKE '%{filtro.Valores[0]}'";
            case OperadorFiltro.Contiene:
                return $"{filtro.Campo} regexp '{filtro.Valores[0]}'";
        }
        return string.Empty;
    }

    /// <summary>
    /// Convierte un filtro de tipo Numero a su representación SQL.
    /// </summary>
    /// <param name="filtro"></param>
    /// <returns></returns>
    public static string CondicionNumeroSQL(this Filtro filtro)
    {
        List<decimal> numeros = new();
        foreach (var valor in filtro.Valores)
        {

            if (decimal.TryParse(valor, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal n))
            {
                numeros.Add(n);
            }
            else
            {
                return string.Empty;
            }
        }

        if (numeros.Count == 0 || (filtro.Operador == OperadorFiltro.Entre && numeros.Count != 2 && numeros[0] == numeros[1]))
        {
            return string.Empty;
        }

        switch (filtro.Operador)
        {
            case OperadorFiltro.Mayor:
                return $"{filtro.Campo} > {numeros[0]}";

            case OperadorFiltro.Menor:
                return $"{filtro.Campo} < {numeros[0]}";

            case OperadorFiltro.Igual:
                return $"{filtro.Campo} = {numeros[0]}";

            case OperadorFiltro.MayorIgual:
                return $"{filtro.Campo} >= {numeros[0]}";

            case OperadorFiltro.MenorIgual:
                return $"{filtro.Campo} <= {numeros[0]}";

            case OperadorFiltro.Entre:
                return numeros[0] < numeros[1]
                ? $"{filtro.Campo} BETWEEN {numeros[0]} AND {numeros[1]}"
                : $"{filtro.Campo} BETWEEN {numeros[1]} AND {numeros[0]}";
        }
        return string.Empty;
    }

    /// <summary>
    /// Convierte un filtro de fecha a su representación SQL
    /// En el caso de SQLite las fechas se almacenan como long debido a que  debe realizarse una conversión
    /// </summary>
    /// <param name="filtro"></param>
    /// <returns>Cadena SQL si l filtro es válido o una cadena vacia</returns>
    public static string CondicionFechaSQL(this Filtro filtro)
    {
        List<long> fechas = new();

        foreach (var valor in filtro.Valores)
            if (DateTime.TryParse(valor, out DateTime fecha))
            {
                fechas.Add(fecha.Ticks);
            }
            else
            {
                return string.Empty;
            }

        if (fechas.Count == 0 || (filtro.Operador == OperadorFiltro.Entre && fechas.Count != 2 && fechas[0] == fechas[1]))
        {
            return string.Empty;
        }

        switch (filtro.Operador)
        {
            case OperadorFiltro.Mayor:
                return $"{filtro.Campo} > {fechas[0]}";

            case OperadorFiltro.Menor:
                return $"{filtro.Campo} < {fechas[0]}";

            case OperadorFiltro.Igual:
                return $"{filtro.Campo} = {fechas[0]}";

            case OperadorFiltro.MayorIgual:
                return $"{filtro.Campo} >= {fechas[0]}";

            case OperadorFiltro.MenorIgual:
                return $"{filtro.Campo} <= {fechas[0]}";

            case OperadorFiltro.Entre:
                return fechas[0] < fechas[1]
                    ? $"{filtro.Campo} BETWEEN {fechas[0]} AND {fechas[1]}"
                    : $"{filtro.Campo} BETWEEN {fechas[1]} AND {fechas[0]}";
        }
        // Si no hay un operador válido devuelve una cadena vacía
        return string.Empty;
    }
    /// <summary>
    /// Verifica si el resultado del filtro sera negado 
    /// </summary>
    /// <param name="filtro"></param>
    /// <returns>bool</returns>
    public static string VerificarNegacion(this Filtro filtro)
    {
        if (filtro.Negar == true)
        {
            return "(NOT ";
        }
        return "(";
    }

    /// <summary>
    /// Devuelve el comando sql correspondiente para  paginar la consulta realizada
    /// </summary>
    /// <param name="pagina"></param>
    /// <returns>string</returns>
    public static string PaginarConsulta(this PaginaGenerica<Archivo> pagina, Consulta consulta)
    {
        int limit = consulta.Paginado.Tamano;
        int offset = consulta.Paginado.Tamano*consulta.Paginado.Indice;
        return $"LIMIT {limit} OFFSET {offset} ";
    }

    /// <summary>
    /// Devuelve el comando sql correspondiente para ordenar el resultado de la consulta.
    /// </summary>
    /// <param name="consulta"></param>
    /// <returns>stringreturns>
    public static string OrdenarConsulta(this Consulta consulta)
    {
        //CFDI objCFDI = new CFDI();
        //if (objCFDI.GetType().GetProperty(consulta.Paginado.ColumnaOrdenamiento) == null)
        //{
        //    consulta.ColumnaOrdenamiento = "FechaCFDI ";
        //}
        string ordenConsulta = "ORDER BY ";
        ordenConsulta += consulta.Paginado.ColumnaOrdenamiento + " ";
        ordenConsulta += consulta.Paginado.Ordenamiento == 0 ? Ordenamiento.asc : Ordenamiento.desc;

        return ordenConsulta;
    }
}