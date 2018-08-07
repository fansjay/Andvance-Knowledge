using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceDemo
{
    public partial class FansjaywindowsService : ServiceBase
    {
        FileStream fileStream = File.Create("log.log");
        public FansjaywindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //添加我们的逻辑代码
            try
            {

                var bytes = Encoding.Default.GetBytes($"开始时间：{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}");
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Flush();
               
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                fileStream.Close();
            }
           

        }

        protected override void OnStop()
        {
            //添加我们的逻辑代码
            try
            {
                var bytes = Encoding.Default.GetBytes($"结束时间：{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}");
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Flush();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
