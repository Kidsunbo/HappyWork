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
        private void ComplementMain()
        {
            addProjectInfo();
            this.showValueToDataView(addData_Complement);
            addEvent_Complement();

            //将未更改过的部分变成粉红色
            foreach (DataGridViewRow row in mainDataView.Rows)
            {
                if (row.Cells[1] is DataGridViewTextBoxCell)
                    row.Cells[1].Style.BackColor = Color.LightPink;
            }
        }

        private void addEvent_Complement()
        {
            mainDataView.CellValueChanged += new DataGridViewCellEventHandler(addEventToDateTime_Complement);
            mainDataView.CellValueChanged += new DataGridViewCellEventHandler(addEventToMoney_Complement);
            mainDataView.CellValueChanged += new DataGridViewCellEventHandler(addEventToProjectInfo);
            mainDataView.CellValueChanged += new DataGridViewCellEventHandler(addEventToColor);

        }

        private void addEventToMoney_Complement(object sender, DataGridViewCellEventArgs e)
        {
            var name = mainDataView.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (name == "补采购小写金额")
            {
                if (dataGVC_dictionary["补采购小写金额"].Value == null || dataGVC_dictionary["补采购小写金额"].Value.ToString()=="")
                {
                    dataGVC_dictionary["补采购大写金额"].Value = "";
                    return;
                }
                dataGVC_dictionary["补采购小写金额"].Value = string.Format("{0:N2}", Convert.ToDecimal(Convert.ToString(dataGVC_dictionary["补采购小写金额"].Value)));
                dataGVC_dictionary["补采购大写金额"].Value = numToChinese(decimal.Parse(Convert.ToString(dataGVC_dictionary["补采购小写金额"].Value)));

            }
            if (name == "补销售小写金额")
            {
                if (dataGVC_dictionary["补销售小写金额"].Value == null || dataGVC_dictionary["补销售小写金额"].Value.ToString() == "")
                {
                    dataGVC_dictionary["补销售大写金额"].Value = "";
                    return;
                }
                dataGVC_dictionary["补销售小写金额"].Value = string.Format("{0:N2}", Convert.ToDecimal(Convert.ToString(dataGVC_dictionary["补销售小写金额"].Value)));
                dataGVC_dictionary["补销售大写金额"].Value = numToChinese(decimal.Parse(Convert.ToString(dataGVC_dictionary["补销售小写金额"].Value)));
            }
        }

        private void addEventToDateTime_Complement(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var rowIndex = e.RowIndex;
                var columnIndex = e.ColumnIndex;
                //检查是否为空
                if (Convert.ToString(mainDataView.Rows[rowIndex].Cells[columnIndex].Value) == "")
                    return;

                var s = new string[] { "补年", "补月", "补日" };
                var name = mainDataView.Rows[rowIndex].Cells[0].Value.ToString();
                if (s.Contains(name))
                {
                    dataGVC_dictionary[name] = mainDataView.Rows[rowIndex].Cells[columnIndex];
                           
                    foreach (var str in s)
                    {
                        if (dataGVC_dictionary[str].Value == null)
                        {
                            return;
                        }
                    }
                    DateTime time = new DateTime(int.Parse(dataGVC_dictionary["补年"].Value.ToString()),
                                        int.Parse(dataGVC_dictionary["补月"].Value.ToString()),
                                        int.Parse(dataGVC_dictionary["补日"].Value.ToString()));
                    var temp = addTime(time);
                    dataGVC_dictionary["补销售年"].Value = temp.Year.ToString();
                    dataGVC_dictionary["补销售月"].Value = temp.Month.ToString();
                    dataGVC_dictionary["补销售日"].Value = temp.Day.ToString();
                }
            }

            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show(this, "时间出错了，请检查。否则会导致生成文件出错", "错误");
            }
        }

        private void addEventToProjectInfo(object sender, DataGridViewCellEventArgs e)
        {
            if (mainDataView.Rows[e.RowIndex].Cells[0].Value.ToString() == "已完成合同")
            {
                var name = mainDataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + ".xml";
                FileInfo file = new FileInfo(@".\Resources\xml\project\" + name);
                if (!file.Exists)
                {
                    return;
                }
                XmlDocument xml = new XmlDocument();
                xml.Load(file.FullName);
                var root = xml.DocumentElement;
                foreach(XmlNode element in root)
                {
                    project_dic.Add(element.Name, element.InnerText);
                }
                foreach(var item in dataGVC_dictionary)
                {
                    if (project_dic.ContainsKey(item.Key))
                    {
                        item.Value.Value = project_dic[item.Key];
                    }
                }


            }
        }

        private void addProjectInfo()
        {
            var row = new DataGridViewRow();
            row.Cells.Add(new DataGridViewTextBoxCell()
            {
                Value = "已完成合同"
            });
            DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
            DirectoryInfo info = new DirectoryInfo(@".\Resources\xml\project");
            if (!info.Exists)
            {
                info.Create();
            }

            var files = info.GetFiles();
            foreach (var file in files)
            {
                comboBoxCell.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
            row.Cells.Add(comboBoxCell);
            mainDataView.Rows.Add(row);

        }


        //str是Name
        private void addData_Complement(string str)
        {
            DataInfo dataInfo = new DataInfo();
            dataInfo.Name = str;
            var str_without_brace = str.Trim('{', '}');
            var str_split_pieces = str_without_brace.Split(':', '：');

            //普通变量名，即{项目名称}这样的
            if (str_split_pieces.Length == 1)
            {
                dataInfo.Pure_name = str_without_brace;

                add_Normal_Variable_Complement(str_without_brace);

            }

            //特殊变量名，即{b:是否续签:续:}这样的
            else if (str_split_pieces[0] == "b")
            {
                dataInfo.Pure_name = str_split_pieces[1];

                add_CheckBox_Variable(str_split_pieces[1]);//复用合同部分的代码

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

        private void add_Normal_Variable_Complement(string str_without_brace)
        {
            #region 处理补年月日，补销售年月日
            if ((new string[] { "补年", "补月", "补日", "补销售年", "补销售月", "补销售日" }).Contains(str_without_brace))
            {
                var temp = new DataGridViewTextBoxCell();
                #region 可以更改为节假日判断
                var afterDay = addTime(DateTime.Now);
                #endregion
                switch (str_without_brace)
                {
                    case "补年":
                        temp.Value = DateTime.Now.Year.ToString();
                        break;
                    case "补月":
                        temp.Value = DateTime.Now.Month.ToString();
                        break;
                    case "补日":
                        temp.Value = DateTime.Now.Day.ToString();
                        break;
                    case "补销售年":
                        temp.Value = afterDay.Year.ToString();
                        break;
                    case "补销售月":
                        temp.Value = afterDay.Month.ToString();
                        break;
                    case "补销售日":
                        temp.Value = afterDay.Day.ToString();
                        break;
                }
                dataGVC_dictionary[str_without_brace] = temp;
            }

            #endregion
#region 其他情况
            else
            {
                var temp = new DataGridViewTextBoxCell();
                dataGVC_dictionary[str_without_brace] = temp;
            }
#endregion

        }
    }
}
