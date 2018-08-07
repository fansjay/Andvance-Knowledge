using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AysncMutiThread
{
    public partial class MutiThreadPubicResource : Form
    {

        private int TicketCount = 0;
        private static object lockticketObj = new object(); //锁最好是静态的对象
        private delegate void BtnEnableDelegate();


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
            this.richTextBox1.Text += "\t\n 现有票数量" + TicketCount.ToString();
        }

        private async void Btn_download_Click(object sender, EventArgs e)
        {

#if false
            #region 用委托（老方法）
            this.Btn_download.Enabled = false;
            WebClient webClient = new WebClient();
            Thread thread = new Thread(() =>
            {
                var result = webClient.DownloadString("http://www.cnblogs.com/KnightsWarrior/");

                
                //webClient.DownloadStringCompleted += IsDownloadComplete;
                MessageBox.Show(result);
                //这里会报错： 因为Btn_download是主线程创建的 但我们拿thread线程【跨线程】来操作显然是不行的 
                //Btn_download.Enabled = true;
                if (this.Btn_download.InvokeRequired)
                {
                    BtnEnableDelegate btnEnableDelegate = new BtnEnableDelegate(() => 
                    {
                        MessageBox.Show("下载完成！");
                        this.Btn_download.Enabled = true;                       
                    });
                    this.Btn_download.BeginInvoke(btnEnableDelegate);
                }
            });
            thread.Start();
            #endregion
#endif
            #region Await、Async使用效果跟上面的一模一样 
            /*
             * 使用await：后面的语句相当于阻塞了只有等可能引起阻塞的代码执行完成后，才会执行！
             */
            this.Btn_download.Enabled = false;
            WebClient webClient = new WebClient();

            //下面这句如果没有await呢？ 如果没有await就不会阻塞了 直接弹出下载完成然后按钮可以使用
            //await后面的相当于回调 【await后面必须是一个task（或者是一个方法）】这里的DownloadStringTaskAsync就是一个任务
            var results = await webClient.DownloadStringTaskAsync("http://www.cnblogs.com/KnightsWarrior/"); //只会返回一个Task 并且是瞬间返回
            MessageBox.Show("下载完成");
            this.Btn_download.Enabled = true;

            await Task.Run(() => {
                File.WriteAllText($"{DateTime.Now.ToString("yyyyMMddHHmmss")}test.txt",results);
            });
            #endregion
        }


    }
}
