namespace CronometroApp.Models
{
    public class Cronometro
    {
        private int segundos;
        private int minutos;

        public Cronometro()
        {
            Reiniciar();
        }

        public void Reiniciar()
        {
            segundos = 0;
            minutos = 0;
        }

        public void IncrementarTiempo()
        {
            segundos++;

            if (segundos >= 60)
            {
                minutos++;
                segundos -= 60;
            }
        }

        public string MostrarTiempo()
        {
            return $"{minutos} minutos, {segundos} segundos";
        }
    }
}
