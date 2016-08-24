using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UHFDemo.Entidades
{
    class Ciudad
    {
        public string IdPais { get; set; }
        public int IdEstado { get; set; }
        public int IdCiudad { get; set; }
        public string Descripcion { get; set; }

        public Ciudad(string idPais, int idEstado, int idCiudad, string descripcion)
        {
            IdPais = idPais;
            IdEstado = idEstado;
            IdCiudad = idCiudad;
            Descripcion = descripcion;
        }
    }
}
