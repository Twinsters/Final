using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracto;
namespace BE
{
    public class BEJuego:BEEntidad
    {
        public string Descripcion { get; set; } 
        public string Categoria { get; set; }   
        public decimal Precio { get; set; } 
        public BEProveedor bEProveedor { get; set; }    
        public int Stock { get; set; }
        public char CodEstado { get; set; }
        public string Plataforma { get; set; }

        public BEJuego() { }
    }
}
