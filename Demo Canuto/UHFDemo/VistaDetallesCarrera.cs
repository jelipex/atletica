﻿using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            cmbRamas.SelectedIndex = 0;

            cmbCarreras.SelectedIndexChanged+= cmbCarreras_SelectedIndexChanged;
        }

        private List<CarreraDetalleTiempos> ObtenerListadoGanadores()
        {
            conexion = new MySqlConnection(connectionString);
            CarreraDetalleTiempos entidad = new CarreraDetalleTiempos();
            List<CarreraDetalleTiempos> listaCarreraDetalle = new List<CarreraDetalleTiempos>();
            try
            {
                int idCarrera = Convert.ToInt32(cmbCarreras.SelectedValue);
                int numeroGanadores = txtNumeroGanadores.Text != null && txtNumeroGanadores.Text != "" ? Convert.ToInt32(txtNumeroGanadores.Text) : 3;

                conexion.Open();

                StringBuilder sentencia = new StringBuilder();
                sentencia.AppendLine("SELECT  ");
                sentencia.AppendLine("	A.IDEMPRESA,  ");
                sentencia.AppendLine("	A.IDCARRERA,  ");
                sentencia.AppendLine("	A.IDCARRERADETALLE,  ");
                sentencia.AppendLine("	A.ID,  ");
                sentencia.AppendLine("	A.NUMERO,  ");
                sentencia.AppendLine("	A.COMPETIDOR,  ");
                sentencia.AppendLine("	A.IDDISTANCIA,  ");
                sentencia.AppendLine("	B.DESCRIPCION AS DISTANCIA,	  ");
                sentencia.AppendLine("	A.IDCATEGORIA,  ");
                sentencia.AppendLine("	C.DESCRIPCION AS CATEGORIA,  ");
                sentencia.AppendLine("	A.RAMA,  ");
                sentencia.AppendLine("	D.TIEMPOINICIALCARRERA, ");
                sentencia.AppendLine("	A.FECHAHORA ");
                sentencia.AppendLine("FROM   ");
                sentencia.AppendLine("	CARRERASDETALLETIEMPOS AS A  ");
                sentencia.AppendLine("LEFT JOIN ");
                sentencia.AppendLine("	CARRERAS AS D ");
                sentencia.AppendLine("ON 	D.IDEMPRESA = A.IDEMPRESA ");
                sentencia.AppendLine("AND D.IDCARRERA = A.IDCARRERA ");
                sentencia.AppendLine("LEFT JOIN  ");
                sentencia.AppendLine("	DISTANCIASCARRERA AS B  ");
                sentencia.AppendLine("ON 	B.IDEMPRESA = A.IDEMPRESA  ");
                sentencia.AppendLine("AND B.IDDISTANCIA = A.IDDISTANCIA  ");
                sentencia.AppendLine("LEFT JOIN  ");
                sentencia.AppendLine("	CATEGORIAS AS C  ");
                sentencia.AppendLine("ON 	C.IDEMPRESA = A.IDEMPRESA  ");
                sentencia.AppendLine("AND C.IDCATEGORIA = A.IDCATEGORIA  ");
                sentencia.AppendLine("WHERE   ");
                sentencia.AppendLine("	A.IDEMPRESA = " + IdEmpresa);
                sentencia.AppendLine("AND A.IDCARRERA = " + idCarrera);
                sentencia.AppendLine("AND A.IDPUNTO = 6 ");
                sentencia.AppendLine("ORDER BY A.IDEMPRESA, A.IDCARRERA, A.IDDISTANCIA, A.IDCATEGORIA, A.RAMA, A.FECHAHORA ");

                MySqlCommand comando = new MySqlCommand(sentencia.ToString(), conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                int row = 1;
                int rowAnterior = 0;

                while (reader.Read())
                {
                    int indice = 0;
                    entidad = new CarreraDetalleTiempos();
                    
                    entidad.IdEmpresa = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.IdCarrera = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.IdCarreraDetalle = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Id = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Numero = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Competidor = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.IdCategoria = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Categoria = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.IdDistancia = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Distancia = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.Rama = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.TiempoInicialCarrera = (reader[indice] is DBNull) ? DateTime.MinValue : reader.GetDateTime(indice); indice++;
                    entidad.FechaHora = (reader[indice] is DBNull) ? DateTime.MinValue : reader.GetDateTime(indice); indice++;

                    TimeSpan span = entidad.FechaHora - entidad.TiempoInicialCarrera;
                    entidad.Tiempo = span.TotalMilliseconds/1000;

                    if (rowAnterior != 0)
                    {
                        if (listaCarreraDetalle[rowAnterior-1].IdDistancia != entidad.IdDistancia)
                        {
                            entidad.Lugar = 1;
                            row = 1;
                        }

                        else if (listaCarreraDetalle[rowAnterior-1].IdCategoria != entidad.IdCategoria)
                        {
                            entidad.Lugar = 1;
                            row = 1;
                        }

                        else if (listaCarreraDetalle[rowAnterior-1].Rama != entidad.Rama)
                        {
                            entidad.Lugar = 1;
                            row = 1;
                        }
                    }

                    entidad.Lugar = row;
                    if (row > numeroGanadores)
                    {
                        continue;
                    }

                    listaCarreraDetalle.Add(entidad);
                    row++;
                    rowAnterior++;
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
                sentencia.AppendLine("	A.NUMERO, ");
                sentencia.AppendLine("	A.COMPETIDOR, ");
                sentencia.AppendLine("	A.IDCATEGORIA, ");
                sentencia.AppendLine("	C.DESCRIPCION AS CATEGORIA, ");
                sentencia.AppendLine("	A.IDDISTANCIA, ");
                sentencia.AppendLine("	D.DESCRIPCION AS DISTANCIA, ");
                sentencia.AppendLine("	A.RAMA, ");
                sentencia.AppendLine("	A.IDPUNTO, ");
                sentencia.AppendLine("	E.DESCRIPCION AS PUNTO, ");
                sentencia.AppendLine("	A.FECHAHORA, ");
                sentencia.AppendLine("	CA.TIEMPOINICIALCARRERA ");

                if (chkPorPuntos.Checked)
                {
                    sentencia.AppendLine("	,A.TIEMPO ");
                }

                sentencia.AppendLine("FROM ");
                sentencia.AppendLine("	CARRERASDETALLETIEMPOS AS A ");
                sentencia.AppendLine("LEFT JOIN ");
                sentencia.AppendLine("	CARRERAS AS CA ");
                sentencia.AppendLine("ON	CA.IDEMPRESA = A.IDEMPRESA ");
                sentencia.AppendLine("AND CA.IDCARRERA = A.IDCARRERA ");
                sentencia.AppendLine("LEFT JOIN ");
                sentencia.AppendLine("	CATEGORIAS AS C ");
                sentencia.AppendLine("ON	C.IDEMPRESA = A.IDEMPRESA ");
                sentencia.AppendLine("AND C.IDCATEGORIA = A.IDCATEGORIA ");
                sentencia.AppendLine("LEFT JOIN ");
                sentencia.AppendLine("	DISTANCIASCARRERA AS D ");
                sentencia.AppendLine("ON 	D.IDEMPRESA = A.IDEMPRESA ");
                sentencia.AppendLine("AND D.IDDISTANCIA = A.IDDISTANCIA ");
                sentencia.AppendLine("LEFT JOIN ");
                sentencia.AppendLine("	PUNTOS AS E ");
                sentencia.AppendLine("ON   E.IDEMPRESA = A.IDEMPRESA ");
                sentencia.AppendLine("AND  E.IDPUNTO = A.IDPUNTO");
                sentencia.AppendLine("WHERE ");
                sentencia.AppendLine("	A.IDEMPRESA = " + IdEmpresa);
                sentencia.AppendLine("AND A.IDCARRERA = " + idCarrera);
               

                if (chkPorPuntos.Checked)
                {
                    sentencia.AppendLine("ORDER BY A.IDEMPRESA, A.IDCARRERA, A.IDCARRERADETALLE, A.FECHAHORA ");
                }
                else
                {
                    sentencia.AppendLine("AND A.IDPUNTO = 6 ");
                    sentencia.AppendLine("ORDER BY A.IDEMPRESA, A.IDCARRERA, A.FECHAHORA ");
                }
                

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
                    entidad.Numero = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Competidor = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.IdCategoria = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Categoria = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.IdDistancia = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Distancia = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.Rama = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.IdPunto = (reader[indice] is DBNull) ? 0 : reader.GetInt32(indice); indice++;
                    entidad.Punto = (reader[indice] is DBNull) ? string.Empty : reader.GetString(indice); indice++;
                    entidad.FechaHora = (reader[indice] is DBNull) ? DateTime.MinValue : reader.GetDateTime(indice); indice++;
                    entidad.TiempoInicialCarrera = (reader[indice] is DBNull) ? DateTime.MinValue : reader.GetDateTime(indice); indice++;

                    if (chkPorPuntos.Checked)
                    {
                        entidad.Tiempo = (reader[indice] is DBNull) ? 0 : reader.GetDouble(indice); indice++;
                    }
                    else
                    {
                        TimeSpan span = entidad.FechaHora - entidad.TiempoInicialCarrera;
                        entidad.Tiempo = span.TotalMilliseconds / 1000;
                    }
                    
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
                    string punto = chkPorPuntos.Checked ? entidad.Punto : "";

                    TimeSpan tiempo = TimeSpan.FromSeconds(entidad.Tiempo);
                    string tiempoFormateado = string.Format("{0:00}:{1:00}:{2:00}:{3:000000}", tiempo.TotalHours, tiempo.Minutes, tiempo.Seconds, tiempo.Milliseconds);

                    string[] row = new string[] { lugar, numero, competidor, distancia, categoria, ramaCarrera, punto, tiempoFormateado };
                    gridDetallesCarrera.Rows.Add(row);

                }
            }

        }

        private void LlenarListadoGanadores()
        {
            List<CarreraDetalleTiempos> listaCarreraDetalle = new List<CarreraDetalleTiempos>();
            int idCategoria = cmbCategorias.SelectedIndex > -1 ? Convert.ToInt32(cmbCategorias.SelectedValue) : 0;
            int idDistancia = cmbDistancias.SelectedIndex > -1 ? Convert.ToInt32(cmbDistancias.SelectedValue) : 0;
            string rama = cmbRamas.SelectedItem != null && cmbRamas.SelectedItem != "" && cmbRamas.SelectedItem.ToString() != "Todas" ? cmbRamas.SelectedItem.ToString() : "";

            listaCarreraDetalle = ObtenerListadoGanadores();
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
            if (chkGanadores.Checked)
            {
                LlenarListadoGanadores();
            }
            else
            {
                LlenarListado();
            }
        }

        private void ExportarGeneral(int idCarrera, string carrera)
        {
            FileInfo newFile = new FileInfo("Tiempos generales de " + carrera.ToUpper() + ".xlsx");
            // If any file exists in this directory having name 'Sample1.xlsx', then delete it
            if (newFile.Exists)
            {
                newFile.Delete(); // ensures we create a new workbook
                newFile = new FileInfo("Tiempos generales de " + carrera.ToUpper() + ".xlsx");
            }

            using (var package = new ExcelPackage(newFile))
            {

                List<CarreraDetalleTiempos> lista = ObtenerListado();
                package.Workbook.Worksheets.Add(carrera);
                ExcelWorksheet ws = package.Workbook.Worksheets[1];
                ws.Name = carrera;

                ws.Cells.Style.Font.Size = 10;//Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial"; //Default Font name for whole sheet

                int numeroColumna = 1;
                ws.Column(numeroColumna++).Width = 12; //Lugar
                ws.Column(numeroColumna++).Width = 12; //IdCompetidor
                ws.Column(numeroColumna++).Width = 30; //Nombre
                ws.Column(numeroColumna++).Width = 15; //Distancia
                ws.Column(numeroColumna++).Width = 15; //Categoria
                ws.Column(numeroColumna++).Width = 15; //Rama
                ws.Column(numeroColumna).Width = 15; //Tiempo

                ws.Cells[1, 1, 1, numeroColumna].Merge = true;
                ws.Cells[2, 1, 2, numeroColumna].Merge = true;
                ws.Cells[3, 1, 3, numeroColumna].Merge = true;

                ws.Cells[1, 1].Value = "ATLÉTICA SPORTS";
                ws.Cells[1, 1].Style.Font.Bold = true;
                ws.Cells[2, 1].Value = "LOS MOCHIS, SINALOA";
                ws.Cells[3, 1].Value = "TIEMPOS GENERALES DE " + carrera.ToUpper();

                var encabezados = ws.Cells[1, 1, 3, numeroColumna];
                encabezados.Style.Font.Bold = true;
                encabezados.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                encabezados.Style.Font.Color.SetColor(Color.White);
                Color colFromHexEncabezado = System.Drawing.ColorTranslator.FromHtml("#333f4f");
                var fillEncabezado = encabezados.Style.Fill;
                fillEncabezado.PatternType = ExcelFillStyle.Solid;
                fillEncabezado.BackgroundColor.SetColor(colFromHexEncabezado);

                //Merging cells and create a center heading for out table


                int renglon = 5;

                if (lista != null && lista.Count > 0)
                {
                    foreach (CarreraDetalleTiempos entidad in lista)
                    {
                        if (entidad.Lugar == 1)
                        {
                            if (renglon != 5)
                            {
                                renglon++;
                            }

                            ws.Cells[renglon, 1].Value = "LUGAR";
                            ws.Cells[renglon, 2].Value = "N°";
                            ws.Cells[renglon, 3].Value = "NOMBRE";
                            ws.Cells[renglon, 4].Value = "DISTANCIA";
                            ws.Cells[renglon, 5].Value = "CATEGORIA";
                            ws.Cells[renglon, 6].Value = "RAMA";
                            ws.Cells[renglon, 7].Value = "TIEMPO";
                            var titulos = ws.Cells[renglon, 1, renglon, numeroColumna];
                            titulos.Style.Font.Bold = true;
                            titulos.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            titulos.Style.Font.Color.SetColor(Color.White);
                            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#337AB7");
                            var fill = titulos.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(colFromHex);

                            var border = titulos.Style.Border;
                            border.Left.Style = ExcelBorderStyle.Thin;
                            border.Right.Style = ExcelBorderStyle.Thin;
                            border.Top.Style = ExcelBorderStyle.Thin;
                            border.Bottom.Style = ExcelBorderStyle.Thin;
                            border.Left.Color.SetColor(Color.White);
                            border.Right.Color.SetColor(Color.White);
                            border.Top.Color.SetColor(Color.White);
                            border.Bottom.Color.SetColor(Color.White);

                            renglon++;
                        }

                        TimeSpan tiempo = TimeSpan.FromSeconds(entidad.Tiempo);
                        string tiempoFormateado = string.Format("{0:00}:{1:00}:{2:00}:{3:000000}", tiempo.TotalHours, tiempo.Minutes, tiempo.Seconds, tiempo.Milliseconds);

                        var dato = ws.Cells[renglon, 1, renglon, numeroColumna];
                        ws.Cells[renglon, 1].Value = entidad.Lugar.ToString();
                        ws.Cells[renglon, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[renglon, 2].Value = entidad.Numero;
                        ws.Cells[renglon, 3].Value = entidad.Competidor;
                        ws.Cells[renglon, 4].Value = entidad.Distancia;
                        ws.Cells[renglon, 5].Value = entidad.Categoria;
                        ws.Cells[renglon, 6].Value = entidad.Rama;
                        ws.Cells[renglon, 7].Value = tiempoFormateado;

                        dato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        dato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        dato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        dato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        renglon++;
                    }
                }

                package.Save();
                System.Diagnostics.Process.Start(package.File.DirectoryName + "/" + package.File.Name);
            }
        }

        private void ExportarGanadores(int idCarrera, string carrera)
        {
            FileInfo newFile = new FileInfo("Tiempos de " + carrera.ToUpper() + ".xlsx");
            // If any file exists in this directory having name 'Sample1.xlsx', then delete it
            if (newFile.Exists)
            {
                newFile.Delete(); // ensures we create a new workbook
                newFile = new FileInfo("Tiempos de " + carrera.ToUpper() + ".xlsx");
            }

            using (var package = new ExcelPackage(newFile))
            {

                List<CarreraDetalleTiempos> lista = ObtenerListadoGanadores();
                package.Workbook.Worksheets.Add(carrera);
                ExcelWorksheet ws = package.Workbook.Worksheets[1];
                ws.Name = carrera;

                ws.Cells.Style.Font.Size = 10;//Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Arial"; //Default Font name for whole sheet

                int numeroColumna = 1;
                ws.Column(numeroColumna++).Width = 12; //Lugar
                ws.Column(numeroColumna++).Width = 12; //IdCompetidor
                ws.Column(numeroColumna++).Width = 30; //Nombre
                ws.Column(numeroColumna++).Width = 15; //Distancia
                ws.Column(numeroColumna++).Width = 15; //Categoria
                ws.Column(numeroColumna++).Width = 15; //Rama
                ws.Column(numeroColumna).Width = 15; //Tiempo

                ws.Cells[1, 1, 1, numeroColumna].Merge = true;
                ws.Cells[2, 1, 2, numeroColumna].Merge = true;
                ws.Cells[3, 1, 3, numeroColumna].Merge = true;

                ws.Cells[1, 1].Value = "ATLÉTICA SPORTS";
                ws.Cells[1, 1].Style.Font.Bold = true;
                ws.Cells[2, 1].Value = "LOS MOCHIS, SINALOA";
                ws.Cells[3, 1].Value = "GANADORES DE " + carrera.ToUpper();

                var encabezados = ws.Cells[1, 1, 3, numeroColumna];
                encabezados.Style.Font.Bold = true;
                encabezados.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                encabezados.Style.Font.Color.SetColor(Color.White);
                Color colFromHexEncabezado = System.Drawing.ColorTranslator.FromHtml("#333f4f");
                var fillEncabezado = encabezados.Style.Fill;
                fillEncabezado.PatternType = ExcelFillStyle.Solid;
                fillEncabezado.BackgroundColor.SetColor(colFromHexEncabezado);

                //Merging cells and create a center heading for out table
              

                int renglon = 5;

                if (lista != null && lista.Count > 0)
                {
                    foreach (CarreraDetalleTiempos entidad in lista)
                    {
                        if (entidad.Lugar == 1)
                        {
                            if (renglon != 5)
                            {
                                renglon++;
                            }

                            ws.Cells[renglon, 1].Value = "LUGAR";
                            ws.Cells[renglon, 2].Value = "N°";
                            ws.Cells[renglon, 3].Value = "NOMBRE";
                            ws.Cells[renglon, 4].Value = "DISTANCIA";
                            ws.Cells[renglon, 5].Value = "CATEGORIA";
                            ws.Cells[renglon, 6].Value = "RAMA";
                            ws.Cells[renglon, 7].Value = "TIEMPO";
                            var titulos = ws.Cells[renglon, 1, renglon, numeroColumna];
                            titulos.Style.Font.Bold = true;
                            titulos.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            titulos.Style.Font.Color.SetColor(Color.White);
                            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#337AB7");
                            var fill = titulos.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(colFromHex);

                            var border = titulos.Style.Border;
                            border.Left.Style = ExcelBorderStyle.Thin;
                            border.Right.Style = ExcelBorderStyle.Thin;
                            border.Top.Style = ExcelBorderStyle.Thin;
                            border.Bottom.Style = ExcelBorderStyle.Thin;
                            border.Left.Color.SetColor(Color.White);
                            border.Right.Color.SetColor(Color.White);
                            border.Top.Color.SetColor(Color.White);
                            border.Bottom.Color.SetColor(Color.White);

                            renglon++;
                        }

                        TimeSpan tiempo = TimeSpan.FromSeconds(entidad.Tiempo);
                        string tiempoFormateado = string.Format("{0:00}:{1:00}:{2:00}:{3:000000}", tiempo.TotalHours, tiempo.Minutes, tiempo.Seconds, tiempo.Milliseconds);

                        var dato = ws.Cells[renglon, 1, renglon, numeroColumna];
                        ws.Cells[renglon, 1].Value = entidad.Lugar.ToString();
                        ws.Cells[renglon, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[renglon, 2].Value = entidad.Numero;
                        ws.Cells[renglon, 3].Value = entidad.Competidor;
                        ws.Cells[renglon, 4].Value = entidad.Distancia;
                        ws.Cells[renglon, 5].Value = entidad.Categoria;
                        ws.Cells[renglon, 6].Value = entidad.Rama;
                        ws.Cells[renglon, 7].Value = tiempoFormateado;

                        dato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        dato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        dato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        dato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        renglon++;
                    }
                }

                package.Save();
                System.Diagnostics.Process.Start(package.File.DirectoryName + "/" + package.File.Name);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            int idCarrera = cmbCarreras.SelectedIndex > -1 ? Convert.ToInt32(cmbCarreras.SelectedValue) : 0;
            string carrera = ((DataRowView)cmbCarreras.SelectedItem).Row[1].ToString();

            if (chkGanadores.Checked)
            {
                ExportarGanadores(idCarrera, carrera);
            }
            else
            {
                ExportarGeneral(idCarrera, carrera);
            }
            
        }

        private void chkGanadores_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGanadores.Checked)
            {
                txtNumeroGanadores.Enabled = true;
            }
            else
            {
                txtNumeroGanadores.Enabled = false;
            }
        }

        private void chkPorPuntos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPorPuntos.Checked)
            {
                gridDetallesCarrera.Columns[6].Visible = true;
            }
            else
            {
                gridDetallesCarrera.Columns[6].Visible = false;
            }
        }
    }
}
