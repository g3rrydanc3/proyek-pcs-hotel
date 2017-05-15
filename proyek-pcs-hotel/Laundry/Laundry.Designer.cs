namespace proyek_pcs_hotel
{
    partial class Laundry
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
            this.detailLaundryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLaundryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laundry_Detail1 = new proyek_pcs_hotel.Laundry_Detail();
            this.laundry_Order1 = new proyek_pcs_hotel.Laundry_Order.Laundry_Order();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLaundryToolStripMenuItem,
            this.detailLaundryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(627, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // detailLaundryToolStripMenuItem
            // 
            this.detailLaundryToolStripMenuItem.Name = "detailLaundryToolStripMenuItem";
            this.detailLaundryToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.detailLaundryToolStripMenuItem.Text = "Detail Laundry";
            this.detailLaundryToolStripMenuItem.Click += new System.EventHandler(this.detailLaundryToolStripMenuItem_Click);
            // 
            // newLaundryToolStripMenuItem
            // 
            this.newLaundryToolStripMenuItem.Name = "newLaundryToolStripMenuItem";
            this.newLaundryToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.newLaundryToolStripMenuItem.Text = "New Laundry";
            this.newLaundryToolStripMenuItem.Click += new System.EventHandler(this.newLaundryToolStripMenuItem_Click);
            // 
            // laundry_Detail1
            // 
            this.laundry_Detail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laundry_Detail1.Location = new System.Drawing.Point(0, 24);
            this.laundry_Detail1.Name = "laundry_Detail1";
            this.laundry_Detail1.Size = new System.Drawing.Size(627, 368);
            this.laundry_Detail1.TabIndex = 2;
            // 
            // laundry_Order1
            // 
            this.laundry_Order1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laundry_Order1.Location = new System.Drawing.Point(0, 24);
            this.laundry_Order1.Name = "laundry_Order1";
            this.laundry_Order1.Size = new System.Drawing.Size(627, 368);
            this.laundry_Order1.TabIndex = 3;
            // 
            // Laundry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(627, 392);
            this.Controls.Add(this.laundry_Order1);
            this.Controls.Add(this.laundry_Detail1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Laundry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laundry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newLaundryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailLaundryToolStripMenuItem;
        private Laundry_Detail laundry_Detail1;
        private Laundry_Order.Laundry_Order laundry_Order1;

    }
}