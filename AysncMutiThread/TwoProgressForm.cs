using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AysncMutiThread
{
    public partial class TwoProgressForm : Form
    {

        private delegate void ChangeProgressValueDelegate();
        public TwoProgressForm()
        {
            InitializeComponent();
        }

        private void Btn_ChangeProgress_Click(object sender, EventArgs e)
        {
            TaskFactory taskFactory = new TaskFactory();
            Action<object> action = (p) => setProgressValue(p as ProgressBar);
            List<Task> tasks = new List<Task>();
            Task task1= taskFactory.StartNew(action,progressBar1);
            Task task2 = taskFactory.StartNew(action, progressBar2);
            tasks.Add(task1); tasks.Add(task2);
            taskFactory.ContinueWhenAll(tasks.ToArray(),a=> {
                foreach (var item in a)
                {
                    Console.WriteLine("item.Status" + item.Status+ " <==> item.IsCompleted:" + item.IsCompleted);
                }
            });
        }

        private void setProgressValue(ProgressBar progressBar)
        {
            ChangeProgressValueDelegate p = new ChangeProgressValueDelegate(()=>{
                for (int i = 0; i <=100; i++)
                {
                    progressBar.Value = i;
                    Thread.Sleep(50);
                }
            });
            if (progressBar.InvokeRequired)
            {
                progressBar.BeginInvoke(p);
            }
            Console.WriteLine($"当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
