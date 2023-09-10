using System;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace Entidades
{
    public enum ESistema
    {
        Decimal = 0,
        Binario = 1
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

            if (double.TryParse(valorNumerico, out unNumero) == true )
            {
                this.valorNumerico = unNumero;
                this.sistema = sistema;
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
                if (sistema == ESistema.Binario)
                {
                    result = DecimalBinario((int)this.valorNumerico);
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
                InicializarValores(resultDecimal.ToString(), ESistema.Decimal);
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

            if (this != ESistema.Binario)
            {
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
                        InicializarValores(new string(arr), ESistema.Binario);
                        break;
                    }

                } while (true);
            }

            return new string(arr);
        }

        public static bool operator == (Numeracion unNumero,ESistema unSitemaNumerico)
        {
            bool respuesta;
            respuesta = unSitemaNumerico == ESistema.Decimal && unNumero.sistema == ESistema.Decimal;
            if (unNumero.sistema == ESistema.Binario && unSitemaNumerico == ESistema.Binario)
            {
                respuesta = EsBinario(unNumero.valorNumerico.ToString());
            }

            return respuesta;
        } 
        
        public static bool operator != (Numeracion primerOperador,ESistema unSitemaNumerico)
        {
            return !(primerOperador == unSitemaNumerico);
        }

        public static Numeracion operator +(Numeracion primerOperador, Numeracion segundoOperador)
        {
            ESistema sistema;
            Numeracion auxiliar = new Numeracion(primerOperador.valorNumerico, ESistema.Decimal);
            Numeracion otroAuxiliar = new Numeracion(segundoOperador.valorNumerico, ESistema.Decimal);
            sistema = ESistema.Decimal;
            
            if (primerOperador.sistema == ESistema.Binario && segundoOperador.sistema == ESistema.Binario)
            {
                auxiliar.ConvertirA(ESistema.Decimal);
                otroAuxiliar.ConvertirA(ESistema.Decimal);
                sistema = ESistema.Binario;
            }

            return new Numeracion(auxiliar.valorNumerico + otroAuxiliar.valorNumerico, sistema);
        }
        public static Numeracion operator -(Numeracion primerOperador, Numeracion segundoOperador)
        {
            ESistema sistema;
            Numeracion auxiliar = new Numeracion(primerOperador.valorNumerico, ESistema.Decimal);
            Numeracion otroAuxiliar = new Numeracion(segundoOperador.valorNumerico, ESistema.Decimal);
            sistema = ESistema.Decimal;

            if (primerOperador.sistema == ESistema.Binario && segundoOperador.sistema == ESistema.Binario)
            {
                auxiliar.ConvertirA(ESistema.Decimal);
                otroAuxiliar.ConvertirA(ESistema.Decimal);
                sistema = ESistema.Binario;
            }

            return new Numeracion(auxiliar.valorNumerico - otroAuxiliar.valorNumerico, sistema);
        }

        public static Numeracion operator *(Numeracion primerOperador, Numeracion segundoOperador)
        {
            ESistema sistema;
            Numeracion auxiliar = new Numeracion(primerOperador.valorNumerico, ESistema.Decimal);
            Numeracion otroAuxiliar = new Numeracion(segundoOperador.valorNumerico, ESistema.Decimal);
            sistema = ESistema.Decimal;

            if (primerOperador.sistema == ESistema.Binario && segundoOperador.sistema == ESistema.Binario)
            {
                auxiliar.ConvertirA(ESistema.Decimal);
                otroAuxiliar.ConvertirA(ESistema.Decimal);
                sistema = ESistema.Binario;
            }

            return new Numeracion(auxiliar.valorNumerico * otroAuxiliar.valorNumerico, sistema);
        }

        public static Numeracion operator /(Numeracion primerOperador, Numeracion segundoOperador)
        {
            ESistema sistema;
            Numeracion auxiliar = new Numeracion(primerOperador.valorNumerico, ESistema.Decimal);
            Numeracion otroAuxiliar = new Numeracion(segundoOperador.valorNumerico, ESistema.Decimal);
            sistema = ESistema.Decimal;

            if (primerOperador.sistema == ESistema.Binario && segundoOperador.sistema == ESistema.Binario)
            {
                auxiliar.ConvertirA(ESistema.Decimal);
                otroAuxiliar.ConvertirA(ESistema.Decimal);
                sistema = ESistema.Binario;
            }

            return new Numeracion(auxiliar.valorNumerico / otroAuxiliar.valorNumerico, sistema);
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