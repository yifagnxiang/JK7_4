

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;//请先添加引用 

namespace DAL
{
    public partial  class Member
    {
        #region 查询是否存在该记录(根据关键字或者条件语句,但是条件语句优先)
        /// <summary>
        /// 查询是否存在该记录
        /// </summary>
        /// <param name="id">关键字</param>
        /// <param name="strWhere">条件语句</param>
        /// <returns></returns>
        public bool Exists(int id,string strWhere)
        {
            StringBuilder strSql= new StringBuilder();
            strSql.Append(@"Select Count(*) from [Member]");
            if(strWhere.Trim () !="")
               { 
                 strSql.Append(@" where "+strWhere);
                 int retrunValue =int.Parse(DAL.SqlDataHelper.GetScalar(strSql.ToString()).ToString ());
                 if (retrunValue > 0)
                   return true;
                 else return false;
               } 
            else 
               { 
                  strSql.Append(@" where [Id]=@id");
                  SqlParameter[] parameters =new SqlParameter []{ 
                                             new SqlParameter("@id",SqlDbType.Int,4)
                                          };
                  parameters[0].Value = id;
                  int retrunValue =int.Parse(DAL.SqlDataHelper.GetScalar(strSql.ToString(),parameters).ToString ());
                  if (retrunValue > 0)
                      return true;
                  else return false;
               } 
        } 
        #endregion

        #region 统计数量
        /// <summary>统计数量
        /// 
        /// </summary>
        /// <param name="strWhere">条件语句</param>
        /// <returns></returns>
        public int RecorCount(string strWhere)
        {
            StringBuilder strSql= new StringBuilder();
            int retrunValue =0;
            strSql.Append(@"Select Count(*) from [Member]");
            if(strWhere.Trim () !="")
               {
                 strSql.Append(@" where "+strWhere);
                 retrunValue =int.Parse(DAL.SqlDataHelper.GetScalar(strSql.ToString()).ToString ());
               }
               return retrunValue;
        }
        #endregion

        #region 查询id
        /// <summary>查询id
        /// 
        /// </summary>
        /// <param name="strWhere">条件语句</param>
        /// <returns></returns>
        public int Select_Id(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            int retrunValue = 0;
            strSql.Append(@"Select id from [Member]");
            if (strWhere.Trim() != "")
            {
                strSql.Append(@" where " + strWhere);
                retrunValue = int.Parse(DAL.SqlDataHelper.GetScalar(strSql.ToString

()).ToString());
            }
            return retrunValue;
        }
        #endregion

        #region 删除一条记录
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id">关键字</param>
        /// <returns>删除结果</returns>
        public int Del(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"delete [Member] where [Id]='" + id + "'");
            return DAL.SqlDataHelper.ExecuteCommand(strSql.ToString());
        }
        #endregion

        #region 获得单个实体对象
        /// <summary>
        /// 获得单个实体对象
        /// </summary>
        /// <param name="id">关键字</param>
        /// <returns>实体对象</returns>
        public Model.Member  SelectModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select [Id],[JK_Name],[JK_Password],[JK_Leve],[JK_City],[JK_Sex],[JK_Phone],[JK_Datetime],[JK_Id],[JK_Jurisdiction],[JK_Activate],[JK_Number_Card_Id] from [Member] ");
            strSql.Append(@" where [Id]=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            Model.Member model = new Model.Member();
            DataTable dt = DAL.SqlDataHelper.GetDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                LoadEntityData(ref model, dt.Rows[0]);
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 获得单个实体对象
        /// <summary>
        /// 获得单个实体对象
        /// </summary>
        /// <param name="whereStr">关键字</param>
        /// <returns>实体对象</returns>
        public Model.Member  SelectModel(string whereStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select [Id],[JK_Name],[JK_Password],[JK_Leve],[JK_City],[JK_Sex],[JK_Phone],[JK_Datetime],[JK_Id],[JK_Jurisdiction],[JK_Activate],[JK_Number_Card_Id] from [Member] ");
            if (whereStr.Trim() != "")
            {
                strSql.Append(@" where " + whereStr);
            }
            Model.Member model = new Model.Member();
            DataTable dt = DAL.SqlDataHelper.GetDataTable(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                LoadEntityData(ref model, dt.Rows[0]);
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 根据条件查询实体记录
        /// <summary>
        /// 根据条件查询实体记录
        /// </summary>
        /// <param name="whereStr">查询条件</param>
        /// <returns>实体记录</returns>
        public IList<Model.Member> SelectList(int top,string whereStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select "); 
            if(top>0)
            {
               strSql.Append(" top "+top);
            }
            strSql.Append(" [Id],[JK_Name],[JK_Password],[JK_Leve],[JK_City],[JK_Sex],[JK_Phone],[JK_Datetime],[JK_Id],[JK_Jurisdiction],[JK_Activate],[JK_Number_Card_Id] from [Member] ");
            if (whereStr.Trim() != "")
            {
                strSql.Append(@" where " + whereStr);
            }
            DataTable dt = DAL.SqlDataHelper.GetDataTable(strSql.ToString());
            List<Model.Member > list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Model.Member >();
                Model.Member  model = null;
                
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Model.Member ();
                    LoadEntityData(ref model, dr);
                    list.Add(model);
                }
            }
            return list;
        }

        #endregion

        #region 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面显示的行数</param>
        /// <param name="pageCount">总行数</param>
        /// <returns>根据分页查询的数据</returns>
        public IList<Model.Member> SelectByPaged(int pageIndex,int pageSize,  string strWhere, string orderBy, out int pageCount)
        {
            string sql_count = "select COUNT(*) from [Member]";
            pageCount = int.Parse(SqlDataHelper.GetScalar(sql_count).ToString());
            StringBuilder strSql = new StringBuilder();
            int numStart = pageSize * (pageIndex - 1) + 1;
            int numEnd = pageIndex * pageSize;
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                strSql.Append("order by " + orderBy);
            }
            else
            {
                strSql.Append("");
            }
            strSql.Append(")as Row, *  from  Member");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) as Temp");
            strSql.AppendFormat(" WHERE Row between {0} and {1}", numStart, numEnd);
            DataTable dt = new DataTable();
            dt = SqlDataHelper.GetDataTable(strSql.ToString());
            IList<Model.Member> list = new List<Model.Member>();
            LoadListData(ref list, dt);
            return list;
        } 
        #endregion

        #region 分页查询(存储过程)
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面显示的行数</param>
        /// <param name="tableName">表名</param>
        /// <param name="orderBy">排序</param>
        /// <param name="where">条件语句</param>
        /// <param name="pageCount">总行数</param>
        /// <returns>根据分页查询的数据</returns>
        public DataSet GetListByTableName(int pageIndex,int pageSize, string tableName,string orderBy, string where, out int pageCount)
        {
            SqlParameter count = new SqlParameter();
            count.ParameterName = "@rowcount";
            count.Direction = ParameterDirection.Output;
	        count.SqlDbType = SqlDbType.Int;
	        count.Size = 4;
	        SqlParameter[] parameters = {
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TableName", SqlDbType.VarChar,4000),
                new SqlParameter("@OrderBy", SqlDbType.VarChar,4000),
                new SqlParameter("@Where", SqlDbType.VarChar,4000),
                count
                };
            parameters[0].Value = pageIndex;
            parameters[1].Value = pageSize;
            parameters[2].Value = tableName;
            parameters[3].Value = orderBy;
            parameters[4].Value = where;
            DataSet ds = SqlDataHelper.RunProcedure("Pager", parameters, tableName);
            pageCount = Convert.ToInt16(parameters[5].Value);
            return ds;
        } 
        #endregion

        #region 分页查询(存储过程)
        /// <summary>
        /// 分页查询
        /// </summary>
        ///<param name="pageIndex">页号</param> 
        ///<param name="pageSize">页面显示的行数</param> 
        /// <param name="orderBy">排序</param>
        /// <param name="where">条件语句</param>
        /// <param name="pageCount">总行数</param>
        /// <returns>根据分页查询的数据</returns>
        public DataSet GetMemberList(int pageIndex,int pageSize, string orderBy, string where, out int pageCount)
        {
            SqlParameter count = new SqlParameter();
            count.ParameterName = "@rowcount";
            count.Direction = ParameterDirection.Output;
	        count.SqlDbType = SqlDbType.Int;
	        count.Size = 4;
	        SqlParameter[] parameters = {
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TableName", SqlDbType.VarChar,4000),
                new SqlParameter("@OrderBy", SqlDbType.VarChar,4000),
                new SqlParameter("@Where", SqlDbType.VarChar,4000),
                count
                };
            parameters[0].Value = pageIndex;
            parameters[1].Value = pageSize;
            parameters[2].Value = "[Member]";
            parameters[3].Value = orderBy;
            parameters[4].Value = where;
            DataSet ds = SqlDataHelper.RunProcedure("Pager", parameters, "Member");
            pageCount = Convert.ToInt32(parameters[5].Value);
            return ds;
        } 
        #endregion

        #region 往实体集合中添加记录
        /// <summary>
        /// 往实体集合中添加记录
        /// </summary>
        /// <param name="list">实体列表</param>
        /// <param name="dt">表</param>
        private void LoadListData(ref IList<Model.Member > list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Model.Member  model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Model.Member ();
                    LoadEntityData(ref model, dr);
                    list.Add(model);
                }
            }
        }
        #endregion

        #region 往实体中存放数据
        /// <summary>
        /// 往实体中存放数据
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <param name="dr">行记录</param>
        private void LoadEntityData(ref Model.Member  model, DataRow dr)
        {
           if (dr["Id"].ToString() != "") model.Id = int.Parse (dr["Id"].ToString());
           if (dr["JK_Name"].ToString() != "") model.JK_Name = dr["JK_Name"].ToString();
           if (dr["JK_Password"].ToString() != "") model.JK_Password = dr["JK_Password"].ToString();
           if (dr["JK_Leve"].ToString() != "") model.JK_Leve = int.Parse (dr["JK_Leve"].ToString());
           if (dr["JK_City"].ToString() != "") model.JK_City = dr["JK_City"].ToString();
           if (dr["JK_Sex"].ToString() != "") model.JK_Sex = dr["JK_Sex"].ToString();
           if (dr["JK_Phone"].ToString() != "") model.JK_Phone = dr["JK_Phone"].ToString();
           if (dr["JK_Datetime"].ToString() != "") model.JK_Datetime = DateTime.Parse (dr["JK_Datetime"].ToString());
           if (dr["JK_Id"].ToString() != "") model.JK_Id = int.Parse (dr["JK_Id"].ToString());
           if (dr["JK_Jurisdiction"].ToString() != "") model.JK_Jurisdiction = int.Parse (dr["JK_Jurisdiction"].ToString());
           if (dr["JK_Activate"].ToString() != "") model.JK_Activate = dr["JK_Activate"].ToString();
           if (dr["JK_Number_Card_Id"].ToString() != "") model.JK_Number_Card_Id = int.Parse (dr["JK_Number_Card_Id"].ToString());
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">要往数据库中的添加的实体对象</param>
        /// <returns>结果</returns>
        public int Add(Model.Member  model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"insert into [Member]( ");
                strSql.Append(@"[JK_Name],[JK_Password],[JK_Leve],[JK_City],[JK_Sex],[JK_Phone],[JK_Datetime],[JK_Id],[JK_Jurisdiction],[JK_Activate],[JK_Number_Card_Id]) values (@jK_Name,@jK_Password,@jK_Leve,@jK_City,@jK_Sex,@jK_Phone,@jK_Datetime,@jK_Id,@jK_Jurisdiction,@jK_Activate,@jK_Number_Card_Id)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@jK_Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@jK_Password", SqlDbType.NVarChar,50),
                    new SqlParameter("@jK_Leve", SqlDbType.Int,4),
                    new SqlParameter("@jK_City", SqlDbType.NVarChar,50),
                    new SqlParameter("@jK_Sex", SqlDbType.NChar,10),
                    new SqlParameter("@jK_Phone", SqlDbType.NVarChar,50),
                    new SqlParameter("@jK_Datetime", SqlDbType.DateTime,8),
                    new SqlParameter("@jK_Id", SqlDbType.Int,4),
                    new SqlParameter("@jK_Jurisdiction", SqlDbType.Int,4),
                    new SqlParameter("@jK_Activate", SqlDbType.NChar,10),
                    new SqlParameter("@jK_Number_Card_Id", SqlDbType.Int,4)
                    };
                parameters[0].Value = model.JK_Name;
                parameters[1].Value = model.JK_Password;
                parameters[2].Value = model.JK_Leve;
                parameters[3].Value = model.JK_City;
                parameters[4].Value = model.JK_Sex;
                parameters[5].Value = model.JK_Phone;
                parameters[6].Value = model.JK_Datetime;
                parameters[7].Value = model.JK_Id;
                parameters[8].Value = model.JK_Jurisdiction;
                parameters[9].Value = model.JK_Activate;
                parameters[10].Value = model.JK_Number_Card_Id;
                result = Convert.ToInt32(DAL.SqlDataHelper.GetScalar(strSql.ToString(), parameters));
            }
            catch (Exception)
            {
            }
            return result;
        }
        #endregion

        #region 更新
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model">需要跟新的数据</param>
        /// <returns>更新结果</returns>
        public int Update(Model.Member  model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Member] set "); 
            strSql.Append("[JK_Name] = @jK_Name , ");
            strSql.Append("[JK_Password] = @jK_Password , ");
            strSql.Append("[JK_Leve] = @jK_Leve , ");
            strSql.Append("[JK_City] = @jK_City , ");
            strSql.Append("[JK_Sex] = @jK_Sex , ");
            strSql.Append("[JK_Phone] = @jK_Phone , ");
            strSql.Append("[JK_Datetime] = @jK_Datetime , ");
            strSql.Append("[JK_Id] = @jK_Id , ");
            strSql.Append("[JK_Jurisdiction] = @jK_Jurisdiction , ");
            strSql.Append("[JK_Activate] = @jK_Activate , ");
            strSql.Append("[JK_Number_Card_Id] = @jK_Number_Card_Id ");
            strSql.Append("  where [Id]=@id");
            SqlParameter[] parameters =new SqlParameter[]  {
                    new SqlParameter("@jK_Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@jK_Password", SqlDbType.NVarChar,50),
                    new SqlParameter("@jK_Leve", SqlDbType.Int,4),
                    new SqlParameter("@jK_City", SqlDbType.NVarChar,50),
                    new SqlParameter("@jK_Sex", SqlDbType.NChar,10),
                    new SqlParameter("@jK_Phone", SqlDbType.NVarChar,50),
                    new SqlParameter("@jK_Datetime", SqlDbType.DateTime,8),
                    new SqlParameter("@jK_Id", SqlDbType.Int,4),
                    new SqlParameter("@jK_Jurisdiction", SqlDbType.Int,4),
                    new SqlParameter("@jK_Activate", SqlDbType.NChar,10),
                    new SqlParameter("@jK_Number_Card_Id", SqlDbType.Int,4),
                    new SqlParameter("@id",SqlDbType.Int,4)
                                       };
               parameters[0].Value = model.JK_Name;
               parameters[1].Value = model.JK_Password;
               parameters[2].Value = model.JK_Leve;
               parameters[3].Value = model.JK_City;
               parameters[4].Value = model.JK_Sex;
               parameters[5].Value = model.JK_Phone;
               parameters[6].Value = model.JK_Datetime;
               parameters[7].Value = model.JK_Id;
               parameters[8].Value = model.JK_Jurisdiction;
               parameters[9].Value = model.JK_Activate;
               parameters[10].Value = model.JK_Number_Card_Id;
                parameters[11].Value = model.Id;
            try
            {
                res = DAL.SqlDataHelper.ExecuteCommand(strSql.ToString(), parameters);
            }
            catch (Exception)
            {
            }
            return res;
        }
        #endregion
    }
}
