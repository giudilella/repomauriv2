using System;
namespace jugadorCansado
{
    class Program
    {
        static void Main(string[] args)
        {
            Jugador j1 = new Amateur();
            Jugador j2 = new Profesional();

            Console.WriteLine("Jugador amateur corre 15 minutos: ");
            Console.WriteLine("Pudo correr?: " + j1.correr(15));
            Console.WriteLine("Está cansado?: " + j1.cansado());

            Console.WriteLine("\nJugador profesional corre 35 minutos: ");
            Console.WriteLine("Pudo correr?: " + j2.correr(35));
            Console.WriteLine("Está cansado?: " + j2.cansado());

            Console.WriteLine("\nJugador amateur intenta correr 10 más: ");
            Console.WriteLine("Pudo correr?: " + j1.correr(10));
            Console.WriteLine("Está cansado?: " + j1.cansado());
        }
    }
}