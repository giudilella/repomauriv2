using System;

class Program
{
    static void Main()
    {
        Sanatorio sanatorio = new Sanatorio();

        sanatorio.AgregarMedico(new Medico { nombre = "Carlos", apellido = "Ramírez", matricula = "1234", especialidad = "Cardiología", disponible = true });
        sanatorio.AgregarMedico(new Medico { nombre = "Lucía", apellido = "Méndez", matricula = "5678", especialidad = "Traumatología", disponible = true });

        int opcion;
        do
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Asignar nueva intervención a un paciente");
            Console.WriteLine("2. Calcular costo de intervenciones de un paciente");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese DNI del paciente: ");
                    string dniC = Console.ReadLine();
                    sanatorio.AsignarIntervencion(dniC);
                    break;
                case 2:
                    Console.Write("Ingrese DNI del paciente: ");
                    string dniD = Console.ReadLine();
                    sanatorio.CalcularCostoPorDNI(dniD);
                    break;
                case 0:
                    Console.WriteLine("Chau!");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }
}
