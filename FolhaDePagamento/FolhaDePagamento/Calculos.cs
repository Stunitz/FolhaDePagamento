using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    /// <summary>
    /// Classe que contém cálculos para salário
    /// </summary>
    class Calculos
    {
        public static double CalcularSalarioBruto(int quantidadeHoras, double valorHora)
        {
            return quantidadeHoras * valorHora;
        }

        /// <summary>
        /// Calcular o o INSS
        /// </summary>
        /// <param name="salarioBruto"></param>
        /// <returns></returns>
        public static double CalcularINSS(double salarioBruto)
        {
            if (salarioBruto <= 1659.38)
            {
                return salarioBruto * .08;
            }
            else
            {
                if (salarioBruto <= 2765.66)
                {
                    return salarioBruto * .09;
                }
                else
                {
                    if (salarioBruto <= 5531.31)
                    {
                        return salarioBruto * .11;
                    }
                    else
                    {
                        return 608.44;
                    }
                }
            }
        }

        public static double CalcularIRRF(double salarioBruto)
        {
            if (salarioBruto <= 1903.98)
            {
                return 0;
            }
            else
            {
                if (salarioBruto <= 2862.65)
                {
                    return (salarioBruto * .075) - 142.80;
                }
                else
                {
                    if (salarioBruto <= 3751.05)
                    {
                        return (salarioBruto * .15) - 354.80;
                    }
                    else
                    {
                        if (salarioBruto <= 4664.68)
                        {
                            return (salarioBruto * .225) - 636.13;
                        }
                        else
                        {
                            return (salarioBruto * .275) - 869.36;
                        }
                    }
                }
            }
        }

        public static double CalcularFGTS(double salaBruto)
        {
            return salaBruto * .08;
        }

        public static double CalcularSalarioLiquido(double salarioBruto, double inss, double irrf)
        {
            return salarioBruto - inss - irrf;
        }
        
    }
}
