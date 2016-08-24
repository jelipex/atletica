using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UHFDemo.Entidades
{
    class CarreraPuntos
    {
        public int IdEmpresa { get; set; }
        public int IdCarrera { get; set; }
        public int IdPunto { get; set; }
        public double Intervalo { get; set; }

        public CarreraPuntos()
        {

        }

        public CarreraPuntos(int idEmpresa, int idCarrera, int idPunto, double intervalo)
        {
            IdEmpresa = idEmpresa;
            IdCarrera = idCarrera;
            IdPunto = idPunto;
            Intervalo = intervalo;
        }
    }
}
