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
    public partial class FmInformes : Form
    {
        BEEmpleado bEEmpleado;
        BLLEmpleado bLLEmpleado;
        public FmInformes(BEEmpleado obBeEmpleado)
        {
            InitializeComponent();
            bEEmpleado = new BEEmpleado();
            bLLEmpleado = new BLLEmpleado();
            bEEmpleado = obBeEmpleado;

        }
        private void btn_BuscarReporte_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (radioButton1.Checked)
                {
                   
                    FmJuegosVendidos fmJuegosVendidos = new FmJuegosVendidos();
                    fmJuegosVendidos.ShowDialog();
                }
                else if (radioButton2.Checked)
                {
                    FmEmpleadosMasVentas fmEmpleadosMasVentas = new FmEmpleadosMasVentas();
                    fmEmpleadosMasVentas.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Error");
                }

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            FmPrincipal fmPrincipal = new FmPrincipal(bEEmpleado);
            fmPrincipal.Show();
            this.Hide();
        }

        private void FmInformes_Load(object sender, EventArgs e)
        {

           
        }
    }
}
