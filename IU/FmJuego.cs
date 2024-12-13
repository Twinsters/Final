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
    public partial class FmJuego : Form
    {
        BEJuego beJuego;
        BLLJuego bllJuego;
        BEEmpleado usuario;
        public FmJuego()
        {
            InitializeComponent();
            beJuego = new BEJuego();
            bllJuego = new BLLJuego();
        }
        public FmJuego(BEEmpleado usu)
        {
            InitializeComponent();
            beJuego = new BEJuego();
            bllJuego = new BLLJuego();
            usuario = new BEEmpleado();
            usuario = usu;
        }
        private void FormJuego_Load(object sender, EventArgs e)
        {
            CompletarDataGrip(bllJuego.ListarTodo());
            Image imagenAtrasOriginal = Properties.Resources.atras;
            Image imagenAtrasEscalable = new Bitmap(imagenAtrasOriginal, btnAtrasJuego.Size);
            btnAtrasJuego.Image = imagenAtrasEscalable;
            Image imagenNuevoOriginal = Properties.Resources.agregar;
            Image imagenNuevoEscalable = new Bitmap(imagenNuevoOriginal, btnAltaJuego.Size);
            btnAltaJuego.Image = imagenNuevoEscalable;
            Image imagenBuscarOriginal = Properties.Resources.agregar;
            Image imagenBuscarEscalable = new Bitmap(imagenBuscarOriginal, btnBuscar.Size);
            btnBuscar.Image = imagenBuscarEscalable;
            cargarCombos();
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



        void CompletarDataGrip(List<BEJuego> buscar)
        {
            try
            {
                dtViGripJuegos.DataSource = null;
                dtViGripJuegos.Rows.Clear();
                dtViGripJuegos.Columns.Clear();
                dtViGripJuegos.DataSource = buscar;
                if (dtViGripJuegos.DataSource != null)
                {
                    dtViGripJuegos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; 
                    dtViGripJuegos.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
                    dtViGripJuegos.Columns["bEProveedor"].HeaderText = "Proveedor";
                    dtViGripJuegos.Columns["CodEstado"].Visible = false;
                    dtViGripJuegos.Columns["Id"].HeaderText = "Codigo";
                    dtViGripJuegos.Columns["Id"].DisplayIndex = 0;

                    DataGridViewImageColumn btnAcciones = new DataGridViewImageColumn
                    {
                        Name = "btnOpciones",
                        HeaderText = "Opciones",
                        Width = 60,
                    };
                    dtViGripJuegos.Columns.Add(btnAcciones);
                    Image eliminarImg = Properties.Resources.eliminar;
                    Image modificarImg = Properties.Resources.editar;
                    foreach (DataGridViewRow row in dtViGripJuegos.Rows)
                    {
                        if (row.IsNewRow) continue;
                        Bitmap cellImage = new Bitmap(60, 25);
                        using (Graphics g = Graphics.FromImage(cellImage))
                        {
                            int width = 30;
                            int height = 25;
                            g.DrawImage(modificarImg, new Rectangle(0, 0, width, height));
                            g.DrawImage(eliminarImg, new Rectangle(width, 0, width, height));
                        }
                        row.Cells["btnOpciones"].Value = cellImage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtViGripJuegos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtViGripJuegos.Columns["btnOpciones"].Index && e.RowIndex >= 0)
                {
                    Point clickPos = dtViGripJuegos.PointToClient(MousePosition);
                    Rectangle cellRectangle = dtViGripJuegos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    if (cellRectangle.Contains(clickPos))
                    {
                        int xPos = clickPos.X - cellRectangle.Left;

                        if (xPos >= 0 && xPos < 30)
                        {
                            modificarVenta(Convert.ToInt32(dtViGripJuegos.Rows[e.RowIndex].Cells["Id"].Value));
                        }
                        else if (xPos >= 30 && xPos < 60)
                        {
                            eliminarVenta(Convert.ToInt32(dtViGripJuegos.Rows[e.RowIndex].Cells["Id"].Value));
                        }
                    }
                }
            }            
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            } 

        }
        private void btnAltaJuego_Click(object sender, EventArgs e)
        {
            FmJuegosGuardar fmjuesgosForm = new FmJuegosGuardar(usuario);
            fmjuesgosForm.ShowDialog();
            this.Hide();
        }
        void modificarVenta(int Id)
        {
            try
            {
                beJuego.Id = Id;
                FmJuegosGuardar fmjuesgosForm = new FmJuegosGuardar(beJuego, usuario);
                fmjuesgosForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void eliminarVenta(int Id)
        {
            try
            {
                BEJuego juego = new BEJuego();
                juego.Id = Id;
                var res = MessageBox.Show("Esta seguro que desea eliminar el juego de la lista?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    if (bllJuego.Eliminar(juego, usuario))
                    {
                        MessageBox.Show("Eliminado con exito");
                        CompletarDataGrip(bllJuego.ListarTodo());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAtrasJuego_Click(object sender, EventArgs e)
        {
            FmPrincipal fmPrincipal = new FmPrincipal(usuario);
            fmPrincipal.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            beJuego.Descripcion = txtNombre.Text;
            beJuego.Plataforma = cbPlataforma.Text;
            beJuego.Categoria = cbCategoria.Text;
            CompletarDataGrip(bllJuego.buscarJuegos(beJuego));
        }
    }
}
