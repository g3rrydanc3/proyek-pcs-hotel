﻿namespace proyek_pcs_hotel
{
    partial class SB
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
            this.sB_31 = new proyek_pcs_hotel.Self_Booking.SB_3();
            this.sB_21 = new proyek_pcs_hotel.Self_Booking.SB_2();
            this.sB_11 = new proyek_pcs_hotel.Self_Booking.SB_1();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sB_31
            // 
            this.sB_31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sB_31.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sB_31.Location = new System.Drawing.Point(0, 0);
            this.sB_31.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.sB_31.Name = "sB_31";
            this.sB_31.Size = new System.Drawing.Size(968, 576);
            this.sB_31.TabIndex = 2;
            // 
            // sB_21
            // 
            this.sB_21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sB_21.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sB_21.Location = new System.Drawing.Point(0, 0);
            this.sB_21.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.sB_21.Name = "sB_21";
            this.sB_21.Size = new System.Drawing.Size(968, 576);
            this.sB_21.TabIndex = 1;
            // 
            // sB_11
            // 
            this.sB_11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sB_11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sB_11.Location = new System.Drawing.Point(0, 0);
            this.sB_11.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.sB_11.Name = "sB_11";
            this.sB_11.Size = new System.Drawing.Size(968, 576);
            this.sB_11.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "Log out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 576);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sB_31);
            this.Controls.Add(this.sB_21);
            this.Controls.Add(this.sB_11);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Self Booking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.SB_Resize);
            this.ResumeLayout(false);

        }


        #endregion

        private Self_Booking.SB_1 sB_11;
        private Self_Booking.SB_2 sB_21;
        private Self_Booking.SB_3 sB_31;
        private System.Windows.Forms.Button button1;
    }
}