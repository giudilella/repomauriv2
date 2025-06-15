public class Bicicleta : Vehiculo {
    private int _pos = 0;
    private const int velocidad = 10;
    public void mover(int tiempo) {
        _pos += tiempo * velocidad;
    }
    public int posicion() {
        return _pos;
    }
    public void reiniciarPosicion() {
        _pos = 0;
    }
}
