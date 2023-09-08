using System;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using System.Text;

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

        /// <summary>
        /// Inicializa el valor de los atributos 
        /// </summary>
        /// <param name="valorNumerico"></param>
        /// <param name="sistema"></param>
        private void InicializarValores(string valorNumerico, ESistema sistema)
        {
            double unNumero;
            this.sistema = sistema;
            this.valorNumerico = 0;
            if (double.TryParse(valorNumerico, out unNumero) == true )
            {
                this.valorNumerico = unNumero;
            }
        }

        public Numeracion(double valorNumerico, ESistema sistema) : this(valorNumerico.ToString(), sistema)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="sistema"></param>
        public Numeracion(string valor, ESistema sistema) 
        {
            InicializarValores(valor, sistema);
        }

        /// <summary>
        /// Verifica si un string contiene solo numeros 
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>(true) si contiene solo numeros 
        /// (false) de caso contrario.</returns>
        public static bool EsNumerica(string valor)
        {
            bool retorno = false;
            if (string.IsNullOrEmpty(valor) == false)
            {
                retorno = true;
                foreach (char unCaracter in valor)
                {
                    if(char.IsDigit(unCaracter) == false)
                    {
                        retorno = false;
                        break;
                    }
                }
            }
            return retorno; 
        }
        /// <summary>
        /// Este retornara una cadena representada en un sistema de numeración 
        /// basado en el parámetro recibido.
        /// </summary>
        /// <param name="sistema"> el sistema de numeracion (Decimal o Binario) </param>
        /// <returns> retornara una cadena representada en un sistema de numeración  </returns>
        public string ConvertirA(ESistema sistema)
        {
            string result = null;
            
            if (sistema == ESistema.Decimal)
            {
                result = BinarioDecimal(this.valorNumerico.ToString()).ToString();
            }
            else
            {
                result = DecimalBinario((int)this.valorNumerico); 
            }

            InicializarValores(result, sistema);

            return result;

        } 

        /// <summary>
        /// Valida que la cadena de caracteres sea un numero binario
        /// </summary>
        /// <param name="valor">un numero binario (solo 0 y 1)</param>
        /// <returns> (true) si no es un numero binario,
        /// De caso contrario retornara (false) </returns>
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
                for (int i = valor.Length-1; i >= 0; i--)
                {
                    if (int.TryParse(valor[i].ToString(), out unNumero) == true)
                    {
                        Math.Pow(2, contador);
                        resultDecimal += Math.Pow(2, contador) * unNumero;
                        contador++;
                    }
                }
            }
            return resultDecimal;
        }

        /// convertirán un número decimal a binario Caso contrario retornará
        /// "-1". 
        /// 
        /// <param name="valor">un numero </param>
        /// <returns> un número decimal a binario Caso contrario retornará
        /// "-1" </returns>
        private string DecimalBinario(string valorStr)
        {
            string result = null;
            int valorInt;

            if (string.IsNullOrEmpty(valorStr) != true
              && int.TryParse(valorStr, out valorInt))
            {
                result = DecimalBinario(valorInt);
            }

            return result;
        }

        private string DecimalBinario(int valor)
        {
            StringBuilder result = new StringBuilder();
            int resultadoDeLadivision;
            int resultadoDeLaMultiplicacion;
            char[] arr = null;
            do
            {
                resultadoDeLadivision = valor / 2;
                resultadoDeLaMultiplicacion = 2 * resultadoDeLadivision;
                result.Append(valor - resultadoDeLaMultiplicacion);
                valor = resultadoDeLadivision;

                if (valor == 0 || valor == 1)
                {
                    result.Append(valor);
                    arr = result.ToString().ToCharArray();
                    Array.Reverse(arr);
                    break;
                }

            } while (true);

            return new string(arr);
        }

        public static bool operator == (Numeracion unNumero,ESistema unSitemaNumerico)
        {
            bool respuesta;
            respuesta = EsBinario(unNumero.valorNumerico.ToString());
            if (unSitemaNumerico == ESistema.Decimal && respuesta == false)
            {
                respuesta = true;
            }

            return respuesta;
        } 
        
        public static bool operator != (Numeracion primerOperador,ESistema unSitemaNumerico)
        {
            return !(primerOperador == unSitemaNumerico);
        }

        public static Numeracion operator +(Numeracion primerOperador, Numeracion segundoOperador)
        {
            Numeracion resultado;
            
            resultado = new Numeracion(primerOperador.valorNumerico + segundoOperador.valorNumerico, ESistema.Decimal);
            if (primerOperador == ESistema.Binario && segundoOperador == ESistema.Binario)
            {
                resultado.valorNumerico = primerOperador.BinarioDecimal(primerOperador.ValorNumerico) 
                 + segundoOperador.BinarioDecimal(segundoOperador.ValorNumerico);
                 resultado.sistema = ESistema.Binario;
            }

            return resultado;
        }

        public static Numeracion operator -(Numeracion primerOperador, Numeracion segundoOperador)
        {
            Numeracion resultado;

            resultado = new Numeracion(primerOperador.valorNumerico - segundoOperador.valorNumerico, ESistema.Decimal);
            /*if (primerOperador.sistema == ESistema.Binario && segundoOperador.sistema == ESistema.Binario)
            {
                resultado.valorNumerico = primerOperador.BinarioDecimal(primerOperador.ValorNumerico)
                 - segundoOperador.BinarioDecimal(segundoOperador.ValorNumerico);
                resultado.sistema = ESistema.Binario;
            }*/

            return resultado; 
        }

        public static Numeracion operator *(Numeracion primerOperador, Numeracion segundoOperador)
        {
            Numeracion resultado;

            resultado = new Numeracion(primerOperador.valorNumerico * segundoOperador.valorNumerico, ESistema.Decimal);
            /*if (primerOperador.sistema == ESistema.Binario && segundoOperador.sistema == ESistema.Binario)
            {
                resultado.valorNumerico = primerOperador.BinarioDecimal(primerOperador.ValorNumerico)
                 * segundoOperador.BinarioDecimal(segundoOperador.ValorNumerico);
                resultado.sistema = ESistema.Binario;
            }*/

            return resultado; 
        }

        public static Numeracion operator /(Numeracion primerOperador, Numeracion segundoOperador)
        {
            Numeracion resultado;

            resultado = new Numeracion(primerOperador.valorNumerico / segundoOperador.valorNumerico, ESistema.Decimal);

            return resultado; 
        }
        public static bool operator ==(Numeracion primerOperador, Numeracion segundoOperador)
        {
            return primerOperador is not null && segundoOperador is not null &&
             primerOperador.valorNumerico == segundoOperador.valorNumerico &&
             primerOperador.sistema == segundoOperador.sistema;
        }
        public static bool operator !=(Numeracion primerOperador, Numeracion segundoOperador)
        {
            return !(primerOperador == segundoOperador);
        }


        public string ValorNumerico
        {
            get {
                string resultado ;

                resultado = this.valorNumerico.ToString();

                if (this != this.sistema)
                {
                    resultado = ConvertirA(this.sistema);
                }

                return resultado;
            }
        }
        public ESistema Sistema {

            get
            { 
                return this.sistema;
            }
        }
    }
}