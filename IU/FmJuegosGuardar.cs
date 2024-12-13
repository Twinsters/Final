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
using BE;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Integrador_2
{
    public partial class FmJuegosGuardar : Form
    {
        BLLProveedor bLLProveedor;
        BLLJuego bLLJuego;
        BEProveedor bEProveedor;
        BEJuego bEJuego;
        BEEmpleado usuario;

        public FmJuegosGuardar(BEJuego obeJuego,BEEmpleado usu)
        {
            InitializeComponent();
            bLLProveedor = new BLLProveedor();
            bEProveedor = new BEProveedor();
            bEJuego = new BEJuego();
            bEJuego = obeJuego;
            bLLJuego = new BLLJuego();
            usuario = new BEEmpleado();
            usuario = usu;
        }
        public FmJuegosGuardar(BEEmpleado usu)
        {
            InitializeComponent();
            bLLProveedor = new BLLProveedor();
            bEProveedor = new BEProveedor();
            bEJuego = new BEJuego();
            bLLJuego = new BLLJuego();
            usuario = new BEEmpleado();
            usuario = usu;
        }

        private void FormJuegosFormulario_Load(object sender, EventArgs e)
        {
            try
            {
                cargarCombos();
                if (bEJuego.Id != 0)
                {
                    bEJuego = bLLJuego.ListarUno(bEJuego);
                    txt_NombreJuegoF.Text = bEJuego.Descripcion;
                    cBox_CategoriaF.Text = bEJuego.Categoria;
                    cBox_PlataformaF.Text = bEJuego.Plataforma;
                    txtDecimales1.Text = bEJuego.Precio.ToString(CultureInfo.InvariantCulture);
                    txtSoloNum1.Text = bEJuego.Stock.ToString();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
        }
        void cargarCombos()
        {
            List<string> Categorias = new List<string>();
            Categorias.Add("Accion");
            Categorias.Add("Aventura");
            Categorias.Add("RPG");
            Categorias.Add("Lucha");
            Categorias.Add("Deporte");
            Categorias.Add("Estrategia");
            Categorias.Add("Simulacion");
            foreach(string Categoria in Categorias)
            {
                cBox_CategoriaF.Items.Add(Categoria);
                
            }
            cBox_CategoriaF.SelectedIndex = 0;
            List<string> Plataformas = new List<string>();
            Plataformas.Add("PC Master Race");
            Plataformas.Add("Play 1");
            Plataformas.Add("Play 3");
            Plataformas.Add("Play 4");
            Plataformas.Add("Play 5");
            Plataformas.Add("XBOX 360");
            Plataformas.Add("XBOX ONE");
            Plataformas.Add("XBOX Series S/X");
            Plataformas.Add("Nintendo Switch");
            Plataformas.Add("Nintendo 3ds");
            Plataformas.Add("Sega");

            foreach(string Plataforma in Plataformas)
            {
                cBox_PlataformaF.Items.Add(Plataforma);
            }
            cBox_PlataformaF.SelectedIndex = 0;
            cBox_ProveedorF.DataSource = bLLProveedor.ListarTodo();
            cBox_ProveedorF.DisplayMember = "Nombre";
            cBox_ProveedorF.ValueMember = "Id";
            cBox_ProveedorF.SelectedIndex = 0;
        }
        bool AsignarDatos()
        {
            bool res = false;
            try
            {
                if (txtDecimales1.Validar() && txtSoloNum1.Validar()  && txt_NombreJuegoF.Text != "" && cBox_CategoriaF.Text != "" && cBox_PlataformaF.Text != "")
                {
                    string numeroConComa = txtDecimales1.Text;
                    string numeroConPunto = numeroConComa.Replace(".", ",");

                    bEJuego.Descripcion = txt_NombreJuegoF.Text;
                    bEJuego.Categoria = cBox_CategoriaF.Text;
                    bEJuego.Plataforma = cBox_PlataformaF.Text;
                    bEJuego.Precio = Convert.ToDecimal(numeroConPunto);
                    bEJuego.Stock = Convert.ToInt32(txtSoloNum1.Text);
                    bEProveedor = (BEProveedor)cBox_ProveedorF.SelectedItem;
                    bEJuego.bEProveedor = bEProveedor;
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

        private void btn_GuardarJuego_Click(object sender, EventArgs e)
        {
            try
            {
                if (AsignarDatos())
                {
                    if (bLLJuego.Guardar(bEJuego,usuario))
                    {
                        MessageBox.Show("Guardado con exito");
                        FmJuego formJuego = new FmJuego(usuario);
                        formJuego.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar con exito");
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_SalirJuegoGuar_Click(object sender, EventArgs e)
        {
            FmJuego fmJuego = new FmJuego(usuario);
            fmJuego.Show();
            this.Hide();
        }
    }
}
