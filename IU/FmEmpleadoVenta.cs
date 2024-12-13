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
namespace Integrador_2
{
    public partial class FmEmpleadoVenta : Form
    {
        BEEmpleado empleado;
        public FmEmpleadoVenta(BEEmpleado bEEmpleado)
        {
            InitializeComponent();
            empleado = new BEEmpleado();
            empleado = bEEmpleado;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FmEmpleadoVenta_Load(object sender, EventArgs e)
        {
            lbCodigo.Text = "Codigo de Empleado = " + empleado.Id.ToString();
            lbNombreApellido.Text = empleado.Apellido + " " + empleado.Nombre;
            lbDNI.Text = empleado.DNI.ToString();
        }
    }
}
