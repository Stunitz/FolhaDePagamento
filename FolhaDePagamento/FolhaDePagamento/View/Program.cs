using FolhaDePagamento.DAL;
using FolhaDePagamento.Model;
using FolhaDePagamento.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento.View
{
    class Program
    {
        private static Folha folha = new Folha();
        private static Funcionario funcionario = new Funcionario();

        static void Main(string[] args)
        {
            string op;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Cadastrar Funcionário");
                Console.WriteLine("2 - Cadastrar Folha de Pagamento");
                Console.WriteLine("3 - Calcular Folha de Pagamento");
                Console.WriteLine("4 - Listar Folhas de Pagamento");
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
                    case "4":
                        OpcaoMenu04();
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
            funcionario = new Funcionario();
            Console.WriteLine(" -- CADASTRAR FUNCIONÁRIO --\n");
            Console.WriteLine("Digite o CPF do funcionário:");
            funcionario.Cpf = Console.ReadLine();
            if (Validar.Cpf(funcionario.Cpf))
            {
                Console.WriteLine("Digite o nome do funcionário:");
                funcionario.Nome = Console.ReadLine();
                if (FuncionarioDAO.AdicionarFuncionario(funcionario))
                {
                    Console.WriteLine("Funcionário adicionado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Funcionário não cadastrado!");
                }
            }
            else
            {
                Console.WriteLine("CPF inválido!");
            }
        }

        private static void OpcaoMenu02()
        {
            folha = new Folha();
            funcionario = new Funcionario();
            Console.Clear();
            Console.WriteLine(" -- CADASTRAR FOLHA --\n");
            Console.WriteLine("Digite o CPF do funcionário:");
            funcionario.Cpf = Console.ReadLine();
            funcionario = FuncionarioDAO.BuscarFuncionarioPorCPF(funcionario);
            if (funcionario != null)
            {
                folha.Funcionario = funcionario;
                Console.WriteLine("Digite o mês da folha de pagamento:");
                folha.Mes = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite o ano da folha de pagamento:");
                folha.Ano = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite a quantidade de horas da folha de pagamento:");
                folha.QuantidadeHoras = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite o valor da hora da folha de pagamento:");
                folha.ValorHora = Convert.ToDouble(Console.ReadLine());
                if (FolhaDAO.AdicionarFolha(folha))
                {
                    Console.WriteLine("\nFolha de Pagamento cadastrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nFolha de Pagamento não cadastrada!");
                }
            }
            else
            {
                Console.WriteLine("\nFuncionário não encontrado!");
            }
        }

        private static void OpcaoMenu03()
        {
            folha = new Folha();
            Console.Clear();
            Console.WriteLine(" -- CALCULAR FOLHA --");

            Console.WriteLine("Digite o CPF do funcionário:");
            folha.Funcionario.Cpf = Console.ReadLine();
            Console.WriteLine("Digite o mês da folha de pagamento:");
            folha.Mes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o ano da folha de pagamento");
            folha.Ano = Convert.ToInt32(Console.ReadLine());

            folha = FolhaDAO.BuscarFolhaPorMesAnoCpf(folha);

            if (folha != null)
            {
                double bruto = Calculos.CalcularSalarioBruto(folha.QuantidadeHoras, folha.ValorHora);
                double inss = Calculos.CalcularINSS(bruto);
                double irrf = Calculos.CalcularIRRF(bruto);
                double fgts = Calculos.CalcularFGTS(bruto);
                double liquido = Calculos.CalcularSalarioLiquido(bruto, inss, irrf);

                Console.WriteLine("\nNome: " + folha.Funcionario.Nome);
                Console.WriteLine("Salário bruto: " + bruto.ToString("C2"));
                Console.WriteLine("INSS: " + inss.ToString("C2"));
                Console.WriteLine("IRRF: " + irrf.ToString("C2"));
                Console.WriteLine("FGTS: " + fgts.ToString("C2"));
                Console.WriteLine("Salário Líquido: " + liquido.ToString("C2"));
            }
            else
            {
                Console.WriteLine("Folha de pagamento não encontrada!");
            }
        }

        private static void OpcaoMenu04()
        {
            folha = new Folha();
            Console.Clear();
            Console.WriteLine(" -- LISTAR FOLHAS POR MÊS E ANO --\n");
            Console.WriteLine("Digite o mês da folha de pagamento:");
            folha.Mes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o ano da folha de pagamento:");
            folha.Ano = Convert.ToInt32(Console.ReadLine());

            double total = 0;

            foreach (Folha folhaCadastrada in FolhaDAO.BuscarFolhasPorMesAno(folha))
            {
                double bruto = Calculos.CalcularSalarioBruto(folhaCadastrada.QuantidadeHoras, folhaCadastrada.ValorHora);
                double inss = Calculos.CalcularINSS(bruto);
                double irrf = Calculos.CalcularIRRF(bruto);
                double fgts = Calculos.CalcularFGTS(bruto);
                double liquido = Calculos.CalcularSalarioLiquido(bruto, inss, irrf);
                total += liquido;
                Console.WriteLine("\nNome: " + folhaCadastrada.Funcionario.Nome);
                Console.WriteLine("Salário bruto: " + bruto.ToString("C2"));
                Console.WriteLine("INSS: " + inss.ToString("C2"));
                Console.WriteLine("IRRF: " + irrf.ToString("C2"));
                Console.WriteLine("FGTS: " + fgts.ToString("C2"));
                Console.WriteLine("Salário Líquido: " + liquido.ToString("C2") + "\n");
            }
            Console.WriteLine("Total do salário do líquido: " + total.ToString("C2"));
        }
    }
}
