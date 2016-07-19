using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_public;
using System.IO;
namespace JK7_4.Controllers
{
    public class LoginController : Controller
    {
       private string name, password, jk_name = "";
       private string msg,str = "";
       private int reuslt,count,id ;

        public ActionResult Index()
        {
          
            if (Request.Cookies["name"] != null  && Request.Cookies["password"]!=null)
            {
                var s = Request.Cookies["name"].Value.ToString();
                Session["name"]=s;
                using (StreamReader sr = new StreamReader(Server.MapPath("test.html")))
                {
                    String htmlContent = sr.ReadToEnd();
                    return Content(htmlContent);
                }

                 
            }
            return View();
            
        }
        #region 登陆
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns>成功或失败返回json信息</returns>
        public ActionResult Login()
        {
          name=Tool.GetSafeSqlandHtml( Request["name"]);
          password=Tool.GetSafeSqlandHtml( Request["password"]);
           str = string.Format("JK_Name='{0}' and JK_Password='{1}' ",name,password);
          int resutl=  BLL.Member.RecorCount(str);
          if (resutl==1)
          {
              HttpCookie h_cookie = new HttpCookie("name");
              h_cookie.Expires = DateTime.Now.AddDays(50);
              h_cookie.Value=name;
              HttpCookie h_cookie2 = new HttpCookie("password");
              h_cookie2.Expires = DateTime.Now.AddDays(50);
              h_cookie2.Value = password;
              Response.Cookies.Add(h_cookie);
              Response.Cookies.Add(h_cookie2);
              
              Session["name"] = name;
              str = "jk_number_count=1 and jk_Member_id='" + Select_Member_id() + "'";
              count = BLL.Number_Card.RecorCount(str);
              if (count==1)
              {
                  return Json(msg = "C", JsonRequestBehavior.AllowGet);
              }
              return Json(msg="Success",JsonRequestBehavior.AllowGet);
          }
          return Json(msg = "Defeated", JsonRequestBehavior.AllowGet);
        }

#endregion

        #region 获取Member id
        private int Select_Member_id()
        {
            jk_name = Gain_Session_Name();
            str = "JK_Name='" + jk_name + "'";
            return id = BLL.Member.Select_Id(str);
        }
        private string Gain_Session_Name()
        {
            return jk_name = Session["name"].ToString();
        }
        #endregion
    }
}
