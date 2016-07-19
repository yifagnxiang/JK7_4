

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Product
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Product()
        { 
        }

        #region 受保护的字段
        protected int id;
        protected string jK_Product_Name;
        protected string jK_Product_Type;
        protected DateTime? jK_Product_DateTime;
        protected int jK_Product_Type_Id;
        protected decimal jK_Product_Price;
        protected string jK_Product_Imgsrc;
        protected string jK_Product_Bewrite;
        protected string jK_Product_parameten_1;
        protected string jK_Product_parameten_2;
        protected int jK_Product_parameten_3;
        protected int jK_Product_parameten_4;
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
        ///  字段说明：JK_Product_Name
        /// </summary>
        public string JK_Product_Name
        {
            set { jK_Product_Name = value; }
            get { return jK_Product_Name; }
        }
        /// <summary>
        ///  字段说明：JK_Product_Type
        /// </summary>
        public string JK_Product_Type
        {
            set { jK_Product_Type = value; }
            get { return jK_Product_Type; }
        }
        /// <summary>
        ///  字段说明：JK_Product_DateTime
        /// </summary>
        public DateTime? JK_Product_DateTime
        {
            set { jK_Product_DateTime = value; }
            get { return jK_Product_DateTime; }
        }
        /// <summary>
        ///  字段说明：JK_Product_Type_Id
        /// </summary>
        public int JK_Product_Type_Id
        {
            set { jK_Product_Type_Id = value; }
            get { return jK_Product_Type_Id; }
        }
        /// <summary>
        ///  字段说明：JK_Product_Price
        /// </summary>
        public decimal JK_Product_Price
        {
            set { jK_Product_Price = value; }
            get { return jK_Product_Price; }
        }
        /// <summary>
        ///  字段说明：JK_Product_Imgsrc
        /// </summary>
        public string JK_Product_Imgsrc
        {
            set { jK_Product_Imgsrc = value; }
            get { return jK_Product_Imgsrc; }
        }
        /// <summary>
        ///  字段说明：JK_Product_Bewrite
        /// </summary>
        public string JK_Product_Bewrite
        {
            set { jK_Product_Bewrite = value; }
            get { return jK_Product_Bewrite; }
        }
        /// <summary>
        ///  字段说明：JK_Product_parameten_1
        /// </summary>
        public string JK_Product_parameten_1
        {
            set { jK_Product_parameten_1 = value; }
            get { return jK_Product_parameten_1; }
        }
        /// <summary>
        ///  字段说明：JK_Product_parameten_2
        /// </summary>
        public string JK_Product_parameten_2
        {
            set { jK_Product_parameten_2 = value; }
            get { return jK_Product_parameten_2; }
        }
        /// <summary>
        ///  字段说明：JK_Product_parameten_3
        /// </summary>
        public int JK_Product_parameten_3
        {
            set { jK_Product_parameten_3 = value; }
            get { return jK_Product_parameten_3; }
        }
        /// <summary>
        ///  字段说明：JK_Product_parameten_4
        /// </summary>
        public int JK_Product_parameten_4
        {
            set { jK_Product_parameten_4 = value; }
            get { return jK_Product_parameten_4; }
        }
        #endregion


    }
}

