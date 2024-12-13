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
using DB;
namespace Integrador_2
{
    public partial class UC_Log : UserControl
    {
        BEEmpleado beeEmp;
        BLLEmpleado bllEmp;

        public UC_Log()
        {
            InitializeComponent();
            beeEmp = new BEEmpleado();
            bllEmp = new BLLEmpleado();
        }
        private void btn_IngresarLogin_Click(object sender, EventArgs e)
        {
           
           
            
            try
            {
                if (soloDNI1.Validar() && txt_PassLogin.Text != "")
                {
                    beeEmp.DNI = Convert.ToInt32(soloDNI1.Text);
                    beeEmp.Pass = txt_PassLogin.Text;
                    beeEmp = bllEmp.ListarUno(beeEmp);

                    if (beeEmp.Id != 0)
                    {   
                        FmPrincipal fmPrincipal = new FmPrincipal(beeEmp);
                        fmPrincipal.Show();
                        this.Parent.Hide();
                        
                    }
                    else
                    {
                        MessageBox.Show("No existe");
                    }
                }
                else
                {
                    MessageBox.Show("El usuario tiene que ser su DNI");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
        }

        private void btn_SalirLogin_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }




}
