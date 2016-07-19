using Library_public;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace JK7_4.Controllers
{
    [HandleError]
    public class HomeController :BaseController
    {
       private string jk_name,str,msg ="";
       private int reuslt;
       private int id,count;
   
        public ActionResult Index()
        {
            //if (Session["name"] == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            
            return View();
        }
        #region 个人中心-预约页面
        /// <summary>
        /// 个人中心-预约页面
        /// </summary>
        /// <returns></returns>
        public ActionResult book_page()
        {
            return View();
        }
        #endregion

        #region 定制服务
        /// <summary>
        /// 定制服务
        /// </summary>
        /// <returns></returns>
        public ActionResult goods_center()
        {
            return View();
        }
        #endregion

        #region 定制信息填写列表
        /// <summary>
        /// 定制信息填写列表
        /// </summary>
        /// <returns></returns>
        public ActionResult make()
        {
            return View(); 
        }
        /// <summary>
        /// 定制信息填写列表
        /// </summary>
        /// <returns></returns>
        public JsonResult post_make()
        {
            jk_name = Gain_Session_Name();
            str = "JK_Name='" + jk_name + "'";
            id = BLL.Member.Select_Id(str);

            string name, phone, theme ,time= "";
            int number;
            name=Tool.GetSafeSqlandHtml( Request["name"]);
            phone =Tool.GetSafeSqlandHtml( Request["phone"]);
            theme =Tool.GetSafeSqlandHtml(  Request["time"]);
            time = Tool.GetSafeSqlandHtml( Request["theme"]);
            number =Convert.ToInt32( Tool.GetSafeSqlandHtml( Request["number"]));
            Model.Cstomization cstomization = new Model.Cstomization() {JK_Cstomation_Date=time,JK_Cstomization_DateTime=DateTime.Now,JK_Cstomization_Context=theme,JK_Cstomization_Number=number,JK_Cstomzatio_Phone=phone,JK_Cstomziation_Name=name,JK_Cstomization_Member_Id=id };
            reuslt = BLL.Cstomization.Add(cstomization);
            if (reuslt>=1)
            {
                msg="Success";
                return Json(msg);
            }
            msg = "Defeated";
            
            return Json(msg);
        }

        #endregion

        #region 预约和定制
        /// <summary>
        /// 预约和定制
        /// </summary>
        /// <returns></returns>
        public ActionResult personal_center()
        {
            return View();        
        }
        #endregion

        #region 列表信息

        /// <summary>
        /// 列表信息
        /// </summary>
        /// <returns></returns>
        public ActionResult list()
        {


            return View();
        }
        #endregion

        #region 定制信息
        /// <summary>
        ///定制信息提交
        /// </summary>
        /// <returns></returns>
        public ActionResult Post_list()
        {
            id=Select_Member_id();
            string name, content, phone,date,msg = "" ;
            int number;
            int result;
           
            name=Tool.GetSafeSqlandHtml( Request["name"]);
            content =Tool.GetSafeSqlandHtml(  Request["content"]);
            phone = Tool.GetSafeSqlandHtml( Request["phone"]);
            date =Tool.GetSafeSqlandHtml(  Request["datatime"]);
            number =Convert.ToInt32( Tool.GetSafeSqlandHtml( Request["number"]));
            Model.Cstomization cstomization = new Model.Cstomization(){JK_Cstomziation_Name=name,JK_Cstomzatio_Phone=phone,JK_Cstomization_DateTime=DateTime.Now,JK_Cstomization_Number=number,JK_Cstomization_Member_Id=id,JK_Cstomation_Date=date};
            result=  BLL.Cstomization.Add(cstomization);
            if (result>=1)
            {
                msg = "Success";
                return Json(msg);
            }
            msg = "Defeated";
            return Json(msg);
        }
        #endregion
      
        #region 预约
        /// <summary>
        /// 预约
        /// </summary>
        /// <returns>预约列表</returns>

        public ActionResult Appointment()
        {
            return View();
        }
#endregion

        #region 激活卡号
        /// <summary>
        /// 激活卡号
        /// </summary>
        /// <returns>返回到视图</returns>

        public ActionResult Activate()
        {
          
            return View();
        }
        /// <summary>
        /// 激活卡号
        /// </summary>
        /// <returns>返回到视图</returns>

        public ActionResult Post_Activate()
        {
            string number_card=Request["number_card"];
            int select_option=Convert.ToInt32(Request["select_option"]);
            str = "JK_Number_Card='" + number_card + "' and JK_Number_Card_Id=" + select_option + "";
            reuslt = BLL.Number_Card.RecorCount(str);
            string str2 = "(jk_number_card='"+number_card+"' and JK_Number_Card_Id='"+select_option+"') and JK_Number_Count=1";
            int reuslt_count = BLL.Number_Card.RecorCount(str2);
            id = Select_Member_id();
            if (reuslt_count == 1)
            {
                msg = "Activate";
                return Json(msg,JsonRequestBehavior.AllowGet);   
            }
            else
            {
                if (reuslt.Equals(0))
                {
                    msg = "D";
                    return Json(msg, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    str = "JK_Number_Card='" + number_card + "'";
                    int number_card_id = BLL.Number_Card.Select_Id(str);
                    Model.Number_Card number = new Model.Number_Card() { JK_Number_Count = 1,JK_Number_Card=number_card,JK_Number_Card_Id=select_option, Id = number_card_id ,JK_NumberCard_DateTime=DateTime.Now,JK_Member_id=id };
                    reuslt=  BLL.Number_Card.Update(number);
                    
                    if (reuslt>=1)
                    {
                         msg = "Success";
                         return Json(msg, JsonRequestBehavior.AllowGet);
                    }
                    msg = "Defeatef";
                }
               
            }
           
            return Json(msg,JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 定制信息列表
        /// <summary>
        /// 定制信息列表
        /// </summary>
        /// <returns></returns>
        public ActionResult My_Cstomizaton_info()
        {

            jk_name = Gain_Session_Name();
          
            str = "JK_Name='" + jk_name + "'";
            id = BLL.Member.Select_Id(str);

            str=" JK_Cstomization_Member_Id='"+id+"'";

            IList<Model.Cstomization> ct= BLL.Cstomization.SelectList(0,str);
          
            return View(ct);
        }

        #endregion

        #region 会员是否激活
        public ActionResult Rt()
        {
            str = "jk_number_count=1 and jk_Member_id='" + Select_Member_id() + "'";
            count = BLL.Number_Card.RecorCount(str);
            if (count == 1)
            {
                return Json(msg = "C", JsonRequestBehavior.AllowGet);
            }
            msg = "0";
            return Json(msg,JsonRequestBehavior.AllowGet);
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

