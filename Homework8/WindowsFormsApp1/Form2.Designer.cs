
namespace WindowsFormsApp1
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.ClientBox = new System.Windows.Forms.TextBox();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.ClientName = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.detailsBox = new System.Windows.Forms.GroupBox();
            this.detailsGridView = new System.Windows.Forms.DataGridView();
            this.GoodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.orderSource = new System.Windows.Forms.BindingSource(this.components);
            this.infoBox.SuspendLayout();
            this.detailsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderSource)).BeginInit();
            this.SuspendLayout();
            // 
            // infoBox
            // 
            this.infoBox.Controls.Add(this.ClientBox);
            this.infoBox.Controls.Add(this.IDBox);
            this.infoBox.Controls.Add(this.ClientName);
            this.infoBox.Controls.Add(this.ID);
            this.infoBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoBox.Location = new System.Drawing.Point(0, 0);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(981, 156);
            this.infoBox.TabIndex = 0;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "基本信息";
            // 
            // ClientBox
            // 
            this.ClientBox.Location = new System.Drawing.Point(293, 84);
            this.ClientBox.Name = "ClientBox";
            this.ClientBox.Size = new System.Drawing.Size(218, 28);
            this.ClientBox.TabIndex = 3;
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(293, 43);
            this.IDBox.Name = "IDBox";
            this.IDBox.ReadOnly = true;
            this.IDBox.Size = new System.Drawing.Size(218, 28);
            this.IDBox.TabIndex = 2;
            // 
            // ClientName
            // 
            this.ClientName.AutoSize = true;
            this.ClientName.Location = new System.Drawing.Point(215, 84);
            this.ClientName.Name = "ClientName";
            this.ClientName.Size = new System.Drawing.Size(44, 18);
            this.ClientName.TabIndex = 1;
            this.ClientName.Text = "客户";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(212, 43);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(62, 18);
            this.ID.TabIndex = 0;
            this.ID.Text = "订单号";
            // 
            // detailsBox
            // 
            this.detailsBox.Controls.Add(this.detailsGridView);
            this.detailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsBox.Location = new System.Drawing.Point(0, 156);
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.Size = new System.Drawing.Size(981, 332);
            this.detailsBox.TabIndex = 1;
            this.detailsBox.TabStop = false;
            this.detailsBox.Text = "订单明细";
            // 
            // detailsGridView
            // 
            this.detailsGridView.AutoGenerateColumns = false;
            this.detailsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GoodsName,
            this.GoodPrice,
            this.Number});
            this.detailsGridView.DataSource = this.itemSource;
            this.detailsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsGridView.Location = new System.Drawing.Point(3, 24);
            this.detailsGridView.Name = "detailsGridView";
            this.detailsGridView.RowHeadersWidth = 62;
            this.detailsGridView.RowTemplate.Height = 30;
            this.detailsGridView.Size = new System.Drawing.Size(975, 305);
            this.detailsGridView.TabIndex = 0;
            // 
            // GoodsName
            // 
            this.GoodsName.DataPropertyName = "GoodsName";
            this.GoodsName.HeaderText = "GoodsName";
            this.GoodsName.MinimumWidth = 8;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.Width = 150;
            // 
            // GoodPrice
            // 
            this.GoodPrice.DataPropertyName = "GoodsPrice";
            this.GoodPrice.HeaderText = "GoodsPrice";
            this.GoodPrice.MinimumWidth = 8;
            this.GoodPrice.Name = "GoodPrice";
            this.GoodPrice.Width = 150;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "Number";
            this.Number.MinimumWidth = 8;
            this.Number.Name = "Number";
            this.Number.Width = 150;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.Controls.Add(this.addButton);
            this.flowLayoutPanel1.Controls.Add(this.changeButton);
            this.flowLayoutPanel1.Controls.Add(this.removeButton);
            this.flowLayoutPanel1.Controls.Add(this.submitButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 425);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(981, 63);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(93, 35);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "添加明细";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(102, 3);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(97, 35);
            this.changeButton.TabIndex = 1;
            this.changeButton.Text = "修改明细";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(205, 3);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(92, 35);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "删除明细";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.submitButton.Location = new System.Drawing.Point(303, 3);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(95, 35);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "保存订单";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // orderSource
            // 
            this.orderSource.DataSource = typeof(OrderSpace.Order);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(981, 488);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.detailsBox);
            this.Controls.Add(this.infoBox);
            this.Name = "Form2";
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.detailsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderSource)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.GroupBox infoBox;
        private System.Windows.Forms.GroupBox detailsBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox ClientBox;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.Label ClientName;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.DataGridView detailsGridView;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        public System.Windows.Forms.BindingSource itemSource;
        public System.Windows.Forms.BindingSource orderSource;
    }
}