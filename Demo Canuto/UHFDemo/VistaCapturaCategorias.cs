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
    public partial class VistaCapturaCategorias : Form
    {
        int IdEmpresa = 14;
        string connectionString = "";
        string query = "";
        MySqlConnection mysqlCon = new MySqlConnection();
        R2000UartDemo vistaDemo;
        public bool entroGuardarCerrar = false;

        public VistaCapturaCategorias(R2000UartDemo Demo)
        {
            InitializeComponent();
            vistaDemo = Demo;
        }

        public void RegistrarCategoria()
        {
            InicializarFormularioCategorias();
            btnGuardarCategoria.Visible = true;
        }

        private void InicializarFormularioCategorias()
        {
            txtIdCategoria.Text = ObtenerConsecutivo().ToString();
            txtDescripcionCategoria.Text = "";
            txtEdadInicial.Text = "";
            txtEdadFinal.Text = "";
            txtDescripcionCategoria.Focus();
            AsignarEventos();
        }

        public void ModificarCategoria(int idCategoria, string descripcion)
        {
            txtIdCategoria.Text = idCategoria.ToString();
            txtDescripcionCategoria.Text = descripcion;
            txtDescripcionCategoria.Focus();
            btnGuardarCategoria.Visible = false;
            btnGuardarCerrarCategoria.Click -= btnGuardarCerrarCategoria_Click;
            btnGuardarCerrarCategoria.Click += new EventHandler(Actualizar);
            btnCancelar.Click += btnCancelar_Click;
            this.FormClosing += VistaCapturaCategorias_FormClosing;
        }

        private void AsignarEventos()
        {
            btnGuardarCategoria.Click -= btnGuardarCategoria_Click;
            btnGuardarCategoria.Click +=btnGuardarCategoria_Click;
            btnGuardarCerrarCategoria.Click -= btnGuardarCerrarCategoria_Click;
            btnGuardarCerrarCategoria.Click += btnGuardarCerrarCategoria_Click;
            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;
            this.FormClosing -= VistaCapturaCategorias_FormClosing;
            this.FormClosing += VistaCapturaCategorias_FormClosing;
        }

        void VistaCapturaCategorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!entroGuardarCerrar)
            {
                DialogResult result = MessageBox.Show("¿Desea salir sin guardar cambios?", "Confirmación", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    //vistaDemo.LlenarListadoCategorias();
                    entroGuardarCerrar = true;
                }
            }
            else
            {
                vistaDemo.LlenarListadoCategorias();
                entroGuardarCerrar = false;
            }
            
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        void btnGuardarCerrarCategoria_Click(object sender, EventArgs e)
        {
            GuardarCerrar();
        }

        void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private int ObtenerConsecutivo()
        {
            connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
            mysqlCon = new MySqlConnection(connectionString);
            query = "SELECT ifnull(MAX(IdCategoria), 0) + 1 from categorias where idempresa = " + IdEmpresa;
            int idCategoria = 0;
            try
            {
                mysqlCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, mysqlCon);
                //Create a data reader and Execute the command
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    idCategoria = (reader[0] is DBNull) ? 0 : reader.GetInt32(0);
                }
                return idCategoria;

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

        private bool ValidarCampos()
        {
            bool valido = true;
            string descripcion = txtDescripcionCategoria.Text;
            string edadInicial = txtEdadInicial.Text;
            string edadFinal = txtEdadFinal.Text;

            if (string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Debe de capturar una descripción de la categoría");
                valido = false;
                return valido;
            }
            else if (string.IsNullOrEmpty(edadInicial))
            {
                MessageBox.Show("Debe de capturar un edad inicial de edad");
                valido = false;
                return valido;
            }
            else if (string.IsNullOrEmpty(edadFinal))
            {
                MessageBox.Show("Debe de capturar un edad final de edad");
                valido = false;
                return valido;
            }

            return valido;
        }

        private void Guardar()
        {
            
           
            try
            {
                if (ValidarCampos())
                {
                    int idCategoria = ObtenerConsecutivo();
                    string descripcion = txtDescripcionCategoria.Text;
                    int edadInicial = Convert.ToInt32(txtEdadInicial.Text);
                    int edadFinal = Convert.ToInt32(txtEdadFinal.Text);

                    connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
                    mysqlCon = new MySqlConnection(connectionString);
                    mysqlCon.Open();
                    query = "INSERT INTO CATEGORIAS(IDEMPRESA, IDCATEGORIA, DESCRIPCION, EDADINICIAL, EDADFINAL) VALUES(" + IdEmpresa + ", " + idCategoria + ", '" + descripcion + "', " + edadInicial + ", " + edadFinal + ")";
                    MySqlCommand cmd = new MySqlCommand(query, mysqlCon);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Categoría guardada correctamente.");
                        InicializarFormularioCategorias();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al guardar la categoría comunicarse con el administrador.");
                    }
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

        private void GuardarCerrar()
        {
            try
            {
                if (ValidarCampos())
                {
                    int idCategoria = ObtenerConsecutivo();
                    string descripcion = txtDescripcionCategoria.Text;
                    int edadInicial = Convert.ToInt32(txtEdadInicial.Text);
                    int edadFinal = Convert.ToInt32(txtEdadFinal.Text);

                    connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
                    mysqlCon = new MySqlConnection(connectionString);
                    mysqlCon.Open();
                    query = "INSERT INTO CATEGORIAS(IDEMPRESA, IDCATEGORIA, DESCRIPCION, EDADINICIAL, EDADFINAL) VALUES(" + IdEmpresa + ", " + idCategoria + ", '" + descripcion + "', " + edadInicial + ", " + edadFinal + ")";
                    MySqlCommand cmd = new MySqlCommand(query, mysqlCon);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Categoría guardada correctamente.");
                        entroGuardarCerrar = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al guardar la categoría comunicarse con el administrador.");
                    }
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
            try
            {
                if (ValidarCampos())
                {
                    int idCategoria = Convert.ToInt32(txtIdCategoria.Text);
                    string descripcion = txtDescripcionCategoria.Text;
                    int edadInicial = Convert.ToInt32(txtEdadInicial.Text);
                    int edadFinal = Convert.ToInt32(txtEdadFinal.Text);

                    connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
                    mysqlCon = new MySqlConnection(connectionString);
                    mysqlCon.Open();
                    query = "UPDATE CATEGORIAS SET DESCRIPCION = '" + descripcion + "', EDADINICIAL = " + edadInicial + ", EDADFINAL = " + edadFinal + " WHERE IDEMPRESA = " + IdEmpresa + " AND IDCATEGORIA = " + idCategoria;
                    MySqlCommand cmd = new MySqlCommand(query, mysqlCon);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Categoría modificada correctamente.");
                        entroGuardarCerrar = true;
                        this.Close();
                        vistaDemo.LlenarListadoCategorias();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al modificar la categoría comunicarse con el administrador.");
                    }
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

        private void Cancelar()
        {
            this.Close();
        }
    }
}
