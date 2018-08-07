using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLucene.Models
{
    public class ExceptionAttribute: HandleErrorAttribute
    {

        public static Queue<Exception> exceptionsQueue = new Queue<Exception>();
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            exceptionsQueue.Enqueue(filterContext.Exception);//把异常消息放入队列
            filterContext.HttpContext.Response.Redirect("/Error.html");
        }
    }
}