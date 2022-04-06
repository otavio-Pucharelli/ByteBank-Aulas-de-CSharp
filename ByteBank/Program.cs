using ByteBank.Funcionarios;
using ByteBank.Sistema;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch (Exception ex)
            {
                Console.WriteLine("catch no metodo main");
            }
            Console.WriteLine("Execução finalizada. Tecle enter para sair");
            Console.ReadLine();
        }

        private static void CarregarContas()
        {
            using (LeitorDeArquivo leitor = new("teste.txt"))
            {
                leitor.LerProximaLinha();
            }





            //<------------------------------------------------------------->
            //LeitorDeArquivo leitor = null;
            //try
            //{
            //   leitor = new LeitorDeArquivo("contasl.txt");

            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();   
            //}
            //finally
            //{
            //    Console.WriteLine("executando o finnaly");
            //    if (leitor != null){
            //        leitor.Fechar();
            //    }
            //}
        }

        private void TestaInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(4564, 789684);
                ContaCorrente conta2 = new ContaCorrente(7891, 456794);

                // conta1.Transferir(10000, conta2);
                conta1.Sacar(10000);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                // Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");

            }

        }

        // Teste com a cadeia de chamada:
        // Metodo -> TestaDivisao -> Dividir
        private static void Metodo()
        {
            TestaDivisao(0);
        }

        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção com numero=" + numero + " e divisor=" + divisor);
                throw;
                //Console.WriteLine("Código depois do throw");
            }
        }

        /*public static void CalcularBonificacao()
        {
            GerenciadorBonificacao gerenciadorBonificacao = new GerenciadorBonificacao();

            Designer pedro = new Designer("833.555.54-10");
            pedro.Nome = "Pedro";

            Auxiliar jorge = new Auxiliar("833.555.54-10");
            jorge.Nome = "jorge";

            Diretor roberta = new Diretor("833.555.54-10");
            roberta.Nome = "roberta";

            GerenteDeConta lucas = new GerenteDeConta("833.555.54-10");
            lucas.Nome = "lucas";

            gerenciadorBonificacao.Registrar(pedro);
            gerenciadorBonificacao.Registrar(jorge);
            gerenciadorBonificacao.Registrar(roberta);
            gerenciadorBonificacao.Registrar(lucas);

            Console.WriteLine("TOTAL DE BONIFICAÇÃO DO MES: " + gerenciadorBonificacao.GetTotalBoificacao());

        }

        public static void UsarSistema()
        {
            SistemaInterno sistemaInterno = new SistemaInterno();

            Diretor camila = new("487.755.268-59");
            camila.Nome = "camila";
            camila.Senha = "123";

            ParceiroComercial parceiro = new();
            parceiro.Senha = "123456";

            sistemaInterno.Logar(camila, "123");
            sistemaInterno.Logar(camila, "abc");
            sistemaInterno.Logar(parceiro, "123456");

        }
        */    
    }
}

    


