namespace Integrador_2
{
    partial class FmJuegosPedidos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmJuegosPedidos));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPlataformaJ = new System.Windows.Forms.ComboBox();
            this.cbCategoriaJ = new System.Windows.Forms.ComboBox();
            this.txtSoloNum1 = new Integrador_2.txtSoloNum();
            this.txtNombreJ = new System.Windows.Forms.TextBox();
            this.dataGribJuegosPedidos = new System.Windows.Forms.DataGridView();
            this.btn_BuscarXml = new System.Windows.Forms.Button();
            this.btn_AgregarDatosXML = new System.Windows.Forms.Button();
            this.bEJuegoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGribJuegosPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEJuegoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Juegos a Pedir";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnReporte);
            this.groupBox1.Controls.Add(this.btn_BuscarXml);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btn_AgregarDatosXML);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbPlataformaJ);
            this.groupBox1.Controls.Add(this.cbCategoriaJ);
            this.groupBox1.Controls.Add(this.txtSoloNum1);
            this.groupBox1.Controls.Add(this.txtNombreJ);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(553, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 340);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XML";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Plataforma:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Categoria:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cantidad:";
            // 
            // cbPlataformaJ
            // 
            this.cbPlataformaJ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlataformaJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlataformaJ.FormattingEnabled = true;
            this.cbPlataformaJ.Location = new System.Drawing.Point(95, 189);
            this.cbPlataformaJ.Name = "cbPlataformaJ";
            this.cbPlataformaJ.Size = new System.Drawing.Size(143, 24);
            this.cbPlataformaJ.TabIndex = 4;
            // 
            // cbCategoriaJ
            // 
            this.cbCategoriaJ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoriaJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoriaJ.FormattingEnabled = true;
            this.cbCategoriaJ.Location = new System.Drawing.Point(95, 137);
            this.cbCategoriaJ.Name = "cbCategoriaJ";
            this.cbCategoriaJ.Size = new System.Drawing.Size(143, 24);
            this.cbCategoriaJ.TabIndex = 3;
            // 
            // txtSoloNum1
            // 
            this.txtSoloNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoloNum1.Location = new System.Drawing.Point(92, 48);
            this.txtSoloNum1.Name = "txtSoloNum1";
            this.txtSoloNum1.Size = new System.Drawing.Size(52, 22);
            this.txtSoloNum1.TabIndex = 1;
            // 
            // txtNombreJ
            // 
            this.txtNombreJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreJ.Location = new System.Drawing.Point(92, 95);
            this.txtNombreJ.Name = "txtNombreJ";
            this.txtNombreJ.Size = new System.Drawing.Size(245, 22);
            this.txtNombreJ.TabIndex = 2;
            // 
            // dataGribJuegosPedidos
            // 
            this.dataGribJuegosPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGribJuegosPedidos.Location = new System.Drawing.Point(12, 56);
            this.dataGribJuegosPedidos.MultiSelect = false;
            this.dataGribJuegosPedidos.Name = "dataGribJuegosPedidos";
            this.dataGribJuegosPedidos.ReadOnly = true;
            this.dataGribJuegosPedidos.Size = new System.Drawing.Size(535, 219);
            this.dataGribJuegosPedidos.TabIndex = 8;
            this.dataGribJuegosPedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGribJuegosPedidos_CellClick_1);
            // 
            // btn_BuscarXml
            // 
            this.btn_BuscarXml.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarXml.Image = ((System.Drawing.Image)(resources.GetObject("btn_BuscarXml.Image")));
            this.btn_BuscarXml.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BuscarXml.Location = new System.Drawing.Point(213, 230);
            this.btn_BuscarXml.Name = "btn_BuscarXml";
            this.btn_BuscarXml.Size = new System.Drawing.Size(124, 41);
            this.btn_BuscarXml.TabIndex = 6;
            this.btn_BuscarXml.Text = "Buscar XML";
            this.btn_BuscarXml.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_BuscarXml.UseVisualStyleBackColor = true;
            this.btn_BuscarXml.Click += new System.EventHandler(this.btn_BuscarXml_Click);
            // 
            // btn_AgregarDatosXML
            // 
            this.btn_AgregarDatosXML.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarDatosXML.Image = ((System.Drawing.Image)(resources.GetObject("btn_AgregarDatosXML.Image")));
            this.btn_AgregarDatosXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AgregarDatosXML.Location = new System.Drawing.Point(20, 230);
            this.btn_AgregarDatosXML.Name = "btn_AgregarDatosXML";
            this.btn_AgregarDatosXML.Size = new System.Drawing.Size(124, 41);
            this.btn_AgregarDatosXML.TabIndex = 5;
            this.btn_AgregarDatosXML.Text = "Agregar XML";
            this.btn_AgregarDatosXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_AgregarDatosXML.UseVisualStyleBackColor = true;
            this.btn_AgregarDatosXML.Click += new System.EventHandler(this.button1_Click);
            // 
            // bEJuegoBindingSource
            // 
            this.bEJuegoBindingSource.DataSource = typeof(BE.BEJuego);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Integrador_2.Properties.Resources.atras;
            this.btnSalir.Location = new System.Drawing.Point(12, 306);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(45, 41);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::Integrador_2.Properties.Resources.limpiar;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(20, 281);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(124, 41);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // btnReporte
            // 
            this.btnReporte.Image = global::Integrador_2.Properties.Resources.Reporte;
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporte.Location = new System.Drawing.Point(213, 281);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(124, 41);
            this.btnReporte.TabIndex = 11;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // FmJuegosPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(940, 375);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dataGribJuegosPedidos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmJuegosPedidos";
            this.Text = "Juegos Pedidos";
            this.Load += new System.EventHandler(this.FmJuegosPedidos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGribJuegosPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEJuegoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bEJuegoBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_AgregarDatosXML;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPlataformaJ;
        private System.Windows.Forms.ComboBox cbCategoriaJ;
        private txtSoloNum txtSoloNum1;
        private System.Windows.Forms.TextBox txtNombreJ;
        private System.Windows.Forms.Button btn_BuscarXml;
        private System.Windows.Forms.DataGridView dataGribJuegosPedidos;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnSalir;
    }
}