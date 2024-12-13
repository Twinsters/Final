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
    public partial class FmPerfil : Form
    {
        BEPerfil bePerfil;
        BLLPerfil bllPerfil;
        BEEmpleado Usuario;
        public FmPerfil(BEEmpleado beEmpleado)
        {
            InitializeComponent();
            bePerfil = new BEPerfil();
            bllPerfil = new BLLPerfil();
            Usuario = new BEEmpleado();
            Usuario = beEmpleado;
            Image imagenEliminarOriginal = Properties.Resources.eliminar;
            Image imagenEliminarEscalable = new Bitmap(imagenEliminarOriginal, btnEliminar.Size);
            btnEliminar.Image = imagenEliminarEscalable;
            Image imagenAtrasOriginal = Properties.Resources.atras;
            Image imagenAtrasEscalable = new Bitmap(imagenAtrasOriginal, btnAtras.Size);
            btnAtras.Image = imagenAtrasEscalable;
            Image imagenGuardarOriginal = Properties.Resources.agregar;
            Image imagenGuardarEscalable = new Bitmap(imagenGuardarOriginal, btnGuardar.Size);
            btnGuardar.Image = imagenGuardarEscalable;
        }
        public FmPerfil()
        {
            InitializeComponent();
            bePerfil = new BEPerfil();
            bllPerfil = new BLLPerfil();        
            Image imagenEliminarOriginal = Properties.Resources.eliminar;
            Image imagenEliminarEscalable = new Bitmap(imagenEliminarOriginal, btnEliminar.Size);
            btnEliminar.Image = imagenEliminarEscalable;
            Image imagenAtrasOriginal = Properties.Resources.atras;
            Image imagenAtrasEscalable = new Bitmap(imagenAtrasOriginal, btnAtras.Size);
            btnAtras.Image = imagenAtrasEscalable;
            Image imagenGuardarOriginal = Properties.Resources.agregar;
            Image imagenGuardarEscalable = new Bitmap(imagenGuardarOriginal, btnGuardar.Size);
            btnGuardar.Image = imagenGuardarEscalable;
        }
        private void rbExistente_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExistente.Checked)
            {
                cbExistente.Enabled = true;
                txtNuevoPerfil.Enabled = false;
                btnEliminar.Enabled = true;
                txtNuevoPerfil.Text = "";
                cargarDatos();
            }
        }
        private void rbNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNuevo.Checked)
            {
                cbExistente.Enabled = false; 
                btnEliminar.Enabled = false;
                txtNuevoPerfil.Enabled = true;
                txtNuevoPerfil.Text = "";
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<Permiso> permisos = new List<Permiso>();
            try
            { 
                foreach (Control control in groupBox1.Controls)
                {
                    Permiso permiso = new Permiso();
                    if (control is CheckBox checkBox && checkBox.Checked)
                    {
                        string textoCheckBox = checkBox.Text;
                        permiso.Nombre = textoCheckBox;
                        permisos.Add(permiso);
                    }
                }
                if (rbExistente.Checked)
                {
                    KeyValuePair<int, string> perfilSeleccionado = (KeyValuePair<int, string>)cbExistente.SelectedItem;
                    bePerfil.Id = perfilSeleccionado.Key;
                    bePerfil.Tipo = perfilSeleccionado.Value;
                    txtNuevoPerfil.Text = "";
                }
                else if(rbNuevo.Checked && txtNuevoPerfil.Text != "")
                {
                    bePerfil.Tipo = txtNuevoPerfil.Text;
                    txtNuevoPerfil.Text = "";
                }   
                bePerfil.Permisos = permisos;
                if (bllPerfil.Guardar(bePerfil, Usuario))
                {
                    cargarDatos();
                    MessageBox.Show("Se guardo correctamente");
                }
                else
                {
                    MessageBox.Show("Error al guardar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void cargarDatos()
        {
            try
            {
                List<BEPerfil> listaPerfiles = bllPerfil.buscarPerfiles();
                if (listaPerfiles.Count > 0)
                {
                    cbExistente.Items.Clear();
                    foreach (BEPerfil perfil in listaPerfiles)
                    {
                        KeyValuePair<int, string> item = new KeyValuePair<int, string>(perfil.Id, perfil.Tipo);
                        cbExistente.Items.Add(item);
                    }
                    cbExistente.DisplayMember = "Value";
                    cbExistente.ValueMember = "Key";
                    cbExistente.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void cbExistente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExistente.SelectedItem != null)
            {
                KeyValuePair<int, string> selectedItem = (KeyValuePair<int, string>)cbExistente.SelectedItem;
                int perfilId = selectedItem.Key;
                List<Permiso> permisos = bllPerfil.buscarPermisos(perfilId);
                foreach (Control control in groupBox1.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        if (permisos.Any(p => p.Nombre == checkBox.Text))
                        {
                            checkBox.Checked = true;
                        }
                        else
                        {
                            checkBox.Checked = false;
                        }
                    }
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                KeyValuePair<int, string> selectedItem = (KeyValuePair<int, string>)cbExistente.SelectedItem;
                int perfilId = selectedItem.Key;
                if(bllPerfil.eliminarPerfil(perfilId, Usuario))
                {
                    cargarDatos();
                    MessageBox.Show("Se elimino correctamente");
                }
                else
                {
                    MessageBox.Show("Error al eliminar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FmPrincipal fmPrincial = new FmPrincipal(Usuario);
            fmPrincial.Show();
            this.Close();
        }
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
