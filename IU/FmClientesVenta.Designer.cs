namespace Integrador_2
{
    partial class FmClientesVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmClientesVenta));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.soloDNI1 = new Integrador_2.SoloDNI();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_ApellidoCliente = new System.Windows.Forms.TextBox();
            this.txt_NombreCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Confirmar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.soloDNI1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txt_ApellidoCliente);
            this.groupBox1.Controls.Add(this.txt_NombreCliente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("3Dventure", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // soloDNI1
            // 
            this.soloDNI1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soloDNI1.Location = new System.Drawing.Point(54, 98);
            this.soloDNI1.Name = "soloDNI1";
            this.soloDNI1.Size = new System.Drawing.Size(140, 21);
            this.soloDNI1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(334, 99);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(223, 21);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // txt_ApellidoCliente
            // 
            this.txt_ApellidoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ApellidoCliente.Location = new System.Drawing.Point(389, 52);
            this.txt_ApellidoCliente.Name = "txt_ApellidoCliente";
            this.txt_ApellidoCliente.Size = new System.Drawing.Size(168, 21);
            this.txt_ApellidoCliente.TabIndex = 2;
            // 
            // txt_NombreCliente
            // 
            this.txt_NombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreCliente.Location = new System.Drawing.Point(86, 51);
            this.txt_NombreCliente.Name = "txt_NombreCliente";
            this.txt_NombreCliente.Size = new System.Drawing.Size(197, 21);
            this.txt_NombreCliente.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(200, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha Nacimiento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "DNI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(317, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btn_Confirmar
            // 
            this.btn_Confirmar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Confirmar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Confirmar.Image")));
            this.btn_Confirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Confirmar.Location = new System.Drawing.Point(346, 239);
            this.btn_Confirmar.Name = "btn_Confirmar";
            this.btn_Confirmar.Size = new System.Drawing.Size(110, 46);
            this.btn_Confirmar.TabIndex = 5;
            this.btn_Confirmar.Text = "Confirmar";
            this.btn_Confirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Confirmar.UseVisualStyleBackColor = true;
            this.btn_Confirmar.Click += new System.EventHandler(this.btn_Confirmar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancelar.Image")));
            this.btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancelar.Location = new System.Drawing.Point(482, 239);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(110, 46);
            this.btn_Cancelar.TabIndex = 6;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // FmClientesVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(609, 305);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Confirmar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmClientesVenta";
            this.Text = "Venta";
            this.Load += new System.EventHandler(this.FmClientesVenta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txt_ApellidoCliente;
        private System.Windows.Forms.TextBox txt_NombreCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Confirmar;
        private System.Windows.Forms.Button btn_Cancelar;
        private SoloDNI soloDNI1;
    }
}