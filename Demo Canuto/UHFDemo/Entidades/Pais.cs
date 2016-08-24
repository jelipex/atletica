using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UHFDemo.Entidades
{
    public class Pais
    {
        public string IdPais { get; set; }
        public string Descripcion { get; set; }

        public Pais()
        {

        }

        public Pais(string idPais, string descripcion)
        {
            IdPais = idPais;
            Descripcion = descripcion;
        }
    }
}
