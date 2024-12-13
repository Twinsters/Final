using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BE;
using BLL;
namespace Integrador_2
{
    public partial class FmBuscarJuegosXML : Form
    {
        BEEmpleado bEEmpleado;
        List<dynamic> listJuegos;
        BLLJuego bLLJuego;
        BEJuego juego;
        public FmBuscarJuegosXML(BEEmpleado oBEEmpleado)
        {
            InitializeComponent();
            bEEmpleado = new BEEmpleado();
            bEEmpleado = oBEEmpleado;
            listJuegos = new List<dynamic>();
            bLLJuego = new BLLJuego();
            juego = new BEJuego();
            CargarCombos();

        }
        void CargarCombos()
        {
            List<string> Categorias = new List<string>();
            Categorias.Add("Accion");
            Categorias.Add("Aventura");
            Categorias.Add("RPG");
            Categorias.Add("Lucha");
            Categorias.Add("Deporte");
            Categorias.Add("Estrategia");
            Categorias.Add("Simulacion");


            foreach (string Categoria in Categorias)
            {
                cb_CatbXLM.Items.Add(Categoria);
             

            }
            cb_CatbXLM.SelectedIndex = 0;
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

            foreach (string Plataforma in Plataformas)
            {
                cb_PlatabXML.Items.Add(Plataforma);
              
            }
            cb_PlatabXML.SelectedIndex=0;
        }

        private void btn_BuscarjXML_Click(object sender, EventArgs e)
        {
            try
            {
                juego.Plataforma = cb_PlatabXML.Text;
                juego.Categoria = cb_CatbXLM.Text;
                listJuegos = (List<dynamic>)bLLJuego.traerJuegosPedidosFiltro(juego);
                FmJuegosPedidos fmJuegosPedidos = new FmJuegosPedidos(bEEmpleado, listJuegos);
                fmJuegosPedidos.Show();
                this.Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
            
           
        }
        private void btn_SalirBJuegosXML_Click(object sender, EventArgs e)
        {
            FmJuegosPedidos fmJuegosPedidos = new FmJuegosPedidos(bEEmpleado);
            fmJuegosPedidos.Show();
            this.Hide();
        }
    }
}
