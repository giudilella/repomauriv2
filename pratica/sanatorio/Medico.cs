public class Medico
{
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string matricula { get; set; }
    public string especialidad { get; set; }
    public bool disponible { get; set; }

    public Medico(string nombre, string apellido, string matricula, string especialidad, bool disponible = true)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.matricula = matricula;
        this.especialidad = especialidad;
        this.disponible = disponible;
    }
}
