using Entidades;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace Delgado.Augusto.EjercicioIntegrador
{
    public partial class FrmCalculadora : Form
    {
        Operacion calculadora;
        ESistema sistema;
        Numeracion segundoOperador;
        Numeracion primerOperador;
        Numeracion resultado;
        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperacion.Items.Add('+');
            this.cmbOperacion.Items.Add('-');
            this.cmbOperacion.Items.Add('*');
            this.cmbOperacion.Items.Add('/');
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

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

        private void DetectarTextBoxVacio(Control.ControlCollection listaDeControles)
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
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBinario.Checked == true)
            {
                sistema = ESistema.Binario;
            }
        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbDecimal.Checked == true)
            {
                sistema = ESistema.Decimal;
            }
        }

        private void SetResultado()
        {

        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            

            

            foreach (var item in this.cmbOperacion.Items)
            {
                if(item is char && item is not null)
                {

                    break;
                }
            }
        }

        /*    
    6. El ComboBox no debe permitir ser editado a mano (escribiendo desde el teclado).
    Solo se debe poder seleccionar alguna de las opciones.
    a. +
    b. –
    c. /
    d. *
    7. El TabIndex debe darse de izquierda a derecha y de arriba hacia abajo, siendo
            txtNumero1 el índice más bajo y los radioButtons el más alto.
    Y el siguiente diagrama de clases:

    8. Recordar que los métodos Dispose e InitializeComponent, así como los atributos
    del diagrama se encuentran definidos en la clase del diseñador. No deben crearlos.
    9. El método Limpiar será llamado por el evento click del botón btnLimpiar, este
    borrará los datos de los TextBox, Label de resultado de la pantalla y también
    asignará null al atributo resultado del formulario.

    10. El método setResultado mostrara el resultado de la operación, convertido de
    acuerdo al sistema numérico seleccionado, siempre y cuando este no sea nulo.
    11. El botón btnCerrar deberá cerrar el formulario.
    12. Los radioButtons de Sistema
    13. Implementar el manejador de evento necesario para que al intentar cerrar el
    formulario por cualquier método pregunte "¿Desea cerrar la calculadora?". Si
    contesta SI se cerrará, si contesta NO debe continuar en ejecución.*/
    }
}