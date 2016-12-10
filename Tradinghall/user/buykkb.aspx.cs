using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
namespace Tradinghall.user
{
    public partial class buykkb : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Text = GetLanguage("Submit");
            AspNetPager1.FirstPageText = GetLanguage("FirstPage");
            AspNetPager1.LastPageText = GetLanguage("LastPage");
            AspNetPager1.NextPageText = GetLanguage("NextPage");
            AspNetPager1.PrevPageText = GetLanguage("PrevPage");

            AspNetPager2.FirstPageText = GetLanguage("FirstPage");
            AspNetPager2.LastPageText = GetLanguage("LastPage");
            AspNetPager2.NextPageText = GetLanguage("NextPage");
            AspNetPager2.PrevPageText = GetLanguage("PrevPage");

            if (!IsPostBack)
            {
                BindData();
                BindData2();
            }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere3()
        {
            string strWhere = "IsSell=0 AND SaleNum>'0' and UserID<>" + getLoginID() + "AND(TypeID=2) AND Price<=" + getPrice() + " order by Price asc,SellDate asc";
            return strWhere;
        }
        /// <summary>
        ///查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "SaleNum>'0'AND IsSell=0 AND (TypeID=2) group by Price";
            return strWhere;
        }
        /// <summary>
        ///查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere1()
        {
            string strWhere1 = " TypeID=2 AND IsBuy=0 and BuyNum>'0' group by Price";
            return strWhere1;
        }
        /// <summary>
        /// 获取夸克币单价
        /// </summary>
        /// <returns></returns>
        public decimal getPrice()
        {
            decimal price = decimal.Parse(txtbuyprice.Value.Trim());
            return price;
        }

        private void BindData()
        {
            bind_repeater(cashsellBLL.GetList1(GetWhere()), Repeater1, "Price asc", tr1, AspNetPager1);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();

        }
        private void BindData2()
        {
            bind_repeater(cashbuyBLL.GetList1(GetWhere1()), Repeater2, "Price desc", tr2, AspNetPager2);
        }
        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindData2();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string isellid = txtbuyprice.Value.Trim();
            if (string.IsNullOrEmpty(isellid))
            {

                if (Language == "en-us")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Please choose to buy and sell Guadan！');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入价格！');", true);
                }
                return;
            }
            string strBuyNum = buyNum.Value.Trim();
            if (string.IsNullOrEmpty(strBuyNum))
            {

                if (Language == "en-us")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Please enter the number of buy！');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入买入数量！');", true);
                }
                return;
            }
            int iBuyNum = 0;
            if (!int.TryParse(strBuyNum, out iBuyNum))
            {
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('购买数量输入有误');", true);
                if (Language == "en-us")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Purchase quantity input error');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('购买数量输入有误');", true);
                }
                return;
            }
            #region 交易密码
            string strBuyPwd = paypwd.Value.Trim();
            if (string.IsNullOrEmpty(strBuyPwd))
            {
                if (Language == "en-us")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Please enter the transaction password！');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入交易密码！');", true);
                }
                return;
            }
            lgk.Model.tb_user buyUserModel = LoginUser;
            if (!PageValidate.GetMd5(strBuyPwd).Equals(buyUserModel.SecondPassword))
            {
                if (Language == "en-us")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Payment password input error！');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('支付密码输入错误！');", true);
                }
                return;
            }
            #endregion

            decimal QuaTra = getParamAmount("QuarkTra");//成功卖出夸克币 返回为交易点数比例参数
            decimal QuaTra1 = getParamAmount("QuarkTra1");//成功卖出夸克币 转为现金币比例参数
            decimal QuaTra2 = getParamAmount("QuarkTra2");//成功卖出夸克币 进入商城比例参数
            decimal QuaTra3 = getParamAmount("QuarkTra3");//成功卖出夸克币 手续费比例参数
            decimal QuarkT = getParamAmount("QuarkT");//买家买入夸克币 进入夸克币部分比例参数
            int buyNumber = iBuyNum;//输入的购买数量
            decimal buyprice = Convert.ToDecimal(txtbuyprice.Value.Trim());//输入的购买价格
            int jiNum = 0;
            int SurplusNum = buyNumber;

            decimal talmoney = buyNumber * buyprice;//需要总交易点数金额
            while (buyNumber > 0)
            {
                lgk.Model.Cashsell model = cashsellBLL.GetModel(GetWhere3());//获取挂单信息
                

                lgk.Model.tb_user userInfo = new lgk.Model.tb_user();//买家
                userInfo = userBLL.GetModel(getLoginID());

                if (userInfo.Emoney < talmoney)//判断账户交易点数余额
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("EcurrencyBalance") + "');", true);//                                                                                                                    //账户余额不足
                    return;
                }

                #region 扣除买家的交易点数
                lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                journalInfo.UserID = getLoginID();
                journalInfo.Remark = "购买夸克币";
                journalInfo.RemarkEn = "Buy quark coins";
                journalInfo.InAmount = 0;
                journalInfo.OutAmount = talmoney;
                journalInfo.BalanceAmount = userInfo.Emoney - talmoney;//结余账户余额;
                journalInfo.JournalDate = DateTime.Now;
                journalInfo.JournalType = 2;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                journalInfo.Journal01 = getLoginID();//
                journalBLL.Add(journalInfo);//增加一条数据

                UpdateAccount("Emoney", userInfo.UserID, talmoney, 0);//扣除的交易点数
                UpdateAccount("User015", userInfo.UserID, talmoney, 1);//冻结的交易点数
                #endregion

                if (model == null)
                {
                    decimal Paymoney = buyNumber * decimal.Parse(isellid);////购买支付的金额

                    //加入交易记录                                                           
                    lgk.Model.Cashbuy cashbuyinfo = new lgk.Model.Cashbuy();
                    cashbuyinfo.Amount = Paymoney;//购买支付的金额
                    cashbuyinfo.CashsellID = 0;//获取挂单ID
                    cashbuyinfo.BuyNum = buyNumber;//剩余委托购买数量
                    cashbuyinfo.Number = buyNumber;
                    cashbuyinfo.SellUserID = 0;//卖家ID
                    cashbuyinfo.UserID = getLoginID();//买家ID
                    cashbuyinfo.Price = buyprice;
                    cashbuyinfo.BuyDate = DateTime.Now;
                    cashbuyinfo.IsBuy = 0;//0是还没购买的订单，2是已购买的订单
                    cashbuyinfo.TypeID = 2;//商品金币类型 1，是注册点；2，是夸克币
                    long x = cashbuyBLL.Add(cashbuyinfo);//增加一条数据,并获取这条记录的Id

                    buyNumber = 0;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');location.href='buykkb.aspx';", true);//操作成功
                    break;
                }

                int sellID = int.Parse(model.UserID.ToString());//获取卖家ID
                if (buyNumber <= model.SaleNum)
                {
                    int SaleNum = model.SaleNum - buyNumber;//挂售订单剩余量
                    decimal Paymoney = buyNumber * decimal.Parse(model.Price.ToString());//购买支付的金额
                    decimal Amount = model.Amount - Paymoney;//更新挂单金额
                    //加入交易记录                                                           
                    lgk.Model.Cashbuy cashbuyinfo = new lgk.Model.Cashbuy();
                    cashbuyinfo.Amount = Paymoney;//购买支付的金额
                    cashbuyinfo.CashsellID = model.CashsellID;//获取挂单ID
                    cashbuyinfo.BuyNum = 0;//Convert.ToInt32(buyNum.Value.Trim());//购买数量
                    cashbuyinfo.Number = Convert.ToInt32(buyNum.Value.Trim());
                    cashbuyinfo.SellUserID = sellID;//卖家ID
                    cashbuyinfo.UserID = getLoginID();//买家ID
                    cashbuyinfo.Price = buyprice;
                    cashbuyinfo.BuyDate = DateTime.Now;
                    cashbuyinfo.IsBuy = 1;
                    cashbuyinfo.TypeID = 2;//商品金币类型 1，是注册点；2，是夸克币
                    long x = cashbuyBLL.Add(cashbuyinfo);//增加一条数据,并获取这条记录的Id

                    //写入订单
                    lgk.Model.Cashorder orderinfo = new lgk.Model.Cashorder();
                    string code = DateTime.Now.ToString("yyyyMMddhhmmssffff");//订单编号
                    orderinfo.BUserID = getLoginID();//买家ID
                    orderinfo.SUserID = sellID;//卖家ID
                    orderinfo.OrderCode = code;//订单编号
                    orderinfo.CashbuyID = x;
                    orderinfo.OrderDate = DateTime.Now;
                    orderinfo.PayDate = DateTime.Now;
                    orderinfo.SendDate = DateTime.Now;
                    orderinfo.BRemark = "夸克币交易";
                    orderinfo.SRemark = "夸克币交易";
                    orderinfo.CashsellID = model.CashsellID;
                    orderinfo.SStatus = 1;
                    orderinfo.Status = 1;
                    orderinfo.BStatus = 1;
                    cashorderBLL.Add(orderinfo);//加入订单

                    //卖家
                    lgk.Model.tb_user useinf = new lgk.Model.tb_user();
                    useinf = userBLL.GetModel(sellID);

                    #region 买家加入流水账表
                    decimal kuabNum = buyNumber * QuarkT / 100;//买入夸克币进入夸克币余额的部分
                    decimal guquNumb = buyNumber * (100 - QuarkT) / 100;//买入夸克币进入股权余额的部分
                    //夸克币
                    lgk.Model.tb_journal journInfo = new lgk.Model.tb_journal();
                    journInfo.UserID = getLoginID();
                    journInfo.Remark = "购买夸克币";
                    journInfo.RemarkEn = "Buy quark coins";
                    journInfo.InAmount = kuabNum;
                    journInfo.OutAmount = 0;
                    journInfo.BalanceAmount = userInfo.User011 + kuabNum;//结余账户余额;
                    journInfo.JournalDate = DateTime.Now;
                    journInfo.JournalType = 8;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    journInfo.Journal01 = sellID;// 出售者ID
                    journalBLL.Add(journInfo);//增加一条数据

                    //股权
                    lgk.Model.tb_journal journInfo1 = new lgk.Model.tb_journal();
                    journInfo1.UserID = getLoginID();
                    journInfo1.Remark = "购买夸克币";
                    journInfo1.RemarkEn = "Buy quark coins";
                    journInfo1.InAmount = guquNumb;//收入股权
                    journInfo1.OutAmount = 0;
                    journInfo1.BalanceAmount = userInfo.StockAccount + guquNumb;//结余账户余额;
                    journInfo1.JournalDate = DateTime.Now;
                    journInfo1.JournalType = 6;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    journInfo1.Journal01 = sellID;// 出售者ID
                    journalBLL.Add(journInfo1);//增加一条数据
                                               
                    //买家夸克币余额更新
                    UpdateAccount("User011", userInfo.UserID, kuabNum, 1);
                    UpdateAccount("StockAccount", userInfo.UserID, guquNumb, 1);
                    #endregion

                    decimal money = buyNumber * decimal.Parse(model.Price.ToString());
                    //买家冻结的交易点数变动
                    UpdateAccount("User015", userInfo.UserID, buyNumber * buyprice, 0);

                    #region 卖家加入流水账表
                    //卖家卖出夸克币获得交易点数
                    lgk.Model.tb_journal jonInfo = new lgk.Model.tb_journal();
                    jonInfo.UserID = sellID;
                    jonInfo.Remark = "卖出夸克币";
                    jonInfo.RemarkEn = "Sell quark coins";
                    jonInfo.InAmount = money * QuaTra / 100;
                    jonInfo.OutAmount = 0;
                    jonInfo.BalanceAmount = useinf.Emoney + money * QuaTra / 100;//结余账户余额;
                    jonInfo.JournalDate = DateTime.Now;
                    jonInfo.JournalType = 2;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    jonInfo.Journal01 = getLoginID();//购买者ID
                    journalBLL.Add(jonInfo);//增加一条数据

                    //卖家卖出夸克币获得现金币
                    lgk.Model.tb_journal joaanInfo = new lgk.Model.tb_journal();
                    joaanInfo.UserID = sellID;
                    joaanInfo.Remark = "卖出夸克币";
                    joaanInfo.RemarkEn = "Sell quark coins";
                    joaanInfo.InAmount = money * QuaTra1 / 100;
                    joaanInfo.OutAmount = 0;
                    joaanInfo.BalanceAmount = useinf.StockMoney + money * QuaTra1 / 100;//结余账户余额;
                    joaanInfo.JournalDate = DateTime.Now;
                    joaanInfo.JournalType = 4;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    joaanInfo.Journal01 = getLoginID();//购买者ID
                    journalBLL.Add(joaanInfo);//增加一条数据

                    //卖家卖出夸克币获得商城点数
                    lgk.Model.tb_journal joadanInfo = new lgk.Model.tb_journal();
                    joadanInfo.UserID = sellID;
                    joadanInfo.Remark = "卖出夸克币";
                    joadanInfo.RemarkEn = "Sell quark coins";
                    joadanInfo.InAmount = money * QuaTra2 / 100;
                    joadanInfo.OutAmount = 0;
                    joadanInfo.BalanceAmount = useinf.ShopAccount + money * QuaTra2 / 100;//结余账户余额;
                    joadanInfo.JournalDate = DateTime.Now;
                    joadanInfo.JournalType = 7;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    joadanInfo.Journal01 = getLoginID();//购买者ID
                    journalBLL.Add(joadanInfo);//增加一条数据
                    #endregion

                    #region 卖家账户数据更新
                    useinf.Emoney = useinf.Emoney + money * QuaTra / 100;
                    useinf.StockMoney = useinf.StockMoney + money * QuaTra1 / 100;
                    useinf.ShopAccount = useinf.ShopAccount + money * QuaTra2 / 100;
                    userBLL.Update(useinf);
                    #endregion

                    cashsellBLL.UpdateUndo(model.CashsellID, SaleNum, Amount);//更新订单剩余量  
                    if (SaleNum == 0)
                    {
                        cashsellBLL.UpdateUndo1(model.CashsellID, 1);//更新订单状态
                    }
                    jiNum = jiNum + buyNumber;
                    buyNumber = 0;
                }
                else if (buyNumber > model.SaleNum)
                {
                    int yuNumber = model.SaleNum; //购买的数量
                    int SaleNum = 0;//挂售订单剩余量
                    decimal payMoney = yuNumber * decimal.Parse(model.Price.ToString());//购买需要支付的金额
                    decimal Amount = model.Amount - payMoney;//更新挂单金额
                    //加入交易记录                                                           
                    lgk.Model.Cashbuy cashbuyinfo = new lgk.Model.Cashbuy();
                    cashbuyinfo.Amount = payMoney;//购买支付的金额
                    cashbuyinfo.CashsellID = model.CashsellID;//获取挂单ID
                    cashbuyinfo.BuyNum = 0;//model.SaleNum;//购买数量
                    cashbuyinfo.Number = model.SaleNum;
                    cashbuyinfo.SellUserID = sellID;//卖家ID
                    cashbuyinfo.UserID = getLoginID();//买家ID
                    cashbuyinfo.Price = buyprice;
                    cashbuyinfo.BuyDate = DateTime.Now;
                    cashbuyinfo.IsBuy = 1;
                    cashbuyinfo.TypeID = 2;//商品金币类型 1，是注册点；2，是夸克币
                    long x = cashbuyBLL.Add(cashbuyinfo);//增加一条数据,并获取这条记录的Id

                    //写入订单
                    lgk.Model.Cashorder orderinfo = new lgk.Model.Cashorder();
                    string code = DateTime.Now.ToString("yyyyMMddhhmmssffff");//订单编号
                    orderinfo.BUserID = getLoginID();//买家ID
                    orderinfo.SUserID = sellID;//卖家ID
                    orderinfo.OrderCode = code;//订单编号
                    orderinfo.CashbuyID = x;
                    orderinfo.OrderDate = DateTime.Now;
                    orderinfo.PayDate = DateTime.Now;
                    orderinfo.SendDate = DateTime.Now;
                    orderinfo.BRemark = "夸克币交易";
                    orderinfo.SRemark = "夸克币交易";
                    orderinfo.CashsellID = model.CashsellID;
                    orderinfo.SStatus = 1;
                    orderinfo.Status = 1;
                    orderinfo.BStatus = 1;
                    cashorderBLL.Add(orderinfo);//加入订单

                    //卖家
                    lgk.Model.tb_user useinf = new lgk.Model.tb_user();
                    useinf = userBLL.GetModel(sellID);

                    #region 买家加入流水账表
                    decimal kuabNum1 = yuNumber * QuarkT / 100;//买入夸克币进入夸克币余额的部分
                    decimal guquNum = yuNumber * (100 - QuarkT) / 100;//买入夸克币进入股权余额的部分
                    //夸克币
                    lgk.Model.tb_journal journInfo = new lgk.Model.tb_journal();
                    journInfo.UserID = getLoginID();
                    journInfo.Remark = "购买夸克币";
                    journInfo.RemarkEn = "Buy quark coins";
                    journInfo.InAmount = kuabNum1;//收入夸克币数
                    journInfo.OutAmount = 0;
                    journInfo.BalanceAmount = userInfo.User011 + kuabNum1;//结余账户余额;
                    journInfo.JournalDate = DateTime.Now;
                    journInfo.JournalType = 8;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    journInfo.Journal01 = sellID;// 出售者ID
                    journalBLL.Add(journInfo);//增加一条数据
                    //股权
                    lgk.Model.tb_journal journInfo1 = new lgk.Model.tb_journal();
                    journInfo1.UserID = getLoginID();
                    journInfo1.Remark = "购买夸克币";
                    journInfo1.RemarkEn = "Buy quark coins";
                    journInfo1.InAmount = guquNum;//收入股权
                    journInfo1.OutAmount = 0;
                    journInfo1.BalanceAmount = userInfo.StockAccount + guquNum;//结余账户余额;
                    journInfo1.JournalDate = DateTime.Now;
                    journInfo1.JournalType = 6;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    journInfo1.Journal01 = sellID;// 出售者ID
                    journalBLL.Add(journInfo1);//增加一条数据

                    //买家账户余额更新
                    UpdateAccount("User011", userInfo.UserID, kuabNum1, 1);
                    UpdateAccount("StockAccount", userInfo.UserID, guquNum, 1);
                    #endregion

                    decimal money = yuNumber * decimal.Parse(model.Price.ToString());
                    //买家冻结的交易点数变动
                    UpdateAccount("User015", userInfo.UserID, yuNumber * buyprice, 0);

                    #region 卖家加入流水账表
                    //卖家卖出夸克币获得交易点数
                    lgk.Model.tb_journal jonInfo = new lgk.Model.tb_journal();
                    jonInfo.UserID = sellID;
                    jonInfo.Remark = "卖出夸克币";
                    jonInfo.RemarkEn = "Sell quark coins";
                    jonInfo.InAmount = money * QuaTra / 100;
                    jonInfo.OutAmount = 0;
                    jonInfo.BalanceAmount = useinf.Emoney + money * QuaTra / 100;//结余账户余额;
                    jonInfo.JournalDate = DateTime.Now;
                    jonInfo.JournalType = 2;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    jonInfo.Journal01 = getLoginID();//购买者ID
                    journalBLL.Add(jonInfo);//增加一条数据

                    //卖家卖出夸克币获得现金币
                    lgk.Model.tb_journal joaanInfo = new lgk.Model.tb_journal();
                    joaanInfo.UserID = sellID;
                    joaanInfo.Remark = "卖出夸克币";
                    joaanInfo.RemarkEn = "Sell quark coins";
                    joaanInfo.InAmount = money * QuaTra1 / 100;
                    joaanInfo.OutAmount = 0;
                    joaanInfo.BalanceAmount = useinf.StockMoney + money * QuaTra1 / 100;//结余账户余额;
                    joaanInfo.JournalDate = DateTime.Now;
                    joaanInfo.JournalType = 4;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    joaanInfo.Journal01 = getLoginID();//购买者ID
                    journalBLL.Add(joaanInfo);//增加一条数据

                    //卖家卖出夸克币获得商城点数
                    lgk.Model.tb_journal joadanInfo = new lgk.Model.tb_journal();
                    joadanInfo.UserID = sellID;
                    joadanInfo.Remark = "卖出夸克币";
                    joadanInfo.RemarkEn = "Sell quark coins";
                    joadanInfo.InAmount = money * QuaTra2 / 100;
                    joadanInfo.OutAmount = 0;
                    joadanInfo.BalanceAmount = useinf.ShopAccount + money * QuaTra2 / 100;//结余账户余额;
                    joadanInfo.JournalDate = DateTime.Now;
                    joadanInfo.JournalType = 7;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    joadanInfo.Journal01 = getLoginID();//购买者ID
                    journalBLL.Add(joadanInfo);//增加一条数据
                    #endregion

                    #region 卖家账户数据更新
                    useinf.Emoney = useinf.Emoney + money * QuaTra / 100;
                    useinf.StockMoney = useinf.StockMoney + money * QuaTra1 / 100;
                    useinf.ShopAccount = useinf.ShopAccount + money * QuaTra2 / 100;
                    userBLL.Update(useinf);
                    #endregion

                    cashsellBLL.UpdateUndo(model.CashsellID, SaleNum, Amount);//更新订单剩余量
                    if (SaleNum == 0)
                    {
                        cashsellBLL.UpdateUndo1(model.CashsellID, 1);//更新订单状态
                    }
                    buyNumber = buyNumber - yuNumber;
                    jiNum = jiNum + yuNumber;
                }

                if (buyNumber == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');location.href='buykkb.aspx';", true);//操作成功
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("buySuccessfully") +jiNum+ "');window.location.href='buykkb.aspx';", true);//操作成功
                    return;
                }

            }

        }
    }
}
