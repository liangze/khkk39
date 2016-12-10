using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using lgk.Model;
namespace lgk.BLL
{
    //StockSell
    public partial class StockSell
    {

        private readonly lgk.DAL.StockSell dal = new lgk.DAL.StockSell();
        public StockSell()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StockID)
        {
            return dal.Exists(StockID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.StockSell model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.StockSell model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long StockID)
        {

            return dal.Delete(StockID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string StockIDlist)
        {
            return dal.DeleteList(StockIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.StockSell GetModel(long StockID)
        {

            return dal.GetModel(StockID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet CashBuyAndSellList(int top, string strWhere)
        {
            return dal.CashBuyAndSellList(top, strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.StockSell> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.StockSell> DataTableToList(DataTable dt)
        {
            List<lgk.Model.StockSell> modelList = new List<lgk.Model.StockSell>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.StockSell model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.StockSell();
                    if (dt.Rows[n]["StockID"].ToString() != "")
                    {
                        model.StockID = long.Parse(dt.Rows[n]["StockID"].ToString());
                    }
                    if (dt.Rows[n]["IsLock"].ToString() != "")
                    {
                        model.IsLock = int.Parse(dt.Rows[n]["IsLock"].ToString());
                    }
                    if (dt.Rows[n]["IsSell"].ToString() != "")
                    {
                        model.IsSell = int.Parse(dt.Rows[n]["IsSell"].ToString());
                    }
                    if (dt.Rows[n]["SalesType"].ToString() != "")
                    {
                        model.SalesType = int.Parse(dt.Rows[n]["SalesType"].ToString());
                    }
                    if (dt.Rows[n]["IsBack"].ToString() != "")
                    {
                        model.IsBack = int.Parse(dt.Rows[n]["IsBack"].ToString());
                    }
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = decimal.Parse(dt.Rows[n]["Amount"].ToString());
                    }
                    if (dt.Rows[n]["BuyPrice"].ToString() != "")
                    {
                        model.BuyPrice = decimal.Parse(dt.Rows[n]["BuyPrice"].ToString());
                    }
                    if (dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["Number"].ToString() != "")
                    {
                        model.Number = int.Parse(dt.Rows[n]["Number"].ToString());
                    }
                    if (dt.Rows[n]["Surplus"].ToString() != "")
                    {
                        model.Surplus = int.Parse(dt.Rows[n]["Surplus"].ToString());
                    }
                    if (dt.Rows[n]["SplitNum"].ToString() != "")
                    {
                        model.SplitNum = int.Parse(dt.Rows[n]["SplitNum"].ToString());
                    }
                    if (dt.Rows[n]["BuyDate"].ToString() != "")
                    {
                        model.BuyDate = DateTime.Parse(dt.Rows[n]["BuyDate"].ToString());
                    }


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        #endregion

    }
}