namespace Delgado.Augusto.EjercicioIntegrador
{
    partial class FrmCalculadora
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCalculadora));
            btnOperar = new Button();
            btnLimpiar = new Button();
            btnCerrar = new Button();
            cmbOperacion = new ComboBox();
            label1 = new Label();
            lblPrimerOperador = new Label();
            lblOperacion = new Label();
            lblSegundoOperador = new Label();
            grpSistema = new GroupBox();
            rdbBinario = new RadioButton();
            rdbDecimal = new RadioButton();
            txtSegundoOperador = new TextBox();
            txtPrimerOperador = new TextBox();
            grpSistema.SuspendLayout();
            SuspendLayout();
            // 
            // btnOperar
            // 
            resources.ApplyResources(btnOperar, "btnOperar");
            btnOperar.Name = "btnOperar";
            btnOperar.UseVisualStyleBackColor = true;
            btnOperar.Click += btnOperar_Click;
            // 
            // btnLimpiar
            // 
            resources.ApplyResources(btnLimpiar, "btnLimpiar");
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnCerrar
            // 
            resources.ApplyResources(btnCerrar, "btnCerrar");
            btnCerrar.Name = "btnCerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // cmbOperacion
            // 
            resources.ApplyResources(cmbOperacion, "cmbOperacion");
            cmbOperacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOperacion.FormattingEnabled = true;
            cmbOperacion.Items.AddRange(new object[] { resources.GetString("cmbOperacion.Items"), resources.GetString("cmbOperacion.Items1"), resources.GetString("cmbOperacion.Items2"), resources.GetString("cmbOperacion.Items3") });
            cmbOperacion.Name = "cmbOperacion";
            cmbOperacion.SelectedIndexChanged += cmbOperacion_SelectedIndexChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // lblPrimerOperador
            // 
            resources.ApplyResources(lblPrimerOperador, "lblPrimerOperador");
            lblPrimerOperador.Name = "lblPrimerOperador";
            // 
            // lblOperacion
            // 
            resources.ApplyResources(lblOperacion, "lblOperacion");
            lblOperacion.Name = "lblOperacion";
            // 
            // lblSegundoOperador
            // 
            resources.ApplyResources(lblSegundoOperador, "lblSegundoOperador");
            lblSegundoOperador.Name = "lblSegundoOperador";
            // 
            // grpSistema
            // 
            resources.ApplyResources(grpSistema, "grpSistema");
            grpSistema.Controls.Add(rdbBinario);
            grpSistema.Controls.Add(rdbDecimal);
            grpSistema.Name = "grpSistema";
            grpSistema.TabStop = false;
            // 
            // rdbBinario
            // 
            resources.ApplyResources(rdbBinario, "rdbBinario");
            rdbBinario.Name = "rdbBinario";
            rdbBinario.TabStop = true;
            rdbBinario.UseVisualStyleBackColor = true;
            rdbBinario.CheckedChanged += rdbBinario_CheckedChanged;
            // 
            // rdbDecimal
            // 
            resources.ApplyResources(rdbDecimal, "rdbDecimal");
            rdbDecimal.Name = "rdbDecimal";
            rdbDecimal.TabStop = true;
            rdbDecimal.UseVisualStyleBackColor = true;
            rdbDecimal.CheckedChanged += rdbDecimal_CheckedChanged;
            // 
            // txtSegundoOperador
            // 
            resources.ApplyResources(txtSegundoOperador, "txtSegundoOperador");
            txtSegundoOperador.Name = "txtSegundoOperador";
            txtSegundoOperador.TextChanged += txtSegundoOperador_TextChanged;
            // 
            // txtPrimerOperador
            // 
            resources.ApplyResources(txtPrimerOperador, "txtPrimerOperador");
            txtPrimerOperador.Name = "txtPrimerOperador";
            txtPrimerOperador.TextChanged += txtPrimerOperador_TextChanged;
            // 
            // FrmCalculadora
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtPrimerOperador);
            Controls.Add(txtSegundoOperador);
            Controls.Add(grpSistema);
            Controls.Add(lblSegundoOperador);
            Controls.Add(lblOperacion);
            Controls.Add(lblPrimerOperador);
            Controls.Add(label1);
            Controls.Add(cmbOperacion);
            Controls.Add(btnCerrar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnOperar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCalculadora";
            FormClosing += FrmCalculadora_FormClosing;
            Load += FrmCalculadora_Load;
            grpSistema.ResumeLayout(false);
            grpSistema.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOperar;
        private Button btnLimpiar;
        private Button btnCerrar;
        private ComboBox cmbOperacion;
        private Label label1;
        private Label lblPrimerOperador;
        private Label lblOperacion;
        private Label lblSegundoOperador;
        private GroupBox grpSistema;
        private RadioButton rdbBinario;
        private RadioButton rdbDecimal;
        private TextBox txtSegundoOperador;
        private TextBox txtPrimerOperador;
    }
}