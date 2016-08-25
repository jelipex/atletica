using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UHFDemo.Entidades
{
    public class Estado
    {
        public string IdPais { get; set; }
        public int IdEstado { get; set; }
        public string Descripcion { get; set; }

        public Estado(string idPais, int idEstado, string descripcion)
        {
            IdPais = idPais;
            IdEstado = idEstado;
            Descripcion = descripcion;
        }
    }
}
