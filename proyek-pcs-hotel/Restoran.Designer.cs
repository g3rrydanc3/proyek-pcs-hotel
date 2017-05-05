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
            this.buttonDineIn = new System.Windows.Forms.Button();
            this.buttonTakeAway = new System.Windows.Forms.Button();
            this.buttonDelivery = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelDetail = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDineIn
            // 
            this.buttonDineIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDineIn.Location = new System.Drawing.Point(0, 0);
            this.buttonDineIn.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.buttonDineIn.Name = "buttonDineIn";
            this.buttonDineIn.Size = new System.Drawing.Size(979, 467);
            this.buttonDineIn.TabIndex = 0;
            this.buttonDineIn.Text = "Dine In";
            this.buttonDineIn.UseVisualStyleBackColor = true;
            // 
            // buttonTakeAway
            // 
            this.buttonTakeAway.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTakeAway.Location = new System.Drawing.Point(0, 0);
            this.buttonTakeAway.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.buttonTakeAway.Name = "buttonTakeAway";
            this.buttonTakeAway.Size = new System.Drawing.Size(979, 467);
            this.buttonTakeAway.TabIndex = 1;
            this.buttonTakeAway.Text = "Take Away";
            this.buttonTakeAway.UseVisualStyleBackColor = true;
            // 
            // buttonDelivery
            // 
            this.buttonDelivery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelivery.Location = new System.Drawing.Point(0, 0);
            this.buttonDelivery.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.buttonDelivery.Name = "buttonDelivery";
            this.buttonDelivery.Size = new System.Drawing.Size(979, 467);
            this.buttonDelivery.TabIndex = 2;
            this.buttonDelivery.Text = "Delivery";
            this.buttonDelivery.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(379, 409);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.HeaderText = "Q";
            this.Column3.MaxInputLength = 2;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 27;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.HeaderText = "Nama";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 57;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "No";
            this.Column1.MaxInputLength = 2;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 35;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelDetail, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel, 1, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(979, 467);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelDetail
            // 
            this.tableLayoutPanelDetail.ColumnCount = 2;
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDetail.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelDetail.Name = "tableLayoutPanelDetail";
            this.tableLayoutPanelDetail.RowCount = 2;
            this.tableLayoutPanelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDetail.Size = new System.Drawing.Size(306, 394);
            this.tableLayoutPanelDetail.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Location = new System.Drawing.Point(394, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // Restoran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(979, 467);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.buttonDelivery);
            this.Controls.Add(this.buttonTakeAway);
            this.Controls.Add(this.buttonDineIn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Restoran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restoran";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonDineIn;
        private System.Windows.Forms.Button buttonTakeAway;
        private System.Windows.Forms.Button buttonDelivery;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDetail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}