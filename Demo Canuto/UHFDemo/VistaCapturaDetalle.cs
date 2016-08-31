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
        public bool guardo = false;

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
            gridCompetidores = vista.gridCarrerasCompetidores;

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
            gridCompetidores = vista.gridCarrerasCompetidores;
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
            else if (cmbGeneroCarreraDetalle.SelectedItem == null || cmbGeneroCarreraDetalle.SelectedItem.ToString() == "")
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
            else if (cmbRamaCarreraDetalle.SelectedItem == null || cmbRamaCarreraDetalle.SelectedItem.ToString() == "")
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
                    row.Cells[vistaCarrera.indiceGenero].Value = cmbGeneroCarreraDetalle.SelectedItem.ToString();
                    row.Cells[vistaCarrera.indiceCiudad].Value = txtCiudadCarreraDetalle.Text;
                    row.Cells[vistaCarrera.indiceIdDistancia].Value = cmbDistanciaCarreraDetalle.SelectedValue;
                    row.Cells[vistaCarrera.indiceDistancia].Value = cmbDistanciaCarreraDetalle.Text;
                    row.Cells[vistaCarrera.indiceIdCategoria].Value = cmbCategoriaCarreraDetalle.SelectedValue;
                    row.Cells[vistaCarrera.indiceCategoria].Value = cmbCategoriaCarreraDetalle.Text;
                    row.Cells[vistaCarrera.indiceRama].Value = cmbRamaCarreraDetalle.SelectedItem.ToString();
                    row.Cells[vistaCarrera.indiceChip].Value = txtChipCarreraDetalle.Text;

                    vistaCarrera.ReajustarNumeros();
                }
                guardo = true;
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
            if (!guardo)
            {
                DialogResult result = MessageBox.Show("¿Desea salir sin guardar cambios?", "Confirmación", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                
            }
            guardo = false;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg,
            System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                if (ActiveControl.Name == "dpFechaNacimientoCarreraDetalle")
                {
                    if (!string.IsNullOrEmpty(dpFechaNacimientoCarreraDetalle.Text))
                    {
                        DateTime fecha = Convert.ToDateTime(dpFechaNacimientoCarreraDetalle.Text);
                        ObtenerDatosAdicionales(fecha.ToString("yyyy-MM-dd"), vistaCarrera);
                    }
                }
            }
            else if (keyData == Keys.Enter)
            {
                if (ActiveControl.Name == "cmbGeneroCarreraDetalle")
                {
                    if (cmbGeneroCarreraDetalle.SelectedItem.ToString().ToUpper() == "MASCULINO")
                    {
                        cmbRamaCarreraDetalle.SelectedItem = "Varonil";
                    }
                    else
                    {
                        cmbRamaCarreraDetalle.SelectedItem = "Femenil";
                    }
                }
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool ObtenerDatosAdicionales(string fechaNacimiento, VistaCapturaCarreras vista)
        {
            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
            MySqlConnection mysqlCon = new MySqlConnection(connectionString);
            string categorias = "";
            if (vista.chkListCategorias.CheckedItems.Count > 0)
            {
                foreach (Item item in vista.chkListCategorias.CheckedItems)
                {
                    if (categorias == "")
                    {
                        categorias += string.Concat(item.Value);
                    }
                    else
                    {
                        categorias += string.Concat(", ", item.Value);
                    }
                }
            }

            try
            {
                
                mysqlCon.Open();

                StringBuilder sentencia = new StringBuilder();
                sentencia.AppendLine("SELECT ");
                sentencia.AppendLine("	A.IDCATEGORIA, ");
                sentencia.AppendLine("	A.DESCRIPCION ");
                sentencia.AppendLine("FROM ");
                sentencia.AppendLine("	CATEGORIAS AS A ");
                sentencia.AppendLine("WHERE ");
                sentencia.AppendLine("	( ");
                sentencia.AppendLine("		SELECT ");
                sentencia.AppendLine("			TIMESTAMPDIFF( ");
                sentencia.AppendLine("				YEAR, ");
                sentencia.AppendLine("				('" + fechaNacimiento + "'), ");
                sentencia.AppendLine("				NOW() ");
                sentencia.AppendLine("			) AS EDAD ");
                sentencia.AppendLine("	) BETWEEN A.EdadInicial ");
                sentencia.AppendLine("AND A.EdadFinal ");
                sentencia.AppendLine("AND A.IDCATEGORIA IN (" + categorias + ") ");
                sentencia.AppendLine("LIMIT 1");

                MySqlCommand cmd = new MySqlCommand(sentencia.ToString(), mysqlCon);
                MySqlDataReader reader = cmd.ExecuteReader();

                int idCategoria = 0;
                string categoria = "";
                string rama = "";

                while (reader.Read())
                {
                    int indice = 0;
                    idCategoria = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    categoria = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                }

                if (idCategoria == 0)
                {
                    MessageBox.Show("No se encontró una categoría para el competidor");
                    cmbCategoriaCarreraDetalle.SelectedValue = 0;
                    return false;
                }
                else
                {
                    cmbCategoriaCarreraDetalle.SelectedValue = idCategoria;
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (mysqlCon != null && mysqlCon.State == ConnectionState.Open)
                {
                    mysqlCon.Close();
                }
            }
        }

        private void cmbGeneroCarreraDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGeneroCarreraDetalle.SelectedItem.ToString().ToUpper() == "MASCULINO")
            {
                cmbRamaCarreraDetalle.SelectedItem = "Varonil";
            }
            else
            {
                cmbRamaCarreraDetalle.SelectedItem = "Femenil";
            }
        }
    }
}
