using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEProveedor : BEEntidad
    {
        public string Nombre { get; set; }
        public BEDomicilio Domicilio { get; set; }
        public char CodEstado { get; set; }

        public BEProveedor()
        {

        }
        public BEProveedor(string nombre, BEDomicilio domicilio, char codEstado)
        {
            Nombre = nombre;
            Domicilio = domicilio;
            CodEstado = codEstado;
        }


        public override string ToString()
        {
            return Id + " " + Nombre;
        }
    }
}
