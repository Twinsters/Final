using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEDomicilio:BEEntidad
    {
        public string Calle { get; set; }
        
        public int Numero { get; set; } 

        public string Localidad { get; set; }

        public BEDomicilio(string calle, int numero, string localidad)
        {
            Calle = calle;
            Numero = numero;
            Localidad = localidad;
        }
        public BEDomicilio() { }

        public override string ToString()
        {
            return  Calle +" "+ Numero + " " + Localidad;
        }
    }
}
