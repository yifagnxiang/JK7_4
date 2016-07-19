using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JK7_4.Controllers
{
    public class RegisterController : Controller
    {
        private int reuslt;
        public ActionResult Index()
        {
            return View();
        }
        #region 注册
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns>成功、失败返回Json到页面处理</returns>
        public ActionResult Register()
        {
            string msg = "";
            string name, password, phone = "";
            //int leve;
            name =Library_public.Tool.GetSafeSqlandHtml(Request["name"]);
            password = Library_public.Tool.GetSafeSqlandHtml(Request["password"]);
            phone = Library_public.Tool.GetSafeSqlandHtml(Request["phone"]);
            //leve = Convert.ToInt32(Request["option"].ToString());
            string str = string.Format("JK_Name='{0}'",name);
            reuslt= BLL.Member.RecorCount(str);
            if (reuslt==1)
            {
                return Json(msg="Exist");
            }
            Model.Member member = new Model.Member() { JK_Name = name, JK_Password = password, JK_Phone = phone,  JK_Datetime = DateTime.Now };
             reuslt = BLL.Member.Add(member);
            if (reuslt >= 1)
            {
                msg = "Success";
                return Json(msg);
            }
            msg = "Defeated";
            return Json(msg);
        }
        #endregion
    }
}
