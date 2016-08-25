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
    public partial class VistaDetallesCarrera : Form
    {
        int IdEmpresa = 14;
        string connectionString = "SERVER=localhost;DATABASE=atletica;UID=root;PASSWORD=pecopeco1290;";
        MySqlConnection mySqlCon = null;

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
            sentencia.AppendLine("	A.IDEMPRESA = " + IdEmpresa);
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
            mySqlCon = new MySqlConnection(connectionString);
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
    }
}
