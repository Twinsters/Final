using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Microsoft.Reporting.WinForms;
using BE;
namespace Integrador_2
{
    public partial class FmReporteJuegosPedidos : Form
    {
        BLLJuego bllJuego;
        public FmReporteJuegosPedidos()
        {
            InitializeComponent();

            bllJuego = new BLLJuego();
        }

        private void FmReporteJuegosPedidos_Load(object sender, EventArgs e)
        {
            CargarReporte();

        }
        private void CargarReporte()
        {
            try
            {
                // Simulación de los datos dinámicos (esto lo obtienes de tu BLL o servicio)
               

                // Lista de objetos Juego donde guardaremos los datos mapeados
                List<BEJuego> listaJuegos = new List<BEJuego>();

                var pedidosDinamicos = bllJuego.traerJuegosPedidos();
            
             
                foreach (var juegos in pedidosDinamicos)
                {
                    BEJuego nuevoJuego = new BEJuego();

                    foreach (var prop in juegos.GetType().GetProperties())
                    {
                        var value = prop.GetValue(juegos);
                        if (prop.Name == "Id")
                        {
                            nuevoJuego.Id = Convert.ToInt32(value);
                        }
                        else if (prop.Name == "Descripcion")
                        {
                            nuevoJuego.Descripcion = value?.ToString() ?? string.Empty;
                        }
                        else if (prop.Name == "Categoria")
                        {
                            nuevoJuego.Categoria = value?.ToString() ?? string.Empty;
                        }
                        else if (prop.Name == "Plataforma")
                        {
                            nuevoJuego.Plataforma = value?.ToString() ?? string.Empty;
                        }
                      
                        else if (prop.Name == "Cantidad")
                        {
                            nuevoJuego.Stock = Convert.ToInt32(value);
                        }
                       
                    }

                    listaJuegos.Add(nuevoJuego);
                }
         
                this.reportViewer1.LocalReport.DataSources[0].Value = listaJuegos;

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }

}

