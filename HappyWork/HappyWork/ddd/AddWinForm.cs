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
using System.Xml;

namespace HappyWork
{
    public partial class AddWinForm : Form
    {
        public AddWinForm()
        {
            InitializeComponent();
        }

#region 新增供应商信息（已完成）
        private void NewBtn_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show(this, "是否可以确定没有错误", "不要笑，这是很严肃的事情", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //检测是否已经存在这个供应商的信息了
                var name = this.SupplierNameTBox.Text;
                DirectoryInfo info = new DirectoryInfo(@".\Resources\xml\information");
                if (!info.Exists)
                {
                    info.Create();
                }
                var names = from file in info.GetFiles()
                            select System.IO.Path.GetFileNameWithoutExtension(file.Name);
                if (names.Contains(name))
                {
                    MessageBox.Show(this, "这个供应商的名字已经存在了，主人", "出错了出错了");
                }

                //如果没有这个供应商存在
                else
                {
                    XmlDocument xml = new XmlDocument();
                    var root = xml.CreateElement("供应商信息");
                    addElementToRoot(xml, root, "供方名称", this.SupplierNameTBox.Text);
                    addElementToRoot(xml, root, "销售人", this.SellerNameTBox.Text);
                    addElementToRoot(xml, root, "销售电话", this.SellerPhoneTBox.Text);
                    addElementToRoot(xml, root, "品牌名称", this.BrandTBox.Text);
                    addElementToRoot(xml, root, "账户名称", this.AccountNameTBox.Text);
                    addElementToRoot(xml, root, "开户银行", this.BankTBox.Text);
                    addElementToRoot(xml, root, "账号", this.AccountNumTBox.Text);
                    addElementToRoot(xml, root, "交货时间", this.HandOffTimeTBox.Text);
                    xml.AppendChild(root);
                    DirectoryInfo directory = new DirectoryInfo(@".\Resources\xml\information");
                    if (!directory.Exists)
                    {
                        directory.Create();
                    }
                    xml.Save(directory.FullName + @"\" + this.SupplierNameTBox.Text + ".xml");
                    comboBox1.Items.Add(this.SupplierNameTBox.Text);
                }
            }

        }
#endregion

        //加入根节点
        private void addElementToRoot(XmlDocument xml,XmlNode node,string name, string value)
        {
            var tempNode = xml.CreateElement(name);
            tempNode.InnerText = value;
            node.AppendChild(tempNode);
        }


        private void AddWinForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(@".\Resources\xml\information"))
            {
                return;
            }
            DirectoryInfo info = new DirectoryInfo(@".\Resources\xml\information");
            var names = from file in info.GetFiles()
                        select System.IO.Path.GetFileNameWithoutExtension(file.Name);
            foreach(var name in names)
            {
                comboBox1.Items.Add(name);
            }
        }

        #region 改变Combox的情况(已完成)
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fileName = this.comboBox1.Text + ".xml";
            FileInfo file = new FileInfo(@".\Resources\xml\information\" + fileName);
            if (!file.Exists)
            {
                return;
            }
            XmlDocument xml = new XmlDocument();
            xml.Load(file.FullName);
            var root = xml.DocumentElement;
            assignValueToControls(root);


        }
#endregion
        private void assignValueToControls(XmlElement root)
        {
            this.SupplierNameTBox.Text = root.GetElementsByTagName("供方名称")[0].InnerText;
            this.SellerNameTBox.Text = root.GetElementsByTagName("销售人")[0].InnerText;
            this.SellerPhoneTBox.Text = root.GetElementsByTagName("销售电话")[0].InnerText;
            this.BrandTBox.Text = root.GetElementsByTagName("品牌名称")[0].InnerText;
            this.AccountNameTBox.Text = root.GetElementsByTagName("账户名称")[0].InnerText;
            this.BankTBox.Text = root.GetElementsByTagName("开户银行")[0].InnerText;
            this.AccountNumTBox.Text = root.GetElementsByTagName("账号")[0].InnerText;
            this.HandOffTimeTBox.Text = root.GetElementsByTagName("交货时间")[0].InnerText;
        }

        #region 更新原有文件(已完成)
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            //删除原有文件
            var fileName = this.SupplierNameTBox.Text + ".xml";
            FileInfo file = new FileInfo(@".\Resources\xml\information\" + fileName);
            if (!file.Exists)
            {
                MessageBox.Show(this, "文件不存在，无法更新", "出错了出错了");
                return;
            }
            else
            {
                file.Delete();
                XmlDocument xml = new XmlDocument();
                var root = xml.CreateElement("供应商信息");
                addElementToRoot(xml, root, "供方名称", this.SupplierNameTBox.Text);
                addElementToRoot(xml, root, "销售人", this.SellerNameTBox.Text);
                addElementToRoot(xml, root, "销售电话", this.SellerPhoneTBox.Text);
                addElementToRoot(xml, root, "品牌名称", this.BrandTBox.Text);
                addElementToRoot(xml, root, "账户名称", this.AccountNameTBox.Text);
                addElementToRoot(xml, root, "开户银行", this.BankTBox.Text);
                addElementToRoot(xml, root, "账号", this.AccountNumTBox.Text);
                addElementToRoot(xml, root, "交货时间", this.HandOffTimeTBox.Text);
                xml.AppendChild(root);
                DirectoryInfo directory = new DirectoryInfo(@".\Resources\xml\information");
                if (!directory.Exists)
                {
                    directory.Create();
                }
                xml.Save(directory.FullName + @"\" + this.SupplierNameTBox.Text + ".xml");
            }
        }
        #endregion

#region 删除功能(已完成）
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var name = this.SupplierNameTBox.Text;
            var fileName = this.SupplierNameTBox.Text + ".xml";
            FileInfo file = new FileInfo(@".\Resources\xml\information\" + fileName);
            if (!file.Exists)
            {
                MessageBox.Show(this, "请检查一下供方名称对应的项目是否存在", "找不到对应供方信息");
                return;
            }
            else
            {
                file.Delete();
                this.comboBox1.Items.Remove(name);
                this.SupplierNameTBox.Text = "";
                this.SellerNameTBox.Text = "";
                this.SellerPhoneTBox.Text = "";
                this.BrandTBox.Text = "";
                this.AccountNameTBox.Text = "";
                this.BankTBox.Text = "";
                this.AccountNumTBox.Text = "";
                this.HandOffTimeTBox.Text = "";

            }


        }

        #endregion

    }

}
