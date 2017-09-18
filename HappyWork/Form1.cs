using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            this.contructRadioButton = new RadioButton();
            this.contructRadioButton.Text = "合同";
            this.contructRadioButton.Dock = DockStyle.Top;
            this.contructRadioButton.FlatStyle = FlatStyle.Flat;




            this.complementRadioButton = new RadioButton();
            this.complementRadioButton.Text = "补充协议";
            this.complementRadioButton.Dock = DockStyle.Top;
            this.complementRadioButton.FlatStyle = FlatStyle.Flat;
            this.complementRadioButton.Checked = true;




            this.submmitedCheckBox = new CheckBox();
            this.submmitedCheckBox.Checked = true;
            this.submmitedCheckBox.Text = "是否生成呈文";
            this.submmitedCheckBox.Dock = DockStyle.Bottom;
            this.submmitedCheckBox.FlatStyle = FlatStyle.Flat;
            this.submmitedCheckBox.SetBounds(10, 30, 200, 50);

            this.trackChange = new CheckBox();
            this.trackChange.Checked = false;
            this.trackChange.Text = "是否保留痕迹";
            this.trackChange.Dock = DockStyle.Bottom;
            this.trackChange.FlatStyle = FlatStyle.Flat;
            this.trackChange.SetBounds(10, 30, 200, 50);



            settingBox.Controls.Add(contructRadioButton);
            settingBox.Controls.Add(complementRadioButton);
            settingBox.Controls.Add(submmitedCheckBox);
            settingBox.Controls.Add(trackChange);
            settingBox.BackColor = Color.Beige;

            

        }

        

        #region
        //PictureBox1
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private void pictureBox1_Hover(object sender, EventArgs e)
        {
            var img = new Bitmap(@"./Resource/134-cross-square.png");
            pictureBox1.Image.Dispose();
            pictureBox1.Image = img;
        }

        private void pictureBox1_Leave(object sender, EventArgs e)
        {
            var img = new Bitmap(@"./Resource/136-cross-circle.png");
            pictureBox1.Image.Dispose();
            pictureBox1.Image = img;
        }
        #endregion

        #region 
        // Close Panel
        private void ClosePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClosePanel_Drag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                this.Location = myPosittion;
            }
        }
        private Point mPoint = new Point();

        private void ClosePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }


        #endregion

#region
        private void pictureBox2_Hover(object sender, EventArgs e)
        {
            var img = new Bitmap(@"./Resource/59-plus-square.png");
            pictureBox2.Image.Dispose();
            pictureBox2.Image = img;
        }


        private void pictureBox2_Leave(object sender, EventArgs e)
        {
            var img = new Bitmap(@"./Resource/60-plus-circle.png");
            pictureBox2.Image.Dispose();
            pictureBox2.Image = img;
        }
        bool isMaximized = false;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!isMaximized)
            {
                isMaximized = true;
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            else
            {
                isMaximized = false;
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }

        }
        #endregion

        #region
        private void pictureBox3_Hover(object sender, EventArgs e)
        {
            var img = new Bitmap(@"./Resource/84-minus-square.png");
            pictureBox3.Image.Dispose();
            pictureBox3.Image = img;
        }


        private void pictureBox3_Leave(object sender, EventArgs e)
        {
            var img = new Bitmap(@"./Resource/85-minus-circle.png");
            pictureBox3.Image.Dispose();
            pictureBox3.Image = img;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }


        #endregion

        #region

        private bool can_begin = false;
        private void button1_Click(object sender, EventArgs e)
        {
            var ready = checkInfo();
            string no_value_name;
            if (ready)
            {
                UpdateMainPanel();
                button1.BackColor = Color.Thistle;
                button1.Text = "开始生成";


                #region
                //检查是否可以开始进行替换，如果可以则替换，否则将不可以的那一行显示出来。

                var can_begin = checkCanBegin(out no_value_name);
                if (can_begin)
                {
                    var newDict = (from dataItem in dict
                                   select new KeyValuePair<string, string>(dataItem.Value.repalce_name, dataItem.Value.value)).ToDictionary(k => k.Key, v => v.Value);
                    DocxCreator.Repalce(newDict, templateFiles, outputDir, trackChange.Checked);
                }
                else
                {
                    foreach (var i in dataGridView1.Rows)
                    {
                        var temp = i as DataGridViewRow;
                        if (temp != null)
                        {
                            if (temp.Cells[0].Value.ToString() == no_value_name)
                            {
                                temp.Cells[1].Style.BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
            

#endregion
        }





        #endregion



        private void settingBox_Enter(object sender, EventArgs e)
        {

        }

      

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = ".";
            openFile.Filter = "word files (*.doc)|*docx";
            openFile.RestoreDirectory = true;
            openFile.Multiselect = true;
            openFile.ShowDialog();
            templateFiles = openFile.FileNames;

            templateRoute.Text = string.Join(";",openFile.SafeFileNames);
            templateRoute.ReadOnly = true;
            templateRoute.ForeColor = Color.Black;
            templateRoute.BackColor = Color.White;

        }

        private void templateRoute_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            
            folderBrowser.Description = "选择一个文件夹，用来放生成的合同或者补充协议";
            folderBrowser.ShowDialog();
            outputDir = folderBrowser.SelectedPath;
            outputRoute.Text = folderBrowser.SelectedPath;
            outputRoute.ReadOnly = true;
            outputRoute.ForeColor = Color.Black;
            outputRoute.BackColor = Color.White;


        }




    }

    
}
