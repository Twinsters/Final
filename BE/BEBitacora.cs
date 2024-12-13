using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBitacora
    {

        public DateTime FechaYHora { get; set; }
        public BEEmpleado Usuario { get; set; }
        public string NombreArchivo { get; set; }
        public string Evento { get; set; }

        public BEBitacora() { }


        public BEBitacora( DateTime fechayHora,BEEmpleado usuairo, string nombreArchivo,string evento) { 
            FechaYHora = fechayHora;
            Usuario = usuairo;
            NombreArchivo = nombreArchivo;
            Evento = evento;

        }

    }
}
