using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Sistema
{
    public class SistemaInterno
    {
        public bool Logar(IAutenticavel funcionario, string senha)
        {
            bool usurioAutenticado = funcionario.Autenticar(senha);

            if (usurioAutenticado)
            {
                Console.WriteLine("ACESSO GARANTIDO!");
                return true;
            }
            else
            {
                Console.WriteLine("acesso negado!!");
                return false;
            }


        }
    }
}
