using System;

public class Carrera
{
    private Vehiculo v1;
    private Vehiculo v2;

    public Carrera(Vehiculo v1, Vehiculo v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }

    public void correr(int segundos)
    {
        v1.mover(segundos);
        v2.mover(segundos);

        // Mostrar posiciones (puede ser más cute pero bueno je)
        Console.WriteLine("Posición vehículo 1: " + v1.posicion());
        Console.WriteLine("Posición vehículo 2: " + v2.posicion());
    }
}
