using System;
using System.Collections.Generic;

public class Sanatorio{
    private List<Paciente> listaPacientes = new List<Paciente>();
    private List<Medico> listaMedicos = new List<Medico>();
    private List<Intervencion> listaIntervenciones = new List<Intervencion>();

    public Sanatorio(){
        listaMedicos.Add(new Medico("Rodrigo", "Romero", "4831", "Cardiología", true));
        listaMedicos.Add(new Medico("Pilar", "Castro", "0104", "Traumatología", true));
        listaMedicos.Add(new Medico("Giuliana", "Di Lella", "0308", "Cardiología", true));
        listaPacientes.Add(new Paciente("44543817", "Juan", "Pérez", "341-360-7359", "OSDE", 0.5));
        listaPacientes.Add(new Paciente("37057190", "María", "López", "341-629-1470", "-", 0));
    }
    public void AgregarPaciente(Paciente paciente){
        int i = 0;
        bool existe = false;
        while (i < listaPacientes.Count){
            if (listaPacientes[i].dni == paciente.dni){
                existe = true;
                break;
            }
            i++;
        }
        if (!existe){
            listaPacientes.Add(paciente);
            Console.WriteLine("Paciente registrado con éxito.");
        }
        else{
            Console.WriteLine("Error: El paciente ya está registrado.");
        }
    }
    public void ListarPacientes(){
        if (listaPacientes.Count == 0){
            Console.WriteLine("No hay pacientes registrados.");
            return;
        }
        Console.WriteLine("\n--- Lista de Pacientes ---");
        for (int i = 0; i < listaPacientes.Count; i++){
            Console.WriteLine($"DNI: {listaPacientes[i].dni}, Nombre: {listaPacientes[i].nombre} {listaPacientes[i].apellido}, Teléfono: {listaPacientes[i].telefono}, Obra Social: {listaPacientes[i].obraSocial}");
        }
    }
    public void AgregarMedico(Medico medico){
        listaMedicos.Add(medico);
    }

    public void AsignarIntervencion(string dni){
        Paciente paciente = null; // Busco al paciente
        int i = 0;
        while (i < listaPacientes.Count){
            if (listaPacientes[i].dni == dni){
                paciente = listaPacientes[i];
                break;
            }
            i++;
        }

        if (paciente == null){
            Console.WriteLine("Paciente no registrado. Por favor, ingrese los datos del nuevo paciente.");
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
            if (tieneObraSocial == "s"){
                Console.Write("Nombre de la obra social: ");
                obraSocial = Console.ReadLine();
                Console.Write("Cobertura (0 a 1, ej. 0.5 para 50%): ");
                cobertura = double.Parse(Console.ReadLine());
            }
            paciente = new Paciente(dni, nombre, apellido, telefono, obraSocial, cobertura);
            AgregarPaciente(paciente);
        }

        Console.WriteLine("\nMédicos disponibles:");
        for (int j = 0; j < listaMedicos.Count; j++){
            if (listaMedicos[j].disponible){
                Console.WriteLine($"Matrícula: {listaMedicos[j].matricula}, Nombre: {listaMedicos[j].nombre} {listaMedicos[j].apellido}, Especialidad: {listaMedicos[j].especialidad}");
            }
        }
        Console.Write("Ingrese matrícula del médico: ");
        string matricula = Console.ReadLine();
        Medico medicoSeleccionado = null;
        i = 0;
        while (i < listaMedicos.Count){
            if (listaMedicos[i].matricula == matricula && listaMedicos[i].disponible){
                medicoSeleccionado = listaMedicos[i];
                break;
            }
            i++;
        }
        if (medicoSeleccionado == null){
            Console.WriteLine("Error: Médico no encontrado o no disponible.");
            return;
        }

        Console.Write("Descripción de la intervención: ");
        string descripcion = Console.ReadLine();
        Console.Write("¿Es de alta complejidad? (s/n): ");
        bool altaComplejidad = Console.ReadLine().ToLower() == "s";
        Console.Write("Arancel: ");
        double arancel = double.Parse(Console.ReadLine());
        Console.Write("Fecha (dd/MM/yyyy): ");
        DateTime fecha = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("¿Pagado? (s/n): ");
        bool pagado = Console.ReadLine().ToLower() == "s";

        Intervencion intervencion = new Intervencion{
            fecha = fecha,
            descripcion = descripcion,
            especialidad = medicoSeleccionado.especialidad,
            arancel = arancel,
            altaComplejidad = altaComplejidad,
            medico = medicoSeleccionado,
            pagado = pagado
        };
        listaIntervenciones.Add(intervencion);
        paciente.AgregarIntervencion(intervencion);
        Console.WriteLine($"Intervención asignada con ID: {intervencion.Id}");
    }

    public void CalcularCostoPorDNI(string dni){
        Paciente paciente = null;
        int i = 0;
        while (i < listaPacientes.Count){
            if (listaPacientes[i].dni == dni){
                paciente = listaPacientes[i];
                break;
            }
            i++;
        }
        if (paciente == null){
            Console.WriteLine("Paciente no encontrado.");
            return;
        }
        double total = 0;
        for (int j = 0; j < paciente.intervenciones.Count; j++){
            total += paciente.intervenciones[j].CalcularCosto(paciente.obraSocial, paciente.cobertura);
        }
        Console.WriteLine($"Costo total de intervenciones para {paciente.nombre} {paciente.apellido}: ${total:F2}");
    }
    public void MostrarReportePendientes(){
        List<Intervencion> pendientes = new List<Intervencion>();
        int i = 0;
        while (i < listaIntervenciones.Count){
            if (!listaIntervenciones[i].pagado){
                pendientes.Add(listaIntervenciones[i]);
            }
            i++;
        }
        if (pendientes.Count == 0){
            Console.WriteLine("No hay intervenciones pendientes de pago.");
            return;
        }
        Console.WriteLine("\n--- Reporte de Liquidaciones Pendientes ---");
        for (i = 0; i < pendientes.Count; i++){
            Paciente paciente = null;
            int j = 0;
            while (j < listaPacientes.Count){
                int k = 0;
                while (k < listaPacientes[j].intervenciones.Count){
                    if (listaPacientes[j].intervenciones[k] == pendientes[i]){
                        paciente = listaPacientes[j];
                        break;
                    }
                    k++;
                }
                if (paciente != null) break;
                j++;
            }
            if (paciente != null){
                double costo = pendientes[i].CalcularCosto(paciente.obraSocial, paciente.cobertura);
                Console.WriteLine($"ID: {pendientes[i].Id}, Fecha: {pendientes[i].fecha:dd/MM/yyyy}, Descripción: {pendientes[i].descripcion}, " +
                                 $"Paciente: {paciente.nombre} {paciente.apellido}, Médico: {pendientes[i].medico.nombre} {pendientes[i].medico.apellido} " +
                                 $"(Mat: {pendientes[i].medico.matricula}), Obra Social: {paciente.obraSocial}, Importe: ${costo:F2}");
            }
        }
    }
}