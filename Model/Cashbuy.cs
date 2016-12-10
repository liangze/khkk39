using System;

namespace lgk.Model
{
    /// <summary>
    /// Cashbuy:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
    public partial class Cashbuy
    {
        public Cashbuy()
        { }
        #region Model

        /// <summary>
        /// 编号
        /// </summary>
        private long _cashbuyid;
        public long CashbuyID
        {
            get { return _cashbuyid; }
            set { _cashbuyid = value; }
        }
        /// <summary>
        /// 销售编号
        /// </summary>
        private long _cashsellid;
        public long CashsellID
        {
            get { return _cashsellid; }
            set { _cashsellid = value; }
        }
        /// <summary>
        /// 会员编号
        /// </summary>
        private long _userid;
        public long UserID
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
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        /// <summary>
        /// 购进数量
        /// </summary>
        private int _Number;
        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        /// <summary>
        /// 购进件数
        /// </summary>		
        private int _buynum;
        public int BuyNum
        {
            get { return _buynum; }
            set { _buynum = value; }
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
        /// 是否已购买完成（0下单，1发货中，2完成）
        /// </summary>
        private int _isbuy;
        public int IsBuy
        {
            get { return _isbuy; }
            set { _isbuy = value; }
        }

        #endregion
        private int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        private int _SellUserID;
        public int SellUserID
        {
            get { return _SellUserID; }
            set { _SellUserID = value; }
        }
        /// <summary>
        /// BankAccount
        /// </summary>		
        private string _bankaccount;
        public string BankAccount
        {
            get { return _bankaccount; }
            set { _bankaccount = value; }
        }
        /// <summary>
        /// BankAccountUser
        /// </summary>		
        private string _bankaccountuser;
        public string BankAccountUser
        {
            get { return _bankaccountuser; }
            set { _bankaccountuser = value; }
        }
        /// <summary>
        /// BankName
        /// </summary>		
        private string _bankname;
        public string BankName
        {
            get { return _bankname; }
            set { _bankname = value; }
        }
        /// <summary>
        /// BankBranch
        /// </summary>		
        private string _bankbranch;
        public string BankBranch
        {
            get { return _bankbranch; }
            set { _bankbranch = value; }
        }
        /// <summary>
        /// BankInProvince
        /// </summary>		
        private string _bankinprovince;
        public string BankInProvince
        {
            get { return _bankinprovince; }
            set { _bankinprovince = value; }
        }
        /// <summary>
        /// Image
        /// </summary>		
        private string _Image;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
    }
}
