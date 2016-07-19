

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Cstomization
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Cstomization()
        { 
        }

        #region 受保护的字段
        protected int id;
        protected int jK_Customization_Type_Id;
        protected string jK_Customization_Type;
        protected DateTime? jK_Cstomization_DateTime;
        protected int jK_Cstomization_Member_Id;
        protected int jK_Cstomization_Number;
        protected string jK_Cstomization_Context;
        protected string jK_Cstomziation_Name;
        protected string jK_Cstomzatio_Phone;
        protected string jK_Cstomation_Date;
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
        ///  字段说明：JK_Customization_Type_Id
        /// </summary>
        public int JK_Customization_Type_Id
        {
            set { jK_Customization_Type_Id = value; }
            get { return jK_Customization_Type_Id; }
        }
        /// <summary>
        ///  字段说明：JK_Customization_Type
        /// </summary>
        public string JK_Customization_Type
        {
            set { jK_Customization_Type = value; }
            get { return jK_Customization_Type; }
        }
        /// <summary>
        ///  字段说明：JK_Cstomization_DateTime
        /// </summary>
        public DateTime? JK_Cstomization_DateTime
        {
            set { jK_Cstomization_DateTime = value; }
            get { return jK_Cstomization_DateTime; }
        }
        /// <summary>
        ///  字段说明：JK_Cstomization_Member_Id
        /// </summary>
        public int JK_Cstomization_Member_Id
        {
            set { jK_Cstomization_Member_Id = value; }
            get { return jK_Cstomization_Member_Id; }
        }
        /// <summary>
        ///  字段说明：定制人数
        /// </summary>
        public int JK_Cstomization_Number
        {
            set { jK_Cstomization_Number = value; }
            get { return jK_Cstomization_Number; }
        }
        /// <summary>
        ///  字段说明：定制内容
        /// </summary>
        public string JK_Cstomization_Context
        {
            set { jK_Cstomization_Context = value; }
            get { return jK_Cstomization_Context; }
        }
        /// <summary>
        ///  字段说明：JK_Cstomziation_Name
        /// </summary>
        public string JK_Cstomziation_Name
        {
            set { jK_Cstomziation_Name = value; }
            get { return jK_Cstomziation_Name; }
        }
        /// <summary>
        ///  字段说明：JK_Cstomzatio_Phone
        /// </summary>
        public string JK_Cstomzatio_Phone
        {
            set { jK_Cstomzatio_Phone = value; }
            get { return jK_Cstomzatio_Phone; }
        }
        /// <summary>
        ///  字段说明：JK_Cstomation_Date
        /// </summary>
        public string JK_Cstomation_Date
        {
            set { jK_Cstomation_Date = value; }
            get { return jK_Cstomation_Date; }
        }
        #endregion


    }
}

