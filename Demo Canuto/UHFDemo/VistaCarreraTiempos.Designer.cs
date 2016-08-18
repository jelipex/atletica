namespace UHFDemo
{
    partial class VistaCarreraTiempos
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
            this.txtFechaCarrera = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCategoriaDescripción = new System.Windows.Forms.TextBox();
            this.txtCarreraDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tablaTiemposCorredores = new System.Windows.Forms.DataGridView();
            this.IdCompetidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Competidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTiemposCorredores)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFechaCarrera);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCategoriaDescripción);
            this.panel1.Controls.Add(this.txtCarreraDescripcion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 49);
            this.panel1.TabIndex = 0;
            // 
            // txtFechaCarrera
            // 
            this.txtFechaCarrera.Location = new System.Drawing.Point(599, 16);
            this.txtFechaCarrera.Name = "txtFechaCarrera";
            this.txtFechaCarrera.ReadOnly = true;
            this.txtFechaCarrera.Size = new System.Drawing.Size(102, 20);
            this.txtFechaCarrera.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(551, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha";
            // 
            // txtCategoriaDescripción
            // 
            this.txtCategoriaDescripción.Location = new System.Drawing.Point(326, 16);
            this.txtCategoriaDescripción.Name = "txtCategoriaDescripción";
            this.txtCategoriaDescripción.ReadOnly = true;
            this.txtCategoriaDescripción.Size = new System.Drawing.Size(203, 20);
            this.txtCategoriaDescripción.TabIndex = 3;
            // 
            // txtCarreraDescripcion
            // 
            this.txtCarreraDescripcion.Location = new System.Drawing.Point(79, 16);
            this.txtCarreraDescripcion.Name = "txtCarreraDescripcion";
            this.txtCarreraDescripcion.ReadOnly = true;
            this.txtCarreraDescripcion.Size = new System.Drawing.Size(169, 20);
            this.txtCarreraDescripcion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(257, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Categoría";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carrera";
            // 
            // tablaTiemposCorredores
            // 
            this.tablaTiemposCorredores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaTiemposCorredores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCompetidor,
            this.Competidor,
            this.Chip,
            this.Tiempo});
            this.tablaTiemposCorredores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaTiemposCorredores.Location = new System.Drawing.Point(0, 49);
            this.tablaTiemposCorredores.Name = "tablaTiemposCorredores";
            this.tablaTiemposCorredores.Size = new System.Drawing.Size(900, 359);
            this.tablaTiemposCorredores.TabIndex = 1;
            // 
            // IdCompetidor
            // 
            this.IdCompetidor.HeaderText = "Clave";
            this.IdCompetidor.Name = "IdCompetidor";
            this.IdCompetidor.ReadOnly = true;
            this.IdCompetidor.Width = 80;
            // 
            // Competidor
            // 
            this.Competidor.HeaderText = "Competidor";
            this.Competidor.Name = "Competidor";
            this.Competidor.ReadOnly = true;
            this.Competidor.Width = 300;
            // 
            // Chip
            // 
            this.Chip.HeaderText = "Chip";
            this.Chip.Name = "Chip";
            this.Chip.ReadOnly = true;
            this.Chip.Width = 250;
            // 
            // Tiempo
            // 
            this.Tiempo.HeaderText = "Tiempo";
            this.Tiempo.Name = "Tiempo";
            this.Tiempo.ReadOnly = true;
            this.Tiempo.Width = 150;
            // 
            // VistaCarreraTiempos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 408);
            this.Controls.Add(this.tablaTiemposCorredores);
            this.Controls.Add(this.panel1);
            this.Name = "VistaCarreraTiempos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiempos de Carrera";
            this.Load += new System.EventHandler(this.VistaCarreraTiempos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTiemposCorredores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtCategoriaDescripción;
        public System.Windows.Forms.TextBox txtCarreraDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtFechaCarrera;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView tablaTiemposCorredores;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCompetidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Competidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;

    }
}