using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class tb_cunbi
    {
        public tb_cunbi() { }

        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_cunbi");
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
        public long Add(lgk.Model.tb_cunbi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_cunbi(");
            strSql.Append("c003,UserID,Amount,SettleDay,SurplusDay,States,AddTime,c001,c002");
            strSql.Append(") values (");
            strSql.Append("@c003,@UserID,@Amount,@SettleDay,@SurplusDay,@States,@AddTime,@c001,@c002");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@c003", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Amount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SettleDay", SqlDbType.Int,4) ,            
                        new SqlParameter("@SurplusDay", SqlDbType.Int,4) ,            
                        new SqlParameter("@States", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@c001", SqlDbType.Int,4) ,            
                        new SqlParameter("@c002", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.c003;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.SettleDay;
            parameters[4].Value = model.SurplusDay;
            parameters[5].Value = model.States;
            parameters[6].Value = model.AddTime;
            parameters[7].Value = model.c001;
            parameters[8].Value = model.c002;

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
        public bool Update(lgk.Model.tb_cunbi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_cunbi set ");

            strSql.Append(" c003 = @c003 , ");
            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" Amount = @Amount , ");
            strSql.Append(" SettleDay = @SettleDay , ");
            strSql.Append(" SurplusDay = @SurplusDay , ");
            strSql.Append(" States = @States , ");
            strSql.Append(" AddTime = @AddTime , ");
            strSql.Append(" c001 = @c001 , ");
            strSql.Append(" c002 = @c002  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@c003", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Amount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SettleDay", SqlDbType.Int,4) ,            
                        new SqlParameter("@SurplusDay", SqlDbType.Int,4) ,            
                        new SqlParameter("@States", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@c001", SqlDbType.Int,4) ,            
                        new SqlParameter("@c002", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.c003;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.SettleDay;
            parameters[5].Value = model.SurplusDay;
            parameters[6].Value = model.States;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.c001;
            parameters[9].Value = model.c002;
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
            strSql.Append("delete from tb_cunbi ");
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
            strSql.Append("delete from tb_cunbi ");
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
        public lgk.Model.tb_cunbi GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, c003, UserID, Amount, SettleDay, SurplusDay, States, AddTime, c001, c002  ");
            strSql.Append("  from tb_cunbi ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;


            lgk.Model.tb_cunbi model = new lgk.Model.tb_cunbi();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.c003 = ds.Tables[0].Rows[0]["c003"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SettleDay"].ToString() != "")
                {
                    model.SettleDay = int.Parse(ds.Tables[0].Rows[0]["SettleDay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SurplusDay"].ToString() != "")
                {
                    model.SurplusDay = int.Parse(ds.Tables[0].Rows[0]["SurplusDay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["States"].ToString() != "")
                {
                    model.States = int.Parse(ds.Tables[0].Rows[0]["States"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["c001"].ToString() != "")
                {
                    model.c001 = int.Parse(ds.Tables[0].Rows[0]["c001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["c002"].ToString() != "")
                {
                    model.c002 = decimal.Parse(ds.Tables[0].Rows[0]["c002"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tb_cunbi ");
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
            strSql.Append(" FROM tb_cunbi ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetUList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c.*,u.UserCode ");
            strSql.Append(" FROM tb_cunbi as c inner join tb_user as u on c.UserID=u.UserID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
