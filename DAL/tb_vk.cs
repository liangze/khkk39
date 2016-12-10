using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class tb_vk
    {
        public tb_vk() { }

        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_vk");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_vk model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_vk(");
            strSql.Append("vkname,imgurl,walletaddress,v001,v002");
            strSql.Append(") values (");
            strSql.Append("@vkname,@imgurl,@walletaddress,@v001,@v002");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@vkname", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@imgurl", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@walletaddress", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@v001", SqlDbType.Int,4) ,            
                        new SqlParameter("@v002", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.vkname;
            parameters[1].Value = model.imgurl;
            parameters[2].Value = model.walletaddress;
            parameters[3].Value = model.v001;
            parameters[4].Value = model.v002;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt64(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_vk model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_vk set ");

            strSql.Append(" vkname = @vkname , ");
            strSql.Append(" imgurl = @imgurl , ");
            strSql.Append(" walletaddress = @walletaddress , ");
            strSql.Append(" v001 = @v001 , ");
            strSql.Append(" v002 = @v002  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@vkname", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@imgurl", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@walletaddress", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@v001", SqlDbType.Int,4) ,            
                        new SqlParameter("@v002", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.vkname;
            parameters[2].Value = model.imgurl;
            parameters[3].Value = model.walletaddress;
            parameters[4].Value = model.v001;
            parameters[5].Value = model.v002;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_vk ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_vk ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_vk GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, vkname, imgurl, walletaddress, v001, v002  ");
            strSql.Append("  from tb_vk ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;


            lgk.Model.tb_vk model = new lgk.Model.tb_vk();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.vkname = ds.Tables[0].Rows[0]["vkname"].ToString();
                model.imgurl = ds.Tables[0].Rows[0]["imgurl"].ToString();
                model.walletaddress = ds.Tables[0].Rows[0]["walletaddress"].ToString();
                if (ds.Tables[0].Rows[0]["v001"].ToString() != "")
                {
                    model.v001 = int.Parse(ds.Tables[0].Rows[0]["v001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["v002"].ToString() != "")
                {
                    model.v002 = decimal.Parse(ds.Tables[0].Rows[0]["v002"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据给定编号，获取ID
        /// </summary>
        /// <param name="vkname">给定额编号</param>
        /// <returns></returns>
        public long GetID(string vkname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ID] FROM tb_vk");
            strSql.Append(" WHERE vkname=@vkname");
            SqlParameter[] parameters = {
                    new SqlParameter("@vkname", SqlDbType.VarChar,20)};
            parameters[0].Value = vkname;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return long.Parse(obj.ToString());
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tb_vk ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM tb_vk ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
