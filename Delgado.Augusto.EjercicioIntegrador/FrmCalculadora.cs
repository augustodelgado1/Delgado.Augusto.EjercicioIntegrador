using Entidades;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Delgado.Augusto.EjercicioIntegrador
{
    public partial class FrmCalculadora : Form
    {
        Operacion calculadora;
        ESistema sistema;
        Numeracion resultado;
        string resultadoBinario;
        double resultadoDecimal;
        Numeracion primerOperando;
        Numeracion segundoOperando;
        public FrmCalculadora()
        {
            InitializeComponent();
            this.cmbOperacion.Items.Add('+');
            this.cmbOperacion.Items.Add('-');
            this.cmbOperacion.Items.Add('*');
            this.cmbOperacion.Items.Add('/');
            rdbDecimal.Checked = true;
            this.cmbOperacion.SelectedItem = '+';
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (cmbOperacion.SelectedItem is not null
             && cmbOperacion.SelectedItem is char
             && DetectarTextBoxVacio(this.Controls) == true && 
             primerOperando is not null
             && segundoOperando is not null)
            {
                SetResultado();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarListaDeTextBox(this.Controls);
            this.primerOperando = null;
            this.segundoOperando = null;

            if (resultado is not null)
            {
                resultado = null;
                this.lblResultado.Text = $"Resultado";
            }
        }

        private void LimpiarPantalla()
        {
            LimpiarListaDeTextBox(this.Controls);
            this.primerOperando = null;
            this.segundoOperando = null;

            if (resultado is not null)
            {
                resultado = null;
                this.lblResultado.Text = $"Resultado";
            }
        }

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

        private bool DetectarTextBoxVacio(Control.ControlCollection listaDeControles)
        {
            bool resultado;
            resultado = false;

            if (listaDeControles is not null && listaDeControles.Count > 0)
            {
                resultado = true;
                foreach (Control unControl in listaDeControles)
                {
                    if (unControl is not null && unControl is TextBox
                     && string.IsNullOrWhiteSpace(((TextBox)unControl).Text) == true)
                    {
                        resultado = false;
                        break;
                    }
                }
            }

            return resultado;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
           e.Cancel = MostrarMensajeAntesDeCerrarLaAplicacion("¿Desea cerrar la calculadora?", "Salida");
        }

        private bool MostrarMensajeAntesDeCerrarLaAplicacion(string mensaje,string titulo)
        {
            bool resultado = false;
            if (MessageBox.Show(mensaje,titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                resultado = true;
            }

            return resultado;
        }

        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrimerOperador.Text) == false)
            {
                primerOperando = new Numeracion(txtPrimerOperador.Text, ESistema.Decimal);
            }
        }

        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSegundoOperador.Text) == false)
            {
                segundoOperando = new Numeracion(txtSegundoOperador.Text, ESistema.Decimal);
            }
        }

        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBinario.Checked == true)
            {
                sistema = ESistema.Binario;
                rdbDecimal.Checked = false;

                if(resultado is not null )
                {
                    this.lblResultado.Text = $"Resultado : {resultadoBinario}";
                }
            }
        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDecimal.Checked == true)
            {
                sistema = ESistema.Decimal;
                rdbBinario.Checked = false;

                if (resultado is not null )
                {
                    this.lblResultado.Text = $"Resultado : {resultado.ValorNumerico}";
                }
            }
            
        }

        private void SetResultado()
        {
            calculadora = new Operacion(primerOperando, segundoOperando);
            resultado = calculadora.Operador((char)cmbOperacion.SelectedItem);
            resultadoBinario = resultado.ConvertirA(ESistema.Binario);
            if (rdbBinario.Checked == true)
            {
                this.lblResultado.Text = $"Resultado : {resultadoBinario}";
            }
            else
            {
                this.lblResultado.Text = $"Resultado : {resultado.ValorNumerico}";
            }
        }

        

       

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