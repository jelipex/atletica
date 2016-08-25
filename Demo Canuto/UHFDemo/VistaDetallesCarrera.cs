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
    public partial class VistaDetallesCarrera : Form
    {
        int IdEmpresa = 14;
        string connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
        MySqlConnection conexion = null;

        public VistaDetallesCarrera()
        {
            InitializeComponent();
        }

        private DataTable LlenarComboCarreras()
        {
            StringBuilder sentencia = new StringBuilder();
            sentencia.AppendLine("SELECT ");
            sentencia.AppendLine("  IDCARRERA, ");
            sentencia.AppendLine("  DESCRIPCION ");
            sentencia.AppendLine("FROM ");
            sentencia.AppendLine("	CARRERAS ");
            sentencia.AppendLine("WHERE ");
            sentencia.AppendLine("	IDEMPRESA = " + IdEmpresa);
            return Populate(sentencia.ToString());
        }

        private DataTable LlenarComboDistancias(int idCarrera)
        {
            StringBuilder sentencia = new StringBuilder();
            sentencia.AppendLine("SELECT ");
            sentencia.AppendLine("	DISTINCT ");
            sentencia.AppendLine("	A.IDDISTANCIA, ");
            sentencia.AppendLine("	B.DESCRIPCION ");
            sentencia.AppendLine("FROM ");
            sentencia.AppendLine("	CARRERASDETALLE AS A ");
            sentencia.AppendLine("LEFT JOIN  ");
            sentencia.AppendLine("	DISTANCIASCARRERA AS B ");
            sentencia.AppendLine("ON 	B.IDEMPRESA = A.IDEMPRESA ");
            sentencia.AppendLine("AND B.IDDISTANCIA = A.IDDISTANCIA ");
            sentencia.AppendLine("WHERE ");
            sentencia.AppendLine("	A.IDEMPRESA = "  + IdEmpresa);
            sentencia.AppendLine("AND A.IDCARRERA = " + idCarrera);
            sentencia.AppendLine("ORDER BY A.IDDISTANCIA ");
            return Populate(sentencia.ToString());
        }

        private DataTable LlenarComboCategorias(int idCarrera)
        {
            StringBuilder sentencia = new StringBuilder();
            sentencia.AppendLine("SELECT ");
            sentencia.AppendLine("	DISTINCT ");
            sentencia.AppendLine("	A.IDCATEGORIA, ");
            sentencia.AppendLine("	B.DESCRIPCION ");
            sentencia.AppendLine("FROM ");
            sentencia.AppendLine("	CARRERASDETALLE AS A ");
            sentencia.AppendLine("LEFT JOIN  ");
            sentencia.AppendLine("	CATEGORIAS AS B ");
            sentencia.AppendLine("ON 	B.IDEMPRESA = A.IDEMPRESA ");
            sentencia.AppendLine("AND B.IDCATEGORIA = A.IDCATEGORIA ");
            sentencia.AppendLine("WHERE ");
            sentencia.AppendLine("	A.IDEMPRESA = "  + IdEmpresa);
            sentencia.AppendLine("AND A.IDCARRERA = " + idCarrera);
            sentencia.AppendLine("ORDER BY A.IDCATEGORIA ");
            return Populate(sentencia.ToString());
        }

        private DataTable Populate(string sqlCommand)
        {
            conexion = new MySqlConnection(connectionString);
            DataTable table = new DataTable();

            try
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand(sqlCommand, conexion);
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
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return table;
        }

        private void cmbCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCarrera = Convert.ToInt32(cmbCarreras.SelectedValue);

            DataTable dtDistancias = LlenarComboDistancias(idCarrera);
            cmbDistancias.DataSource = dtDistancias;
            cmbDistancias.DisplayMember = "Descripcion";
            cmbDistancias.ValueMember = "IdDistancia";

            DataRow drDistancias = dtDistancias.NewRow();
            drDistancias["Descripcion"] = "Todas";
            drDistancias["IdDistancia"] = 0;

            dtDistancias.Rows.InsertAt(drDistancias, 0);
            cmbDistancias.SelectedIndex = 0;

            DataTable dtCategorias = LlenarComboCategorias(idCarrera);
            cmbCategorias.DataSource = dtCategorias;
            cmbCategorias.DisplayMember = "Descripcion";
            cmbCategorias.ValueMember = "IdCategoria";

            DataRow drCategorias = dtCategorias.NewRow();
            drCategorias["Descripcion"] = "Todas";
            drCategorias["IdCategoria"] = 0;

            dtCategorias.Rows.InsertAt(drCategorias, 0);
            cmbCategorias.SelectedIndex = 0;
        }

        private void VistaDetallesCarrera_Load(object sender, EventArgs e)
        {
            DataTable dtCarreras = LlenarComboCarreras();

            cmbCarreras.DataSource = dtCarreras;
            cmbCarreras.DisplayMember = "Descripcion";
            cmbCarreras.ValueMember = "IdCarrera";

            DataRow dr = dtCarreras.NewRow();
            dr["Descripcion"] = "Seleccionar";
            dr["IdCarrera"] = 0;

            dtCarreras.Rows.InsertAt(dr, 0);
            cmbCarreras.SelectedIndex = 0;

            cmbCarreras.SelectedIndexChanged+= cmbCarreras_SelectedIndexChanged;
        }

        private List<CarreraDetalleTiempos> ObtenerListado()
        {
            conexion = new MySqlConnection(connectionString);
            CarreraDetalleTiempos entidad = new CarreraDetalleTiempos();
            List<CarreraDetalleTiempos> listaCarreraDetalle = new List<CarreraDetalleTiempos>();
            try
            {
                int idCarrera = Convert.ToInt32(cmbCarreras.SelectedValue);

                conexion.Open();

                StringBuilder sentencia = new StringBuilder();
                sentencia.AppendLine("SELECT ");
                sentencia.AppendLine("	A.IDEMPRESA, ");
                sentencia.AppendLine("	A.IDCARRERA, ");
                sentencia.AppendLine("	A.IDCARRERADETALLE, ");
                sentencia.AppendLine("	A.ID, ");
                sentencia.AppendLine("	A.IDCOMPETIDOR, ");
                sentencia.AppendLine("	CONCAT(B.APELLIDOPATERNO, ' ', B.APELLIDOMATERNO, ' ', B.NOMBRE) AS NOMBRECOMPLETO, ");
                sentencia.AppendLine("	A.IDCATEGORIA, ");
                sentencia.AppendLine("	C.DESCRIPCION AS CATEGORIA, ");
                sentencia.AppendLine("	A.IDDISTANCIA, ");
                sentencia.AppendLine("	D.DESCRIPCION AS DISTANCIA, ");
                sentencia.AppendLine("	A.RAMA, ");
                sentencia.AppendLine("	A.FECHAHORA, ");
                sentencia.AppendLine("	(SELECT SUM(TIEMPO) FROM CARRERASDETALLETIEMPOS WHERE IDEMPRESA = A.IDEMPRESA AND IDCARRERA = A.IDCARRERA AND IDCARRERADETALLE = A.IDCARRERADETALLE) AS TIEMPO ");
                sentencia.AppendLine("FROM ");
                sentencia.AppendLine("	CARRERASDETALLETIEMPOS AS A ");
                sentencia.AppendLine("LEFT JOIN ");
                sentencia.AppendLine("	COMPETIDORES AS B ");
                sentencia.AppendLine("ON 	B.IDEMPRESA = A.IDEMPRESA ");
                sentencia.AppendLine("AND B.IDCOMPETIDOR = A.IDCOMPETIDOR ");
                sentencia.AppendLine("LEFT JOIN ");
                sentencia.AppendLine("	CATEGORIAS AS C ");
                sentencia.AppendLine("ON	C.IDEMPRESA = A.IDEMPRESA ");
                sentencia.AppendLine("AND C.IDCATEGORIA = A.IDCATEGORIA ");
                sentencia.AppendLine("LEFT JOIN ");
                sentencia.AppendLine("	DISTANCIASCARRERA AS D ");
                sentencia.AppendLine("ON 	D.IDEMPRESA = A.IDEMPRESA ");
                sentencia.AppendLine("AND D.IDDISTANCIA = A.IDDISTANCIA ");
                sentencia.AppendLine("WHERE ");
                sentencia.AppendLine("	A.IDEMPRESA = " + IdEmpresa);
                sentencia.AppendLine("AND A.IDCARRERA = " + idCarrera);
                sentencia.AppendLine("AND A.ID = (SELECT MAX(ID) FROM CARRERASDETALLETIEMPOS WHERE IDEMPRESA = A.IDEMPRESA AND IDCARRERA = A.IDCARRERA AND IDCARRERADETALLE = A.IDCARRERADETALLE) ");
                sentencia.AppendLine("ORDER BY A.IDEMPRESA, A.IDCARRERA, A.FECHAHORA ");

                MySqlCommand comando = new MySqlCommand(sentencia.ToString(), conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                int row = 1;

                while (reader.Read())
                {
                    int indice = 0;
                    entidad = new CarreraDetalleTiempos();
                    entidad.Lugar = row;
                    entidad.IdEmpresa = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.IdCarrera = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.IdCarreraDetalle = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Id = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.IdCompetidor = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Competidor = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.IdCategoria = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Categoria = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.IdDistancia = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Distancia = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.Rama = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.FechaHora = (reader[indice] is DBNull) ? DateTime.MinValue : reader.GetDateTime(indice); indice++;
                    entidad.Tiempo = (reader[indice] is DBNull) ? 0: reader.GetDouble(indice); indice++;
                    
                    listaCarreraDetalle.Add(entidad);
                    row++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return listaCarreraDetalle;
        }

        private void LlenarListado()
        {
            List<CarreraDetalleTiempos> listaCarreraDetalle = new List<CarreraDetalleTiempos>();
            int idCategoria = cmbCategorias.SelectedIndex > -1 ? Convert.ToInt32(cmbCategorias.SelectedValue) : 0;
            int idDistancia = cmbDistancias.SelectedIndex > - 1 ? Convert.ToInt32(cmbDistancias.SelectedValue) : 0;
            string rama = cmbRamas.SelectedItem != null && cmbRamas.SelectedItem != "" && cmbRamas.SelectedItem.ToString() != "Todas" ? cmbRamas.SelectedItem.ToString() : "";

            listaCarreraDetalle = ObtenerListado();
            gridDetallesCarrera.Rows.Clear();

            if (listaCarreraDetalle != null && listaCarreraDetalle.Count > 0)
            {
                foreach (CarreraDetalleTiempos entidad in listaCarreraDetalle)
                {
                    if (idCategoria != 0 && entidad.IdCategoria != idCategoria)
                    {
                        continue;
                    }

                    if (idDistancia != 0 && entidad.IdDistancia != idDistancia)
                    {
                        continue;
                    }

                    if (rama != "" && entidad.Rama != rama)
                    {
                        continue;
                    } 
                    
                    string lugar = entidad.Lugar.ToString();
                    string numero = entidad.IdCarreraDetalle.ToString();
                    string competidor = entidad.Competidor;
                    string distancia = entidad.Distancia;
                    string categoria = entidad.Categoria;
                    string ramaCarrera = entidad.Rama;

                    TimeSpan tiempo = TimeSpan.FromSeconds(entidad.Tiempo);
                    string tiempoFormateado = string.Format("{0:00}:{1:00}:{2:00}:{3:000000}", tiempo.TotalHours, tiempo.Minutes, tiempo.Seconds, tiempo.Milliseconds);

                    string[] row = new string[] { lugar, numero, competidor, distancia, categoria, ramaCarrera, tiempoFormateado };
                    gridDetallesCarrera.Rows.Add(row);

                }
            }

        }

        private void btnBuscarCarrera_Click(object sender, EventArgs e)
        {
            LlenarListado();
        }
    }
}
