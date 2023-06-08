using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HexAll;
using System.Threading;
using System.Diagnostics;

namespace SerialPort_ReadAddress
{
    public partial class Form1 : Form
    {
        //委托为添加文本
        public delegate void Test(TextBox textBox, string text);
        public void Test_Text(TextBox textBox, string text)
        {
            textBox.Text += text + "\r\n";
            textBox.SelectionStart = textBox.TextLength;
            textBox.ScrollToCaret();
        }
        //委托修改文本
        public delegate void Test_label(Label textlabel, string text);
        public void Test_Text_label(Label textlabel, string text)
        {
            textlabel.Text = text;
        }
        public Form1()
        {
            InitializeComponent();

            Text_PortName.Items.AddRange(SerialPort.GetPortNames());
            Text_DataBits.Items.AddRange(new object[] { "5", "6", "7", "8" });
            Text_StopBits.Items.AddRange(new object[] { StopBits.One, StopBits.OnePointFive, StopBits.Two, StopBits.None });
            Text_Parity.Items.AddRange(new object[] { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space });
            Text_ReadAddress.Items.AddRange(new object[] { "DL-T 645","DLT698", "DLT698 明文读取", "DLT698 明文+MAC" });

            Text_ReadAddress.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ContextMenuStrip = contextMenuStrip1;
            textBox2.ContextMenuStrip = contextMenuStrip1;

            //打开读取数据
            Text_PortName.Text = Properties.Settings.Default.PortName;
            Text_DataBits.Text = Properties.Settings.Default.DataBits;
            Text_StopBits.Text = Properties.Settings.Default.StopBits;
            Text_Parity.Text = Properties.Settings.Default.Parity;
            Text_BaudRate.Text = Properties.Settings.Default.BaudRate;
            Text_ReadAddress.Text = Properties.Settings.Default.ReadAddress;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭保存数据
            Properties.Settings.Default.PortName = Text_PortName.Text;
            Properties.Settings.Default.DataBits = Text_DataBits.Text;
            Properties.Settings.Default.StopBits = Text_StopBits.Text;
            Properties.Settings.Default.Parity = Text_Parity.Text;
            Properties.Settings.Default.BaudRate = Text_BaudRate.Text;
            Properties.Settings.Default.ReadAddress = Text_ReadAddress.Text;
            Properties.Settings.Default.Save();
        }

        

        List<TaskList> taskLists = new List<TaskList>();
        List<Parameter> parameterslist = new List<Parameter>();
        private static readonly object thisLock = new object();

        private async void button1_Click(object sender, EventArgs e)
        {
            string text = String.Empty;
            if (Text_ReadAddress.Text == "DL-T 645")
            {
                text = "FE FE FE FE 68 AA AA AA AA AA AA 68 13 00 DF 16";
            }
            else if (Text_ReadAddress.Text == "DLT698")
            {
                text = "FE FE FE FE 68 1C 00 43 45 AA AA AA AA AA AA 10 C3 1D 05 02 02 02 40 01 02 00 40 02 02 00 00 C8 C3 16";
            }
            else if (Text_ReadAddress.Text == "DLT698 明文读取")
            {
                text = "FE FE FE FE 68 14 00 43 45 AA AA AA AA AA AA 10 69 A1 05 02 02 01 00 32 3F 16";
            }
            else if (Text_ReadAddress.Text == "DLT698 明文+MAC")
            {
                text = "FE FE FE FE 68 1D 00 43 45 AA AA AA AA AA AA 10 52 48 10 00 05 05 02 02 01 00 01 04 12 34 56 78 59 FE 16";
            }
            else
            {
                MessageBox.Show("读地址为空");
                return;
            }
            //存储文本数据
            string BaudRate = Text_BaudRate.Text;
            string Parity = Text_Parity.Text;
            string DataBits = Text_DataBits.Text;
            string StopBits = Text_StopBits.Text;
            string PortName = Text_PortName.Text;

            //多任务添加
            TaskList tasklist = new TaskList
            {
                BaudRate = BaudRate,
                Parity = Parity,
                DataBits = DataBits,
                StopBits = StopBits,
                PortName = PortName,
                text = text
            };
            taskLists.Add(tasklist);
            //任务列表静态保存
            TaskListClass.taskList = taskLists;
            BeginInvoke(new Test_label(Test_Text_label), new object[] { label7, "任务数量：" + taskLists.Count });
            //多线程启动,防止主UI卡顿
            await Task.Run(() =>
            {
                //添加锁防止多个任务同时启动
                lock (thisLock)
                {
                    //判断任务有无删除
                    if(TaskListClass.taskList.Count != 0 && TaskListClass.taskList[0] == tasklist)
                    {
                        //textBox2.Text += "发送命令：" + text + "\r\n";
                        BeginInvoke(new Test(Test_Text), new object[] { textBox2, "发送命令：" + text + "\r\n" });

                        Stopwatch s1 = new Stopwatch();
                        s1.Start();
                        string Readtext = Hex.Port_String(text, PortName, BaudRate, Parity, DataBits, StopBits);
                        s1.Stop();
                        //textBox2.Text += "接收命令：" + text + "\r\n";
                        BeginInvoke(new Test(Test_Text), new object[] { textBox2, "接收命令：" + Readtext + " 运行时间:" + s1.ElapsedMilliseconds + "毫秒" + "\r\n" });

                        //记录完成数据
                        Parameter parameter = new Parameter();
                        parameter.ID = parameterslist.Count + 1;
                        parameter.BaudRate = BaudRate;
                        parameter.Parity = Parity;
                        parameter.DataBits = DataBits;
                        parameter.StopBits = StopBits;
                        parameter.PortName = PortName;
                        parameter.WirtPost = text;
                        parameter.ReadPost = Readtext;

                        parameterslist.Add(parameter);
                        ParameterList.Parameters = parameterslist;
                    }
                    taskLists.Remove(tasklist);
                }
            });
            BeginInvoke(new Test_label(Test_Text_label), new object[] { label7, "任务数量：" + taskLists.Count });
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TaskListClass.taskList = taskLists;
            Form2 form2 = new Form2(1);
            form2.ShowDialog();
            BeginInvoke(new Test_label(Test_Text_label), new object[] { label7, "任务数量：" + TaskListClass.taskList.Count });

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ParameterList.Parameters = parameterslist;
            Form2 form2 = new Form2(2);
            form2.ShowDialog();
        } 
    }
}
