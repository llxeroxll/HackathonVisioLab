namespace HackathonVisioLab.View
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minhasComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recomendaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprasToolStripMenuItem,
            this.recomendaçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(512, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minhasComprasToolStripMenuItem,
            this.realizarComprasToolStripMenuItem});
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // minhasComprasToolStripMenuItem
            // 
            this.minhasComprasToolStripMenuItem.Name = "minhasComprasToolStripMenuItem";
            this.minhasComprasToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.minhasComprasToolStripMenuItem.Text = "Minhas compras";
            // 
            // realizarComprasToolStripMenuItem
            // 
            this.realizarComprasToolStripMenuItem.Name = "realizarComprasToolStripMenuItem";
            this.realizarComprasToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.realizarComprasToolStripMenuItem.Text = "Realizar compras";
            // 
            // recomendaçõesToolStripMenuItem
            // 
            this.recomendaçõesToolStripMenuItem.Name = "recomendaçõesToolStripMenuItem";
            this.recomendaçõesToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.recomendaçõesToolStripMenuItem.Text = "Recomendações";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 370);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minhasComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizarComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recomendaçõesToolStripMenuItem;
    }
}