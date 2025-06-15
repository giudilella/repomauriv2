using System;
namespace jugadorCansado
{
    class Program
    {
        static void Main(string[] args)
        {
            jugador j1 = new amateur();
            jugadorCansado j2 = new pro();
            Console.WriteLine("JUgador amateur corre 15 mintuos: ");
            bool resuktado = j1.correr(15);
            Console.WriteLine("Pudo correr?: " + resultado);
            Console.WriteLine("Está cansado?: " + j1.cansado());

            Console.WriteLine();

            Console.WriteLine("Jugador profesional (pro) corre 35 minutos: ");
            bool resultado2 = j2.correr(35);
            Console.WriteLine("Pudocorrer?: " + r2);
            Console.WriteLine("está cansado?: " + j2.cansado());

            Console.WriteLine();

            Console.WriteLine("Jugador amateur intentó correr 10 más: ");
            bool resultado3 = j1.correr(10);
            Console.WriteLine("Pudo correr?: " + resultado3);
            Console.WriteLine("Está cansado?: " + j1.cansado());
        }
    }
}
