namespace proyek_pcs_hotel
{
    partial class Restoran
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
            this.dataGridViewFood = new System.Windows.Forms.DataGridView();
            this.dataGridViewDrink = new System.Windows.Forms.DataGridView();
            this.buttonDineIn = new System.Windows.Forms.Button();
            this.buttonTakeAway = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDelivery = new System.Windows.Forms.Button();
            this.buttonOrderDrink = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownDrink = new System.Windows.Forms.NumericUpDown();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownFood = new System.Windows.Forms.NumericUpDown();
            this.buttonOrderFood = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.messageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrink)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDrink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFood)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewFood
            // 
            this.dataGridViewFood.AllowUserToAddRows = false;
            this.dataGridViewFood.AllowUserToDeleteRows = false;
            this.dataGridViewFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFood.Location = new System.Drawing.Point(4, 36);
            this.dataGridViewFood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewFood.MultiSelect = false;
            this.dataGridViewFood.Name = "dataGridViewFood";
            this.dataGridViewFood.ReadOnly = true;
            this.dataGridViewFood.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFood.Size = new System.Drawing.Size(281, 221);
            this.dataGridViewFood.TabIndex = 4;
            this.dataGridViewFood.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFood_CellClick);
            // 
            // dataGridViewDrink
            // 
            this.dataGridViewDrink.AllowUserToAddRows = false;
            this.dataGridViewDrink.AllowUserToDeleteRows = false;
            this.dataGridViewDrink.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDrink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDrink.Location = new System.Drawing.Point(4, 424);
            this.dataGridViewDrink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewDrink.MultiSelect = false;
            this.dataGridViewDrink.Name = "dataGridViewDrink";
            this.dataGridViewDrink.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewDrink, 2);
            this.dataGridViewDrink.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDrink.Size = new System.Drawing.Size(281, 244);
            this.dataGridViewDrink.TabIndex = 3;
            this.dataGridViewDrink.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDrink_CellClick);
            // 
            // buttonDineIn
            // 
            this.buttonDineIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDineIn.Location = new System.Drawing.Point(304, 672);
            this.buttonDineIn.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDineIn.Name = "buttonDineIn";
            this.tableLayoutPanel1.SetRowSpan(this.buttonDineIn, 3);
            this.buttonDineIn.Size = new System.Drawing.Size(289, 128);
            this.buttonDineIn.TabIndex = 0;
            this.buttonDineIn.Text = "Dine In";
            this.buttonDineIn.UseVisualStyleBackColor = true;
            this.buttonDineIn.Click += new System.EventHandler(this.buttonDineIn_Click);
            // 
            // buttonTakeAway
            // 
            this.buttonTakeAway.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTakeAway.Location = new System.Drawing.Point(593, 672);
            this.buttonTakeAway.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTakeAway.Name = "buttonTakeAway";
            this.tableLayoutPanel1.SetRowSpan(this.buttonTakeAway, 3);
            this.buttonTakeAway.Size = new System.Drawing.Size(290, 128);
            this.buttonTakeAway.TabIndex = 1;
            this.buttonTakeAway.Text = "Take Away";
            this.buttonTakeAway.UseVisualStyleBackColor = true;
            this.buttonTakeAway.Click += new System.EventHandler(this.buttonTakeAway_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.96774F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.96774F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.03226F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.03226F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonTakeAway, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelivery, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.buttonOrderDrink, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.buttonDineIn, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownDrink, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownFood, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonOrderFood, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewDrink, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewFood, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelete, 4, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 42);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.42373F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.78814F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.78814F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1176, 800);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Food";
            // 
            // buttonDelivery
            // 
            this.buttonDelivery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelivery.Location = new System.Drawing.Point(883, 672);
            this.buttonDelivery.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDelivery.Name = "buttonDelivery";
            this.tableLayoutPanel1.SetRowSpan(this.buttonDelivery, 3);
            this.buttonDelivery.Size = new System.Drawing.Size(293, 128);
            this.buttonDelivery.TabIndex = 2;
            this.buttonDelivery.Text = "Delivery To Room";
            this.buttonDelivery.UseVisualStyleBackColor = true;
            this.buttonDelivery.Click += new System.EventHandler(this.buttonDelivery_Click);
            // 
            // buttonOrderDrink
            // 
            this.buttonOrderDrink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOrderDrink.Enabled = false;
            this.buttonOrderDrink.Location = new System.Drawing.Point(4, 755);
            this.buttonOrderDrink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOrderDrink.Name = "buttonOrderDrink";
            this.buttonOrderDrink.Size = new System.Drawing.Size(281, 41);
            this.buttonOrderDrink.TabIndex = 10;
            this.buttonOrderDrink.Text = "Order Drink";
            this.buttonOrderDrink.UseVisualStyleBackColor = true;
            this.buttonOrderDrink.Click += new System.EventHandler(this.buttonOrderDrink_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 672);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quantity Drink";
            // 
            // numericUpDownDrink
            // 
            this.numericUpDownDrink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownDrink.Location = new System.Drawing.Point(4, 708);
            this.numericUpDownDrink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownDrink.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDrink.Name = "numericUpDownDrink";
            this.numericUpDownDrink.Size = new System.Drawing.Size(281, 39);
            this.numericUpDownDrink.TabIndex = 9;
            this.numericUpDownDrink.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView3, 3);
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(308, 4);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView3.Name = "dataGridView3";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView3, 7);
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(864, 587);
            this.dataGridView3.TabIndex = 7;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 83;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Jenis";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 103;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Menu";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 114;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Q";
            this.Column4.Name = "Column4";
            this.Column4.Width = 69;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(4, 261);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 32);
            this.label4.TabIndex = 11;
            this.label4.Text = "Quantity Food";
            // 
            // numericUpDownFood
            // 
            this.numericUpDownFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownFood.Location = new System.Drawing.Point(4, 297);
            this.numericUpDownFood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownFood.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFood.Name = "numericUpDownFood";
            this.numericUpDownFood.Size = new System.Drawing.Size(281, 39);
            this.numericUpDownFood.TabIndex = 12;
            this.numericUpDownFood.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonOrderFood
            // 
            this.buttonOrderFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOrderFood.Enabled = false;
            this.buttonOrderFood.Location = new System.Drawing.Point(4, 344);
            this.buttonOrderFood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOrderFood.Name = "buttonOrderFood";
            this.buttonOrderFood.Size = new System.Drawing.Size(281, 40);
            this.buttonOrderFood.TabIndex = 13;
            this.buttonOrderFood.Text = "Order Food";
            this.buttonOrderFood.UseVisualStyleBackColor = true;
            this.buttonOrderFood.Click += new System.EventHandler(this.buttonOrderFood_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 388);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Drink";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(887, 599);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(285, 69);
            this.buttonDelete.TabIndex = 14;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1176, 42);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // messageToolStripMenuItem
            // 
            this.messageToolStripMenuItem.Name = "messageToolStripMenuItem";
            this.messageToolStripMenuItem.Size = new System.Drawing.Size(121, 36);
            this.messageToolStripMenuItem.Text = "Message";
            // 
            // Restoran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1176, 842);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Restoran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restoran";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Restoran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrink)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDrink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFood)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFood;
        private System.Windows.Forms.DataGridView dataGridViewDrink;
        private System.Windows.Forms.Button buttonDineIn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownDrink;
        private System.Windows.Forms.Button buttonOrderDrink;
        private System.Windows.Forms.Button buttonTakeAway;
        private System.Windows.Forms.Button buttonDelivery;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownFood;
        private System.Windows.Forms.Button buttonOrderFood;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button buttonDelete;
    }
}