using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UHFDemo.Entidades
{
    public class CarreraDetalleTiempos
    {
        public int IdEmpresa { get; set; }
        public int IdCarrera { get; set; }
        public int IdCarreraDetalle { get; set; }
        public int Id { get; set; }
        public int IdCompetidor { get; set; }
        public string Competidor { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public int IdDistancia { get; set; }
        public string Distancia { get; set; }
        public int IdPunto { get; set; }
        public string Punto { get; set; }
        public string Rama { get; set; }
        public DateTime FechaHora { get; set; }
        public double Tiempo { get; set; }

        public CarreraDetalleTiempos()
        {

        }
    }
}
