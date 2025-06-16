using System;

class Program{
    static void Main(string[] args){
        Console.WriteLine("Funciones del semáforo. Seleccioná la función a usar:");
        Semaforo semaforo = new Semaforo("Verde");

        int ejecutando = 1;
        while (ejecutando == 1)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            if (opcion == "1"){
                AvanzarTiempo(semaforo);
            }
            else if (opcion == "2"){
                MostrarColorActual(semaforo);
            }
            else if (opcion == "3"){
                PonerModoIntermitente(semaforo);
            }
            else if (opcion == "4"){
                SacarModoIntermitente(semaforo);
            }
            else if (opcion == "5"){
                ejecutando = 0;
            }
            else{
                Console.WriteLine("Opción no válida.");
            }
        }

    }

    static void MostrarMenu(){
        Console.WriteLine("\nOpciones:");
        Console.WriteLine("1. Avanzar tiempo");
        Console.WriteLine("2. Mostrar color actual");
        Console.WriteLine("3. Poner en modo intermitente");
        Console.WriteLine("4. Sacar de modo intermitente");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void AvanzarTiempo(Semaforo semaforo){
        Console.Write("Ingrese segundos a avanzar: ");
        if (int.TryParse(Console.ReadLine(), out int segundos)){ //tryparse convierte la entrada string en tipo int y devuelve un booleano si pudo, de ahí el out
            SemaforoFunciones.PasoDelTiempo(semaforo, segundos);
            Console.WriteLine("Tiempo avanzado" + segundos + "segundos.");
        }
        else{
            Console.WriteLine("Entrada inválida.");
        }
    }

    static void MostrarColorActual(Semaforo semaforo){
        Console.WriteLine("Color actual" + SemaforoFunciones.MostrarColor(semaforo));
    }

    static void PonerModoIntermitente(Semaforo semaforo){
        SemaforoFunciones.PonerEnIntermitente(semaforo);
        Console.WriteLine("El semáforo en amarillo (intermitente).");
    }

    static void SacarModoIntermitente(Semaforo semaforo){
        SemaforoFunciones.SacarDeIntermitente(semaforo);
        Console.WriteLine("El semáforo volvió al modo normal.");
    }
}