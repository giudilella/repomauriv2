namespace jugadorCansado
{
    public class Profesional : jugadorCansado
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
            else
            {
                energia = 0;
                return false;
            }
        }
        public bool cansado()
        {
            return energia == 0;
        }
        public void descansar(int minutos)
        {
            energia += minutos;
            if (energia > energiaMax)
                energia = energiaMax;
        }
    }
}
