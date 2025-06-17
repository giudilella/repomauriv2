using System;

public class Intervencion{
    private static int contador = 1;

    public int Id { get; private set; }
    public DateTime fecha { get; set; }
    public string descripcion { get; set; }
    public string especialidad { get; set; }
    public double arancel { get; set; }
    public bool altaComplejidad { get; set; }
    public static double porcentajeEquipoEspecial { get; set; } = 0.20;
    public Medico medico { get; set; }
    public bool pagado { get; set; }

    public Intervencion(){
        Id = contador++;
        this.descripcion = descripcion;
        this.especialidad = especialidad;
        this.arancel = arancel;
        this.altaComplejidad = altaComplejidad;
    }

    public Intervencion(string descripcion, string especialidad, double arancel, bool altaComplejidad) //inicializa las intervenciones para sanatorio.cs{
        Id = contador++;
        this.descripcion = descripcion;
        this.especialidad = especialidad;
        this.arancel = arancel;
        this.altaComplejidad = altaComplejidad;
    }

    public double CalcularCosto(string obraSocial, double cobertura){
        double total = arancel;
        if (altaComplejidad)
            total += arancel * porcentajeEquipoEspecial;
        if (obraSocial != "-" && cobertura > 0)
            total -= total * cobertura;
        return total;
    }

    public void AsignarAPaciente(Paciente paciente){
    if (paciente != null && !paciente.intervenciones.Contains(this)){
        paciente.intervenciones.Add(this);
    }
}
}
