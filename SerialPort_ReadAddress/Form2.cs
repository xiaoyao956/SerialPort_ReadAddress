using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SerialPort_ReadAddress
{
    public partial class Form2 : Form
    {
        bool notClose = true;

        //委托更新任务列表
        public delegate void Test_dataGridView(DataGridView dataGridView, List<TaskList> text);
        public void Test_Text_dataGridView(DataGridView dataGridView, List<TaskList> text)
        {
            dataGridView.DataSource = text;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeader;
        }
        //委托清除任务列表
        public delegate void Test_dataGridView_Clear(DataGridView dataGridView);
        public void Test_Clear_dataGridView(DataGridView dataGridView)
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
        }
        
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //dataGridView1.Rows.Clear();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭窗口时停止刷新任务列表
            notClose = false;
        }

        /// <summary>
        /// 删除任务方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            int[] ints = new int[dataGridView1.SelectedRows.Count];
            for (int i = 0; dataGridView1.SelectedRows.Count > i ; i++)//遍历所有选中的行
            {
                ints[i] = dataGridView1.SelectedRows[i].Index;
                if (ints[i] == 0)
                {
                    MessageBox.Show("不允许删除正在执行任务.");
                    return;
                }
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    TaskListClass.taskList.RemoveAt(ints[i]);
                    BeginInvoke(new Test_dataGridView_Clear(Test_Clear_dataGridView), new object[] { dataGridView1 });
                    BeginInvoke(new Test_dataGridView(Test_Text_dataGridView), new object[] { dataGridView1, TaskListClass.taskList });
                    return;
                }
            }
            
            Array.Sort(ints);
            if (ints[0] < ints[1])
            {
                Array.Reverse(ints);
            }
            
            foreach(int i in ints)
            {
                TaskListClass.taskList.RemoveAt(i);
            }
            BeginInvoke(new Test_dataGridView_Clear(Test_Clear_dataGridView), new object[] { dataGridView1 });
            BeginInvoke(new Test_dataGridView(Test_Text_dataGridView), new object[] { dataGridView1, TaskListClass.taskList });
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            notClose = true;
            int listcount = TaskListClass.taskList.Count;
            BeginInvoke(new Test_dataGridView_Clear(Test_Clear_dataGridView), new object[] { dataGridView1 });
            BeginInvoke(new Test_dataGridView(Test_Text_dataGridView), new object[] { dataGridView1, TaskListClass.taskList });

            //异步刷新任务列表
            Task.Run(() =>
            {
                while (notClose)
                {
                    if (listcount != TaskListClass.taskList.Count && notClose)
                    {
                        listcount = TaskListClass.taskList.Count;
                        BeginInvoke(new Test_dataGridView_Clear(Test_Clear_dataGridView), new object[] { dataGridView1 });
                        BeginInvoke(new Test_dataGridView(Test_Text_dataGridView), new object[] { dataGridView1, TaskListClass.taskList });
                    }
                }
            });
            //dataGridView1.DataSource = List;
        }
    }
}
