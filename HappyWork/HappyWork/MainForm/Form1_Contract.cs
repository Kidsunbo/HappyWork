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
    partial class Form1
    {

        private void ContractMain()
        {
            this.showValueToDataView(addData_Contract);
            AddEventHandler(dataGVC_dictionary);

        }

        #region 加入变量（完成）
        //str是Name
        private void addData_Contract(string str)
        {
            DataInfo dataInfo = new DataInfo();
            dataInfo.Name = str;
            var str_without_brace = str.Trim('{', '}');
            var str_split_pieces = str_without_brace.Split('：', ':');
            
            //普通变量名，即{项目名称}这样的
            if(str_split_pieces.Length == 1)
            {
                dataInfo.Pure_name = str_without_brace;

                add_Normal_Variable(str_without_brace);

            }
            //特殊变量名，即{b:是否续签:续:None}这样的
            else if(str_split_pieces.Length == 4)
            {
                dataInfo.Pure_name = str_split_pieces[1];

                add_CheckBox_Variable(str_split_pieces[1]);

            }

            dic.Add(dataInfo.Pure_name, dataInfo);

            if (dataGVC_dictionary.Keys.Contains(dataInfo.Pure_name))
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
            //mainDataView.CellValueChanged += new DataGridViewCellEventHandler(addEventToSupplierName);
            mainDataView.CellValueChanged += new DataGridViewCellEventHandler(addEventToDateTime);
            mainDataView.CellValueChanged += new DataGridViewCellEventHandler(addEventToMoney);

        }

        #region 金钱时间（已完成）
        private void addEventToMoney(object sender, DataGridViewCellEventArgs e)
        {
            var name = mainDataView.Rows[e.RowIndex].Cells[0].Value.ToString();
            if(name == "采购小写金额")
            {
                dataGVC_dictionary["采购大写金额"].Value = numToChinese(decimal.Parse(dataGVC_dictionary["采购小写金额"].Value.ToString()));
            }
            if (name == "销售小写金额")
            {
                dataGVC_dictionary["销售大写金额"].Value = numToChinese(decimal.Parse(dataGVC_dictionary["销售小写金额"].Value.ToString()));
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
                if (mainDataView.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "")
                    return;

                var s = new string[] { "年", "月", "日" };
                var name = mainDataView.Rows[rowIndex].Cells[0].Value.ToString();
                if (s.Contains(name))
                {
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
                    DateTime time = new DateTime(int.Parse(dataGVC_dictionary["年"].Value.ToString()),
                                        int.Parse(dataGVC_dictionary["月"].Value.ToString()),
                                        int.Parse(dataGVC_dictionary["日"].Value.ToString()));
                    var temp = time.AddDays(dayBetweenSellAndBuy);
                    dataGVC_dictionary["销售年"].Value = temp.Year.ToString();
                    dataGVC_dictionary["销售月"].Value = temp.Month.ToString();
                    dataGVC_dictionary["销售日"].Value = temp.Day.ToString();
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
            throw new NotImplementedException();
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
                    tempGridCell.Items.Add(file.Name);
                dataGVC_dictionary["供方名称"] = tempGridCell;
            }
            #endregion
            #region   处理年月日
            else if ((new string[]{ "年", "月", "日", "销售年", "销售月", "销售日" }).Contains(str_without_brace))
            {
                var temp = new DataGridViewTextBoxCell();
                switch (str_without_brace)
                {
                    case "年":
                        temp.Value = DateTime.Now.Year.ToString();
                        break;
                    case "月":
                        temp.Value = DateTime.Now.Month.ToString();
                        break;
                    case "日":
                        temp.Value = DateTime.Now.Day.ToString();
                        break;
                    case "销售年":
                        temp.Value = DateTime.Now.AddDays(this.dayBetweenSellAndBuy).Year.ToString();
                        break;
                    case "销售月":
                        temp.Value = DateTime.Now.AddDays(this.dayBetweenSellAndBuy).Month.ToString();
                        break;
                    case "销售日":
                        temp.Value = DateTime.Now.AddDays(this.dayBetweenSellAndBuy).Day.ToString();
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
    }
}
