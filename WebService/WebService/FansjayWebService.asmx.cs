using System.Web.Services;
using WebService.Models;

namespace WebService.WebService
{
    /// <summary>
    /// FansjayWebService 的摘要说明 
    /// 
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本【也就是javascript脚本】中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]

    //要想使用WebService只需要有一个类继承自System.Web.Services.WebService即可
    public class FansjayWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod] //一定要加这个WebMethod才可以
        public int plus(int a,int b)
        {
            return a + b;
        }

        [WebMethod]
        public User GetUser()
        {
            return new User { ID = 1, Username = "FansjayWebService", age = 25 };
        }
    }


}
