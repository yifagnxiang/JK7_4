using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace JK7_4.Controllers
{
    public class AppointmentController : Controller
    {

        private string msg, jk_name ,str= "";
        private int id;
        /// <summary>
       /// 预约产品
       /// </summary>
       /// <returns></returns>
        public ActionResult Index()
        {
            string str = string.Format("");
            IList<Model.Product> produrct = BLL.Product.SelectList(0,"");

            return View(produrct);
        }
        public PartialViewResult Partial()
        {
            return PartialView();
                
        }

        #region 预约产品详细列表信息
        /// <summary>
        /// 预约产品详细列表信息
        /// </summary>
        /// <returns>返回一个对象</returns>
        public ActionResult Listappointment()
        {
            id =Convert.ToInt32( Library_public.Tool.GetSafeSqlandHtml( Request.QueryString["id"]));
            string str="id="+id+"";
            IList<Model.Product> product = BLL.Product.SelectList(0,str);
            //ViewBag.id=id;
            return View(product);
        }
        #endregion

        #region  产品添加
        /// <summary>
        /// 产品添加
        /// </summary>
        /// <returns>返回一个实体对象</returns>
        public ActionResult Product()
        {
            return View();
        }

        [HttpPost]
        public ActionResult post_product(HttpPostedFileBase fileData)
        {
            HttpFileCollectionBase files = Request.Files;
            fileData = files["file"];
            string title, bewrite, select_option_type, file_img, price, number, date, pointOfDeparture = "";
            select_option_type = Library_public.Tool.GetSafeSqlandHtml(Request["select_option_type"]);
            title = Library_public.Tool.GetSafeSqlandHtml(Request["title"]);
            bewrite = Library_public.Tool.GetSafeSqlandHtml(Request["content"]);
            file_img = Library_public.Tool.GetSafeSqlandHtml(Request["file_img"]);
            price = Library_public.Tool.GetSafeSqlandHtml(Request["price"]);
            number = Library_public.Tool.GetSafeSqlandHtml(Request["number"]);
            date = Library_public.Tool.GetSafeSqlandHtml(Request["date"]);
            pointOfDeparture = Library_public.Tool.GetSafeSqlandHtml(Request["pointOfDeparture"]);
            // 文件上传后的保存路径
            string filePath = Server.MapPath("~/Upload/");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            if (fileData == null)
            {
                return Redirect("Product");
            }
            string fileName = Path.GetFileName(fileData.FileName);// 原始文件名称
            string fileExtension = Path.GetExtension(fileName); // 文件扩展名
            string saveName = Guid.NewGuid().ToString() + fileExtension; // 保存文件名称
            fileData.SaveAs(filePath + saveName);

            Model.Product product = new Model.Product { JK_Product_DateTime = DateTime.Now, JK_Product_Imgsrc = saveName, JK_Product_parameten_1 = title, JK_Product_Bewrite = bewrite, };
            BLL.Product.Add(product);
            if (BLL.Product.Add(product) >= 1)
            {
                return Content("添加成功！");
            }
           
            return Redirect("Product");

        }
        #endregion

        #region 预约添加
        /// <summary>
        /// 预约添加
        /// </summary>
        /// <returns>返回json结果</returns>

        [HttpPost]
        public ActionResult add_product()
        {  
            id=Select_Member_id();
            string name, img_src, date, bewrite = "";
            name=Request["name"];
            img_src=Request["img"];
            date = Request["datetime"];
            bewrite=Request["bewrite"];
            Model.Product_Info product_info = new Model.Product_Info() { Jk_DateTime = DateTime.Now, JK_Product_datetime = Convert.ToDateTime(date.ToString()), JK_Product_name = name, JK_Product_img_src = img_src, JK_Titile = bewrite,JK_Product_id=id };
            if(BLL.Product_Info.Add(product_info)>=1)
            {
                msg="Success";
                return  Json(msg, JsonRequestBehavior.AllowGet);
            }
            msg = "Defeated";
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

        #region 我的预约信息
        public ActionResult my_product_info(int? page)
        {
           
            id = Select_Member_id();
            str = "JK_Product_id="+id+"";
           IList<Model.Product_Info> product_info= BLL.Product_Info.SelectList(0, str);
            
            //DataSet dt = BLL.Product_Info.GetProduct_InfoList(pager, 3, "Jk_DateTime desc", str, out total);
            PagedList<Model.Product_Info> product_info_1 =product_info.ToPagedList(page??1,2); //new PagedList<System.Data.DataRow>(dt.Tables[0].Select(), pager, 3, total);

            return View(product_info_1);
        }
        #endregion
    }
}
