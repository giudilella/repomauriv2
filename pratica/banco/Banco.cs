using System;
using System.Collections.Generic;

namespace BancoApp
{
    public class Banco
    {
        private Dictionary<string, CuentaBancaria> cuentas = new Dictionary<string, CuentaBancaria>();

        public void AgregarCuenta(CuentaBancaria cuenta)
        {
            cuentas[cuenta.obtenerNumeroCuenta()] = cuenta;
        }

        public bool Depositar(string numeroCuenta, double monto)
        {
            if (monto <= 0 || !cuentas.ContainsKey(numeroCuenta))
                return false;

            var cuenta = cuentas[numeroCuenta];
            cuenta.cambiarSaldo(cuenta.obtenerSaldo() + monto);
            return true;
        }

        public bool Extraer(string numeroCuenta, double monto)
        {
            if (!cuentas.ContainsKey(numeroCuenta))
                return false;

            var cuenta = cuentas[numeroCuenta];
            if (monto <= 0 || monto > cuenta.obtenerSaldo())
                return false;

            cuenta.cambiarSaldo(cuenta.obtenerSaldo() - monto);
            return true;
        }

        public bool Transferencia(string cuentaOrigen, double monto, string cuentaDestino)
        {
            if (!cuentas.ContainsKey(cuentaOrigen) || !cuentas.ContainsKey(cuentaDestino))
                return false;

            var origen = cuentas[cuentaOrigen];
            var destino = cuentas[cuentaDestino];

            if (monto <= 0 || monto > origen.obtenerSaldo())
                return false;

            origen.cambiarSaldo(origen.obtenerSaldo() - monto);
            destino.cambiarSaldo(destino.obtenerSaldo() + monto);
            return true;
        }

        public CuentaBancaria obtenerCuenta(string numeroCuenta)
        {
            if (cuentas.ContainsKey(numeroCuenta))
                return cuentas[numeroCuenta];
            return null;
        }
    }
}
