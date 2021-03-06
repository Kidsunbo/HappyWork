﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novacode;
using System.IO;

namespace HappyWork
{
    static class DocxCreator
    {

        //替换字符串，需要提供替换字典、文件的名字。
        public static void Repalce(Dictionary<string,string> dict,string[] files,string outdir,bool trackChange = false)
        {

            foreach(var i in files)
            {
                using(DocX doc = DocX.Load(i))
                {
                    foreach(var pair in dict)
                    {
                        doc.ReplaceText(pair.Key, pair.Value, trackChange, System.Text.RegularExpressions.RegexOptions.Multiline);
                    }

                    FileInfo file = new FileInfo(i);
                    var name = file.Name;
                    foreach (var pair in dict)
                    {
                        name = name.Replace(pair.Key, pair.Value);
                    }

                    doc.SaveAs($"{outdir}/" + name);
                }
            }
        }



        //简单的找到被大括号引起来的字符串
        private static Dictionary<string, string> find(DocX doc)
        {
            Dictionary<string, string> dir = new Dictionary<string, string>();
            StringBuilder name = new StringBuilder();
            bool inStr = false;
            foreach (char i in doc.Text)
            {
                if (i == '{')
                {
                    inStr = true;
                    name.Append(i);
                }
                else if (i == '}')
                {
                    inStr = false;
                    name.Append(i);
                    var name_string = name.ToString(); ;
                    name.Clear();
                    if (!dir.ContainsKey(name_string))
                    {
                        dir[name_string] = "";
                    }
                }
                else if (inStr)
                {
                    name.Append(i);
                }
            }


            return dir;
        }

        public static Dictionary<string,string> findAll(string[] files)
        {
            var dictOnlyContainName = new Dictionary<string, string>();
            foreach(var file in files)
            {
                using(DocX doc = DocX.Load(file))
                {
                    var temp = dictOnlyContainName.Union(find(doc));
                    dictOnlyContainName = temp.ToDictionary(k => k.Key, v => v.Value);
                }
            }

            return dictOnlyContainName;
        }

    }
}
