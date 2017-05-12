namespace proyek_pcs_hotel
{
    partial class Receptionist
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
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchKamarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receptionist_Booking1 = new proyek_pcs_hotel.Receptionist_Booking();
            this.receptionist_List1 = new proyek_pcs_hotel.Receptionist_List();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.searchKamarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(888, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.homeToolStripMenuItem.Text = "List Kamar";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // searchKamarToolStripMenuItem
            // 
            this.searchKamarToolStripMenuItem.Name = "searchKamarToolStripMenuItem";
            this.searchKamarToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.searchKamarToolStripMenuItem.Text = "Search Kamar";
            this.searchKamarToolStripMenuItem.Click += new System.EventHandler(this.searchKamarToolStripMenuItem_Click);
            // 
            // receptionist_Booking1
            // 
            this.receptionist_Booking1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receptionist_Booking1.Location = new System.Drawing.Point(0, 24);
            this.receptionist_Booking1.Margin = new System.Windows.Forms.Padding(2);
            this.receptionist_Booking1.Name = "receptionist_Booking1";
            this.receptionist_Booking1.Size = new System.Drawing.Size(888, 439);
            this.receptionist_Booking1.TabIndex = 2;
            // 
            // receptionist_List1
            // 
            this.receptionist_List1.BackColor = System.Drawing.SystemColors.Control;
            this.receptionist_List1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receptionist_List1.Location = new System.Drawing.Point(0, 24);
            this.receptionist_List1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.receptionist_List1.Name = "receptionist_List1";
            this.receptionist_List1.Size = new System.Drawing.Size(888, 439);
            this.receptionist_List1.TabIndex = 3;
            // 
            // Receptionist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(888, 463);
            this.Controls.Add(this.receptionist_Booking1);
            this.Controls.Add(this.receptionist_List1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Receptionist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receptionist";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchKamarToolStripMenuItem;
        private Receptionist_Booking receptionist_Booking1;
        private Receptionist_List receptionist_List1;
    }
}