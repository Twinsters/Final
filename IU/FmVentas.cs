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
    public partial class FmVentas : Form
    {

        List<BEVenta> listaVenta;
        BEEmpleado empleado;
        BEEmpleado Usuario;
        BLLVenta venta;
        public FmVentas(BEEmpleado Usu)
        {
            InitializeComponent();
            listaVenta = new List<BEVenta>();
            empleado = new BEEmpleado();
            venta = new BLLVenta();
            Usuario = new BEEmpleado();
            Usuario = Usu;
        }
        private void FmVentas_Load(object sender, EventArgs e)
        {
           
            cargarDataGrid();
            Image originalImage = Properties.Resources.atras;

            // Escalar la imagen al tamaño del botón
            Image scaledImage = new Bitmap(originalImage, btnSalir.Size);  // Redimensiona la imagen al tamaño del botón

            // Asignar la imagen escalada al botón
            btnSalir.Image = scaledImage;


        }
        void cargarDataGrid()
        {
            listaVenta = venta.ListarTodo();
            var ventasPlanas = listaVenta.Select(v => new
            {
                v.Id,                           
                v.Pago,                      
                v.FechaCompra,                
                JuegoDescripcion = v.bEJuego.Descripcion,
                JuegoPlataforma = v.bEJuego.Plataforma,
                JuegoCategoria = v.bEJuego.Categoria,
                ClienteNombre = v.bECliente.Nombre + " " + v.bECliente.Apellido,
                ClienteDNI = v.bECliente.DNI
            }).ToList();


            dataGridVentas.DataSource = null;
            dataGridVentas.Rows.Clear();
            dataGridVentas.Columns.Clear();
            dataGridVentas.DataSource = ventasPlanas;

            dataGridVentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            dataGridVentas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridVentas.Columns["Id"].DisplayIndex = 0;
            dataGridVentas.Columns["Id"].HeaderText = "Codigo";
            dataGridVentas.Columns["FechaCompra"].HeaderText = "Fecha Compra";
            dataGridVentas.Columns["JuegoDescripcion"].HeaderText = "Juego";
            dataGridVentas.Columns["JuegoPlataforma"].HeaderText = "Plataforma";
            dataGridVentas.Columns["JuegoCategoria"].HeaderText = "Categoria";
            dataGridVentas.Columns["ClienteNombre"].HeaderText = "Cliente";
            dataGridVentas.Columns["ClienteDNI"].HeaderText = "DNI";
            
            DataGridViewImageColumn btnAcciones = new DataGridViewImageColumn
            {
                Name = "btnOpciones",
                HeaderText = "Opciones",
                Width = 60,
            };

           
            dataGridVentas.Columns.Add(btnAcciones);

           
            Image eliminarImg = Properties.Resources.eliminar;
            Image verVendedorImg = Properties.Resources.vendedor;

            foreach (DataGridViewRow row in dataGridVentas.Rows)
            {
                if (row.IsNewRow) continue; 

                
                Bitmap cellImage = new Bitmap(60, 25);  

                
                using (Graphics g = Graphics.FromImage(cellImage))
                {
                    
                    int width = 30; 
                    int height = 25;
                   
                    g.DrawImage(verVendedorImg, new Rectangle(0, 0, width, height));

                 
                    g.DrawImage(eliminarImg, new Rectangle(width, 0, width, height));

                }
                row.Cells["btnOpciones"].Value = cellImage;
            }

        }
        private void dataGridVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            if (e.ColumnIndex == dataGridVentas.Columns["btnOpciones"].Index && e.RowIndex >= 0)
            {
              
                Point clickPos = dataGridVentas.PointToClient(MousePosition);  
                Rectangle cellRectangle = dataGridVentas.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                if (cellRectangle.Contains(clickPos))
                {
                   
                    int xPos = clickPos.X - cellRectangle.Left;

                    if (xPos >= 0 && xPos < 30) 
                    {
                        verEmpleado(Convert.ToInt32(dataGridVentas.Rows[e.RowIndex].Cells["Id"].Value));
                       
                    }
                    else if (xPos >= 30 && xPos < 60) 
                    {
                        eliminarVenta(Convert.ToInt32(dataGridVentas.Rows[e.RowIndex].Cells["Id"].Value));
                    }
                }
            }
        }
        void verEmpleado(int Id)
        {
            try
            {
                BEVenta Venta = new BEVenta();
                Venta.Id = Id;
                empleado = venta.verEmpleado(Venta);
                FmEmpleadoVenta fmEmpleadoVenta = new FmEmpleadoVenta(empleado);
                fmEmpleadoVenta.ShowDialog();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        void eliminarVenta(int Id)
        {     
            var result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta venta?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Eliminar la venta de la lista o base de datos
                if (venta.eliminarVentas(Id, Usuario))
                {
                    MessageBox.Show("Venta Eliminada");
                    cargarDataGrid();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la venta ");
                }              
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            FmPrincipal fmPrincipal = new FmPrincipal(Usuario);
            fmPrincipal.Show();
            this.Close();
        }
    }

}
