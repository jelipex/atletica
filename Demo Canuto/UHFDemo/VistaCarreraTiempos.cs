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
    public partial class VistaCarreraTiempos : Form
    {
        public VistaCarreraTiempos()
        {
            InitializeComponent();
            this.FormClosing += VistaCarreraTiempos_FormClosing;
        }

        void VistaCarreraTiempos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globales.GuardarTiemposCarrera = false;
        }

        private void VistaCarreraTiempos_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string chip = " FF 46 70 5C 74 E7 DB FF 07 49 27 11";
            try
            {
                VistaCarreraTiempos vista = new VistaCarreraTiempos();
                DataGridView grid = vista.tablaTiemposCorredores;

                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells[2].Value.ToString().Equals(chip))
                    {
                        if (row.Cells[3].Value.ToString() == "")
                        {
                            row.Cells[3].Value = DateTime.Now.ToString("hh:mm:ss tt");
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
