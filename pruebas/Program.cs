using System.Drawing;
using Entidades;
namespace pruebas
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            Numeracion otroNumero = new Numeracion("-14", ESistema.Binario);
            Numeracion tercerNumero = new Numeracion("100", ESistema.Decimal);
            Numeracion cuartoNumero = new Numeracion("100", ESistema.Decimal);
            Console.WriteLine(cuartoNumero.ValorNumerico);
            tercerNumero.ConvertirA(ESistema.Decimal);
            Console.WriteLine(tercerNumero.ValorNumerico);
            Console.WriteLine((tercerNumero + cuartoNumero).ValorNumerico);
            Console.ReadKey();
            /*    unNumero += otroNumero;
                new string(unNumero.ValorNumerico);
                unNumero.ConvertirA(ESistema.Decimal);
                otroNumero.ConvertirA(ESistema.Decimal);

                unNumero += otroNumero;

                unNumero = new Numeracion(1001, ESistema.Decimal) + new Numeracion(1001, ESistema.Decimal);*/
        }

        private static string DecimalBinario(int valor)
        {
            string result = string.Empty;
            int resultadoDeLadivision;
            int resultadoDeLaMultiplicacion;

            do
            {
                resultadoDeLadivision = valor / 2;
                resultadoDeLaMultiplicacion = 2 * resultadoDeLadivision;
                result += (valor - resultadoDeLaMultiplicacion).ToString();
                valor = resultadoDeLadivision;

                if (valor == 0 || valor == 1)
                {
                    result += valor;
                    result.Reverse();
                    break;
                }

            } while (true);

            return result;
        }

        private static bool EsBinario(string valor)
        {
            bool result = false;

            if (string.IsNullOrEmpty(valor) == false)
            {
                result = true;
                foreach (char unCaracter in valor)
                {
                    if (unCaracter != '0' && unCaracter != '1')
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        private static double BinarioDecimal(string valor)
        {
            double resultDecimal = -1;
            int contador;
            int unNumero;
            contador = 0;


            if (EsBinario(valor) == true)
            {
                resultDecimal = 0;
                foreach (char unCaracter in valor)
                {
                    if (int.TryParse(unCaracter.ToString(), out unNumero) == true)
                    {
                        resultDecimal += (Math.Pow(2, contador)) * unNumero;
                        contador++;
                    }
                }
            }
            return resultDecimal;
        }


    }
}