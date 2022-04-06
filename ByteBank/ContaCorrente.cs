// using _05_ByteBank;

namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente? Titular { get; set; }
        public static int TotalDeContasCriadas { get; private set; }
        public int Numero{ get; } // <== readOnly
        public int Agencia { get; } // <== readOnly
        public int contadorSaquesNaoPermitidos { get; private set; }
        public int contadorTrasnferenciasNaoPermitidas { get; private set; }





        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int numeroAgencia, int numeroConta) // <== Construtor
        {
            if (numeroConta <= 0)
            {
                throw new ArgumentException("O argumento Numero deve ser maior que 0!", nameof(numeroConta));
            } 
            
            if(numeroAgencia <= 0)
            {
                throw new ArgumentException("O argumento Agencia deve ser maior que 0!",nameof(numeroAgencia));
            }

            Agencia = numeroAgencia;
            Numero = numeroConta;

            TotalDeContasCriadas++;
        }


        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                contadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
            {
                return false;
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                contadorTrasnferenciasNaoPermitidas++;
                throw new Exception("operação não realizada", ex)
                    ;
            }
            
            return true;
        }
    }
}
