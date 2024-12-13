namespace Integrador_2
{
    partial class FmVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmVenta));
            this.label4 = new System.Windows.Forms.Label();
            this.dtgriViewVenta = new System.Windows.Forms.DataGridView();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.cbPlataforma = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btn_SalirVenta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgriViewVenta)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("3Dventure", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(330, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Juegos";
            // 
            // dtgriViewVenta
            // 
            this.dtgriViewVenta.BackgroundColor = System.Drawing.Color.DarkGreen;
            this.dtgriViewVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgriViewVenta.Location = new System.Drawing.Point(12, 232);
            this.dtgriViewVenta.MultiSelect = false;
            this.dtgriViewVenta.Name = "dtgriViewVenta";
            this.dtgriViewVenta.ReadOnly = true;
            this.dtgriViewVenta.Size = new System.Drawing.Size(766, 233);
            this.dtgriViewVenta.TabIndex = 7;
            this.dtgriViewVenta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgriViewVenta_CellClick);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(22, 38);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(255, 21);
            this.textNombre.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCategoria);
            this.groupBox1.Controls.Add(this.cbPlataforma);
            this.groupBox1.Controls.Add(this.textNombre);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 154);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // cbCategoria
            // 
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(22, 120);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(255, 23);
            this.cbCategoria.TabIndex = 11;
            // 
            // cbPlataforma
            // 
            this.cbPlataforma.FormattingEnabled = true;
            this.cbPlataforma.Location = new System.Drawing.Point(22, 80);
            this.cbPlataforma.Name = "cbPlataforma";
            this.cbPlataforma.Size = new System.Drawing.Size(255, 23);
            this.cbPlataforma.TabIndex = 10;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::Integrador_2.Properties.Resources.lupa;
            this.btnBuscar.Location = new System.Drawing.Point(378, 64);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(58, 52);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btn_SalirVenta
            // 
            this.btn_SalirVenta.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SalirVenta.Image = global::Integrador_2.Properties.Resources.atras;
            this.btn_SalirVenta.Location = new System.Drawing.Point(12, 21);
            this.btn_SalirVenta.Name = "btn_SalirVenta";
            this.btn_SalirVenta.Size = new System.Drawing.Size(45, 45);
            this.btn_SalirVenta.TabIndex = 8;
            this.btn_SalirVenta.UseVisualStyleBackColor = true;
            this.btn_SalirVenta.Click += new System.EventHandler(this.btn_SalirVenta_Click);
            // 
            // FmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(806, 489);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_SalirVenta);
            this.Controls.Add(this.dtgriViewVenta);
            this.Controls.Add(this.label4);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmVenta";
            this.Text = "Venta";
            this.Load += new System.EventHandler(this.FmVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgriViewVenta)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtgriViewVenta;
        private System.Windows.Forms.Button btn_SalirVenta;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.ComboBox cbPlataforma;
    }
}