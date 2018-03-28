using FolhaDePagamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento.DAL
{
    class FolhaDAO
    {
        private static List<Folha> folhas = new List<Folha>();

        public static bool AdicionarFolha(Folha folha)
        {
            if (BuscarFolhaPorMesAnoCpf(folha) != null)
            {
                return false;
            }
            folhas.Add(folha);
            return true;
        }

        public static List<Folha> RetornarFolhas()
        {
            return folhas;
        }

        public static Folha BuscarFolhaPorMesAnoCpf(Folha folha)
        {
            foreach (Folha folhaCadastrada in folhas)
            {
                if (folhaCadastrada.Funcionario.Cpf.Equals(folha.Funcionario.Cpf) &&
                    folhaCadastrada.Ano == folha.Ano &&
                    folhaCadastrada.Mes == folha.Mes)
                {
                    return folhaCadastrada;
                }
            }
            return null;
        }

        public static List<Folha>BuscarFolhasPorMesAno(Folha folha)
        {
            List<Folha> listaAux = new List<Folha>(); 
            foreach (Folha folhaCadastrada in folhas)
            {
                if(folhaCadastrada.Mes == folha.Mes && 
                    folhaCadastrada.Ano == folha.Ano)
                {
                    listaAux.Add(folhaCadastrada);
                }
            }
            return listaAux;
        }
    }
}