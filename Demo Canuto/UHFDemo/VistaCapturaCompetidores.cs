using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UHFDemo.Entidades;

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
            btnGuardarCompetidor.Click -= new EventHandler(Guardar);
            btnGuardarCompetidor.Click += new EventHandler(Guardar);
            btnGuardarCerrarCompetidor.Click -= new EventHandler(GuardarCerrar);
            btnGuardarCerrarCompetidor.Click += new EventHandler(GuardarCerrar);
            btnCancelarCompetidor.Click -= new EventHandler(Cancelar);
            btnCancelarCompetidor.Click += new EventHandler(Cancelar);
            this.FormClosing -= VistaCapturaCompetidores_FormClosing;
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
                connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
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
                    dtFechaNacimiento.Text = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    cmbGeneroCompetidor.SelectedItem = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                }

                LlenarComboPaises(idPais);
                if (!string.IsNullOrEmpty(idPais))
                {
                    LlenarComboEstados(idPais, idEstado);
                }

                if (!string.IsNullOrEmpty(idPais) && idEstado != 0)
                {
                    LlenarComboCiudades(idPais, idEstado, idCiudad);
                }
                
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
            txtAPaternoCompetidor.Text = "";
            txtAMaternoCompetidor.Text = "";
            txtNombreCompetidor.Text = "";
            txtDireccionCompetidor.Text = "";
            txtTelefonoCompetidor.Text = "";
            txtAPaternoCompetidor.Focus();
            LlenarComboPaises("");
            cmbEstadoCompetidor.Items.Clear();
            cmbCiudadCompetidor.Items.Clear();
            cmbGeneroCompetidor.SelectedItem = "Seleccionar";
            AsignarEventos();
        }

        private int ObtenerConsecutivo()
        {
            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
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
            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT IdPais, Descripcion FROM PAISES";
            try
            {
                cmbPaisCompetidor.SelectedIndexChanged -= cmbPaisCompetidor_SelectedIndexChanged;

                mysqlCon.Open();
                List<Pais> listaPaises = new List<Pais>();
                MySqlCommand sc = new MySqlCommand(query, mysqlCon);
                MySqlDataReader reader;

                reader = sc.ExecuteReader();
                int row = 0;
                int indiceSeleccionado = -1;
                while (reader.Read())
                {
                    int indice= 0;
                    string idPais = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    string descripcion = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    if (idPais == idPaisParam)
                    {
                        indiceSeleccionado = row;
                    }
                    listaPaises.Add(new Pais(idPais, descripcion));
                    row++;
                }


                cmbPaisCompetidor.DisplayMember = "Descripcion";
                cmbPaisCompetidor.ValueMember = "IdPais";
                cmbPaisCompetidor.DataSource = listaPaises;

                if (string.IsNullOrEmpty(idPaisParam) && indiceSeleccionado == -1)
                {
                    cmbPaisCompetidor.SelectedIndex = -1;
                }
                else
                {
                    cmbPaisCompetidor.SelectedItem = cmbPaisCompetidor.Items[indiceSeleccionado];
                }
                
                //cmbPaisCompetidor.SelectedIndex = indiceSeleccionado;
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
            string idPais = idPaisParam == "" ? cmbPaisCompetidor.SelectedValue.ToString() : idPaisParam;

            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT IdEstado, Descripcion FROM ESTADOS WHERE IDPAIS = '" + idPais + "'";
            try
            {

                cmbEstadoCompetidor.SelectedIndexChanged -= cmbEstadoCompetidor_SelectedIndexChanged;
                mysqlCon.Open();
                List<Estado> listaEstados = new List<Estado>();
                MySqlCommand sc = new MySqlCommand(query, mysqlCon);
                MySqlDataReader reader;

                reader = sc.ExecuteReader();
                
                int row = 0;
                int indiceSeleccionado = -1;
                while (reader.Read())
                {
                    int indice = 0;
                    int idEstado = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    string descripcion = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    if (idEstado == idEstadoParam)
                    {
                        indiceSeleccionado = row;
                    }
                    listaEstados.Add(new Estado(idPais, idEstado, descripcion));
                    row++;
                }

                cmbEstadoCompetidor.DisplayMember = "Descripcion";
                cmbEstadoCompetidor.ValueMember = "IdEstado";
                cmbEstadoCompetidor.DataSource = listaEstados;
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

            string idPais = idPaisParam == "" ? cmbPaisCompetidor.SelectedValue.ToString() : idPaisParam;
            int idEstado = idEstadoParam == 0 ? Convert.ToInt32(cmbEstadoCompetidor.SelectedValue) : idEstadoParam;

            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT IdCiudad, Descripcion FROM CIUDADES WHERE IDPAIS = '" + idPais + "' AND IDESTADO =" + idEstado;
            try
            {
                mysqlCon.Open();
                List<Ciudad> listaCiudades = new List<Ciudad>();
                MySqlCommand sc = new MySqlCommand(query, mysqlCon);
                MySqlDataReader reader;

                reader = sc.ExecuteReader();
                
                int row = 0;
                int indiceSeleccionado = -1;
                while (reader.Read())
                {
                    int indice = 0;
                    int idCiudad = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    string descripcion = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    if (idCiudad == idCiudadParam)
                    {
                        indiceSeleccionado = row;
                    }
                    listaCiudades.Add(new Ciudad(idPais, idEstado, idCiudad, descripcion));
                    row++;
                }

                cmbCiudadCompetidor.DisplayMember = "Descripcion";
                cmbCiudadCompetidor.ValueMember = "IdCiudad";
                cmbCiudadCompetidor.DataSource = listaCiudades;
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
            //else if (cmbPaisCompetidor.SelectedValue == "0")
            //{
            //    valido = false;
            //    MessageBox.Show("Debe de seleccionar un país");
            //    return valido;
            //}
            //else if (cmbEstadoCompetidor.SelectedValue == "0")
            //{
            //    valido = false;
            //    MessageBox.Show("Debe de seleccionar un estado");
            //    return valido;
            //}
            //else if (cmbCiudadCompetidor.SelectedValue == "0")
            //{
            //    valido = false;
            //    MessageBox.Show("Debe de seleccionar una ciudad");
            //    return valido;
            //}
            else if (string.IsNullOrEmpty(txtTelefonoCompetidor.Text))
            {
                valido = false;
                MessageBox.Show("Debe de capturar un teléfono");
                return valido;
            }
            else if (cmbGeneroCompetidor.SelectedItem == null || cmbGeneroCompetidor.SelectedItem.ToString() == "Seleccionar")
            {
                valido = false;
                MessageBox.Show("Debe de seleccionar un género");
                return valido;
            }
            //else if (string.IsNullOrEmpty(txtEdadCompetidor.Text))
            //{
            //    valido = false;
            //    MessageBox.Show("Debe de capturar una edad");
            //    return valido;
            //}

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
            string idPais = cmbPaisCompetidor.SelectedValue != null ? cmbPaisCompetidor.SelectedValue.ToString() : "";
            int idEstado = cmbEstadoCompetidor.SelectedValue != null ? Convert.ToInt32(cmbEstadoCompetidor.SelectedValue) : 0;
            int idCiudad = cmbCiudadCompetidor.SelectedValue != null ? Convert.ToInt32(cmbCiudadCompetidor.SelectedValue) : 0;
            string telefono = txtTelefonoCompetidor.Text;
            DateTime fecha = Convert.ToDateTime(dtFechaNacimiento.Text);
            string fechaNacimiento = fecha.ToString("yyyy-MM-dd");
            string genero = cmbGeneroCompetidor.SelectedItem.ToString();

            try
            {
               
                connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
                mysqlCon = new MySqlConnection(connectionString);
                mysqlCon.Open();

                StringBuilder sentencia = new StringBuilder();
                sentencia.AppendLine("INSERT INTO ");
                sentencia.AppendLine("	COMPETIDORES ");
                sentencia.AppendLine("	( ");
                sentencia.AppendLine("		 IDEMPRESA ");
                sentencia.AppendLine("		,IDCOMPETIDOR ");
                sentencia.AppendLine("		,APELLIDOPATERNO ");
                sentencia.AppendLine("		,APELLIDOMATERNO ");
                sentencia.AppendLine("		,NOMBRE ");
                sentencia.AppendLine("		,DIRECCION ");

                if (!string.IsNullOrEmpty(idPais))
                {
                    sentencia.AppendLine("		,IDPAIS ");
                }

                if (idEstado != 0)
                {
                    sentencia.AppendLine("		,IDESTADO ");
                }

                if (idCiudad != 0)
                {
                    sentencia.AppendLine("		,IDCIUDAD ");
                }

                sentencia.AppendLine("		,TELEFONO ");
                sentencia.AppendLine("		,FECHANACIMIENTO, ");
                sentencia.AppendLine("		,GENERO ");
                sentencia.AppendLine("	) ");
                sentencia.AppendLine("VALUES ");
                sentencia.AppendLine("	( ");
                sentencia.AppendLine("   " + IdEmpresa);
                sentencia.AppendLine("  ," + idCompetidor);
                sentencia.AppendLine("  ,'" + apellidoPaterno + "'");
                sentencia.AppendLine("  ,'" + apellidoMaterno + "'");
                sentencia.AppendLine("  ,'" + nombre + "'");
                sentencia.AppendLine("  ,'" + direccion + "'");

                if (!string.IsNullOrEmpty(idPais))
                {
                    sentencia.AppendLine("  ,'" + idPais + "'");
                }

                if (idEstado != 0)
                {
                    sentencia.AppendLine("  ," + idEstado);
                }

                if (idCiudad != 0)
                {
                    sentencia.AppendLine("  ," + idCiudad);
                }

                sentencia.AppendLine("  ,'" + telefono + "'");
                sentencia.AppendLine("  ,'" + fechaNacimiento + "'");
                sentencia.AppendLine("  ,'" + genero + "'");
                sentencia.AppendLine("	) ");


                MySqlCommand cmd = new MySqlCommand(sentencia.ToString(), mysqlCon);

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
            string idPais = cmbPaisCompetidor.SelectedValue != null ? cmbPaisCompetidor.SelectedValue.ToString() : "";
            int idEstado =  cmbEstadoCompetidor.SelectedValue != null ? Convert.ToInt32(cmbEstadoCompetidor.SelectedValue) : 0;
            int idCiudad = cmbCiudadCompetidor.SelectedValue != null ? Convert.ToInt32(cmbCiudadCompetidor.SelectedValue) : 0;
            string telefono = txtTelefonoCompetidor.Text;
            DateTime fecha = Convert.ToDateTime(dtFechaNacimiento.Text);
            string fechaNacimiento = fecha.ToString("yyyy-MM-dd");
            string genero = cmbGeneroCompetidor.SelectedItem.ToString();

            try
            {
         
                connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
                mysqlCon = new MySqlConnection(connectionString);
                mysqlCon.Open();

                StringBuilder sentencia = new StringBuilder();
                sentencia.AppendLine("INSERT INTO ");
                sentencia.AppendLine("	COMPETIDORES ");
                sentencia.AppendLine("	( ");
                sentencia.AppendLine("		 IDEMPRESA ");
                sentencia.AppendLine("		,IDCOMPETIDOR ");
                sentencia.AppendLine("		,APELLIDOPATERNO ");
                sentencia.AppendLine("		,APELLIDOMATERNO ");
                sentencia.AppendLine("		,NOMBRE ");
                sentencia.AppendLine("		,DIRECCION ");

                if (!string.IsNullOrEmpty(idPais))
                {
                    sentencia.AppendLine("		,IDPAIS ");
                }

                if (idEstado != 0)
                {
                    sentencia.AppendLine("		,IDESTADO ");
                }

                if (idCiudad != 0)
                {
                    sentencia.AppendLine("		,IDCIUDAD ");
                }
                
                sentencia.AppendLine("		,TELEFONO ");
                sentencia.AppendLine("		,FECHANACIMIENTO ");
                sentencia.AppendLine("		,GENERO ");
                sentencia.AppendLine("	) ");
                sentencia.AppendLine("VALUES ");
                sentencia.AppendLine("	( ");
                sentencia.AppendLine("   "  + IdEmpresa);
                sentencia.AppendLine("  ,"  + idCompetidor);
                sentencia.AppendLine("  ,'" + apellidoPaterno + "'");
                sentencia.AppendLine("  ,'"  + apellidoMaterno + "'");
                sentencia.AppendLine("  ,'"  + nombre + "'");
                sentencia.AppendLine("  ,'"  + direccion + "'");

                if (!string.IsNullOrEmpty(idPais))
                {
                    sentencia.AppendLine("  ,'" + idPais + "'");
                }

                if (idEstado != 0)
                {
                    sentencia.AppendLine("  ," + idEstado);
                }

                if (idCiudad != 0)
                {
                    sentencia.AppendLine("  ," + idCiudad);
                }
                
                sentencia.AppendLine("  ,'" + telefono + "'");
                sentencia.AppendLine("  ,'" + fechaNacimiento + "'");
                sentencia.AppendLine("  ,'" + genero + "'");
                sentencia.AppendLine("	) ");

                
                MySqlCommand cmd = new MySqlCommand(sentencia.ToString(), mysqlCon);

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

            int idCompetidor = Convert.ToInt32(txtIdCompetidor.Text);
            string apellidoPaterno = txtAPaternoCompetidor.Text;
            string apellidoMaterno = txtAMaternoCompetidor.Text;
            string nombre = txtNombreCompetidor.Text;
            string direccion = txtDireccionCompetidor.Text;
            string idPais = cmbPaisCompetidor.SelectedValue != null ? cmbPaisCompetidor.SelectedValue.ToString() : "";
            int idEstado = cmbEstadoCompetidor.SelectedValue != null ? Convert.ToInt32(cmbEstadoCompetidor.SelectedValue) : 0;
            int idCiudad = cmbCiudadCompetidor.SelectedValue != null ? Convert.ToInt32(cmbCiudadCompetidor.SelectedValue) : 0;
            string telefono = txtTelefonoCompetidor.Text;
            DateTime fecha = Convert.ToDateTime(dtFechaNacimiento.Text);
            string fechaNacimiento = fecha.ToString("yyyy-MM-dd");
            string genero = cmbGeneroCompetidor.SelectedItem.ToString();

            try
            {
    
                connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
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

                if (!string.IsNullOrEmpty(idPais))
                {
                    sentencia.AppendLine(" 	IDPAIS = '" + idPais + "', ");
                }

                if (idEstado != 0)
                {
                    sentencia.AppendLine(" 	IDESTADO = " + idEstado + ", ");
                }

                if (idCiudad != 0)
                {
                    sentencia.AppendLine(" 	IDCIUDAD = " + idCiudad + ", ");
                }
                
                sentencia.AppendLine(" 	TELEFONO = '" + telefono + "', ");
                sentencia.AppendLine(" 	FECHANACIMIENTO = '" + fechaNacimiento + "',  ");
                sentencia.AppendLine(" 	GENERO = '" + genero + "'  ");
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
