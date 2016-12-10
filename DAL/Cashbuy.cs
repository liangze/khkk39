using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:Cashbuy
    /// </summary>
    public partial class Cashbuy
    {
        public Cashbuy()
		{ }
        #region Method

        public bool Exists(long CashbuyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cashbuy where CashbuyID = @CashbuyID");
            SqlParameter[] parameters = {
					new SqlParameter("@CashbuyID", SqlDbType.BigInt,8)};
            parameters[0].Value = CashbuyID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.Cashbuy model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cashbuy(");
            strSql.Append("CashsellID,UserID,Amount,Price,Number,BuyNum,BuyDate,IsBuy,TypeID,SellUserID,BankAccount,BankAccountUser,BankName,BankBranch,BankInProvince,Image) ");
            strSql.Append("values (@CashsellID,@UserID,@Amount,@Price,@Number,@BuyNum,@BuyDate,@IsBuy,@TypeID,@SellUserID,@BankAccount,@BankAccountUser,@BankName,@BankBranch,@BankInProvince,@Image)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@CashsellID", SqlDbType.BigInt,8),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@Price", SqlDbType.Decimal,9),
                        new SqlParameter("@Number", SqlDbType.Int,4),
                        new SqlParameter("@BuyNum", SqlDbType.Int,4),
                        new SqlParameter("@BuyDate", SqlDbType.DateTime),
                        new SqlParameter("@IsBuy", SqlDbType.Int,4),
                        new SqlParameter("@TypeID", SqlDbType.Int,4),
                        new SqlParameter("@SellUserID", SqlDbType.Int,4),
                        new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
                        new SqlParameter("@BankAccountUser", SqlDbType.VarChar,50),
                        new SqlParameter("@BankName", SqlDbType.VarChar,50),
                        new SqlParameter("@BankBranch", SqlDbType.VarChar,50),
                        new SqlParameter("@BankInProvince", SqlDbType.VarChar,50),
                         new SqlParameter("@Image", SqlDbType.VarChar,50),
            };
                        
            parameters[0].Value = model.CashsellID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.Number;
            parameters[5].Value = model.BuyNum;
            parameters[6].Value = model.BuyDate;
            parameters[7].Value = model.IsBuy;
            parameters[8].Value = model.TypeID;
            parameters[9].Value = model.SellUserID;
            parameters[10].Value = model.BankAccount;
            parameters[11].Value = model.BankAccountUser;
            parameters[12].Value = model.BankName;
            parameters[13].Value = model.BankBranch;
            parameters[14].Value = model.BankInProvince;
            parameters[15].Value = model.Image;
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
        public bool Update(lgk.Model.Cashbuy model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cashbuy set");
            strSql.Append(" CashsellID = @CashsellID,");
            strSql.Append(" UserID = @UserID,");
            strSql.Append(" Amount = @Amount,");
            strSql.Append(" Price = @Price,");
            strSql.Append(" Number = @Number,");
            strSql.Append(" BuyNum = @BuyNum,");
            strSql.Append(" BuyDate = @BuyDate,");
            strSql.Append(" IsBuy = @IsBuy,");
            strSql.Append(" TypeID = @TypeID,");
            strSql.Append(" SellUserID = @SellUserID,");
            strSql.Append(" BankAccount = @BankAccount,");
            strSql.Append(" BankAccountUser = @BankAccountUser,");
            strSql.Append(" BankName = @BankName,");
            strSql.Append(" BankBranch = @BankBranch,");
            strSql.Append(" BankInProvince = @BankInProvince,");
       
            strSql.Append(" Image = @Image");
            strSql.Append(" where CashbuyID=@CashbuyID");
            SqlParameter[] parameters = {
			            new SqlParameter("@CashbuyID", SqlDbType.BigInt,8),
                        new SqlParameter("@CashsellID", SqlDbType.BigInt,8),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@Price", SqlDbType.Decimal,9),
                        new SqlParameter("@Number", SqlDbType.Int,4),
                        new SqlParameter("@BuyNum", SqlDbType.Int,4),
                        new SqlParameter("@BuyDate", SqlDbType.DateTime),
                        new SqlParameter("@IsBuy", SqlDbType.Int,4),
                        new SqlParameter("@TypeID", SqlDbType.Int,4),
                        new SqlParameter("@SellUserID", SqlDbType.Int,4),
                        new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
                        new SqlParameter("@BankAccountUser", SqlDbType.VarChar,50),
                        new SqlParameter("@BankName", SqlDbType.VarChar,50),
                        new SqlParameter("@BankBranch", SqlDbType.VarChar,50),
                        new SqlParameter("@BankInProvince", SqlDbType.VarChar,50),
                        new SqlParameter("@Image", SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.CashbuyID;
            parameters[1].Value = model.CashsellID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.Number;
            parameters[6].Value = model.BuyNum;
            parameters[7].Value = model.BuyDate;
            parameters[8].Value = model.IsBuy;
            parameters[9].Value = model.TypeID;
            parameters[10].Value = model.SellUserID;
            parameters[11].Value = model.BankAccount;
            parameters[12].Value = model.BankAccountUser;
            parameters[13].Value = model.BankName;
            parameters[14].Value = model.BankBranch;
            parameters[15].Value = model.BankInProvince;
            parameters[16].Value = model.Image;

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
        public bool Delete(long CashbuyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashbuy ");
            strSql.Append(" where CashbuyID=@CashbuyID");
            SqlParameter[] parameters = {
					new SqlParameter("@CashbuyID", SqlDbType.BigInt,8)};
            parameters[0].Value = CashbuyID;

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
        public bool DeleteList(string CashbuyIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashbuy ");
            strSql.Append(" where ID in (" + CashbuyIDlist + ")  ");
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
        public lgk.Model.Cashbuy GetModel(long CashbuyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CashbuyID, CashsellID, UserID, Amount, Price, Number, BuyNum, BuyDate, IsBuy,TypeID,SellUserID,BankAccount,BankAccountUser,BankName,BankBranch,BankInProvince,Image");
            strSql.Append(" from Cashbuy");
            strSql.Append(" where CashbuyID=@CashbuyID");
            SqlParameter[] parameters = {
					new SqlParameter("@CashbuyID", SqlDbType.BigInt,8)};
            parameters[0].Value = CashbuyID;

            lgk.Model.Cashbuy model = new lgk.Model.Cashbuy();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CashbuyID"].ToString() != "")
                {
                    model.CashbuyID = long.Parse(ds.Tables[0].Rows[0]["CashbuyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CashsellID"].ToString() != "")
                {
                    model.CashsellID = long.Parse(ds.Tables[0].Rows[0]["CashsellID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SellUserID"].ToString() != "")
                {
                    model.Number = int.Parse(ds.Tables[0].Rows[0]["Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyNum"].ToString() != "")
                {
                    model.BuyNum = int.Parse(ds.Tables[0].Rows[0]["BuyNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(ds.Tables[0].Rows[0]["BuyDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsBuy"].ToString() != "")
                {
                    model.IsBuy = int.Parse(ds.Tables[0].Rows[0]["IsBuy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SellUserID"].ToString() != "")
                {
                    model.SellUserID = int.Parse(ds.Tables[0].Rows[0]["SellUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccountUser"].ToString() != "")
                {
                    model.BankAccountUser = ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankBranch"].ToString() != "")
                {
                    model.BankBranch = ds.Tables[0].Rows[0]["BankBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankInProvince"].ToString() != "")
                {
                    model.BankInProvince = ds.Tables[0].Rows[0]["BankInProvince"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                {
                    model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Image"].ToString() != "")
                {
                    model.Image = ds.Tables[0].Rows[0]["Image"].ToString();
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashbuy GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CashbuyID, CashsellID, UserID, Amount, Price, Number, BuyNum, BuyDate, IsBuy,TypeID,SellUserID,BankAccount,BankAccountUser,BankName,BankBranch,BankInProvince,Image");
            strSql.Append(" from Cashbuy ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            lgk.Model.Cashbuy model = new lgk.Model.Cashbuy();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CashbuyID"].ToString() != "")
                {
                    model.CashbuyID = long.Parse(ds.Tables[0].Rows[0]["CashbuyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CashsellID"].ToString() != "")
                {
                    model.CashsellID = long.Parse(ds.Tables[0].Rows[0]["CashsellID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Number"].ToString() != "")
                {
                    model.SellUserID = int.Parse(ds.Tables[0].Rows[0]["Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyNum"].ToString() != "")
                {
                    model.BuyNum = int.Parse(ds.Tables[0].Rows[0]["BuyNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(ds.Tables[0].Rows[0]["BuyDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsBuy"].ToString() != "")
                {
                    model.IsBuy = int.Parse(ds.Tables[0].Rows[0]["IsBuy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SellUserID"].ToString() != "")
                {
                    model.SellUserID = int.Parse(ds.Tables[0].Rows[0]["SellUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccountUser"].ToString() != "")
                {
                    model.BankAccountUser = ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankBranch"].ToString() != "")
                {
                    model.BankBranch = ds.Tables[0].Rows[0]["BankBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankInProvince"].ToString() != "")
                {
                    model.BankInProvince = ds.Tables[0].Rows[0]["BankInProvince"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                {
                    model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Image"].ToString() != "")
                {
                    model.BankName = ds.Tables[0].Rows[0]["Image"].ToString();
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
            strSql.Append("SELECT * FROM Cashbuy");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Price,IsNull(sum(BuyNum),0) as BuyNum FROM Cashbuy");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetInnerList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [Cashbuy].*,[Cashsell].[UserID] AS SUserID");
            strSql.Append(" FROM [Cashbuy] JOIN [Cashsell] ON [Cashsell].[CashsellID]=[Cashbuy].[CashsellID]");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
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
            strSql.Append(" FROM Cashbuy ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList1(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            //select u.Price,IsNull(sum(u.BuyNum), 0) as BuyNum FROM(select top 5 * from Cashbuy where IsBuy=0 AND TypeID=2 order by BuyDate desc) u GROUP BY u.Price order by u.Price desc
            strSql.Append(" (select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }

            strSql.Append(" Price,SUM(BuyNum) as BuyNum FROM Cashbuy ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by Price order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion
    }
}
