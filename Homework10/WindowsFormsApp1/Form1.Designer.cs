
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
            this.startUrl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stateLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.startUrlBox = new System.Windows.Forms.TextBox();
            this.urlGridView = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.urlGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // startUrl
            // 
            this.startUrl.AutoSize = true;
            this.startUrl.Location = new System.Drawing.Point(3, 50);
            this.startUrl.Name = "startUrl";
            this.startUrl.Size = new System.Drawing.Size(71, 18);
            this.startUrl.TabIndex = 0;
            this.startUrl.Text = "初始URL";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.stateLabel);
            this.panel1.Controls.Add(this.startButton);
            this.panel1.Controls.Add(this.startUrlBox);
            this.panel1.Controls.Add(this.startUrl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 139);
            this.panel1.TabIndex = 1;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(12, 96);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(35, 18);
            this.stateLabel.TabIndex = 3;
            this.stateLabel.Text = "...";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(588, 37);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(98, 44);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "开始爬虫";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // startUrlBox
            // 
            this.startUrlBox.Location = new System.Drawing.Point(102, 47);
            this.startUrlBox.Name = "startUrlBox";
            this.startUrlBox.Size = new System.Drawing.Size(439, 28);
            this.startUrlBox.TabIndex = 1;
            // 
            // urlGridView
            // 
            this.urlGridView.AutoGenerateColumns = false;
            this.urlGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.urlGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.urlGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.URL,
            this.State});
            this.urlGridView.DataSource = this.resultBindingSource;
            this.urlGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlGridView.Location = new System.Drawing.Point(0, 139);
            this.urlGridView.Name = "urlGridView";
            this.urlGridView.RowHeadersWidth = 62;
            this.urlGridView.RowTemplate.Height = 30;
            this.urlGridView.Size = new System.Drawing.Size(800, 311);
            this.urlGridView.TabIndex = 2;
            // 
            // Num
            // 
            this.Num.DataPropertyName = "Num";
            this.Num.HeaderText = "Num";
            this.Num.MinimumWidth = 8;
            this.Num.Name = "Num";
            // 
            // URL
            // 
            this.URL.DataPropertyName = "Url";
            this.URL.HeaderText = "URL";
            this.URL.MinimumWidth = 8;
            this.URL.Name = "URL";
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "State";
            this.State.MinimumWidth = 8;
            this.State.Name = "State";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.urlGridView);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.urlGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label startUrl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox startUrlBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.DataGridView urlGridView;
        private System.Windows.Forms.BindingSource resultBindingSource;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
    }
}

