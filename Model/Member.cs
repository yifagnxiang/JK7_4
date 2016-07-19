

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Member
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Member()
        { 
        }

        #region 受保护的字段
        protected int id;
        protected string jK_Name;
        protected string jK_Password;
        protected int jK_Leve;
        protected string jK_City;
        protected string jK_Sex;
        protected string jK_Phone;
        protected DateTime? jK_Datetime;
        protected int jK_Id;
        protected int jK_Jurisdiction;
        protected string jK_Activate;
        protected int jK_Number_Card_Id;
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
        ///  字段说明：JK_Name
        /// </summary>
        public string JK_Name
        {
            set { jK_Name = value; }
            get { return jK_Name; }
        }
        /// <summary>
        ///  字段说明：JK_Password
        /// </summary>
        public string JK_Password
        {
            set { jK_Password = value; }
            get { return jK_Password; }
        }
        /// <summary>
        ///  字段说明：等级id关联
        /// </summary>
        public int JK_Leve
        {
            set { jK_Leve = value; }
            get { return jK_Leve; }
        }
        /// <summary>
        ///  字段说明：JK_City
        /// </summary>
        public string JK_City
        {
            set { jK_City = value; }
            get { return jK_City; }
        }
        /// <summary>
        ///  字段说明：JK_Sex
        /// </summary>
        public string JK_Sex
        {
            set { jK_Sex = value; }
            get { return jK_Sex; }
        }
        /// <summary>
        ///  字段说明：JK_Phone
        /// </summary>
        public string JK_Phone
        {
            set { jK_Phone = value; }
            get { return jK_Phone; }
        }
        /// <summary>
        ///  字段说明：JK_Datetime
        /// </summary>
        public DateTime? JK_Datetime
        {
            set { jK_Datetime = value; }
            get { return jK_Datetime; }
        }
        /// <summary>
        ///  字段说明：JK_Id
        /// </summary>
        public int JK_Id
        {
            set { jK_Id = value; }
            get { return jK_Id; }
        }
        /// <summary>
        ///  字段说明：权限
        /// </summary>
        public int JK_Jurisdiction
        {
            set { jK_Jurisdiction = value; }
            get { return jK_Jurisdiction; }
        }
        /// <summary>
        ///  字段说明：激活会员类型id
        /// </summary>
        public string JK_Activate
        {
            set { jK_Activate = value; }
            get { return jK_Activate; }
        }
        /// <summary>
        ///  字段说明：JK_Number_Card_Id
        /// </summary>
        public int JK_Number_Card_Id
        {
            set { jK_Number_Card_Id = value; }
            get { return jK_Number_Card_Id; }
        }
        #endregion


    }
}

