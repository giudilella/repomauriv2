using System;
class Program
{
    static void Main(string[] args)
    {
        Auto ferrari = new Auto(45); //45m/s
        Bicicleta bici = new Bicicleta();
        Camion camion = new Camion();

        bici.mover(20); //bici mover x 20 s
        Console.WriteLine(bici.posicion()); //muestra pos bici duh
        bici.mover(10);
        Console.WriteLine(bici.posicion()); //muestra nueva pos. bici!!
        Carrera carrera = new Carrera(ferrari, camion);
        carrera.correr(10); //se corre la carrera x 10 segundos
    }
}
