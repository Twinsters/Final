using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPersona:BEEntidad
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNac { get; set; }
        public char Estado { get; set; }
        public int Edad { get; set; }

        public BEPersona(string nombre, string apellido, int dNI, DateTime fechaNac, char estado, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dNI;
            FechaNac = fechaNac;
            Estado = estado;
            Edad = edad;
        }
        public BEPersona()
        {

        }
        public int Calcular_Edad(DateTime fechaNac)
        {
            DateTime hoy = DateTime.Now;
            if (fechaNac.Month < hoy.Month)
            {
                Edad = hoy.Year - fechaNac.Year;
            }
            else if (fechaNac.Month == hoy.Month && fechaNac.Day <= hoy.Day)
            {
                Edad = hoy.Year - fechaNac.Year;
            }
            else
            {
                Edad = hoy.Year - fechaNac.Year - 1;
            }
            return Edad;
        }
    }
}
