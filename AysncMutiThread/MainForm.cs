using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AysncMutiThread
{
    /// <summary>
    /// 没有委托 就没有异步多线程
    /// 当我使用多线程的时候 CPU利用率在80%左右    只花了300毫秒
    /// 而我使用单线程的时候CPU利用率只有24%       却花了3900毫秒
    /// 公有资源的访问:
    /// </summary>

    public partial class MainForm : Form
    {
        Action<string> action;
        public MainForm()
        {
            InitializeComponent();
        }

        //同步
        /*
            1.当test方法正在运行的时候 界面UI是卡住的表示当前主线程是卡住状态
            2.
             
         */
        private void Btn_Sync_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < 16; i++)
            {
                test(string.Format("￥￥￥￥同步执行￥￥￥￥_{0}", i));
            }
            stopWatch.Stop();
            Console.WriteLine("共耗时:" + stopWatch.ElapsedMilliseconds);//毫秒
        }
        //异步
        /*
          1.当test方法正在运行的时候 界面UI是卡住的表示当前主线程可以正常拖动的
          2.


       */
        private void Btn_Async_Click(object sender, EventArgs e)
        {
            List<IAsyncResult> asyncResults = new List<IAsyncResult>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 16; i++)
            {
                action = test;
                asyncResults.Add(action.BeginInvoke(string.Format("****异步执行****_{0}", i), null, null));//委托的异步调用
            }


            /*
             while (asyncResults.Count(r=>r.IsCompleted)<5)
             {
                 Thread.Sleep(100);//主线程等待100毫秒
             }
             */

            foreach (var item in asyncResults)
            {
                item.AsyncWaitHandle.WaitOne(); //waitone 等待结果 AsyncWaitHandle：等待一个异步操作完成 
            }
            stopwatch.Stop();
            Console.WriteLine("共耗时:" + stopwatch.ElapsedMilliseconds);//毫秒
        }



        public void test(string name)
        {
            Console.WriteLine(name + ",开始：  线程ID:" + Thread.CurrentThread.ManagedThreadId + ",当前时间为：" + DateTime.Now.ToString("HH:mm:ss.ffff"));
            long sum = 0;
            for (int i = 0; i < 99999999; i++)
            {
                sum += i;
            }
            Console.WriteLine(name + ",结束：  线程ID:" + Thread.CurrentThread.ManagedThreadId + ",当前时间为：" + DateTime.Now.ToString("HH:mm:ss.ffff") + ",计算结果为:" + sum);
        }

        private void Btn_CommResource_Click(object sender, EventArgs e)
        {
            MutiThreadPubicResource mutiThreadPubicResource = new MutiThreadPubicResource();
            mutiThreadPubicResource.Show(this);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Thread默认是一个【前台线程 进程取消后，还会完成计算任务】。 (【thread.IsBackground = true;//后台线程 进程取消后 立即销毁。任务完成后 自动销毁】)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_thread_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //第一种线程等待
            List<Thread> threads = new List<Thread>();
            // ParameterizedThreadStart标准的开始
            ParameterizedThreadStart parameterizedThreadStart = a => test(a.ToString());
            for (int i = 0; i < 16; i++)
            {
                Thread thread = new Thread(parameterizedThreadStart);
                thread.Start(string.Format("通过thread执行!第{0}次", i));
                thread.IsBackground = true;//任务完成后 自动销毁 
                threads.Add(thread);
            }

            //  while (threads.Count(t=>t.ThreadState==System.Threading.ThreadState.Running)>0)//还有线程正在运行
            //{
            //  Thread.Sleep(10);
            //}

            foreach (var item in threads)
            {
                item.Join();//可以把当前的线程join到主线程里面 然后主线程就会【等着】这些线程执行完的时候才能继续完成
            }

            stopwatch.Stop();
            Console.WriteLine("共耗时:" + stopwatch.ElapsedMilliseconds);//毫秒
        }

        #region 带参数及返回值的多线程方法调用
        /// <summary>
        /// 自己定义的一个带有回调方法的线程
        /// </summary>
        /// <param name="action">委托</param>
        /// <param name="callback">回调方法</param>
        private void ThreadWithCallback(Action action, Action callback)
        {
            ThreadStart threadStart = new ThreadStart(() => { action(); callback(); });//当执行完Aaction后 再执行callback方法
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        /// <summary>
        /// 自己定义的一个带有回调方法的线程,有返回值
        /// </summary>
        /// <param name="func">有返回值的委托, bool int string ...都可以返回</param>
        /// <param name="callback">回调方法</param>
        private string ThreadWithCallbackandReturnValue(Func<string> func, Action callback)
        {
            string result = "";
            ThreadStart threadStart = new ThreadStart(() => { result = func(); callback(); });//当执行完Aaction后 再执行callback方法
            Thread thread = new Thread(threadStart);
            thread.Start();
            thread.Join();//加入主线程等待，如果没有执行完则一直等待下去，执行完则返回(string)
            return result;
        }

        #endregion

        /// <summary>
        /// 线程池，可以重复利用，在线程完成后又被释放提前保存好一堆的线程 等你需要的时候调用 threadpool都是后台线程 速度快
        /// 线程池等待
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_threadpool_Click(object sender, EventArgs e)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //第一种线程等待
            List<Thread> threads = new List<Thread>();


            // ParameterizedThreadStart标准的开始
            ParameterizedThreadStart parameterizedThreadStart = a => test(a.ToString());

            for (int i = 0; i < 16; i++)
            {
                ManualResetEvent manualResetEvent = new ManualResetEvent(false);
                WaitCallback waitCallback = t => { test(t.ToString()); manualResetEvent.Set(); /* 当执行完的时候再让这些执行*/};
                ThreadPool.QueueUserWorkItem(waitCallback, string.Format("------>threadpool执行：{0}", i));
                manualResetEvent.WaitOne();//阻止当前线程 直到当前waithandle收到信号（也就是说test方法执行完成才可以）
                //
            }
            #region 线程池
#if false
              //【当初始化为false：非终止状态 waitone()立即返回 =>Reset变成非终止状态 】
            //【当初始化为true：终止状态  waitone() 不会立即返回，等待Set() =>Set变成终止状态】
            ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            new Action(() => { Thread.Sleep(3000); manualResetEvent.Set(); }).BeginInvoke(null, null); //如果不让其它线程来操作manualResetEvent.set();  下面这句话永远不会执行manualResetEvent.WaitOne();
            manualResetEvent.WaitOne();//不通过
#endif
#if false

            #region 线程池参数
            int workThreadsCount = 0;
            int cpm = 0;
            ThreadPool.GetAvailableThreads(out workThreadsCount, out cpm);
            Console.WriteLine(string.Format("workThreadsCount->{0},completionPortThreads->{1}", workThreadsCount, cpm));
            #endregion
#endif
            #endregion
            stopwatch.Stop();
            Console.WriteLine("共耗时:" + stopwatch.ElapsedMilliseconds);//毫秒
        }

        /// <summary>
        /// 【推荐使用Task】【新版本才会有 高大上】无论waitall waitany都是回调形式 【都会卡住主线程】 --> 而ContinueWhenAll ContinueWhenAny 【不会卡主线程】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Task_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Action<object> action = a => { test(a.ToString()); };
            List<Task> tasks = new List<Task>();
            TaskFactory taskFactory = new TaskFactory();
            for (int i = 0; i < 16; i++)
            {
                Task task = taskFactory.StartNew(action, string.Format("Task执行第{0}次", i))/*.ContinueWith(action)注意这也是一个回调可以直接回调*/;
                tasks.Add(task);
            }






#if false  //无论waitall waitany都是回调形式 【都会卡住主线程】 --> 而ContinueWhenAll ContinueWhenAny 【不会卡主线程】
           /*无论 waitany waitall都是卡住 主线程*/
            Task.WaitAny(tasks.ToArray());//等待TASKS数组中任意一个线程完成
            Console.WriteLine("一个线程完成");
            Task.WaitAll(tasks.ToArray());//等待所有线程完成  如果没有参数则没有效果            
#endif
            //带回调的 a就是前面tasks的数组 AsyncState就是我们调用的参数 当tasks线程中任意一个任务完成 就启动下面这个console 
            taskFactory.ContinueWhenAny(tasks.ToArray(), a =>
            {
                Console.WriteLine(a.AsyncState + "," + a.IsCompleted);
            });

            //带回调的 a就是前面tasks的数组 当所有tasks任务完成再启动下面这个console
            taskFactory.ContinueWhenAll(tasks.ToArray(), a =>
            {
                foreach (var item in a)
                {
                    //回调动作 当所有任务完成时立即调用此动作
                    Console.WriteLine(item.AsyncState + "," + item.IsCompleted);
                }
            });

            //这里主线程还是阻塞的 正在等待中....

#if false

            //如果是单任务的回调
            Task task = taskFactory.StartNew(action, string.Format("Task执行第{0}次", i))/*.ContinueWith(action)注意这也是一个回调可以直接回调*/;

#endif
            stopwatch.Stop();
            Console.WriteLine("共耗时:" + stopwatch.ElapsedMilliseconds + "毫秒");//毫秒
        }
        /// <summary>
        /// Parallel 并行运算，基于Task实现 
        /// parallel【=Task + WaitAll】就是task的封装
        /// 计算完成后才会进入下一行代码 比如 Parallel【1】-->Parallel【2】--->Parallel【3】        
        ///【也是多线程】
        ///一定会卡住界面
        ///可以控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Parallel_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ParallelOptions parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 5,/*最大线程数设置为5个*/           };
            Parallel.Invoke(
                () => Console.WriteLine("Parallel【1】执行：" + "当前线程ID:" + Thread.CurrentThread.ManagedThreadId),
                () => Console.WriteLine("Parallel【2】执行：" + "当前线程ID:" + Thread.CurrentThread.ManagedThreadId),
                () => Console.WriteLine("Parallel【3】执行：" + "当前线程ID:" + Thread.CurrentThread.ManagedThreadId),
                () => Console.WriteLine("Parallel【4】执行：" + "当前线程ID:" + Thread.CurrentThread.ManagedThreadId));

            Parallel.ForEach<int>(new int[] { 3, 4, 5, 6, 7, 4, 5435, 345, 435, 435, 324324, 32432, 423, 42, 323, 423, 432, 4, 324, 32, 4, 324, 8900, 324, 23, 4, 23, 4, 324, 32, 4, 32, 4, 23, 23423, 32, 324324, 2, 2, 56, 6, 765, 75, 7, 6, 66, 6, 666664, 900 },
                t => { Console.WriteLine(t.ToString() + "线程——>" + Thread.CurrentThread.ManagedThreadId); Thread.Sleep(1000); });

            Parallel.For(0, 1905, parallelOptions, (t, state) =>
            {
                Console.WriteLine(t.ToString());
                state.Break();//当前执行一个其它几个立即停止 
                state.Stop();//停止当前Parallel
            });//注意这个东西是多线程的....会开启新线程的东西

            /*我有100个任务 5个线程完成  */
            stopwatch.Stop();
            Console.WriteLine("Parallel共耗时:" + stopwatch.ElapsedMilliseconds + "毫秒");//毫秒
        }
        /// <summary>
        /// Async Await 语法糖
        /// .NET4.5 CLR4.0 C#5.0 【VS2015-->C#6.0】才引用Async Await 
        /// Async Await依赖Task的异步。。
        /// 只要在方法面前加上Async 里面必须有Await【如果单独出现async是没有意义的 最多出现一个警告】
        /// Await只能出现在Task前面，
        /// 【只要是await后面的东西都会变成回调 ？？？？？】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_AsyncAwait_Click(object sender, EventArgs e)
        {
            Console.WriteLine(string.Format("进入Btn_AsyncAwait_Click方法,线程ID{0}", Thread.CurrentThread.ManagedThreadId));
            string str = await AsyncMethod();//跟调用普通方法没有区别
            Console.WriteLine(str);
            Console.WriteLine(string.Format("离开Btn_AsyncAwait_Click方法,线程ID{0}", Thread.CurrentThread.ManagedThreadId));
        }
        private async Task<string> AsyncMethod() //如果有返回值string:Task<string>
        {
            string temp = "V";
            Console.WriteLine(string.Format("进入AsyncMethod方法，线程ID：{0}", Thread.CurrentThread.ManagedThreadId));
            TaskFactory taskFactory = new TaskFactory();
            Task task = taskFactory.StartNew(() =>
            {
                Console.WriteLine(string.Format("Task子线程方法，线程ID：{0}", Thread.CurrentThread.ManagedThreadId));
                Thread.Sleep(5000);
                Console.WriteLine(string.Format("Task子线程休息5秒后执行，线程ID：{0}", Thread.CurrentThread.ManagedThreadId));
            });
            await task;//主线程会等待 Task执行完以后才会继续执行
            Console.WriteLine(string.Format("离开AsyncMethod方法，线程ID：{0}", Thread.CurrentThread.ManagedThreadId));
            return temp;
        }

        /// <summary>
        /// 多线程相关
        /// 【多线程如果出现异步？==>】 异步多线程中  如果在子线程发生异步，主线程是无法捕捉到异步的、例如try catch 就不可以
        /// Task的取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ThreadXiangGuan_Click(object sender, EventArgs e)
        {
            //Task的一个标志
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Action<object> action = a =>
                {
                    // try
                    // {
                    if (a.ToString().Equals("Task执行第10"))
                    {
                       // cancellationTokenSource.Cancel();
                        throw new Exception(string.Format("{0}时失败", a.ToString()));
                    }
                    test(a.ToString());
                    Thread.Sleep(1000);
                    if(!cancellationTokenSource.IsCancellationRequested)
                    {
                        Console.WriteLine("已经完成任务{0}",a.ToString());
                    }
                    else
                    {
                        Console.WriteLine("已经取消任务{0}", a.ToString());
                    }

                    // }
                    // catch (Exception ex)
                    // {
                    //     Console.WriteLine("子线程抛出异步！{0}",ex.Message);
                    // }
                };
                List<Task> tasks = new List<Task>();
                TaskFactory taskFactory = new TaskFactory();
                for (int i = 0; i < 16; i++)
                {
                    Task task = taskFactory.StartNew(action, string.Format("Task执行第{0}", i),cancellationTokenSource.Token)/*.ContinueWith(action)注意这也是一个回调可以直接回调*/;
                    tasks.Add(task);
                }
                Task.WaitAll(tasks.ToArray()); //阻塞
                //Task.WhenAll(tasks.ToArray());
                stopwatch.Stop();
                Console.WriteLine("共耗时:" + stopwatch.ElapsedMilliseconds + "毫秒");//毫秒
            }
            catch (Exception ex)
            {
                cancellationTokenSource.Cancel();//当一个发生错误时取消
                Console.WriteLine("主线程抛出异步!==>{0}", ex.Message);
            }
        }
        /// <summary>
        ///  【多线程的临时变量问题】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MutiThreadVariable_Click(object sender, EventArgs e)
        {
            Action<int> action = i => { Thread.Sleep(100); Console.WriteLine(i); };
            for (int i = 0; i < 10; i++)
            {
                /*
                 action.BeginInvoke(i, null, null); 这句话的结果为什么是0，1，2，3，4，5..9
                 Task.Run(()=>action(i));           这句话的结果为什么是10,10,10,10,10,10,10,10  当多线程任务真的执行时i已经变成10了 
                 */
                //action.BeginInvoke(i, null, null); 
                int k = i;
                Task.Run(()=>action(k/*i*/));//这样就可以了
            }
        }
    }
}
