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


#region 
    //该区域用于定义一些变量。

        //用于保存数据，其中name为包含修饰符的名称，pure_name为展示给用户的名字
        class DataInfo
        {
            public enum DataType
            {
                CHECK_BOX = 1,
                TEXT,
                COMBOBOX,

            }
            public DataType Type = DataType.TEXT;
            public bool Has_value
            {
                get
                {
                    return has_value;
                }


            }
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    has_value = true;
                    name = value;
                }
            }

            public string Pure_name
            {
                get
                {
                    return pure_name;
                }
                set
                {
                    pure_name = value;
                }
            }

            public string Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                }
            }

            private string name ="";
            private string pure_name ="";
            private bool has_value = false ;
            private string _value = "";
             

        }



        //模板文件的名称列表，包含多个模板文件的全名及地址
        private string[] templateFiles = null;

        //输出合同或者补充协议的地址
        private string outputDir = null;

        //定义一个字典，用来保存所有的内容
        Dictionary<string, DataInfo> dic = new Dictionary<string, DataInfo>();

        #endregion

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
        private void showValueToDataView()
        {
            var dict = DocxCreator.findAll(templateFiles);
            foreach (var i in dict)
                addToDataView(str: i.Key.ToString());
            //Over
        }
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


            mainDataView.Rows.Add(row);
            //Over

         }

    }
}
