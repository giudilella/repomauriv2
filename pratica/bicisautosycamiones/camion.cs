public class Camion : Vehiculo {
    private int pos = 0;
    private const int velocidad = 30;
    public void mover(int tiempo) {
        pos += tiempo * velocidad;
    }
    public int posicion() {
        return pos;
    }
    public void reiniciarPosicion() {
        pos = 0;
    }
}
