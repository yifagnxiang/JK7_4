using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JK7_4.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnException(ExceptionContext filterContext)
        {
            // 此处进行异常记录，可以记录到数据库或文本，也可以使用其他日志记录组件。
            // 通过filterContext.Exception来获取这个异常。
            string filePath = @"D:\Temp\Exceptions.txt";
            StreamWriter sw = System.IO.File.AppendText(filePath);
            string msg = filterContext.Exception.Source;
            string msg2 = filterContext.Exception.TargetSite.Name;
              
            sw.Write(msg+"_"+msg2+"_"+ filterContext.Exception.Message+""+DateTime.Now+"");
            sw.Close();
            // 执行基类中的OnException
            base.OnException(filterContext);
        } 

       }
}