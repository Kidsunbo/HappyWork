using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace HappyWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //登入软件的时候进行一次记录
            DirectoryInfo fileInfo = new DirectoryInfo("./Log");
            if (!fileInfo.Exists)
                fileInfo.Create();
            using (StreamWriter file = new StreamWriter(@".\Log\Login.txt", true))
            {
                file.WriteLine($"{DateTime.Now.ToString()}用户{Environment.UserName}登入。");
            }
            //Over

        }


        private void templateFileBtn_Click(object sender, EventArgs e)
        {
            //定义选择模板文件的文件选择窗口
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = ".";
            fileDialog.Filter = "word files (*.doc)|*docx";
            fileDialog.RestoreDirectory = true;
            fileDialog.Multiselect = true;
            fileDialog.ShowDialog();
            //检查是否选择了文件
            var returnValueOfFiles = fileDialog.FileNames;
            if (returnValueOfFiles.Length == 0)
            {
                return;
            }
            //将模板文件的位置路径保存下来
            templateFiles = fileDialog.FileNames;
            //在展示框中展示文件路径
            StringBuilder tempString = new StringBuilder();
            foreach (string file in returnValueOfFiles)
            {
                tempString.AppendLine(file);
            }
            templateDirRichBox.Text = tempString.ToString();
            templateDirRichBox.ForeColor = Color.Black;
            templateDirRichBox.ReadOnly = true;
            templateDirRichBox.BackColor = Color.White;
            //Over
        }

        private void OutputDirBtn_Click(object sender, EventArgs e)
        {
            //展示一个窗口，选择对应的输出路径
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "选择一个文件夹，用来放生成的合同或者补充协议";
            folderBrowser.ShowDialog();

            //将选择的路径保存，并展示出来
            outputDir = folderBrowser.SelectedPath;
            outputDirRichTextBox.Text = folderBrowser.SelectedPath;
            outputDirRichTextBox.ReadOnly = true;
            outputDirRichTextBox.ForeColor = Color.Black;
            outputDirRichTextBox.BackColor = Color.White;
            //Over
        }

        private void checkDataBtn_Click(object sender, EventArgs e)
        {
            //Step1 检查模板文件路径和输出文件的路径是否设置，如果没有设置，将输入框变成红色。
            if (!CheckFilesAndDirSetFinished())
            {
                return; //如果没有配置，则直接返回，不再往下进行。
            }
            //Step2 将模板文件里所有的数据读取出来并展示到DataView里。
            if (!mainPanelHasValue)
            {
                if (this.ContractRadioBtn.Checked)
                {
                    ContractMain();
                }
                if (this.ComplementRadioBtn.Checked)
                {
                    ComplementMain();
                }
                mainPanelHasValue = true;
            }
            else //即mainPanel中已经有了数据的情况下
            {
                //检查一下是否都赋值了，由用户自己决定是否继续
                foreach (var i in dataGVC_dictionary)
                {
                    if (!unusedVar.Contains(i.Key.ToString()) && Convert.ToString(i.Value.Value) == "")
                    {
                        var result = MessageBox.Show(this, "\"" + i.Key.ToString() + "\"" + "貌似还没有赋值，是否不管它呢？", "检查到有的地方没有写过", MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                    }
                }

                this.StartTask_btn.Enabled = true;
            }

        }


        private void settingMenuStripBtn_Click(object sender, EventArgs e)
        {

        }

        private void AboutMenuStripBtn_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }


        private void AddSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWinForm addWin = new AddWinForm();
            addWin.FormClosed += new FormClosedEventHandler(updateAddSupplierInfo);
            addWin.Show();
        }

        private void StartTask_btn_Click(object sender, EventArgs e)
        {

            d.Clear();
            //制作一份Name：Value词典
            var finalDic_linq = from pair in dic
                                from pair2 in dataGVC_dictionary
                                where pair.Key == pair2.Key
                                select new { k = pair.Value.Name, v = pair2.Value };

            var finalDic = finalDic_linq.ToDictionary(k => k.k, v => v.v);

            foreach (var i in finalDic)
            {
                //处理CheckBox的情况
                if (i.Value is DataGridViewCheckBoxCell)
                {
                    bool isChecked = Convert.ToBoolean(i.Value.Value);
                    var spit_str = i.Key.Trim('{', '}').Split(':', '：');
                    if (isChecked)
                    {
                        if (spit_str.Length == 2) d.Add(i.Key, "");
                        else if (spit_str.Length >= 3) d.Add(i.Key, spit_str[2]);
                    }
                    else
                    {
                        if (spit_str.Length == 2 || spit_str.Length == 3) d.Add(i.Key, "");
                        else if (spit_str.Length >= 4) d.Add(i.Key, spit_str[3]);
                    }
                }


                //处理ComboBox的情况
                else if (i.Value is DataGridViewComboBoxCell)
                {

                    d.Add(i.Key, Convert.ToString(i.Value.Value));
                }
                //处理普通的情况
                else
                {

                    d.Add(i.Key, Convert.ToString(i.Value.Value));
                }
            }
            this.progressBar.Maximum = d.Count;
            this.progressBar.Step = 1;
            //制作完成
            var t = new Thread(() =>
            {
                DocxCreator.Repalce(d, templateFiles, outputDir, this.updateProgress, this.TrackChange_CheckBox.Checked);

            });
            t.Start();
            if (this.SubmitText_CheckBtn.Checked)
            {
                CreateSubmitText(d);
            }
            //记录项目信息
            if (ContractRadioBtn.Checked)
                recordTheProjectInfo(d);
            t.Join();
            if (MessageBox.Show(this, "是否打开生成文件所在文件夹", "是否打开", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
                psi.Arguments = "/e," + outputDir;
                System.Diagnostics.Process.Start(psi);

            }




        }

    }

}
