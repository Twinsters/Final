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
    public partial class FmPrincipal : Form
    {
        BEEmpleado bEEmpleado;
        BLLPerfil bll;
        public FmPrincipal(BEEmpleado obBe)
        {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            InitializeComponent();
            bEEmpleado = new BEEmpleado();
            bEEmpleado = obBe;
            bll = new BLLPerfil();
            bll.AsignarPermisos(obBe.Perfil.Id);
            MostrarPermisos();
          

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void ventaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FmVenta fmVenta = new FmVenta(bEEmpleado);
            fmVenta.ShowDialog();
            this.Hide();
        }

        private void FmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void juegosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmJuego formJuego = new FmJuego(bEEmpleado);
            formJuego.Show();
            this.Hide();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {


            FmInformes fmInformes = new FmInformes(bEEmpleado);
            fmInformes.Show();
            this.Hide();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                FmEmpleado fmEmpleado = new FmEmpleado(bEEmpleado);
                fmEmpleado.Show();
                this.Hide();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmProveedor fmProveedor = new FmProveedor(bEEmpleado);
            fmProveedor.Show();
            this.Hide();
        }
        private void MostrarPermisos()
        {

            // Acciones
            ventaToolStripMenuItem1.Enabled = bEEmpleado.Perfil.TieneAcceso("Venta");
            consultaToolStripMenuItem.Enabled = bEEmpleado.Perfil.TieneAcceso("Informes");
            ComprasToolStripMenuItem.Enabled = bEEmpleado.Perfil.TieneAcceso("Compras");
            dashboardToolStripMenuItem.Enabled = bEEmpleado.Perfil.TieneAcceso("Dashboard");
            // ABM
            juegosToolStripMenuItem.Enabled = bEEmpleado.Perfil.TieneAcceso("Juegos");
            empleadosToolStripMenuItem.Enabled = bEEmpleado.Perfil.TieneAcceso("Empleados");
            proveedoresToolStripMenuItem.Enabled = bEEmpleado.Perfil.TieneAcceso("Proveedores");
            ventasToolStripMenuItem.Enabled = bEEmpleado.Perfil.TieneAcceso("Ventas");
            // Backup
            backupToolStripMenuItem1.Enabled = bEEmpleado.Perfil.TieneAcceso("Backups");
            // Perfil
            perfilToolStripMenuItem1.Enabled = bEEmpleado.Perfil.TieneAcceso("Perfiles");
        }
        private void xMLJuegosPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmJuegosPedidos fmJuegosPedidos = new FmJuegosPedidos(bEEmpleado);
            fmJuegosPedidos.Show();
            this.Hide();

        }
        private void Application_ApplicationExit(object sender, EventArgs e)
        {

         
        }
        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmDashboard fmDashboard = new FmDashboard(bEEmpleado);
            fmDashboard.Show();
            this.Hide();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmVentas fmVentas = new FmVentas(bEEmpleado);
            fmVentas.Show();
            this.Hide();
        }

        private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FmBackup fmBackup = new FmBackup(bEEmpleado);
            fmBackup.Show();
            this.Hide();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void perfilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FmPerfil fmPerfil = new FmPerfil(bEEmpleado);
            fmPerfil.Show();
            this.Hide();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmLogin fmLogin = new FmLogin();
            fmLogin.Show();
            this.Hide();
        }
    }
}
