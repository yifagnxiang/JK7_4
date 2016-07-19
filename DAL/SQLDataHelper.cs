

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
namespace DAL
{
    public  class SqlDataHelper
    {
        //private static readonly string connectionString ="Data Source=.;database=JK7_4;User ID=sa;Password=123456;";
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["jkyacht"].ConnectionString;

        private static bool isErlog = false; //是否记录错误日志
        private static bool isOplog = false; //是否记录操作日志


        #region 1.为cmd命令对象做执行前参数设定
        /// <summary>
        /// 为cmd命令对象做执行前参数设定
        /// </summary>
        /// <param name="cmd">cmd命令对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">sql命令文本,</param>
        /// <param name="cmdParms">在命令文本中要使用的 sql参数</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != System.Data.ConnectionState.Open) conn.Open();//如果连接通道未打开 则打开通道
            cmd.Connection = conn;//为命令对象设置连接通道
            cmd.CommandText = cmdText;//为命令对象设置sql文本
            if (trans != null) cmd.Transaction = trans;//如果存在事务，则为命令对象设置事务
            cmd.CommandType = cmdType;//设置命令类型(sql文本/存储过程)
            if (cmdParms != null)//如果参数集合不为空，为命令对象添加参数
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&(parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
        #endregion

        #region 2.执行sql命令 增删改
        /// <summary>
        /// 执行sql命令 增删改(无参数)
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <returns></returns>
        public static int ExecuteCommand(string cmdText)
        {
            return ExecuteCommand(cmdText, null);
        }

        /// <summary>
        /// 执行sql命令 增删改(带参数)
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <returns></returns>
        public static int ExecuteCommand(string cmdText, SqlParameter[] parameters)
        {
            #region 原方法代码
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand(cmdText, conn);
            //    if (parameters != null) cmd.Parameters.AddRange(parameters);
            //    int val = 0; 
            //    try
            //    {
            //        val = cmd.ExecuteNonQuery();
            //    }
            //    catch (Exception)
            //    {
            //    }
            //    cmd.Parameters.Clear();
            //    return val;
            //} 
            #endregion
            return ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        /// <summary>
        /// 执行sql命令 增删改(带参数)
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="commandParameters">参数集合</param>
        /// <returns></returns>
        public static int ExecuteCommand(string cmdText, CommandType cmdType, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int res = 0;
                try
                {
                    res = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                cmd.Parameters.Clear();
                return res;
            }
            //return ExecuteCommand(cmdText, null, cmdType, commandParameters);
        }

        /// <summary>
        /// 执行sql命令 增删改
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        public static int ExecuteCommand(string cmdText, SqlTransaction trans, CommandType cmdType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, parameters);
            int res =0;
            try
            {
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            { 
            }
            cmd.Parameters.Clear();
            return res;
        }
        #endregion

        #region 3.构建 SqlCommand 对象
        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                     // 检查未分配值的输出参数,将其分配以DBNull.Value
                     if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&(parameter.Value == null))
                     {
                         parameter.Value = DBNull.Value;
                     }
                     command.Parameters.Add(parameter);
                }
            }
            return command;
        }
        #endregion

        #region 4.执行sql命令 查询
        /// <summary>
        /// 执行sql命令 查询
        /// </summary>
        /// <param name="sqlStr">sql命令语句</param>
        /// <returns></returns>
        public static System.Data.DataTable GetDataTable(string sqlStr)
        {
            #region 原方法代码
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlDataAdapter da = new SqlDataAdapter(sqlStr, connection);
            //    DataTable dt = new DataTable();
            //    try
            //    {
            //        da.Fill(dt);
            //    }
            //    catch (Exception)
            //    { 
            //    }
            //    return dt;
            //} 
            #endregion
            return GetDataTable(sqlStr, null);
        }

        /// <summary>
        /// 执行sql命令 查询
        /// </summary>
        /// <param name="sqlStr">sql命令语句</param>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        public static System.Data.DataTable GetDataTable(string sqlStr,SqlParameter[] parameters)
        {
            return GetDataTable(sqlStr, CommandType.Text, parameters);
        }

        /// <summary>
        /// 执行sql命令 查询
        /// </summary>
        /// <param name="sqlStr">sql命令语句</param>
        /// <param name="type">命令类型</param>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sqlStr,CommandType type, SqlParameter[] parameters) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, connection);
                cmd.CommandType = type;
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                }
                catch (Exception)
                {
                }
                cmd.Parameters.Clear();
                return dt;
            }
        }

        /// <summary>
        /// 执行存储过程查询
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// 执行sql命令 (查询)
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <returns></returns>
        public static object GetScalar(string cmdText) 
        {
            return GetScalar(cmdText, null);
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">sql多条SQL语句</param>
        /// <returns></returns>
        public static int ExecuteSqlTran(List<String> SQLStringList) 
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    foreach (var strsql in SQLStringList)
                    {
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
            }
        }


        /// <summary>
        /// 执行sql命令 (查询)
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <param name="parameters">参数集合</param>
        /// <returns>第一行第一列的值（object类型）</returns>
        public static object GetScalar(string cmdText,SqlParameter[] parameters)
        {
            return GetScalar(cmdText, CommandType.Text, parameters);
        }

        /// <summary>
        /// 执行sql命令 (查询)
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="parameters">参数集合</param>
        /// <returns>第一行第一列的值（object类型）</returns>
        public static object  GetScalar(string cmdText, CommandType cmdType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            object res = 0;
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, parameters);
                try
                {
                    res = cmd.ExecuteScalar();
                }
                catch (Exception)
                {
                }
                cmd.Parameters.Clear();
                return res;
            }
        }
        /// <summary>
        /// 执行存储过程，返回Obj对象
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static object RunProcedureSingle(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
               {
                    connection.Open();
                    SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                    command.CommandTimeout = 600;
                    command.CommandType = CommandType.StoredProcedure;
                    object retval = command.ExecuteScalar();
                    command.Parameters.Clear();
                    return retval;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        #endregion

        // <summary>记录错误日志
        
        // </summary>
        //<param name="dic"></param>
        // <returns></returns>
        private static void WriteErro(Exception filterContext)
        {
            if (isErlog)
            {
                DateTime now = DateTime.Now;
                string fatherName = "/App_Data/" + "Logs_" + now.ToString("yyyy-MM") + "/";
                string savePath = new System.Web.UI.Page().Server.MapPath(fatherName);
                if(!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string fileName = now.ToString("yyyy-MM-dd") + ".txt";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                var mBase = System.Reflection.MethodBase.GetCurrentMethod();
                sb.AppendLine("----------------------------------header---------------------------------<br/>");
                sb.AppendLine("访问地址：" + HttpContext.Current.Request.Url.PathAndQuery + "  访问类名:" + mBase.DeclaringType.FullName + "执行方法:" + mBase.Name + "<br/>");
                sb.AppendLine("异常来自：" + filterContext.TargetSite.ReflectedType.ToString() + "." + filterContext.TargetSite.Name + "<br/>");
                sb.AppendLine("异常信息：" + filterContext.Message + "<br/>");
                sb.AppendLine("发生时间：" + now + "<br/>");
                sb.AppendLine("----------------------------------footer----------------------------------<br/>");
                System.IO.File.AppendAllText(savePath + fileName , sb.ToString());
            }
        }

    }
}

