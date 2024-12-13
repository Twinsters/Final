namespace Integrador_2
{
    partial class FmJuego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmJuego));
            this.dtViGripJuegos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cbPlataforma = new System.Windows.Forms.ComboBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAtrasJuego = new System.Windows.Forms.Button();
            this.btnAltaJuego = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtViGripJuegos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtViGripJuegos
            // 
            this.dtViGripJuegos.Location = new System.Drawing.Point(34, 282);
            this.dtViGripJuegos.Name = "dtViGripJuegos";
            this.dtViGripJuegos.Size = new System.Drawing.Size(885, 315);
            this.dtViGripJuegos.TabIndex = 14;
            this.dtViGripJuegos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtViGripJuegos_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("3Dventure", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(416, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 30);
            this.label4.TabIndex = 13;
            this.label4.Text = "Juegos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cbCategoria);
            this.groupBox1.Controls.Add(this.cbPlataforma);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(34, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 189);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(40, 56);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(272, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // cbPlataforma
            // 
            this.cbPlataforma.FormattingEnabled = true;
            this.cbPlataforma.Location = new System.Drawing.Point(40, 95);
            this.cbPlataforma.Name = "cbPlataforma";
            this.cbPlataforma.Size = new System.Drawing.Size(272, 21);
            this.cbPlataforma.TabIndex = 1;
            // 
            // cbCategoria
            // 
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(40, 137);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(272, 21);
            this.cbCategoria.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Integrador_2.Properties.Resources.lupa;
            this.btnBuscar.Location = new System.Drawing.Point(399, 72);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(64, 51);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAtrasJuego
            // 
            this.btnAtrasJuego.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtrasJuego.Image = global::Integrador_2.Properties.Resources.atras;
            this.btnAtrasJuego.Location = new System.Drawing.Point(34, 26);
            this.btnAtrasJuego.Name = "btnAtrasJuego";
            this.btnAtrasJuego.Size = new System.Drawing.Size(53, 42);
            this.btnAtrasJuego.TabIndex = 15;
            this.btnAtrasJuego.UseVisualStyleBackColor = true;
            this.btnAtrasJuego.Click += new System.EventHandler(this.btnAtrasJuego_Click);
            // 
            // btnAltaJuego
            // 
            this.btnAltaJuego.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaJuego.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAltaJuego.Image = global::Integrador_2.Properties.Resources.agregar;
            this.btnAltaJuego.Location = new System.Drawing.Point(93, 26);
            this.btnAltaJuego.Name = "btnAltaJuego";
            this.btnAltaJuego.Size = new System.Drawing.Size(53, 42);
            this.btnAltaJuego.TabIndex = 2;
            this.btnAltaJuego.UseVisualStyleBackColor = true;
            this.btnAltaJuego.Click += new System.EventHandler(this.btnAltaJuego_Click);
            // 
            // FmJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(956, 622);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAtrasJuego);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtViGripJuegos);
            this.Controls.Add(this.btnAltaJuego);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmJuego";
            this.Text = "Juegos";
            this.Load += new System.EventHandler(this.FormJuego_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtViGripJuegos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAltaJuego;
        private System.Windows.Forms.DataGridView dtViGripJuegos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAtrasJuego;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.ComboBox cbPlataforma;
        private System.Windows.Forms.TextBox txtNombre;
    }
}