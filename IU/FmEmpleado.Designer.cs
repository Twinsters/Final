namespace Integrador_2
{
    partial class FmEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmEmpleado));
            this.dtGripViEmpl = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnNuevoEmpleado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGripViEmpl)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGripViEmpl
            // 
            this.dtGripViEmpl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGripViEmpl.Location = new System.Drawing.Point(34, 87);
            this.dtGripViEmpl.MultiSelect = false;
            this.dtGripViEmpl.Name = "dtGripViEmpl";
            this.dtGripViEmpl.ReadOnly = true;
            this.dtGripViEmpl.Size = new System.Drawing.Size(885, 315);
            this.dtGripViEmpl.TabIndex = 0;
            this.dtGripViEmpl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGripViEmpl_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("3Dventure", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(357, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Empleados";
            // 
            // btnAtras
            // 
            this.btnAtras.Image = global::Integrador_2.Properties.Resources.atras;
            this.btnAtras.Location = new System.Drawing.Point(34, 26);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(53, 42);
            this.btnAtras.TabIndex = 2;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnNuevoEmpleado
            // 
            this.btnNuevoEmpleado.Image = global::Integrador_2.Properties.Resources.agregar;
            this.btnNuevoEmpleado.Location = new System.Drawing.Point(93, 26);
            this.btnNuevoEmpleado.Name = "btnNuevoEmpleado";
            this.btnNuevoEmpleado.Size = new System.Drawing.Size(51, 42);
            this.btnNuevoEmpleado.TabIndex = 3;
            this.btnNuevoEmpleado.UseVisualStyleBackColor = true;
            this.btnNuevoEmpleado.Click += new System.EventHandler(this.btnNuevoEmpleado_Click);
            // 
            // FmEmpleado
            // 
            this.ClientSize = new System.Drawing.Size(956, 451);
            this.Controls.Add(this.btnNuevoEmpleado);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtGripViEmpl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmEmpleado";
            this.Text = "Empleados";
            this.Load += new System.EventHandler(this.FmEmpleado_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dtGripViEmpl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.DataGridView dtGripViEmpl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnNuevoEmpleado;
    }
}