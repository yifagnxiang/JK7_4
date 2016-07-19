

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;//请先添加引用 

namespace DAL
{
    public partial  class Applyforresale
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
            strSql.Append(@"Select Count(*) from [Applyforresale]");
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
            strSql.Append(@"Select Count(*) from [Applyforresale]");
            if(strWhere.Trim () !="")
               {
                 strSql.Append(@" where "+strWhere);
                 retrunValue =int.Parse(DAL.SqlDataHelper.GetScalar(strSql.ToString()).ToString ());
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
            strSql.Append(@"delete [Applyforresale] where [Id]='" + id + "'");
            return DAL.SqlDataHelper.ExecuteCommand(strSql.ToString());
        }
        #endregion

        #region 获得单个实体对象
        /// <summary>
        /// 获得单个实体对象
        /// </summary>
        /// <param name="id">关键字</param>
        /// <returns>实体对象</returns>
        public Model.Applyforresale  SelectModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select [Id],[JK_Applyforresale],[JK_Applyforresale_DateTime],[JK_Applyforresale_Member_Id],[JK_Applforresale_Member_name] from [Applyforresale] ");
            strSql.Append(@" where [Id]=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            Model.Applyforresale model = new Model.Applyforresale();
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
        public Model.Applyforresale  SelectModel(string whereStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select [Id],[JK_Applyforresale],[JK_Applyforresale_DateTime],[JK_Applyforresale_Member_Id],[JK_Applforresale_Member_name] from [Applyforresale] ");
            if (whereStr.Trim() != "")
            {
                strSql.Append(@" where " + whereStr);
            }
            Model.Applyforresale model = new Model.Applyforresale();
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
        public IList<Model.Applyforresale> SelectList(int top,string whereStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select "); 
            if(top>0)
            {
               strSql.Append(" top "+top);
            }
            strSql.Append(" [Id],[JK_Applyforresale],[JK_Applyforresale_DateTime],[JK_Applyforresale_Member_Id],[JK_Applforresale_Member_name] from [Applyforresale] ");
            if (whereStr.Trim() != "")
            {
                strSql.Append(@" where " + whereStr);
            }
            DataTable dt = DAL.SqlDataHelper.GetDataTable(strSql.ToString());
            List<Model.Applyforresale > list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Model.Applyforresale >();
                Model.Applyforresale  model = null;
                
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Model.Applyforresale ();
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
        public IList<Model.Applyforresale> SelectByPaged(int pageIndex,int pageSize,  string strWhere, string orderBy, out int pageCount)
        {
            string sql_count = "select COUNT(*) from [Applyforresale]";
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
            strSql.Append(")as Row, *  from  Applyforresale");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) as Temp");
            strSql.AppendFormat(" WHERE Row between {0} and {1}", numStart, numEnd);
            DataTable dt = new DataTable();
            dt = SqlDataHelper.GetDataTable(strSql.ToString());
            IList<Model.Applyforresale> list = new List<Model.Applyforresale>();
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
        public DataSet GetApplyforresaleList(int pageIndex,int pageSize, string orderBy, string where, out int pageCount)
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
            parameters[2].Value = "[Applyforresale]";
            parameters[3].Value = orderBy;
            parameters[4].Value = where;
            DataSet ds = SqlDataHelper.RunProcedure("Pager", parameters, "Applyforresale");
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
        private void LoadListData(ref IList<Model.Applyforresale > list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Model.Applyforresale  model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Model.Applyforresale ();
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
        private void LoadEntityData(ref Model.Applyforresale  model, DataRow dr)
        {
           if (dr["Id"].ToString() != "") model.Id = int.Parse (dr["Id"].ToString());
           if (dr["JK_Applyforresale"].ToString() != "") model.JK_Applyforresale = dr["JK_Applyforresale"].ToString();
           if (dr["JK_Applyforresale_DateTime"].ToString() != "") model.JK_Applyforresale_DateTime = DateTime.Parse (dr["JK_Applyforresale_DateTime"].ToString());
           if (dr["JK_Applyforresale_Member_Id"].ToString() != "") model.JK_Applyforresale_Member_Id = int.Parse (dr["JK_Applyforresale_Member_Id"].ToString());
           if (dr["JK_Applforresale_Member_name"].ToString() != "") model.JK_Applforresale_Member_name = dr["JK_Applforresale_Member_name"].ToString();
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">要往数据库中的添加的实体对象</param>
        /// <returns>结果</returns>
        public int Add(Model.Applyforresale  model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"insert into [Applyforresale]( ");
                strSql.Append(@"[JK_Applyforresale],[JK_Applyforresale_DateTime],[JK_Applyforresale_Member_Id],[JK_Applforresale_Member_name]) values (@jK_Applyforresale,@jK_Applyforresale_DateTime,@jK_Applyforresale_Member_Id,@jK_Applforresale_Member_name)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@jK_Applyforresale", SqlDbType.NChar,10),
                    new SqlParameter("@jK_Applyforresale_DateTime", SqlDbType.DateTime,8),
                    new SqlParameter("@jK_Applyforresale_Member_Id", SqlDbType.Int,4),
                    new SqlParameter("@jK_Applforresale_Member_name", SqlDbType.NVarChar,50)
                    };
                parameters[0].Value = model.JK_Applyforresale;
                parameters[1].Value = model.JK_Applyforresale_DateTime;
                parameters[2].Value = model.JK_Applyforresale_Member_Id;
                parameters[3].Value = model.JK_Applforresale_Member_name;
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
        public int Update(Model.Applyforresale  model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Applyforresale] set "); 
            strSql.Append("[JK_Applyforresale] = @jK_Applyforresale , ");
            strSql.Append("[JK_Applyforresale_DateTime] = @jK_Applyforresale_DateTime , ");
            strSql.Append("[JK_Applyforresale_Member_Id] = @jK_Applyforresale_Member_Id , ");
            strSql.Append("[JK_Applforresale_Member_name] = @jK_Applforresale_Member_name ");
            strSql.Append("  where [Id]=@id");
            SqlParameter[] parameters =new SqlParameter[]  {
                    new SqlParameter("@jK_Applyforresale", SqlDbType.NChar,10),
                    new SqlParameter("@jK_Applyforresale_DateTime", SqlDbType.DateTime,8),
                    new SqlParameter("@jK_Applyforresale_Member_Id", SqlDbType.Int,4),
                    new SqlParameter("@jK_Applforresale_Member_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@id",SqlDbType.Int,4)
                                       };
               parameters[0].Value = model.JK_Applyforresale;
               parameters[1].Value = model.JK_Applyforresale_DateTime;
               parameters[2].Value = model.JK_Applyforresale_Member_Id;
               parameters[3].Value = model.JK_Applforresale_Member_name;
                parameters[4].Value = model.Id;
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
