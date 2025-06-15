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
}
