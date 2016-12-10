using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //StockSell
    public class StockSell
    {

        /// <summary>
        /// 编号
        /// </summary>		
        private long _stockid;
        public long StockID
        {
            get { return _stockid; }
            set { _stockid = value; }
        }
        /// <summary>
        /// 会员编号
        /// </summary>		
        private int _userid;
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 购买金额
        /// </summary>		
        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        /// <summary>
        /// 购进价格
        /// </summary>		
        private decimal _buyprice;
        public decimal BuyPrice
        {
            get { return _buyprice; }
            set { _buyprice = value; }
        }
        /// <summary>
        /// 购进价格(拆分价格)
        /// </summary>		
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        /// <summary>
        /// 当前持股数
        /// </summary>		
        private int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        /// <summary>
        /// 股票剩余量
        /// </summary>		
        private int _surplus;
        public int Surplus
        {
            get { return _surplus; }
            set { _surplus = value; }
        }
        /// <summary>
        /// 购进时拆分次数
        /// </summary>		
        private int _splitnum;
        public int SplitNum
        {
            get { return _splitnum; }
            set { _splitnum = value; }
        }
        /// <summary>
        /// 购买时间
        /// </summary>		
        private DateTime _buydate;
        public DateTime BuyDate
        {
            get { return _buydate; }
            set { _buydate = value; }
        }
        /// <summary>
        /// 是否已冻结（0未冻结,1已冻结）
        /// </summary>		
        private int _islock;
        public int IsLock
        {
            get { return _islock; }
            set { _islock = value; }
        }
        /// <summary>
        /// 是否挂单卖出(0持有，1挂单，2已生成订单卖出中,3已卖出。注：1为系统自动挂单时才出现，如果手动挂单，则直接变成2状态)
        /// </summary>		
        private int _issell;
        public int IsSell
        {
            get { return _issell; }
            set { _issell = value; }
        }
        /// <summary>
        /// 销售方式（0系统挂单，1手动挂单）
        /// </summary>		
        private int _salestype;
        public int SalesType
        {
            get { return _salestype; }
            set { _salestype = value; }
        }
        /// <summary>
        /// 是否为回购类股票（0否，1是）
        /// </summary>		
        private int _isback;
        public int IsBack
        {
            get { return _isback; }
            set { _isback = value; }
        }

    }
}

