using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebWCFService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class FansjayService : IFansjayService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Student GetStudent()
        {
            return new Student { ID = 1, Username = "学生Fansjay", Major = "Programer、English" };
        }

        public User GetUser()
        {
            return new User { ID = 1, Username = "Fansjay"};
        }

        public int Plus(int a, int b)
        {
           
            return a + b;
        }
    }
}
