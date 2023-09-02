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

        public Operacion(Numeracion primerOperador, Numeracion segundoOperador)
        {
            this.primerOperador = primerOperador;
            this.segundoOperador = segundoOperador;
        }

        public Numeracion Operador(char operador)
        {
            Numeracion resultado = null;

            switch (operador)
            {
                case '*':
                    this.primerOperador * this.segundoOperador;
                    break;
                
                case '-':
                    this.primerOperador - this.segundoOperador;
                    break;

                case '/':
                    this.primerOperador / this.segundoOperador;
                    break;

                default:
                    this.primerOperador + this.segundoOperador;
                    break;
            }

            return resultado;
        }

        

        public Numeracion PrimerOperador { get => primerOperador; set => primerOperador = value; }
        public Numeracion SegundoOperador { get => segundoOperador; set => segundoOperador = value; }

       
    }
}
