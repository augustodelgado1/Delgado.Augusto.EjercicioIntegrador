using Entidades;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Delgado.Augusto.EjercicioIntegrador
{
    public partial class FrmCalculadora : Form
    {
        private char[] listaDeOperadores = { '+', '-', '*', '/' };
        private Operacion calculadora;
        private ESistema sistema;
        private Numeracion resultado;
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private const string resultadoConst = "Resultado:";
        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            this.unErrorProvider.Icon = SystemIcons.Error;
            this.CargarCmbItems(this.cmbOperacion.Items, listaDeOperadores);
            this.calculadora = new Operacion(primerOperando, segundoOperando);
            this.rdbDecimal.Checked = true;
            this.lblResultado.Text = resultadoConst;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (ActivarErrorProvider(this.cmbOperacion, "Elija un operador", unControl => unControl is not null && string.IsNullOrWhiteSpace(unControl.Text) == false)
             && ActivarErrorProvider(this.txtPrimerOperador, "Ingrese un numero valido", unControl => unControl is not null && double.TryParse(unControl.Text, out double primerNumero))
             && ActivarErrorProvider(this.txtSegundoOperador, "Ingrese un numero valido", unControl => unControl is not null && double.TryParse(unControl.Text, out double primerNumero))
             && (primerOperando = new Numeracion(txtPrimerOperador.Text, ESistema.Decimal)) is not null
             && (segundoOperando = new Numeracion(txtSegundoOperador.Text, ESistema.Decimal)) is not null)
            {
                this.calculadora.PrimerOperador = primerOperando;
                this.calculadora.SegundoOperador = segundoOperando;
                this.resultado = calculadora.Operador((char)cmbOperacion.SelectedItem);
                this.SetResultado();
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarListaDeTextBox(this.Controls);
            this.unErrorProvider.Clear();

            if (resultado is not null)
            {
                resultado = null;
                this.lblResultado.Text = resultadoConst;
                this.primerOperando = null;
                this.segundoOperando = null;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = ConfirmarSalida("¿Desea cerrar la calculadora?", "Salida");
        }

        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {
            ActivarErrorProvider(this.txtPrimerOperador, "Ingrese un numero valido", unControl => unControl is not null && double.TryParse(unControl.Text, out double primerNumero));
        }
        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {
            ActivarErrorProvider(this.txtSegundoOperador, "Ingrese un numero valido", unControl => unControl is not null && double.TryParse(unControl.Text, out double primerNumero));
        }

        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBinario.Checked == true)
            {
                this.sistema = ESistema.Binario;
                SetResultado();
            }
        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDecimal.Checked == true)
            {
                this.sistema = ESistema.Decimal;
                SetResultado();
            }

        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarErrorProvider(this.cmbOperacion, "Ingrese un operador valido", unControl => string.IsNullOrWhiteSpace(unControl.Text) == false);
        }


        #region Metodos

        /// <summary>
        /// Muestra un error provider informando que condiciones debe cumplir el Control pasado por parametro
        /// </summary>
        /// <param name="unControl">el control</param>
        /// <param name="mensaje">Mensaje informando que condiciones debe cumplir el control</param>
        /// <param name="predicate">el metodo que va a derminar si se cumplieron las condiciones , que debe
        /// retornar (True) en caso que se cumpla o (false) de caso contrario</param>
        /// <returns>(false) en caso de que el control no se cumpla con la condiciones de el metodo pasado por parametro
        /// de lo contrario devueve (true)</returns>
        private bool ActivarErrorProvider(Control unControl, string mensaje, Predicate<Control> predicate)
        {
            bool estado;
            estado = false;
            this.unErrorProvider.SetError(unControl, mensaje);

            if (predicate is not null && predicate.Invoke(unControl) == true)
            {
                this.unErrorProvider.Clear();
                estado = true;
            }

            return estado;
        }

        /// <summary>
        /// Recorre la lista de controles y limpia los text box de la lista de controles
        /// </summary>
        /// <param name="listaDeControles">una lista de controles</param>
        /// <returns>(false) si los parametros no son correcto , (true) de caso contrario </returns>
        private bool LimpiarListaDeTextBox(Control.ControlCollection listaDeControles)
        {
            bool result = false;
            if (listaDeControles is not null)
            {
                result = true;
                foreach (Control unControl in listaDeControles)
                {
                    if (unControl is not null && unControl is TextBox
                     && string.IsNullOrWhiteSpace(unControl.Text) == false)
                    {
                        ((TextBox)unControl).Clear();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Guarda los elementos de un array de char[] ,en una lista de controles de ComboBox
        /// </summary>
        /// <param name="items">Los elementos que se van a guardar</param>
        /// <param name="listaDeOperadores">Donde se va almaser los elementos del array de char[]</param>
        /// <returns>(True) si pudo guardar los elementos , de casoi contrario retorna (false)</returns>
        private bool CargarCmbItems(ComboBox.ObjectCollection items, char[] listaDeOperadores)
        {
            bool estado;
            estado = false;
            if (items is not null)
            {
                estado = true;

                foreach (char unOperador in listaDeOperadores)
                {
                    items.Add(unOperador);
                }
            }

            return estado;
        }

        /// <summary>
        /// le Muestra al usuario un mesaje donde le da la opcion de que si quiere cerrar un form en especifico
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="titulo"></param>
        /// <returns></returns>
        private bool ConfirmarSalida(string mensaje, string titulo)
        {
            bool resultado = false;

            if (string.IsNullOrWhiteSpace(mensaje) == false && string.IsNullOrWhiteSpace(titulo) == false
             && MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                resultado = true;
            }

            return resultado;
        }

        /// <summary>
        /// muestra el resultado de la operación, 
        /// convertido de acuerdo con el sistema numérico seleccionado
        /// </summary>
        private void SetResultado()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{resultadoConst}");
            if (this.resultado is not null)
            {
                stringBuilder.Clear();
                stringBuilder.AppendLine("No se pudo realizar la conversion");

                if ((this.sistema != this.resultado
                && string.IsNullOrWhiteSpace(this.resultado.ConvertirA(sistema)) == false)
                || (this.sistema == this.resultado))
                {
                    stringBuilder.Clear();
                    stringBuilder.AppendLine($"{resultadoConst} {this.resultado.ValorNumerico}");
                }
            }
            this.lblResultado.Text = stringBuilder.ToString();
        }



        #endregion
    }
}