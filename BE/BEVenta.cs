using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEVenta:BEEntidad
    {
        public BEPersona bECliente { get; set; }
        public BEJuego bEJuego { get; set; }
        public DateTime FechaCompra { get; set; }
        public char Estado { get; set; }   
        public decimal Pago { get; set; }
        public BEVenta(BEPersona bECliente, BEJuego bEJuego, DateTime fechaCompra, char estado, decimal pago)
        {
            this.bECliente = bECliente;
            this.bEJuego = bEJuego;
            FechaCompra = fechaCompra;
            Estado = estado;
            Pago = pago;
        }
        public BEVenta() { }


    }
}
