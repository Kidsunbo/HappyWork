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

            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
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


            private string name = "";
            private string pure_name = "";
            private bool has_value = false;
            private string _value = "";


        }
    
        //表示中间的GridView是否已经有了值。如果没有的话，就往上面添加值。
        private bool mainPanelHasValue = false;

        //模板文件的名称列表，包含多个模板文件的全名及地址
        private string[] templateFiles = null;

        //输出合同或者补充协议的地址
        private string outputDir = null;


        //定义一个字典，用来保存所有的内容,Key值为Pure_name，方便查找
        Dictionary<string, DataInfo> dic = new Dictionary<string, DataInfo>();

        //定义一个字典，用来保存每一个名字对应的空间，Key为Pure_name,Value为DataGridViewCellBox.
        Dictionary<string, DataGridViewCell> dataGVC_dictionary = new Dictionary<string, DataGridViewCell>();

        //最终的字典，用来做替代。名字是Name，即模板中的样子，值是Pure_Name。
        Dictionary<string,string> d = new Dictionary<string, string>();

        //用来保存ProjectInfo的字典，Key是PureName，Value是对应的值，均为String
        Dictionary<string, string> project_dic = new Dictionary<string, string>();

        //定义一个委托，用来共用一个函数，接收不同的函数分别添加合同和补充协议的变量
        private delegate void Func(string str);


        //定义销售合同/补充协议和采购合同/补充协议之间的时间差
        int dayBetweenSellAndBuy = 3;
        #endregion

    }
}
