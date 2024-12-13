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
namespace Integrador_2
{
    public partial class FmProveedor : Form
    {
        BEProveedor beProveedor;
        BLLProveedor bllProveedor;
        BEEmpleado beEmpleado;
        public FmProveedor(BEEmpleado obBeEmp)
        { 
            InitializeComponent();
            beProveedor = new BEProveedor();
            bllProveedor = new BLLProveedor();
            beEmpleado = new BEEmpleado();
            beEmpleado = obBeEmp;
        }
        public FmProveedor()
        {
            InitializeComponent();
            beProveedor = new BEProveedor();
            bllProveedor = new BLLProveedor();
            beEmpleado = new BEEmpleado();     
        }
        private void btn_GuardarProv_Click(object sender, EventArgs e)
        {
            FmProveedorGuardar fmProveedorGuardar = new FmProveedorGuardar(beEmpleado);
            fmProveedorGuardar.ShowDialog();
            this.Hide();
        }
        private void FmProveedor_Load(object sender, EventArgs e)
        {          
            CargarDatos();
            Image imagenAtrasOriginal = Properties.Resources.atras;
            Image imagenAtrasEscalable = new Bitmap(imagenAtrasOriginal, btnAtras.Size);
            btnAtras.Image = imagenAtrasEscalable;
            Image imagenNuevoOriginal = Properties.Resources.agregar;
            Image imagenNuevoEscalable = new Bitmap(imagenNuevoOriginal, btnNuevoPro.Size);
            btnNuevoPro.Image = imagenNuevoEscalable;
        }
    
        void CargarDatos()
        {
            try
            {
                dtGripViewProveedor.DataSource = null;
                dtGripViewProveedor.Rows.Clear();
                dtGripViewProveedor.Columns.Clear();
                dtGripViewProveedor.DataSource = bllProveedor.ListarTodo();
                dtGripViewProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dtGripViewProveedor.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
                dtGripViewProveedor.Columns["Id"].DisplayIndex = 0;
                DataGridViewImageColumn btnAcciones = new DataGridViewImageColumn
                {
                    Name = "btnOpciones",
                    HeaderText = "Opciones",
                    Width = 60,
                };
                dtGripViewProveedor.Columns.Add(btnAcciones);
                Image eliminarImg = Properties.Resources.eliminar;
                Image modificarImg = Properties.Resources.editar;
                foreach (DataGridViewRow row in dtGripViewProveedor.Rows)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   

        void modificarProveedor(int Id)
        {
            try
            {
                beProveedor.Id = Id;
                FmProveedorGuardar fmProveedorGuardar = new FmProveedorGuardar(beEmpleado, beProveedor);
                fmProveedorGuardar.ShowDialog();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void eliminarProveedor(int Id)
        {
            try
            {
                beProveedor.Id = Id;
                var res = MessageBox.Show("Esta seguro que desea eliminar el proveedor de la lista?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    if (bllProveedor.Eliminar(beProveedor, beEmpleado))
                    {
                        MessageBox.Show("Eliminado con exito");
                        CargarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_SalirProveedor_Click(object sender, EventArgs e)
        {
            FmPrincipal fmPrincipal = new FmPrincipal(beEmpleado);
            fmPrincipal.Show();
            this.Hide();
        }

        private void dtGripViewProveedor_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtGripViewProveedor.Columns["btnOpciones"].Index && e.RowIndex >= 0)
            {

                Point clickPos = dtGripViewProveedor.PointToClient(MousePosition);
                Rectangle cellRectangle = dtGripViewProveedor.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                if (cellRectangle.Contains(clickPos))
                {

                    int xPos = clickPos.X - cellRectangle.Left;

                    if (xPos >= 0 && xPos < 30)
                    {
                        modificarProveedor(Convert.ToInt32(dtGripViewProveedor.Rows[e.RowIndex].Cells["Id"].Value));

                    }
                    else if (xPos >= 30 && xPos < 60)
                    {
                        eliminarProveedor(Convert.ToInt32(dtGripViewProveedor.Rows[e.RowIndex].Cells["Id"].Value));
                    }
                }
            }

        }
    }
}
