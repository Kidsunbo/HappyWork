using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (StreamWriter file = new StreamWriter(@".\Log\Login.txt",true))
            {
                file.WriteLine($"{DateTime.Now.ToString()}用户{Environment.UserName}登入。");
            }
            //Over

        }


        private void mainDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            if(returnValueOfFiles.Length == 0)
            {
                return;
            }
            //将模板文件的位置路径保存下来
            templateFiles = fileDialog.FileNames;
            //在展示框中展示文件路径
            StringBuilder tempString = new StringBuilder();
            foreach(string file in returnValueOfFiles)
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

        private bool mainPanelHasValue = false;
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
                showValueToDataView();
                mainPanelHasValue = true;
            }
            else //即mainPanel中已经有了数据的情况下
            {
                //TO DO...
            }

            //throw new NotImplementedException();
        }

        
    }
}
