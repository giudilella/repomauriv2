using System;
using System.Collections.Generic;

namespace BancoApp
{
    public class Banco
    {
        private Dictionary<string, CuentaBancaria> cuentas = new Dictionary<string, CuentaBancaria>();

        public void AgregarCuenta(CuentaBancaria cuenta)
        {
            cuentas[cuenta.ObtenerNumeroCuenta()] = cuenta;
        }

        public bool Depositar(string numeroCuenta, double monto)
        {
            if (monto <= 0 || !cuentas.ContainsKey(numeroCuenta))
                return false;

            var cuenta = cuentas[numeroCuenta];
            cuenta.ModificarSaldo(cuenta.ObtenerSaldo() + monto);
            return true;
        }

        public bool Extraer(string numeroCuenta, double monto)
        {
            if (!cuentas.ContainsKey(numeroCuenta))
                return false;

            var cuenta = cuentas[numeroCuenta];
            if (monto <= 0 || monto > cuenta.ObtenerSaldo())
                return false;

            cuenta.ModificarSaldo(cuenta.ObtenerSaldo() - monto);
            return true;
        }

        public bool Transferencia(string cuentaOrigen, double monto, string cuentaDestino)
        {
            if (!cuentas.ContainsKey(cuentaOrigen) || !cuentas.ContainsKey(cuentaDestino))
                return false;

            var origen = cuentas[cuentaOrigen];
            var destino = cuentas[cuentaDestino];

            if (monto <= 0 || monto > origen.ObtenerSaldo())
                return false;

            origen.ModificarSaldo(origen.ObtenerSaldo() - monto);
            destino.ModificarSaldo(destino.ObtenerSaldo() + monto);
            return true;
        }

        public CuentaBancaria ObtenerCuenta(string numeroCuenta)
        {
            if (cuentas.ContainsKey(numeroCuenta))
                return cuentas[numeroCuenta];
            return null;
        }
    }
}
