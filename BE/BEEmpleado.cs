using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEEmpleado : BEPersona
    {
        public BEDomicilio oDom{get;set;}
        public BEPerfil Perfil { get; set; }
        public string Pass { get; set; }
        public BEEmpleado()
        {

        }
        public BEEmpleado(string nombre, string apellido, int dNI, BEDomicilio p_oDom, DateTime fechaNac, char codEstado, BEPerfil perfil, string pass)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dNI;
            oDom = p_oDom;
            FechaNac = fechaNac;
            Estado = codEstado;
            Perfil = perfil;
            Pass = pass;
        }
        public override string ToString()
        {
            return this.Apellido + " " + this.Nombre;
        }
    }
}
