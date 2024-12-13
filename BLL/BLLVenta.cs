using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE;
using MPP;
namespace BLL
{
    public class BLLVenta
    {
        MPPVenta mppVenta;
        BLLCliente bLLCliente;
       
        public bool GuardarCompleto(BEVenta obBeVenta, BEEmpleado obBeEmpleado)
        {

            mppVenta = new MPPVenta();
            bLLCliente = new BLLCliente();
            obBeVenta.bECliente = bLLCliente.GuardarYTraer(obBeVenta.bECliente);

            if (obBeVenta.bECliente.Id != 0)
            {

                return mppVenta.GuardarCompleto(obBeVenta, obBeEmpleado);
            }
            else
            {
                return false;
            }
           
        }
        public bool eliminarVentas(int Id, BEEmpleado Usuario)
        {
            mppVenta = new MPPVenta();
            return mppVenta.eliminarVentas(Id, Usuario);
        }

        public BEEmpleado verEmpleado(BEVenta IdVenta)
        {

            mppVenta = new MPPVenta();
            return mppVenta.VerEmpleadoVenta(IdVenta);
        }
        public List<BEVenta> ListarTodo()
        {
            mppVenta = new MPPVenta();
            return mppVenta.ListarTodo();
        }
        public string GananciasDia(int opcion, List<DateTime> rangoFechas = null)
        {
            mppVenta = new MPPVenta();
            return mppVenta.GananciasDia(opcion, rangoFechas);

        }
        public string VentasDiaHoy(int opcion, List<DateTime> rangoFechas = null)
        {
            mppVenta = new MPPVenta();
            return mppVenta.VentasDiaHoy(opcion, rangoFechas);
        }
        public Dictionary<string,int> VentasPorVendedorHoy(int opcion, List<DateTime> rangoFechas = null)
        {
            mppVenta = new MPPVenta();
            return mppVenta.VentasPorVendedor(opcion, rangoFechas);
        }
        public Dictionary<string, int> VentaPorCategoria(int opcion, List<DateTime> rangoFechas = null)
        {
            mppVenta = new MPPVenta();
            return mppVenta.VentaPorCategoria(opcion, rangoFechas);

        }
        public List<BEJuego> ObtenerJuegosConPocoStock()
        {
            mppVenta = new MPPVenta();
            return mppVenta.ObtenerJuegosConPocoStock();
        }
        public IEnumerable<dynamic> TopMasVendidos(int opcion, List<DateTime> rangoFechas = null)
        {
            mppVenta = new MPPVenta();
            return mppVenta.TopMasVendidos(opcion, rangoFechas);
        }

        public List<BEJuego> TopVentas()
        {
            mppVenta = new MPPVenta();
            return mppVenta.TopVentas();
        }
        public List<BEEmpleado> TopVentasEmpleados()
        {
            mppVenta = new MPPVenta();
            return mppVenta.TopVentasEmpleados();
        }
    }
}
