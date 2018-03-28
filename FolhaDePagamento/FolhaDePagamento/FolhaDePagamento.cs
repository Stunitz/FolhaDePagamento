using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    class FolhaDePagamento
    {
        //Construtor
        public FolhaDePagamento(string nome, int ano)
        {
            this.Nome = nome;
            this.Ano = ano;
        }
        public FolhaDePagamento()
        {

        }

        //Atributos/Propriedades
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int QuantidadeHoras { get; set; }
        public double ValorHora { get; set; }

        //Impressão do Objeto
        public override string ToString()
        {
            return "Nome: " + Nome + " CPF: " + Cpf;
        }

        //JAVA
        //private string nome;
        //public void setNome(string nome)
        //{
        //    this.nome = nome;
        //}
        //public string getNome()
        //{
        //    return this.nome;
        //}
    }
}
