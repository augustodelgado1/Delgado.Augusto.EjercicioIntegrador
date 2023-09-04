namespace prubaFrm
{
    partial class Form1
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
            txtPrimerOperador = new TextBox();
            txtSegundoOperador = new TextBox();
            grpSistema = new GroupBox();
            rdbBinario = new RadioButton();
            rdbDecimal = new RadioButton();
            lblSegundoOperador = new Label();
            lblOperacion = new Label();
            lblPrimerOperador = new Label();
            label1 = new Label();
            cmbOperacion = new ComboBox();
            btnCerrar = new Button();
            btnLimpiar = new Button();
            btnOperar = new Button();
            grpSistema.SuspendLayout();
            SuspendLayout();
            // 
            // txtPrimerOperador
            // 
            txtPrimerOperador.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPrimerOperador.Location = new Point(20, 258);
            txtPrimerOperador.Name = "txtPrimerOperador";
            txtPrimerOperador.Size = new Size(179, 23);
            txtPrimerOperador.TabIndex = 21;
            // 
            // txtSegundoOperador
            // 
            txtSegundoOperador.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSegundoOperador.Location = new Point(614, 258);
            txtSegundoOperador.Name = "txtSegundoOperador";
            txtSegundoOperador.Size = new Size(197, 23);
            txtSegundoOperador.TabIndex = 20;
            // 
            // grpSistema
            // 
            grpSistema.Controls.Add(rdbBinario);
            grpSistema.Controls.Add(rdbDecimal);
            grpSistema.Location = new Point(20, 96);
            grpSistema.Name = "grpSistema";
            grpSistema.Size = new Size(255, 95);
            grpSistema.TabIndex = 19;
            grpSistema.TabStop = false;
            grpSistema.Text = "Representar Resultado en";
            // 
            // rdbBinario
            // 
            rdbBinario.AutoSize = true;
            rdbBinario.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdbBinario.ImeMode = ImeMode.NoControl;
            rdbBinario.Location = new Point(154, 39);
            rdbBinario.Name = "rdbBinario";
            rdbBinario.Size = new Size(76, 22);
            rdbBinario.TabIndex = 1;
            rdbBinario.TabStop = true;
            rdbBinario.Text = "Binario";
            rdbBinario.UseVisualStyleBackColor = true;
            // 
            // rdbDecimal
            // 
            rdbDecimal.AutoSize = true;
            rdbDecimal.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdbDecimal.ImeMode = ImeMode.NoControl;
            rdbDecimal.Location = new Point(9, 39);
            rdbDecimal.Name = "rdbDecimal";
            rdbDecimal.Size = new Size(84, 22);
            rdbDecimal.TabIndex = 0;
            rdbDecimal.TabStop = true;
            rdbDecimal.Text = "Decimal";
            rdbDecimal.UseVisualStyleBackColor = true;
            // 
            // lblSegundoOperador
            // 
            lblSegundoOperador.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblSegundoOperador.AutoSize = true;
            lblSegundoOperador.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblSegundoOperador.ImeMode = ImeMode.NoControl;
            lblSegundoOperador.Location = new Point(624, 214);
            lblSegundoOperador.Name = "lblSegundoOperador";
            lblSegundoOperador.Size = new Size(173, 25);
            lblSegundoOperador.TabIndex = 18;
            lblSegundoOperador.Text = "Segundo Operador";
            // 
            // lblOperacion
            // 
            lblOperacion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblOperacion.AutoSize = true;
            lblOperacion.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblOperacion.ImeMode = ImeMode.NoControl;
            lblOperacion.Location = new Point(380, 214);
            lblOperacion.Name = "lblOperacion";
            lblOperacion.Size = new Size(100, 25);
            lblOperacion.TabIndex = 17;
            lblOperacion.Text = "Operacion";
            // 
            // lblPrimerOperador
            // 
            lblPrimerOperador.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPrimerOperador.AutoSize = true;
            lblPrimerOperador.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrimerOperador.ImeMode = ImeMode.NoControl;
            lblPrimerOperador.Location = new Point(24, 214);
            lblPrimerOperador.Name = "lblPrimerOperador";
            lblPrimerOperador.Size = new Size(154, 25);
            lblPrimerOperador.TabIndex = 16;
            lblPrimerOperador.Text = "Primer Operador";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(369, 9);
            label1.Name = "label1";
            label1.Size = new Size(134, 37);
            label1.TabIndex = 15;
            label1.Text = "Resultado";
            // 
            // cmbOperacion
            // 
            cmbOperacion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbOperacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOperacion.FormattingEnabled = true;
            cmbOperacion.Location = new Point(337, 258);
            cmbOperacion.Name = "cmbOperacion";
            cmbOperacion.Size = new Size(184, 23);
            cmbOperacion.TabIndex = 14;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCerrar.ImeMode = ImeMode.NoControl;
            btnCerrar.Location = new Point(614, 304);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(197, 40);
            btnCerrar.TabIndex = 13;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLimpiar.ImeMode = ImeMode.NoControl;
            btnLimpiar.Location = new Point(337, 304);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(186, 40);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnOperar
            // 
            btnOperar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOperar.ImeMode = ImeMode.NoControl;
            btnOperar.Location = new Point(18, 304);
            btnOperar.Name = "btnOperar";
            btnOperar.Size = new Size(186, 40);
            btnOperar.TabIndex = 11;
            btnOperar.Text = "Operar";
            btnOperar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 356);
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
            Name = "Form1";
            Text = "Calculadora Delgado Augusto";
            grpSistema.ResumeLayout(false);
            grpSistema.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPrimerOperador;
        private TextBox txtSegundoOperador;
        private GroupBox grpSistema;
        private RadioButton rdbBinario;
        private RadioButton rdbDecimal;
        private Label lblSegundoOperador;
        private Label lblOperacion;
        private Label lblPrimerOperador;
        private Label label1;
        private ComboBox cmbOperacion;
        private Button btnCerrar;
        private Button btnLimpiar;
        private Button btnOperar;
    }
}