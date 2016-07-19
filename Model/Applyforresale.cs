

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Applyforresale
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Applyforresale()
        { 
        }

        #region 受保护的字段
        protected int id;
        protected string jK_Applyforresale;
        protected DateTime? jK_Applyforresale_DateTime;
        protected int jK_Applyforresale_Member_Id;
        protected string jK_Applforresale_Member_name;
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
        ///  字段说明：JK_Applyforresale
        /// </summary>
        public string JK_Applyforresale
        {
            set { jK_Applyforresale = value; }
            get { return jK_Applyforresale; }
        }
        /// <summary>
        ///  字段说明：JK_Applyforresale_DateTime
        /// </summary>
        public DateTime? JK_Applyforresale_DateTime
        {
            set { jK_Applyforresale_DateTime = value; }
            get { return jK_Applyforresale_DateTime; }
        }
        /// <summary>
        ///  字段说明：转售关联id
        /// </summary>
        public int JK_Applyforresale_Member_Id
        {
            set { jK_Applyforresale_Member_Id = value; }
            get { return jK_Applyforresale_Member_Id; }
        }
        /// <summary>
        ///  字段说明：JK_Applforresale_Member_name
        /// </summary>
        public string JK_Applforresale_Member_name
        {
            set { jK_Applforresale_Member_name = value; }
            get { return jK_Applforresale_Member_name; }
        }
        #endregion


    }
}

