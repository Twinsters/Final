namespace Integrador_2
{
    partial class UC_Log
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.soloDNI1 = new Integrador_2.SoloDNI();
            this.txt_PassLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_IngresarLogin = new System.Windows.Forms.Button();
            this.btn_SalirLogin = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.soloDNI1);
            this.groupBox1.Controls.Add(this.txt_PassLogin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // soloDNI1
            // 
            this.soloDNI1.Location = new System.Drawing.Point(80, 33);
            this.soloDNI1.Name = "soloDNI1";
            this.soloDNI1.Size = new System.Drawing.Size(137, 20);
            this.soloDNI1.TabIndex = 1;
            // 
            // txt_PassLogin
            // 
            this.txt_PassLogin.Location = new System.Drawing.Point(80, 83);
            this.txt_PassLogin.Name = "txt_PassLogin";
            this.txt_PassLogin.Size = new System.Drawing.Size(142, 20);
            this.txt_PassLogin.TabIndex = 2;
            this.txt_PassLogin.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // btn_IngresarLogin
            // 
            this.btn_IngresarLogin.Location = new System.Drawing.Point(25, 173);
            this.btn_IngresarLogin.Name = "btn_IngresarLogin";
            this.btn_IngresarLogin.Size = new System.Drawing.Size(75, 23);
            this.btn_IngresarLogin.TabIndex = 3;
            this.btn_IngresarLogin.Text = "Ingresar";
            this.btn_IngresarLogin.UseVisualStyleBackColor = true;
            this.btn_IngresarLogin.Click += new System.EventHandler(this.btn_IngresarLogin_Click);
            // 
            // btn_SalirLogin
            // 
            this.btn_SalirLogin.Location = new System.Drawing.Point(159, 173);
            this.btn_SalirLogin.Name = "btn_SalirLogin";
            this.btn_SalirLogin.Size = new System.Drawing.Size(75, 23);
            this.btn_SalirLogin.TabIndex = 4;
            this.btn_SalirLogin.Text = "Salir";
            this.btn_SalirLogin.UseVisualStyleBackColor = true;
            this.btn_SalirLogin.Click += new System.EventHandler(this.btn_SalirLogin_Click);
            // 
            // UC_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_SalirLogin);
            this.Controls.Add(this.btn_IngresarLogin);
            this.Controls.Add(this.groupBox1);
            this.Name = "UC_Log";
            this.Size = new System.Drawing.Size(254, 211);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_PassLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_IngresarLogin;
        private System.Windows.Forms.Button btn_SalirLogin;
        private SoloDNI soloDNI1;
    }
}
