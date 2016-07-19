

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Product_Info
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Product_Info()
        { 
        }

        #region 受保护的字段
        protected int id;
        protected string jK_Titile;
        protected DateTime? jk_DateTime;
        protected int jK_Product_id;
        protected string jK_Product_img_src;
        protected string jK_Product_name;
        protected DateTime? jK_Product_datetime;
        #endregion


        #region 共有属性
        /// <summary>
        ///  字段说明：Id
        /// </summary>
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        ///  字段说明：JK_Titile
        /// </summary>
        public string JK_Titile
        {
            set { jK_Titile = value; }
            get { return jK_Titile; }
        }
        /// <summary>
        ///  字段说明：jk_DateTime
        /// </summary>
        public DateTime? Jk_DateTime
        {
            set { jk_DateTime = value; }
            get { return jk_DateTime; }
        }
        /// <summary>
        ///  字段说明：JK_Product_id
        /// </summary>
        public int JK_Product_id
        {
            set { jK_Product_id = value; }
            get { return jK_Product_id; }
        }
        /// <summary>
        ///  字段说明：JK_Product_img_src
        /// </summary>
        public string JK_Product_img_src
        {
            set { jK_Product_img_src = value; }
            get { return jK_Product_img_src; }
        }
        /// <summary>
        ///  字段说明：JK_Product_name
        /// </summary>
        public string JK_Product_name
        {
            set { jK_Product_name = value; }
            get { return jK_Product_name; }
        }
        /// <summary>
        ///  字段说明：JK_Product_datetime
        /// </summary>
        public DateTime? JK_Product_datetime
        {
            set { jK_Product_datetime = value; }
            get { return jK_Product_datetime; }
        }
        #endregion


    }
}

