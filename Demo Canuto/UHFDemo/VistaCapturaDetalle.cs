using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UHFDemo
{
    public partial class VistaCapturaDetalle : Form
    {
        string connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
        int IdEmpresa = 14;
        public DataGridView gridCompetidores { get; set; }
        public VistaCapturaCarreras vistaCarrera { get; set; }
        public R2000UartDemo vistaDemo2 { get; set; }

        public VistaCapturaDetalle(R2000UartDemo demo, VistaCapturaCarreras carrera)
        {
            InitializeComponent();
            LlenarDatos();
            vistaDemo2 = demo;
            vistaDemo2.vistaDetalle1 = this;
            vistaCarrera = carrera;
        }

        private void LlenarDatos()
        {
            DataTable dtDistancias = LlenarComboDistancias();
            cmbDistanciaCarreraDetalle.DataSource = dtDistancias;
            cmbDistanciaCarreraDetalle.DisplayMember = "Descripcion";
            cmbDistanciaCarreraDetalle.ValueMember = "IdDistancia";

            DataRow drDistancias = dtDistancias.NewRow();
            drDistancias["Descripcion"] = "Seleccionar";
            drDistancias["IdDistancia"] = 0;

            dtDistancias.Rows.InsertAt(drDistancias, 0);
            cmbDistanciaCarreraDetalle.SelectedIndex = 0;

            DataTable dtCategorias = LlenarComboCategorias();
            cmbCategoriaCarreraDetalle.DataSource = dtCategorias;
            cmbCategoriaCarreraDetalle.DisplayMember = "Descripcion";
            cmbCategoriaCarreraDetalle.ValueMember = "IdCategoria";

            DataRow drCategorias = dtCategorias.NewRow();
            drCategorias["Descripcion"] = "Seleccionar";
            drCategorias["IdCategoria"] = 0;

            dtCategorias.Rows.InsertAt(drCategorias, 0);
            cmbCategoriaCarreraDetalle.SelectedIndex = 0;
        }

        private DataTable LlenarComboDistancias()
        {
            string query = "SELECT IdDistancia, Descripcion FROM DISTANCIASCARRERA WHERE IDEMPRESA=" + IdEmpresa;
            return Populate(query);
        }

        private DataTable LlenarComboCategorias()
        {
            string query = "SELECT IdCategoria, Descripcion FROM CATEGORIAS WHERE IDEMPRESA=" + IdEmpresa;
            return Populate(query);
        }

        private DataTable Populate(string sqlCommand)
        {
            
            MySqlConnection mySqlCon = new MySqlConnection(connectionString);
            DataTable table = new DataTable();

            try
            {
                mySqlCon.Open();
                MySqlCommand command = new MySqlCommand(sqlCommand, mySqlCon);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(table);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (mySqlCon != null && mySqlCon.State == ConnectionState.Open)
                {
                    mySqlCon.Close();
                }
            }

            return table;
        }

        private bool ValidarCompetidorRepetido(VistaCapturaCarreras vista)
        {
            string competidor = gridCompetidores.CurrentCell != null ? gridCompetidores[vista.indiceCompetidor, gridCompetidores.CurrentCell.RowIndex].Value.ToString() : string.Empty;
            string fechaNacimiento = gridCompetidores.CurrentCell != null ? gridCompetidores[vista.indiceFechaNacimiento, gridCompetidores.CurrentCell.RowIndex].Value.ToString() : string.Empty;

            if (!string.IsNullOrEmpty(competidor) && !string.IsNullOrEmpty(fechaNacimiento))
            {
                foreach (DataGridViewRow row in gridCompetidores.Rows)
                {
                    if (row.Index != gridCompetidores.CurrentCell.RowIndex)
                    {
                        if (row.Cells[vista.indiceCompetidor].Value != null && row.Cells[vista.indiceCompetidor].Value.ToString() != "" && row.Cells[vista.indiceCompetidor].Value.ToString().Equals(competidor) &&
                            row.Cells[vista.indiceFechaNacimiento].Value != null && row.Cells[vista.indiceFechaNacimiento].Value.ToString() != "" && row.Cells[vista.indiceFechaNacimiento].Value.ToString().Equals(fechaNacimiento))
                        {
                            MessageBox.Show("Ya se encuentra registrado el competidor capturado");
                            return false;
                        }
                    }
                }
            }


            return true;
        }

        private bool ValidarNumeroRepetido(VistaCapturaCarreras vista)
        {
            string numero = gridCompetidores.CurrentCell != null ? gridCompetidores[vista.indiceNumero, gridCompetidores.CurrentCell.RowIndex].Value.ToString() : string.Empty;

            if (!string.IsNullOrEmpty(numero))
            {
                foreach (DataGridViewRow row in gridCompetidores.Rows)
                {
                    if (row.Index != gridCompetidores.CurrentCell.RowIndex)
                    {
                        if (row.Cells[vista.indiceNumero].Value != null && row.Cells[vista.indiceNumero].Value.ToString() != "" && row.Cells[vista.indiceNumero].Value.ToString().Equals(numero))
                        {
                            gridCompetidores.CurrentCell.Value = "";
                            MessageBox.Show("Ya se encuentra registrado el número de competidor capturado");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNumeroCarreraDetalle.Text))
            {
                MessageBox.Show("Debe de llenar todos los campos del competidor");
                return false;
            }
            else if(string.IsNullOrEmpty(txtCompetidorCarreraDetalle.Text))
            {
                MessageBox.Show("Debe de llenar todos los campos del competidor");
                return false;
            }
            else if (string.IsNullOrEmpty(dpFechaNacimientoCarreraDetalle.Text))
            {
                MessageBox.Show("Debe de llenar todos los campos del competidor");
                return false;
            }
            else if (cmbGeneroCarreraDetalle.SelectedValue == null || cmbGeneroCarreraDetalle.SelectedValue == "")
            {
                MessageBox.Show("Debe de llenar todos los campos del competidor");
                return false;
            }
            else if (string.IsNullOrEmpty(txtCiudadCarreraDetalle.Text))
            {
                MessageBox.Show("Debe de llenar todos los campos del competidor");
                return false;
            }
            else if (cmbDistanciaCarreraDetalle.SelectedValue == null || cmbDistanciaCarreraDetalle.SelectedValue == "" || cmbDistanciaCarreraDetalle.SelectedIndex <= 0)
            {
                MessageBox.Show("Debe de llenar todos los campos del competidor");
                return false;
            }
            else if (cmbCategoriaCarreraDetalle.SelectedValue == null || cmbCategoriaCarreraDetalle.SelectedValue == "" || cmbCategoriaCarreraDetalle.SelectedIndex <= 0)
            {
                MessageBox.Show("Debe de llenar todos los campos del competidor");
                return false;
            }
            else if (cmbRamaCarreraDetalle.SelectedValue == null || cmbRamaCarreraDetalle.SelectedValue == "")
            {
                MessageBox.Show("Debe de llenar todos los campos del competidor");
                return false;
            }
            else if (string.IsNullOrEmpty(txtChipCarreraDetalle.Text))
            {
                MessageBox.Show("Debe de llenar todos los campos del competidor");
                return false;
            }

            return true;
        }

        private void btnAceptarCarreraDetalle_Click(object sender, EventArgs e)
        {

            if (ValidarCampos() && ValidarCompetidorRepetido(vistaCarrera) && ValidarNumeroRepetido(vistaCarrera))
            {
                if (vistaCarrera.gridCarrerasCompetidores.CurrentCell != null)
                {

                    DataGridViewRow row = vistaCarrera.gridCarrerasCompetidores.Rows[vistaCarrera.gridCarrerasCompetidores.CurrentCell.RowIndex];

                    row.Cells[vistaCarrera.indiceNumero].Value = txtNumeroCarreraDetalle.Text;
                    row.Cells[vistaCarrera.indiceCompetidor].Value = txtCompetidorCarreraDetalle.Text;
                    row.Cells[vistaCarrera.indiceFechaNacimiento].Value = dpFechaNacimientoCarreraDetalle.Text;
                    row.Cells[vistaCarrera.indiceGenero].Value = cmbGeneroCarreraDetalle.SelectedValue;
                    row.Cells[vistaCarrera.indiceIdDistancia].Value = cmbDistanciaCarreraDetalle.SelectedValue;
                    row.Cells[vistaCarrera.indiceDistancia].Value = cmbDistanciaCarreraDetalle.SelectedText;
                    row.Cells[vistaCarrera.indiceIdCategoria].Value = cmbCategoriaCarreraDetalle.SelectedValue;
                    row.Cells[vistaCarrera.indiceCategoria].Value = cmbCategoriaCarreraDetalle.SelectedText;
                    row.Cells[vistaCarrera.indiceRama].Value = cmbRamaCarreraDetalle.SelectedValue;
                    row.Cells[vistaCarrera.indiceChip].Value = txtChipCarreraDetalle.Text;

                    vistaCarrera.ReajustarNumeros();
                }
                this.Close(); 
            }
        }

        private void txtNumeroCarreraDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void VistaCapturaDetalle_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir sin guardar cambios?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
