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
    public partial class VistaCapturaCompetidores : Form
    {
        int IdEmpresa = 14;
        string connectionString = "";
        string query = "";
        MySqlConnection mysqlCon = new MySqlConnection();
        R2000UartDemo VistaDemo = new R2000UartDemo();
        public bool entroGuardarCerrar = false;


        public VistaCapturaCompetidores(R2000UartDemo demo)
        {
            InitializeComponent();
            VistaDemo = demo;
        }

        private void AsignarEventos()
        {
            btnGuardarCompetidor.Click += new EventHandler(Guardar);
            btnGuardarCerrarCompetidor.Click += new EventHandler(GuardarCerrar);
            btnCancelarCompetidor.Click += new EventHandler(Cancelar);
            this.FormClosing += VistaCapturaCompetidores_FormClosing;
        }

        void VistaCapturaCompetidores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!entroGuardarCerrar)
            {
                DialogResult result = MessageBox.Show("¿Desea salir sin guardar cambios?", "Confirmación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    VistaDemo.LlenarListadoCompetidores();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                VistaDemo.LlenarListadoCompetidores();
            }
            entroGuardarCerrar = false;
            
        }

        void cmbPaisCompetidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboEstados("", 0);
        }

        private void VistaCapturaCompetidores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'inventariofacturacionDataSet.paises' Puede moverla o quitarla según sea necesario.

            LlenarComboPaises("");
        }

        public void RegistrarCompetidor()
        {
            
            InicializarFormularioCompetidores();
            btnGuardarCompetidor.Visible = true;
        }

        public void ModificarCompetidor(int idCompetidor)
        {
            string idPais = "";
            int idEstado = 0;
            int idCiudad = 0;

            try
            {
                connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
                mysqlCon = new MySqlConnection(connectionString);
                mysqlCon.Open();
                query = "SELECT * FROM COMPETIDORES WHERE IDEMPRESA = "+ IdEmpresa + " AND IDCOMPETIDOR = " + idCompetidor;

                MySqlCommand cmd = new MySqlCommand(query, mysqlCon);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()){
                    int indice = 1;
                    txtIdCompetidor.Text = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    txtAPaternoCompetidor.Text = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    txtAMaternoCompetidor.Text = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    txtNombreCompetidor.Text = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    txtDireccionCompetidor.Text = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    idPais = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    idEstado = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    idCiudad =  (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    txtTelefonoCompetidor.Text = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    txtEdadCompetidor.Text = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                }

                LlenarComboPaises(idPais);
                LlenarComboEstados(idPais, idEstado);
                LlenarComboCiudades(idPais, idEstado, idCiudad);

                txtAPaternoCompetidor.Focus();
                btnGuardarCompetidor.Visible = false;
                btnGuardarCerrarCompetidor.Click -= new EventHandler(GuardarCerrar);;
                btnGuardarCerrarCompetidor.Click += new EventHandler(Actualizar);
                btnCancelarCompetidor.Click += new EventHandler(Cancelar);
                this.FormClosing += VistaCapturaCompetidores_FormClosing;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(mysqlCon != null && mysqlCon.State == ConnectionState.Open)
                {
                    mysqlCon.Close();
                }
            }
        }

        private void InicializarFormularioCompetidores()
        {
            txtIdCompetidor.Text = ObtenerConsecutivo().ToString();
            txtAPaternoCompetidor.Focus();
            AsignarEventos();
        }

        private int ObtenerConsecutivo()
        {
            connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT ifnull(MAX(IdCompetidor), 0) + 1 from competidores where idempresa = " + IdEmpresa;
            int idCompetidor = 0;
            try
            {
                mysqlCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, mysqlCon);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idCompetidor = (reader[0] is DBNull) ? 0 : reader.GetInt32(0);
                }
                return idCompetidor;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                mysqlCon.Close();
            }
        }

        private void LlenarComboPaises(string idPaisParam)
        {
            connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT IdPais, Descripcion FROM PAISES";
            try
            {
                cmbPaisCompetidor.SelectedIndexChanged -= cmbPaisCompetidor_SelectedIndexChanged;

                mysqlCon.Open();
                List<Item> lista = new List<Item>();
                MySqlCommand sc = new MySqlCommand(query, mysqlCon);
                MySqlDataReader reader;

                reader = sc.ExecuteReader();
                lista.Add(new Item("Seleccionar", ""));
                int row = 1;
                int indiceSeleccionado = 0;
                while (reader.Read())
                {
                    int indice= 0;
                    string idPais = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    string descripcion = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    if (idPais == idPaisParam)
                    {
                        indiceSeleccionado = row;
                    }
                    lista.Add(new Item(descripcion, idPais));
                    row++;
                }


                cmbPaisCompetidor.DisplayMember = "Descripcion";
                cmbPaisCompetidor.ValueMember = "IdPais";
                cmbPaisCompetidor.DataSource = lista;

                cmbPaisCompetidor.SelectedIndex = indiceSeleccionado;
                cmbPaisCompetidor.SelectedItem= cmbPaisCompetidor.Items[indiceSeleccionado];
                cmbPaisCompetidor.Text = ((Item)cmbPaisCompetidor.Items[indiceSeleccionado]).Name;
                cmbPaisCompetidor.SelectedIndexChanged += cmbPaisCompetidor_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mysqlCon.Close();
            }
        }

        private void LlenarComboEstados(string idPaisParam, int idEstadoParam)
        {
            var item = (Item)cmbPaisCompetidor.SelectedValue;
            string idPais = idPaisParam == "" ? item.Value : idPaisParam;

            connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT IdEstado, Descripcion FROM ESTADOS WHERE IDPAIS = '" + idPais + "'";
            try
            {

                cmbEstadoCompetidor.SelectedIndexChanged -= cmbEstadoCompetidor_SelectedIndexChanged;
                mysqlCon.Open();
                List<Item> lista = new List<Item>();
                MySqlCommand sc = new MySqlCommand(query, mysqlCon);
                MySqlDataReader reader;

                reader = sc.ExecuteReader();
                lista.Add(new Item("Seleccionar", ""));
                int row = 1;
                int indiceSeleccionado = 0;
                while (reader.Read())
                {
                    int indice = 0;
                    int idEstado = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    string descripcion = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    if (idEstado == idEstadoParam)
                    {
                        indiceSeleccionado = row;
                    }
                    lista.Add(new Item(descripcion, idEstado));
                    row++;
                }

                cmbEstadoCompetidor.DisplayMember = "Descripcion";
                cmbEstadoCompetidor.ValueMember = "IdEstado";
                cmbEstadoCompetidor.DataSource = lista;
                cmbEstadoCompetidor.SelectedIndex = indiceSeleccionado;
                cmbEstadoCompetidor.SelectedIndexChanged += cmbEstadoCompetidor_SelectedIndexChanged;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                mysqlCon.Close();
            }
        }

        private void LlenarComboCiudades(string idPaisParam, int idEstadoParam, int idCiudadParam)
        {
            var item = (Item)cmbPaisCompetidor.SelectedValue;
            var item2 = (Item)cmbEstadoCompetidor.SelectedValue;

            string idPais = idPaisParam == "" ? item.Value : idPaisParam;
            int idEstado = idEstadoParam == 0 ? Convert.ToInt32(item2.Value) : idEstadoParam;

            connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT IdCiudad, Descripcion FROM CIUDADES WHERE IDPAIS = '" + idPais + "' AND IDESTADO =" + idEstado;
            try
            {
                mysqlCon.Open();
                List<Item> lista = new List<Item>();
                MySqlCommand sc = new MySqlCommand(query, mysqlCon);
                MySqlDataReader reader;

                reader = sc.ExecuteReader();
                lista.Add(new Item("Seleccionar", ""));
                int row = 1;
                int indiceSeleccionado = 0;
                while (reader.Read())
                {
                    int indice = 0;
                    int idCiudad = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    string descripcion = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    if (idCiudad == idCiudadParam)
                    {
                        indiceSeleccionado = row;
                    }
                    lista.Add(new Item(descripcion, idCiudad));
                    row++;
                }

                cmbCiudadCompetidor.DisplayMember = "Descripcion";
                cmbCiudadCompetidor.ValueMember = "IdCiudad";
                cmbCiudadCompetidor.DataSource = lista;
                cmbCiudadCompetidor.SelectedIndex = indiceSeleccionado;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                mysqlCon.Close();
            }
        }

        void cmbEstadoCompetidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboCiudades("", 0, 0);
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtAPaternoCompetidor.Text))
            {
                valido = false;
                MessageBox.Show("Debe de capturar un apellido paterno");
                return valido;
            }
            else if (string.IsNullOrEmpty(txtAMaternoCompetidor.Text))
            {
                valido = false;
                MessageBox.Show("Debe de capturar un apellido materno");
                return valido;
            }
            else if (string.IsNullOrEmpty(txtNombreCompetidor.Text))
            {
                valido = false;
                MessageBox.Show("Debe de capturar un nombre");
                return valido;
            }
            else if (string.IsNullOrEmpty(txtDireccionCompetidor.Text))
            {
                valido = false;
                MessageBox.Show("Debe de capturar una dirección");
                return valido;
            }
            else if (cmbPaisCompetidor.SelectedValue == "0")
            {
                valido = false;
                MessageBox.Show("Debe de seleccionar un país");
                return valido;
            }
            else if (cmbEstadoCompetidor.SelectedValue == "0")
            {
                valido = false;
                MessageBox.Show("Debe de seleccionar un estado");
                return valido;
            }
            else if (cmbCiudadCompetidor.SelectedValue == "0")
            {
                valido = false;
                MessageBox.Show("Debe de seleccionar una ciudad");
                return valido;
            }
            else if (string.IsNullOrEmpty(txtTelefonoCompetidor.Text))
            {
                valido = false;
                MessageBox.Show("Debe de capturar un teléfono");
                return valido;
            }
            else if (string.IsNullOrEmpty(txtEdadCompetidor.Text))
            {
                valido = false;
                MessageBox.Show("Debe de capturar una edad");
                return valido;
            }

            return valido;

        }

        private void Guardar(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            int idCompetidor = ObtenerConsecutivo();
            string apellidoPaterno = txtAPaternoCompetidor.Text;
            string apellidoMaterno = txtAMaternoCompetidor.Text;
            string nombre = txtNombreCompetidor.Text;
            string direccion = txtDireccionCompetidor.Text;
            string idPais = ((Item)cmbPaisCompetidor.SelectedValue).Value.ToString();
            int idEstado = Convert.ToInt32(((Item)cmbEstadoCompetidor.SelectedValue).Value);
            int idCiudad = Convert.ToInt32(((Item)cmbCiudadCompetidor.SelectedValue).Value);
            string telefono = txtTelefonoCompetidor.Text;
            int edad = Convert.ToInt32(txtEdadCompetidor.Text);

            try
            {
               
                connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
                mysqlCon = new MySqlConnection(connectionString);
                mysqlCon.Open();
                query = "INSERT INTO COMPETIDORES VALUES (" + IdEmpresa + ", " + idCompetidor + ", '" + apellidoPaterno.Trim() + "', '" + apellidoMaterno.Trim() + "', '" + nombre.Trim() + "', '" + direccion.Trim() + "', '" + idPais + "', " + idEstado + ", " + idCiudad + ", '" + telefono + "', " + edad + " )";
                MySqlCommand cmd = new MySqlCommand(query, mysqlCon);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Competidor guardado correctamente.");
                    InicializarFormularioCompetidores();
                }
                else
                {
                    MessageBox.Show("Hubo un error al guardar el competidor comunicarse con el administrador.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                if (mysqlCon != null && mysqlCon.State == ConnectionState.Open)
                {
                    mysqlCon.Close();
                }
            }
        }

        private void GuardarCerrar(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            int idCompetidor = ObtenerConsecutivo();
            string apellidoPaterno = txtAPaternoCompetidor.Text;
            string apellidoMaterno = txtAMaternoCompetidor.Text;
            string nombre = txtNombreCompetidor.Text;
            string direccion = txtDireccionCompetidor.Text;
            string idPais = ((Item)cmbPaisCompetidor.SelectedValue).Value.ToString();
            int idEstado = Convert.ToInt32(((Item)cmbEstadoCompetidor.SelectedValue).Value);
            int idCiudad = Convert.ToInt32(((Item)cmbCiudadCompetidor.SelectedValue).Value);
            string telefono = txtTelefonoCompetidor.Text;
            int edad = Convert.ToInt32(txtEdadCompetidor.Text);

            try
            {
         
                connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
                mysqlCon = new MySqlConnection(connectionString);
                mysqlCon.Open();
                query = "INSERT INTO COMPETIDORES VALUES(" + IdEmpresa + ", " + idCompetidor + ", '" + apellidoPaterno.Trim() + "', '" + apellidoMaterno.Trim() + "', '" + nombre.Trim() + "', '" + direccion.Trim() + "', '" + idPais + "', " + idEstado + ", " + idCiudad + ", '" + telefono + "'," + edad + " )";
                MySqlCommand cmd = new MySqlCommand(query, mysqlCon);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Competidor guardado correctamente.");
                    entroGuardarCerrar = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hubo un error al guardar el competidor comunicarse con el administrador.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                if (mysqlCon != null && mysqlCon.State == ConnectionState.Open)
                {
                    mysqlCon.Close();
                }
            }
        }

        private void Actualizar(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            int idCompetidor = ObtenerConsecutivo();
            string apellidoPaterno = txtAPaternoCompetidor.Text;
            string apellidoMaterno = txtAMaternoCompetidor.Text;
            string nombre = txtNombreCompetidor.Text;
            string direccion = txtDireccionCompetidor.Text;
            string idPais = ((Item)cmbPaisCompetidor.SelectedValue).Value.ToString();
            int idEstado = Convert.ToInt32(((Item)cmbEstadoCompetidor.SelectedValue).Value);
            int idCiudad = Convert.ToInt32(((Item)cmbCiudadCompetidor.SelectedValue).Value);
            string telefono = txtTelefonoCompetidor.Text;
            int edad = Convert.ToInt32(txtEdadCompetidor.Text);

            try
            {
    
                connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
                mysqlCon = new MySqlConnection(connectionString);
                mysqlCon.Open();

                StringBuilder sentencia = new StringBuilder();
                sentencia.AppendLine(" UPDATE ");
                sentencia.AppendLine(" 	COMPETIDORES ");
                sentencia.AppendLine(" SET ");
                sentencia.AppendLine(" 	APELLIDOPATERNO = '" + apellidoPaterno + "', ");
                sentencia.AppendLine(" 	APELLIDOMATERNO = '" + apellidoMaterno + "', ");
                sentencia.AppendLine(" 	NOMBRE = '" + nombre + "', ");
                sentencia.AppendLine(" 	DIRECCION = '" + direccion + "', ");
                sentencia.AppendLine(" 	IDPAIS = '" + idPais + "', ");
                sentencia.AppendLine(" 	IDESTADO = " + idEstado + ", ");
                sentencia.AppendLine(" 	IDCIUDAD = " + idCiudad + ", ");
                sentencia.AppendLine(" 	TELEFONO = '" + telefono + "', ");
                sentencia.AppendLine(" 	EDAD = " + edad + "  ");
                sentencia.AppendLine(" WHERE IDEMPRESA = " + IdEmpresa + " AND IDCOMPETIDOR = " + idCompetidor);
                query = sentencia.ToString();
                MySqlCommand cmd = new MySqlCommand(query, mysqlCon);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Competidor modificado correctamente.");
                    entroGuardarCerrar = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hubo un error al modificar el competidor comunicarse con el administrador.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                if (mysqlCon != null && mysqlCon.State == ConnectionState.Open)
                {
                    mysqlCon.Close();
                }
            }
        }

        private void Cancelar(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
