namespace jugadorCansado
{
    public interface Jugador
    {
        bool correr(int minutos);
        bool cansado();
        void descansar(int minutos);
    }
}