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
    public partial class FmProveedorGuardar : Form
    {
       
        BEDomicilio bEDomicilio;
        BEProveedor bEProveedor;
        BLLProveedor bLLProveedor;
        BEEmpleado usuario;
        public FmProveedorGuardar(BEEmpleado usu, BEProveedor proveedor = null)
        {
            InitializeComponent();          
            bEProveedor = new BEProveedor();
            bEDomicilio = new BEDomicilio();
            bLLProveedor = new BLLProveedor();
            usuario = new BEEmpleado();
            usuario = usu;
            if (proveedor != null)
            {
                bEProveedor = proveedor;
            }
         
            
        }
        private void FmProveedorGuardar_Load(object sender, EventArgs e)
        {
            if (bEProveedor.Id != 0)
            {
                bEProveedor = bLLProveedor.ListarUno(bEProveedor);
                Asignar();
            }
        }
        bool CapturarDatos()
        {
            bool res = false;
            try
            {
                if (txtSoloNum1.Validar()&& txt_CalleProve.Text !="" && txt_NombreProve.Text !="")
                {                   
                    bEDomicilio.Calle = txt_CalleProve.Text;
                    bEDomicilio.Numero = Convert.ToInt32(txtSoloNum1.Text);
                    bEDomicilio.Localidad = txtLocalidad.Text;
                    if (bEProveedor.Id != 0)
                    {
                        bEProveedor.Domicilio.Calle = bEDomicilio.Calle;
                        bEProveedor.Domicilio.Numero = bEDomicilio.Numero;
                        bEProveedor.Domicilio.Localidad = bEDomicilio.Localidad;
                    }
                    else
                    {
                        bEProveedor.Domicilio = bEDomicilio;
                    }
                    bEProveedor.Nombre = txt_NombreProve.Text;
                    res = true;
                }
                else
                {
                    MessageBox.Show("Error en los campos");
                }               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return res;
        }
        void Asignar()
        {
            txt_NombreProve.Text = bEProveedor.Nombre;
            txt_CalleProve.Text = bEProveedor.Domicilio.Calle;
            txtSoloNum1.Text = bEProveedor.Domicilio.Numero.ToString();
            txtLocalidad.Text = bEProveedor.Domicilio.Localidad; 
        }
        private void btn_GuardarProv_Click(object sender, EventArgs e)
        {
            try
            {
               if(CapturarDatos())
                {

                    if (bLLProveedor.Guardar(bEProveedor,usuario))
                    {
                        MessageBox.Show("Se guardo con exito");
                        FmProveedor fmProveedor = new FmProveedor(usuario);
                        fmProveedor.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
        }
        private void btn_SalirProv_Click(object sender, EventArgs e)
        { 
            FmProveedor fmProveedor = new FmProveedor(usuario);
            fmProveedor.Show();
            this.Hide();
        }
    }
}
