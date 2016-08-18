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
    public partial class VistaCapturaCarreras : Form
    {
        int IdEmpresa = 14;
        string connectionString = "";
        string query = "";
        MySqlConnection mysqlCon = new MySqlConnection();
        R2000UartDemo VistaDemo = new R2000UartDemo();

        public DataGridView gridActual { get; set; }
        public string accion { get; set; }
        public bool entroGuardarCerrar = false;
        


        public VistaCapturaCarreras(R2000UartDemo demo)
        {
            InitializeComponent();
            VistaDemo = demo;

        }

        private void AsignarEventos()
        {
            cmbPaisCarrera.SelectedIndexChanged += cmbPaisCarrrera_SelectedIndexChanged;
            cmbEstadoCarrera.SelectedIndexChanged += cmbEstadoCarrera_SelectedIndexChanged;
            this.FormClosing += VistaCapturaCarreras_FormClosing;
        }

        void VistaCapturaCarreras_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!entroGuardarCerrar)
            {
                DialogResult result = MessageBox.Show("¿Desea salir sin guardar cambios?", "Confirmación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    VistaDemo.LlenarListadoCarreras();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                VistaDemo.LlenarListadoCarreras();
            }
            entroGuardarCerrar = false;
            Globales.capturaCarrera = false;
        }

        void cmbEstadoCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboCiudades("", 0, 0);
        }

        void cmbPaisCarrrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboEstados("", 0);
        }

        public void RegistrarCarrera()
        {
            btnGuardarCarrera.Visible = true;
            Globales.capturaCarrera = true;
        }

        public void ModificarCarrera(int idCarrera)
        {
            LlenarDatosCarrera(idCarrera);
            btnGuardarCarrera.Visible = false;
            this.FormClosing += VistaCapturaCarreras_FormClosing;
            Globales.capturaCarrera = true;
        }

        private void InicializarFormularioCarreras()
        {
            try
            {
                LlenarComboPaises("");
                LlenarComboCategorias(0);
                txtIdCarrera.Text = ObtenerConsecutivo().ToString();
                dpFechaCarrera.Focus();
                if (cmbCategoriaCarrera.Items.Count > 0)
                {
                    cmbCategoriaCarrera.SelectedIndex = 0;
                }

                if (cmbPaisCarrera.Items.Count > 0)
                {
                    cmbPaisCarrera.SelectedIndex = 0;
                }

                if (cmbEstadoCarrera.Items.Count > 0)
                {
                    cmbEstadoCarrera.SelectedIndex = 0;
                }

                if (cmbCiudadCarrera.Items.Count > 0)
                {
                    cmbCiudadCarrera.SelectedIndex = 0;
                }
                
                TabCategorias.TabPages.Clear();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
           
        }

        private int ObtenerConsecutivo()
        {
            connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT ifnull(MAX(IdCarrera), 0) + 1 from carreras where idempresa = " + IdEmpresa;
            int idCarrera = 0;
            try
            {
                mysqlCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, mysqlCon);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idCarrera = (reader[0] is DBNull) ? 0 : reader.GetInt32(0);
                }
                return idCarrera;

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
                cmbPaisCarrera.SelectedIndexChanged -= cmbPaisCarrrera_SelectedIndexChanged;

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
                    string idPais = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    string descripcion = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    if (idPais == idPaisParam)
                    {
                        indiceSeleccionado = row;
                    }
                    lista.Add(new Item(descripcion, idPais));
                    row++;
                }


                cmbPaisCarrera.DisplayMember = "Descripcion";
                cmbPaisCarrera.ValueMember = "IdPais";
                cmbPaisCarrera.DataSource = lista;

                cmbPaisCarrera.SelectedItem = cmbPaisCarrera.Items[indiceSeleccionado];
                cmbPaisCarrera.Text = ((Item)cmbPaisCarrera.Items[indiceSeleccionado]).Name;
                cmbPaisCarrera.SelectedIndexChanged += cmbPaisCarrrera_SelectedIndexChanged;
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

        private void LlenarComboEstados(string idPaisParam, int idEstadoParam)
        {
            var item = (Item)cmbPaisCarrera.SelectedValue;
            string idPais = idPaisParam == "" ? item.Value : idPaisParam;

            connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT IdEstado, Descripcion FROM ESTADOS WHERE IDPAIS = '" + idPais + "'";
            try
            {

                cmbEstadoCarrera.SelectedIndexChanged -= cmbEstadoCarrera_SelectedIndexChanged;
                mysqlCon.Open();
                List<Item> lista = new List<Item>();
                MySqlCommand sc = new MySqlCommand(query, mysqlCon);
                MySqlDataReader reader;

                reader = sc.ExecuteReader();
                lista.Add(new Item("Seleccionar", 0));
                int row = 1;
                int indiceSeleccionado = 0;
                while (reader.Read())
                {
                    int indice = 0;
                    int idEstado = (reader[indice] is DBNull) ? 9 : reader.GetInt32(indice); indice++;
                    string descripcion = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    if (idEstado == idEstadoParam)
                    {
                        indiceSeleccionado = row;
                    }
                    lista.Add(new Item(descripcion, idEstado));
                    row++;
                }

                cmbEstadoCarrera.DisplayMember = "Descripcion";
                cmbEstadoCarrera.ValueMember = "IdEstado";
                cmbEstadoCarrera.DataSource = lista;
                cmbEstadoCarrera.SelectedIndex = indiceSeleccionado;
                cmbEstadoCarrera.SelectedIndexChanged += cmbEstadoCarrera_SelectedIndexChanged;

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
            var item = (Item)cmbPaisCarrera.SelectedValue;
            var item2 = (Item)cmbEstadoCarrera.SelectedValue;

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
                lista.Add(new Item("Seleccionar", 0));
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

                cmbCiudadCarrera.DisplayMember = "Descripcion";
                cmbCiudadCarrera.ValueMember = "IdCiudad";
                cmbCiudadCarrera.DataSource = lista;
                cmbCiudadCarrera.SelectedIndex = indiceSeleccionado;

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

        private void LlenarComboCategorias(int idCategoriaParam)
        {

            connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT IdCategoria, Descripcion FROM CATEGORIAS WHERE IDEMPRESA=" + IdEmpresa;
            try
            {
                mysqlCon.Open();
                List<Item> lista = new List<Item>();
                MySqlCommand sc = new MySqlCommand(query, mysqlCon);
                MySqlDataReader reader;

                reader = sc.ExecuteReader();
                lista.Add(new Item("Seleccionar", 0));
                int row = 1;
                int indiceSeleccionado = 0;
                while (reader.Read())
                {
                    int indice = 0;
                    int idCategoria = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    string descripcion = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    if (idCategoria == idCategoriaParam)
                    {
                        indiceSeleccionado = row;
                    }
                    lista.Add(new Item(descripcion, idCategoria));
                    row++;
                }

                cmbCategoriaCarrera.DisplayMember = "Descripcion";
                cmbCategoriaCarrera.ValueMember = "IdCategoria";
                cmbCategoriaCarrera.DataSource = lista;
                cmbCategoriaCarrera.SelectedIndex = indiceSeleccionado;

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

        private DataTable LlenarComboCompetidores()
        {
            query = "SELECT IdCompetidor, CONCAT(ApellidoPaterno, ' ', ApellidoMaterno, ' ' , Nombre) as NombreCompleto FROM COMPETIDORES WHERE IDEMPRESA=" + IdEmpresa;
            return Populate(query);
        }

        private DataTable Populate(string sqlCommand)
        {
            connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
            MySqlConnection northwindConnection = new MySqlConnection(connectionString);
            northwindConnection.Open();

            MySqlCommand command = new MySqlCommand(sqlCommand, northwindConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        //private List<Item> LlenarComboCompetidores()
        //{
        //    connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
        //    mysqlCon = new MySqlConnection(connectionString);
        //    query = "SELECT IdCompetidor, CONCAT(ApellidoPaterno, ' ', ApellidoMaterno, ' ' , Nombre) as NombreCompleto FROM COMPETIDORES WHERE IDEMPRESA=" + IdEmpresa;
        //    try
        //    {
        //        mysqlCon.Open();
        //        List<Item> lista = new List<Item>();
        //        MySqlCommand sc = new MySqlCommand(query, mysqlCon);
        //        MySqlDataReader reader;

        //        reader = sc.ExecuteReader();
        //        lista.Add(new Item("Seleccionar", 0));
        //        int row = 1;
        //        while (reader.Read())
        //        {
        //            int indice = 0;
        //            int idCompetidor = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
        //            string nombreCompleto = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
        //            lista.Add(new Item(nombreCompleto, idCompetidor));
        //            row++;
        //        }

        //        return lista;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        throw ex;
        //    }
        //    finally
        //    {
        //        mysqlCon.Close();
        //    }
        //}

        private bool ValidarCamposCarrera()
        {
            bool valido = true;
            if (txtIdCarrera.Text == "")
            {
                MessageBox.Show("Debe de existir un id para la carrera");
                return false;
            }
            if (txtDescripcionCarrera.Text == "")
            {
                MessageBox.Show("Debe de capturar un nombre para la carrera");
                return false;
            }
            else if (dpFechaCarrera.Text == "")
            {
                MessageBox.Show("Debe de capturar una fecha para la carrera");
                return false;
            }
            else if (cmbPaisCarrera.Items.Count == 0 || ((Item)cmbPaisCarrera.SelectedValue).Value == "")
            {
                MessageBox.Show("Debe de seleccionar un país");
                return false;
            }
            else if (cmbEstadoCarrera.Items.Count == 0 || ((Item)cmbEstadoCarrera.SelectedValue).Value == "" || ((Item)cmbEstadoCarrera.SelectedValue).Value.ToString() == "0")
            {
                MessageBox.Show("Debe de seleccionar un estado");
                return false;
            }
            else if (cmbCiudadCarrera.Items.Count == 0 || ((Item)cmbCiudadCarrera.SelectedValue).Value == "" || ((Item)cmbCiudadCarrera.SelectedValue).Value.ToString() == "0")
            {
                MessageBox.Show("Debe de seleccionar una ciudad");
                return false;
            }

            if (TabCategorias.TabPages.Count == 0)
            {
                MessageBox.Show("Debe de agregar por lo menos una categoría a la carrera");
                return false;
            }


            foreach (TabPage tab in TabCategorias.TabPages)
            {
                bool encontroGrid = false;
                foreach (Control control in tab.Controls)
                {
                    if (control.GetType().Name == "DataGridView")
                    {
                        DataGridView grid = (DataGridView)control;
                        encontroGrid = true;
                        int indice = 1;

                        if (grid.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in grid.Rows)
                            {
                                if (row.Cells[1].Value == null || row.Cells[1].Value.ToString() == "" || row.Cells[1].Value.ToString() == "0")
                                {
                                    MessageBox.Show("Debe de seleccionar un competidor en el indice = " + indice);
                                    return false;
                                }

                                if (row.Cells[2].Value == null || row.Cells[2].Value.ToString() == "" || row.Cells[2].Value.ToString() == "0")
                                {
                                    MessageBox.Show("Debe de asignar un chip al competidor " + row.Cells[0].Value);
                                    return false;
                                }
                                indice++;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay competidores registrados en la categoría " + tab.Name);
                            return false;
                        }
                    }
                }

                if (!encontroGrid)
                {
                    MessageBox.Show("No hay competidores capturados en la categoria " + tab.Name);
                }
                    
            }

            return true;
        }

        private void btnGuardarCarrera_Click(object sender, EventArgs e)
        {

            if (ValidarCamposCarrera())
            {
                int idCarrera = ObtenerConsecutivo();
                string descripcion = txtDescripcionCarrera.Text;
                string fecha = dpFechaCarrera.Text;
                DateTime fechaCarrera = Convert.ToDateTime(fecha);
                string idPais = ((Item)cmbPaisCarrera.SelectedValue).Value.ToString();
                int idEstado = Convert.ToInt32(((Item)cmbEstadoCarrera.SelectedValue).Value);
                int idCiudad = Convert.ToInt32(((Item)cmbCiudadCarrera.SelectedValue).Value);
                
                connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";

                MySqlTransaction transaccion = null;
                mysqlCon = new MySqlConnection(connectionString);
                mysqlCon.Open();
                transaccion = mysqlCon.BeginTransaction();
                try
                {

                    if (InsertarMaestro(idCarrera, descripcion, fechaCarrera, idPais, idEstado, idCiudad, mysqlCon, transaccion))
                    {
                        foreach (TabPage tab in TabCategorias.TabPages)
                        {

                            DataGridView grid = (DataGridView)tab.Controls["tablaCarrerasDetalle"];

                            if (grid.Rows.Count > 0)
                            {
                                StringBuilder cadena = new StringBuilder();
                                cadena.AppendLine("INSERT INTO CARRERASDETALLE(IDEMPRESA, IDCARRERA, ID, IDCOMPETIDOR, IDCATEGORIA, CHIP) VALUES ");

                                int indice = 0;
                                foreach (DataGridViewRow row in grid.Rows)
                                {
                                    int idCarreraDetalle = Convert.ToInt32(row.Cells[0].Value);
                                    int idCompetidor = Convert.ToInt32(row.Cells[1].Value);
                                    string chip = row.Cells[2].Value.ToString();
                                    int idCategoria = Convert.ToInt32(row.Cells[3].Value);

                                    if (indice != 0)
                                    {
                                        cadena.Append(", ");
                                    }
                                    cadena.AppendLine("(" + IdEmpresa + ", " + idCarrera + ", " + idCarreraDetalle + ", " + idCompetidor + ", " + idCategoria + ",'" + chip + "')");
                                    indice++;
                                }

                                if (!InsertarDetalle(cadena.ToString(), mysqlCon, transaccion))
                                {
                                    MessageBox.Show("Error al guardar carrera favor de comunicarse con administrador");
                                    transaccion.Rollback();
                                }
                                else{
                                    transaccion.Commit();
                                    MessageBox.Show("Carrera guardada correctamente");
                                    InicializarFormularioCarreras();
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        transaccion.Rollback();
                        MessageBox.Show("Error al guardar carrera favor de comunicarse con administrador");
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (mysqlCon != null && mysqlCon.State == ConnectionState.Open)
                    {
                        mysqlCon.Close();
                    }
                }
            }
        }

        private bool EliminarDetalle(int idCarrera, MySqlConnection conexion, MySqlTransaction transaccion)
        {
            bool eliminadoConExito = false;
            try
            {
                string query = "DELETE FROM CARRERASDETALLE WHERE IDEMPRESA =" + IdEmpresa + " AND IDCARRERA = " + idCarrera;
                MySqlCommand cmd = new MySqlCommand(query, conexion, transaccion);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    eliminadoConExito = true;
                }
            }
            catch (Exception)
            {
                
            }

            return eliminadoConExito;
        }

        private bool ActualizarMaestro(int idCarrera, string descripcion, DateTime fecha, string idPais, int idEstado, int idCiudad, MySqlConnection conexion, MySqlTransaction transaccion)
        {
            bool actualizadoConExito = false;
            try
            {

                StringBuilder sentencia = new StringBuilder();
                sentencia.AppendLine(" UPDATE carreras ");
                sentencia.AppendLine(" SET Descripcion = '" + descripcion + "', ");
                sentencia.AppendLine("  FECHA = '" + fecha.ToString("yyyy-MM-yy") + "', ");
                sentencia.AppendLine("  IdPais = '" + idPais + "', ");
                sentencia.AppendLine("  IdEstado = " + idEstado + ", ");
                sentencia.AppendLine("  IdCiudad = " + idCiudad);
                sentencia.AppendLine(" WHERE ");
                sentencia.AppendLine(" 	IdEmpresa = " + IdEmpresa);
                sentencia.AppendLine(" AND IdCarrera = " + idCarrera);
                MySqlCommand cmd = new MySqlCommand(sentencia.ToString(), conexion, transaccion);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    actualizadoConExito = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return actualizadoConExito;
        }
        
        private bool InsertarMaestro(int idCarrera, string descripcion, DateTime fecha, string idPais, int idEstado, int idCiudad, MySqlConnection conexion, MySqlTransaction transaccion)
        {
            bool guardadoConExito = false;
            try
            {

               
                query = "INSERT INTO CARRERAS VALUES (" + IdEmpresa + ", " + idCarrera + ", '" + descripcion + "', '" + fecha.ToString("yyyy-MM-dd") + "', '" + idPais + "', " + idEstado + ", " + idCiudad + ")";
                MySqlCommand cmd = new MySqlCommand(query, conexion, transaccion);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    guardadoConExito = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return guardadoConExito;
        }

        private bool InsertarDetalle(string query, MySqlConnection conexion, MySqlTransaction transaccion)
        {
            bool guardadoConExito = false;
            try
            {

                MySqlCommand cmd = new MySqlCommand(query, conexion, transaccion);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    guardadoConExito = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }

            return guardadoConExito;
        }

        private void btnGuardarCerrarCarrera_Click(object sender, EventArgs e)
        {
            if (ValidarCamposCarrera())
            {
                int idCarrera =  accion == "registrar" ? ObtenerConsecutivo() : Convert.ToInt32(txtIdCarrera.Text);
                string descripcion = txtDescripcionCarrera.Text;
                string fecha = dpFechaCarrera.Text;
                DateTime fechaCarrera = Convert.ToDateTime(fecha);
                string idPais = ((Item)cmbPaisCarrera.SelectedValue).Value.ToString();
                int idEstado = Convert.ToInt32(((Item)cmbEstadoCarrera.SelectedValue).Value);
                int idCiudad = Convert.ToInt32(((Item)cmbCiudadCarrera.SelectedValue).Value);

                connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";

                MySqlTransaction transaccion = null;
                mysqlCon = new MySqlConnection(connectionString);
                mysqlCon.Open();
                transaccion = mysqlCon.BeginTransaction();
                try
                {
                    bool valido = false;

                    if (accion == "modificar")
                    {

                        valido = ((EliminarDetalle(idCarrera, mysqlCon, transaccion) && ActualizarMaestro(idCarrera, descripcion, fechaCarrera, idPais, idEstado, idCiudad, mysqlCon, transaccion)));
                    }
                    else
                    {
                        valido = InsertarMaestro(idCarrera, descripcion, fechaCarrera, idPais, idEstado, idCiudad, mysqlCon, transaccion);
                    }


                    if (valido)
                    {
                        foreach (TabPage tab in TabCategorias.TabPages)
                        {

                            DataGridView grid = (DataGridView)tab.Controls["tablaCarrerasDetalle"];

                            if (grid.Rows.Count > 0)
                            {
                                StringBuilder cadena = new StringBuilder();
                                cadena.AppendLine("INSERT INTO CARRERASDETALLE(IDEMPRESA, IDCARRERA, ID, IDCOMPETIDOR, IDCATEGORIA, CHIP) VALUES ");

                                int indice = 0;
                                foreach (DataGridViewRow row in grid.Rows)
                                {
                                    int idCarreraDetalle = Convert.ToInt32(row.Cells[0].Value);
                                    int idCompetidor = Convert.ToInt32(row.Cells[1].Value);
                                    string chip = row.Cells[2].Value.ToString();
                                    int idCategoria = Convert.ToInt32(row.Cells[3].Value);

                                    if (indice != 0)
                                    {
                                        cadena.Append(", ");
                                    }
                                    cadena.AppendLine("(" + IdEmpresa + ", " + idCarrera + ", " + idCarreraDetalle + ", " + idCompetidor + ", " + idCategoria + ",'" + chip + "')");
                                    indice++;
                                }

                                if (!InsertarDetalle(cadena.ToString(), mysqlCon, transaccion))
                                {
                                    MessageBox.Show("Error al guardar carrera favor de comunicarse con administrador");
                                    transaccion.Rollback();
                                }
                                else
                                {
                                    transaccion.Commit();
                                    MessageBox.Show("Carrera guardada correctamente");
                                    entroGuardarCerrar = true;
                                    this.Close();
                                }
                            }
                        }

                    }
                    else
                    {
                        transaccion.Rollback();
                        MessageBox.Show("Error al guardar carrera favor de comunicarse con administrador");
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (mysqlCon != null && mysqlCon.State == ConnectionState.Open)
                    {
                        mysqlCon.Close();
                    }
                }
            }
        }

        private void btnCancelarCarrera_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VistaCapturaCarreras_Load(object sender, EventArgs e)
        {
            if (accion == "registrar")
            {
                InicializarFormularioCarreras();
            }
            
            AsignarEventos();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Item categoria = ((Item)cmbCategoriaCarrera.SelectedValue);
            if (categoria.Value.ToString() == "" || categoria.Value.ToString() == "0")
            {
                MessageBox.Show("Debe de seleccionar una categoria");
                return;
            }

            string title = categoria.Name;
            TabPage tabCategoria = new TabPage(title);

            if (TabCategorias.TabPages.IndexOfKey(categoria.Value) != -1)
            {
                MessageBox.Show("La categoría seleccionada ya fue agregada, favor de escoger otra");
                return;
            }
            int idCategoria = Convert.ToInt32(categoria.Value);
            TabCategorias.TabPages.Add(categoria.Value, categoria.Name);
            DataGridView grid = CrearDataGridView(idCategoria);
            TabCategorias.TabPages[TabCategorias.TabPages.Count - 1].Controls.Add(grid);

            
            

        }

        private void EliminarCategoria(Object sender, EventArgs e,  TabPage tab)
        {
            DialogResult result = MessageBox.Show("¿Desea eliminar la categoría seleccionada?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                TabCategorias.TabPages.Remove(tab);
            }
        }

        private DataGridView CrearDataGridView(int idCategoria)
        {
            DataGridView grid = new DataGridView();
            grid.Name = "tablaCarrerasDetalle";

            DataGridViewColumn colClave = new DataGridViewTextBoxColumn();
            colClave.HeaderText = "Clave";
            colClave.ReadOnly = true;
            colClave.Width = 80;
            grid.Columns.Add(colClave);
            //grid.Rows[grid.RowCount - 1].Cells[0].Value = grid.RowCount;

            //DataGridViewComboBoxColumn colCompetidor = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn colCompetidor = new DataGridViewTextBoxColumn();
            colCompetidor.HeaderText = "Competidor";
            colCompetidor.Width = 200;
            //colCompetidor.DataSource = LlenarComboCompetidores();
            //colCompetidor.ValueMember = "IdCompetidor";
            //colCompetidor.DisplayMember = "NombreCompleto";
            grid.Columns.Add(colCompetidor);

            DataGridViewColumn colChip = new DataGridViewTextBoxColumn();
            colChip.HeaderText = "Chip";
            colChip.Name = "ColumnaChip";
            colChip.Width = 300;
            grid.Columns.Add(colChip);

            DataGridViewColumn colCategoria = new DataGridViewTextBoxColumn();
            colCategoria.Visible = false;
            grid.Columns.Add(colCategoria);
            //grid.Rows[grid.RowCount - 1].Cells[3].Value = idCategoria;

            DataGridViewColumn colTiempo = new DataGridViewTextBoxColumn();
            colTiempo.HeaderText = "Tiempo";
            colTiempo.Width = 80;
            colTiempo.ReadOnly = true;
            grid.Columns.Add(colTiempo);

            grid.AllowUserToAddRows = false;
            grid.Dock = DockStyle.Fill;
            grid.RowsAdded += grid_RowsAdded;
            grid.EditingControlShowing += grid_EditingControlShowing;
            return grid;
            
        }

        private void AgregarRenglon()
        {
            TabPage tab = TabCategorias.SelectedTab;
            DataGridView grid = (DataGridView)tab.Controls["tablaCarrerasDetalle"];
            int idCategoria = cmbCategoriaCarrera.FindStringExact(tab.Text);
            DataGridViewRow row = new DataGridViewRow();

            string[] rowNuevo = new string[] { (grid.RowCount+1).ToString(), "" , "", idCategoria.ToString(), "" };
            grid.Rows.Add(rowNuevo);

            DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();;
            c.DataSource = LlenarComboCompetidores();
            c.ValueMember = "IdCompetidor";
            c.DisplayMember = "NombreCompleto";

            grid.Rows[grid.RowCount-1].Cells[1] = c;
            
        }

        private void AgregarRenglon(int idCarreraDetalle, int idCompetidor, string chip, int idCategoria, string tiempo)
        {
            TabPage tab = TabCategorias.SelectedTab;
            DataGridView grid = (DataGridView)tab.Controls["tablaCarrerasDetalle"];
            DataGridViewRow row = new DataGridViewRow();

            string[] rowNuevo = new string[] { idCarreraDetalle.ToString(), idCompetidor.ToString(), chip, idCategoria.ToString(), tiempo };
            grid.Rows.Add(rowNuevo);

            DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();

            c.DataSource = LlenarComboCompetidores();
            c.ValueMember = "IdCompetidor";
            c.DisplayMember = "NombreCompleto";
            c.Value = idCompetidor;

            grid.Rows[grid.RowCount - 1].Cells[1] = c;

        }

        void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            gridActual = (DataGridView)sender;
            if (e.Control is ComboBox)
            {
                // remove handler first to avoid attaching twice
                ((ComboBox)e.Control).SelectedIndexChanged -= new EventHandler(ValidarCompetidor);
                ((ComboBox)e.Control).SelectedIndexChanged += new EventHandler(ValidarCompetidor);
            }
        }

        private void ValidarCompetidor(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.SelectedValue != null)
            {
                if (gridActual != null && gridActual.RowCount > 0)
                {
                    foreach (DataGridViewRow row in gridActual.Rows)
                    {
                        if (row.Cells[1].Value != null)
                        {
                            if (row.Cells[1].Value.ToString().Equals(cmb.SelectedValue.ToString()))
                            {
                                MessageBox.Show("Ya se agregó ese competidor");
                                cmb.SelectedIndex = -1;
                                return;
                            }
                        }                        
                    }
                }
            }
            
            
        }

        void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            int indice = e.RowIndex;
            grid.Rows[indice].Cells[0].Value = grid.RowCount;
        }

        private void btnAsignarChip_Click(object sender, EventArgs e)
        {
            if (TabCategorias.TabPages.Count > 0)
            {
                TabPage tab = TabCategorias.SelectedTab;
                foreach (Control control in tab.Controls)
                {
                    if (control.GetType().Name == "DataGridView")
                    {
                        DataGridView grid = (DataGridView)control;
                        if (grid.SelectedCells.Count > 0 && grid.CurrentCell.ColumnIndex == 2)
                        {
                            foreach (DataGridViewRow row in grid.Rows)
                            {
                                if (row.Cells[2].Value != null && row.Cells[2].Value.ToString().Equals(Globales.chipActual))
                                {
                                    MessageBox.Show("Ya hay un competidor agregado con ese chip.");
                                    return;
                                }
                            }
                            grid.CurrentCell.Value = Globales.chipActual;
                        }
                    }
                }

            }
        }

        private void btnAgregarCompetidor_Click(object sender, EventArgs e)
        {
            AgregarRenglon();
        }

        private void TabCategorias_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int x = 0; x < TabCategorias.TabCount; x++)
                {
                    Rectangle rt = TabCategorias.GetTabRect(x);
                    if (e.X > rt.Left && e.X < rt.Right
                    && e.Y > rt.Top && e.Y < rt.Bottom)
                    {
                        TabPage tab = TabCategorias.TabPages[x];
                        ContextMenuStrip contextMenu = new ContextMenuStrip();
                        contextMenu.Items.Add("Eliminar Categoría", null, new EventHandler((s, e2) => EliminarCategoria(s, e2, tab)));
                        contextMenu.Show(this.TabCategorias, e.Location);
                    }
                }
            }
        }

        private void btnCancelarCarrera_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlenarDatosCarrera(int idCarrera)
        {

            connectionString = "SERVER=localhost;DATABASE=inventariofacturacion;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            mysqlCon.Open();
            try
            {
                StringBuilder sentencia = new StringBuilder();
                sentencia.AppendLine("SELECT ");
                sentencia.AppendLine("	A.Descripcion, ");
                sentencia.AppendLine("	A.Fecha, ");
                sentencia.AppendLine("	A.IdPais, ");
                sentencia.AppendLine("	A.IdEstado, ");
                sentencia.AppendLine("	A.IdCiudad, ");
                sentencia.AppendLine("	B.Id, ");
                sentencia.AppendLine("	B.IdCompetidor, ");
                sentencia.AppendLine("	B.IdCategoria, ");
                sentencia.AppendLine("	C.Descripcion as Categoria, ");
                sentencia.AppendLine("	B.Chip, ");
                sentencia.AppendLine("	B.Tiempo ");
                sentencia.AppendLine("FROM ");
                sentencia.AppendLine("	carreras AS A ");
                sentencia.AppendLine("LEFT JOIN carrerasdetalle AS B ON B.IdEmpresa = A.IdEmpresa ");
                sentencia.AppendLine("AND B.IdCarrera = A.IdCarrera ");
                sentencia.AppendLine("LEFT JOIN categorias AS C ON C.IdEmpresa = B.IdEmpresa ");
                sentencia.AppendLine("AND C.IdCategoria = B.IdCategoria ");
                sentencia.AppendLine("WHERE ");
                sentencia.AppendLine("	A.IdEmpresa = " + IdEmpresa);
                sentencia.AppendLine("AND A.IdCarrera = " + idCarrera);

                string query = sentencia.ToString();
                MySqlCommand cmd = new MySqlCommand(query, mysqlCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                int row = 0;
                int idCategoriaAnterior = 0;
                while (reader.Read())
                {
                    int indice = 0;
                    string descripcion = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    DateTime fecha = (reader[indice] is DBNull) ? DateTime.MinValue : reader.GetDateTime(indice); indice++;
                    string idPais = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    int idEstado = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    int idCiudad = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    int idCarreraDetalle = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    int idCompetidor = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    int idCategoria = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    string categoria = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    string chip = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    string tiempo = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;

                    if (row == 0)
                    {
                        txtIdCarrera.Text = idCarrera.ToString();
                        txtDescripcionCarrera.Text = descripcion;
                        dpFechaCarrera.Text = fecha.ToString("dd/MM/yyyy");
                        LlenarComboPaises(idPais);
                        LlenarComboEstados(idPais, idEstado);
                        LlenarComboCiudades(idPais, idEstado, idCiudad);
                        LlenarComboCategorias(idCategoria);
                    }

                    if (idCategoriaAnterior == 0 || idCategoriaAnterior != idCategoria)
                    {
                        TabCategorias.TabPages.Add(idCategoria.ToString(), categoria);
                        DataGridView grid = CrearDataGridView(idCategoria);
                        TabCategorias.TabPages[TabCategorias.TabPages.Count - 1].Controls.Add(grid);
                        idCategoriaAnterior = idCategoria;
                    }
                    else
                    {
                        TabCategorias.TabPages[idCategoria.ToString()].Select();
                    }

                    AgregarRenglon(idCarreraDetalle, idCompetidor, chip, idCategoria, tiempo);
                    row++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (mysqlCon != null && mysqlCon.State == ConnectionState.Open)
                {
                    mysqlCon.Close();
                }
            }
        }

        

    }
}
