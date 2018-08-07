using MVCLucene.Models;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCLucene
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //程序一启动的时候开启一线程【用来把队列中存储的错误存入日志文件】
            string LogFilePath = Server.MapPath("/Log/");
            string LogFileName =$"{DateTime.Now.ToString("yyyyMMdd")}.log";
            CancellationToken cancellationToken = new CancellationToken();
            TaskFactory taskFactory = new TaskFactory(cancellationToken);
            Action<object> action = a => {
                while (true)
                {
                   
                    if (ExceptionAttribute.exceptionsQueue.Count>0) //当队列里有错误日志
                    {
                        File.AppendAllText(a + LogFileName, ExceptionAttribute.exceptionsQueue.Dequeue().Message);
                    }
                    else
                    {
                        Thread.Sleep(5000);//没有错误 休息省CPU资源
                    }

                }

            };
            taskFactory.StartNew(action, LogFilePath);


        }
    }
}
