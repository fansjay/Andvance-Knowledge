namespace AysncMutiThread
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Btn_Sync = new System.Windows.Forms.Button();
            this.Btn_Async = new System.Windows.Forms.Button();
            this.Btn_CommResource = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_thread = new System.Windows.Forms.Button();
            this.Btn_threadpool = new System.Windows.Forms.Button();
            this.Btn_Task = new System.Windows.Forms.Button();
            this.Btn_Parallel = new System.Windows.Forms.Button();
            this.Btn_AsyncAwait = new System.Windows.Forms.Button();
            this.Btn_ThreadXiangGuan = new System.Windows.Forms.Button();
            this.Btn_MutiThreadVariable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Sync
            // 
            this.Btn_Sync.Location = new System.Drawing.Point(12, 12);
            this.Btn_Sync.Name = "Btn_Sync";
            this.Btn_Sync.Size = new System.Drawing.Size(93, 36);
            this.Btn_Sync.TabIndex = 0;
            this.Btn_Sync.Text = "同步按钮";
            this.Btn_Sync.UseVisualStyleBackColor = true;
            this.Btn_Sync.Click += new System.EventHandler(this.Btn_Sync_Click);
            // 
            // Btn_Async
            // 
            this.Btn_Async.Location = new System.Drawing.Point(111, 12);
            this.Btn_Async.Name = "Btn_Async";
            this.Btn_Async.Size = new System.Drawing.Size(84, 36);
            this.Btn_Async.TabIndex = 1;
            this.Btn_Async.Text = "异步按钮";
            this.Btn_Async.UseVisualStyleBackColor = true;
            this.Btn_Async.Click += new System.EventHandler(this.Btn_Async_Click);
            // 
            // Btn_CommResource
            // 
            this.Btn_CommResource.Location = new System.Drawing.Point(960, 61);
            this.Btn_CommResource.Name = "Btn_CommResource";
            this.Btn_CommResource.Size = new System.Drawing.Size(153, 36);
            this.Btn_CommResource.TabIndex = 2;
            this.Btn_CommResource.Text = "多线程访问公有资源";
            this.Btn_CommResource.UseVisualStyleBackColor = true;
            this.Btn_CommResource.Click += new System.EventHandler(this.Btn_CommResource_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 103);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1101, 439);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "\t1.看到1:05:22秒\n\t2.thread和threadpool在1：12：20秒\n\t3.threadpool都是后台线程 速度快\n\t4.Async Awai" +
    "t 1:31:35秒 结束于1：51：40秒";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // btn_thread
            // 
            this.btn_thread.Location = new System.Drawing.Point(201, 12);
            this.btn_thread.Name = "btn_thread";
            this.btn_thread.Size = new System.Drawing.Size(125, 36);
            this.btn_thread.TabIndex = 4;
            this.btn_thread.Text = "Thread";
            this.btn_thread.UseVisualStyleBackColor = true;
            this.btn_thread.Click += new System.EventHandler(this.btn_thread_Click);
            // 
            // Btn_threadpool
            // 
            this.Btn_threadpool.Location = new System.Drawing.Point(332, 12);
            this.Btn_threadpool.Name = "Btn_threadpool";
            this.Btn_threadpool.Size = new System.Drawing.Size(125, 36);
            this.Btn_threadpool.TabIndex = 4;
            this.Btn_threadpool.Text = "ThreadPool";
            this.Btn_threadpool.UseVisualStyleBackColor = true;
            this.Btn_threadpool.Click += new System.EventHandler(this.Btn_threadpool_Click);
            // 
            // Btn_Task
            // 
            this.Btn_Task.Location = new System.Drawing.Point(463, 12);
            this.Btn_Task.Name = "Btn_Task";
            this.Btn_Task.Size = new System.Drawing.Size(98, 36);
            this.Btn_Task.TabIndex = 5;
            this.Btn_Task.Text = "Task";
            this.Btn_Task.UseVisualStyleBackColor = true;
            this.Btn_Task.Click += new System.EventHandler(this.Btn_Task_Click);
            // 
            // Btn_Parallel
            // 
            this.Btn_Parallel.Location = new System.Drawing.Point(567, 12);
            this.Btn_Parallel.Name = "Btn_Parallel";
            this.Btn_Parallel.Size = new System.Drawing.Size(102, 36);
            this.Btn_Parallel.TabIndex = 6;
            this.Btn_Parallel.Text = "Parallel";
            this.Btn_Parallel.UseVisualStyleBackColor = true;
            this.Btn_Parallel.Click += new System.EventHandler(this.Btn_Parallel_Click);
            // 
            // Btn_AsyncAwait
            // 
            this.Btn_AsyncAwait.Location = new System.Drawing.Point(12, 61);
            this.Btn_AsyncAwait.Name = "Btn_AsyncAwait";
            this.Btn_AsyncAwait.Size = new System.Drawing.Size(144, 36);
            this.Btn_AsyncAwait.TabIndex = 7;
            this.Btn_AsyncAwait.Text = "Async AWait";
            this.Btn_AsyncAwait.UseVisualStyleBackColor = true;
            this.Btn_AsyncAwait.Click += new System.EventHandler(this.Btn_AsyncAwait_Click);
            // 
            // Btn_ThreadXiangGuan
            // 
            this.Btn_ThreadXiangGuan.Location = new System.Drawing.Point(162, 62);
            this.Btn_ThreadXiangGuan.Name = "Btn_ThreadXiangGuan";
            this.Btn_ThreadXiangGuan.Size = new System.Drawing.Size(113, 35);
            this.Btn_ThreadXiangGuan.TabIndex = 8;
            this.Btn_ThreadXiangGuan.Text = "多线程相关";
            this.Btn_ThreadXiangGuan.UseVisualStyleBackColor = true;
            this.Btn_ThreadXiangGuan.Click += new System.EventHandler(this.Btn_ThreadXiangGuan_Click);
            // 
            // Btn_MutiThreadVariable
            // 
            this.Btn_MutiThreadVariable.Location = new System.Drawing.Point(290, 62);
            this.Btn_MutiThreadVariable.Name = "Btn_MutiThreadVariable";
            this.Btn_MutiThreadVariable.Size = new System.Drawing.Size(118, 35);
            this.Btn_MutiThreadVariable.TabIndex = 9;
            this.Btn_MutiThreadVariable.Text = "多线程的临时变量";
            this.Btn_MutiThreadVariable.UseVisualStyleBackColor = true;
            this.Btn_MutiThreadVariable.Click += new System.EventHandler(this.Btn_MutiThreadVariable_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 554);
            this.Controls.Add(this.Btn_MutiThreadVariable);
            this.Controls.Add(this.Btn_ThreadXiangGuan);
            this.Controls.Add(this.Btn_AsyncAwait);
            this.Controls.Add(this.Btn_Parallel);
            this.Controls.Add(this.Btn_Task);
            this.Controls.Add(this.Btn_threadpool);
            this.Controls.Add(this.btn_thread);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Btn_CommResource);
            this.Controls.Add(this.Btn_Async);
            this.Controls.Add(this.Btn_Sync);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "异步多线程";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Sync;
        private System.Windows.Forms.Button Btn_Async;
        private System.Windows.Forms.Button Btn_CommResource;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_thread;
        private System.Windows.Forms.Button Btn_threadpool;
        private System.Windows.Forms.Button Btn_Task;
        private System.Windows.Forms.Button Btn_Parallel;
        private System.Windows.Forms.Button Btn_AsyncAwait;
        private System.Windows.Forms.Button Btn_ThreadXiangGuan;
        private System.Windows.Forms.Button Btn_MutiThreadVariable;
    }
}

