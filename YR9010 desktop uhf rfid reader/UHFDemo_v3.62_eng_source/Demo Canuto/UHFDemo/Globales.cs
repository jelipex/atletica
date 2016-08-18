using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UHFDemo
{
    public static class Globales
    {
        public static string chipActual { get; set; }
        public static bool capturaCarrera { get; set; }
        public static bool GuardarTiemposCarrera = false;
        public static string chip
        {
            get
            {
                // Reads are usually simple
                return chipActual;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                chipActual = value;
            }
        }
    }
}
