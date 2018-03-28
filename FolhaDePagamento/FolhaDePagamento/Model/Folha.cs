using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento.Model
{
    class Folha
    {
        //Construtor
        public Folha(string nome, int ano)
        {
            this.Ano = ano;
        }
        public Folha()
        {
            Funcionario = new Funcionario();
        }

        //Atributos/Propriedades
        public Funcionario Funcionario { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int QuantidadeHoras { get; set; }
        public double ValorHora { get; set; }

        //Impressão do Objeto
        public override string ToString()
        {
            return "Nome: " + Funcionario.Nome + " CPF: " + Funcionario.Cpf;
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
