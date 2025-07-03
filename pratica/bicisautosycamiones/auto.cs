public class Auto : Vehiculo
{
    private int pos = 0;
    private int velocidad;

    public Auto(int velocidad = 40) => this.velocidad = velocidad;

    public void mover(int tiempo) => pos += tiempo * velocidad;
    public int posicion() => pos;
    public void reiniciarPosicion() => pos = 0;
}