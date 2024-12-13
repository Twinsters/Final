using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Abstracto;
namespace BLL
{
    public class BLLJuego : IGestor<BEJuego>
    {
        MPPJuego mppJuego;
   
        public bool Guardar(BEJuego oBeJuego, BEEmpleado usu)
        {
            mppJuego = new MPPJuego();
            return mppJuego.Guardar(oBeJuego, usu);
        }
        public List<BEJuego> ListarTodo()
        {
            mppJuego = new MPPJuego();
            return mppJuego.ListarTodo();
        }
        public List<BEJuego> buscarJuegos(BEJuego juego)
        {
            mppJuego = new MPPJuego();
            return mppJuego.buscarJuegos(juego);
        }
        public bool Eliminar(BEJuego oBeJuego,BEEmpleado usuario)
        {
            mppJuego = new MPPJuego();
            return mppJuego.Eliminar(oBeJuego, usuario);
        }
        public BEJuego ListarUno(BEJuego oBeJuego)
        {
            mppJuego = new MPPJuego();
            return mppJuego.ListarUno(oBeJuego);
        }
        public bool guardarPedido(BEJuego juegoPedido, BEEmpleado usuario)
        {
            mppJuego = new MPPJuego();
            return mppJuego.guardarPedido(juegoPedido, usuario);
        }
        public IEnumerable<dynamic> traerJuegosPedidos() {

            mppJuego = new MPPJuego();
            return mppJuego.traerJuegosPedidos();
        }
        public IEnumerable<dynamic> traerJuegosPedidosFiltro(BEJuego juego)
        {

            mppJuego = new MPPJuego();
            return mppJuego.traerJuegosPedidosFiltro(juego);
        }
        public bool EliminarReserva(BEJuego oBeJuego, BEEmpleado usuario)
        {
            mppJuego = new MPPJuego();
            return mppJuego.EliminarReserva(oBeJuego, usuario);
        }
        public bool Eliminar(BEJuego obj)
        {
            throw new NotImplementedException();
        }
        public bool Guardar(BEJuego obj)
        {
            throw new NotImplementedException();
        }
    }
}
