using System;

namespace BancoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco();

            var cuenta1 = new CuentaBancaria("001", "Juan Pérez", 1000);
            var cuenta2 = new CuentaBancaria("002", "Ana Gómez", 500);

            banco.AgregarCuenta(cuenta1);
            banco.AgregarCuenta(cuenta2);

            banco.Depositar("001", 200);
            banco.Extraer("002", 100);
            bool resultado = banco.Transferencia("001", 300, "002");

            Console.WriteLine($"Cuenta 001 - Saldo: {cuenta1.obtenerSaldo()}");
            Console.WriteLine($"Cuenta 002 - Saldo: {cuenta2.obtenerSaldo()}");
            Console.WriteLine($"Transferencia realizada: {resultado}");
        }
    }
}