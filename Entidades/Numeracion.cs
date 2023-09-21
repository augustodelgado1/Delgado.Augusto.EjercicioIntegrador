using System;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace Entidades
{
    public enum ESistema
    {
        Decimal = 0,
        Binario
    }
    public class Numeracion
    {

        private ESistema sistema;
        private double valorNumerico;

        /// <summary>
        /// Inicializa los atributos de la clase 
        /// </summary>
        /// <param name="valorNumerico"> una cadena que debe contener un numero
        /// ,en el caso de que no corresponda a un numero se guardara "double.MinValue" </param>
        /// <param name="sistema"> el sistema de numeracion (Decimal o Binario)  </param>
        private void InicializarValores(string valorNumerico, ESistema sistema)
        {
            double unNumero;
            this.valorNumerico = double.MinValue;

            if ((sistema == ESistema.Binario && (unNumero = BinarioDecimal(valorNumerico)) != -1) 
             || double.TryParse(valorNumerico, out unNumero) == true)
            {
                this.valorNumerico = unNumero;
                this.sistema = sistema;
            }
        }

        /// <summary>
        /// es el contructor que inicializa los atributos de la clase
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="sistema"></param>
        public Numeracion(double valorNumerico, ESistema sistema) : this(valorNumerico.ToString(), sistema)
        {

        }

        /// <summary>
        /// es el contructor que inicializa los atributos de la clase
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="sistema"></param>
        public Numeracion(string valor, ESistema sistema) 
        {
            InicializarValores(valor, sistema);
        }


        /// <summary>
        /// Convierte el valor numerico del objeto en un sistema determinado , basado en el parámetro recibido.
        /// 
        /// </summary>
        /// <param name="sistema"> el sistema de numeracion (Decimal o Binario) </param>
        /// <returns> una cadena representada en un sistema de numeración  </returns>
        public string ConvertirA(ESistema sistema)
        {
            string result = null;

            if (sistema == ESistema.Decimal)
            {
                result = this.valorNumerico.ToString();
            }
            else
            {
                if (sistema == ESistema.Binario)
                {
                    result = DecimalBinario((int)this.valorNumerico);
                }
            }
            this.sistema = sistema;

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

            if (EsBinario(valor) == true
             && double.TryParse(valor,out double valorNumerico) == true && valorNumerico >= 0)
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

        /// convertirán un número decimal a binario Caso contrario retornará
        /// "-1". 
        /// 
        /// <param name="valor">un numero </param>
        /// <returns> un número decimal a binario Caso contrario retornará
        /// "-1" </returns>
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
        /// <summary>
        /// Verifica si el valor de numeracion coincide con el sistema pasado por parametro
        /// </summary>
        /// <param name="unSitemaNumerico"></param>
        /// <param name="unNumero"></param>
        /// <returns>(true) en caso de que coincida , (False) de caso contrario </returns>
        public static bool operator == (ESistema unSitemaNumerico, Numeracion unNumero)
        {
            bool respuesta;
            respuesta = unSitemaNumerico == ESistema.Decimal && unNumero.sistema == ESistema.Decimal;
            if (unNumero.sistema == ESistema.Binario && unSitemaNumerico == ESistema.Binario)
            {
                respuesta = EsBinario(unNumero.valorNumerico.ToString());
            }

            return respuesta;
        }

        /// <summary>
        /// Verifica si el valor de numeracion coincide con el sistema pasado por parametro
        /// </summary>
        /// <param name="unSitemaNumerico"></param>
        /// <param name="unNumero"></param>
        /// <returns>(true) en caso de que coincida , (False) de caso contrario </returns>
        public static bool operator != (ESistema unSitemaNumerico, Numeracion primerOperador)
        {
            return !(unSitemaNumerico == primerOperador);
        }

        /// <summary>
        /// Realiza una suma y devuelve el resultado en un sistema determinado , por el sistema 
        /// de los operadores pasados por parametro
        /// 
        /// </summary>
        /// <param name="unSitemaNumerico"></param>
        /// <param name="unNumero"></param>
        /// <returns>el resultado de la suma en un sistema determinado </returns>
        public static Numeracion operator +(Numeracion primerOperador, Numeracion segundoOperador)
        {
            ESistema sistema;
            Numeracion resultado = null;
            
            if (primerOperador.sistema == segundoOperador.sistema)
            {
                sistema = primerOperador.sistema;
                resultado = new Numeracion(primerOperador.valorNumerico + segundoOperador.valorNumerico, sistema);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza una resta y devuelve el resultado en un sistema determinado , por el sistema 
        /// de los operadores pasados por parametro
        /// </summary>
        /// <param name="primerOperador"></param>
        /// <param name="segundoOperador"></param>
        /// <returns>el resultado de la resta en un sistema determinado</returns>
        public static Numeracion operator -(Numeracion primerOperador, Numeracion segundoOperador)
        {
            ESistema sistema;
            Numeracion resultado = null;

            if (primerOperador.sistema == segundoOperador.sistema)
            {
                sistema = primerOperador.sistema;
                resultado = new Numeracion(primerOperador.valorNumerico - segundoOperador.valorNumerico, sistema);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza una multiplicacion y devuelve el resultado en un sistema determinado , por el sistema 
        /// de los operadores pasados por parametro
        /// </summary>
        /// <param name="primerOperador"></param>
        /// <param name="segundoOperador"></param>
        /// <returns>el resultado de la multiplicacion en un sistema determinado</returns>
        public static Numeracion operator *(Numeracion primerOperador, Numeracion segundoOperador)
        {
            ESistema sistema;
            Numeracion resultado = null;

            if (primerOperador.sistema == segundoOperador.sistema)
            {
                sistema = primerOperador.sistema;
                resultado = new Numeracion(primerOperador.valorNumerico * segundoOperador.valorNumerico, sistema);
            }

            return resultado;
        }
        /// <summary>
        /// Realiza una division y devuelve el resultado en un sistema determinado , por el sistema 
        /// de los operadores pasados por parametro
        /// </summary>
        /// <param name="primerOperador"></param>
        /// <param name="segundoOperador"></param>
        /// <returns>el resultado de la division en un sistema determinado</returns>
        public static Numeracion operator /(Numeracion primerOperador, Numeracion segundoOperador)
        {
            ESistema sistema;
            Numeracion resultado = null;

            if (primerOperador.sistema == segundoOperador.sistema && segundoOperador.valorNumerico != 0)
            {
                sistema = primerOperador.sistema;
                resultado = new Numeracion(primerOperador.valorNumerico / segundoOperador.valorNumerico, sistema);
            }

            return resultado;
        }

        /// <summary>
        /// compara si los dos operadores pasados por parametro , son iguales.
        /// Comparando el valor de numeracion y el sistema
        /// </summary>
        /// <param name="primerOperador"></param>
        /// <param name="segundoOperador"></param>
        /// <returns>(True) si son iguales , de caso contrario (false) </returns>
        public static bool operator ==(Numeracion primerOperador, Numeracion segundoOperador)
        {
            return primerOperador is not null && segundoOperador is not null &&
             primerOperador.valorNumerico == segundoOperador.valorNumerico &&
             primerOperador.sistema == segundoOperador.sistema;
        }
        /// <summary>
        /// compara si los dos operadores pasados por parametro , son distintos.
        /// Comparando el valor de numeracion y el sistema
        /// </summary>
        /// <param name="primerOperador"></param>
        /// <param name="segundoOperador"></param>
        /// <returns>(True) si son distintos , de caso contrario (false) </returns>
        public static bool operator !=(Numeracion primerOperador, Numeracion segundoOperador)
        {
            return !(primerOperador == segundoOperador);
        }


        public string ValorNumerico
        {
            get {
                string resultado ;
                resultado = ConvertirA(this.sistema);
                return resultado;
            }
        }
        public ESistema Sistema {

            get
            {
                if (this.valorNumerico < 0)
                {
                    this.sistema = ESistema.Decimal;
                }
                return this.sistema;
            }
        }
    }
}