using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataAccess;

namespace lgk.DAL
{
    //StockSell
    public partial class StockSell
    {

        public bool Exists(long StockID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StockSell");
            strSql.Append(" where ");
            strSql.Append(" StockID = @StockID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.StockSell model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StockSell(");
            strSql.Append("IsLock,IsSell,SalesType,IsBack,UserID,Amount,BuyPrice,Price,Number,Surplus,SplitNum,BuyDate");
            strSql.Append(") values (");
            strSql.Append("@IsLock,@IsSell,@SalesType,@IsBack,@UserID,@Amount,@BuyPrice,@Price,@Number,@Surplus,@SplitNum,@BuyDate");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@IsLock", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsSell", SqlDbType.Int,4) ,            
                        new SqlParameter("@SalesType", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsBack", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Amount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BuyPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Number", SqlDbType.Int,4) ,            
                        new SqlParameter("@Surplus", SqlDbType.Int,4) ,            
                        new SqlParameter("@SplitNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@BuyDate", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.IsLock;
            parameters[1].Value = model.IsSell;
            parameters[2].Value = model.SalesType;
            parameters[3].Value = model.IsBack;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.Amount;
            parameters[6].Value = model.BuyPrice;
            parameters[7].Value = model.Price;
            parameters[8].Value = model.Number;
            parameters[9].Value = model.Surplus;
            parameters[10].Value = model.SplitNum;
            parameters[11].Value = model.BuyDate;

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
        public bool Update(lgk.Model.StockSell model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StockSell set ");

            strSql.Append(" IsLock = @IsLock , ");
            strSql.Append(" IsSell = @IsSell , ");
            strSql.Append(" SalesType = @SalesType , ");
            strSql.Append(" IsBack = @IsBack , ");
            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" Amount = @Amount , ");
            strSql.Append(" BuyPrice = @BuyPrice , ");
            strSql.Append(" Price = @Price , ");
            strSql.Append(" Number = @Number , ");
            strSql.Append(" Surplus = @Surplus , ");
            strSql.Append(" SplitNum = @SplitNum , ");
            strSql.Append(" BuyDate = @BuyDate  ");
            strSql.Append(" where StockID=@StockID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@StockID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@IsLock", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsSell", SqlDbType.Int,4) ,            
                        new SqlParameter("@SalesType", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsBack", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Amount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BuyPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Number", SqlDbType.Int,4) ,            
                        new SqlParameter("@Surplus", SqlDbType.Int,4) ,            
                        new SqlParameter("@SplitNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@BuyDate", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.StockID;
            parameters[1].Value = model.IsLock;
            parameters[2].Value = model.IsSell;
            parameters[3].Value = model.SalesType;
            parameters[4].Value = model.IsBack;
            parameters[5].Value = model.UserID;
            parameters[6].Value = model.Amount;
            parameters[7].Value = model.BuyPrice;
            parameters[8].Value = model.Price;
            parameters[9].Value = model.Number;
            parameters[10].Value = model.Surplus;
            parameters[11].Value = model.SplitNum;
            parameters[12].Value = model.BuyDate;
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
        public bool Delete(long StockID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockSell ");
            strSql.Append(" where StockID=@StockID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockID;


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
        public bool DeleteList(string StockIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockSell ");
            strSql.Append(" where ID in (" + StockIDlist + ")  ");
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
        public lgk.Model.StockSell GetModel(long StockID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StockID, IsLock, IsSell, SalesType, IsBack, UserID, Amount, BuyPrice, Price, Number, Surplus, SplitNum, BuyDate  ");
            strSql.Append("  from StockSell ");
            strSql.Append(" where StockID=@StockID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockID;


            lgk.Model.StockSell model = new lgk.Model.StockSell();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StockID"].ToString() != "")
                {
                    model.StockID = long.Parse(ds.Tables[0].Rows[0]["StockID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSell"].ToString() != "")
                {
                    model.IsSell = int.Parse(ds.Tables[0].Rows[0]["IsSell"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SalesType"].ToString() != "")
                {
                    model.SalesType = int.Parse(ds.Tables[0].Rows[0]["SalesType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsBack"].ToString() != "")
                {
                    model.IsBack = int.Parse(ds.Tables[0].Rows[0]["IsBack"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyPrice"].ToString() != "")
                {
                    model.BuyPrice = decimal.Parse(ds.Tables[0].Rows[0]["BuyPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Number"].ToString() != "")
                {
                    model.Number = int.Parse(ds.Tables[0].Rows[0]["Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Surplus"].ToString() != "")
                {
                    model.Surplus = int.Parse(ds.Tables[0].Rows[0]["Surplus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitNum"].ToString() != "")
                {
                    model.SplitNum = int.Parse(ds.Tables[0].Rows[0]["SplitNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(ds.Tables[0].Rows[0]["BuyDate"].ToString());
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
            strSql.Append("select convert(varchar(100),BuyDate,24) as bt, IsSell, BuyPrice, Number, Amount, BuyDate ");
            strSql.Append(" FROM StockSell ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet CashBuyAndSellList(int top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" TOP " + top.ToString());
            }
            strSql.Append(" UserID,Amount,Price,AddTime,IsBorS,Number from  ");
            strSql.Append(" (select UserID,Amount,Price,SurplusSum as Number,BuyDate as AddTime,IsBorS=1 from tb_StockBuy union ");
            strSql.Append(" select UserID,Amount,Price,Number,BuyDate as AddTime,IsBorS=2 from tb_StockSell ) u ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by u.AddTime desc ");

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
            strSql.Append(" convert(varchar(100),BuyDate,24) as bt, IsSell, BuyPrice, Number, Amount, BuyDate ");
            strSql.Append(" FROM StockSell ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

