using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
namespace Integrador_2
{
    public partial class FmJuegosVendidos : Form
    {
        
        BLLVenta bllJuego;
        public FmJuegosVendidos()
        {
            InitializeComponent();
            bllJuego = new BLLVenta();
        }
        private void FmJuegosVendidos_Load(object sender, EventArgs e)
        {
  
            
            this.reportViewer1.LocalReport.DataSources[0].Value = bllJuego.TopVentas();
            this.reportViewer1.RefreshReport();
            
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
