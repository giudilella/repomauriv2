using System;
using System.Collections.Generic;
using System.Linq;

public class Sanatorio
{
    private List<Paciente> pacientes = new List<Paciente>();
    private List<Medico> medicos = new List<Medico>();

    public void AgregarPaciente(Paciente paciente)
    {
        pacientes.Add(paciente);
    }

    public void AgregarMedico(Medico medico)
    {
        medicos.Add(medico);
    }

    public void AsignarIntervencion(string dni)
    {
        var paciente = pacientes.FirstOrDefault(p => p.dni == dni);
        if (paciente == null)
        {
            Console.WriteLine("Paciente no encontrado. Se dará de alta.");
            paciente = new Paciente();
            Console.Write("Nombre: ");
            paciente.nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            paciente.apellido = Console.ReadLine();
            paciente.dni = dni;
            Console.Write("Teléfono: ");
            paciente.telefono = Console.ReadLine();
            Console.Write("¿Tiene obra social? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                Console.Write("Nombre de la obra social: ");
                paciente.obraSocial = Console.ReadLine();
                Console.Write("Cobertura (por ejemplo 0.8 para 80%): ");
                paciente.cobertura = double.Parse(Console.ReadLine());
            }
            pacientes.Add(paciente);
        }

        var intervencion = new Intervencion();
        Console.Write("Fecha (yyyy-mm-dd): ");
        intervencion.fecha = DateTime.Parse(Console.ReadLine());
        Console.Write("Descripción: ");
        intervencion.descripcion = Console.ReadLine();
        Console.Write("Especialidad: ");
        intervencion.especialidad = Console.ReadLine();
        Console.Write("Arancel: ");
        intervencion.arancel = double.Parse(Console.ReadLine());
        Console.Write("¿Alta complejidad? (s/n): ");
        intervencion.altaComplejidad = Console.ReadLine().ToLower() == "s";

        Console.WriteLine("Médicos disponibles:");
        var disponibles = medicos.Where(m => m.disponible && m.especialidad == intervencion.especialidad).ToList();
        if (!disponibles.Any())
        {
            Console.WriteLine("No hay médicos disponibles para esta especialidad.");
            return;
        }

        for (int i = 0; i < disponibles.Count; i++)
        {
            var m = disponibles[i];
            Console.WriteLine($"{i + 1}. {m.nombre} {m.apellido} - {m.matricula}");
        }

        Console.Write("Seleccione el número del médico: ");
        int indice = int.Parse(Console.ReadLine()) - 1;
        intervencion.medico = disponibles[indice];

        Console.Write("¿Está pagado? (s/n): ");
        intervencion.pagado = Console.ReadLine().ToLower() == "s";

        paciente.intervenciones.Add(intervencion);
        Console.WriteLine("Intervención asignada con éxito.");
    }

    public void CalcularCostoPorDNI(string dni)
    {
        var paciente = pacientes.FirstOrDefault(p => p.dni == dni);
        if (paciente == null)
        {
            Console.WriteLine("Paciente no encontrado.");
            return;
        }

        double total = 0;
        foreach (var i in paciente.intervenciones)
        {
            double costo = i.CalcularCosto(paciente.obraSocial, paciente.cobertura);
            Console.WriteLine($"Intervención {i.Id} - {i.descripcion}: ${costo:F2}");
            total += costo;
        }

        Console.WriteLine($"Costo total para el paciente {paciente.nombre} {paciente.apellido}: ${total:F2}");
    }
}
