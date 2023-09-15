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
            components = new System.ComponentModel.Container();
            btnOperar = new Button();
            btnLimpiar = new Button();
            btnCerrar = new Button();
            cmbOperacion = new ComboBox();
            lblResultado = new Label();
            lblPrimerOperador = new Label();
            lblOperacion = new Label();
            lblSegundoOperador = new Label();
            grpSistema = new GroupBox();
            rdbBinario = new RadioButton();
            rdbDecimal = new RadioButton();
            txtSegundoOperador = new TextBox();
            txtPrimerOperador = new TextBox();
            unErrorProvider = new ErrorProvider(components);
            grpSistema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)unErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // btnOperar
            // 
            btnOperar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOperar.Location = new Point(12, 289);
            btnOperar.Name = "btnOperar";
            btnOperar.Size = new Size(184, 40);
            btnOperar.TabIndex = 3;
            btnOperar.Text = "Operar";
            btnOperar.UseVisualStyleBackColor = true;
            btnOperar.Click += btnOperar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLimpiar.Location = new Point(317, 289);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(179, 40);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCerrar.Location = new Point(617, 289);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(179, 40);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // cmbOperacion
            // 
            cmbOperacion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbOperacion.BackColor = SystemColors.Menu;
            cmbOperacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOperacion.FlatStyle = FlatStyle.System;
            cmbOperacion.FormattingEnabled = true;
            cmbOperacion.Location = new Point(317, 243);
            cmbOperacion.Name = "cmbOperacion";
            cmbOperacion.Size = new Size(179, 23);
            cmbOperacion.TabIndex = 1;
            cmbOperacion.SelectedIndexChanged += cmbOperacion_SelectedIndexChanged;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblResultado.Location = new Point(12, 20);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(145, 37);
            lblResultado.TabIndex = 4;
            lblResultado.Text = "Resultado:";
            // 
            // lblPrimerOperador
            // 
            lblPrimerOperador.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPrimerOperador.AutoSize = true;
            lblPrimerOperador.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrimerOperador.Location = new Point(12, 204);
            lblPrimerOperador.Name = "lblPrimerOperador";
            lblPrimerOperador.Size = new Size(163, 25);
            lblPrimerOperador.TabIndex = 5;
            lblPrimerOperador.Text = "Primer Operador";
            // 
            // lblOperacion
            // 
            lblOperacion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblOperacion.AutoSize = true;
            lblOperacion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblOperacion.Location = new Point(353, 204);
            lblOperacion.Name = "lblOperacion";
            lblOperacion.Size = new Size(104, 25);
            lblOperacion.TabIndex = 6;
            lblOperacion.Text = "Operacion";
            // 
            // lblSegundoOperador
            // 
            lblSegundoOperador.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblSegundoOperador.AutoSize = true;
            lblSegundoOperador.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSegundoOperador.Location = new Point(612, 204);
            lblSegundoOperador.Name = "lblSegundoOperador";
            lblSegundoOperador.Size = new Size(184, 25);
            lblSegundoOperador.TabIndex = 7;
            lblSegundoOperador.Text = "Segundo Operador";
            // 
            // grpSistema
            // 
            grpSistema.Controls.Add(rdbBinario);
            grpSistema.Controls.Add(rdbDecimal);
            grpSistema.Location = new Point(283, 80);
            grpSistema.Name = "grpSistema";
            grpSistema.Size = new Size(251, 78);
            grpSistema.TabIndex = 8;
            grpSistema.TabStop = false;
            grpSistema.Text = "Representar Resultado en";
            // 
            // rdbBinario
            // 
            rdbBinario.AutoSize = true;
            rdbBinario.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdbBinario.Location = new Point(150, 32);
            rdbBinario.Name = "rdbBinario";
            rdbBinario.RightToLeft = RightToLeft.No;
            rdbBinario.Size = new Size(76, 22);
            rdbBinario.TabIndex = 6;
            rdbBinario.TabStop = true;
            rdbBinario.Text = "Binario";
            rdbBinario.UseVisualStyleBackColor = true;
            rdbBinario.CheckedChanged += rdbBinario_CheckedChanged;
            // 
            // rdbDecimal
            // 
            rdbDecimal.AutoSize = true;
            rdbDecimal.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdbDecimal.Location = new Point(24, 32);
            rdbDecimal.Name = "rdbDecimal";
            rdbDecimal.Size = new Size(84, 22);
            rdbDecimal.TabIndex = 7;
            rdbDecimal.TabStop = true;
            rdbDecimal.Text = "Decimal";
            rdbDecimal.UseVisualStyleBackColor = true;
            rdbDecimal.CheckedChanged += rdbDecimal_CheckedChanged;
            // 
            // txtSegundoOperador
            // 
            txtSegundoOperador.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSegundoOperador.Location = new Point(617, 243);
            txtSegundoOperador.Name = "txtSegundoOperador";
            txtSegundoOperador.Size = new Size(179, 23);
            txtSegundoOperador.TabIndex = 2;
            txtSegundoOperador.TextChanged += txtSegundoOperador_TextChanged;
            // 
            // txtPrimerOperador
            // 
            txtPrimerOperador.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPrimerOperador.Location = new Point(12, 244);
            txtPrimerOperador.Name = "txtPrimerOperador";
            txtPrimerOperador.Size = new Size(179, 23);
            txtPrimerOperador.TabIndex = 0;
            txtPrimerOperador.TextChanged += txtPrimerOperador_TextChanged;
            // 
            // unErrorProvider
            // 
            unErrorProvider.ContainerControl = this;
            // 
            // FrmCalculadora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(818, 341);
            Controls.Add(txtPrimerOperador);
            Controls.Add(txtSegundoOperador);
            Controls.Add(grpSistema);
            Controls.Add(lblSegundoOperador);
            Controls.Add(lblOperacion);
            Controls.Add(lblPrimerOperador);
            Controls.Add(lblResultado);
            Controls.Add(cmbOperacion);
            Controls.Add(btnCerrar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnOperar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCalculadora";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculadora de Augusto Delgado";
            FormClosing += FrmCalculadora_FormClosing;
            Load += FrmCalculadora_Load;
            grpSistema.ResumeLayout(false);
            grpSistema.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)unErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOperar;
        private Button btnLimpiar;
        private Button btnCerrar;
        private ComboBox cmbOperacion;
        private Label lblResultado;
        private Label lblPrimerOperador;
        private Label lblOperacion;
        private Label lblSegundoOperador;
        private GroupBox grpSistema;
        private RadioButton rdbBinario;
        private RadioButton rdbDecimal;
        private TextBox txtSegundoOperador;
        private TextBox txtPrimerOperador;
        private ErrorProvider unErrorProvider;
    }
}