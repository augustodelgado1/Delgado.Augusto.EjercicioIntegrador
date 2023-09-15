using Entidades;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

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
            unErrorProvider.Icon = SystemIcons.Error;
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            CargarCmbItems(this.cmbOperacion.Items, listaDeOperadores);
            rdbDecimal.Checked = true;
            this.lblResultado.Visible = false;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (cmbOperacion.SelectedItem is char
             && string.IsNullOrEmpty(unErrorProvider.GetError(txtPrimerOperador)) == true
             && string.IsNullOrEmpty(unErrorProvider.GetError(txtSegundoOperador)) == true
             && (primerOperando = new Numeracion(txtPrimerOperador.Text, ESistema.Decimal)) is not null
             && (segundoOperando = new Numeracion(txtSegundoOperador.Text, ESistema.Decimal)) is not null)
            {
                calculadora = new Operacion(primerOperando, segundoOperando);
                resultado = calculadora.Operador((char)cmbOperacion.SelectedItem);
                SetResultado();
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarListaDeTextBox(this.Controls);
            unErrorProvider.Clear();
            this.primerOperando = null;
            this.segundoOperando = null;
            if (resultado is not null)
            {
                resultado = null;
                this.lblResultado.Visible = false;
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
            unErrorProvider.SetError(this.txtPrimerOperador, "Por favor, ingrese un número válido.");
            if (double.TryParse(this.txtPrimerOperador.Text, out double primerNumero))
            {
                unErrorProvider.Clear();
            }
        }
        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {
            unErrorProvider.SetError(this.txtSegundoOperador, "Por favor, ingrese un número válido.");
            if (double.TryParse(this.txtSegundoOperador.Text, out double primerNumero))
            {
                unErrorProvider.Clear();
            }
        }

        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBinario.Checked == true)
            {
                sistema = ESistema.Binario;
                SetResultado();
            }
        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDecimal.Checked == true)
            {
                sistema = ESistema.Decimal;
                SetResultado();
            }

        }


        #region Metodos
        private void LimpiarListaDeTextBox(Control.ControlCollection listaDeControles)
        {

            if (listaDeControles is not null)
            {
                foreach (Control unControl in listaDeControles)
                {
                    if (unControl is not null && unControl is TextBox)
                    {
                        ((TextBox)unControl).Clear();
                    }
                }
            }
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
            if (resultado is not null)
            {
                if (sistema != resultado)
                {
                    resultado.ConvertirA(sistema);
                }
                this.lblResultado.Visible = true;
                this.lblResultado.Text = $"Resultado : {resultado.ValorNumerico}";
            }
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {

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