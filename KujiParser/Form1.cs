using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace KujiParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string file_name = "";
        //第一簽
        //簽詞
        //概述
        //詩曰
        //解曰
        //釋義
        private void btn_open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file_name = openFileDialog1.FileName;
            }
            else
            {
                file_name = "";
            }
            tb_file.Text = file_name;
        }
        private JArray list = new JArray();
        private void btn_process_Click(object sender, EventArgs e)
        {
            if (file_name.Length > 0)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                string line = "";
                int i = 0;
                list = new JArray();
                JArray interpretation = new JArray();
                JObject jo = new JObject();
                String nextKey = "";

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.IndexOf('[') >= 0)
                    {
                        tb_output.Text += "\r\n" + line.Substring(line.IndexOf('[')+1, line.IndexOf(']') - 1);


                        if (line.IndexOf("[第") >= 0)
                        {
                            list.Add(jo);
                            jo = new JObject();
                            jo["num"] = line.Substring(line.IndexOf('[') + 1, line.IndexOf(']') - 1);
                            nextKey = "title";
                        }
                        else if (line.IndexOf("[簽詞]") >= 0)
                        {
                            nextKey = "text";
                        }
                        else if (line.IndexOf("[概述]") >= 0)
                        {
                            nextKey = "overview";
                        }
                        else if (line.IndexOf("[詩曰]") >= 0)
                        {
                            nextKey = "poetry";
                        }
                        else if (line.IndexOf("[解曰]") >= 0)
                        {
                            nextKey = "explanation";
                        }
                        else if (line.IndexOf("[釋義]") >= 0)
                        {
                            nextKey = "interpretation";
                            interpretation = new JArray();
                        }
                    }
                    else
                    {
                        if (nextKey == "interpretation")
                        {
                            if (line.TrimEnd().Length > 0)
                            {
                                if (line.IndexOf('：') >= 0)
                                {
                                    int sep = line.IndexOf('：');
                                    JObject intep_item = new JObject();
                                    intep_item["key"] = line.Substring(0, sep);
                                    intep_item["value"] = line.Substring(sep + 1, line.Length - sep -1);
                                    interpretation.Add(intep_item);
                                }
                            }
    
                            jo["interpretation"] = interpretation;
                        }else if (nextKey.Length > 0 )
                        {
                            jo[nextKey] = line;
                        }
                    }

                }
                list.Add(jo);


                sr.Close();

                tb_output.Text = list.ToString();
            }
            else
            {
                MessageBox.Show("File is not opened.");
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new
                   System.IO.StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.UTF8);
                sw.Write(list.ToString());
                sw.Close();
            }
        }
    }
}
