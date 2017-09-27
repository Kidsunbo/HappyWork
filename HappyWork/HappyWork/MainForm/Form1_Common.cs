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
using System.Text.RegularExpressions;

/*
 * 这个文件代表了所有于界面无关的逻辑函数，不包含变量。
 */


namespace HappyWork
{
    partial class Form1
    {

        
        //检查模板文件路径和输出文件的路径是否设置，如果没有设置，将输入框变成红色。
        private bool CheckFilesAndDirSetFinished()
        {
            //检查模板文件的路径
            if(templateFiles == null)
            {
                templateDirRichBox.ForeColor = Color.Black;//将字体颜色设置为黑色
                templateDirRichBox.BackColor = Color.Pink;
                return false;
            }
            if(outputDir == null)
            {
                outputDirRichTextBox.ForeColor = Color.Black;
                outputDirRichTextBox.BackColor = Color.Pink;
                return false;
            }

            return true;
            //Over
        }

        //第一次点击左侧按钮时进行数据创建
        private void showValueToDataView(Func func)
        {
            var dict = DocxCreator.findAll(templateFiles);
            foreach (var i in dict)
                func(str: i.Key.ToString());
            //Over
        }

        //人民币小写转大写
        private string numToChinese(decimal number)
        {
            var s = number.ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            var d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
            var r = Regex.Replace(d, ".", m => "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟万亿兆京垓秭穰"[m.Value[0] - '-'].ToString());
            return r;
        }


        //当添加供应商或者修改供应商信息后的事件
        private void updateAddSupplierInfo(object sender, FormClosedEventArgs e)
        {
            if (!Directory.Exists(@".\Resources\xml\information"))
            {
                return;
            }
            DirectoryInfo info = new DirectoryInfo(@".\Resources\xml\information");
            var files = info.GetFiles();
            var temp = dataGVC_dictionary["供方名称"] as DataGridViewComboBoxCell;
            if (temp == null) return;
            temp.Items.Clear();
            foreach (var file in files)
                temp.Items.Add(file.Name);
            
        }

        /*
        //添加每一个数据到View里
        void addToDataView(string str)
        {

            string[] modifiedStr = str.Trim('{', '}').Split(new char[] { ':', '：' }, 2);

            var dataInfo = new DataInfo(); //创建一个DataInfo对象，来保存该行类型的数据'

            //确定展现的类型是CheckBox还是文本
            switch (modifiedStr[0])
            {
                case "b":
                    dataInfo.Type = DataInfo.DataType.CHECK_BOX;
                    break;
                case "c":
                    dataInfo.Type = DataInfo.DataType.COMBOBOX;
                    break;
                default:
                    dataInfo.Type = DataInfo.DataType.TEXT;
                    break;
            }
            //新建一个对象代表这一行
            DataGridViewRow row = new DataGridViewRow();
            dataInfo.Name = str;
            //当str不带修饰信息的时候
            if (modifiedStr.Length == 1)
            {
                dataInfo.Pure_name = modifiedStr[0];
            }

            //当str带修饰信息的时候
            else if (modifiedStr.Length == 2)
            {
                dataInfo.Pure_name = modifiedStr[1];
            }
            DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
            textBoxCell.Value = dataInfo.Pure_name;
            row.Cells.Add(textBoxCell);

            if (checkSpecialItem(dataInfo.Pure_name))
            {
                //如果是特殊的元素的话，进行特殊处理
                handleSpecialItem(dataInfo.Pure_name, row);
            }
            else
            {
                switch (dataInfo.Type)
                {
                    case DataInfo.DataType.CHECK_BOX:
                        //定义值类型，即checkbox框
                        DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();
                        checkBoxCell.Value = false;
                        row.Cells.Add(checkBoxCell);
                        break;
                    case DataInfo.DataType.COMBOBOX:
                        //定义值类型，COMBOBOX
                        DataGridViewComboBoxCell comboBox = new DataGridViewComboBoxCell();
                        //ComboBox添加候选项功能尚未实现  ！！！！！！！！！！！！！！！！！！！！
                        row.Cells.Add(comboBox);
                        break;
                }
            }

            mainDataView.Rows.Add(row);
            

         }

        //处理特殊元素的赋值问题
        private void handleSpecialItem(string pure_name, DataGridViewRow row)
        {
            string value = "";
            var now = DateTime.Now;
            var afterNow = now.AddDays(3);//注意这个三天后续可以通过设置来进行更改
            switch (pure_name)
            {
                case "年":
                    value = now.Year.ToString();
                    break;
                case "月":
                    value = now.Month.ToString();
                    break;
                case "日":
                    value = now.Day.ToString();
                    break;
                case "销售年":
                    value = afterNow.Year.ToString();
                    break;
                case "销售月":
                    value = afterNow.Month.ToString();
                    break;
                case "销售日":
                    value = afterNow.Day.ToString();
                    break;

            }
            DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
            textBoxCell.Value = value;
            row.Cells.Add(textBoxCell);

            //Over
        }

        //检查是否是特殊元素，目前仅支持时间
        private bool checkSpecialItem(string pure_name)
        {
            var specialItems = new string[]
            {
                "年","月","日","销售年","销售月","销售日"
            };
            if (specialItems.Contains(pure_name))
            {
                return true;
            }
            else
            {
                return false;
            }
            //Over
        }
        */
    }


}
