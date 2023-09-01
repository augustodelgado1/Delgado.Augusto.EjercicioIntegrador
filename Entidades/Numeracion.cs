using System;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;

namespace Entidades
{
    public enum ESistema
    {
        Decimal,
        Binario
    }
    public class Numeracion
    {
        private ESistema sistema;
        private double valorNumerico;
        private void InicializarValores(double valorNumerico, ESistema sistema)
        {
            this.sistema = sistema;
            this.valorNumerico = valorNumerico;
        }
        public Numeracion(double valorNumerico, ESistema sistema)
        {
            InicializarValores(valorNumerico,sistema);
        }

        public Numeracion(string valor, ESistema sistema)
        {
            
            
        }

        /// <summary>
        /// Este retornara una cadena representada en un sistema de numeración basado en el parámetro recibido.
        /// </summary>
        /// <param name="sistema"> el sistema de numeracion (Decimal o Binario) </param>
        /// <returns> retornara una cadena representada en un sistema de numeración  </returns>
        public string ConvertirA(ESistema sistema)
        {
            string result = null;
/*
            if (sistema == ESistema.Decimal)
            {
                result = BinarioDecimal(this.valorNumerico.ToString()).ToString();
            }
            else
            {
                if(sistema == ESistema.Binario)
                {
                    result = DecimalBinario(this.ValorNumerico);
                }
            }*/

            return result;

        }

        /// <summary>
        /// Valida que la cadena de caracteres sea un numero binario
        /// </summary>
        /// <param name="valor">un numero binario (solo 0 y 1)</param>
        /// <returns> (true) si no es un numero binario,
        /// De caso contrario retornara (false) </returns>
        private bool EsBinario(string valor)
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
        
        /// Convierte un número binario a decimal.
        /// 
        /// <param name="valor">un numero binario</param>
        /// 
        /// <returns> el numero binario pasado a decimal,Caso contrario retornará "-1" </returns>
        private double BinarioDecimal(string valor)
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

        /// convertirán un número decimal a binario Caso contrario retornará
        /// "-1". 
        /// 
        /// <param name="valor"></param>
        /// <returns></returns>
        private string DecimalBinario(string valorStr)
        {
            string result = null;
            int valorInt;

            if (string.IsNullOrEmpty(valorStr) != false
              && int.TryParse(valorStr, out valorInt))
            {
                result = DecimalBinario(valorInt);
            }

            return result;
        }

        private string DecimalBinario(int valor)
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


       /* public string ValorNumerico { get =>;*/
        public ESistema Sistema { get => sistema;  }
    }
}