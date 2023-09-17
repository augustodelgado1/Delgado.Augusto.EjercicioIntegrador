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
        char[] listaDeOperadores = { '+', '-', '*', '/' };
        Operacion calculadora;
        ESistema sistema;
        Numeracion resultado;
        Numeracion primerOperando;
        Numeracion segundoOperando;
        public FrmCalculadora()
        {
            InitializeComponent();
            this.unErrorProvider.Icon = SystemIcons.Error;
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            this.CargarCmbItems(this.cmbOperacion.Items, listaDeOperadores);
            this.rdbDecimal.Checked = true;
            this.lblResultado.Visible = false;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (ActivarErrorProvider(this.cmbOperacion, "Ingrese un operador valido", unControl => unControl is not null && string.IsNullOrWhiteSpace(unControl.Text) == false)
             && ActivarErrorProvider(this.txtPrimerOperador, "Ingrese un numero valido", unControl => unControl is not null && double.TryParse(unControl.Text, out double primerNumero))
             && ActivarErrorProvider(this.txtSegundoOperador, "Ingrese un numero valido", unControl => unControl is not null && double.TryParse(unControl.Text, out double primerNumero))
             && (primerOperando = new Numeracion(txtPrimerOperador.Text, ESistema.Decimal)) is not null
             && (segundoOperando = new Numeracion(txtSegundoOperador.Text, ESistema.Decimal)) is not null)
            {
                this.calculadora = new Operacion(primerOperando, segundoOperando);
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
                this.lblResultado.Visible = false;
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


        #region Metodos
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

        private bool CargarCmbItems(ComboBox.ObjectCollection items, char[] listaDeOperadores)
        {
            bool estado;
            estado = false;
            if (items is not null)
            {
                estado = true;
                items.Clear();
                foreach (char unOperador in listaDeOperadores)
                {
                    items.Add(unOperador);
                }
            }

            return estado;
        }
        private bool ConfirmarSalida(string mensaje, string titulo)
        {
            bool resultado = false;

            if (MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                resultado = true;
            }

            return resultado;
        }

        private void SetResultado()
        {
            if (this.resultado is not null)
            {
                if (this.sistema != this.resultado)
                {
                    this.resultado.ConvertirA(sistema);
                }
                this.lblResultado.Visible = true;
                this.lblResultado.Text = $"Resultado : {this.resultado.ValorNumerico}";
            }
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarErrorProvider(this.cmbOperacion, "Ingrese un operador valido", unControl => string.IsNullOrWhiteSpace(unControl.Text) == false);
        }

        #endregion





        /*    
    7. El TabIndex debe darse de izquierda a derecha y de arriba hacia abajo, siendo
            txtNumero1 el índice más bajo y los radioButtons el más alto.
    Y el siguiente diagrama de clases:

    9. El método Limpiar será llamado por el evento click del botón btnLimpiar, este
    borrará los datos de los TextBox, Label de resultado de la pantalla y también
    asignará null al atributo resultado del formulario.

    10. El método setResultado mostrara el resultado de la operación, convertido de
    acuerdo al sistema numérico seleccionado, siempre y cuando este no sea nulo.
    12. Los radioButtons de Sistema.*/
    }
}