using System;
using System.Collections.Generic;

public class Paciente
{
    public string dni { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string telefono { get; set; }
    public string obraSocial { get; set; } = "-";
    public double cobertura { get; set; } = 0;
    public List<Intervencion> intervenciones { get; set; } = new List<Intervencion>();

    public Paciente(string dni, string nombre, string apellido, string telefono, string obraSocial = "-", double cobertura = 0)
    {
        this.dni = dni;
        this.nombre = nombre;
        this.apellido = apellido;
        this.telefono = telefono;
        this.obraSocial = obraSocial;
        this.cobertura = cobertura;
    }

    public void AgregarIntervencion(Intervencion intervencion){
        if (!intervenciones.Contains(intervencion)){
            intervenciones.Add(intervencion);
        }
    }
}
