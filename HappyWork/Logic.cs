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
    public partial class Form1
    {
        class DataInfo
        {
            public enum ValueType
            {
                checkBox = 1,
                text
            };

            public string pure_name = "";
            public string repalce_name = "";
            public ValueType value_type = ValueType.text;
            public bool has_value = false;
            public string value = "";
        }

        private RadioButton contructRadioButton = null;
        private RadioButton complementRadioButton = null;
        private CheckBox submmitedCheckBox = null;
        private CheckBox trackChange = null;
        private string[] templateFiles = null;
        private string outputDir = null;
        Dictionary<string, DataInfo> dict = new Dictionary<string, DataInfo>();

        private void UpdateMainPanel()
        {
#region
            foreach(var i in DocxCreator.findAll(templateFiles))
            {
                var original_name = i.Key;
                //TO DO
            }
#endregion
        }

        private void createControl(string name, string value = "")
        {


            string pureName = name;
            DataGridViewRow row = new DataGridViewRow();
            if (name.Contains(':') || name.Contains('：'))
            {
                var nameAndAttr = name.Split(new char[] { ':', '：' }, 2);
                pureName = nameAndAttr[1];



                DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                pureName = pureName.Trim('{', '}');
                textboxcell.Value = pureName;
                row.Cells.Add(textboxcell);

                switch (nameAndAttr[0])
                {
                    case "b":
                        DataGridViewComboBoxCell comboxcell = new DataGridViewComboBoxCell();
                        comboxcell.Value = pureName;
                        comboxcell.Style.BackColor = Color.LightPink;
                        row.Cells.Add(comboxcell);
                        break;
                        //还可以加入更多的方法，等以后实现。
                }

            }
            else
            {

                DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                pureName = pureName.Trim('{', '}');
                textboxcell.Value = pureName;
                row.Cells.Add(textboxcell);
                DataGridViewTextBoxCell textBoxCell2 = new DataGridViewTextBoxCell();
                textBoxCell2.Style.BackColor = Color.LightPink;
                textBoxCell2.Value = value;
                row.Cells.Add(textBoxCell2);
            }
            dataGridView1.Rows.Add(row);
        }

        private void modify(string key, out string value)
        {
            var now = DateTime.Now;
            switch (key)
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
                default:
                    value = "";
                    break;
            }

            //throw new NotImplementedException();
        }


        //该函数用在UpdateMainPanel之前，检查模板文件是否给出，同时检查输出文件夹是否给出
        private bool checkInfo()
        {
            var ready = true;
            if (outputDir == null)
            {
                outputRoute.BackColor = Color.Red;
                ready = false;

            }
            if (templateFiles == null)
            {
                templateRoute.BackColor = Color.Red;
                ready = false;
            }
            return ready;


        }


        //该函数勇于检查是否可以开始进行替换，如果可以返回true，否则返回false，并将第一个遇到的未赋值的变量名给出
        private bool checkCanBegin(out string name)
        {
            
            foreach(var i in dict)
            {
                if (!i.Value.has_value)
                {
                    name = i.Key;
                    return false;
                }
            }

            name = "";
            return true;
        }

    }
}
