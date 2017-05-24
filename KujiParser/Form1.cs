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
using Newtonsoft.Json;

namespace KujiParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string file_name = "";
        private string file_name2 = "";
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
        private String list_csv = "";

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
                if (cb_csv.Checked) sw.Write(list_csv);
                else sw.Write(list.ToString());

                sw.Close();
            }
        }


        private void btn_process2_Click(object sender, EventArgs e)
        {

            if (file_name.Length > 0)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(file_name);

                string json_string = sr.ReadToEnd();
                sr.Close();
                System.IO.StreamReader sr2 = new System.IO.StreamReader(file_name2);

                string json_string2 = sr2.ReadToEnd();
                sr2.Close();
                list = new JArray();
                JArray source = JsonConvert.DeserializeObject<JArray>(json_string);
                JArray source2 = JsonConvert.DeserializeObject<JArray>(json_string2);
                int i = 0;
                foreach (var item in source)
                {
                    JObject jo = new JObject();
                    jo["id"] = item["id"];
                    jo["num"] = source2[i]["num"];
                    jo["title"] = item["title"];
                    jo["text"] = item["text"];
                    jo["type"] = item["type"];
                    string[] info1 = item["info1"].ToString().Split(new string[] { "<br>" }, StringSplitOptions.None);
                    jo["overview"] = info1[0];
                    jo["poetry"] = info1[1].Replace("靈籤之曰：","");
                    jo["explanation"] = item["info3"];
                    jo["remark"] = item["info4"];

                    JArray interpretation = new JArray();
                    String inttext = item["info2"].ToString().Replace("<br>", "　");
                    List<string> intarray = inttext.Split(new string[] { "　" }, StringSplitOptions.None).ToList();
                    foreach (var int_item in intarray)
                    {
                        string[] int_items = int_item.Split(new string[] { "－" }, StringSplitOptions.None);
                        JObject int_jo = new JObject();
                        if (int_items.Length >= 2)
                        {
                            int_jo["key"] = int_items[0];
                            int_jo["value"] = int_items[1];
                            interpretation.Add(int_jo);
                        }

                    }


                    jo["interpretation"] = interpretation;
                    ++i;

                    list.Add(jo);
                }

                

                tb_output.Text = list.ToString();
            }
            else
            {
                MessageBox.Show("File is not opened.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_open2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file_name2 = openFileDialog1.FileName;
            }
            else
            {
                file_name2 = "";
            }
            tb_file2.Text = file_name2;
        }

        private void btn_process3_Click(object sender, EventArgs e)
        {
            if (file_name.Length > 0)
            {
                System.IO.StreamReader sr = new
                      System.IO.StreamReader(openFileDialog1.FileName);
                string line = "";
                int i = 0;
                list = new JArray();
                list_csv = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] sl = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (sl.Length > 2)
                    {
                        if (sl[0].Length == 2)
                        {
                            JObject jo = new JObject();
                            jo["fan"] = sl[0];
                            jo["jian"] = sl[1];
                            list.Add(jo);

                            if (cb_csv.Checked)
                            {
                                list_csv += "\"" + jo["fan"] + "\"," + "\"" + jo["jian"] + "\"\r\n";
                            }
                        }

                    }
                    //++i;
                    //if (i > 10) break;
                }

                sr.Close();

                if (cb_csv.Checked) tb_output.Text = list_csv;
                else tb_output.Text = list.ToString();
            }
            else
            {
                MessageBox.Show("File is not opened.");
            }
        }

        private void btn_process4_Click(object sender, EventArgs e)
        {
            if (file_name.Length > 0)
            {
                System.IO.StreamReader sr = new
                      System.IO.StreamReader(openFileDialog1.FileName);
                string line = "";
                int i = 0;
                list = new JArray();
                list_csv = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] sl = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (sl.Length >= 2)
                    {
                        string[] sl2 = sl[1].Split('/');
                        JObject jo = new JObject();
                        if (sl2.Length > 0 && sl2[0].Length == 2)
                        {
                            if (sl2.Length > 1)
                            {
                                jo["fan"] = sl2[0];
                                jo["jian"] = sl2[1];
                            }
                            else if (sl2.Length == 1)
                            {
                                jo["fan"] = sl2[0];
                                jo["jian"] = sl2[0];
                            }

                            

                            if (cb_csv.Checked)
                            {
                                list_csv += "\"" + jo["fan"] + "\"," + "\"" + jo["jian"] + "\"\r\n";
                            }else
                            {
                                list.Add(jo);
                            }
                        }
                    }
                    //++i;
                    //if (i > 10) break;
                }

                sr.Close();
                if (cb_csv.Checked) tb_output.Text = list_csv;
                else tb_output.Text = list.ToString();
            }
            else
            {
                MessageBox.Show("File is not opened.");
            }
        }

        private void btn_process_save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new
                   System.IO.StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.UTF8);

                if (file_name.Length > 0)
                {
                    System.IO.StreamReader sr = new
                          System.IO.StreamReader(openFileDialog1.FileName);
                    string line = "";
                    int i = 0;
                    list = new JArray();
                    list_csv = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] sl = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (sl.Length >= 2)
                        {
                            string[] sl2 = sl[1].Split('/');
                            JObject jo = new JObject();
                            if (sl2.Length > 0 && sl2[0].Length == 2)
                            {
                                if (sl2.Length > 1)
                                {
                                    jo["fan"] = sl2[0];
                                    jo["jian"] = sl2[1];
                                }
                                else if (sl2.Length == 1)
                                {
                                    jo["fan"] = sl2[0];
                                    jo["jian"] = sl2[0];
                                }

                                if (cb_csv.Checked) sw.WriteLine("\"" + jo["fan"] + "\"," + "\"" + jo["jian"] + "\"");
                                else sw.WriteLine(jo.ToString());
                            }
                        }
                    }

                    sr.Close();
                    MessageBox.Show("File saved.");
                }
                else
                {
                    MessageBox.Show("File is not opened.");
                }

                sw.Close();
            }
        }

        private void btn_process5_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new
                   System.IO.StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.UTF8);

                if (file_name.Length > 0)
                {
                    System.IO.StreamReader sr = new
                          System.IO.StreamReader(openFileDialog1.FileName);
                    string line = "";
                    int i = 0;
                    list = new JArray();
                    list_csv = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        if (line.Length == 2)
                        {
                            if (line[0] != line[1])
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }

                    sr.Close();
                    MessageBox.Show("File saved.");
                }
                else
                {
                    MessageBox.Show("File is not opened.");
                }

                sw.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new
                   System.IO.StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.UTF8);

                if (file_name.Length > 0)
                {
                    System.IO.StreamReader sr = new
                          System.IO.StreamReader(openFileDialog1.FileName);
                    string line = "";
                    int i = 0;
                    list = new JArray();
                    list_csv = "";
                    while ((line = sr.ReadLine()) != null)
                    {

                        if (line.Length == 2)
                        {
                            if (line[0] != line[1])
                            {
                                sw.WriteLine(line[0] + "," + line[1]);
                            }
                        }
                    }

                    sr.Close();
                    MessageBox.Show("File saved.");
                }
                else
                {
                    MessageBox.Show("File is not opened.");
                }

                sw.Close();
            }
        }
    }
}
