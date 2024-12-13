namespace Integrador_2
{
    partial class FmEmpleadoVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmEmpleadoVenta));
            this.lbCodigo = new System.Windows.Forms.Label();
            this.lbNombreApellido = new System.Windows.Forms.Label();
            this.lbDNI = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodigo.Location = new System.Drawing.Point(26, 43);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(52, 18);
            this.lbCodigo.TabIndex = 0;
            this.lbCodigo.Text = "label1";
            // 
            // lbNombreApellido
            // 
            this.lbNombreApellido.AutoSize = true;
            this.lbNombreApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbNombreApellido.Location = new System.Drawing.Point(26, 91);
            this.lbNombreApellido.Name = "lbNombreApellido";
            this.lbNombreApellido.Size = new System.Drawing.Size(52, 18);
            this.lbNombreApellido.TabIndex = 1;
            this.lbNombreApellido.Text = "label2";
            // 
            // lbDNI
            // 
            this.lbDNI.AutoSize = true;
            this.lbDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbDNI.Location = new System.Drawing.Point(26, 141);
            this.lbDNI.Name = "lbDNI";
            this.lbDNI.Size = new System.Drawing.Size(52, 18);
            this.lbDNI.TabIndex = 2;
            this.lbDNI.Text = "label3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbCodigo);
            this.groupBox1.Controls.Add(this.lbDNI);
            this.groupBox1.Controls.Add(this.lbNombreApellido);
            this.groupBox1.Font = new System.Drawing.Font("3Dventure", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 193);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Vendedor";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(251, 211);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FmEmpleadoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 236);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmEmpleadoVenta";
            this.Text = "Empleado";
            this.Load += new System.EventHandler(this.FmEmpleadoVenta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Label lbNombreApellido;
        private System.Windows.Forms.Label lbDNI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
    }
}