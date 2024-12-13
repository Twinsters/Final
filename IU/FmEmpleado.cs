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
    public partial class FmEmpleado : Form
    {
        BLLEmpleado bLLEmpleado;
        BEEmpleado bEEmpleado;
        BEEmpleado Usuario;
        public FmEmpleado(BEEmpleado objBeE)
        {
            InitializeComponent();
            bLLEmpleado = new BLLEmpleado();
            bEEmpleado = new BEEmpleado();
            Usuario = objBeE;
        }
        public FmEmpleado()
        {
            InitializeComponent();
            bLLEmpleado = new BLLEmpleado();
            bEEmpleado = new BEEmpleado();
          
        }
        private void FmEmpleado_Load_1(object sender, EventArgs e)
        {
            CargarDatos();
            Image imagenAtrasOriginal = Properties.Resources.atras;
            Image imagenAtrasEscalable = new Bitmap(imagenAtrasOriginal, btnAtras.Size);
            btnAtras.Image = imagenAtrasEscalable;
            Image imagenNuevoOriginal = Properties.Resources.agregar;
            Image imagenNuevoEscalable = new Bitmap(imagenNuevoOriginal, btnAtras.Size);
            btnNuevoEmpleado.Image = imagenNuevoEscalable;
        }
        void CargarDatos()
        {


            dtGripViEmpl.DataSource = null;
            dtGripViEmpl.Rows.Clear();
            dtGripViEmpl.Columns.Clear();
            dtGripViEmpl.DataSource = bLLEmpleado.ListarTodo();
            dtGripViEmpl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtGripViEmpl.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dtGripViEmpl.Columns["Id"].DisplayIndex = 0;
            dtGripViEmpl.Columns["Id"].HeaderText = "Codigo";
            dtGripViEmpl.Columns["oDom"].HeaderText = "Domicilio";
            dtGripViEmpl.Columns["Estado"].HeaderText = "Estado";
            dtGripViEmpl.Columns["Pass"].HeaderText = "Contraseña";
            dtGripViEmpl.Columns["Perfil"].HeaderText = "Cargo";

            DataGridViewImageColumn btnAcciones = new DataGridViewImageColumn
            {
                Name = "btnOpciones",
                HeaderText = "Opciones",
                Width = 60,
            };
            dtGripViEmpl.Columns.Add(btnAcciones);
            Image eliminarImg = Properties.Resources.eliminar;
            Image modificarImg = Properties.Resources.editar;
            foreach (DataGridViewRow row in dtGripViEmpl.Rows)
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
        private void dtGripViEmpl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtGripViEmpl.Columns["btnOpciones"].Index && e.RowIndex >= 0)
            {
                Point clickPos = dtGripViEmpl.PointToClient(MousePosition);  // Obtener la posición del clic
                Rectangle cellRectangle = dtGripViEmpl.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                if (cellRectangle.Contains(clickPos))
                {
                    int xPos = clickPos.X - cellRectangle.Left;

                    if (xPos >= 0 && xPos < 30) 
                    {
                        modificarEmpleado(Convert.ToInt32(dtGripViEmpl.Rows[e.RowIndex].Cells["Id"].Value));
                    }
                    else if (xPos >= 30 && xPos < 60)
                    {
                        eliminarEmpleado(Convert.ToInt32(dtGripViEmpl.Rows[e.RowIndex].Cells["Id"].Value));
                    }
                }
            }
        }

        void modificarEmpleado(int Id)
        {
            try
            {
                bEEmpleado.Id = Id;
                FmEmpleadosGuardar fmEmpleadosGuardar = new FmEmpleadosGuardar(Usuario, bEEmpleado);
                fmEmpleadosGuardar.ShowDialog();
                this.Hide();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void eliminarEmpleado(int Id)
        {
            try
            {
                bEEmpleado.Id = Id;
                var res = MessageBox.Show("Esta seguro que desea eliminar el empleado de la lista?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    if (bLLEmpleado.Eliminar(bEEmpleado, Usuario))
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
        private void btnAtras_Click(object sender, EventArgs e)
        {
            FmPrincipal fmPrincipal = new FmPrincipal(Usuario);
            fmPrincipal.Show();
            this.Hide();
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            FmEmpleadosGuardar fmEmpleadosGuardar = new FmEmpleadosGuardar(Usuario);
            fmEmpleadosGuardar.ShowDialog();
            this.Hide();
        }

       
    }
}
