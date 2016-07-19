

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Appointment
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Appointment()
        { 
        }

        #region 受保护的字段
        protected int id;
        protected int jK_Appointment_Number;
        protected int jK_Appointment_Member_id;
        protected string jK_Appointment_Datetime;
        protected DateTime? jK_DateTime;
        protected string jK_Appointment_Context;
        protected string jK_Appointment_Phone;
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
        ///  字段说明：预约人数
        /// </summary>
        public int JK_Appointment_Number
        {
            set { jK_Appointment_Number = value; }
            get { return jK_Appointment_Number; }
        }
        /// <summary>
        ///  字段说明：预约表和用户名id关联
        /// </summary>
        public int JK_Appointment_Member_id
        {
            set { jK_Appointment_Member_id = value; }
            get { return jK_Appointment_Member_id; }
        }
        /// <summary>
        ///  字段说明：预约时间
        /// </summary>
        public string JK_Appointment_Datetime
        {
            set { jK_Appointment_Datetime = value; }
            get { return jK_Appointment_Datetime; }
        }
        /// <summary>
        ///  字段说明：当前时间
        /// </summary>
        public DateTime? JK_DateTime
        {
            set { jK_DateTime = value; }
            get { return jK_DateTime; }
        }
        /// <summary>
        ///  字段说明：预约内容
        /// </summary>
        public string JK_Appointment_Context
        {
            set { jK_Appointment_Context = value; }
            get { return jK_Appointment_Context; }
        }
        /// <summary>
        ///  字段说明：预约联系手机号码
        /// </summary>
        public string JK_Appointment_Phone
        {
            set { jK_Appointment_Phone = value; }
            get { return jK_Appointment_Phone; }
        }
        #endregion


    }
}

