namespace Integrador_2
{
    partial class FmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmDashboard));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btnSemana = new System.Windows.Forms.Button();
            this.btnUltimos = new System.Windows.Forms.Button();
            this.btnMes = new System.Windows.Forms.Button();
            this.dateTimeDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimeHasta = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbTotalVentas = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbTotalRecaudado = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chVentasCategoria = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chMasVendidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgBajoStock = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lbTop5 = new System.Windows.Forms.Label();
            this.lbTop4 = new System.Windows.Forms.Label();
            this.lbTop3 = new System.Windows.Forms.Label();
            this.lbTop2 = new System.Windows.Forms.Label();
            this.lbTop1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chVentasCategoria)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chMasVendidos)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBajoStock)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(391, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(96, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnHoy
            // 
            this.btnHoy.Location = new System.Drawing.Point(531, 12);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(96, 23);
            this.btnHoy.TabIndex = 1;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = true;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // btnSemana
            // 
            this.btnSemana.Location = new System.Drawing.Point(633, 12);
            this.btnSemana.Name = "btnSemana";
            this.btnSemana.Size = new System.Drawing.Size(96, 23);
            this.btnSemana.TabIndex = 2;
            this.btnSemana.Text = "Semana";
            this.btnSemana.UseVisualStyleBackColor = true;
            this.btnSemana.Click += new System.EventHandler(this.btnSemana_Click);
            // 
            // btnUltimos
            // 
            this.btnUltimos.Location = new System.Drawing.Point(735, 12);
            this.btnUltimos.Name = "btnUltimos";
            this.btnUltimos.Size = new System.Drawing.Size(96, 23);
            this.btnUltimos.TabIndex = 3;
            this.btnUltimos.Text = "30 Dias";
            this.btnUltimos.UseVisualStyleBackColor = true;
            this.btnUltimos.Click += new System.EventHandler(this.btnUltimos_Click);
            // 
            // btnMes
            // 
            this.btnMes.Location = new System.Drawing.Point(837, 12);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(96, 23);
            this.btnMes.TabIndex = 4;
            this.btnMes.Text = "Mes";
            this.btnMes.UseVisualStyleBackColor = true;
            this.btnMes.Click += new System.EventHandler(this.btnMes_Click);
            // 
            // dateTimeDesde
            // 
            this.dateTimeDesde.Location = new System.Drawing.Point(25, 15);
            this.dateTimeDesde.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimeDesde.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimeDesde.Name = "dateTimeDesde";
            this.dateTimeDesde.Size = new System.Drawing.Size(152, 20);
            this.dateTimeDesde.TabIndex = 5;
            // 
            // dateTimeHasta
            // 
            this.dateTimeHasta.Location = new System.Drawing.Point(202, 15);
            this.dateTimeHasta.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimeHasta.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimeHasta.Name = "dateTimeHasta";
            this.dateTimeHasta.Size = new System.Drawing.Size(152, 20);
            this.dateTimeHasta.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTotalVentas);
            this.groupBox1.Font = new System.Drawing.Font("3Dventure", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 84);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cantidad de Ventas";
            // 
            // lbTotalVentas
            // 
            this.lbTotalVentas.AutoSize = true;
            this.lbTotalVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalVentas.Location = new System.Drawing.Point(113, 38);
            this.lbTotalVentas.Name = "lbTotalVentas";
            this.lbTotalVentas.Size = new System.Drawing.Size(0, 20);
            this.lbTotalVentas.TabIndex = 0;
            this.lbTotalVentas.Click += new System.EventHandler(this.lbTotalVentas_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbTotalRecaudado);
            this.groupBox2.Font = new System.Drawing.Font("3Dventure", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(391, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 84);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total Recaudado";
            // 
            // lbTotalRecaudado
            // 
            this.lbTotalRecaudado.AutoSize = true;
            this.lbTotalRecaudado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRecaudado.Location = new System.Drawing.Point(172, 38);
            this.lbTotalRecaudado.Name = "lbTotalRecaudado";
            this.lbTotalRecaudado.Size = new System.Drawing.Size(0, 24);
            this.lbTotalRecaudado.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chVentasCategoria);
            this.groupBox4.Font = new System.Drawing.Font("3Dventure", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(25, 174);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(632, 240);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ventas Por Categoria";
            // 
            // chVentasCategoria
            // 
            chartArea1.Name = "ChartArea1";
            this.chVentasCategoria.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chVentasCategoria.Legends.Add(legend1);
            this.chVentasCategoria.Location = new System.Drawing.Point(6, 19);
            this.chVentasCategoria.Name = "chVentasCategoria";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chVentasCategoria.Series.Add(series1);
            this.chVentasCategoria.Size = new System.Drawing.Size(620, 206);
            this.chVentasCategoria.TabIndex = 0;
            this.chVentasCategoria.Text = "chart1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chMasVendidos);
            this.groupBox5.Font = new System.Drawing.Font("3Dventure", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(663, 174);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(270, 358);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ventas Por Vendedor";
            // 
            // chMasVendidos
            // 
            chartArea2.Name = "ChartArea1";
            this.chMasVendidos.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chMasVendidos.Legends.Add(legend2);
            this.chMasVendidos.Location = new System.Drawing.Point(6, 19);
            this.chMasVendidos.Name = "chMasVendidos";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chMasVendidos.Series.Add(series2);
            this.chMasVendidos.Size = new System.Drawing.Size(258, 333);
            this.chMasVendidos.TabIndex = 1;
            this.chMasVendidos.Text = "chart2";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgBajoStock);
            this.groupBox6.Font = new System.Drawing.Font("3Dventure", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(252, 420);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(405, 182);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Bajo Stock";
            // 
            // dgBajoStock
            // 
            this.dgBajoStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBajoStock.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgBajoStock.Location = new System.Drawing.Point(6, 26);
            this.dgBajoStock.MultiSelect = false;
            this.dgBajoStock.Name = "dgBajoStock";
            this.dgBajoStock.ReadOnly = true;
            this.dgBajoStock.Size = new System.Drawing.Size(393, 150);
            this.dgBajoStock.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lbTop5);
            this.groupBox7.Controls.Add(this.lbTop4);
            this.groupBox7.Controls.Add(this.lbTop3);
            this.groupBox7.Controls.Add(this.lbTop2);
            this.groupBox7.Controls.Add(this.lbTop1);
            this.groupBox7.Font = new System.Drawing.Font("3Dventure", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(25, 420);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(204, 182);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Top 5 Vendidos";
            // 
            // lbTop5
            // 
            this.lbTop5.AutoSize = true;
            this.lbTop5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTop5.Location = new System.Drawing.Point(6, 137);
            this.lbTop5.Name = "lbTop5";
            this.lbTop5.Size = new System.Drawing.Size(0, 18);
            this.lbTop5.TabIndex = 4;
            // 
            // lbTop4
            // 
            this.lbTop4.AutoSize = true;
            this.lbTop4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTop4.Location = new System.Drawing.Point(7, 111);
            this.lbTop4.Name = "lbTop4";
            this.lbTop4.Size = new System.Drawing.Size(0, 18);
            this.lbTop4.TabIndex = 3;
            // 
            // lbTop3
            // 
            this.lbTop3.AutoSize = true;
            this.lbTop3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTop3.Location = new System.Drawing.Point(7, 84);
            this.lbTop3.Name = "lbTop3";
            this.lbTop3.Size = new System.Drawing.Size(0, 18);
            this.lbTop3.TabIndex = 2;
            // 
            // lbTop2
            // 
            this.lbTop2.AutoSize = true;
            this.lbTop2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTop2.Location = new System.Drawing.Point(6, 59);
            this.lbTop2.Name = "lbTop2";
            this.lbTop2.Size = new System.Drawing.Size(0, 18);
            this.lbTop2.TabIndex = 1;
            // 
            // lbTop1
            // 
            this.lbTop1.AutoSize = true;
            this.lbTop1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTop1.Location = new System.Drawing.Point(7, 32);
            this.lbTop1.Name = "lbTop1";
            this.lbTop1.Size = new System.Drawing.Size(0, 18);
            this.lbTop1.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Integrador_2.Properties.Resources.atras;
            this.btnSalir.Location = new System.Drawing.Point(772, 543);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(59, 41);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(862, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            // 
            // FmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 614);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimeHasta);
            this.Controls.Add(this.dateTimeDesde);
            this.Controls.Add(this.btnMes);
            this.Controls.Add(this.btnUltimos);
            this.Controls.Add(this.btnSemana);
            this.Controls.Add(this.btnHoy);
            this.Controls.Add(this.btnBuscar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmDashboard";
            this.Text = "Dashboard";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chVentasCategoria)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chMasVendidos)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBajoStock)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Button btnSemana;
        private System.Windows.Forms.Button btnUltimos;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.DateTimePicker dateTimeDesde;
        private System.Windows.Forms.DateTimePicker dateTimeHasta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbTotalVentas;
        private System.Windows.Forms.Label lbTotalRecaudado;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chVentasCategoria;
        private System.Windows.Forms.DataVisualization.Charting.Chart chMasVendidos;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgBajoStock;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lbTop5;
        private System.Windows.Forms.Label lbTop4;
        private System.Windows.Forms.Label lbTop3;
        private System.Windows.Forms.Label lbTop2;
        private System.Windows.Forms.Label lbTop1;
        private System.Windows.Forms.Label label1;
    }
}