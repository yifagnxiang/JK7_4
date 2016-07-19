
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;//请先添加引用
using Model;//请先添加引用

namespace BLL
{
    public partial class Cstomization
    {
        private static readonly DAL.Cstomization _DALCstomization = new DAL.Cstomization();

        #region 查看是否存在该记录(条件语句优先)
        /// <summary>
        /// 查看是否存在该记录(条件语句优先)
        /// </summary>
        /// <param name="Id">关键字</param>
        /// <param name="strWhere">条件语句</param>
        /// <returns></returns>
        public static bool Exists(int Id,string strWhere)
        {
            return _DALCstomization.Exists(Id,strWhere);
        } 
        #endregion

        #region 统计数量
        /// <summary>统计数量
        ///
        /// </summary>
        /// <param name="strWhere">条件语句</param>
        /// <returns></returns>
        public static int RecorCount(string strWhere)
        {
            return _DALCstomization.RecorCount(strWhere);
        }
        #endregion

        #region 根据关键字获得用户实体对象
        /// <summary>
        /// 根据关键字获得用户实体对象
        /// </summary>
        /// <param name="Id">关键字</param>
        /// <returns>实体记录</returns>
        public static Model.Cstomization SelectModel(int Id)
        {
            return _DALCstomization.SelectModel(Id);
        }
        #endregion

        #region 根据关键字获得用户实体对象
        /// <summary>
        /// 根据关键字获得用户实体对象
        /// </summary>
        /// <param name="whereStr">关键字</param>
        /// <returns>实体记录</returns>
        public static Model.Cstomization SelectModel(string whereStr)
        {
            return _DALCstomization.SelectModel(whereStr);
        }
        #endregion

        #region 获取数据集
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="whereStr">条件语句</param>
        /// <returns>实体泛型集合</returns>
        public static IList<Model.Cstomization> SelectList(int top,string whereStr)
        {
            return _DALCstomization.SelectList(top,whereStr);
        }
        #endregion

        #region 根据分页查询记录
        /// <summary>
        /// 根据分页查询记录
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面显示的行数</param>  
        /// <param name="pageCount">总行数</param>
        /// <returns>根据分页查询到的记录</returns>
        public static IList<Model.Cstomization> SelectByPage(int pageIndex,int pageSize,  string strWhere,string orderBy, out int pageCount)
        {
            return _DALCstomization.SelectByPaged( pageIndex,pageSize, strWhere, orderBy, out pageCount);
        } 

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面显示的行数</param> 
        /// <param name="tableName">表名</param>
        /// <param name="orderBy">排序</param>
        /// <param name="where">条件语句</param>
        /// <param name="pageCount">总行数</param>
        /// <returns>DataSet</returns>
        public static DataSet GetListByTableName(int pageIndex , int pageSize , string tableName , string orderBy , string where , out int pageCount)
        {
            return _DALCstomization.GetListByTableName(pageIndex,pageSize,tableName,orderBy,where,out pageCount);
        } 

        public static DataSet GetCstomizationList( int pageIndex ,int pageSize , string orderBy , string where , out int pageCount)
        {
            return _DALCstomization.GetCstomizationList(pageIndex,pageSize,orderBy,where,out pageCount);
        } 

        #endregion


        #region 删除一条记录
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="Id">关键字</param>
        /// <returns>删除结果</returns>
        public static int Delet(int Id)
        {
            return _DALCstomization.Del(Id);
        }
        #endregion

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns>添加结果</returns>
        public static int Add(Model.Cstomization _entity)
        {
            return _DALCstomization.Add(_entity);
        }
        #endregion

        #region 更新一条记录
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns>更新结果</returns>
        public static int Update(Model.Cstomization  _entity)
        {
            return _DALCstomization.Update(_entity);
        }
        #endregion
    }
}

