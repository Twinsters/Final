namespace Integrador_2
{
    partial class FmPrincipal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.juegosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.perfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfilToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.ventaToolStripMenuItem,
            this.aBMToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.perfilToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventaToolStripMenuItem1,
            this.consultaToolStripMenuItem,
            this.ComprasToolStripMenuItem,
            this.dashboardToolStripMenuItem});
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ventaToolStripMenuItem.Text = "Acciones";
            this.ventaToolStripMenuItem.Click += new System.EventHandler(this.ventaToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem1
            // 
            this.ventaToolStripMenuItem1.Name = "ventaToolStripMenuItem1";
            this.ventaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.ventaToolStripMenuItem1.Text = "Venta";
            this.ventaToolStripMenuItem1.Click += new System.EventHandler(this.ventaToolStripMenuItem1_Click);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.consultaToolStripMenuItem.Text = "Informes";
            this.consultaToolStripMenuItem.Click += new System.EventHandler(this.consultaToolStripMenuItem_Click);
            // 
            // ComprasToolStripMenuItem
            // 
            this.ComprasToolStripMenuItem.Name = "ComprasToolStripMenuItem";
            this.ComprasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ComprasToolStripMenuItem.Text = "Compras";
            this.ComprasToolStripMenuItem.Click += new System.EventHandler(this.xMLJuegosPedidosToolStripMenuItem_Click);
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // aBMToolStripMenuItem
            // 
            this.aBMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.juegosToolStripMenuItem,
            this.empleadosToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.ventasToolStripMenuItem});
            this.aBMToolStripMenuItem.Name = "aBMToolStripMenuItem";
            this.aBMToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.aBMToolStripMenuItem.Text = "ABM";
            // 
            // juegosToolStripMenuItem
            // 
            this.juegosToolStripMenuItem.Name = "juegosToolStripMenuItem";
            this.juegosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.juegosToolStripMenuItem.Text = "Juegos";
            this.juegosToolStripMenuItem.Click += new System.EventHandler(this.juegosToolStripMenuItem_Click);
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.empleadosToolStripMenuItem.Text = "Empleados";
            this.empleadosToolStripMenuItem.Click += new System.EventHandler(this.empleadosToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem1});
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.backupToolStripMenuItem.Text = "Backup";
            // 
            // backupToolStripMenuItem1
            // 
            this.backupToolStripMenuItem1.Name = "backupToolStripMenuItem1";
            this.backupToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.backupToolStripMenuItem1.Text = "Backups";
            this.backupToolStripMenuItem1.Click += new System.EventHandler(this.backupToolStripMenuItem1_Click);
            // 
            // perfilToolStripMenuItem
            // 
            this.perfilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfilToolStripMenuItem1});
            this.perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            this.perfilToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.perfilToolStripMenuItem.Text = "Perfil";
            // 
            // perfilToolStripMenuItem1
            // 
            this.perfilToolStripMenuItem1.Name = "perfilToolStripMenuItem1";
            this.perfilToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.perfilToolStripMenuItem1.Text = "Perfiles";
            this.perfilToolStripMenuItem1.Click += new System.EventHandler(this.perfilToolStripMenuItem1_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // FmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FmPrincipal";
            this.Text = "Trabajo Final";
            this.Load += new System.EventHandler(this.FmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem juegosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem perfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perfilToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}

