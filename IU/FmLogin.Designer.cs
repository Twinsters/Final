namespace Integrador_2
{
    partial class FmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmLogin));
            this.uC_Log1 = new Integrador_2.UC_Log();
            this.SuspendLayout();
            // 
            // uC_Log1
            // 
            this.uC_Log1.Location = new System.Drawing.Point(12, 15);
            this.uC_Log1.Name = "uC_Log1";
            this.uC_Log1.Size = new System.Drawing.Size(254, 211);
            this.uC_Log1.TabIndex = 0;
            this.uC_Log1.Load += new System.EventHandler(this.uC_Log1_Load);
            // 
            // FmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 238);
            this.Controls.Add(this.uC_Log1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmLogin";
            this.Text = "Login";
            this.ResumeLayout(false);

        }


        #endregion

        private UC_Log uC_Log1;
    }
}