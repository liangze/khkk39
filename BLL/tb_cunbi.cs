using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class tb_cunbi
    {
        private readonly lgk.DAL.tb_cunbi dal = new lgk.DAL.tb_cunbi();
        public tb_cunbi()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_cunbi model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_cunbi model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_cunbi GetModel(long ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public lgk.Model.tb_cunbi GetModelByCache(long ID)
        //{

        //    string CacheKey = "tb_cunbiModel-" + ID;
        //    object objModel = lgk.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = lgk.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                lgk.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (lgk.Model.tb_cunbi)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
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
        public List<lgk.Model.tb_cunbi> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_cunbi> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_cunbi> modelList = new List<lgk.Model.tb_cunbi>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_cunbi model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_cunbi();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.c003 = dt.Rows[n]["c003"].ToString();
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = decimal.Parse(dt.Rows[n]["Amount"].ToString());
                    }
                    if (dt.Rows[n]["SettleDay"].ToString() != "")
                    {
                        model.SettleDay = int.Parse(dt.Rows[n]["SettleDay"].ToString());
                    }
                    if (dt.Rows[n]["SurplusDay"].ToString() != "")
                    {
                        model.SurplusDay = int.Parse(dt.Rows[n]["SurplusDay"].ToString());
                    }
                    if (dt.Rows[n]["States"].ToString() != "")
                    {
                        model.States = int.Parse(dt.Rows[n]["States"].ToString());
                    }
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["c001"].ToString() != "")
                    {
                        model.c001 = int.Parse(dt.Rows[n]["c001"].ToString());
                    }
                    if (dt.Rows[n]["c002"].ToString() != "")
                    {
                        model.c002 = decimal.Parse(dt.Rows[n]["c002"].ToString());
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetUList(string strWhere)
        {
            return dal.GetUList(strWhere);
        }

        #endregion
    }
}
