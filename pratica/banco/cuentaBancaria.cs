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

        public double obtenerSaldo()
        {
            return saldo;
        }

        public void cambiarSaldo(double nuevoSaldo)
        {
            saldo = nuevoSaldo;
        }

        public string obtenerNumeroCuenta()
        {
            return numeroCuenta;
        }

        public string obtenerTitular()
        {
            return titular;
        }
    }
}
