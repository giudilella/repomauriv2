namespace jugadorCansado
{
    public interface IJugadorCansado
    {
        bool Correr(int minutos);
        bool Cansado();
        void Descansar(int minutos);
    }
}