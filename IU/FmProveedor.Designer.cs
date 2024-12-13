namespace Integrador_2
{
    partial class FmProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmProveedor));
            this.dtGripViewProveedor = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNuevoPro = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGripViewProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGripViewProveedor
            // 
            this.dtGripViewProveedor.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtGripViewProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGripViewProveedor.Location = new System.Drawing.Point(25, 75);
            this.dtGripViewProveedor.MultiSelect = false;
            this.dtGripViewProveedor.Name = "dtGripViewProveedor";
            this.dtGripViewProveedor.ReadOnly = true;
            this.dtGripViewProveedor.Size = new System.Drawing.Size(625, 268);
            this.dtGripViewProveedor.TabIndex = 1;
            this.dtGripViewProveedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGripViewProveedor_CellClick_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("3Dventure", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(227, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Proveedores";
            // 
            // btnNuevoPro
            // 
            this.btnNuevoPro.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoPro.Image = global::Integrador_2.Properties.Resources.agregar;
            this.btnNuevoPro.Location = new System.Drawing.Point(79, 28);
            this.btnNuevoPro.Name = "btnNuevoPro";
            this.btnNuevoPro.Size = new System.Drawing.Size(48, 41);
            this.btnNuevoPro.TabIndex = 3;
            this.btnNuevoPro.UseVisualStyleBackColor = true;
            this.btnNuevoPro.Click += new System.EventHandler(this.btn_GuardarProv_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Image = global::Integrador_2.Properties.Resources.atras;
            this.btnAtras.Location = new System.Drawing.Point(25, 28);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(48, 40);
            this.btnAtras.TabIndex = 6;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btn_SalirProveedor_Click);
            // 
            // FmProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(676, 384);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnNuevoPro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtGripViewProveedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmProveedor";
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.FmProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGripViewProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtGripViewProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNuevoPro;
        private System.Windows.Forms.Button btnAtras;
    }
}