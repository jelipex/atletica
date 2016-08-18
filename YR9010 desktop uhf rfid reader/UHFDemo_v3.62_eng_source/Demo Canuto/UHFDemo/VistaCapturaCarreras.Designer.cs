namespace UHFDemo
{
    partial class VistaCapturaCarreras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescripcionCarrera = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAgregarCompetidor = new System.Windows.Forms.Button();
            this.btnAsignarChip = new System.Windows.Forms.Button();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.cmbCiudadCarrera = new System.Windows.Forms.ComboBox();
            this.cmbEstadoCarrera = new System.Windows.Forms.ComboBox();
            this.cmbPaisCarrera = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpFechaCarrera = new System.Windows.Forms.DateTimePicker();
            this.txtIdCarrera = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCategoriaCarrera = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TabCategorias = new System.Windows.Forms.TabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelarCarrera = new System.Windows.Forms.Button();
            this.btnGuardarCerrarCarrera = new System.Windows.Forms.Button();
            this.btnGuardarCarrera = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.txtDescripcionCarrera);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnAgregarCompetidor);
            this.panel1.Controls.Add(this.btnAsignarChip);
            this.panel1.Controls.Add(this.btnAgregarCategoria);
            this.panel1.Controls.Add(this.cmbCiudadCarrera);
            this.panel1.Controls.Add(this.cmbEstadoCarrera);
            this.panel1.Controls.Add(this.cmbPaisCarrera);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dpFechaCarrera);
            this.panel1.Controls.Add(this.txtIdCarrera);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbCategoriaCarrera);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1093, 98);
            this.panel1.TabIndex = 0;
            // 
            // txtDescripcionCarrera
            // 
            this.txtDescripcionCarrera.Location = new System.Drawing.Point(235, 6);
            this.txtDescripcionCarrera.Name = "txtDescripcionCarrera";
            this.txtDescripcionCarrera.Size = new System.Drawing.Size(240, 20);
            this.txtDescripcionCarrera.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Nombre";
            // 
            // btnAgregarCompetidor
            // 
            this.btnAgregarCompetidor.Location = new System.Drawing.Point(322, 69);
            this.btnAgregarCompetidor.Name = "btnAgregarCompetidor";
            this.btnAgregarCompetidor.Size = new System.Drawing.Size(112, 23);
            this.btnAgregarCompetidor.TabIndex = 14;
            this.btnAgregarCompetidor.Text = "Agregar Competidor";
            this.btnAgregarCompetidor.UseVisualStyleBackColor = true;
            this.btnAgregarCompetidor.Click += new System.EventHandler(this.btnAgregarCompetidor_Click);
            // 
            // btnAsignarChip
            // 
            this.btnAsignarChip.Location = new System.Drawing.Point(440, 69);
            this.btnAsignarChip.Name = "btnAsignarChip";
            this.btnAsignarChip.Size = new System.Drawing.Size(75, 23);
            this.btnAsignarChip.TabIndex = 13;
            this.btnAsignarChip.Text = "Asignar Chip";
            this.btnAsignarChip.UseVisualStyleBackColor = true;
            this.btnAsignarChip.Click += new System.EventHandler(this.btnAsignarChip_Click);
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Location = new System.Drawing.Point(207, 69);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(109, 23);
            this.btnAgregarCategoria.TabIndex = 12;
            this.btnAgregarCategoria.Text = "Agregar Categoria";
            this.btnAgregarCategoria.UseVisualStyleBackColor = true;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // cmbCiudadCarrera
            // 
            this.cmbCiudadCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudadCarrera.FormattingEnabled = true;
            this.cmbCiudadCarrera.Location = new System.Drawing.Point(544, 36);
            this.cmbCiudadCarrera.Name = "cmbCiudadCarrera";
            this.cmbCiudadCarrera.Size = new System.Drawing.Size(180, 21);
            this.cmbCiudadCarrera.TabIndex = 11;
            // 
            // cmbEstadoCarrera
            // 
            this.cmbEstadoCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoCarrera.FormattingEnabled = true;
            this.cmbEstadoCarrera.Location = new System.Drawing.Point(310, 35);
            this.cmbEstadoCarrera.Name = "cmbEstadoCarrera";
            this.cmbEstadoCarrera.Size = new System.Drawing.Size(165, 21);
            this.cmbEstadoCarrera.TabIndex = 10;
            // 
            // cmbPaisCarrera
            // 
            this.cmbPaisCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaisCarrera.FormattingEnabled = true;
            this.cmbPaisCarrera.Location = new System.Drawing.Point(80, 36);
            this.cmbPaisCarrera.Name = "cmbPaisCarrera";
            this.cmbPaisCarrera.Size = new System.Drawing.Size(168, 21);
            this.cmbPaisCarrera.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(498, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ciudad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Pais";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha";
            // 
            // dpFechaCarrera
            // 
            this.dpFechaCarrera.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaCarrera.Location = new System.Drawing.Point(541, 6);
            this.dpFechaCarrera.Name = "dpFechaCarrera";
            this.dpFechaCarrera.Size = new System.Drawing.Size(85, 20);
            this.dpFechaCarrera.TabIndex = 4;
            // 
            // txtIdCarrera
            // 
            this.txtIdCarrera.Enabled = false;
            this.txtIdCarrera.Location = new System.Drawing.Point(80, 6);
            this.txtIdCarrera.Name = "txtIdCarrera";
            this.txtIdCarrera.Size = new System.Drawing.Size(71, 20);
            this.txtIdCarrera.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Categoria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clave";
            // 
            // cmbCategoriaCarrera
            // 
            this.cmbCategoriaCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaCarrera.FormattingEnabled = true;
            this.cmbCategoriaCarrera.Location = new System.Drawing.Point(80, 69);
            this.cmbCategoriaCarrera.Name = "cmbCategoriaCarrera";
            this.cmbCategoriaCarrera.Size = new System.Drawing.Size(121, 21);
            this.cmbCategoriaCarrera.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.TabCategorias);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1093, 362);
            this.panel3.TabIndex = 1;
            // 
            // TabCategorias
            // 
            this.TabCategorias.AccessibleName = "TabCategorias";
            this.TabCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabCategorias.Location = new System.Drawing.Point(0, 0);
            this.TabCategorias.Name = "TabCategorias";
            this.TabCategorias.SelectedIndex = 0;
            this.TabCategorias.Size = new System.Drawing.Size(1093, 362);
            this.TabCategorias.TabIndex = 0;
            this.TabCategorias.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TabCategorias_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.btnCancelarCarrera);
            this.panel2.Controls.Add(this.btnGuardarCerrarCarrera);
            this.panel2.Controls.Add(this.btnGuardarCarrera);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 460);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1093, 36);
            this.panel2.TabIndex = 2;
            // 
            // btnCancelarCarrera
            // 
            this.btnCancelarCarrera.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarCarrera.Location = new System.Drawing.Point(1008, 7);
            this.btnCancelarCarrera.Name = "btnCancelarCarrera";
            this.btnCancelarCarrera.Size = new System.Drawing.Size(75, 22);
            this.btnCancelarCarrera.TabIndex = 2;
            this.btnCancelarCarrera.Text = "Cancelar";
            this.btnCancelarCarrera.UseVisualStyleBackColor = true;
            this.btnCancelarCarrera.Click += new System.EventHandler(this.btnCancelarCarrera_Click_1);
            // 
            // btnGuardarCerrarCarrera
            // 
            this.btnGuardarCerrarCarrera.Location = new System.Drawing.Point(881, 6);
            this.btnGuardarCerrarCarrera.Name = "btnGuardarCerrarCarrera";
            this.btnGuardarCerrarCarrera.Size = new System.Drawing.Size(120, 23);
            this.btnGuardarCerrarCarrera.TabIndex = 1;
            this.btnGuardarCerrarCarrera.Text = "Guardar y Cerrar";
            this.btnGuardarCerrarCarrera.UseVisualStyleBackColor = true;
            this.btnGuardarCerrarCarrera.Click += new System.EventHandler(this.btnGuardarCerrarCarrera_Click);
            // 
            // btnGuardarCarrera
            // 
            this.btnGuardarCarrera.Location = new System.Drawing.Point(796, 6);
            this.btnGuardarCarrera.Name = "btnGuardarCarrera";
            this.btnGuardarCarrera.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarCarrera.TabIndex = 0;
            this.btnGuardarCarrera.Text = "Guardar";
            this.btnGuardarCarrera.UseVisualStyleBackColor = true;
            this.btnGuardarCarrera.Click += new System.EventHandler(this.btnGuardarCarrera_Click);
            // 
            // VistaCapturaCarreras
            // 
            this.AcceptButton = this.btnGuardarCarrera;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelarCarrera;
            this.ClientSize = new System.Drawing.Size(1093, 496);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "VistaCapturaCarreras";
            this.Text = "Carreras";
            this.Load += new System.EventHandler(this.VistaCapturaCarreras_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbCategoriaCarrera;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbCiudadCarrera;
        private System.Windows.Forms.ComboBox cmbEstadoCarrera;
        private System.Windows.Forms.ComboBox cmbPaisCarrera;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpFechaCarrera;
        private System.Windows.Forms.TextBox txtIdCarrera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.TabControl TabCategorias;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelarCarrera;
        private System.Windows.Forms.Button btnGuardarCerrarCarrera;
        private System.Windows.Forms.Button btnGuardarCarrera;
        private System.Windows.Forms.Button btnAsignarChip;
        private System.Windows.Forms.Button btnAgregarCompetidor;
        private System.Windows.Forms.TextBox txtDescripcionCarrera;
        private System.Windows.Forms.Label label7;
    }
}