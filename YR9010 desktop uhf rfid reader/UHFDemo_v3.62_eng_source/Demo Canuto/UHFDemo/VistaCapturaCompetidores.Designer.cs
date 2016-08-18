namespace UHFDemo
{
    partial class VistaCapturaCompetidores
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdCompetidor = new System.Windows.Forms.TextBox();
            this.txtAPaternoCompetidor = new System.Windows.Forms.TextBox();
            this.txtAMaternoCompetidor = new System.Windows.Forms.TextBox();
            this.txtNombreCompetidor = new System.Windows.Forms.TextBox();
            this.txtDireccionCompetidor = new System.Windows.Forms.TextBox();
            this.txtTelefonoCompetidor = new System.Windows.Forms.TextBox();
            this.cmbPaisCompetidor = new System.Windows.Forms.ComboBox();
            this.cmbEstadoCompetidor = new System.Windows.Forms.ComboBox();
            this.cmbCiudadCompetidor = new System.Windows.Forms.ComboBox();
            this.inventariofacturacionDataSet = new UHFDemo.inventariofacturacionDataSet();
            this.paisesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paisesTableAdapter = new UHFDemo.inventariofacturacionDataSetTableAdapters.paisesTableAdapter();
            this.btnGuardarCompetidor = new System.Windows.Forms.Button();
            this.btnGuardarCerrarCompetidor = new System.Windows.Forms.Button();
            this.btnCancelarCompetidor = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEdadCompetidor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.inventariofacturacionDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paisesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Appellido Paterno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido Materno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dirección";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pais";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Estado";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ciudad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Teléfono";
            // 
            // txtIdCompetidor
            // 
            this.txtIdCompetidor.Enabled = false;
            this.txtIdCompetidor.Location = new System.Drawing.Point(139, 15);
            this.txtIdCompetidor.Name = "txtIdCompetidor";
            this.txtIdCompetidor.Size = new System.Drawing.Size(100, 20);
            this.txtIdCompetidor.TabIndex = 1;
            // 
            // txtAPaternoCompetidor
            // 
            this.txtAPaternoCompetidor.Location = new System.Drawing.Point(139, 45);
            this.txtAPaternoCompetidor.Name = "txtAPaternoCompetidor";
            this.txtAPaternoCompetidor.Size = new System.Drawing.Size(244, 20);
            this.txtAPaternoCompetidor.TabIndex = 2;
            // 
            // txtAMaternoCompetidor
            // 
            this.txtAMaternoCompetidor.Location = new System.Drawing.Point(139, 73);
            this.txtAMaternoCompetidor.Name = "txtAMaternoCompetidor";
            this.txtAMaternoCompetidor.Size = new System.Drawing.Size(244, 20);
            this.txtAMaternoCompetidor.TabIndex = 3;
            // 
            // txtNombreCompetidor
            // 
            this.txtNombreCompetidor.Location = new System.Drawing.Point(139, 104);
            this.txtNombreCompetidor.Name = "txtNombreCompetidor";
            this.txtNombreCompetidor.Size = new System.Drawing.Size(244, 20);
            this.txtNombreCompetidor.TabIndex = 4;
            // 
            // txtDireccionCompetidor
            // 
            this.txtDireccionCompetidor.Location = new System.Drawing.Point(139, 134);
            this.txtDireccionCompetidor.Name = "txtDireccionCompetidor";
            this.txtDireccionCompetidor.Size = new System.Drawing.Size(244, 20);
            this.txtDireccionCompetidor.TabIndex = 5;
            // 
            // txtTelefonoCompetidor
            // 
            this.txtTelefonoCompetidor.Location = new System.Drawing.Point(139, 256);
            this.txtTelefonoCompetidor.Name = "txtTelefonoCompetidor";
            this.txtTelefonoCompetidor.Size = new System.Drawing.Size(141, 20);
            this.txtTelefonoCompetidor.TabIndex = 9;
            // 
            // cmbPaisCompetidor
            // 
            this.cmbPaisCompetidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaisCompetidor.FormattingEnabled = true;
            this.cmbPaisCompetidor.Location = new System.Drawing.Point(139, 163);
            this.cmbPaisCompetidor.Name = "cmbPaisCompetidor";
            this.cmbPaisCompetidor.Size = new System.Drawing.Size(178, 21);
            this.cmbPaisCompetidor.TabIndex = 6;
            // 
            // cmbEstadoCompetidor
            // 
            this.cmbEstadoCompetidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoCompetidor.FormattingEnabled = true;
            this.cmbEstadoCompetidor.Location = new System.Drawing.Point(139, 195);
            this.cmbEstadoCompetidor.Name = "cmbEstadoCompetidor";
            this.cmbEstadoCompetidor.Size = new System.Drawing.Size(178, 21);
            this.cmbEstadoCompetidor.TabIndex = 7;
            // 
            // cmbCiudadCompetidor
            // 
            this.cmbCiudadCompetidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudadCompetidor.FormattingEnabled = true;
            this.cmbCiudadCompetidor.Location = new System.Drawing.Point(139, 225);
            this.cmbCiudadCompetidor.Name = "cmbCiudadCompetidor";
            this.cmbCiudadCompetidor.Size = new System.Drawing.Size(178, 21);
            this.cmbCiudadCompetidor.TabIndex = 8;
            // 
            // inventariofacturacionDataSet
            // 
            this.inventariofacturacionDataSet.DataSetName = "inventariofacturacionDataSet";
            this.inventariofacturacionDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // paisesBindingSource
            // 
            this.paisesBindingSource.DataMember = "paises";
            this.paisesBindingSource.DataSource = this.inventariofacturacionDataSet;
            // 
            // paisesTableAdapter
            // 
            this.paisesTableAdapter.ClearBeforeFill = true;
            // 
            // btnGuardarCompetidor
            // 
            this.btnGuardarCompetidor.Location = new System.Drawing.Point(139, 345);
            this.btnGuardarCompetidor.Name = "btnGuardarCompetidor";
            this.btnGuardarCompetidor.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarCompetidor.TabIndex = 11;
            this.btnGuardarCompetidor.Text = "Guardar";
            this.btnGuardarCompetidor.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCerrarCompetidor
            // 
            this.btnGuardarCerrarCompetidor.Location = new System.Drawing.Point(222, 345);
            this.btnGuardarCerrarCompetidor.Name = "btnGuardarCerrarCompetidor";
            this.btnGuardarCerrarCompetidor.Size = new System.Drawing.Size(112, 23);
            this.btnGuardarCerrarCompetidor.TabIndex = 12;
            this.btnGuardarCerrarCompetidor.Text = "Guardar y Cerrar";
            this.btnGuardarCerrarCompetidor.UseVisualStyleBackColor = true;
            // 
            // btnCancelarCompetidor
            // 
            this.btnCancelarCompetidor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarCompetidor.Location = new System.Drawing.Point(343, 345);
            this.btnCancelarCompetidor.Name = "btnCancelarCompetidor";
            this.btnCancelarCompetidor.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarCompetidor.TabIndex = 13;
            this.btnCancelarCompetidor.Text = "Cancelar";
            this.btnCancelarCompetidor.UseVisualStyleBackColor = true;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(432, 380);
            this.shapeContainer1.TabIndex = 24;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = -4;
            this.lineShape1.X2 = 432;
            this.lineShape1.Y1 = 331;
            this.lineShape1.Y2 = 331;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 290);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Edad";
            // 
            // txtEdadCompetidor
            // 
            this.txtEdadCompetidor.Location = new System.Drawing.Point(139, 287);
            this.txtEdadCompetidor.Name = "txtEdadCompetidor";
            this.txtEdadCompetidor.Size = new System.Drawing.Size(82, 20);
            this.txtEdadCompetidor.TabIndex = 10;
            // 
            // VistaCapturaCompetidores
            // 
            this.AcceptButton = this.btnGuardarCompetidor;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelarCompetidor;
            this.ClientSize = new System.Drawing.Size(432, 380);
            this.Controls.Add(this.txtEdadCompetidor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCancelarCompetidor);
            this.Controls.Add(this.btnGuardarCerrarCompetidor);
            this.Controls.Add(this.btnGuardarCompetidor);
            this.Controls.Add(this.cmbCiudadCompetidor);
            this.Controls.Add(this.cmbEstadoCompetidor);
            this.Controls.Add(this.cmbPaisCompetidor);
            this.Controls.Add(this.txtTelefonoCompetidor);
            this.Controls.Add(this.txtDireccionCompetidor);
            this.Controls.Add(this.txtNombreCompetidor);
            this.Controls.Add(this.txtAMaternoCompetidor);
            this.Controls.Add(this.txtAPaternoCompetidor);
            this.Controls.Add(this.txtIdCompetidor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "VistaCapturaCompetidores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Competidores";
            this.Load += new System.EventHandler(this.VistaCapturaCompetidores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inventariofacturacionDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paisesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdCompetidor;
        private System.Windows.Forms.TextBox txtAPaternoCompetidor;
        private System.Windows.Forms.TextBox txtAMaternoCompetidor;
        private System.Windows.Forms.TextBox txtNombreCompetidor;
        private System.Windows.Forms.TextBox txtDireccionCompetidor;
        private System.Windows.Forms.TextBox txtTelefonoCompetidor;
        private System.Windows.Forms.ComboBox cmbPaisCompetidor;
        private System.Windows.Forms.ComboBox cmbEstadoCompetidor;
        private System.Windows.Forms.ComboBox cmbCiudadCompetidor;
        private inventariofacturacionDataSet inventariofacturacionDataSet;
        private System.Windows.Forms.BindingSource paisesBindingSource;
        private inventariofacturacionDataSetTableAdapters.paisesTableAdapter paisesTableAdapter;
        private System.Windows.Forms.Button btnGuardarCompetidor;
        private System.Windows.Forms.Button btnGuardarCerrarCompetidor;
        private System.Windows.Forms.Button btnCancelarCompetidor;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEdadCompetidor;
    }
}