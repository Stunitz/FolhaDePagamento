using FolhaDePagamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento.DAL
{
    class FuncionarioDAO
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();

        public static bool AdicionarFuncionario(Funcionario funcionario)
        {
            if(BuscarFuncionarioPorCPF(funcionario) != null)
            {
                return false;
            }
            funcionarios.Add(funcionario);
            return true;
        }

        public static Funcionario BuscarFuncionarioPorCPF(Funcionario funcionario)
        {
            foreach (Funcionario funcionarioCadastrado in 
                funcionarios)
            {
                if (funcionarioCadastrado.Cpf.
                    Equals(funcionario.Cpf))
                {
                    return funcionarioCadastrado;
                }
            }
            return null;
        }

    }
}
