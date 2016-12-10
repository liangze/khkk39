using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class tb_vk
    {
        private readonly lgk.DAL.tb_vk dal = new lgk.DAL.tb_vk();
        public tb_vk()
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
        public long Add(lgk.Model.tb_vk model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_vk model)
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
        public lgk.Model.tb_vk GetModel(long ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 根据给定编号，获取用户ID
        /// </summary>
        /// <param name="vkname">给定额编号</param>
        /// <returns></returns>
        public long GetID(string vkname)
        {
            return dal.GetID(vkname);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public lgk.Model.tb_vk GetModelByCache(long ID)
        //{

        //    string CacheKey = "tb_vkModel-" + ID;
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
        //    return (lgk.Model.tb_vk)objModel;
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
        public List<lgk.Model.tb_vk> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_vk> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_vk> modelList = new List<lgk.Model.tb_vk>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_vk model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_vk();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.vkname = dt.Rows[n]["vkname"].ToString();
                    model.imgurl = dt.Rows[n]["imgurl"].ToString();
                    model.walletaddress = dt.Rows[n]["walletaddress"].ToString();
                    if (dt.Rows[n]["v001"].ToString() != "")
                    {
                        model.v001 = int.Parse(dt.Rows[n]["v001"].ToString());
                    }
                    if (dt.Rows[n]["v002"].ToString() != "")
                    {
                        model.v002 = decimal.Parse(dt.Rows[n]["v002"].ToString());
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
