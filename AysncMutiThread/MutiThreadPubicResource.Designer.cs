namespace AysncMutiThread
{
    partial class MutiThreadPubicResource
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Start = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Btn_download = new System.Windows.Forms.Button();
            this.progressBar_down = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(661, 415);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(127, 33);
            this.Btn_Start.TabIndex = 0;
            this.Btn_Start.Text = "开始";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(776, 354);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "关于公有资源多线程的访问:\n\n\n\t1.对于共有变量的操作及访问\n\t2.建议一个静态对象锁 不要用字符串\n\t3.线程冲突问题。可能同时100个线程同时操作的时候冲突" +
    "\n\t4.lock(私有的静态对象){}";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Btn_download
            // 
            this.Btn_download.Location = new System.Drawing.Point(542, 415);
            this.Btn_download.Name = "Btn_download";
            this.Btn_download.Size = new System.Drawing.Size(113, 33);
            this.Btn_download.TabIndex = 2;
            this.Btn_download.Text = "下载按钮";
            this.Btn_download.UseVisualStyleBackColor = true;
            this.Btn_download.Click += new System.EventHandler(this.Btn_download_Click);
            // 
            // progressBar_down
            // 
            this.progressBar_down.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.progressBar_down.Location = new System.Drawing.Point(90, 372);
            this.progressBar_down.Name = "progressBar_down";
            this.progressBar_down.Size = new System.Drawing.Size(698, 30);
            this.progressBar_down.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "下载进度:";
            // 
            // MutiThreadPubicResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar_down);
            this.Controls.Add(this.Btn_download);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Btn_Start);
            this.Name = "MutiThreadPubicResource";
            this.Text = "MutiThreadPubicResource";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Btn_download;
        private System.Windows.Forms.ProgressBar progressBar_down;
        private System.Windows.Forms.Label label1;
    }
}