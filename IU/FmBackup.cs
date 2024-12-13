using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DB;
using BE;
using BLL;
namespace Integrador_2
{
    public partial class FmBackup : Form
    {


        string rutaBackUp = BackupHelper.backupDir;
        BackupHelper backupHelper;
        BEEmpleado usuario;
        BEBackup baseDeDatos;
        BEBitacora bitacora;
        BLLBitacora bllBitacora;

        public FmBackup(BEEmpleado usu)
        {
            InitializeComponent();
            backupHelper = new BackupHelper();
            usuario = new BEEmpleado();
            usuario = usu;
            baseDeDatos = new BEBackup();
            bitacora = new BEBitacora();
            bllBitacora = new BLLBitacora();
        }
        public FmBackup()
        {
            InitializeComponent();
            backupHelper = new BackupHelper();
            BEEmpleado usuario = new BEEmpleado("claudio","Herrera",1,null, DateTime.Now, 'A',null,"1");
            
            baseDeDatos = new BEBackup();
            bitacora = new BEBitacora();
            bllBitacora = new BLLBitacora();
        }
        private void cargarBitacoras()
        {
            try
            {
                dgvBitacora.DataSource = null;
                dgvBitacora.Rows.Clear();
                dgvBitacora.Columns.Clear();
                dgvBitacora.DataSource = bllBitacora.listarTodo();
                dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBitacora.Columns["FechaYHora"].HeaderText = "Fecha";
                dgvBitacora.Columns["NombreArchivo"].HeaderText = "Archivo";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los archivos de backup: {ex.Message}");
            }
        }

        private void CargarArchivosBackup()
        {
            try

            {
                dataGridBackup.DataSource = null;
                dataGridBackup.Rows.Clear();
                dataGridBackup.Columns.Clear();
                dataGridBackup.DataSource = backupHelper.CargarArchivosBackup();
                dataGridBackup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                Image imagenCargarBaseOriginal = Properties.Resources.base_de_datos;
                DataGridViewImageColumn btnAcciones = new DataGridViewImageColumn
                {
                    Name = "btnOpciones",
                    HeaderText = "Opciones",
                    Width = 30,
                };
                dataGridBackup.Columns.Add(btnAcciones);
                Image restarurarBase = Properties.Resources.base_de_datos;
                foreach (DataGridViewRow row in dataGridBackup.Rows)
                {
                    if (row.IsNewRow) continue;
                    Bitmap cellImage = new Bitmap(30, 25);
                    using (Graphics g = Graphics.FromImage(cellImage))
                    {
                        int width = 30;
                        int height = 25;
                        g.DrawImage(restarurarBase, new Rectangle(0, 0, width, height));
                    }
                    row.Cells["btnOpciones"].Value = cellImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los archivos de backup: {ex.Message}");
            }
        }
        private void FmBackup_Load(object sender, EventArgs e)
        {         
            Image imagenAtrasOriginal = Properties.Resources.atras;
            Image imagenAtrasEscalable = new Bitmap(imagenAtrasOriginal, btnSalir.Size);
            btnSalir.Image = imagenAtrasEscalable; 
            Image imagenGuardarBaseOriginal = Properties.Resources.disco_flexible;
            Image imagenGuardarBaseEscalable = new Bitmap(imagenGuardarBaseOriginal, btnGuardar.Size);
            btnGuardar.Image = imagenGuardarBaseEscalable;
            CargarArchivosBackup();
            cargarBitacoras();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(backupHelper.RealizarBackup())
            {
                bitacora.Usuario = usuario;
                bitacora.FechaYHora = DateTime.Now;
                bitacora.Evento = "Backup";
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                bitacora.NombreArchivo = $"Backup_{timestamp}.xml";
                if(bllBitacora.guardarBitacora(bitacora))
                {
                    MessageBox.Show("Backup creado");
                    CargarArchivosBackup();
                    cargarBitacoras();
                }  
            }
            else
            {
                MessageBox.Show("Error al crear backup");
            }                       
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            FmPrincipal fmPrinciapl = new FmPrincipal(usuario);
            fmPrinciapl.Show();
            this.Close();
        }
        private void dataGridBackup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridBackup.Columns["btnOpciones"].Index && e.RowIndex >= 0)
            {
                Point clickPos = dataGridBackup.PointToClient(MousePosition);  // Obtener la posición del clic
                Rectangle cellRectangle = dataGridBackup.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                if (cellRectangle.Contains(clickPos))
                {
                    int xPos = clickPos.X - cellRectangle.Left;
                    if (xPos >= 0 && xPos < 30)
                    {
                        cambiarBaseDeDatos(dataGridBackup.Rows[e.RowIndex].Cells["Nombre"].Value.ToString());
                    }             
                }
            }
        }


        void cambiarBaseDeDatos(string nombre)
        {
            try
            {
                baseDeDatos.Nombre = nombre;
                var res = MessageBox.Show("Esta seguro que desea reemplazar la base de datos?", "Restaurar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    if (backupHelper.ReemplazarBaseDeDatos(baseDeDatos,usuario))
                    {
                        bitacora.Usuario = usuario;
                        bitacora.FechaYHora = DateTime.Now;
                        bitacora.Evento = "Restore";
                        bitacora.NombreArchivo = nombre;
                        if (bllBitacora.guardarBitacora(bitacora))
                        {
                            MessageBox.Show("La base se a restauradado");
                            CargarArchivosBackup();
                            cargarBitacoras();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error a restaurar la base de datos");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
