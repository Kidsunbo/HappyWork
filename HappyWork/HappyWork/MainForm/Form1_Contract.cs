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
    partial class Form1
    {

        private void ContractMain()
        {
            this.showValueToDataView(addData_Contract);
            AddEventHandler(dataGVC_dictionary);

            //改变未更改的部分为粉红色
            foreach(DataGridViewRow row in mainDataView.Rows)
            {
                if(row.Cells[1] is DataGridViewTextBoxCell)
                    row.Cells[1].Style.BackColor = Color.LightPink;
            }
        }

        #region 加入变量（完成）
        //str是Name
        private void addData_Contract(string str)
        {
            DataInfo dataInfo = new DataInfo();
            dataInfo.Name = str;
            var str_without_brace = str.Trim('{', '}');
            var str_split_pieces = str_without_brace.Split(':','：');
            
            //普通变量名，即{项目名称}这样的
            if(str_split_pieces.Length == 1)
            {
                dataInfo.Pure_name = str_without_brace;

                add_Normal_Variable(str_without_brace);

            }
            //特殊变量名，即{b:是否续签:续:}这样的
            else if(str_split_pieces[0]=="b")
            {
                dataInfo.Pure_name = str_split_pieces[1];

                add_CheckBox_Variable(str_split_pieces[1]);

            }

            dic.Add(dataInfo.Pure_name, dataInfo);

            //将dataGVC_dictionary的内容加入到DataGridView里
            if (dataGVC_dictionary.Keys.Contains(dataInfo.Pure_name))//这个判断貌似没什么用
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell()
                {
                    Value = dataInfo.Pure_name
                });
                row.Cells.Add(dataGVC_dictionary[dataInfo.Pure_name]);
                mainDataView.Rows.Add(row);
            }

        }
        #endregion
        private void AddEventHandler(Dictionary<string, DataGridViewCell> dataGVC_dictionary)
        {
            mainDataView.CellValueChanged += new DataGridViewCellEventHandler(addEventToSupplierName);
            mainDataView.CellValueChanged += new DataGridViewCellEventHandler(addEventToDateTime);
            mainDataView.CellValueChanged += new DataGridViewCellEventHandler(addEventToMoney);
            mainDataView.CellValueChanged += new DataGridViewCellEventHandler(addEventToColor);

        }

        private void addEventToColor(object sender, DataGridViewCellEventArgs e)
        {
            if(mainDataView.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                mainDataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            }
        }

        #region 金钱事件（已完成）
        private void addEventToMoney(object sender, DataGridViewCellEventArgs e)
        {
            var name = mainDataView.Rows[e.RowIndex].Cells[0].Value.ToString();
            if(name == "采购小写金额")
            {
                if (dataGVC_dictionary["采购小写金额"].Value == null)
                {
                    dataGVC_dictionary["采购大写金额"].Value = "";
                    return;
                }
                var pVal = Convert.ToDecimal(Convert.ToString(dataGVC_dictionary["采购小写金额"].Value));
                //处理违约金
                if (pVal >= 0)
                {
                    if (pVal <= 1000000) dataGVC_dictionary["违约金"].Value = "2,000.00";
                    else if (pVal > 1000000 && pVal <= 5000000) dataGVC_dictionary["违约金"].Value = "5,000.00";
                    else dataGVC_dictionary["违约金"].Value = "20,000.00";
                }
                dataGVC_dictionary["采购小写金额"].Value = string.Format("{0:N2}", Convert.ToDecimal(Convert.ToString(dataGVC_dictionary["采购小写金额"].Value)));
                dataGVC_dictionary["采购大写金额"].Value = numToChinese(decimal.Parse(Convert.ToString(dataGVC_dictionary["采购小写金额"].Value)));

            }
            if (name == "销售小写金额")
            {
                if (dataGVC_dictionary["销售小写金额"].Value == null)
                {
                    dataGVC_dictionary["销售大写金额"].Value = "";
                    return;
                }
                dataGVC_dictionary["销售小写金额"].Value = string.Format("{0:N2}", Convert.ToDecimal(Convert.ToString(dataGVC_dictionary["销售小写金额"].Value)));
                dataGVC_dictionary["销售大写金额"].Value = numToChinese(decimal.Parse(Convert.ToString(dataGVC_dictionary["销售小写金额"].Value)));
            }
        }
        #endregion

        #region 时间事件（已完成）
        private void addEventToDateTime(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                var rowIndex = e.RowIndex;
                var columnIndex = e.ColumnIndex;
                //检查是否为空
                if (Convert.ToString(mainDataView.Rows[rowIndex].Cells[columnIndex].Value) == "")
                    return;

                var s = new string[] { "年", "月", "日" };
                var name = mainDataView.Rows[rowIndex].Cells[0].Value.ToString();
                if (s.Contains(name))
                {
                    //这个switch语句并没有什么卵用
                    switch (name)
                    {
                        case "年":
                            dataGVC_dictionary["年"] = mainDataView.Rows[rowIndex].Cells[columnIndex];
                            break;
                        case "月":
                            dataGVC_dictionary["月"] = mainDataView.Rows[rowIndex].Cells[columnIndex];
                            break;
                        case "日":
                            dataGVC_dictionary["日"] = mainDataView.Rows[rowIndex].Cells[columnIndex];
                            break;
                    }
                    foreach (var str in s)
                    {
                        if (dataGVC_dictionary[str].Value == null)
                        {
                            return;
                        }
                    }
                    DateTime time = new DateTime(int.Parse(dataGVC_dictionary["年"].Value.ToString()),
                                        int.Parse(dataGVC_dictionary["月"].Value.ToString()),
                                        int.Parse(dataGVC_dictionary["日"].Value.ToString()));
                    var temp =addTime(time);
                    dataGVC_dictionary["销售年"].Value = temp.ToString("yyyy");
                    dataGVC_dictionary["销售月"].Value = temp.ToString("MM");
                    dataGVC_dictionary["销售日"].Value = temp.ToString("dd");
                }
            }

            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show(this, "时间出错了，请检查。否则会导致生成文件出错", "错误");
            }

        }
#endregion
        private void addEventToSupplierName(object sender, DataGridViewCellEventArgs e)
        {
            if(mainDataView.Rows[e.RowIndex].Cells[0].Value.ToString() == "供方名称")
            {
                XmlDocument xml = new XmlDocument();
                var name = mainDataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + ".xml";
                FileInfo file = new FileInfo(@".\Resources\xml\information\" + name);
                if (!file.Exists)
                {
                    return;
                }
                xml.Load(file.FullName);
                var root = xml.DocumentElement;
                if(dataGVC_dictionary.Keys.Contains("销售人")&& root.GetElementsByTagName("销售人")[0].InnerText!="")
                    dataGVC_dictionary["销售人"].Value = root.GetElementsByTagName("销售人")[0].InnerText;
                if (dataGVC_dictionary.Keys.Contains("销售电话")&& root.GetElementsByTagName("销售电话")[0].InnerText!="")
                    dataGVC_dictionary["销售电话"].Value = root.GetElementsByTagName("销售电话")[0].InnerText;
                if (dataGVC_dictionary.Keys.Contains("品牌名称")&& root.GetElementsByTagName("品牌名称")[0].InnerText!="")
                    dataGVC_dictionary["品牌名称"].Value = root.GetElementsByTagName("品牌名称")[0].InnerText;
                if (dataGVC_dictionary.Keys.Contains("账户名称")&& root.GetElementsByTagName("账户名称")[0].InnerText!="")
                    dataGVC_dictionary["账户名称"].Value = root.GetElementsByTagName("账户名称")[0].InnerText;
                if (dataGVC_dictionary.Keys.Contains("开户银行")&& root.GetElementsByTagName("开户银行")[0].InnerText!="")
                    dataGVC_dictionary["开户银行"].Value = root.GetElementsByTagName("开户银行")[0].InnerText;
                if (dataGVC_dictionary.Keys.Contains("账号")&& root.GetElementsByTagName("账号")[0].InnerText!="")
                    dataGVC_dictionary["账号"].Value = root.GetElementsByTagName("账号")[0].InnerText;
                if (dataGVC_dictionary.Keys.Contains("交货时间")&& root.GetElementsByTagName("交货时间")[0].InnerText!="")
                    dataGVC_dictionary["交货时间"].Value = root.GetElementsByTagName("交货时间")[0].InnerText;
                this.Select(true, false);
                this.Select(true, true);

            }
        }

        #region 非CheckBox的情况(完成）
        //加入普通变量的行，即加入Text，或者对于特殊的普通变量加入ComboBox
        private void add_Normal_Variable(string str_without_brace)
        {
            #region 处理“供方名称”
            if(str_without_brace == "供方名称")
            {
                var tempGridCell = new DataGridViewComboBoxCell();
                
                if (!Directory.Exists(@".\Resources\xml\information"))
                {
                    dataGVC_dictionary["供方名称"] = tempGridCell;
                    return;
                }
                DirectoryInfo info = new DirectoryInfo(@".\Resources\xml\information");
                var files = info.GetFiles();

                foreach (var file in files)
                    tempGridCell.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file.Name));
                dataGVC_dictionary["供方名称"] = tempGridCell;
            }
            #endregion
            #region   处理年月日
            else if ((new string[]{ "年", "月", "日", "销售年", "销售月", "销售日" }).Contains(str_without_brace))
            {
                var temp = new DataGridViewTextBoxCell();

                var afterDay = addTime(DateTime.Now);

                switch (str_without_brace)
                {
                    case "年":
                        temp.Value = DateTime.Now.ToString("yyyy");
                        break;
                    case "月":
                        temp.Value = DateTime.Now.ToString("MM");
                        break;
                    case "日":
                        temp.Value = DateTime.Now.ToString("dd");
                        break;
                    case "销售年":
                        temp.Value = afterDay.Year.ToString();
                        break;
                    case "销售月":
                        temp.Value = afterDay.ToString("MM");
                        break;
                    case "销售日":
                        temp.Value = afterDay.ToString("dd");
                        break;
                }
                dataGVC_dictionary[str_without_brace] = temp;

            }
            #endregion
            #region 处理普通情况
            else
            {
                var temp = new DataGridViewTextBoxCell();
                dataGVC_dictionary[str_without_brace] = temp;
            }

            #endregion

        }
        #endregion

        #region 有CheckBox的情况(已完成)
        //加入CheckBox的行，即加入CheckBox
        private void add_CheckBox_Variable(string v)
        {
            var temp = new DataGridViewCheckBoxCell
            {
                Value = false,
            };
            dataGVC_dictionary[v] = temp;
        }
        #endregion

        //记录项目的信息，留给制作补充协议的时候使用
        private void recordTheProjectInfo(Dictionary<string, string> d)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var i in d)
            {
                var key = i.Key.Trim('}', '{');
                if (key.StartsWith("b") && (key.Contains(':') || key.Contains('：')))
                {
                    key = key.Split(':', '：')[1];
                    if(dataGVC_dictionary[key] is DataGridViewCheckBoxCell)
                    {
                        bool isChecked = Convert.ToBoolean(dataGVC_dictionary[key].Value);
                        dic.Add(key, Convert.ToString(isChecked));
                    }
                }
                else
                    dic.Add(key, i.Value);
            }

            XmlDocument xml = new XmlDocument();
            var root = xml.CreateElement("项目信息");
            foreach (var i in dic)
            {
                AddWinForm.addElementToRoot(xml, root, i.Key, i.Value);
            }
            xml.AppendChild(root);
            DirectoryInfo directory = new DirectoryInfo(@".\Resources\xml\project");
            if (!directory.Exists)
            {
                directory.Create();
            }
            if (dic.Keys.Contains("项目名称"))
            {
                FileInfo info = new FileInfo(@".\Resources\xml\project\" + dic["项目名称"] + ".xml");
                if (info.Exists)
                {
                    info.Delete();
                }

                xml.Save(info.FullName);
            }
        }

    }
}
