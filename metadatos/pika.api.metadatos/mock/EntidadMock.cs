using Bogus;
using pika.comun.metadatos;

namespace pika.api.metadatos.mock
{
    public class EntidadMock
    {
        public string Id { get; set; }
        public bool IdLogico { get; set; }
        public string IdListaSeleccionSimple { get; set; }
        public DateTime IdFecha { get; set; }        
        public DateTime IdFechaHora { get; set; }
        public DateTime IdHora { get; set; }
        public decimal IdDecimal { get; set; }
        public long IdEntero { get; set; }
        public string IdListaSeleccionMultiple { get; set; }
        public string IdTexto { get; set; }
        public string IdTextoIndexado { get; set; }

    }

    public static class Mocker
    {
        public static List<EntidadMock> EntidadesMock()
        {
            List<EntidadMock> m = new List<EntidadMock>();
            Randomizer.Seed = new Random(8675309);
            Random r = new Random();

            List<ElementoLista> elementosLista = new List<ElementoLista>();
            elementosLista.Add(new ElementoLista() { Id = "1", Nombre = "Elemento A", Valor = "A", Posicion = 1 });
            elementosLista.Add(new ElementoLista() { Id = "2", Nombre = "Elemento B", Valor = "B", Posicion = 2 });
            elementosLista.Add(new ElementoLista() { Id = "3", Nombre = "Elemento C", Valor = "C", Posicion = 0 });
            elementosLista.Add(new ElementoLista() { Id = "4", Nombre = "Elemento D", Valor = "D", Posicion = 3 });

            List<string> textos = new List<string>()
            {
                "No cuentes los días, haz que los días cuenten. Muhamed Alí",
"No hay pasión más ilusa y fanática que el odio. George Gordon",
"La única manera de salir del laberinto del sufrimiento es perdonar. John Green",
"Al final, lo que importa no son los años de vida, sino la vida de los años. Abraham Lincoln",
"La vida es aquello que te va sucediendo mientras te empeñas en hacer otros planes. John Lennon",
"La vida es una obra teatral que no importa cuánto haya durado, sino lo bien que haya sido representada. Séneca",
"Aprendí que no se puede dar marcha atrás, que la esencia de la vida es ir hacia delante. La vida, en realidad, es una calle de sentido único. Agatha Christie",
"No se puede encontrar la paz evitando la vida. Virginia Woolf",
"La felicidad no brota de la razón, sino de la imaginación. Immanuel Kant",
"El conocimiento habla, pero la sabiduría escucha. Jimi Hendrix",
"Nunca sabes lo fuerte que eres, hasta que ser fuerte es la única opción que te queda. Bob Marley",
"La vida es una película que vuelve a empezar cada mañana al despertarnos. Olvídate de tus errores, cada día tienes una nueva oportunidad para triunfar y alcanzar la felicidad. Norkin Gilbert",
"Tu actitud, no tu aptitud, determinará tu altitud. Zig Ziglar",
"La victoria más difícil es la victoria sobre uno mismo. Aristóteles",
"La vida es una oportunidad, benefíciate de ella. La vida es belleza, admírala. La vida es un sueño, alcánzalo. La vida es un desafío, enfréntalo. La vida es un juego, juégalo. Madre Teresa de Calcuta"
            };

            for (int i = 0; i < 250; i++)
            {

                EntidadMock e = new EntidadMock();

                var idl = elementosLista[r.Next(0, 4)];
                var idl2 = elementosLista[r.Next(0, 4)];
                var dd = r.Next(1, 28);
                var hh = r.Next(1, 24);
                var mm = r.Next(1, 59);
                var ss = r.Next(1, 30);
                var tt = r.Next(0, 14);
                var ll = r.Next(0, 10);

                e.Id = i.ToString();
                e.IdLogico = ll > 5;
                e.IdFechaHora = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dd, hh, mm, ss);
                e.IdFecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dd, 0, 0, 0);
                e.IdHora = new DateTime(2001, 1, 1, hh, mm, ss);
                e.IdDecimal = ((decimal)r.Next(-10, 10)) * (decimal)1.1;
                e.IdEntero = r.Next(0, 50);
                e.IdTexto = textos[tt].Split('.')[1].Trim();
                e.IdTextoIndexado = textos[tt].Split('.')[0].Trim();
                e.IdListaSeleccionSimple = idl.Valor;
                e.IdListaSeleccionMultiple = $"{idl.Valor},{idl2.Valor}";
                m.Add(e);
            }

            return m;
        }
    }


}
