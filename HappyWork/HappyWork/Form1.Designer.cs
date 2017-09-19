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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OutputDirBtn = new System.Windows.Forms.Button();
            this.outputDirRichTextBox = new System.Windows.Forms.RichTextBox();
            this.templateFileBtn = new System.Windows.Forms.Button();
            this.templateDirRichBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ContractRadioBtn = new System.Windows.Forms.RadioButton();
            this.ComplementRadioBtn = new System.Windows.Forms.RadioButton();
            this.TrackChange_CheckBox = new System.Windows.Forms.CheckBox();
            this.SubmitText_CheckBtn = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainDataView = new System.Windows.Forms.DataGridView();
            this.checkDataBtn = new System.Windows.Forms.Button();
            this.StartTask_btn = new System.Windows.Forms.Button();
            this.dataName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.92162F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.07837F));
            this.tableLayoutPanel1.Controls.Add(this.templateDirRichBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.templateFileBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.OutputDirBtn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.outputDirRichTextBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(689, 63);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // OutputDirBtn
            // 
            this.OutputDirBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputDirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputDirBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OutputDirBtn.Location = new System.Drawing.Point(594, 34);
            this.OutputDirBtn.Name = "OutputDirBtn";
            this.OutputDirBtn.Size = new System.Drawing.Size(92, 26);
            this.OutputDirBtn.TabIndex = 1;
            this.OutputDirBtn.Text = "浏览";
            this.OutputDirBtn.UseVisualStyleBackColor = true;
            this.OutputDirBtn.Click += new System.EventHandler(this.OutputDirBtn_Click);
            // 
            // outputDirRichTextBox
            // 
            this.outputDirRichTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.outputDirRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputDirRichTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.outputDirRichTextBox.Location = new System.Drawing.Point(3, 34);
            this.outputDirRichTextBox.Name = "outputDirRichTextBox";
            this.outputDirRichTextBox.ReadOnly = true;
            this.outputDirRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.outputDirRichTextBox.Size = new System.Drawing.Size(585, 26);
            this.outputDirRichTextBox.TabIndex = 4;
            this.outputDirRichTextBox.Text = "请选择输出文件夹的位置";
            // 
            // templateFileBtn
            // 
            this.templateFileBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.templateFileBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.templateFileBtn.Location = new System.Drawing.Point(594, 3);
            this.templateFileBtn.Name = "templateFileBtn";
            this.templateFileBtn.Size = new System.Drawing.Size(92, 25);
            this.templateFileBtn.TabIndex = 5;
            this.templateFileBtn.Text = "浏览";
            this.templateFileBtn.UseVisualStyleBackColor = true;
            this.templateFileBtn.Click += new System.EventHandler(this.templateFileBtn_Click);
            // 
            // templateDirRichBox
            // 
            this.templateDirRichBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.templateDirRichBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateDirRichBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.templateDirRichBox.Location = new System.Drawing.Point(3, 3);
            this.templateDirRichBox.Name = "templateDirRichBox";
            this.templateDirRichBox.ReadOnly = true;
            this.templateDirRichBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.templateDirRichBox.Size = new System.Drawing.Size(585, 25);
            this.templateDirRichBox.TabIndex = 6;
            this.templateDirRichBox.Text = "请选择模板文件";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.SubmitText_CheckBtn, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.ComplementRadioBtn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ContractRadioBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.TrackChange_CheckBox, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 63);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(689, 34);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // ContractRadioBtn
            // 
            this.ContractRadioBtn.AutoSize = true;
            this.ContractRadioBtn.Checked = true;
            this.ContractRadioBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContractRadioBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContractRadioBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ContractRadioBtn.Location = new System.Drawing.Point(4, 4);
            this.ContractRadioBtn.Name = "ContractRadioBtn";
            this.ContractRadioBtn.Size = new System.Drawing.Size(165, 26);
            this.ContractRadioBtn.TabIndex = 0;
            this.ContractRadioBtn.TabStop = true;
            this.ContractRadioBtn.Text = "合同";
            this.ContractRadioBtn.UseVisualStyleBackColor = true;
            // 
            // ComplementRadioBtn
            // 
            this.ComplementRadioBtn.AutoSize = true;
            this.ComplementRadioBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComplementRadioBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComplementRadioBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComplementRadioBtn.Location = new System.Drawing.Point(176, 4);
            this.ComplementRadioBtn.Name = "ComplementRadioBtn";
            this.ComplementRadioBtn.Size = new System.Drawing.Size(165, 26);
            this.ComplementRadioBtn.TabIndex = 1;
            this.ComplementRadioBtn.Text = "补充协议";
            this.ComplementRadioBtn.UseVisualStyleBackColor = true;
            // 
            // TrackChange_CheckBox
            // 
            this.TrackChange_CheckBox.AutoSize = true;
            this.TrackChange_CheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackChange_CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TrackChange_CheckBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TrackChange_CheckBox.Location = new System.Drawing.Point(348, 4);
            this.TrackChange_CheckBox.Name = "TrackChange_CheckBox";
            this.TrackChange_CheckBox.Size = new System.Drawing.Size(165, 26);
            this.TrackChange_CheckBox.TabIndex = 2;
            this.TrackChange_CheckBox.Text = "是否保留痕迹";
            this.TrackChange_CheckBox.UseVisualStyleBackColor = true;
            // 
            // SubmitText_CheckBtn
            // 
            this.SubmitText_CheckBtn.AutoSize = true;
            this.SubmitText_CheckBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubmitText_CheckBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitText_CheckBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SubmitText_CheckBtn.Location = new System.Drawing.Point(520, 4);
            this.SubmitText_CheckBtn.Name = "SubmitText_CheckBtn";
            this.SubmitText_CheckBtn.Size = new System.Drawing.Size(165, 26);
            this.SubmitText_CheckBtn.TabIndex = 3;
            this.SubmitText_CheckBtn.Text = "是否生成呈文";
            this.SubmitText_CheckBtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mainDataView);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 315);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.StartTask_btn);
            this.panel2.Controls.Add(this.checkDataBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 279);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(689, 36);
            this.panel2.TabIndex = 0;
            // 
            // mainDataView
            // 
            this.mainDataView.AllowUserToAddRows = false;
            this.mainDataView.AllowUserToDeleteRows = false;
            this.mainDataView.AllowUserToResizeColumns = false;
            this.mainDataView.AllowUserToResizeRows = false;
            this.mainDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataName,
            this.dataValue});
            this.mainDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDataView.GridColor = System.Drawing.SystemColors.Control;
            this.mainDataView.Location = new System.Drawing.Point(0, 0);
            this.mainDataView.Name = "mainDataView";
            this.mainDataView.RowTemplate.Height = 23;
            this.mainDataView.Size = new System.Drawing.Size(689, 279);
            this.mainDataView.TabIndex = 1;
            this.mainDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDataView_CellContentClick);
            // 
            // checkDataBtn
            // 
            this.checkDataBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkDataBtn.Location = new System.Drawing.Point(0, 0);
            this.checkDataBtn.Name = "checkDataBtn";
            this.checkDataBtn.Size = new System.Drawing.Size(75, 36);
            this.checkDataBtn.TabIndex = 0;
            this.checkDataBtn.Text = "检查数据";
            this.checkDataBtn.UseVisualStyleBackColor = true;
            this.checkDataBtn.Click += new System.EventHandler(this.checkDataBtn_Click);
            // 
            // StartTask_btn
            // 
            this.StartTask_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.StartTask_btn.Enabled = false;
            this.StartTask_btn.Location = new System.Drawing.Point(614, 0);
            this.StartTask_btn.Name = "StartTask_btn";
            this.StartTask_btn.Size = new System.Drawing.Size(75, 36);
            this.StartTask_btn.TabIndex = 1;
            this.StartTask_btn.Text = "开始生成";
            this.StartTask_btn.UseVisualStyleBackColor = true;
            // 
            // dataName
            // 
            this.dataName.HeaderText = "名称";
            this.dataName.Name = "dataName";
            this.dataName.ReadOnly = true;
            // 
            // dataValue
            // 
            this.dataValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataValue.HeaderText = "值";
            this.dataValue.Name = "dataValue";
            // 
            // splitter1
            // 
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(75, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(93, 36);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(520, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(94, 36);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(168, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(352, 36);
            this.progressBar.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "Form1";
            this.Text = "HappyWork";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button OutputDirBtn;
        private System.Windows.Forms.RichTextBox outputDirRichTextBox;
        private System.Windows.Forms.Button templateFileBtn;
        private System.Windows.Forms.RichTextBox templateDirRichBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton ComplementRadioBtn;
        private System.Windows.Forms.RadioButton ContractRadioBtn;
        private System.Windows.Forms.CheckBox SubmitText_CheckBtn;
        private System.Windows.Forms.CheckBox TrackChange_CheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView mainDataView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button StartTask_btn;
        private System.Windows.Forms.Button checkDataBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataValue;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
    }
}

