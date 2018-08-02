using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AysncMutiThread
{
    public partial class MutiThreadPubicResource : Form
    {

        private int TicketCount = 0;
        private static object lockticketObj=new object(); //锁最好是静态的对象
        public MutiThreadPubicResource()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {

            base.OnFormClosing(e);
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {

            //用锁的方式解决多线程访问公有资源 （效率比较差 跟同步方法没有区别 不推荐使用）
            Action action = () =>
            {
                lock (lockticketObj) //加锁了一般都没有问题了
                {
                    TicketCount++;
                }                
            };


             

            for (int i = 0; i < 100000; i++)
            {
                action.BeginInvoke(null, null);//结果应该是一万
            }
            this.richTextBox1.Text +="\t\n 现有票数量"+ TicketCount.ToString();
        }
    }
}
