using UHFDemo.Entidades;
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbPaisCarrera = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkListCategorias = new System.Windows.Forms.CheckedListBox();
            this.txtDescripcionCarrera = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAsignarChip = new System.Windows.Forms.Button();
            this.cmbCiudadCarrera = new System.Windows.Forms.ComboBox();
            this.cmbEstadoCarrera = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpFechaCarrera = new System.Windows.Forms.DateTimePicker();
            this.txtIdCarrera = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TabCarrerasDetalle = new System.Windows.Forms.TabControl();
            this.tabCompetidores = new System.Windows.Forms.TabPage();
            this.cmbRama = new System.Windows.Forms.ComboBox();
            this.cmbCategorias = new System.Windows.Forms.ComboBox();
            this.cmbCompetidores = new System.Windows.Forms.ComboBox();
            this.gridCarrerasCompetidores = new System.Windows.Forms.DataGridView();
            this.tabPuntos = new System.Windows.Forms.TabPage();
            this.cmbPuntos = new System.Windows.Forms.ComboBox();
            this.gridCarrerasPuntos = new System.Windows.Forms.DataGridView();
            this.IdPunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Punto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intervalo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelarCarrera = new System.Windows.Forms.Button();
            this.btnGuardarCerrarCarrera = new System.Windows.Forms.Button();
            this.btnGuardarCarrera = new System.Windows.Forms.Button();
            this.ctxMenuCompetidor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripEliminarCompetidor = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuPunto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripEliminarPunto = new System.Windows.Forms.ToolStripMenuItem();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCompetidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Competidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.TabCarrerasDetalle.SuspendLayout();
            this.tabCompetidores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCarrerasCompetidores)).BeginInit();
            this.tabPuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCarrerasPuntos)).BeginInit();
            this.panel2.SuspendLayout();
            this.ctxMenuCompetidor.SuspendLayout();
            this.ctxMenuPunto.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.cmbPaisCarrera);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtDescripcionCarrera);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnAsignarChip);
            this.panel1.Controls.Add(this.cmbCiudadCarrera);
            this.panel1.Controls.Add(this.cmbEstadoCarrera);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dpFechaCarrera);
            this.panel1.Controls.Add(this.txtIdCarrera);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1159, 90);
            this.panel1.TabIndex = 0;
            // 
            // cmbPaisCarrera
            // 
            this.cmbPaisCarrera.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPaisCarrera.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPaisCarrera.FormattingEnabled = true;
            this.cmbPaisCarrera.Location = new System.Drawing.Point(73, 36);
            this.cmbPaisCarrera.Name = "cmbPaisCarrera";
            this.cmbPaisCarrera.Size = new System.Drawing.Size(199, 21);
            this.cmbPaisCarrera.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkListCategorias);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(747, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 90);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categorías";
            // 
            // chkListCategorias
            // 
            this.chkListCategorias.CheckOnClick = true;
            this.chkListCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListCategorias.FormattingEnabled = true;
            this.chkListCategorias.Location = new System.Drawing.Point(3, 16);
            this.chkListCategorias.MultiColumn = true;
            this.chkListCategorias.Name = "chkListCategorias";
            this.chkListCategorias.Size = new System.Drawing.Size(406, 71);
            this.chkListCategorias.TabIndex = 17;
            // 
            // txtDescripcionCarrera
            // 
            this.txtDescripcionCarrera.Location = new System.Drawing.Point(228, 6);
            this.txtDescripcionCarrera.Name = "txtDescripcionCarrera";
            this.txtDescripcionCarrera.Size = new System.Drawing.Size(277, 20);
            this.txtDescripcionCarrera.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Nombre";
            // 
            // btnAsignarChip
            // 
            this.btnAsignarChip.Location = new System.Drawing.Point(664, 7);
            this.btnAsignarChip.Name = "btnAsignarChip";
            this.btnAsignarChip.Size = new System.Drawing.Size(75, 23);
            this.btnAsignarChip.TabIndex = 8;
            this.btnAsignarChip.Text = "Asignar Chip";
            this.btnAsignarChip.UseVisualStyleBackColor = true;
            this.btnAsignarChip.Visible = false;
            this.btnAsignarChip.Click += new System.EventHandler(this.btnAsignarChip_Click);
            // 
            // cmbCiudadCarrera
            // 
            this.cmbCiudadCarrera.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCiudadCarrera.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCiudadCarrera.FormattingEnabled = true;
            this.cmbCiudadCarrera.Location = new System.Drawing.Point(559, 37);
            this.cmbCiudadCarrera.Name = "cmbCiudadCarrera";
            this.cmbCiudadCarrera.Size = new System.Drawing.Size(180, 21);
            this.cmbCiudadCarrera.TabIndex = 6;
            // 
            // cmbEstadoCarrera
            // 
            this.cmbEstadoCarrera.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEstadoCarrera.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEstadoCarrera.FormattingEnabled = true;
            this.cmbEstadoCarrera.Location = new System.Drawing.Point(342, 36);
            this.cmbEstadoCarrera.Name = "cmbEstadoCarrera";
            this.cmbEstadoCarrera.Size = new System.Drawing.Size(165, 21);
            this.cmbEstadoCarrera.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(513, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ciudad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Pais";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha";
            // 
            // dpFechaCarrera
            // 
            this.dpFechaCarrera.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaCarrera.Location = new System.Drawing.Point(556, 6);
            this.dpFechaCarrera.Name = "dpFechaCarrera";
            this.dpFechaCarrera.Size = new System.Drawing.Size(85, 20);
            this.dpFechaCarrera.TabIndex = 3;
            this.dpFechaCarrera.ValueChanged += new System.EventHandler(this.dpFechaCarrera_ValueChanged);
            // 
            // txtIdCarrera
            // 
            this.txtIdCarrera.Enabled = false;
            this.txtIdCarrera.Location = new System.Drawing.Point(73, 6);
            this.txtIdCarrera.Name = "txtIdCarrera";
            this.txtIdCarrera.Size = new System.Drawing.Size(71, 20);
            this.txtIdCarrera.TabIndex = 1;
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.TabCarrerasDetalle);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1159, 362);
            this.panel3.TabIndex = 1;
            // 
            // TabCarrerasDetalle
            // 
            this.TabCarrerasDetalle.AccessibleName = "TabCategorias";
            this.TabCarrerasDetalle.Controls.Add(this.tabCompetidores);
            this.TabCarrerasDetalle.Controls.Add(this.tabPuntos);
            this.TabCarrerasDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabCarrerasDetalle.Location = new System.Drawing.Point(0, 0);
            this.TabCarrerasDetalle.Name = "TabCarrerasDetalle";
            this.TabCarrerasDetalle.SelectedIndex = 0;
            this.TabCarrerasDetalle.Size = new System.Drawing.Size(1159, 362);
            this.TabCarrerasDetalle.TabIndex = 0;
            this.TabCarrerasDetalle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TabCategorias_MouseUp);
            // 
            // tabCompetidores
            // 
            this.tabCompetidores.Controls.Add(this.cmbRama);
            this.tabCompetidores.Controls.Add(this.cmbCategorias);
            this.tabCompetidores.Controls.Add(this.cmbCompetidores);
            this.tabCompetidores.Controls.Add(this.gridCarrerasCompetidores);
            this.tabCompetidores.Location = new System.Drawing.Point(4, 22);
            this.tabCompetidores.Name = "tabCompetidores";
            this.tabCompetidores.Size = new System.Drawing.Size(1151, 336);
            this.tabCompetidores.TabIndex = 0;
            this.tabCompetidores.Text = "Competidores";
            this.tabCompetidores.UseVisualStyleBackColor = true;
            // 
            // cmbRama
            // 
            this.cmbRama.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRama.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRama.DropDownWidth = 250;
            this.cmbRama.FormattingEnabled = true;
            this.cmbRama.Items.AddRange(new object[] {
            "Varonil",
            "Femenil"});
            this.cmbRama.Location = new System.Drawing.Point(1022, 52);
            this.cmbRama.Name = "cmbRama";
            this.cmbRama.Size = new System.Drawing.Size(121, 21);
            this.cmbRama.TabIndex = 3;
            this.cmbRama.Visible = false;
            // 
            // cmbCategorias
            // 
            this.cmbCategorias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategorias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategorias.DropDownWidth = 250;
            this.cmbCategorias.FormattingEnabled = true;
            this.cmbCategorias.Location = new System.Drawing.Point(1022, 3);
            this.cmbCategorias.Name = "cmbCategorias";
            this.cmbCategorias.Size = new System.Drawing.Size(121, 21);
            this.cmbCategorias.TabIndex = 2;
            this.cmbCategorias.Visible = false;
            // 
            // cmbCompetidores
            // 
            this.cmbCompetidores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCompetidores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompetidores.DropDownWidth = 250;
            this.cmbCompetidores.FormattingEnabled = true;
            this.cmbCompetidores.Location = new System.Drawing.Point(1022, 27);
            this.cmbCompetidores.Name = "cmbCompetidores";
            this.cmbCompetidores.Size = new System.Drawing.Size(121, 21);
            this.cmbCompetidores.TabIndex = 1;
            this.cmbCompetidores.Visible = false;
            // 
            // gridCarrerasCompetidores
            // 
            this.gridCarrerasCompetidores.AllowUserToAddRows = false;
            this.gridCarrerasCompetidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCarrerasCompetidores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdCompetidor,
            this.Competidor,
            this.IdCategoria,
            this.Categoria,
            this.Rama,
            this.Chip});
            this.gridCarrerasCompetidores.ContextMenuStrip = this.ctxMenuCompetidor;
            this.gridCarrerasCompetidores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCarrerasCompetidores.Location = new System.Drawing.Point(0, 0);
            this.gridCarrerasCompetidores.Name = "gridCarrerasCompetidores";
            this.gridCarrerasCompetidores.Size = new System.Drawing.Size(1151, 336);
            this.gridCarrerasCompetidores.TabIndex = 0;
            this.gridCarrerasCompetidores.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCarrerasCompetidores_CellEnter);
            this.gridCarrerasCompetidores.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridCarrerasCompetidores_EditingControlShowing);
            // 
            // tabPuntos
            // 
            this.tabPuntos.Controls.Add(this.cmbPuntos);
            this.tabPuntos.Controls.Add(this.gridCarrerasPuntos);
            this.tabPuntos.Location = new System.Drawing.Point(4, 22);
            this.tabPuntos.Name = "tabPuntos";
            this.tabPuntos.Size = new System.Drawing.Size(1151, 336);
            this.tabPuntos.TabIndex = 1;
            this.tabPuntos.Text = "Puntos";
            this.tabPuntos.UseVisualStyleBackColor = true;
            // 
            // cmbPuntos
            // 
            this.cmbPuntos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPuntos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPuntos.DropDownWidth = 250;
            this.cmbPuntos.FormattingEnabled = true;
            this.cmbPuntos.Location = new System.Drawing.Point(311, 3);
            this.cmbPuntos.Name = "cmbPuntos";
            this.cmbPuntos.Size = new System.Drawing.Size(121, 21);
            this.cmbPuntos.TabIndex = 3;
            this.cmbPuntos.Visible = false;
            // 
            // gridCarrerasPuntos
            // 
            this.gridCarrerasPuntos.AllowUserToAddRows = false;
            this.gridCarrerasPuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCarrerasPuntos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPunto,
            this.Punto,
            this.Intervalo});
            this.gridCarrerasPuntos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCarrerasPuntos.Location = new System.Drawing.Point(0, 0);
            this.gridCarrerasPuntos.Name = "gridCarrerasPuntos";
            this.gridCarrerasPuntos.Size = new System.Drawing.Size(1151, 336);
            this.gridCarrerasPuntos.TabIndex = 0;
            this.gridCarrerasPuntos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridCarrerasPuntos_EditingControlShowing);
            // 
            // IdPunto
            // 
            this.IdPunto.HeaderText = "IdPunto";
            this.IdPunto.Name = "IdPunto";
            this.IdPunto.Visible = false;
            // 
            // Punto
            // 
            this.Punto.HeaderText = "Punto";
            this.Punto.Name = "Punto";
            this.Punto.ReadOnly = true;
            this.Punto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Punto.Width = 150;
            // 
            // Intervalo
            // 
            this.Intervalo.HeaderText = "Intervalo(min)";
            this.Intervalo.Name = "Intervalo";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.btnCancelarCarrera);
            this.panel2.Controls.Add(this.btnGuardarCerrarCarrera);
            this.panel2.Controls.Add(this.btnGuardarCarrera);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1159, 62);
            this.panel2.TabIndex = 2;
            // 
            // btnCancelarCarrera
            // 
            this.btnCancelarCarrera.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarCarrera.Location = new System.Drawing.Point(1073, 14);
            this.btnCancelarCarrera.Name = "btnCancelarCarrera";
            this.btnCancelarCarrera.Size = new System.Drawing.Size(75, 22);
            this.btnCancelarCarrera.TabIndex = 11;
            this.btnCancelarCarrera.Text = "Cancelar";
            this.btnCancelarCarrera.UseVisualStyleBackColor = true;
            this.btnCancelarCarrera.Click += new System.EventHandler(this.btnCancelarCarrera_Click_1);
            // 
            // btnGuardarCerrarCarrera
            // 
            this.btnGuardarCerrarCarrera.Location = new System.Drawing.Point(946, 13);
            this.btnGuardarCerrarCarrera.Name = "btnGuardarCerrarCarrera";
            this.btnGuardarCerrarCarrera.Size = new System.Drawing.Size(120, 23);
            this.btnGuardarCerrarCarrera.TabIndex = 10;
            this.btnGuardarCerrarCarrera.Text = "Guardar y Cerrar";
            this.btnGuardarCerrarCarrera.UseVisualStyleBackColor = true;
            this.btnGuardarCerrarCarrera.Click += new System.EventHandler(this.btnGuardarCerrarCarrera_Click);
            // 
            // btnGuardarCarrera
            // 
            this.btnGuardarCarrera.Location = new System.Drawing.Point(861, 13);
            this.btnGuardarCarrera.Name = "btnGuardarCarrera";
            this.btnGuardarCarrera.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarCarrera.TabIndex = 9;
            this.btnGuardarCarrera.Text = "Guardar";
            this.btnGuardarCarrera.UseVisualStyleBackColor = true;
            this.btnGuardarCarrera.Click += new System.EventHandler(this.btnGuardarCarrera_Click);
            // 
            // ctxMenuCompetidor
            // 
            this.ctxMenuCompetidor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripEliminarCompetidor});
            this.ctxMenuCompetidor.Name = "ctxMenuCompetidor";
            this.ctxMenuCompetidor.Size = new System.Drawing.Size(185, 26);
            // 
            // toolStripEliminarCompetidor
            // 
            this.toolStripEliminarCompetidor.Name = "toolStripEliminarCompetidor";
            this.toolStripEliminarCompetidor.Size = new System.Drawing.Size(184, 22);
            this.toolStripEliminarCompetidor.Text = "Eliminar Competidor";
            // 
            // ctxMenuPunto
            // 
            this.ctxMenuPunto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripEliminarPunto});
            this.ctxMenuPunto.Name = "ctxMenuPunto";
            this.ctxMenuPunto.Size = new System.Drawing.Size(153, 26);
            // 
            // toolStripEliminarPunto
            // 
            this.toolStripEliminarPunto.Name = "toolStripEliminarPunto";
            this.toolStripEliminarPunto.Size = new System.Drawing.Size(152, 22);
            this.toolStripEliminarPunto.Text = "Eliminar Punto";
            this.toolStripEliminarPunto.Click += new System.EventHandler(this.toolStripEliminarPunto_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.Frozen = true;
            this.Id.HeaderText = "Clave";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 60;
            // 
            // IdCompetidor
            // 
            this.IdCompetidor.DataPropertyName = "IdCompetidor";
            this.IdCompetidor.HeaderText = "IdCompetidor";
            this.IdCompetidor.Name = "IdCompetidor";
            this.IdCompetidor.ReadOnly = true;
            this.IdCompetidor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdCompetidor.Visible = false;
            this.IdCompetidor.Width = 250;
            // 
            // Competidor
            // 
            this.Competidor.HeaderText = "Competidor";
            this.Competidor.Name = "Competidor";
            this.Competidor.ReadOnly = true;
            this.Competidor.Width = 250;
            // 
            // IdCategoria
            // 
            this.IdCategoria.DataPropertyName = "IdCategoria";
            this.IdCategoria.HeaderText = "IdCategoria";
            this.IdCategoria.Name = "IdCategoria";
            this.IdCategoria.ReadOnly = true;
            this.IdCategoria.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdCategoria.Visible = false;
            this.IdCategoria.Width = 200;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 200;
            // 
            // Rama
            // 
            this.Rama.HeaderText = "Rama";
            this.Rama.Name = "Rama";
            this.Rama.ReadOnly = true;
            // 
            // Chip
            // 
            this.Chip.DataPropertyName = "Chip";
            this.Chip.HeaderText = "Chip";
            this.Chip.Name = "Chip";
            this.Chip.Width = 250;
            // 
            // VistaCapturaCarreras
            // 
            this.AcceptButton = this.btnGuardarCarrera;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelarCarrera;
            this.ClientSize = new System.Drawing.Size(1159, 514);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "VistaCapturaCarreras";
            this.Text = "Carreras";
            this.Load += new System.EventHandler(this.VistaCapturaCarreras_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.TabCarrerasDetalle.ResumeLayout(false);
            this.tabCompetidores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCarrerasCompetidores)).EndInit();
            this.tabPuntos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCarrerasPuntos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ctxMenuCompetidor.ResumeLayout(false);
            this.ctxMenuPunto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbCiudadCarrera;
        private System.Windows.Forms.ComboBox cmbEstadoCarrera;
        //private SuggestComboBox cmbPaisCarrera;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpFechaCarrera;
        private System.Windows.Forms.TextBox txtIdCarrera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelarCarrera;
        private System.Windows.Forms.Button btnGuardarCerrarCarrera;
        private System.Windows.Forms.Button btnGuardarCarrera;
        private System.Windows.Forms.TextBox txtDescripcionCarrera;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox chkListCategorias;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbPaisCarrera;
        private System.Windows.Forms.TabControl TabCarrerasDetalle;
        private System.Windows.Forms.TabPage tabCompetidores;
        private System.Windows.Forms.TabPage tabPuntos;
        private System.Windows.Forms.DataGridView gridCarrerasPuntos;
        private System.Windows.Forms.ComboBox cmbCompetidores;
        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.ComboBox cmbRama;
        public System.Windows.Forms.DataGridView gridCarrerasCompetidores;
        public System.Windows.Forms.Button btnAsignarChip;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Punto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intervalo;
        private System.Windows.Forms.ComboBox cmbPuntos;
        private System.Windows.Forms.ContextMenuStrip ctxMenuCompetidor;
        private System.Windows.Forms.ToolStripMenuItem toolStripEliminarCompetidor;
        private System.Windows.Forms.ContextMenuStrip ctxMenuPunto;
        private System.Windows.Forms.ToolStripMenuItem toolStripEliminarPunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCompetidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Competidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chip;
    }
}