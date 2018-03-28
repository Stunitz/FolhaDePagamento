using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    class Program
    {
        private static FolhaDePagamento folha = new FolhaDePagamento();
        private static List<FolhaDePagamento> folhas = 
            new List<FolhaDePagamento>();

        static void Main(string[] args)
        {
            string op;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Cadastrar Folha de Pagamento");
                Console.WriteLine("2 - Calcular Folha de Pagamento");
                Console.WriteLine("3 - Listar Folhas de Pagamento");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("Digite uma opção:");
                op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        OpcaoMenu01();
                        break;
                    case "2":
                        OpcaoMenu02();
                        break;
                    case "3":
                        OpcaoMenu03();
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine("\nAperte uma tecla para continuar...");
                Console.ReadKey();
            } while (!op.Equals("0"));
        }

        private static void OpcaoMenu01()
        {
            Console.Clear();
            Console.WriteLine(" -- CADASTRAR FOLHA --\n");
            Console.WriteLine("Digite o CPF do funcionário:");
            folha.Cpf = Console.ReadLine();
            Console.WriteLine("Digite o nome do funcionário:");
            folha.Nome = Console.ReadLine();
            Console.WriteLine("Digite o mês da folha de pagamento:");
            folha.Mes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o ano da folha de pagamento:");
            folha.Ano = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a quantidade de horas da folha de pagamento:");
            folha.QuantidadeHoras = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o valor da hora da folha de pagamento:");
            folha.ValorHora = Convert.ToDouble(Console.ReadLine());
            folhas.Add(folha);
            Console.WriteLine("\nFolha de Pagamento cadastrada com sucesso!");
        }

        private static void OpcaoMenu02()
        {
            Console.Clear();
            Console.WriteLine(" -- CALCULAR FOLHA --");
            double bruto = Calculos.CalcularSalarioBruto(folha.QuantidadeHoras, folha.ValorHora);
            double inss = Calculos.CalcularINSS(bruto);
            double irrf = Calculos.CalcularIRRF(bruto);
            double fgts = Calculos.CalcularFGTS(bruto);
            double liquido = Calculos.CalcularSalarioLiquido(bruto, inss, irrf);

            Console.WriteLine("\nNome: " + folha.Nome);
            Console.WriteLine("Salário bruto: " + bruto.ToString("C2"));
            Console.WriteLine("INSS: " + inss.ToString("C2"));
            Console.WriteLine("IRRF: " + irrf.ToString("C2"));
            Console.WriteLine("FGTS: " + fgts.ToString("C2"));
            Console.WriteLine("Salário Líquido: " + liquido.ToString("C2"));
        }

        private static void OpcaoMenu03()
        {
            Console.Clear();
            Console.WriteLine(" -- LISTAR FOLHAS --\n");
            
            //for(int i = 0; i < folhas.Count; i++)
            //{
            //    Console.WriteLine(folhas[i]);
            //}

            foreach(FolhaDePagamento folhaCadastrada in folhas)
            {
                Console.WriteLine(folhaCadastrada);
            }
        }
    }
}
