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
    public partial class FmVenta : Form
    {
        BEJuego beJuego;
        BLLJuego bllJuego;
        BEEmpleado bEEmpleado;
        public FmVenta(BEEmpleado obBeEmpleado)
        {
            InitializeComponent();
            beJuego = new BEJuego();
            bllJuego = new BLLJuego();
            bEEmpleado = new BEEmpleado();
            bEEmpleado = obBeEmpleado;
        }
        private void FmVenta_Load(object sender, EventArgs e)
        {
            CompletarDataGrip(bllJuego.buscarJuegos(beJuego));
            cargarCombos();
            Image imagenAtrasOriginal = Properties.Resources.atras;
            Image imagenAtrasEscalable = new Bitmap(imagenAtrasOriginal, btn_SalirVenta.Size);
            btn_SalirVenta.Image = imagenAtrasEscalable;
            Image imagenBuscarOriginal = Properties.Resources.lupa;
            Image imagenBuscarEscalable = new Bitmap(imagenBuscarOriginal, btnBuscar.Size);
            btnBuscar.Image = imagenBuscarEscalable;          
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
            foreach (string Categoria in Categorias)
            {
                cbCategoria.Items.Add(Categoria);
            }
            cbCategoria.SelectedIndex = 0;
            List<string> Plataformas = new List<string>();
            Plataformas.Add("PC Master Race");
            Plataformas.Add("Play 1");
            Plataformas.Add("Play 3");
            Plataformas.Add("Play 4");
            Plataformas.Add("Play 5");
            Plataformas.Add("XBOX 360");
            Plataformas.Add("XBOX 360");
            Plataformas.Add("XBOX ONE");
            Plataformas.Add("XBOX Series S/X");
            Plataformas.Add("Nintendo Switch");
            Plataformas.Add("Nintendo 3ds");
            Plataformas.Add("Sega");

            foreach (string Plataforma in Plataformas)
            {
                cbPlataforma.Items.Add(Plataforma);
            }
            cbPlataforma.SelectedIndex = 0;
        }

        void CompletarDataGrip(List<BEJuego> ListaJuegos)
        {
            try
            {
                dtgriViewVenta.DataSource = null;
                dtgriViewVenta.Rows.Clear();
                dtgriViewVenta.Columns.Clear();
                dtgriViewVenta.DataSource = ListaJuegos;
                dtgriViewVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dtgriViewVenta.Columns["bEProveedor"].HeaderText = "Proveedor";
                dtgriViewVenta.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
                dtgriViewVenta.Columns["CodEstado"].Visible = false;
                dtgriViewVenta.Columns["bEProveedor"].Visible = false;
                dtgriViewVenta.Columns["Id"].HeaderText = "Codigo";
                dtgriViewVenta.Columns["Id"].DisplayIndex = 0;

                DataGridViewImageColumn btnAcciones = new DataGridViewImageColumn
                {
                    Name = "btnOpciones",
                    HeaderText = "Opciones",
                    Width = 30,
                };
                dtgriViewVenta.Columns.Add(btnAcciones);     
                Image venderImg = Properties.Resources.signo_de_dolar;
                foreach (DataGridViewRow row in dtgriViewVenta.Rows)
                {
                    if (row.IsNewRow) continue;
                    Bitmap cellImage = new Bitmap(30, 25);
                    using (Graphics g = Graphics.FromImage(cellImage))
                    {
                        int width = 30;
                        int height = 25;
                        g.DrawImage(venderImg, new Rectangle(0, 0, width, height));               
                    }
                    row.Cells["btnOpciones"].Value = cellImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgriViewVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgriViewVenta.Columns["btnOpciones"].Index && e.RowIndex >= 0)
            {

                Point clickPos = dtgriViewVenta.PointToClient(MousePosition);
                Rectangle cellRectangle = dtgriViewVenta.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                if (cellRectangle.Contains(clickPos))
                {

                    int xPos = clickPos.X - cellRectangle.Left;

                    if (xPos >= 0 && xPos < 30)
                    {
                        vender(Convert.ToInt32(dtgriViewVenta.Rows[e.RowIndex].Cells["Id"].Value));

                    }
                }
            }
        }
        void vender(int Id)
        {
            try
            {
                beJuego.Id = Id;
                FmClientesVenta fmClientesVenta = new FmClientesVenta(beJuego, bEEmpleado);
                fmClientesVenta.ShowDialog();
                this.Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
      
        private void btn_SalirVenta_Click(object sender, EventArgs e)
        {
            FmPrincipal fmPrincipal = new FmPrincipal(bEEmpleado);
            fmPrincipal.Show();
            this.Hide();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            beJuego.Descripcion = textNombre.Text;
            beJuego.Plataforma = cbPlataforma.Text;
            beJuego.Categoria = cbCategoria.Text;
            CompletarDataGrip(bllJuego.buscarJuegos(beJuego));           
        }
    }
}
