using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBackup
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

        public BEBackup(string nombre, DateTime fechaCreacion)
        {
            Nombre = nombre;
            FechaCreacion = fechaCreacion;
        }
        public BEBackup()
        {

        }
    }
}
