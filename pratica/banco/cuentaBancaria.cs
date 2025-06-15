namespace BancoApp
{
    public class CuentaBancaria
    {
        private string numeroCuenta;
        private double saldo;
        private string titular;

        public CuentaBancaria(string numeroCuenta, string titular, double saldoInicial)
        {
            this.numeroCuenta = numeroCuenta;
            this.titular = titular;
            this.saldo = saldoInicial;
        }

        public double ObtenerSaldo()
        {
            return saldo;
        }

        public void ModificarSaldo(double nuevoSaldo)
        {
            saldo = nuevoSaldo;
        }

        public string ObtenerNumeroCuenta()
        {
            return numeroCuenta;
        }

        public string ObtenerTitular()
        {
            return titular;
        }
    }
}

