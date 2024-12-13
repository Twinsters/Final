using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using BE;
using BLL;
namespace Integrador_2
{
    public partial class FmJuegosPedidos : Form
    {
        BEEmpleado usuario;
        BLLJuego bllJuego;
        BEJuego beJuegoReservado;
        List<dynamic> listaDeBus;
        Image eliminarImg = Properties.Resources.eliminar;
        public FmJuegosPedidos(BEEmpleado usu)
        {
            InitializeComponent();
            usuario = new BEEmpleado();
            usuario = usu;
            bllJuego = new BLLJuego();
            beJuegoReservado = new BEJuego();
            CargarDatos();
            
        }
        public FmJuegosPedidos(BEEmpleado usu, List<dynamic> listaDeBusqueda = null)
        {
            InitializeComponent();
            usuario = new BEEmpleado();
            usuario = usu;
            bllJuego = new BLLJuego();
            beJuegoReservado = new BEJuego();
            listaDeBus = listaDeBusqueda;
            CargarDatos();

        }
        public FmJuegosPedidos(List<dynamic> listaDeBusqueda = null)
        {
            InitializeComponent();
            usuario = new BEEmpleado();
            bllJuego = new BLLJuego();
            beJuegoReservado = new BEJuego();
            listaDeBus = listaDeBusqueda;
            CargarDatos();

        }
        public FmJuegosPedidos()
        {
            InitializeComponent();
            usuario = new BEEmpleado();
           
            bllJuego = new BLLJuego();
            beJuegoReservado = new BEJuego();
            CargarDatos();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            AgregarJuego();
        }

        private void FmJuegosPedidos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarCombos();
            Image imagenAtrasOriginal = Properties.Resources.atras;
          
            Image imagenAtrasEscalable = new Bitmap(imagenAtrasOriginal, btnSalir.Size);
            btnSalir.Image = imagenAtrasEscalable;
            cargarImgen();


        }
        void cargarImgen()
        {
            foreach (DataGridViewRow row in dataGribJuegosPedidos.Rows)
            {
                if (row.IsNewRow) continue;
                Bitmap cellImage = new Bitmap(30, 25);
                using (Graphics g = Graphics.FromImage(cellImage))
                {
                    int width = 30;
                    int height = 25;
                    g.DrawImage(eliminarImg, new Rectangle(0, 0, width, height));

                }
                row.Cells["btnOpciones"].Value = cellImage;
            }
        }
        void modificarDataGrib()
        {
            dataGribJuegosPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGribJuegosPedidos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGribJuegosPedidos.Columns["Id"].DisplayIndex = 0;
            dataGribJuegosPedidos.Columns["Id"].HeaderText = "Codigo";
            dataGribJuegosPedidos.Columns["Cod_Estado"].Visible = false;
            dataGribJuegosPedidos.Columns["FechaPedido"].HeaderText = "Fecha Pedido";
            dataGribJuegosPedidos.Columns["Descripcion"].HeaderText = "Nombre";

            DataGridViewImageColumn btnAcciones = new DataGridViewImageColumn
            {
                Name = "btnOpciones",
                HeaderText = "Opciones",
                Width = 30,
            };
            dataGribJuegosPedidos.Columns.Add(btnAcciones);
            cargarImgen();
        }
            
        void CargarDatos()
        {

            
            dataGribJuegosPedidos.DataSource = null;
            dataGribJuegosPedidos.Rows.Clear();
            dataGribJuegosPedidos.Columns.Clear();
            if (listaDeBus == null && bllJuego.traerJuegosPedidos().Count()>0)
            {
                dataGribJuegosPedidos.DataSource = bllJuego.traerJuegosPedidos();
                modificarDataGrib();
            }
            else if(listaDeBus != null && listaDeBus.Count > 0 )
            {
                dataGribJuegosPedidos.DataSource = listaDeBus;
                modificarDataGrib();
            }
            else
            {
                dataGribJuegosPedidos.DataSource = null;
            }
           
         

        }
        private void dataGribJuegosPedidos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGribJuegosPedidos.Columns["btnOpciones"].Index && e.RowIndex >= 0)
            {
                Point clickPos = dataGribJuegosPedidos.PointToClient(MousePosition);
                Rectangle cellRectangle = dataGribJuegosPedidos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                if (cellRectangle.Contains(clickPos))
                {
                    int xPos = clickPos.X - cellRectangle.Left;

                    if (xPos >= 0 && xPos < 50)
                    {
                        eliminarPedido(Convert.ToInt32(dataGribJuegosPedidos.Rows[e.RowIndex].Cells["Id"].Value));
                    }
                }
            }
        }
        void eliminarPedido(int id)
        {
            BEJuego juegoEliminar = new BEJuego();
            juegoEliminar.Id = id;
            var res = MessageBox.Show("Esta seguro que desea eliminar el juego de la lista?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                if (bllJuego.EliminarReserva(juegoEliminar, usuario))
                {
                    MessageBox.Show("Eliminado con exito");
                    CargarDatos();
                }
            }

           
           
           
        }
        void CargarCombos()
        {
            try
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
                    cbCategoriaJ.Items.Add(Categoria);
                }
                cbCategoriaJ.SelectedIndex = 0;
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
                    cbPlataformaJ.Items.Add(Plataforma);
                }
                cbPlataformaJ.SelectedIndex = 0;
            }
            catch (Exception ex)            {
                MessageBox.Show(ex.Message);
            }           
        }
        void AgregarJuego()
        {
            try
            {
                beJuegoReservado.Descripcion = txtNombreJ.Text;
                beJuegoReservado.Plataforma = cbPlataformaJ.Text;
                beJuegoReservado.Categoria = cbCategoriaJ.Text;
                beJuegoReservado.Stock = Convert.ToInt32(txtSoloNum1.Text);
                bllJuego.guardarPedido(beJuegoReservado,usuario);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }
        private void btn_BuscarXml_Click(object sender, EventArgs e)
        {
            FmBuscarJuegosXML fmBuscarJuegosXML = new FmBuscarJuegosXML(usuario);
            fmBuscarJuegosXML.ShowDialog();
            this.Hide();
        }
        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            listaDeBus = null;
            CargarDatos();

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            FmPrincipal fmPrincipal = new FmPrincipal(usuario);
            fmPrincipal.Show();
            this.Hide();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            FmReporteJuegosPedidos fmReporteJuegosPedidos = new FmReporteJuegosPedidos();
            fmReporteJuegosPedidos.ShowDialog();
        }
    }
}
