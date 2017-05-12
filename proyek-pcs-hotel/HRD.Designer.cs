namespace proyek_pcs_hotel
{
    partial class HRD
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
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recruitmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hrD_Payroll1 = new proyek_pcs_hotel.HRD_Payroll();
            this.hrD_People1 = new proyek_pcs_hotel.HRD_People();
            this.hrD_Recruitment1 = new proyek_pcs_hotel.HRD_Recruitment();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peopleToolStripMenuItem,
            this.recruitmentToolStripMenuItem,
            this.payrollToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // recruitmentToolStripMenuItem
            // 
            this.recruitmentToolStripMenuItem.Name = "recruitmentToolStripMenuItem";
            this.recruitmentToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.recruitmentToolStripMenuItem.Text = "Recruitment";
            this.recruitmentToolStripMenuItem.Click += new System.EventHandler(this.recruitmentToolStripMenuItem_Click);
            // 
            // payrollToolStripMenuItem
            // 
            this.payrollToolStripMenuItem.Name = "payrollToolStripMenuItem";
            this.payrollToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.payrollToolStripMenuItem.Text = "Payroll";
            this.payrollToolStripMenuItem.Click += new System.EventHandler(this.payrollToolStripMenuItem_Click);
            // 
            // hrD_Payroll1
            // 
            this.hrD_Payroll1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrD_Payroll1.Location = new System.Drawing.Point(0, 24);
            this.hrD_Payroll1.Name = "hrD_Payroll1";
            this.hrD_Payroll1.Size = new System.Drawing.Size(784, 537);
            this.hrD_Payroll1.TabIndex = 4;
            // 
            // hrD_People1
            // 
            this.hrD_People1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrD_People1.Location = new System.Drawing.Point(0, 24);
            this.hrD_People1.Name = "hrD_People1";
            this.hrD_People1.Size = new System.Drawing.Size(784, 537);
            this.hrD_People1.TabIndex = 3;
            // 
            // hrD_Recruitment1
            // 
            this.hrD_Recruitment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrD_Recruitment1.Location = new System.Drawing.Point(0, 24);
            this.hrD_Recruitment1.Name = "hrD_Recruitment1";
            this.hrD_Recruitment1.Size = new System.Drawing.Size(784, 537);
            this.hrD_Recruitment1.TabIndex = 2;
            // 
            // HRD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.hrD_Payroll1);
            this.Controls.Add(this.hrD_People1);
            this.Controls.Add(this.hrD_Recruitment1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HRD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HRD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recruitmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payrollToolStripMenuItem;
        private HRD_Recruitment hrD_Recruitment1;
        private HRD_People hrD_People1;
        private HRD_Payroll hrD_Payroll1;
    }
}