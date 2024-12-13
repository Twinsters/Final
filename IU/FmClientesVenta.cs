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
    public partial class FmClientesVenta : Form
    {
        BEJuego bEjuego; 
        BEPersona bECliente;
        BEEmpleado bEEmpleado;
        public FmClientesVenta(BEJuego oBeJuego, BEEmpleado obBeEmpleado)
        {
            InitializeComponent();
            bEjuego = new BEJuego();
            bECliente = new BEPersona();
            bEEmpleado = new BEEmpleado();
            bEjuego = oBeJuego;
            bEEmpleado = obBeEmpleado;
        }

        private void FmClientesVenta_Load(object sender, EventArgs e)
        {

        }
        bool AsignarDatos()
        {
            bool res = false;
            try
            {
                if(txt_NombreCliente.Text !=""&& txt_ApellidoCliente.Text !="" && soloDNI1.Validar())
                {
                    bECliente.Nombre = txt_NombreCliente.Text;
                    bECliente.Apellido = txt_ApellidoCliente.Text;
                    bECliente.DNI = Convert.ToInt32(soloDNI1.Text);
                    bECliente.FechaNac = dateTimePicker1.Value;
                    bECliente.Edad = bECliente.Calcular_Edad(bECliente.FechaNac);
                    res = true;
                }
                else
                {
                    MessageBox.Show("Error de datos");
                }
        
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return res;

        }
        private void btn_Confirmar_Click(object sender, EventArgs e)
        {       
            try
            {
                if (AsignarDatos())
                {
                    if (bECliente.Edad >= 18)
                    {     
                        FmConfirmacionCompra fmConfirmacionCompra = new FmConfirmacionCompra(bECliente, bEjuego, bEEmpleado);
                        fmConfirmacionCompra.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Es menor de edad");
                    }
                }
            }            
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            FmVenta fmVenta = new FmVenta(bEEmpleado);
            fmVenta.Show();
            this.Hide();
        }
    }
}
