﻿using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// 业务逻辑类:Cashsell
    /// </summary>
    public partial class Cashsell
    {
        private readonly lgk.DAL.Cashsell dal = new lgk.DAL.Cashsell();
        public Cashsell()
        { }
        #region Method

        public bool Exists(long CashsellID)
        {
            return dal.Exists(CashsellID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.Cashsell model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.Cashsell model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 执行给定的存储过程。
        /// </summary>
        /// <param name="strProcName">给定的存储过程</param>
        /// <returns></returns>
        public string  ExecProcedure(string strProcName,decimal price,long sellUserID)
        {
            return dal.ExecProcedure(strProcName, price, sellUserID);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateUndo(long iCashsellID, int iIsUndo,decimal Amount)
        {
            return dal.UpdateUndo(iCashsellID, iIsUndo, Amount);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateUndo1(long iCashsellID, int IsSell)
        {
            return dal.UpdateUndo1(iCashsellID,IsSell);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long CashsellID)
        {
            return dal.Delete(CashsellID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string CashsellIDlist)
        {
            return dal.DeleteList(CashsellIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashsell GetModel(long CashsellID)
        {
            return dal.GetModel(CashsellID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashsell GetModel(string strWhere)
        {
            return dal.GetModel(strWhere);
        }
        public DataSet CashBuyAndSellList(int top, string strWhere)
        {
            return dal.CashBuyAndSellList(top, strWhere);
        }

        /// <summary>
        /// 今日已挂卖数量
        /// </summary>
        public decimal GetAlready(long iUserID)
        {
            return dal.GetAlready(iUserID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList1(string strWhere)
        {
            return dal.GetList1(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetInnerList(string strWhere)
        {
            return dal.GetInnerList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList1(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList1(Top, strWhere, filedOrder);
        }

        #endregion
    }
}
