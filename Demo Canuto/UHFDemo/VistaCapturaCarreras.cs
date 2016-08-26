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
            VistaDemo.tablaCarreraDetalle = gridCarrerasCompetidores;

        }

        private void AsignarEventos()
        {
            cmbPaisCarrera.SelectedIndexChanged += cmbPaisCarrrera_SelectedIndexChanged;
            cmbEstadoCarrera.SelectedIndexChanged += cmbEstadoCarrera_SelectedIndexChanged;
            this.FormClosing += VistaCapturaCarreras_FormClosing;
            toolStripEliminarCompetidor.Click += toolStripEliminarCompetidor_Click;
        }

        void toolStripEliminarCompetidor_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea eliminar el competidor seleccionado?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow row = gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentCell.RowIndex];
                if (gridCarrerasCompetidores.RowCount == 1 && gridCarrerasCompetidores.CurrentCell.RowIndex == 0)
                {
                    row.Cells[1].Value = "";
                    row.Cells[2].Value = "";
                    row.Cells[3].Value = "";
                    row.Cells[4].Value = "";
                    row.Cells[5].Value = "";
                }
                else
                {
                    gridCarrerasCompetidores.Rows.Remove(row);

                    int indice = 1;
                    foreach (DataGridViewRow renglon in gridCarrerasCompetidores.Rows)
                    {
                        renglon.Cells[0].Value = indice++;
                    }
                }
            }
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
            LlenarComboPaises("");
            LlenarCategorias(0);
            AsignarEventos();
        }

        public void ModificarCarrera(int idCarrera)
        {
            LlenarDatosCarreraCompetidores(idCarrera);
            LlenarDatosCarreraPuntos(idCarrera);
            LlenarCategorias(idCarrera);
            btnGuardarCarrera.Visible = false;
            cmbPaisCarrera.SelectedIndexChanged += cmbPaisCarrrera_SelectedIndexChanged;
            cmbEstadoCarrera.SelectedIndexChanged += cmbEstadoCarrera_SelectedIndexChanged;
            this.FormClosing += VistaCapturaCarreras_FormClosing;
            toolStripEliminarCompetidor.Click += toolStripEliminarCompetidor_Click;
            Globales.capturaCarrera = true;
        }

        private void InicializarFormularioCarreras()
        {
            try
            {
              

                txtIdCarrera.Text = ObtenerConsecutivo().ToString();
                txtDescripcionCarrera.Text = "";
                dpFechaCarrera.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDescripcionCarrera.Focus();

                gridCarrerasCompetidores.Rows.Clear();
                AgregarRenglonCompetidor();

                gridCarrerasPuntos.Rows.Clear();
                AgregarRenglonPunto();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private int ObtenerConsecutivo()
        {
            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
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
            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT IdPais, Descripcion FROM PAISES";
            List<Pais> listaPaises = new List<Pais>();

            try
            {
                cmbPaisCarrera.SelectedIndexChanged -= cmbPaisCarrrera_SelectedIndexChanged;

                mysqlCon.Open();
                MySqlCommand sc = new MySqlCommand(query, mysqlCon);
                MySqlDataReader reader;

                reader = sc.ExecuteReader();
                
                int row = 0;
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
                    listaPaises.Add(new Pais(idPais, descripcion));
                    row++;
                }


                cmbPaisCarrera.DisplayMember = "Descripcion";
                cmbPaisCarrera.ValueMember = "IdPais";
                cmbPaisCarrera.DataSource = listaPaises;
                

                //cmbPaisCarrera.SelectedItem = cmbPaisCarrera.Items[indiceSeleccionado];
                //cmbPaisCarrera.Text = ((Item)cmbPaisCarrera.Items[indiceSeleccionado]).Name;
                cmbPaisCarrera.SelectedIndex = indiceSeleccionado;
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
            string idPais = idPaisParam == "" ? cmbPaisCarrera.SelectedValue.ToString() : idPaisParam;

            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT IdEstado, Descripcion FROM ESTADOS WHERE IDPAIS = '" + idPais + "'";
            List<Estado> listaEstados = new List<Estado>();

            try
            {

                cmbEstadoCarrera.SelectedIndexChanged -= cmbEstadoCarrera_SelectedIndexChanged;
                mysqlCon.Open();
                MySqlCommand sc = new MySqlCommand(query, mysqlCon);
                MySqlDataReader reader;

                reader = sc.ExecuteReader();
                int row = 0;
                int indiceSeleccionado = -1;
                while (reader.Read())
                {
                    int indice = 0;
                    int idEstado = (reader[indice] is DBNull) ? 9 : reader.GetInt32(indice); indice++;
                    string descripcion = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    if (idEstado == idEstadoParam)
                    {
                        indiceSeleccionado = row;
                    }
                    listaEstados.Add(new Estado(idPais, idEstado, descripcion));
                    row++;
                }

                cmbEstadoCarrera.DisplayMember = "Descripcion";
                cmbEstadoCarrera.ValueMember = "IdEstado";
                cmbEstadoCarrera.DataSource = listaEstados;
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
            
            string idPais = idPaisParam == "" ? cmbPaisCarrera.SelectedValue.ToString() : idPaisParam;
            int idEstado = idEstadoParam == 0 ? Convert.ToInt32(cmbEstadoCarrera.SelectedValue) : idEstadoParam;

            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT IdCiudad, Descripcion FROM CIUDADES WHERE IDPAIS = '" + idPais + "' AND IDESTADO =" + idEstado;

            List<Ciudad> listaCiudades = new List<Ciudad>();
            try
            {
                mysqlCon.Open();
                
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

                cmbCiudadCarrera.DisplayMember = "Descripcion";
                cmbCiudadCarrera.ValueMember = "IdCiudad";
                cmbCiudadCarrera.DataSource = listaCiudades;
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

        private void LlenarCategorias(int idCarrera)
        {

            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            StringBuilder sentencia = new StringBuilder();
            sentencia.AppendLine("SELECT ");
            sentencia.AppendLine("	A.IDCATEGORIA,  ");
            sentencia.AppendLine("	A.DESCRIPCION,  ");
            sentencia.AppendLine("	if(B.IDCARRERA IS NULL, 'No', 'Si') AS SELECCIONADO ");
            sentencia.AppendLine("FROM ");
            sentencia.AppendLine("	CATEGORIAS AS A ");
            sentencia.AppendLine("LEFT JOIN ");
            sentencia.AppendLine("	CARRERASCATEGORIAS AS B ");
            sentencia.AppendLine("ON 	B.IDEMPRESA = A.IDEMPRESA ");
            sentencia.AppendLine("AND B.IDCARRERA = " + idCarrera);
            sentencia.AppendLine("AND B.IDCATEGORIA = A.IDCATEGORIA ");
            sentencia.AppendLine("WHERE A.IDEMPRESA = " + IdEmpresa);
            
            try
            {
                mysqlCon.Open();
                List<Item> lista = new List<Item>();
                MySqlCommand sc = new MySqlCommand(sentencia.ToString(), mysqlCon);
                MySqlDataReader reader;
                chkListCategorias.Items.Clear();

                reader = sc.ExecuteReader();

                while (reader.Read())
                {
                    int indice = 0;
                    int idCategoria = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    string descripcion = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    string seleccionado = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    
                    Item item = new Item(descripcion, idCategoria);
                    chkListCategorias.Items.Add(item, seleccionado == "Si");

                }


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

        private DataTable LlenarComboCategorias()
        {
            query = "SELECT IdCategoria, Descripcion FROM CATEGORIAS WHERE IDEMPRESA=" + IdEmpresa;
            return Populate(query);
        }

        private DataTable LlenarComboCompetidores()
        {
            query = "SELECT IdCompetidor, CONCAT(ApellidoPaterno, ' ', ApellidoMaterno, ' ' , Nombre) as NombreCompleto FROM COMPETIDORES WHERE IDEMPRESA=" + IdEmpresa;
            return Populate(query);
        }

        private DataTable LlenarComboDistanciasCarrera()
        {
            query = "SELECT IdDistancia, Descripcion FROM DISTANCIASCARRERA WHERE IDEMPRESA=" + IdEmpresa;
            return Populate(query);
        }

        private DataTable LlenarComboPuntos()
        {
            query = "SELECT IdPunto, Descripcion FROM PUNTOS WHERE IDEMPRESA=" + IdEmpresa;
            return Populate(query);
        }

        private DataTable Populate(string sqlCommand)
        {
            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
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
                if (mySqlCon != null && mysqlCon.State == ConnectionState.Open)
                {
                    mysqlCon.Close();
                }
            }
           
            return table;
        }

        private bool ValidarCamposCarrera()
        {
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
            else if (cmbPaisCarrera.Items.Count == 0 || cmbPaisCarrera.SelectedValue == "")
            {
                MessageBox.Show("Debe de seleccionar un país");
                return false;
            }
            else if (cmbEstadoCarrera.Items.Count == 0 || cmbEstadoCarrera.SelectedValue == null || cmbEstadoCarrera.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe de seleccionar un estado");
                return false;
            }
            else if (cmbCiudadCarrera.Items.Count == 0 || cmbCiudadCarrera.SelectedValue == null || cmbCiudadCarrera.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe de seleccionar una ciudad");
                return false;
            }

            if (chkListCategorias.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe de seleccionar por lo menos una categoría");
                return false;
            }

            if (gridCarrerasCompetidores.RowCount == 0)
            {
                MessageBox.Show("Debe de capturar por lo menos un competidor");
                return false;
            }
            else
            {
                if (!ValidarCompetidores())
                {
                    return false;
                }
            }

            if (gridCarrerasPuntos.RowCount == 0)
            {
                MessageBox.Show("Debe de capturar por lo menos un punto");
                return false;
            }
            else
            {
                if (!ValidarPuntos())
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidarCompetidores()
        {
            foreach (DataGridViewRow row in gridCarrerasCompetidores.Rows)
            {
                if ((row.Cells[1].Value == null || row.Cells[1].Value.ToString() == "") &&
                    (row.Cells[2].Value == null || row.Cells[2].Value.ToString() == ""))
                {
                    MessageBox.Show("Debe de capturar el competidor en el renglon " + row.Index + 1);
                    return false;
                }
                else if ((row.Cells[3].Value == null || row.Cells[3].Value.ToString() == "") &&
                    (row.Cells[4].Value == null || row.Cells[4].Value.ToString() == ""))
                {
                    MessageBox.Show("Debe de capturar la categoría del corredor en el renglon " + row.Index + 1);
                    return false;
                }
                else if ((row.Cells[5].Value == null || row.Cells[5].Value.ToString() == "") &&
                         (row.Cells[6].Value == null || row.Cells[6].Value.ToString() == ""))
                {
                    MessageBox.Show("Debe de capturar la categoría del corredor en el renglon " + row.Index + 1);
                    return false;
                }
                else if ((row.Cells[7].Value == null || row.Cells[7].Value.ToString() == ""))
                {
                    MessageBox.Show("Debe de capturar la rama del corredor en el renglon " + row.Index + 1);
                    return false;
                }
                else if ((row.Cells[8].Value == null || row.Cells[8].Value.ToString() == ""))
                {
                    MessageBox.Show("Debe de capturar el chip del corredor en el renglon " + row.Index + 1);
                    return false;
                }
            }

            return true;
        }

        private bool ValidarPuntos()
        {
            foreach (DataGridViewRow row in gridCarrerasPuntos.Rows)
            {
                if ((row.Cells[0].Value == null || row.Cells[0].Value.ToString() == "") &&
                    (row.Cells[1].Value == null || row.Cells[1].Value.ToString() == ""))
                {
                    MessageBox.Show("Existen un punto sin capturar en el renglon " + row.Index + 1);
                    return false;
                }
                else if ((row.Cells[2].Value == null || row.Cells[2].Value.ToString() == ""))
                {
                    MessageBox.Show("Debe de capturar el intervalor del punto en el renglon " + row.Index + 1);
                    return false;
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
                string idPais = cmbPaisCarrera.SelectedValue.ToString();
                int idEstado = Convert.ToInt32(cmbEstadoCarrera.SelectedValue);
                int idCiudad = Convert.ToInt32(cmbCiudadCarrera.SelectedValue);
                
                connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";

                MySqlTransaction transaccion = null;
                mysqlCon = new MySqlConnection(connectionString);
                mysqlCon.Open();
                transaccion = mysqlCon.BeginTransaction();
                try
                {

                    if (InsertarMaestro(idCarrera, descripcion, fechaCarrera, idPais, idEstado, idCiudad, mysqlCon, transaccion))
                    {
                        StringBuilder cadenaCompetidores = new StringBuilder();
                        cadenaCompetidores.AppendLine("INSERT INTO CARRERASDETALLE(IDEMPRESA, IDCARRERA, ID, IDCOMPETIDOR, IDDISTANCIA, IDCATEGORIA, CHIP, RAMA) VALUES ");

                        int indice = 0;
                        foreach (DataGridViewRow row in gridCarrerasCompetidores.Rows)
                        {
                            int idCarreraDetalle = Convert.ToInt32(row.Cells[0].Value);
                            int idCompetidor = Convert.ToInt32(row.Cells[1].Value);
                            int idDistancia = Convert.ToInt32(row.Cells[3].Value);
                            int idCategoria = Convert.ToInt32(row.Cells[5].Value);
                            string rama = row.Cells[7].Value.ToString();
                            string chip = row.Cells[8].Value.ToString();


                            if (indice != 0)
                            {
                                cadenaCompetidores.Append(", ");
                            }
                            cadenaCompetidores.AppendLine("(" + IdEmpresa + ", " + idCarrera + ", " + idCarreraDetalle + ", " + idCompetidor + ", " + idDistancia + ", " + idCategoria + ",'" + chip + "', '" + rama + "')");
                            indice++;
                        }

                        StringBuilder cadenaPuntos = new StringBuilder();
                        cadenaPuntos.AppendLine("INSERT INTO CARRERASPUNTOS(IDEMPRESA, IDCARRERA, IDPUNTO, INTERVALO) VALUES ");

                        indice = 0;
                        foreach (DataGridViewRow row in gridCarrerasPuntos.Rows)
                        {
                            int idPunto = Convert.ToInt32(row.Cells[0].Value);
                            double intervalo = Convert.ToDouble(row.Cells[2].Value);

                            if (indice != 0)
                            {
                                cadenaPuntos.Append(", ");
                            }

                            cadenaPuntos.AppendLine("(" + IdEmpresa + "," + idCarrera + ", " + idPunto + ", " + intervalo + ")");
                            indice++;
                        }

                        StringBuilder cadenaCategorias = new StringBuilder();
                        cadenaCategorias.AppendLine("INSERT INTO CARRERASCATEGORIAS(IDEMPRESA, IDCARRERA, IDCATEGORIA) VALUES ");

                        indice = 0;
                        foreach(Item item in chkListCategorias.CheckedItems)
                        {
                            int idCategoria = Convert.ToInt32(item.Value);

                            if (indice != 0)
                            {
                                cadenaCategorias.Append(", ");
                            }

                            cadenaCategorias.AppendLine("(" + IdEmpresa + ", " + idCarrera + ", " + idCategoria + ")");
                            indice++;
                        }

                        if (!InsertarDetalle(cadenaCompetidores.ToString(), mysqlCon, transaccion))
                        {
                            MessageBox.Show("Error al guardar carrera favor de comunicarse con administrador");
                            transaccion.Rollback();
                        }
                        else if (!InsertarDetalle(cadenaPuntos.ToString(), mysqlCon, transaccion))
                        {
                            MessageBox.Show("Error al guardar carrera favor de comunicarse con administrador");
                            transaccion.Rollback();
                        }
                        else if (!InsertarDetalle(cadenaCategorias.ToString(), mysqlCon, transaccion))
                        {
                            MessageBox.Show("Error al guardar carrera favor de comunicarse con administrador");
                            transaccion.Rollback();
                        }
                        else
                        {
                            transaccion.Commit();
                            MessageBox.Show("Carrera guardada correctamente");
                            InicializarFormularioCarreras();
                            VistaDemo.LlenarComboCarreras();
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

        private bool EliminarDetalles(int idCarrera, MySqlConnection conexion, MySqlTransaction transaccion)
        {
            bool eliminadoConExitoDetalle = false;
            bool eliminadoConExitoPunto = false;
            bool eliminadoConExitoCategoria = false;
            try
            {
                string query = "DELETE FROM CARRERASDETALLE WHERE IDEMPRESA =" + IdEmpresa + " AND IDCARRERA = " + idCarrera;
                MySqlCommand cmd = new MySqlCommand(query, conexion, transaccion);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    eliminadoConExitoDetalle = true;
                }

                string query2 = "DELETE FROM carreraspuntos WHERE IDEMPRESA =" + IdEmpresa + " AND IDCARRERA = " + idCarrera;
                MySqlCommand cmd2 = new MySqlCommand(query2, conexion, transaccion);

                if (cmd2.ExecuteNonQuery() > 0)
                {
                    eliminadoConExitoPunto = true;
                }

                string query3 = "DELETE FROM CARRERASCATEGORIAS WHERE IDEMPRESA =" + IdEmpresa + " AND IDCARRERA = " + idCarrera;
                MySqlCommand cmd3 = new MySqlCommand(query3, conexion, transaccion);

                if (cmd3.ExecuteNonQuery() > 0)
                {
                    eliminadoConExitoCategoria = true;
                }
            }
            catch (Exception)
            {
                
            }

            return (eliminadoConExitoDetalle && eliminadoConExitoPunto && eliminadoConExitoCategoria);
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

               
                query = "INSERT INTO CARRERAS(IDEMPRESA, IDCARRERA, DESCRIPCION, FECHA, IDPAIS, IDESTADO, IDCIUDAD) VALUES (" + IdEmpresa + ", " + idCarrera + ", '" + descripcion + "', '" + fecha.ToString("yyyy-MM-dd") + "', '" + idPais + "', " + idEstado + ", " + idCiudad + ")";
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
                string idPais = cmbPaisCarrera.SelectedValue.ToString();
                int idEstado = Convert.ToInt32(cmbEstadoCarrera.SelectedValue);
                int idCiudad = Convert.ToInt32(cmbCiudadCarrera.SelectedValue);

                connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";

                MySqlTransaction transaccion = null;
                mysqlCon = new MySqlConnection(connectionString);
                mysqlCon.Open();
                transaccion = mysqlCon.BeginTransaction();
                try
                {
                    bool valido = false;

                    if (accion == "modificar")
                    {

                        valido = ((EliminarDetalles(idCarrera, mysqlCon, transaccion) && ActualizarMaestro(idCarrera, descripcion, fechaCarrera, idPais, idEstado, idCiudad, mysqlCon, transaccion)));
                    }
                    else
                    {
                        valido = InsertarMaestro(idCarrera, descripcion, fechaCarrera, idPais, idEstado, idCiudad, mysqlCon, transaccion);
                    }


                    if (valido)
                    {
                        StringBuilder cadenaCompetidores = new StringBuilder();
                        cadenaCompetidores.AppendLine("INSERT INTO CARRERASDETALLE(IDEMPRESA, IDCARRERA, ID, IDCOMPETIDOR, IDDISTANCIA, IDCATEGORIA, CHIP, RAMA) VALUES ");

                        int indice = 0;
                        foreach (DataGridViewRow row in gridCarrerasCompetidores.Rows)
                        {
                            int idCarreraDetalle = Convert.ToInt32(row.Cells[0].Value);
                            int idCompetidor = Convert.ToInt32(row.Cells[1].Value);
                            int idDistancia = Convert.ToInt32(row.Cells[3].Value);
                            int idCategoria = Convert.ToInt32(row.Cells[5].Value);
                            string rama = row.Cells[7].Value.ToString();
                            string chip = row.Cells[8].Value.ToString();


                            if (indice != 0)
                            {
                                cadenaCompetidores.Append(", ");
                            }
                            cadenaCompetidores.AppendLine("(" + IdEmpresa + ", " + idCarrera + ", " + idCarreraDetalle + ", " + idCompetidor + ", " + idDistancia + ", " + idCategoria + ",'" + chip + "', '" + rama + "')");
                            indice++;
                        }

                        StringBuilder cadenaPuntos = new StringBuilder();
                        cadenaPuntos.AppendLine("INSERT INTO CARRERASPUNTOS(IDEMPRESA, IDCARRERA, IDPUNTO, INTERVALO) VALUES ");

                        indice = 0;
                        foreach (DataGridViewRow row in gridCarrerasPuntos.Rows)
                        {
                            int idPunto = Convert.ToInt32(row.Cells[0].Value);
                            double intervalo = Convert.ToDouble(row.Cells[2].Value);

                            if (indice != 0)
                            {
                                cadenaPuntos.Append(", ");
                            }

                            cadenaPuntos.AppendLine("(" + IdEmpresa + "," + idCarrera + ", " + idPunto + ", " + intervalo + ")");
                            indice++;
                        }

                        StringBuilder cadenaCategorias = new StringBuilder();
                        cadenaCategorias.AppendLine("INSERT INTO CARRERASCATEGORIAS(IDEMPRESA, IDCARRERA, IDCATEGORIA) VALUES ");

                        indice = 0;
                        foreach (Item item in chkListCategorias.CheckedItems)
                        {
                            int idCategoria = Convert.ToInt32(item.Value);

                            if (indice != 0)
                            {
                                cadenaCategorias.Append(", ");
                            }

                            cadenaCategorias.AppendLine("(" + IdEmpresa + ", " + idCarrera + ", " + idCategoria + ")");
                            indice++;
                        }

                        if (!InsertarDetalle(cadenaCompetidores.ToString(), mysqlCon, transaccion))
                        {
                            MessageBox.Show("Error al guardar carrera favor de comunicarse con administrador");
                            transaccion.Rollback();
                        }
                        else if (!InsertarDetalle(cadenaPuntos.ToString(), mysqlCon, transaccion))
                        {
                            MessageBox.Show("Error al guardar carrera favor de comunicarse con administrador");
                            transaccion.Rollback();
                        }
                        else if (!InsertarDetalle(cadenaCategorias.ToString(), mysqlCon, transaccion))
                        {
                            MessageBox.Show("Error al guardar carrera favor de comunicarse con administrador");
                            transaccion.Rollback();
                        }
                        else
                        {
                            transaccion.Commit();
                            MessageBox.Show("Carrera guardada correctamente");
                            entroGuardarCerrar = true;
                            VistaDemo.LlenarComboCarreras();
                            this.Close();
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
            cmbCompetidores.DataSource = LlenarComboCompetidores();
            cmbCompetidores.DisplayMember = "NombreCompleto";
            cmbCompetidores.ValueMember = "IdCompetidor";

            cmbCategorias.DataSource = LlenarComboCategorias();
            cmbCategorias.DisplayMember = "Descripcion";
            cmbCategorias.ValueMember = "IdCategoria";

            cmbDistanciasCarrera.DataSource = LlenarComboDistanciasCarrera();
            cmbDistanciasCarrera.DisplayMember = "Descripcion";
            cmbDistanciasCarrera.ValueMember = "IdDistancia";

            cmbPuntos.DataSource = LlenarComboPuntos();
            cmbPuntos.DisplayMember = "Descripcion";
            cmbPuntos.ValueMember = "IdPunto";
           
        }

        private void AgregarRenglonCompetidor()
        {
            DataGridViewRow row = new DataGridViewRow();

            string[] rowNuevo = new string[] { (gridCarrerasCompetidores.RowCount + 1).ToString(), "", "", "", "", "", "", "" };
            gridCarrerasCompetidores.Rows.Add(rowNuevo);

            gridCarrerasCompetidores.CurrentCell = gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.RowCount - 1].Cells[2];
            
        }

        private void AgregarRenglonPunto()
        {
            DataGridViewRow row = new DataGridViewRow();

            string[] rowNuevo = new string[] {"", "", ""};
            gridCarrerasPuntos.Rows.Add(rowNuevo);
            gridCarrerasPuntos.CurrentCell = gridCarrerasPuntos.Rows[gridCarrerasPuntos.RowCount - 1].Cells[1];

        }

        private void AgregarRenglonCompetidor(int idCarreraDetalle, int idCompetidor, string competidor, int idDistancia, string distancia, int idCategoria, string categoria, string rama, string chip)
        {   
            DataGridViewRow row = new DataGridViewRow();

            string[] rowNuevo = new string[] { idCarreraDetalle.ToString(), idCompetidor.ToString(), competidor, idDistancia.ToString(), distancia, idCategoria.ToString(), categoria, rama, chip};
            gridCarrerasCompetidores.Rows.Add(rowNuevo);
            gridCarrerasCompetidores.CurrentCell = gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.RowCount - 1].Cells[2];
        }

        private void AgregarRenglonPunto(int idPunto, string punto, double intervalo)
        {
            DataGridViewRow row = new DataGridViewRow();

            string[] rowNuevo = new string[] { idPunto.ToString(), punto, intervalo.ToString()};
            gridCarrerasPuntos.Rows.Add(rowNuevo);
            gridCarrerasPuntos.CurrentCell = gridCarrerasPuntos.Rows[gridCarrerasPuntos.RowCount - 1].Cells[1];
        }

        void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            int indice = e.RowIndex;
            grid.Rows[indice].Cells[0].Value = grid.RowCount;
        }

        public void AsignarChip()
        {
            foreach (DataGridViewRow row in gridCarrerasCompetidores.Rows)
            {
                if (row.Index != gridCarrerasCompetidores.CurrentCell.RowIndex)
                {
                    if (row.Cells[6].Value != null && row.Cells[6].Value.ToString().Equals(Globales.chipActual))
                    {
                        MessageBox.Show("Ya existe otro competidor con el mismo chip");
                        return;
                    }
                }
            }
            if (gridCarrerasCompetidores.CurrentCell != null)
            {
                gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentCell.RowIndex].Cells[6].Value = Globales.chipActual;
            }
            
        }

        public void btnAsignarChip_Click(object sender, EventArgs e)
        {
            if (TabCarrerasDetalle.TabPages.Count > 0)
            {
                TabPage tab = TabCarrerasDetalle.SelectedTab;
                foreach (Control control in tab.Controls)
                {
                    if (control.GetType().Name == "DataGridView" && control.Name == "gridCarrerasCompetidores")
                    {
                        DataGridView grid = (DataGridView)control;
                        if (grid.SelectedCells.Count > 0 && grid.CurrentCell != null)
                        {
                            foreach (DataGridViewRow row in grid.Rows)
                            {
                                if (row.Index != grid.CurrentCell.RowIndex)
                                {
                                    if (row.Cells[6].Value != null && row.Cells[6].Value.ToString().Equals(Globales.chipActual))
                                    {
                                        MessageBox.Show("Ya hay un competidor agregado con ese chip.");
                                        return;
                                    }
                                }
                                
                            }
                            gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentCell.RowIndex].Cells[6].Value = Globales.chipActual;
                        }
                    }
                }

            }
        }

        private void btnAgregarCompetidor_Click(object sender, EventArgs e)
        {
            if (chkListCategorias.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe de seleccionar por lo menos una categoría.");
                return;
            }

            AgregarRenglonCompetidor();
        }

        private void TabCategorias_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int x = 0; x < TabCarrerasDetalle.TabCount; x++)
                {
                    Rectangle rt = TabCarrerasDetalle.GetTabRect(x);
                    if (e.X > rt.Left && e.X < rt.Right
                    && e.Y > rt.Top && e.Y < rt.Bottom)
                    {
                        TabPage tab = TabCarrerasDetalle.TabPages[x];
                        ContextMenuStrip contextMenu = new ContextMenuStrip();
                        //contextMenu.Items.Add("Eliminar Categoría", null, new EventHandler((s, e2) => EliminarCategoria(s, e2, tab)));
                        contextMenu.Show(this.TabCarrerasDetalle, e.Location);
                    }
                }
            }
        }

        private void btnCancelarCarrera_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlenarDatosCarreraPuntos(int idCarrera)
        {
            mysqlCon = new MySqlConnection(connectionString);
            try
            {
                mysqlCon.Open();
                StringBuilder sentencia = new StringBuilder();
                sentencia.AppendLine("SELECT ");
                sentencia.AppendLine("	A.IDPUNTO, ");
                sentencia.AppendLine("	B.DESCRIPCION, ");
                sentencia.AppendLine("	A.INTERVALO ");
                sentencia.AppendLine("FROM ");
                sentencia.AppendLine("	CARRERASPUNTOS AS A ");
                sentencia.AppendLine("LEFT JOIN ");
                sentencia.AppendLine("	PUNTOS B ");
                sentencia.AppendLine("ON	B.IDEMPRESA = A.IDEMPRESA ");
                sentencia.AppendLine("AND B.IDPUNTO = A.IDPUNTO ");
                sentencia.AppendLine("WHERE ");
                sentencia.AppendLine("	A.IDEMPRESA = "+ IdEmpresa);
                sentencia.AppendLine("AND A.IdCarrera = " + idCarrera);

                MySqlCommand cmd = new MySqlCommand(sentencia.ToString(), mysqlCon);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int indice = 0;
                    int idPunto = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    string punto = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    double intervalo = (reader[indice] is DBNull) ? 0 : reader.GetDouble(indice); indice++;

                    AgregarRenglonPunto(idPunto, punto, intervalo);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void LlenarDatosCarreraCompetidores(int idCarrera)
        {

            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
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
                sentencia.AppendLine("	CONCAT(D.ApellidoPaterno, ' ', D.ApellidoMaterno, ' ', D.Nombre) as NombreCompleto , ");
                sentencia.AppendLine("	B.IdDistancia, ");
                sentencia.AppendLine("	E.Descripcion, ");
                sentencia.AppendLine("	B.IdCategoria, ");
                sentencia.AppendLine("	C.Descripcion as Categoria, ");
                sentencia.AppendLine("	B.Chip, ");
                sentencia.AppendLine("	B.Rama ");
                sentencia.AppendLine("FROM ");
                sentencia.AppendLine("	carreras AS A ");
                sentencia.AppendLine("LEFT JOIN carrerasdetalle AS B ON B.IdEmpresa = A.IdEmpresa ");
                sentencia.AppendLine("AND B.IdCarrera = A.IdCarrera ");
                sentencia.AppendLine("LEFT JOIN categorias AS C ON C.IdEmpresa = B.IdEmpresa ");
                sentencia.AppendLine("AND C.IdCategoria = B.IdCategoria ");
                sentencia.AppendLine("LEFT JOIN competidores AS D ON D.IdEmpresa = B.IdEmpresa ");
                sentencia.AppendLine("AND D.IdCompetidor = B.IdCompetidor ");
                sentencia.AppendLine("LEFT JOIN distanciascarrera AS E ON E.IdEmpresa = B.IdEmpresa ");
                sentencia.AppendLine("AND E.IdDistancia = B.IdDistancia ");
                sentencia.AppendLine("WHERE ");
                sentencia.AppendLine("	A.IdEmpresa = " + IdEmpresa);
                sentencia.AppendLine("AND A.IdCarrera = " + idCarrera);

                string query = sentencia.ToString();
                MySqlCommand cmd = new MySqlCommand(query, mysqlCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                int row = 0;

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
                    string competidor = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    int idDistancia = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    string distancia = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    int idCategoria = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    string categoria = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    string chip = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    string rama = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;

                    if (row == 0)
                    {
                        txtIdCarrera.Text = idCarrera.ToString();
                        txtDescripcionCarrera.Text = descripcion;
                        dpFechaCarrera.Text = fecha.ToString("dd/MM/yyyy");
                        LlenarComboPaises(idPais);
                        LlenarComboEstados(idPais, idEstado);
                        LlenarComboCiudades(idPais, idEstado, idCiudad);
                        LlenarCategorias(idCarrera);
                    }

                   
                    AgregarRenglonCompetidor(idCarreraDetalle, idCompetidor, competidor, idDistancia, distancia, idCategoria, categoria, rama, chip);
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

        private void dpFechaCarrera_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}");
        }

        private void gridCarrerasCompetidores_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1); //Make sure the clicked row/column is valid.
            var datagridview = sender as DataGridView;

            // Check to make sure the cell clicked is the cell containing the combobox 
            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }

        public int ObtenerSiguienteColumnaVisibleCompetidores(int indiceInicial)
        {
            // Number of visible columns.
            int indiceFinal = 0;
            for (int i = ++indiceInicial; i < gridCarrerasCompetidores.Columns.Count; i++)
            {
                if (gridCarrerasCompetidores[i, gridCarrerasCompetidores.CurrentCell.RowIndex].Visible)
                {
                    indiceFinal = i;
                    break;
                }
            }

            return indiceFinal;
        }

        public int ObtenerSiguienteColumnaVisiblePuntos(int indiceInicial)
        {
            // Number of visible columns.
            int indiceFinal = 0;
            for (int i = ++indiceInicial; i < gridCarrerasPuntos.Columns.Count; i++)
            {
                if (gridCarrerasPuntos[i, gridCarrerasPuntos.CurrentCell.RowIndex].Visible)
                {
                    indiceFinal = i;
                    break;
                }
            }

            return indiceFinal;
        }

        private bool ValidarCompetidorRepetido(string idCompetidor, string competidor)
        {
            foreach (DataGridViewRow row in gridCarrerasCompetidores.Rows)
            {
                if (row.Index != gridCarrerasCompetidores.CurrentCell.RowIndex)
                {
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "" && row.Cells[1].Value.ToString().Equals(idCompetidor) && 
                        row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "" && row.Cells[2].Value.ToString().Equals(competidor))
                    {
                        MessageBox.Show("Ya se encuentra registrado el competidor seleccionado");
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ValidarPuntoRepetido(string idPunto, string punto)
        {
            foreach (DataGridViewRow row in gridCarrerasPuntos.Rows)
            {
                if (row.Index != gridCarrerasPuntos.CurrentCell.RowIndex)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "" && row.Cells[0].Value.ToString().Equals(idPunto) &&
                        row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "" && row.Cells[1].Value.ToString().Equals(punto))
                    {
                        MessageBox.Show("Ya se encuentra registrado el punto seleccionado");
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ObtenerDatosAdicionales(string idCompetidor)
        {
            string categorias = "";
            if (chkListCategorias.CheckedItems.Count > 0)
            {
                foreach (Item item in chkListCategorias.CheckedItems)
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
                mysqlCon = new MySqlConnection(connectionString);
                mysqlCon.Open();

                StringBuilder sentencia = new StringBuilder();
                sentencia.AppendLine("SELECT ");
                sentencia.AppendLine("	A.IDCATEGORIA, ");
                sentencia.AppendLine("	A.DESCRIPCION, ");
                sentencia.AppendLine("	CASE ");
                sentencia.AppendLine("		WHEN (SELECT GENERO FROM COMPETIDORES WHERE IDEMPRESA = " + IdEmpresa + " AND IDCOMPETIDOR = " + idCompetidor + ") = 'Masculino' ");
                sentencia.AppendLine("		THEN 'Varonil' ");
                sentencia.AppendLine("		ELSE 'Femenil' ");
                sentencia.AppendLine("	END AS RAMA ");
                sentencia.AppendLine("FROM ");
                sentencia.AppendLine("	CATEGORIAS AS A ");
                sentencia.AppendLine("WHERE ");
                sentencia.AppendLine("	( ");
                sentencia.AppendLine("		SELECT ");
                sentencia.AppendLine("			TIMESTAMPDIFF( ");
                sentencia.AppendLine("				YEAR, ");
                sentencia.AppendLine("				(FECHANACIMIENTO), ");
                sentencia.AppendLine("				NOW() ");
                sentencia.AppendLine("			) AS EDAD ");
                sentencia.AppendLine("		FROM ");
                sentencia.AppendLine("			COMPETIDORES ");
                sentencia.AppendLine("		WHERE ");
                sentencia.AppendLine("			IDEMPRESA = " + IdEmpresa);
                sentencia.AppendLine("		AND IDCOMPETIDOR = " + idCompetidor);
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
                    rama = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                }

                if (idCategoria == 0)
                {
                    MessageBox.Show("No se encontró una categoría para el competidor");
                    DataGridViewRow row = gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentCell.RowIndex];
                    row.Cells[1].Value = "";
                    row.Cells[2].Value = "";
                    row.Cells[3].Value = "";
                    row.Cells[4].Value = "";
                    row.Cells[5].Value = "";
                    row.Cells[6].Value = "";
                    row.Cells[7].Value = "";
                    return false;
                }
                else
                {
                    DataGridViewRow row = gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentCell.RowIndex];
                    row.Cells[5].Value = idCategoria;
                    row.Cells[6].Value = categoria;
                    row.Cells[7].Value = rama;
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

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, 
            System.Windows.Forms.Keys keyData)
        {
            if (ActiveControl.Name == "txtIdCarrera" || ActiveControl.Name == "txtDescripcionCarrera" || ActiveControl.Name == "dpFechaCarrera"
                || ActiveControl.Name == "cmbPaisCarrera" || ActiveControl.Name == "cmbEstadoCarrera" || ActiveControl.Name == "cmbCiudadCarrera" || ActiveControl.Name == "chkListCategorias")
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            if (keyData == Keys.Enter)
            {
                // ON ENTER KEY, GO TO THE NEXT CELL. 
                // WHEN THE CURSOR REACHES THE LAST COLUMN, CARRY IT ON TO THE NEXT ROW.
                if (TabCarrerasDetalle.SelectedIndex == 0)
                {
                    if (gridCarrerasCompetidores.CurrentCell.ColumnIndex == 2)
                    {
                        if (ActiveControl.Name == "cmbCompetidores")
                        {
                            cmbCompetidores.Visible = false;

                            gridCarrerasCompetidores.Focus();

                            string idCompetidor = "";
                            string competidor = "";
                            if (cmbCompetidores.SelectedIndex != -1)
                            {
                                idCompetidor = cmbCompetidores.SelectedValue.ToString();
                                competidor = cmbCompetidores.Text;
                            }
                            else
                            {
                                idCompetidor = "";
                                competidor = "";
                            }
                            // ONCE THE COMBO IS SET AS INVISIBLE, SET FOCUS BACK TO THE GRID. (IMPORTANT)
                            gridCarrerasCompetidores[gridCarrerasCompetidores.CurrentCell.ColumnIndex,
                                gridCarrerasCompetidores.CurrentRow.Index].Value = competidor;

                            gridCarrerasCompetidores[1, gridCarrerasCompetidores.CurrentRow.Index].Value = idCompetidor;

                            if (!string.IsNullOrEmpty(idCompetidor))
                            {
                                if (ValidarCompetidorRepetido(idCompetidor, competidor) && chkListCategorias.CheckedItems.Count > 0)
                                {
                                    if (ObtenerDatosAdicionales(idCompetidor))
                                    {
                                        int indiceFinal = ObtenerSiguienteColumnaVisibleCompetidores(2);
                                        if (indiceFinal != 0)
                                        {
                                            gridCarrerasCompetidores.CurrentCell =
                                            gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentRow.Index]
                                                .Cells[indiceFinal];
                                        }
                                    }
                                }
                                else
                                {
                                    gridCarrerasCompetidores[gridCarrerasCompetidores.CurrentCell.ColumnIndex,
                                    gridCarrerasCompetidores.CurrentRow.Index].Value = "";

                                    gridCarrerasCompetidores[1, gridCarrerasCompetidores.CurrentRow.Index].Value = "";

                                    if (chkListCategorias.CheckedItems.Count == 0)
                                    {
                                        MessageBox.Show("Debe de seleccionar por lo menos una categoria");
                                    }
                                }
                            }
                        }
                        else
                        {
                            // SHOW COMBOBOX.
                            Show_Combobox(gridCarrerasCompetidores.CurrentRow.Index,
                                gridCarrerasCompetidores.CurrentCell.ColumnIndex, "competidor");

                            SendKeys.Send("{F4}");      // DROP DOWN THE LIST.
                            return true;

                        }
                    }
                    else if (gridCarrerasCompetidores.CurrentCell.ColumnIndex == 4)
                    {
                        if (ActiveControl.Name == "cmbDistanciasCarrera")
                        {
                            cmbDistanciasCarrera.Visible = false;

                            gridCarrerasCompetidores.Focus();

                            string idDistsancia = "";
                            string distancia = "";
                            if (cmbDistanciasCarrera.SelectedIndex != -1)
                            {
                                idDistsancia = cmbDistanciasCarrera.SelectedValue.ToString();
                                distancia = cmbDistanciasCarrera.Text;
                            }
                            else
                            {
                                idDistsancia = "";
                                distancia = "";
                            }

                            // ONCE THE COMBO IS SET AS INVISIBLE, SET FOCUS BACK TO THE GRID. (IMPORTANT)
                            gridCarrerasCompetidores[gridCarrerasCompetidores.CurrentCell.ColumnIndex,
                                                        gridCarrerasCompetidores.CurrentRow.Index].Value = distancia;

                            gridCarrerasCompetidores[3, gridCarrerasCompetidores.CurrentRow.Index].Value = idDistsancia;

                            int indiceFinal = ObtenerSiguienteColumnaVisibleCompetidores(4);
                            if (indiceFinal != 0)
                            {
                                gridCarrerasCompetidores.CurrentCell =
                                gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentRow.Index]
                                    .Cells[indiceFinal];
                            }
                        }
                        else
                        {
                            // SHOW COMBOBOX.
                            Show_Combobox(gridCarrerasCompetidores.CurrentRow.Index,
                                gridCarrerasCompetidores.CurrentCell.ColumnIndex, "distancia");

                            SendKeys.Send("{F4}");      // DROP DOWN THE LIST.
                            return true;

                        }
                    }

                    else if (gridCarrerasCompetidores.CurrentCell.ColumnIndex == 6)
                    {
                        if (ActiveControl.Name == "cmbCategorias")
                        {
                            cmbCategorias.Visible = false;

                            gridCarrerasCompetidores.Focus();

                            string idCategoria = "";
                            string categoria = "";
                            if (cmbCategorias.SelectedIndex != -1)
                            {
                                idCategoria = cmbCategorias.SelectedValue.ToString();
                                categoria = cmbCategorias.Text;
                            }
                            else
                            {
                                idCategoria = "";
                                categoria = "";
                            }

                            // ONCE THE COMBO IS SET AS INVISIBLE, SET FOCUS BACK TO THE GRID. (IMPORTANT)
                            gridCarrerasCompetidores[gridCarrerasCompetidores.CurrentCell.ColumnIndex,
                                                        gridCarrerasCompetidores.CurrentRow.Index].Value = categoria;

                            gridCarrerasCompetidores[5, gridCarrerasCompetidores.CurrentRow.Index].Value = idCategoria;

                            int indiceFinal = ObtenerSiguienteColumnaVisibleCompetidores(6);
                            if (indiceFinal != 0)
                            {
                                gridCarrerasCompetidores.CurrentCell =
                                gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentRow.Index]
                                    .Cells[indiceFinal];
                            }
                        }
                        else
                        {
                            // SHOW COMBOBOX.
                            Show_Combobox(gridCarrerasCompetidores.CurrentRow.Index,
                                gridCarrerasCompetidores.CurrentCell.ColumnIndex, "categoria");

                            SendKeys.Send("{F4}");      // DROP DOWN THE LIST.
                            return true;

                        }
                    }
                    else if (gridCarrerasCompetidores.CurrentCell.ColumnIndex == 5)
                    {
                        if (ActiveControl.Name == "cmbRama")
                        {
                            cmbRama.Visible = false;

                            gridCarrerasCompetidores.Focus();

                            string rama = "";
                            if (cmbRama.SelectedItem != null)
                            {
                                rama = cmbRama.SelectedItem.ToString();
                            }
                            else
                            {
                                rama = "";
                            }

                            // ONCE THE COMBO IS SET AS INVISIBLE, SET FOCUS BACK TO THE GRID. (IMPORTANT)
                            gridCarrerasCompetidores[gridCarrerasCompetidores.CurrentCell.ColumnIndex,
                                                        gridCarrerasCompetidores.CurrentRow.Index].Value = rama;


                            int indiceFinal = ObtenerSiguienteColumnaVisibleCompetidores(5);
                            if (indiceFinal != 0)
                            {
                                gridCarrerasCompetidores.CurrentCell =
                                gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentRow.Index]
                                    .Cells[indiceFinal];
                            }
                        }
                        else
                        {
                            // SHOW COMBOBOX.
                            Show_Combobox(gridCarrerasCompetidores.CurrentRow.Index,
                                gridCarrerasCompetidores.CurrentCell.ColumnIndex, "rama");

                            SendKeys.Send("{F4}");      // DROP DOWN THE LIST.
                            return true;

                        }
                    }
                    else
                    {
                        AgregarRenglonCompetidor();
                        //SendKeys.Send("{TAB}");
                    }
                }
                else
                {
                    if (gridCarrerasPuntos.CurrentCell.ColumnIndex == 1)
                    {
                        if (ActiveControl.Name == "cmbPuntos")
                        {
                            cmbPuntos.Visible = false;

                            gridCarrerasPuntos.Focus();

                            string idPunto = "";
                            string punto = "";
                            if (cmbPuntos.SelectedIndex != -1)
                            {
                                idPunto = cmbPuntos.SelectedValue.ToString();
                                punto = cmbPuntos.Text;
                            }
                            else
                            {
                                idPunto = "";
                                punto = "";
                            }
                            // ONCE THE COMBO IS SET AS INVISIBLE, SET FOCUS BACK TO THE GRID. (IMPORTANT)
                            gridCarrerasPuntos[gridCarrerasPuntos.CurrentCell.ColumnIndex,
                                gridCarrerasPuntos.CurrentRow.Index].Value = punto;

                            gridCarrerasPuntos[0, gridCarrerasPuntos.CurrentRow.Index].Value = idPunto;

                            if (ValidarPuntoRepetido(idPunto, punto))
                            {
                                int indiceFinal = ObtenerSiguienteColumnaVisiblePuntos(1);
                                if (indiceFinal != 0)
                                {
                                    gridCarrerasPuntos.CurrentCell =
                                    gridCarrerasPuntos.Rows[gridCarrerasPuntos.CurrentRow.Index]
                                        .Cells[indiceFinal];
                                }
                            }
                            else
                            {
                                gridCarrerasPuntos[gridCarrerasPuntos.CurrentCell.ColumnIndex,
                                gridCarrerasPuntos.CurrentRow.Index].Value = "";

                                gridCarrerasPuntos[0, gridCarrerasPuntos.CurrentRow.Index].Value = "";
                            }
                        }
                        else
                        {
                            // SHOW COMBOBOX.
                            Show_Combobox(gridCarrerasPuntos.CurrentRow.Index,
                                gridCarrerasPuntos.CurrentCell.ColumnIndex, "punto");

                            SendKeys.Send("{F4}");      // DROP DOWN THE LIST.
                            return true;

                        }
                    }
                    else
                    {
                        int indiceFinal = ObtenerSiguienteColumnaVisiblePuntos(gridCarrerasPuntos.CurrentCell.ColumnIndex);

                        if (indiceFinal == 0)
                        {
                            if (gridCarrerasPuntos.CurrentCell.RowIndex == gridCarrerasPuntos.RowCount - 1)
                            {
                                DataGridViewRow row = gridCarrerasPuntos.Rows[gridCarrerasPuntos.RowCount - 1];
                                string idPunto = row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "" ? row.Cells[0].Value.ToString() : "";
                                string punto = row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "" ? row.Cells[1].Value.ToString() : "";
                                string intervalo = row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "" ? row.Cells[2].Value.ToString() : "";


                                if (idPunto != "" || punto != "" || intervalo != "")
                                {
                                    AgregarRenglonPunto();
                                    return true;
                                }
                                else
                                {
                                    return base.ProcessCmdKey(ref msg, keyData);
                                }
                            }
                            else
                            {
                                return base.ProcessCmdKey(ref msg, keyData);
                            }
                        }
                    }
                }
                
                return true;
            }
            else if (keyData == Keys.Escape)            // PRESS ESCAPE TO HIDE THE COMBOBOX.
            {
                if (ActiveControl.Name == "cmbCompetidores")
                {
                    cmbCompetidores.Text = "";
                    cmbCompetidores.Visible = false;

                    gridCarrerasCompetidores.CurrentCell =
                        gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentCell.RowIndex]
                            .Cells[gridCarrerasCompetidores.CurrentCell.ColumnIndex];

                    gridCarrerasCompetidores.Focus();
                }
                else if (ActiveControl.Name == "cmbCategorias")
                {
                    cmbCategorias.Text = "";
                    cmbCategorias.Visible = false;

                    gridCarrerasCompetidores.CurrentCell =
                        gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentCell.RowIndex]
                            .Cells[gridCarrerasCompetidores.CurrentCell.ColumnIndex];

                    gridCarrerasCompetidores.Focus();
                }
                else if (ActiveControl.Name == "cmbPuntos")
                {
                    cmbPuntos.Text = "";
                    cmbPuntos.Visible = false;

                    gridCarrerasPuntos.CurrentCell =
                        gridCarrerasPuntos.Rows[gridCarrerasPuntos.CurrentCell.RowIndex]
                            .Cells[gridCarrerasPuntos.CurrentCell.ColumnIndex];

                    gridCarrerasPuntos.Focus();
                }
                else if (ActiveControl.Name == "cmbDistanciasCarrera")
                {
                    cmbDistanciasCarrera.Text = "";
                    cmbDistanciasCarrera.Visible = false;

                    gridCarrerasCompetidores.CurrentCell =
                        gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentCell.RowIndex]
                            .Cells[gridCarrerasCompetidores.CurrentCell.ColumnIndex];

                    gridCarrerasCompetidores.Focus();
                }
                return true;
            }
            else if (keyData == Keys.Down)
            {
                if (TabCarrerasDetalle.SelectedIndex == 0)
                {
                    if (ActiveControl.Name != "cmbCompetidores" && ActiveControl.Name != "cmbCategorias" && ActiveControl.Name != "cmbRama" && ActiveControl.Name != "cmbDistanciasCarrera")
                    {
                        if (gridCarrerasCompetidores.CurrentCell.RowIndex == gridCarrerasCompetidores.RowCount - 1)
                        {
                            DataGridViewRow row = gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.RowCount - 1];
                            string clave = row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "" ? row.Cells[0].Value.ToString() : "";
                            string idCompetidor = row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "" ? row.Cells[1].Value.ToString() : "";
                            string competidor = row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "" ? row.Cells[2].Value.ToString() : "";
                            string idDistancia = row.Cells[3].Value != null && row.Cells[3].Value.ToString() != "" ? row.Cells[3].Value.ToString() : "";
                            string distancia = row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "" ? row.Cells[4].Value.ToString() : "";
                            string idCategoria = row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "" ? row.Cells[5].Value.ToString() : "";
                            string categoria = row.Cells[6].Value != null && row.Cells[6].Value.ToString() != "" ? row.Cells[6].Value.ToString() : "";
                            string rama = row.Cells[7].Value != null && row.Cells[7].Value.ToString() != "" ? row.Cells[7].Value.ToString() : "";
                            string chip = row.Cells[8].Value != null && row.Cells[8].Value.ToString() != "" ? row.Cells[8].Value.ToString() : "";

                            if (idCompetidor != "" || competidor != "" || idDistancia != "" && distancia != "" || idCategoria != "" || categoria != "" || rama != "" || chip != "")
                            {
                                AgregarRenglonCompetidor();
                                return true;
                            }
                            else
                            {
                                return base.ProcessCmdKey(ref msg, keyData);
                            }
                        }
                        else
                        {
                            return base.ProcessCmdKey(ref msg, keyData);
                        }
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                }
                else
                {
                    if (ActiveControl.Name != "cmbPuntos")
                    {
                        if (gridCarrerasPuntos.CurrentCell.RowIndex == gridCarrerasPuntos.RowCount - 1)
                        {
                            DataGridViewRow row = gridCarrerasPuntos.Rows[gridCarrerasPuntos.RowCount - 1];
                            string idPunto = row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "" ? row.Cells[0].Value.ToString() : "";
                            string punto = row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "" ? row.Cells[1].Value.ToString() : "";
                            string intervalo = row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "" ? row.Cells[2].Value.ToString() : "";


                            if (idPunto != "" || punto != "" || intervalo != "")
                            {
                                AgregarRenglonPunto();
                                return true;
                            }
                            else
                            {
                                return base.ProcessCmdKey(ref msg, keyData);
                            }
                        }
                        else
                        {
                            return base.ProcessCmdKey(ref msg, keyData);
                        }
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                }
            }
            else if (keyData == Keys.Up)
            {
                if (TabCarrerasDetalle.SelectedIndex == 0)
                {
                    if (ActiveControl.Name != "cmbCompetidores" && ActiveControl.Name != "cmbCategorias" && ActiveControl.Name != "cmbRama" && ActiveControl.Name != "cmbDistanciasCarrera")
                    {
                        if (gridCarrerasCompetidores.CurrentCell.RowIndex == gridCarrerasCompetidores.RowCount - 1)
                        {
                            DataGridViewRow row = gridCarrerasCompetidores.Rows[gridCarrerasCompetidores.CurrentCell.RowIndex];
                            string clave = row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "" ? row.Cells[0].Value.ToString() : "";
                            string idCompetidor = row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "" ? row.Cells[1].Value.ToString() : "";
                            string competidor = row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "" ? row.Cells[2].Value.ToString() : "";
                            string idDistancia = row.Cells[3].Value != null && row.Cells[3].Value.ToString() != "" ? row.Cells[3].Value.ToString() : "";
                            string distancia = row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "" ? row.Cells[4].Value.ToString() : "";
                            string idCategoria = row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "" ? row.Cells[5].Value.ToString() : "";
                            string categoria = row.Cells[6].Value != null && row.Cells[6].Value.ToString() != "" ? row.Cells[6].Value.ToString() : "";
                            string rama = row.Cells[7].Value != null && row.Cells[7].Value.ToString() != "" ? row.Cells[7].Value.ToString() : "";
                            string chip = row.Cells[8].Value != null && row.Cells[8].Value.ToString() != "" ? row.Cells[8].Value.ToString() : "";

                            if (idCompetidor == "" && competidor == "" &&idDistancia == "" && distancia == "" && idCategoria == "" && categoria == "" && rama == "" && chip == "")
                            {
                                gridCarrerasCompetidores.Rows.Remove(row);
                                return true;
                            }
                            else
                            {
                                return base.ProcessCmdKey(ref msg, keyData);
                            }
                        }
                        else
                        {
                            return base.ProcessCmdKey(ref msg, keyData);
                        }
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                }
                else
                {
                    if (ActiveControl.Name != "cmbPuntos")
                    {
                        if (gridCarrerasPuntos.CurrentCell.RowIndex == gridCarrerasPuntos.RowCount - 1)
                        {
                            DataGridViewRow row = gridCarrerasPuntos.Rows[gridCarrerasPuntos.CurrentCell.RowIndex];
                            string idPunto = row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "" ? row.Cells[0].Value.ToString() : "";
                            string punto = row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "" ? row.Cells[1].Value.ToString() : "";
                            string intervalo = row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "" ? row.Cells[2].Value.ToString() : "";

                            if (idPunto == "" && punto == "" && intervalo == "")
                            {
                                gridCarrerasPuntos.Rows.RemoveAt(row.Index);
                                return true;
                            }
                            else
                            {
                                return base.ProcessCmdKey(ref msg, keyData);
                            }
                        }
                        else
                        {
                            return base.ProcessCmdKey(ref msg, keyData);
                        }
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                }
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void Show_Combobox(int iRowIndex, int iColumnIndex, string tipo)
         {
             // DESCRIPTION: SHOW THE COMBO BOX IN THE SELECTED CELL OF THE GRID.
             // PARAMETERS: iRowIndex - THE ROW ID OF THE GRID.
             //             iColumnIndex - THE COLUMN ID OF THE GRID.

             int x = 0;
             int y = 0;
             int Width = 0;
             int height = 0;

             // GET THE ACTIVE CELL'S DIMENTIONS TO BIND THE COMBOBOX WITH IT.
             Rectangle rect = default(Rectangle);
             if (TabCarrerasDetalle.SelectedIndex == 0)
             {
                 rect = gridCarrerasCompetidores.GetCellDisplayRectangle(iColumnIndex, iRowIndex, false);
                 x = rect.X + gridCarrerasCompetidores.Left;
                 y = rect.Y + gridCarrerasCompetidores.Top;
             }
             else
             {
                 rect = gridCarrerasPuntos.GetCellDisplayRectangle(iColumnIndex, iRowIndex, false);
                 x = rect.X + gridCarrerasPuntos.Left;
                 y = rect.Y + gridCarrerasPuntos.Top;
             }

             Width = rect.Width;
             height = rect.Height;

             switch (tipo)
             {
                 case "competidor":
                     {
                         cmbCompetidores.SetBounds(x, y, Width, height);
                         cmbCompetidores.Visible = true;
                         cmbCompetidores.Focus();
                     }break;
                 case "categoria":
                     {
                         cmbCategorias.SetBounds(x, y, Width, height);
                         cmbCategorias.Visible = true;
                         cmbCategorias.Focus();
                     }break;
                 case "rama":
                     {
                         cmbRama.SetBounds(x, y, Width, height);
                         cmbRama.Visible = true;
                         cmbRama.Focus();
                     }break;
                 case "distancia":
                     {
                         cmbDistanciasCarrera.SetBounds(x, y, Width, height);
                         cmbDistanciasCarrera.Visible = true;
                         cmbDistanciasCarrera.Focus();
                     } break;
                 case "punto":
                     {
                         cmbPuntos.SetBounds(x, y, Width, height);
                         cmbPuntos.Visible = true;
                         cmbPuntos.Focus();
                     }break;
             }
         }


        private void gridCarrerasCompetidores_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }

            int indice = gridCarrerasCompetidores.CurrentCell.RowIndex;
            if (e.Control is ComboBox)
            {
                ComboBox cmb = (ComboBox)e.Control;
                if (cmb.SelectedValue != null && cmb.Name == "IdCompetidor")
                {
                    if (gridCarrerasCompetidores != null && gridCarrerasCompetidores.RowCount > 0)
                    {
                        int indiceRow = 0;
                        foreach (DataGridViewRow row in gridCarrerasCompetidores.Rows)
                        {
                            if (indice == indiceRow)
                            {
                                continue;
                            }

                            if (row.Cells[1].Value != null)
                            {
                                if (row.Cells[1].Value.ToString().Equals(cmb.SelectedValue.ToString()))
                                {
                                    MessageBox.Show("Ya se agregó ese competidor");
                                    cmb.SelectedIndex = -1;
                                    return;
                                }
                            }
                            indiceRow++;
                        }
                    }
                }

                // remove handler first to avoid attaching twice
                //((ComboBox)e.Control).SelectedIndexChanged -= new EventHandler(ValidarCompetidor(sender, e, indice));
                //((ComboBox)e.Control).SelectedIndexChanged += new EventHandler(ValidarCompetidor(sender, e, indice));
            }
        }

        private void gridCarrerasPuntos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void toolStripEliminarPunto_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea eliminar el punto seleccionado?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow row = gridCarrerasPuntos.Rows[gridCarrerasPuntos.CurrentCell.RowIndex];
                if (gridCarrerasPuntos.RowCount == 1 && gridCarrerasPuntos.CurrentCell.RowIndex == 0)
                {
                    row.Cells[1].Value = "";
                    row.Cells[2].Value = "";
                    row.Cells[3].Value = "";
                    row.Cells[4].Value = "";
                    row.Cells[5].Value = "";
                }
                else
                {
                    gridCarrerasPuntos.Rows.Remove(row);

                    int indice = 1;
                    foreach (DataGridViewRow renglon in gridCarrerasPuntos.Rows)
                    {
                        renglon.Cells[0].Value = indice++;
                    }
                }
            }
        }


    }
}
