namespace jugadorCansado
{
    public class Profesional : Jugador
    {
        int energia = 40;
        int energiaMax = 40;

        public bool correr(int minutos)
        {
            if (minutos <= energia)
            {
                energia -= minutos;
                return true;
            }
            energia = 0;
            return false;
        }

        public bool cansado() => energia == 0;

        public void descansar(int minutos)
        {
            energia = Math.Min(energia + minutos, energiaMax);
        }
    }
}