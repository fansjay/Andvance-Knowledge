namespace Delegate
{
    partial class DelegateForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.Btn_ChangeProgress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(462, 25);
            this.progressBar1.TabIndex = 0;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(3, 44);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(462, 23);
            this.progressBar2.TabIndex = 1;
            // 
            // Btn_ChangeProgress
            // 
            this.Btn_ChangeProgress.Location = new System.Drawing.Point(713, 415);
            this.Btn_ChangeProgress.Name = "Btn_ChangeProgress";
            this.Btn_ChangeProgress.Size = new System.Drawing.Size(75, 23);
            this.Btn_ChangeProgress.TabIndex = 2;
            this.Btn_ChangeProgress.Text = "改变进度";
            this.Btn_ChangeProgress.UseVisualStyleBackColor = true;
            this.Btn_ChangeProgress.Click += new System.EventHandler(this.Btn_ChangeProgress_Click);
            // 
            // DelegateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_ChangeProgress);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Name = "DelegateForm";
            this.Text = "委托的应用";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button Btn_ChangeProgress;
    }
}

