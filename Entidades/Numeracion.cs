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
        private void InicializarValores(string valorNumerico, ESistema sistema)
        {
            int unNumero;
            if (int.TryParse(valorNumerico, out unNumero) == true)
            {
                this.sistema = sistema;
                this.valorNumerico = unNumero;
            }
        }

        public Numeracion(double valorNumerico, ESistema sistema) : this(valorNumerico.ToString(), sistema)
        {

        }

        public Numeracion(string valor, ESistema sistema) 
        {
            InicializarValores(valor, sistema);
        }

        /// <summary>
        /// Este retornara una cadena representada en un sistema de numeración basado en el parámetro recibido.
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
                if (sistema == ESistema.Binario)
                {
                    result = DecimalBinario(this.valorNumerico.ToString());
                }
            }

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

                this.InicializarValores(resultDecimal.ToString(), ESistema.Decimal);
            }
            return resultDecimal;
        }

        /// convertirán un número decimal a binario Caso contrario retornará
        /// "-1". 
        /// 
        /// <param name="valor">un numero </param>
        /// 
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
            string retorno = null;

            do
            {
                resultadoDeLadivision = valor / 2;
                resultadoDeLaMultiplicacion = 2 * resultadoDeLadivision;
                result.Append(valor - resultadoDeLaMultiplicacion);
                valor = resultadoDeLadivision;

                if (valor == 0 || valor == 1)
                {
                    result.Append(valor);
                    retorno = result.ToString();
                    retorno.Reverse();
                    this.sistema = ESistema.Binario;
                    break;
                }

            } while (true);

            return retorno;
        }

        public static bool operator == (Numeracion unNumero,ESistema unSitemaNumerico)
        {
            return unNumero.Sistema == unSitemaNumerico;
        } 
        
        public static bool operator != (Numeracion primerOperador,ESistema unSitemaNumerico)
        {
            return !(primerOperador == unSitemaNumerico);
        }

        public static Numeracion operator +(Numeracion primerOperador, Numeracion segundoOperador)
        {
            return new Numeracion(primerOperador.valorNumerico + segundoOperador.valorNumerico
                 , ESistema.Decimal);
        }

        public static Numeracion operator -(Numeracion primerOperador, Numeracion segundoOperador)
        {
            return new Numeracion(primerOperador.valorNumerico - segundoOperador.valorNumerico
                 ,ESistema.Decimal);
        }

        public static Numeracion operator *(Numeracion primerOperador, Numeracion segundoOperador)
        {
            return new Numeracion(primerOperador.valorNumerico * segundoOperador.valorNumerico
                 , ESistema.Decimal);
        }

        public static Numeracion operator /(Numeracion primerOperador, Numeracion segundoOperador)
        {
            return new Numeracion(primerOperador.valorNumerico / segundoOperador.valorNumerico
                 , ESistema.Decimal);
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

                if (this.sistema == ESistema.Binario)
                {
                   
                }

                return resultado;
            }
        }
        public ESistema Sistema {

            get
            {
                this.sistema = ESistema.Decimal;

                if (this.EsBinario(this.valorNumerico.ToString()) == true)
                {
                    this.sistema = ESistema.Binario;
                }

                return this.sistema;
            }
        }
    }
}