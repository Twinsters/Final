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
    public partial class FmConfirmacionCompra : Form
    {
        BEPersona bECliente;
        BEJuego bEJuego;
        BEEmpleado Usuario;
        BLLJuego bllJuego;
        BEVenta beVenta;
        BLLVenta bLLVenta;
        
        public FmConfirmacionCompra(BEPersona oBeCliente,BEJuego oBeJuego, BEEmpleado obBeEmpleado)
        {
            InitializeComponent();
            bECliente = new BEPersona();
            bllJuego = new BLLJuego();
            bEJuego = new BEJuego();
            Usuario = new BEEmpleado();
            Usuario = obBeEmpleado;
            bECliente = oBeCliente;
            bEJuego = oBeJuego;
           
            beVenta = new BEVenta();
            bLLVenta = new BLLVenta();
        }

        private void FmConfirmacionCompra_Load(object sender, EventArgs e)
        {
            bEJuego = bllJuego.ListarUno(bEJuego);
            CargarDatos();
        }

        void CargarDatos()
        {
            try
            {
                
                label2.Text = bEJuego.Descripcion;
                label4.Text = bEJuego.Plataforma;
                label6.Text = bEJuego.Precio.ToString();
             
                label10.Text = bECliente.Nombre + " " + bECliente.Apellido;
                label12.Text = bECliente.DNI.ToString();
                label14.Text = bECliente.FechaNac.ToString("dd-MM-yyyy");
                label16.Text = bEJuego.Precio.ToString();

            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }
        void AsignarDatos()
        {
            beVenta.Pago = Convert.ToDecimal(label16.Text);
            beVenta.bEJuego = bEJuego;
            beVenta.bECliente = bECliente;
            DateTime hoy = DateTime.Today;
            beVenta.FechaCompra = hoy;
        }
        private void btn_ConfirmarRes_Click(object sender, EventArgs e)
        {
            try
            {
                AsignarDatos();
                if (bLLVenta.GuardarCompleto(beVenta, Usuario))
                {
                    MessageBox.Show("Se guardo Con Exito");
                    FmVenta fmVenta = new FmVenta(Usuario);
                    fmVenta.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Fallo Con exito");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_CancelarResum_Click(object sender, EventArgs e)
        {
            FmVenta fmVenta = new FmVenta(Usuario);
            fmVenta.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
