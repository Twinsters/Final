using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BE;
using BLL;
namespace Integrador_2
{
    public partial class FmDashboard : Form
    {
        BLLVenta bLLVenta;
        BEEmpleado usuario;
        public FmDashboard(BEEmpleado usua)
        {           
            bLLVenta = new BLLVenta();
            usuario = new BEEmpleado();
            usuario = usua;
            InitializeComponent();
            InicializarComponentes();
            Image imagenAtrasOriginal = Properties.Resources.atras;
            Image imagenAtrasEscalable = new Bitmap(imagenAtrasOriginal, btnSalir.Size);
            btnSalir.Image = imagenAtrasEscalable;

        }

        private void lbTotalVentas_Click(object sender, EventArgs e)
        {

        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            lbTotalVentas.Text = bLLVenta.VentasDiaHoy(1);
            lbTotalRecaudado.Text = " $ " + " " + bLLVenta.GananciasDia(1);
            cargargraficoDona(1);
            cargargraficoBarra(1);
            cargarDataGrid();
            topJuegos(1);

        }
        private void btnSemana_Click(object sender, EventArgs e)
        {  
            lbTotalVentas.Text = bLLVenta.VentasDiaHoy(2);
            lbTotalRecaudado.Text = " $ " + " " + bLLVenta.GananciasDia(2);
            cargargraficoDona(2);
            cargargraficoBarra(2);
            cargarDataGrid();
            topJuegos(2);
        }
        private void btnUltimos_Click(object sender, EventArgs e)
        {
            lbTotalVentas.Text = bLLVenta.VentasDiaHoy(3);
            lbTotalRecaudado.Text = " $ " + " " + bLLVenta.GananciasDia(3);
            cargargraficoDona(3);
            cargargraficoBarra(3);
            cargarDataGrid();
            topJuegos(3);
        }
        private void btnMes_Click(object sender, EventArgs e)
        {

            lbTotalVentas.Text = bLLVenta.VentasDiaHoy(4);
            lbTotalRecaudado.Text = " $ " + " " + bLLVenta.GananciasDia(4);
            cargargraficoDona(4);
            cargargraficoBarra(4);
            cargarDataGrid();
            topJuegos(4);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<DateTime> rango = new List<DateTime>();
            rango.Add(dateTimeDesde.Value);
            rango.Add(dateTimeHasta.Value);

            lbTotalVentas.Text = bLLVenta.VentasDiaHoy(5,rango);
            lbTotalRecaudado.Text = " $ " + " " + bLLVenta.GananciasDia(5, rango);
            cargargraficoDona(5,rango);
            cargargraficoBarra(5,rango);
            cargarDataGrid();
            topJuegos(5, rango);
        }
        private void InicializarComponentes()
        {
            Panel panelGrafico = new Panel
            {
                Dock = DockStyle.Top,
                Height = 300
            };
            Chart chMasVendidos = new Chart
            {
                Dock = DockStyle.Fill
            };
            ChartArea chartArea = new ChartArea();
            chMasVendidos.ChartAreas.Add(chartArea);
            panelGrafico.Controls.Add(chMasVendidos);
            this.Controls.Add(panelGrafico);
            Legend legend = new Legend
            {
                Docking = Docking.Bottom
            };
            chMasVendidos.Legends.Add(legend);
        }
        void cargarDataGrid()
        {
            dgBajoStock.DataSource = null;
            dgBajoStock.DataSource = bLLVenta.ObtenerJuegosConPocoStock();
            dgBajoStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgBajoStock.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
            dgBajoStock.Columns["CodEstado"].Visible = false;
            dgBajoStock.Columns["bEProveedor"].Visible = false;
            dgBajoStock.Columns["Id"].HeaderText = "Codigo";
            dgBajoStock.Columns["Id"].DisplayIndex = 0;

        }
        void cargargraficoDona(int opcion, List<DateTime> rangoFechas = null)
        {
            var ventasHoy = bLLVenta.VentasPorVendedorHoy(opcion, rangoFechas);
            chMasVendidos.ResetAutoValues();
            chMasVendidos.Series.Clear();
            chMasVendidos.Titles.Clear();
            chMasVendidos.Titles.Add("Ventas por Vendedor");
            Series series = chMasVendidos.Series.Add("Ventas");
            series.ChartType = SeriesChartType.Doughnut;
            chMasVendidos.ChartAreas[0].Area3DStyle.Enable3D = true;

            foreach (var vendedor in ventasHoy)
            {
                series.Points.AddXY(vendedor.Key, vendedor.Value);
                series.Points[series.Points.Count - 1].Label = vendedor.Value.ToString();
            }
            foreach (var point in series.Points)
            {
                point.LegendText = point.AxisLabel;
            }
            chMasVendidos.Legends[0].Docking = Docking.Bottom;
        }
        void cargargraficoBarra(int opcion, List<DateTime> rangoFechas = null)
        {
            var ventasCategoria = bLLVenta.VentaPorCategoria(opcion, rangoFechas);
            chVentasCategoria.ResetAutoValues();
            chVentasCategoria.Series.Clear();
            chVentasCategoria.Titles.Clear();
           
            chVentasCategoria.Titles.Add("Ventas por Categoria");
            Series series = chVentasCategoria.Series.Add("Ventas");
            series.ChartType = SeriesChartType.Column;
            chVentasCategoria.ChartAreas[0].Area3DStyle.Enable3D = false;

            foreach (var ventaCategoria in ventasCategoria)
            {
                series.Points.AddXY(ventaCategoria.Key, ventaCategoria.Value);
                series.Points[series.Points.Count - 1].Label = ventaCategoria.Value.ToString();
            }
            foreach (var point in series.Points)
            {
                point.LegendText = point.AxisLabel;
            }
            chVentasCategoria.Legends[0].Docking = Docking.Bottom;
        }
        void topJuegos(int opcion, List<DateTime> rangoFechas = null)
        {
            var top5Juegos = bLLVenta.TopMasVendidos(opcion, rangoFechas).ToList();

            lbTop1.Text = top5Juegos.ElementAtOrDefault(0) ?? "";
            lbTop2.Text = top5Juegos.ElementAtOrDefault(1) ?? "";
            lbTop3.Text = top5Juegos.ElementAtOrDefault(2) ?? "";
            lbTop4.Text = top5Juegos.ElementAtOrDefault(3) ?? "";
            lbTop5.Text = top5Juegos.ElementAtOrDefault(4) ?? "";

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FmPrincipal fmPrincipal = new FmPrincipal(usuario);
            fmPrincipal.Show();
            this.Close();

        }
    }
}
