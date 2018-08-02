using System;
using System.Threading;
using System.Windows.Forms;

namespace Delegate
{
    public partial class DelegateForm : Form
    {

        /*一般使用action,很少自己自定义委托*/
        //定义改变进度的委托
         private delegate void SetProgressValueDelegate(int value);

        //声明委托
        SetProgressValueDelegate setProgressValueDelegate=null;
        public DelegateForm()
        {
            InitializeComponent();
        }

        private void Btn_ChangeProgress_Click(object sender, EventArgs e)
        {

#if false //不使用线程的 
            for (int i = 0; i <=100; i++)
            {
                Application.DoEvents();
                Thread.Sleep(10);//把控制权交还给用户
                progressBar1.Value = i;
            }
            for (int i = 0; i <=100; i++)
            {
                Application.DoEvents();
                Thread.Sleep(10);
                progressBar2.Value = i;
            }
#endif
            //定义--> 声明-->实例化委托  【X】
            // setProgressValue = new SetProgressValue(DelegateMethod);
            //新方法  【V】 【错误:线程间操作无效】 【还是要用方法呀】
            setProgressValueDelegate=a=>SetProgressValue(a);            
            setProgressValueDelegate(80);
        }
        private  void  SetProgressValue(int val)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(setProgressValueDelegate,val);
            }
            else
            {
                setProgressValueDelegate(val);
            }          
        }


      
    }
}
