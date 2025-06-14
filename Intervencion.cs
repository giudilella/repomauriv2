using System;

public class Intervencion
{
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

    public Intervencion()
    {
        Id = contador++;
    }

    public double CalcularCosto(string obraSocial, double cobertura)
    {
        double total = arancel;
        if (altaComplejidad)
            total += arancel * porcentajeEquipoEspecial;
        if (obraSocial != "-" && cobertura > 0)
            total -= total * cobertura;
        return total;
    }
}
