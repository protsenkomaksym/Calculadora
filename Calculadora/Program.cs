using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculadora calculadora = new Calculadora();
            string opcion = string.Empty;

            Console.WriteLine("Elija una opción:");
            Console.WriteLine("1.Suma");
            Console.WriteLine("2.Resta");
            Console.WriteLine("3.Multiplicación");
            Console.WriteLine("4.División");

            opcion = Console.ReadLine();

            try
            {
                switch (opcion)
                {
                    case "1":
                        // Suma
                        Console.WriteLine(calculadora.Suma());
                        break;
                    case "2":
                        // Resta
                        Console.WriteLine(calculadora.Resta());
                        break;
                    case "3":
                        // Multiplicación
                        Console.WriteLine(calculadora.Multiplicacion());
                        break;
                    case "4":
                        // División
                        Console.WriteLine(calculadora.Division());
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Se produjo un error: " + e.ToString());
            }

            Console.ReadKey();
        }
    }

    class Calculadora
    {
        public double Suma()
        {
            double resultado = 0;
            string valor = string.Empty;

            while(valor != "x")
            {
                Console.WriteLine("Ingrese un valor (x para terminar):");
                valor = Console.ReadLine();
                
                double ingreso;
                if (double.TryParse(valor, out ingreso))
                {
                    resultado += ingreso;
                }
            }

            return resultado;
        }

        public double Resta()
        {
            double? resultado = null;
            string valor = string.Empty;

            while (valor != "x")
            {
                Console.WriteLine("Ingrese un valor (x para terminar):");
                valor = Console.ReadLine();

                double ingreso;
                if (double.TryParse(valor, out ingreso))
                {
                    if (resultado == null)
                        resultado = ingreso;
                    else
                        resultado -= ingreso;
                }
            }

            return resultado.GetValueOrDefault();
        }

        public double Multiplicacion()
        {
            double resultado = 0;
            string valor = string.Empty;

            while (valor != "x")
            {
                Console.WriteLine("Ingrese un valor (x para terminar):");
                valor = Console.ReadLine();

                double ingreso;
                if (double.TryParse(valor, out ingreso))
                {
                    resultado = ((resultado == 0) ? 1. : resultado) * ingreso;
                }
            }

            return resultado;
        }

        public double Division()
        {
            double? resultado = null;
            string valor = string.Empty;

            while (valor != "x")
            {
                Console.WriteLine("Ingrese un valor (x para terminar):");
                valor = Console.ReadLine();

                double ingreso;
                if (double.TryParse(valor, out ingreso))
                {
                    if(ingreso == 0)
                    {
                        throw new DivideByZeroException();
                    }

                    resultado = ((resultado == null) ? ingreso : resultado / ingreso);
                }
            }

            return resultado.GetValueOrDefault();
        }
    }
}
