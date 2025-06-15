using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CronometroApp.Models;

namespace CronometroApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Cronometro cronometro = new Cronometro();

            for (int i = 0; i < 5000; i++)
            {
                cronometro.IncrementarTiempo();
            }

            Console.WriteLine(cronometro.MostrarTiempo());
        }
    }
}
