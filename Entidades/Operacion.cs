using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operacion
    {
        private Numeracion primerOperador;
        private Numeracion segundoOperador;

        /// <summary>
        /// es el contructor de la clase que inicializa el valor de los atributos
        /// </summary>
        /// <param name="primerOperador"></param>
        /// <param name="segundoOperador"></param>
        public Operacion(Numeracion primerOperador, Numeracion segundoOperador)
        {
            this.PrimerOperador = primerOperador;
            this.SegundoOperador = segundoOperador;
        }

        /// <summary>
        /// Realiza una operacion determinada entre dos operadores y develve el resultado en un sistema 
        /// en especifico
        /// </summary>
        /// <param name="operador">la opercion que desea realizar (+,-,*,/)</param>
        /// <returns>el resultado de la operacion ,en caso de no recibir un operador valido realizara 
        /// una suma</returns>
        public Numeracion Operador(char operador)
        {
            Numeracion resultado = null;

            switch (operador)
            {
                case '*':
                    resultado = this.primerOperador * this.segundoOperador;
                    break;

                case '-':
                    resultado = this.primerOperador - this.segundoOperador;
                    break;

                case '/':
                    resultado = this.primerOperador / this.segundoOperador;
                    break;

                default:
                    resultado = this.primerOperador + this.segundoOperador;
                    break;
            }


            return resultado;
        }



        public Numeracion PrimerOperador { get { return primerOperador; } 
            
            set {
                if (value is not null && (value == segundoOperador || segundoOperador is null))
                {
                    primerOperador = value;
                } 
            } 
        }


        public Numeracion SegundoOperador { get { return segundoOperador; }
            
            set
            {
                if (value is not null && (value == primerOperador || primerOperador is null))
                {
                    segundoOperador = value;
                }
            }
        }


    }
}
