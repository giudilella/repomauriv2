using System;

class Program
{
    static void Main()
    {
        Sanatorio sanatorio = new Sanatorio();

        int opcion;
        do
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Asignar nueva intervención a un paciente");
            Console.WriteLine("2. Calcular costo de intervenciones de un paciente");
            Console.WriteLine("3. Ver reporte de intervenciones pendientes");
            Console.WriteLine("4. Dar de alta un nuevo paciente");
            Console.WriteLine("5. Listar los pacientes");
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
                case 3:
                    sanatorio.MostrarReportePendientes();
                    break;
                case 4:
                    Console.Write("Ingrese DNI: ");
                    string dni = Console.ReadLine();
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Apellido: ");
                    string apellido = Console.ReadLine();
                    Console.Write("Teléfono: ");
                    string telefono = Console.ReadLine();
                    Console.Write("¿Tiene obra social? (s/n): ");
                    string tieneObraSocial = Console.ReadLine().ToLower();
                    string obraSocial = "-";
                    double cobertura = 0;
                    if (tieneObraSocial == "s")
                    {
                        Console.Write("Nombre de la obra social: ");
                        obraSocial = Console.ReadLine();
                        Console.Write("Cobertura (0 a 1, ej. 0.5 para 50%): ");
                        cobertura = double.Parse(Console.ReadLine());
                    }
                    sanatorio.AgregarPaciente(new Paciente(dni, nombre, apellido, telefono, obraSocial, cobertura));
                    break;
                case 5:
                    sanatorio.ListarPacientes();
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