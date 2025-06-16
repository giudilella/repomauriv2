using System;

public class Semaforo{
    private string colorActual;
    private int tiempoTranscurrido;
    private bool intermitente;
    private int indiceSecuencia;

    private readonly (string color, int duracion)[] secuencia = new[]{
        ("Rojo", 30),
        ("Rojo-Amarillo", 2),
        ("Verde", 20),
        ("Amarillo", 2)
    };

    public Semaforo(string colorInicial){
        if (colorInicial != "Rojo" && colorInicial != "Verde" && colorInicial != "Amarillo"){
            throw new ArgumentException("Color inicial debe ser Rojo, Verde o Amarillo");
        }

        for (int i = 0; i < secuencia.Length; i++){
            if (secuencia[i].color.StartsWith(colorInicial)){
                indiceSecuencia = i;
                break;
            }
        }

        colorActual = secuencia[indiceSecuencia].color;
        tiempoTranscurrido = 0;
        intermitente = false;
    }

    public string ColorActual { get => colorActual; set => colorActual = value; }
    public int TiempoTranscurrido { get => tiempoTranscurrido; set => tiempoTranscurrido = value; }
    public bool Intermitente { get => intermitente; set => intermitente = value; }
    public int IndiceSecuencia { get => indiceSecuencia; set => indiceSecuencia = value; }
    public (string color, int duracion)[] Secuencia => secuencia;
}