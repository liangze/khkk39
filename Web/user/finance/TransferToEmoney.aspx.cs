using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using lgk.Model;

namespace Web.user.finance
{
    public partial class TransferToEmoney : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Text = GetLanguage("Submit");
            AspNetPager1.FirstPageText = GetLanguage("FirstPage");
            AspNetPager1.LastPageText = GetLanguage("LastPage");
            AspNetPager1.NextPageText = GetLanguage("NextPage");
            AspNetPager1.PrevPageText = GetLanguage("PrevPage");
            /* spd.jumpUrl1(this.Page, 1);*///跳转二级密码

            if (!IsPostBack)
            {
                //txtBonusAccount.Value = LoginUser.BonusAccount.ToString();//注册点
                //txtEmoney.Value = LoginUser.Emoney.ToString();//现金币余额
                //txtStockMoney.Value = LoginUser.GLmoney.ToString();//购物币余额

                BindCurrency();
                BindData();
                btnSubmit.Text = GetLanguage("Submit");//提交
                btnSubmit.OnClientClick = "javascript:return confirm('" + GetLanguage("TransferConfirm") + "')";
                btnSearch.Text = GetLanguage("Search");//搜索
            }
        }

        private void BindCurrency()
        {
            if (GetLanguage("LoginLable") == "zh-cn")
            {
                dropCurrency.Items.Add(new ListItem("-请选择-", "0"));
                dropCurrency.Items.Add(new ListItem("佣金点数转注册点数", "1"));
                dropCurrency.Items.Add(new ListItem("交易点数转注册点数", "2"));
                dropCurrency.Items.Add(new ListItem("现金币转注册点数", "3"));
                dropCurrency.Items.Add(new ListItem("注册点数转交易点数", "4"));
                dropCurrency.Items.Add(new ListItem("转其他会员激活点数", "5"));
                dropCurrency.Items.Add(new ListItem("转其他会员注册点数", "6"));
                dropCurrency.Items.Add(new ListItem("转其他会员夸克币", "7"));



                dropType.Items.Add(new ListItem("-请选择-", "0"));
                dropType.Items.Add(new ListItem("佣金点数转注册点数", "1"));
                dropType.Items.Add(new ListItem("交易点数转注册点数", "2"));
                dropType.Items.Add(new ListItem("现金币注册点数", "3"));
                dropType.Items.Add(new ListItem("注册点数转交易点数", "4"));
                dropType.Items.Add(new ListItem("转其他会员激活点数", "5"));
                dropType.Items.Add(new ListItem("转其他会员注册点数", "6"));
                dropType.Items.Add(new ListItem("转其他会员夸克币", "7"));
            }
            else
            {
                dropCurrency.Items.Add(new ListItem("-Please choose-", "0"));
                dropCurrency.Items.Add(new ListItem("Commission points to register points", "1"));
                dropCurrency.Items.Add(new ListItem("Trading points to register points", "2"));
                dropCurrency.Items.Add(new ListItem("Cash currency to register points", "3"));
                dropCurrency.Items.Add(new ListItem("Registered points to transfer transactions", "4"));
                dropCurrency.Items.Add(new ListItem("Activation points to other members", "5"));
                dropCurrency.Items.Add(new ListItem("Quark coin to other members", "6"));
                dropCurrency.Items.Add(new ListItem("Registered points to other members", "7"));
               

                dropType.Items.Add(new ListItem("-Please choose-", "0"));
                dropType.Items.Add(new ListItem("Commission points to register points", "1"));
                dropType.Items.Add(new ListItem("Trading points to register points", "2"));
                dropType.Items.Add(new ListItem("Cash currency to register points", "3"));
                dropType.Items.Add(new ListItem("Registered points to transfer transactions", "4"));
                dropType.Items.Add(new ListItem("Activation points to other members", "5"));
                dropType.Items.Add(new ListItem("Quark coin to other members", "6"));
                dropType.Items.Add(new ListItem("Registered points to other members", "7"));
            }
        }

        private bool CheckOpen(string value)
        {
            switch (value)
            {
                case "1":
                    var iOpen1 = getParamInt("Transfer4");
                    if (iOpen1 != 1)//佣金点数转注册点数
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "2":
                    var iOpen2 = getParamAmount("Transfer5");
                    if (iOpen2 != 1)//交易点数转注册点数
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "3":
                    var iOpen3 = getParamAmount("Transfer6");
                    if (iOpen3 != 1)//现金币注册点数
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "4":
                    var iOpen4 = getParamAmount("Transfer7");
                    if (iOpen4 != 1)//注册点数转交易点数
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "5":
                    var iOpen5 = getParamAmount("Transfer8");
                    if (iOpen5 != 1)//转其他会员激活点数
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "6":
                    var iOpen6 = getParamAmount("Transfer9");
                    if (iOpen6 != 1)//转其他会员注册点数
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                case "7":
                    var iOpen7 = getParamAmount("Transfer10");
                    if (iOpen7 != 1)//转其他会员夸克币
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                        return false;
                    }
                    break;
                default://请选择转账类型
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("ChooseTransfer") + "');", true);
                    return false;
            }
            return true;
        }

        protected void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            string strUserCode = txtUserCode.Text.Trim();
            var user = userBLL.GetModel(" UserCode='" + strUserCode + "'");
            if (user != null)
            {
                txtTrueName.Text = user.TrueName;
            }
            else
            {
                txtTrueName.Text = string.Empty;
                MessageBox.Show(this, GetLanguage("numberIsExist"));//会员编号不存在
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long toUserID = 0;
            lgk.Model.tb_user userInfo = userBLL.GetModel(getLoginID());
            lgk.Model.tb_change changeInfo = new lgk.Model.tb_change();

            if (dropCurrency.SelectedValue == "0")
            {
                MessageBox.Show(this, "" + GetLanguage("ChooseTransfer") + "");//请选择转账类型
                return;
            }
            if (!CheckOpen(dropCurrency.SelectedValue))
            {
                MessageBox.Show(this, "" + GetLanguage("Feature") + "");//该功能未开放
                return;
            }
            int iTypeID = int.Parse(dropCurrency.SelectedValue);
            if (txtMoney.Text.Trim() == "")
            {
                MessageBox.Show(this, "" + GetLanguage("transferMoneyIsnull") + "");//转账金额不能为空
                return;
            }

            decimal dResult = 0;
            if (decimal.TryParse(txtMoney.Text.Trim(), out dResult))
            {
                decimal dTrans = getParamAmount("Transfer1");//转账最低金额
                decimal d = getParamAmount("Transfer2");//转账倍数基数
                if (dResult < dTrans)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("equalTo") + dTrans + "');", true);//转账金额必须是大于等于XX的整数
                    return;
                }
                if (d != 0 && dResult % d != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("amountMustbe") + "" + d + "" + GetLanguage("Multiples") + "');", true);//转账金额必须是XX的倍数
                    return;
                }
            }

            if (iTypeID != 0)
            {   
                //判断账户余额是否足够转账
                if (iTypeID == 1 && dResult > userInfo.AllBonusAccount)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NotCurrent") + "');", true);
                    //佣金点数账户余额不足
                    return;
                }
              //  佣金点数 AllBonusAccount
              //  注册点数 BonusAccount
              //   交易点数 Emoney
              //   现金币 StockMoney
              //    激活点数 GLmoney
              // 股权 StockAccount
              // 商城点数 ShopAccount
              //   夸克币 User011
              //  持币 User012
              //存币 User013

                else if (iTypeID == 2 && dResult > userInfo.Emoney)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);
                    return;
                }
                else if (iTypeID == 3 && dResult > userInfo.StockMoney)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);
                    return;
                }
                else if (iTypeID == 4 && dResult > userInfo.BonusAccount)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);
                    return;
                }
                else if (iTypeID == 5 && dResult > userInfo.GLmoney)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);
                    return;
                }
                else if (iTypeID == 6 && dResult > userInfo.BonusAccount)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);
                    return;
                }
                else if (iTypeID == 7 && dResult > userInfo.User011)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);
                    return;
                }
            }

            string strUserCode = txtUserCode.Text.Trim();
            var toUser = userBLL.GetModel(" UserCode='" + strUserCode + "'");
            if (toUser == null)
            {
                MessageBox.Show(this, GetLanguage("numberIsExist"));//会员编号不存在
                return;
            }
            else
            {
                toUserID = int.Parse(toUser.UserID.ToString());
            }

            if (toUserID <= 0)
            {
                MessageBox.Show(this, GetLanguage("objectExist"));//转帐对象不存在
                return;
            }

            if (dropCurrency.SelectedValue == "5")
            {
                if (toUserID == userInfo.UserID)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("TransferToOuner") + "');", true);
                    return;
                }

                if (!userBLL.OnRecommendSameLine(userInfo.UserID, toUserID))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("objectExist") + "');", true);
                    return;
                }
            }

            changeInfo.UserID = getLoginID();
            changeInfo.ToUserID = toUserID;
            changeInfo.ToUserType = 0;
            changeInfo.MoneyType = 0;
            changeInfo.Amount = dResult;
            changeInfo.ChangeType = Convert.ToInt32(dropCurrency.SelectedValue);
            changeInfo.ChangeDate = DateTime.Now;
            

           
            try
            {
                if (changeInfo.ChangeType == 1)//佣金点数转注册点数
                {
                    changeInfo.Change005 = dResult;
                    #region 佣金点数转注册点数
                    decimal dBonusAccount = userBLL.GetMoney(getLoginID(), "AllBonusAccount");
                    if (dBonusAccount >= changeInfo.Amount)
                    {
                        UpdateAccount("AllBonusAccount", userInfo.UserID, changeInfo.Amount, 0);//佣金点数
                        UpdateAccount("BonusAccount", toUserID, changeInfo.Change005, 1);//注册点数
                        
                        //加入流水账表（佣金点减少）
                        lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                        model.UserID = userInfo.UserID;
                        model.Remark = "佣金点数转注册点数";
                        model.RemarkEn = "Commission points to register points";
                        model.InAmount = 0;
                        model.OutAmount = changeInfo.Amount;

                        model.BalanceAmount = userBLL.GetMoney(getLoginID(), "AllBonusAccount");
                        model.JournalDate = DateTime.Now;
                        model.JournalType = 3;
                        model.Journal01 = toUserID;
                        journalBLL.Add(model);

                        //加入流水账表(注册点数增加)
                        lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                        journalInfo.UserID = toUserID;
                        journalInfo.Remark = "佣金点数转注册点数";
                        journalInfo.RemarkEn = "Commission points to register points";
                        journalInfo.InAmount = changeInfo.Change005;
                        journalInfo.OutAmount = 0;
                        journalInfo.BalanceAmount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                        journalInfo.JournalDate = DateTime.Now;
                        journalInfo.JournalType = 1;
                        journalInfo.Journal01 = userInfo.UserID;

                        journalBLL.Add(journalInfo);
                        changeBLL.Add(changeInfo);//添加转账记录
                            MessageBox.ShowAndRedirect(this, GetLanguage("TransferSuccess"), "TransferToEmoney.aspx");//转账成功
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);//账户余额不足
                    }
                    #endregion
                }
                else if (changeInfo.ChangeType == 2)//交易点数转注册点数
                {
                    changeInfo.Change005 = dResult;
                    //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    #region 交易点数转注册点数
                    decimal dBonusAccount = userBLL.GetMoney(getLoginID(), "Emoney");
                    if (dBonusAccount >= changeInfo.Amount)
                    {
                        changeInfo.Change005 = dResult;
                        UpdateAccount("Emoney", userInfo.UserID, changeInfo.Amount, 0);//交易点数
                        UpdateAccount("BonusAccount", toUserID, changeInfo.Change005, 1);//注册点数

                         //加入流水账表（交易点减少）
                        lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                        jmodel.UserID = userInfo.UserID;
                        jmodel.Remark = "交易点数转注册点数";
                        jmodel.RemarkEn = "Trading points to register points";
                        jmodel.InAmount = 0;
                        jmodel.OutAmount = changeInfo.Amount;

                        jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "Emoney");
                        jmodel.JournalDate = DateTime.Now;
                        jmodel.JournalType = 2;
                        jmodel.Journal01 = toUserID;
                        journalBLL.Add(jmodel);
                        //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                        //加入流水账表(注册点数增加)
                        lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                        journalInfo.UserID = toUserID;
                        journalInfo.Remark = "交易点数转注册点数";
                        journalInfo.RemarkEn = "Trading points to register points";
                        journalInfo.InAmount = changeInfo.Change005;
                        journalInfo.OutAmount = 0;
                        journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "BonusAccount");
                        journalInfo.JournalDate = DateTime.Now;
                        journalInfo.JournalType = 1;
                        journalInfo.Journal01 = userInfo.UserID;
                        journalBLL.Add(journalInfo);
                        changeBLL.Add(changeInfo);//添加转账记录
                        MessageBox.ShowAndRedirect(this, GetLanguage("TransferSuccess"), "TransferToEmoney.aspx");//转账成功
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);//账户余额不足
                    }
                    #endregion
                }
                else if (changeInfo.ChangeType == 3)//现金币注册点数
                {
                    changeInfo.Change005 = dResult;
                    #region 现金币注册点数
                    decimal dBonusAccount = userBLL.GetMoney(getLoginID(), "StockMoney");//获取当前账户现金币余额
                    if (dBonusAccount >= changeInfo.Amount)
                    {
                        UpdateAccount("StockMoney", userInfo.UserID, changeInfo.Amount, 0);//现金币
                        UpdateAccount("BonusAccount", toUserID, changeInfo.Change005, 1);//注册点数
                         //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                        //加入流水账表（现金币减少）
                        lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                        jmodel.UserID = userInfo.UserID;
                        jmodel.Remark = "现金币转注册点数";
                        jmodel.RemarkEn = "Cash currency to register points";
                        jmodel.InAmount = 0;
                        jmodel.OutAmount = changeInfo.Amount;
                        jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "StockMoney");
                        jmodel.JournalDate = DateTime.Now;
                        jmodel.JournalType = 4;
                        jmodel.Journal01 = toUserID;
                        journalBLL.Add(jmodel);

                        //加入流水账表(交易点增加)
                        lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                        journalInfo.UserID = toUserID;
                        journalInfo.Remark = "现金币可以转交易点数";
                        journalInfo.RemarkEn = "Cash currency to register points";
                        journalInfo.InAmount = changeInfo.Change005;
                        journalInfo.OutAmount = 0;
                        journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "BonusAccount");
                        journalInfo.JournalDate = DateTime.Now;
                        journalInfo.JournalType = 1;
                        journalInfo.Journal01 = userInfo.UserID;
                        journalBLL.Add(journalInfo);
                        changeBLL.Add(changeInfo);//添加转账记录
                        MessageBox.ShowAndRedirect(this, GetLanguage("TransferSuccess"), "TransferToEmoney.aspx");//转账成功
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);//账户余额不足
                    }
                    #endregion
                }
                else if (changeInfo.ChangeType == 4)//注册点数转交易点数
                {
                    changeInfo.Change005 = dResult;
                    #region 注册点数转交易点数
                    decimal dStockAccount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                    if (dStockAccount >= changeInfo.Amount)
                    {
                        UpdateAccount("BonusAccount", userInfo.UserID, changeInfo.Amount, 0);//注册点数
                        UpdateAccount("Emoney", toUserID, changeInfo.Change005, 1);//交易点数
                          //加入流水账表（注册点减少）
                        //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                        lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                        jmodel.UserID = userInfo.UserID;
                        jmodel.Remark = "注册点数转交易点数";
                        jmodel.RemarkEn = "Registered points to transfer transactions";
                        jmodel.InAmount = 0;
                        jmodel.OutAmount = changeInfo.Amount;
                        jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                        jmodel.JournalDate = DateTime.Now;
                        jmodel.JournalType = 1;
                        jmodel.Journal01 = toUserID;
                        journalBLL.Add(jmodel);

                        //加入流水账表(交易点增加)
                        lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                        journalInfo.UserID = toUserID;
                        journalInfo.Remark = "注册点数转交易点数";
                        journalInfo.RemarkEn = "Registered points to transfer transactions";
                        journalInfo.InAmount = changeInfo.Change005;
                        journalInfo.OutAmount = 0;
                        journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "Emoney");
                        journalInfo.JournalDate = DateTime.Now;
                        journalInfo.JournalType = 2;
                        journalInfo.Journal01 = userInfo.UserID;
                        journalBLL.Add(journalInfo);
                        changeBLL.Add(changeInfo);//添加转账记录
                        MessageBox.ShowAndRedirect(this, GetLanguage("TransferSuccess"), "TransferToEmoney.aspx");//转账成功
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);//账户余额不足
                    }
                    #endregion
                }
                else if (changeInfo.ChangeType == 5)//转其他会员激活点数
                {
                    changeInfo.Change005 = dResult;//- dResult * getParamAmount("Transfer3") / 100;
                    #region 转其他会员激活点数
                    decimal dStockAccount = userBLL.GetMoney(getLoginID(), "GLmoney");
                    if (dStockAccount >= changeInfo.Amount)
                    {
                        UpdateAccount("GLmoney", userInfo.UserID, changeInfo.Amount, 0);//
                        UpdateAccount("GLmoney", toUserID, changeInfo.Change005, 1);//
                                                                                    //加入流水账表（激活点减少）
                        lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                        jmodel.UserID = userInfo.UserID;
                        jmodel.Remark = "激活点转给" + txtUserCode.Text;
                        jmodel.RemarkEn = "Activation points to " + txtUserCode.Text;
                        jmodel.InAmount = 0;
                        jmodel.OutAmount = changeInfo.Amount;
                        jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "GLmoney");
                        jmodel.JournalDate = DateTime.Now;
                        jmodel.JournalType = 5;
                        jmodel.Journal01 = toUserID;
                        journalBLL.Add(jmodel);

                        //加入流水账表(激活点增加)
                        lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                        journalInfo.UserID = toUserID;
                        journalInfo.Remark = "获得" + LoginUser.UserCode + "转来激活点";
                        journalInfo.RemarkEn = "Get " + LoginUser.UserCode + " Transfer Activation points";
                        journalInfo.InAmount = changeInfo.Change005;
                        journalInfo.OutAmount = 0;
                        journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "GLmoney");
                        journalInfo.JournalDate = DateTime.Now;
                        journalInfo.JournalType = 5;
                        journalInfo.Journal01 = userInfo.UserID;
                        journalBLL.Add(journalInfo);
                        changeBLL.Add(changeInfo);//添加转账记录
                        MessageBox.ShowAndRedirect(this, GetLanguage("TransferSuccess"), "TransferToEmoney.aspx");//转账成功
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);//账户余额不足
                    }
                    #endregion
                }
                else if (changeInfo.ChangeType == 6)//转其他会员注册点数
                {
                    changeInfo.Change005 = dResult;// - dResult * getParamAmount("Transfer3") / 100;
                    #region 转其他会员注册点数
                    decimal dStockAccount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                    if (dStockAccount >= changeInfo.Amount)
                    {
                        UpdateAccount("BonusAccount", userInfo.UserID, changeInfo.Amount, 0);//
                        UpdateAccount("BonusAccount", toUserID, changeInfo.Change005, 1);//
                                                                                         //加入流水账表（注册点减少）
                        lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                        jmodel.UserID = userInfo.UserID;
                        jmodel.Remark = "注册点转给" + txtUserCode.Text;
                        jmodel.RemarkEn = "Registered currency to " + txtUserCode.Text;
                        jmodel.InAmount = 0;
                        jmodel.OutAmount = changeInfo.Amount;
                        jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                        jmodel.JournalDate = DateTime.Now;
                        jmodel.JournalType = 1;
                        //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                        jmodel.Journal01 = toUserID;
                        journalBLL.Add(jmodel);

                        //加入流水账表(注册点增加)
                        lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                        journalInfo.UserID = toUserID;
                        journalInfo.Remark = "获得" + LoginUser.UserCode + "转来注册点";
                        journalInfo.RemarkEn = "Get " + LoginUser.UserCode + " Transfer Registered currency";
                        journalInfo.InAmount = changeInfo.Change005;
                        journalInfo.OutAmount = 0;
                        journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "BonusAccount");
                        journalInfo.JournalDate = DateTime.Now;
                        journalInfo.JournalType = 1;
                        journalInfo.Journal01 = userInfo.UserID;
                        journalBLL.Add(journalInfo);
                        changeBLL.Add(changeInfo);//添加转账记录
                        MessageBox.ShowAndRedirect(this, GetLanguage("TransferSuccess"), "TransferToEmoney.aspx");//转账成功
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);//账户余额不足
                    }
                    #endregion
                }
                else if (changeInfo.ChangeType == 7)//转其他会员夸克币
                {
                    changeInfo.Change005 = dResult;//
                    decimal dmoney= dResult + dResult * getParamAmount("Transfer3") / 100;//转出方扣除的金额
                    #region 转其他会员夸克币
                    decimal dStockAccount = userBLL.GetMoney(getLoginID(), "User011");
                    if (dStockAccount >= changeInfo.Amount)
                    {
                        UpdateAccount("User011", userInfo.UserID, dmoney, 0);//
                        UpdateAccount("User011", toUserID, changeInfo.Change005, 1);//
                                                                                    //加入流水账表（夸克币减少）
                        lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                        jmodel.UserID = userInfo.UserID;
                        jmodel.Remark = "夸克币转给" + txtUserCode.Text;
                        jmodel.RemarkEn = "Quark coin to " + txtUserCode.Text;
                        jmodel.InAmount = 0;
                        jmodel.OutAmount = dmoney;
                        jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "User011");
                        jmodel.JournalDate = DateTime.Now;
                        jmodel.JournalType = 8;
                        //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                        jmodel.Journal01 = toUserID;
                        journalBLL.Add(jmodel);

                        //加入流水账表(夸克币增加)
                        lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                        journalInfo.UserID = toUserID;
                        journalInfo.Remark = "获得" + LoginUser.UserCode + "转来夸克币";
                        journalInfo.RemarkEn = "Get " + LoginUser.UserCode + " Transfer Quark coin";
                        journalInfo.InAmount = dResult;//changeInfo.Change005;
                        journalInfo.OutAmount = 0;
                        journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "User011");
                        journalInfo.JournalDate = DateTime.Now;
                        journalInfo.JournalType = 8;
                        journalInfo.Journal01 = userInfo.UserID;
                        journalBLL.Add(journalInfo);
                        changeBLL.Add(changeInfo);//添加转账记录
                        MessageBox.ShowAndRedirect(this, GetLanguage("TransferSuccess"), "TransferToEmoney.aspx");//转账成功
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhanghyue") + "');", true);//账户余额不足
                    }
                    #endregion
                }
            }
            catch
            {
                MessageBox.Show(this, GetLanguage("addError"));//添加流水账错误
            }
        }

        private string GetWhere()
        {
            string strWhere = string.Format(" and c.UserID=" + getLoginID());

            if (dropType.SelectedValue != "0")
            {
                strWhere += " AND c.ChangeType = " + dropType.SelectedValue + "";
            }

            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();
            if (GetLanguage("LoginLable") == "en-us")
            {
                strStartTime = this.txtStartEn.Text.Trim();
                strEndTime = this.txtEndEn.Text.Trim();
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) between '" + strStartTime + "' and '" + strEndTime + "' ");
            }
            return strWhere;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData()
        {
            bind_repeater(changeBLL.GetDataSet(GetWhere()), Repeater1, "ChangeDate desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 根据选择級別获取金額
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dropCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (dropCurrency.SelectedValue == "5")//设置会员输入框的显示
            {
                txtUserCode.Enabled = true;
                txtUserCode.Text = string.Empty;
                txtTrueName.Text = string.Empty;
            }
            else if (dropCurrency.SelectedValue == "6")
            {
                txtUserCode.Enabled = true;
                txtUserCode.Text = string.Empty;
                txtUserCode.Text = string.Empty;
            }
            else if (dropCurrency.SelectedValue == "7")
            {
                txtUserCode.Enabled = true;
                txtUserCode.Text = string.Empty;
                txtUserCode.Text = string.Empty;
            }
            else
            {
                txtUserCode.Enabled = false;
                txtUserCode.Text = LoginUser.UserCode;
                txtTrueName.Text = LoginUser.TrueName;
            }
        }

        protected void txtMoney_TextChanged(object sender, EventArgs e)
        {
            string strMoney = txtMoney.Text.Trim();
            int y= int.Parse(dropCurrency.SelectedValue);
            if (strMoney != "")
            {
                decimal dMoney = decimal.Parse(strMoney);
                lgk.Model.tb_change changeInfo = new lgk.Model.tb_change();
                if (y == 7)
                {
                    decimal dValue = dMoney;//- dMoney * getParamAmount("Transfer3") / 100;

                    txtActualAmount.Value = dValue.ToString();
                }
                else
                {
                    
                    txtActualAmount.Value = dMoney.ToString();
                }
                
            }
        }

    }
}