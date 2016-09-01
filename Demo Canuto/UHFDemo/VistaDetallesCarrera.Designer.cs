namespace UHFDemo
{
    partial class VistaDetallesCarrera
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnBuscarCarrera = new System.Windows.Forms.Button();
            this.cmbRamas = new System.Windows.Forms.ComboBox();
            this.cmbCategorias = new System.Windows.Forms.ComboBox();
            this.cmbDistancias = new System.Windows.Forms.ComboBox();
            this.cmbCarreras = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridDetallesCarrera = new System.Windows.Forms.DataGridView();
            this.chkGanadores = new System.Windows.Forms.CheckBox();
            this.txtNumeroGanadores = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Lugar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetallesCarrera)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNumeroGanadores);
            this.panel1.Controls.Add(this.chkGanadores);
            this.panel1.Controls.Add(this.btnExportar);
            this.panel1.Controls.Add(this.btnBuscarCarrera);
            this.panel1.Controls.Add(this.cmbRamas);
            this.panel1.Controls.Add(this.cmbCategorias);
            this.panel1.Controls.Add(this.cmbDistancias);
            this.panel1.Controls.Add(this.cmbCarreras);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 68);
            this.panel1.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(371, 37);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 9;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnBuscarCarrera
            // 
            this.btnBuscarCarrera.Location = new System.Drawing.Point(290, 37);
            this.btnBuscarCarrera.Name = "btnBuscarCarrera";
            this.btnBuscarCarrera.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarCarrera.TabIndex = 8;
            this.btnBuscarCarrera.Text = "Buscar";
            this.btnBuscarCarrera.UseVisualStyleBackColor = true;
            this.btnBuscarCarrera.Click += new System.EventHandler(this.btnBuscarCarrera_Click);
            // 
            // cmbRamas
            // 
            this.cmbRamas.FormattingEnabled = true;
            this.cmbRamas.Items.AddRange(new object[] {
            "Todas",
            "Varonil",
            "Femenil"});
            this.cmbRamas.Location = new System.Drawing.Point(642, 9);
            this.cmbRamas.Name = "cmbRamas";
            this.cmbRamas.Size = new System.Drawing.Size(121, 21);
            this.cmbRamas.TabIndex = 7;
            // 
            // cmbCategorias
            // 
            this.cmbCategorias.FormattingEnabled = true;
            this.cmbCategorias.Location = new System.Drawing.Point(448, 9);
            this.cmbCategorias.Name = "cmbCategorias";
            this.cmbCategorias.Size = new System.Drawing.Size(121, 21);
            this.cmbCategorias.TabIndex = 6;
            // 
            // cmbDistancias
            // 
            this.cmbDistancias.FormattingEnabled = true;
            this.cmbDistancias.Location = new System.Drawing.Point(253, 9);
            this.cmbDistancias.Name = "cmbDistancias";
            this.cmbDistancias.Size = new System.Drawing.Size(121, 21);
            this.cmbDistancias.TabIndex = 5;
            // 
            // cmbCarreras
            // 
            this.cmbCarreras.FormattingEnabled = true;
            this.cmbCarreras.Location = new System.Drawing.Point(60, 9);
            this.cmbCarreras.Name = "cmbCarreras";
            this.cmbCarreras.Size = new System.Drawing.Size(121, 21);
            this.cmbCarreras.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Categoria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(588, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Distancia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carrera";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridDetallesCarrera);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 384);
            this.panel2.TabIndex = 1;
            // 
            // gridDetallesCarrera
            // 
            this.gridDetallesCarrera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetallesCarrera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lugar,
            this.Numero,
            this.Nombre,
            this.Distancia,
            this.Categoria,
            this.Rama,
            this.Tiempo,
            this.Diferencia});
            this.gridDetallesCarrera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetallesCarrera.Location = new System.Drawing.Point(0, 0);
            this.gridDetallesCarrera.Name = "gridDetallesCarrera";
            this.gridDetallesCarrera.Size = new System.Drawing.Size(933, 384);
            this.gridDetallesCarrera.TabIndex = 0;
            // 
            // chkGanadores
            // 
            this.chkGanadores.AutoSize = true;
            this.chkGanadores.Location = new System.Drawing.Point(16, 39);
            this.chkGanadores.Name = "chkGanadores";
            this.chkGanadores.Size = new System.Drawing.Size(78, 17);
            this.chkGanadores.TabIndex = 10;
            this.chkGanadores.Text = "Ganadores";
            this.chkGanadores.UseVisualStyleBackColor = true;
            // 
            // txtNumeroGanadores
            // 
            this.txtNumeroGanadores.Enabled = false;
            this.txtNumeroGanadores.Location = new System.Drawing.Point(195, 38);
            this.txtNumeroGanadores.Name = "txtNumeroGanadores";
            this.txtNumeroGanadores.Size = new System.Drawing.Size(75, 20);
            this.txtNumeroGanadores.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "N° de Ganadores";
            // 
            // Lugar
            // 
            this.Lugar.Frozen = true;
            this.Lugar.HeaderText = "Lugar";
            this.Lugar.Name = "Lugar";
            this.Lugar.ReadOnly = true;
            this.Lugar.Width = 60;
            // 
            // Numero
            // 
            this.Numero.Frozen = true;
            this.Numero.HeaderText = "N°";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 60;
            // 
            // Nombre
            // 
            this.Nombre.Frozen = true;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 220;
            // 
            // Distancia
            // 
            this.Distancia.Frozen = true;
            this.Distancia.HeaderText = "Distancia";
            this.Distancia.Name = "Distancia";
            this.Distancia.ReadOnly = true;
            this.Distancia.Width = 110;
            // 
            // Categoria
            // 
            this.Categoria.Frozen = true;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 120;
            // 
            // Rama
            // 
            this.Rama.Frozen = true;
            this.Rama.HeaderText = "Rama";
            this.Rama.Name = "Rama";
            this.Rama.ReadOnly = true;
            // 
            // Tiempo
            // 
            this.Tiempo.Frozen = true;
            this.Tiempo.HeaderText = "Tiempo";
            this.Tiempo.Name = "Tiempo";
            this.Tiempo.ReadOnly = true;
            this.Tiempo.Width = 120;
            // 
            // Diferencia
            // 
            this.Diferencia.Frozen = true;
            this.Diferencia.HeaderText = "Diferencia";
            this.Diferencia.Name = "Diferencia";
            this.Diferencia.ReadOnly = true;
            // 
            // VistaDetallesCarrera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 452);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "VistaDetallesCarrera";
            this.Text = "Consulta de Carrera";
            this.Load += new System.EventHandler(this.VistaDetallesCarrera_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetallesCarrera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbRamas;
        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.ComboBox cmbDistancias;
        private System.Windows.Forms.ComboBox cmbCarreras;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBuscarCarrera;
        private System.Windows.Forms.DataGridView gridDetallesCarrera;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.CheckBox chkGanadores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumeroGanadores;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lugar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diferencia;
    }
}