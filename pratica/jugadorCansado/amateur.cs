namespace jugadorCansado
{
    public class Amateur : Jugador
    {
        int energia = 20;
        int energiaMax = 20;

        public bool correr(int minutos)
        {
            if (min <= energia)
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
