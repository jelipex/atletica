using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UHFDemo
{
    
    public class CarreraDetalle
    {
        public int IdCarrera { get; set; }
        public int IdCarreraDetalle { get; set; }
        public int IdEmpresa { get; set; }
        public int IdCompetidor { get; set; }
        public int IdCategoria { get; set; }
        public string Competidor { get; set; }
        public string Categoria { get; set; }
        public string Chip { get; set; }
        public string Tiempo { get; set; }
    }
}
