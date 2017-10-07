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
using System.Xml;

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
            if (r.EndsWith("元") || r.EndsWith("角"))
            {
                r = r + "整";
            }
            return r;
        }


        //当添加供应商或者修改供应商信息后的事件
        private void updateAddSupplierInfo(object sender, FormClosedEventArgs e)
        {

            DirectoryInfo info = new DirectoryInfo(@".\Resources\xml\information");
            if (!info.Exists)
            {
                info.Create();
            }

            var files = info.GetFiles();
            //对“供方名称”做一个判断，如果不存在，则直接返回，不用添加。
            if (!dataGVC_dictionary.Keys.Contains("供方名称"))
            {
                return;
            }
            var temp = dataGVC_dictionary["供方名称"] as DataGridViewComboBoxCell;
            if (temp == null) return; 
            temp.Items.Clear();
            Console.WriteLine(temp.Items.Count);
            foreach (var file in files)
            {
                temp.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
            checkDataBtn.Select();

            Console.WriteLine(temp.Items.Count);
            
            
        }

        //生成呈文
        private void CreateSubmitText(Dictionary<string, string> d)
        {
            FileInfo templateFile = new FileInfo(@".\Resources\template\SubmitText\SubmitText.txt");
            if (!templateFile.Exists)
            {
                MessageBox.Show(this, "呈文模板不存在，请检查一下", "无法生成呈文", MessageBoxButtons.OK);
                return;
            }
            try
            {

                var content = File.ReadAllText(templateFile.FullName);
                foreach(var i in d)
                {
                    content.Replace(i.Key, i.Value);
                }
                File.WriteAllText(outputDir + @"\呈文.txt", content);
       
            }
            catch(IOException e)
            {
                MessageBox.Show(this, e.ToString(), "生成呈文出错了", MessageBoxButtons.OK);
            }

        }

        //刷新ProgressBar
        private void updateProgress()
        {
            if (this.progressBar.InvokeRequired)
            {
                this.progressBar.Invoke(new Action(updateProgress));
            }
            else
            {
                this.progressBar.PerformStep();
            }
        }

        //通过采购时间计算出补充协议时间
        private DateTime addTime(DateTime time)
        {
            var afterDay = time.AddDays(this.dayBetweenSellAndBuy);
            while (afterDay.DayOfWeek == DayOfWeek.Saturday || afterDay.DayOfWeek == DayOfWeek.Sunday)
            {
                afterDay = afterDay.AddDays(1);
            }
            return afterDay;
        }
       
    }


}
