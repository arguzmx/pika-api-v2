namespace api.comunes.consultas.dto;

public enum Ordenamiento
{
    asc = 0, desc = 1
}

public enum OperadorFiltro
{
    Igual = 0, Contiene = 1, ComienzaCon = 2, TerminaCon = 3,
    Mayor = 4, MayorIgual = 5, Menor = 6, MenorIgual = 7, Entre = 8,
    TextoCompleto = 100
}
