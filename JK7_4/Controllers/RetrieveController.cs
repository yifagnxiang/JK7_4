using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JK7_4.Controllers
{
    public class RetrieveController : Controller
    {

        private string jk_name, str, msg = "";
        private int reuslt,id;
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Retrieve()
        {
            return View();
        }

        #region 激活卡号
        /// <summary>
        /// 激活卡号
        /// </summary>
        /// <returns>返回Jons数据到页面处理</returns>

        public JsonResult Post_Activate()
        {
            id = Select_Member_id();
            string number_card =Library_public.Tool.GetSafeSqlandHtml( Request["activenumber"]);
            int select_option = Convert.ToInt32(Library_public.Tool.GetSafeSqlandHtml( Request["select_option"]));
            str = "JK_Number_Card='" + number_card + "' and JK_Number_Card_Id=" + select_option + " ";
            reuslt = BLL.Number_Card.RecorCount(str);
            string str2 = "JK_Number_Card='" + number_card + "' and JK_Number_Count=1 or JK_Member_id=" + id + "";
            int reuslt_count = BLL.Number_Card.RecorCount(str2);
            
            if (reuslt_count >= 1)
            {
                msg = "Activate";
                return Json(msg);
            }
            else
            {
                if (reuslt.Equals(0))
                {
                    msg = "D";
                    return Json(msg);
                }
                else
                {
                    str = "JK_Number_Card='" + number_card + "'";
                    int number_card_id = BLL.Number_Card.Select_Id(str);
                    Model.Number_Card number = new Model.Number_Card() { JK_Number_Count = 1, JK_Number_Card = number_card, JK_Number_Card_Id = select_option, Id = number_card_id, JK_NumberCard_DateTime = DateTime.Now, JK_Member_id = id };
                    reuslt = BLL.Number_Card.Update(number);

                    if (reuslt >= 1)
                    {
                        msg = "Success";
                        return Json(msg);
                    }
                    msg = "Defeatef";
                }

            }

            return Json(msg);
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
