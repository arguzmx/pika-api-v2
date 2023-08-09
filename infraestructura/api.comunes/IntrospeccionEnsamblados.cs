using api.comunes.modelos.reflectores;
using System.Reflection;
using System.Text.Json;

namespace api.comunes;

/// <summary>
/// Mantiene las funciones comunes de introspeccion de ensamblados para las API genericas
/// </summary>
public static class IntrospeccionEnsamblados
{
    /// <summary>
    /// OBtiene la ruta donde se encuentran los ensambaldos de la aplicacion
    /// </summary>
    /// <returns></returns>
    public static string ObtieneRutaBin()
    {
        return new FileInfo(Assembly.GetEntryAssembly().Location).Directory.FullName;
    }

    /// <summary>
    /// Devuelve una lista de las clases que implementan IEntidadAPI
    /// </summary>
    /// <returns></returns>
    public static List<ServicioEntidadAPI> ObtienesServiciosIEntidadAPI()
    {
        List<ServicioEntidadAPI> l = new ();
        string Ruta = ObtieneRutaBin();

        var assemblies = Directory.GetFiles(Ruta, "pika*.dll", new EnumerationOptions() { RecurseSubdirectories = true });

        foreach (var ensamblado in assemblies)
        {
            try
            {
                var assembly = Assembly.LoadFile(ensamblado);
                var Tipos = assembly.GetTypes()
                        .Where(t =>
                        !t.IsAbstract &&
                        typeof(IEntidadAPI).IsAssignableFrom(t))
                        .ToArray();

                foreach (var t in Tipos)
                {
                    var atributoAPI = t.GetCustomAttribute(typeof(EntidadAPIAttribute));
                    if (atributoAPI!=null) {
                        FileInfo fi = new FileInfo(ensamblado);
                        ServicioEntidadAPI s = new ()
                        {
                            NombreEnsamblado = t.FullName,
                            NombreRuteo = ((EntidadAPIAttribute)atributoAPI).NombreEntidad,
                            Ruta  = ensamblado
                        };
                        l.Add (s);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }

        l.ForEach(i =>
        {
            Console.WriteLine($"{JsonSerializer.Serialize(i)}");
        });

        return l;
    }
}
