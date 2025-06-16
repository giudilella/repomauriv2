using System;

public static class SemaforoFunciones
{
    public static void PasoDelTiempo(Semaforo semaforo, int segundos)
    {
        if (semaforo.Intermitente) return;

        semaforo.TiempoTranscurrido += segundos;

        while (semaforo.TiempoTranscurrido >= semaforo.Secuencia[semaforo.IndiceSecuencia].duracion)
        {
            semaforo.TiempoTranscurrido -= semaforo.Secuencia[semaforo.IndiceSecuencia].duracion;
            semaforo.IndiceSecuencia = (semaforo.IndiceSecuencia + 1) % semaforo.Secuencia.Length;
            semaforo.ColorActual = semaforo.Secuencia[semaforo.IndiceSecuencia].color;
        }
    }

    public static string MostrarColor(Semaforo semaforo)
    {
        if (semaforo.Intermitente)
        {
            if (semaforo.TiempoTranscurrido % 2 == 0)
                return "Amarillo";
            else
                return "Apagado";
        }
        return semaforo.ColorActual;
    }

    public static void PonerEnIntermitente(Semaforo semaforo)
    {
        semaforo.Intermitente = true;
        semaforo.TiempoTranscurrido = 0;
    }

    public static void SacarDeIntermitente(Semaforo semaforo)
    {
        semaforo.Intermitente = false;
        semaforo.TiempoTranscurrido = 0;
    }
}
