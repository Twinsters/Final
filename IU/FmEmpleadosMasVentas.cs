using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace Integrador_2
{
    public partial class FmEmpleadosMasVentas : Form
    {
        
        BLLVenta bLLVenta;
        public FmEmpleadosMasVentas()
        {
            InitializeComponent();
            bLLVenta = new BLLVenta();
        }
        

        private void FmEmpleadosMasVentas_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources[0].Value = bLLVenta.TopVentasEmpleados();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
