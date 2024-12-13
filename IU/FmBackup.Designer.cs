namespace Integrador_2
{
    partial class FmBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmBackup));
            this.dataGridBackup = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBackup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridBackup
            // 
            this.dataGridBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBackup.Location = new System.Drawing.Point(29, 65);
            this.dataGridBackup.MultiSelect = false;
            this.dataGridBackup.Name = "dataGridBackup";
            this.dataGridBackup.ReadOnly = true;
            this.dataGridBackup.Size = new System.Drawing.Size(643, 232);
            this.dataGridBackup.TabIndex = 0;
            this.dataGridBackup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBackup_CellClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::Integrador_2.Properties.Resources.disco_flexible;
            this.btnGuardar.Location = new System.Drawing.Point(701, 90);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(61, 49);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Integrador_2.Properties.Resources.atras;
            this.btnSalir.Location = new System.Drawing.Point(29, 17);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(52, 42);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("3Dventure", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Backup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("3Dventure", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(254, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "BITACORA";
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.Location = new System.Drawing.Point(29, 371);
            this.dgvBitacora.MultiSelect = false;
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.ReadOnly = true;
            this.dgvBitacora.Size = new System.Drawing.Size(643, 150);
            this.dgvBitacora.TabIndex = 6;
            // 
            // FmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 556);
            this.Controls.Add(this.dgvBitacora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dataGridBackup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmBackup";
            this.Text = "Recuperacion";
            this.Load += new System.EventHandler(this.FmBackup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBackup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridBackup;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvBitacora;
    }
}