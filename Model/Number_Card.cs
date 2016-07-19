

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Number_Card
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Number_Card()
        { 
        }

        #region 受保护的字段
        protected int id;
        protected string jK_Number_Card;
        protected int jK_Number_Card_Id;
        protected DateTime? jK_NumberCard_DateTime;
        protected int jK_Number_Count;
        protected int jK_Member_id;
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
        ///  字段说明：激活卡号
        /// </summary>
        public string JK_Number_Card
        {
            set { jK_Number_Card = value; }
            get { return jK_Number_Card; }
        }
        /// <summary>
        ///  字段说明：卡号激活次数
        /// </summary>
        public int JK_Number_Card_Id
        {
            set { jK_Number_Card_Id = value; }
            get { return jK_Number_Card_Id; }
        }
        /// <summary>
        ///  字段说明：JK_NumberCard_DateTime
        /// </summary>
        public DateTime? JK_NumberCard_DateTime
        {
            set { jK_NumberCard_DateTime = value; }
            get { return jK_NumberCard_DateTime; }
        }
        /// <summary>
        ///  字段说明：JK_Number_Count
        /// </summary>
        public int JK_Number_Count
        {
            set { jK_Number_Count = value; }
            get { return jK_Number_Count; }
        }
        /// <summary>
        ///  字段说明：JK_Member_id
        /// </summary>
        public int JK_Member_id
        {
            set { jK_Member_id = value; }
            get { return jK_Member_id; }
        }
        #endregion


    }
}

