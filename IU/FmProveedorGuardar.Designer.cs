namespace Integrador_2
{
    partial class FmProveedorGuardar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmProveedorGuardar));
            this.txt_NombreProve = new System.Windows.Forms.TextBox();
            this.txt_CalleProve = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLocalidad = new Integrador_2.txtSoloNum();
            this.txtSoloNum1 = new Integrador_2.txtSoloNum();
            this.btn_GuardarProv = new System.Windows.Forms.Button();
            this.btn_SalirProv = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_NombreProve
            // 
            this.txt_NombreProve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreProve.Location = new System.Drawing.Point(76, 54);
            this.txt_NombreProve.Name = "txt_NombreProve";
            this.txt_NombreProve.Size = new System.Drawing.Size(193, 21);
            this.txt_NombreProve.TabIndex = 1;
            // 
            // txt_CalleProve
            // 
            this.txt_CalleProve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CalleProve.Location = new System.Drawing.Point(76, 102);
            this.txt_CalleProve.Name = "txt_CalleProve";
            this.txt_CalleProve.Size = new System.Drawing.Size(193, 21);
            this.txt_CalleProve.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(275, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Localidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Calle:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(275, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Numero:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLocalidad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSoloNum1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_NombreProve);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_CalleProve);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("3Dventure", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 163);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalidad.Location = new System.Drawing.Point(354, 53);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(192, 21);
            this.txtLocalidad.TabIndex = 2;
            // 
            // txtSoloNum1
            // 
            this.txtSoloNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoloNum1.Location = new System.Drawing.Point(354, 100);
            this.txtSoloNum1.Name = "txtSoloNum1";
            this.txtSoloNum1.Size = new System.Drawing.Size(192, 21);
            this.txtSoloNum1.TabIndex = 4;
            // 
            // btn_GuardarProv
            // 
            this.btn_GuardarProv.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarProv.Image = ((System.Drawing.Image)(resources.GetObject("btn_GuardarProv.Image")));
            this.btn_GuardarProv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_GuardarProv.Location = new System.Drawing.Point(371, 203);
            this.btn_GuardarProv.Name = "btn_GuardarProv";
            this.btn_GuardarProv.Size = new System.Drawing.Size(94, 42);
            this.btn_GuardarProv.TabIndex = 5;
            this.btn_GuardarProv.Text = "Guardar";
            this.btn_GuardarProv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_GuardarProv.UseVisualStyleBackColor = true;
            this.btn_GuardarProv.Click += new System.EventHandler(this.btn_GuardarProv_Click);
            // 
            // btn_SalirProv
            // 
            this.btn_SalirProv.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SalirProv.Image = ((System.Drawing.Image)(resources.GetObject("btn_SalirProv.Image")));
            this.btn_SalirProv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SalirProv.Location = new System.Drawing.Point(485, 203);
            this.btn_SalirProv.Name = "btn_SalirProv";
            this.btn_SalirProv.Size = new System.Drawing.Size(89, 42);
            this.btn_SalirProv.TabIndex = 6;
            this.btn_SalirProv.Text = "Salir";
            this.btn_SalirProv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SalirProv.UseVisualStyleBackColor = true;
            this.btn_SalirProv.Click += new System.EventHandler(this.btn_SalirProv_Click);
            // 
            // FmProveedorGuardar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(593, 278);
            this.Controls.Add(this.btn_SalirProv);
            this.Controls.Add(this.btn_GuardarProv);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmProveedorGuardar";
            this.Text = "Guardar";
            this.Load += new System.EventHandler(this.FmProveedorGuardar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_NombreProve;
        private System.Windows.Forms.TextBox txt_CalleProve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private txtSoloNum txtSoloNum1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_GuardarProv;
        private System.Windows.Forms.Button btn_SalirProv;
        private txtSoloNum txtLocalidad;
    }
}