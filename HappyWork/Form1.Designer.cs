namespace HappyWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.settingBox = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.ClosePanel = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.filePanel = new System.Windows.Forms.Panel();
            this.outputRoute = new System.Windows.Forms.RichTextBox();
            this.templateRoute = new System.Windows.Forms.RichTextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ValueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftPanel.SuspendLayout();
            this.ClosePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.filePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.settingBox);
            this.leftPanel.Controls.Add(this.button1);
            this.leftPanel.Controls.Add(this.ClosePanel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(149, 432);
            this.leftPanel.TabIndex = 0;
            // 
            // settingBox
            // 
            this.settingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingBox.Location = new System.Drawing.Point(0, 170);
            this.settingBox.Name = "settingBox";
            this.settingBox.Padding = new System.Windows.Forms.Padding(20);
            this.settingBox.Size = new System.Drawing.Size(149, 262);
            this.settingBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(0, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 96);
            this.button1.TabIndex = 1;
            this.button1.Text = "合同及补充协议";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClosePanel
            // 
            this.ClosePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClosePanel.Controls.Add(this.pictureBox3);
            this.ClosePanel.Controls.Add(this.pictureBox2);
            this.ClosePanel.Controls.Add(this.pictureBox1);
            this.ClosePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClosePanel.Location = new System.Drawing.Point(0, 0);
            this.ClosePanel.Name = "ClosePanel";
            this.ClosePanel.Size = new System.Drawing.Size(149, 74);
            this.ClosePanel.TabIndex = 0;
            this.ClosePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ClosePanel_Paint);
            this.ClosePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ClosePanel_MouseDown);
            this.ClosePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ClosePanel_Drag);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(113, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_Leave);
            this.pictureBox3.MouseHover += new System.EventHandler(this.pictureBox3_Hover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(63, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_Leave);
            this.pictureBox2.MouseHover += new System.EventHandler(this.pictureBox2_Hover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_Leave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_Hover);
            // 
            // filePanel
            // 
            this.filePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.filePanel.Controls.Add(this.outputRoute);
            this.filePanel.Controls.Add(this.templateRoute);
            this.filePanel.Controls.Add(this.pictureBox4);
            this.filePanel.Controls.Add(this.pictureBox5);
            this.filePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filePanel.Location = new System.Drawing.Point(149, 0);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(624, 74);
            this.filePanel.TabIndex = 2;
            // 
            // outputRoute
            // 
            this.outputRoute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputRoute.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.outputRoute.Location = new System.Drawing.Point(6, 39);
            this.outputRoute.Name = "outputRoute";
            this.outputRoute.Size = new System.Drawing.Size(564, 20);
            this.outputRoute.TabIndex = 6;
            this.outputRoute.Text = "请输入生成合同之后要放置的位置";
            // 
            // templateRoute
            // 
            this.templateRoute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.templateRoute.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.templateRoute.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.templateRoute.Location = new System.Drawing.Point(6, 12);
            this.templateRoute.Name = "templateRoute";
            this.templateRoute.Size = new System.Drawing.Size(564, 20);
            this.templateRoute.TabIndex = 0;
            this.templateRoute.Text = "请输入模板文件所在的文件夹位置";
            this.templateRoute.TextChanged += new System.EventHandler(this.templateRoute_TextChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(582, 39);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 29);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(582, 4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 29);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 3;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.dataGridView1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(149, 74);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(624, 358);
            this.mainPanel.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValueName,
            this.Value});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(624, 358);
            this.dataGridView1.TabIndex = 0;
            // 
            // ValueName
            // 
            this.ValueName.HeaderText = "名称";
            this.ValueName.MinimumWidth = 50;
            this.ValueName.Name = "ValueName";
            this.ValueName.ReadOnly = true;
            this.ValueName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "值";
            this.Value.MinimumWidth = 400;
            this.Value.Name = "Value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(773, 432);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.filePanel);
            this.Controls.Add(this.leftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.leftPanel.ResumeLayout(false);
            this.ClosePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.filePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel ClosePanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.FlowLayoutPanel settingBox;
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.RichTextBox outputRoute;
        private System.Windows.Forms.RichTextBox templateRoute;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}

