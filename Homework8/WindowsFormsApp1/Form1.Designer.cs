
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.queryBox = new System.Windows.Forms.TextBox();
            this.queryByID = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.queryByClientName = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.orderGridView = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderBingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.detailsBox = new System.Windows.Forms.TextBox();
            this.detailsButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.itemGridView = new System.Windows.Forms.DataGridView();
            this.GoodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodsPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.changeBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // queryBox
            // 
            this.queryBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.queryBox.Location = new System.Drawing.Point(3, 15);
            this.queryBox.Name = "queryBox";
            this.queryBox.Size = new System.Drawing.Size(100, 28);
            this.queryBox.TabIndex = 0;
            // 
            // queryByID
            // 
            this.queryByID.Location = new System.Drawing.Point(109, 3);
            this.queryByID.Name = "queryByID";
            this.queryByID.Size = new System.Drawing.Size(166, 49);
            this.queryByID.TabIndex = 1;
            this.queryByID.Text = "根据编号查询";
            this.queryByID.UseVisualStyleBackColor = true;
            this.queryByID.Click += new System.EventHandler(this.queryByID_Click);
            // 
            // changeButton
            // 
            this.changeButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.changeButton.Location = new System.Drawing.Point(709, 10);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(91, 37);
            this.changeButton.TabIndex = 3;
            this.changeButton.Text = "修改订单";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addButton.Location = new System.Drawing.Point(3, 61);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(93, 34);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "新建订单";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // queryByClientName
            // 
            this.queryByClientName.Location = new System.Drawing.Point(281, 3);
            this.queryByClientName.Name = "queryByClientName";
            this.queryByClientName.Size = new System.Drawing.Size(166, 52);
            this.queryByClientName.TabIndex = 6;
            this.queryByClientName.Text = "根据客户查询";
            this.queryByClientName.UseVisualStyleBackColor = true;
            this.queryByClientName.Click += new System.EventHandler(this.queryByClientName_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exportButton.Location = new System.Drawing.Point(912, 11);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(91, 35);
            this.exportButton.TabIndex = 7;
            this.exportButton.Text = "导出订单";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // importButton
            // 
            this.importButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.importButton.Location = new System.Drawing.Point(1009, 11);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(91, 35);
            this.importButton.TabIndex = 8;
            this.importButton.Text = "导入订单";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // orderGridView
            // 
            this.orderGridView.AutoGenerateColumns = false;
            this.orderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.clientNameDataGridViewTextBoxColumn,
            this.sumDataGridViewTextBoxColumn});
            this.orderGridView.DataSource = this.orderBingSource;
            this.orderGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.orderGridView.Location = new System.Drawing.Point(0, 0);
            this.orderGridView.Name = "orderGridView";
            this.orderGridView.RowHeadersWidth = 62;
            this.orderGridView.RowTemplate.Height = 30;
            this.orderGridView.Size = new System.Drawing.Size(526, 351);
            this.orderGridView.TabIndex = 2;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 150;
            // 
            // clientNameDataGridViewTextBoxColumn
            // 
            this.clientNameDataGridViewTextBoxColumn.DataPropertyName = "ClientName";
            this.clientNameDataGridViewTextBoxColumn.HeaderText = "ClientName";
            this.clientNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.clientNameDataGridViewTextBoxColumn.Name = "clientNameDataGridViewTextBoxColumn";
            this.clientNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // sumDataGridViewTextBoxColumn
            // 
            this.sumDataGridViewTextBoxColumn.DataPropertyName = "Sum";
            this.sumDataGridViewTextBoxColumn.HeaderText = "Sum";
            this.sumDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
            this.sumDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumDataGridViewTextBoxColumn.Width = 150;
            // 
            // orderBingSource
            // 
            this.orderBingSource.DataSource = typeof(OrderSpace.Order);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.queryBox);
            this.flowLayoutPanel1.Controls.Add(this.queryByID);
            this.flowLayoutPanel1.Controls.Add(this.queryByClientName);
            this.flowLayoutPanel1.Controls.Add(this.detailsBox);
            this.flowLayoutPanel1.Controls.Add(this.detailsButton);
            this.flowLayoutPanel1.Controls.Add(this.changeButton);
            this.flowLayoutPanel1.Controls.Add(this.changeBox);
            this.flowLayoutPanel1.Controls.Add(this.exportButton);
            this.flowLayoutPanel1.Controls.Add(this.importButton);
            this.flowLayoutPanel1.Controls.Add(this.returnButton);
            this.flowLayoutPanel1.Controls.Add(this.addButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1253, 99);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // detailsBox
            // 
            this.detailsBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.detailsBox.Location = new System.Drawing.Point(453, 15);
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.Size = new System.Drawing.Size(100, 28);
            this.detailsBox.TabIndex = 9;
            // 
            // detailsButton
            // 
            this.detailsButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.detailsButton.Location = new System.Drawing.Point(559, 3);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(144, 52);
            this.detailsButton.TabIndex = 10;
            this.detailsButton.Text = "根据编号查明细";
            this.detailsButton.UseVisualStyleBackColor = true;
            this.detailsButton.Click += new System.EventHandler(this.detailsButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.returnButton.Location = new System.Drawing.Point(1106, 11);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(94, 35);
            this.returnButton.TabIndex = 11;
            this.returnButton.Text = "返回";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.itemGridView);
            this.panel1.Controls.Add(this.orderGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1253, 351);
            this.panel1.TabIndex = 10;
            // 
            // itemGridView
            // 
            this.itemGridView.AutoGenerateColumns = false;
            this.itemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GoodsName,
            this.GoodsPrice,
            this.Number});
            this.itemGridView.DataSource = this.itemBindingSource;
            this.itemGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemGridView.Location = new System.Drawing.Point(526, 0);
            this.itemGridView.Name = "itemGridView";
            this.itemGridView.RowHeadersWidth = 62;
            this.itemGridView.RowTemplate.Height = 30;
            this.itemGridView.Size = new System.Drawing.Size(727, 351);
            this.itemGridView.TabIndex = 3;
            // 
            // GoodsName
            // 
            this.GoodsName.DataPropertyName = "GoodsName";
            this.GoodsName.HeaderText = "GoodsName";
            this.GoodsName.MinimumWidth = 8;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.Width = 150;
            // 
            // GoodsPrice
            // 
            this.GoodsPrice.DataPropertyName = "GoodsPrice";
            this.GoodsPrice.HeaderText = "GoodsPrice";
            this.GoodsPrice.MinimumWidth = 8;
            this.GoodsPrice.Name = "GoodsPrice";
            this.GoodsPrice.Width = 150;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "Number";
            this.Number.MinimumWidth = 8;
            this.Number.Name = "Number";
            this.Number.Width = 150;
            // 
            // changeBox
            // 
            this.changeBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.changeBox.Location = new System.Drawing.Point(806, 15);
            this.changeBox.Name = "changeBox";
            this.changeBox.Size = new System.Drawing.Size(100, 28);
            this.changeBox.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox queryBox;
        private System.Windows.Forms.Button queryByID;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button queryByClientName;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.DataGridView orderGridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox detailsBox;
        private System.Windows.Forms.Button detailsButton;
        private System.Windows.Forms.DataGridView itemGridView;
        public System.Windows.Forms.BindingSource orderBingSource;
        public System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.TextBox changeBox;
    }
}

