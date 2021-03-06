﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;
using System.Collections.Generic;
using System.Globalization;

namespace Web.user.finance
{
    public partial class TakeMoney : PageCore
    {
        //private decimal week = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.FirstPageText = GetLanguage("FirstPage");
            AspNetPager1.LastPageText = GetLanguage("LastPage");
            AspNetPager1.NextPageText = GetLanguage("NextPage");
            AspNetPager1.PrevPageText = GetLanguage("PrevPage");
            /* spd.jumpUrl1(this.Page, 1);*///跳转二级密码

            if (!IsPostBack)
            {
                ShowData();
                BindData();
                btnSearch.Text = GetLanguage("Search");//搜索
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

       /// <summary>
       /// 提现金额
       /// </summary>
        private void ShowData()
        {
            decimal dMin = getParamAmount("ATM1");

            txtBonusAccount.Value = LoginUser.StockMoney.ToString("0.00") + GetLanguage("USD");

            //if (LoginUser.BonusAccount >= dMin)
            //{
            //    btnSubmit.Visible = true;
            //}
            //else
            //{
            //    btnSubmit.Visible = false;
            //}
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = " u.UserID=" + getLoginID() + "";
            string strStart = txtStart.Text.Trim();
            string strEnd = txtEnd.Text.Trim();

            if (strStart != "" && strEnd == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),RegTime,120) >= '" + strStart + "'");
            }
            else if (strStart == "" && strEnd != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  <= '" + strEnd + "'");
            }
            else if (strStart != "" && strEnd != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  between '" + strStart + "' and '" + strEnd + "'");
            }
            return strWhere;
        }

        /// <summary>
        /// 填充
        /// </summary>
        protected void BindData()
        {
            bind_repeater(GetTakeList(GetWhere()), Repeater1, "TakeTime desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region 数据验证
            //string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            //week = Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"));
            //var open2 = getParamAmount("extract4");
            //if (week != open2)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请在提现日进行此功能操作，谢谢!');", true);
            //    return;
            //}
            
            lgk.Model.tb_takeMoney takeflag = takeBLL.GetModel(" UserID="+getLoginID()+" order by TakeTime desc");
            lgk.Model.tb_user stmoney = userBLL.GetModel(getLoginID());
            if(stmoney.StockMoney<decimal.Parse( txtTake.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("EcurrencyBalance") + "');", true);//现金币余额不足
            }
            if (takeflag != null)
            {
                if (takeflag.Flag == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("TaxMoneya") + "');", true);//您的提现尚未审核，不能再次申请
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您的提现尚未审核，不能再次申请');", true);//
                    return;
                }

                DateTime dtnow = DateTime.Now;
                GregorianCalendar gc = new GregorianCalendar();

                DayOfWeek df = DayOfWeek.Monday;
                int year1 = dtnow.Year;
                int year2 = takeflag.TakeTime.Year;
                int weekOfYear = gc.GetWeekOfYear(dtnow, CalendarWeekRule.FirstDay, df);
                int weekOfYear2 = gc.GetWeekOfYear(takeflag.TakeTime, CalendarWeekRule.FirstDay, df);
                if (year1==year2 && weekOfYear == weekOfYear2)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("TaxMoneyaweek") + "');", true);//本周您已提现，不能再次申请
                                                                          
                    return;
                }
            }


            #region 提现金额验证
            if (txtTake.Text.Trim() == "")
            {
                MessageBox.MyShow(this, GetLanguage("WithdrawalIsnull"));//提现金额不能为空
                return;
            }
            decimal resultNum = 0;
            decimal tx_min = getParamAmount("ATM1");//最低体现额
            decimal tx_bs = getParamAmount("ATM2");//倍数基数
            if (decimal.TryParse(txtTake.Text.Trim(), out resultNum))
            {
                if (resultNum < tx_min)
                {
                    MessageBox.MyShow(this, GetLanguage("AmountThan") + tx_min);//提现金额必须是大于等于XX的整数!
                    return;
                }
                if (tx_bs != 0 && resultNum % tx_bs != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("amountMust") + tx_bs + GetLanguage("Multiples") + "');", true);//提现金额必须是" + tx_bs + "的倍数!
                    return;
                }
            }
            else
            {
                MessageBox.MyShow(this, GetLanguage("AmountErrors"));//金额格式输入错误
                return;
            }

            //if (Convert.ToDecimal(resultNum) > LoginUser.BonusAccount)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseExchange") + "');", true);//请到流通币交易大厅交易
            //    return;
            //}

            //if (LoginUser.User010 != txtAnswer.Text.Trim())
            //{
            //    MessageBox.Show(this, GetLanguage("answerErrors"));//密保答案错误
            //    return;
            //}

            //int getCount = 0;
            //int takeCount = Convert.ToInt32(getParamAmount("extract4"));
            //string dt = DateTime.Now.ToString("yyyy/M/d");
            //string isTake = getColumn(1, "Take006", "tb_takeMoney", "UserID=" + getLoginID(), "Take006 Desc");
            //DataSet ds = new DataSet();
            //lgk.BLL.tb_takeMoney takemoney = new lgk.BLL.tb_takeMoney();
            //ds = takemoney.GetList("UserID=" + getLoginID());
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (ds.Tables[0].Rows[i]["Take006"].ToString().Contains(dt)) 
            //    {
            //        getCount++;
            //    }
            //}
            ////若今天已经存在提款记录，则提示不能再提现
            //if (getCount >= takeCount)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('提现次数不能大于" + takeCount + "次!');", true);
            //    return;
            //}
            #endregion

            #endregion

            #region 提现申请
            lgk.Model.tb_takeMoney takeMoneyInfo = new lgk.Model.tb_takeMoney();
            takeMoneyInfo.TakeTime = DateTime.Now;
            takeMoneyInfo.TakeMoney = resultNum;
            takeMoneyInfo.TakePoundage = resultNum * getParamAmount("ATM3") / 100;
            takeMoneyInfo.RealityMoney = resultNum - takeMoneyInfo.TakePoundage;
            takeMoneyInfo.Flag = 0;
            takeMoneyInfo.UserID = getLoginID();
            takeMoneyInfo.BonusBalance = LoginUser.StockMoney - takeMoneyInfo.TakeMoney;

            takeMoneyInfo.BankName = LoginUser.BankName;
            takeMoneyInfo.Take003 = LoginUser.BankBranch;
            takeMoneyInfo.BankAccount = LoginUser.BankAccount;
            takeMoneyInfo.BankAccountUser = LoginUser.BankAccountUser;
            #endregion

            #region 加入流水账表

            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            journalInfo.UserID = takeMoneyInfo.UserID;
            journalInfo.Remark = "会员提现";
            journalInfo.RemarkEn = "Cash withdrawal";
            journalInfo.InAmount = 0;
            journalInfo.OutAmount = takeMoneyInfo.TakeMoney;
            journalInfo.BalanceAmount = takeMoneyInfo.BonusBalance;
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = 4;
            journalInfo.Journal01 = takeMoneyInfo.UserID;

            #endregion

            if (takeBLL.Add(takeMoneyInfo) > 0 && journalBLL.Add(journalInfo) > 0 && UpdateAccount("StockMoney", getLoginID(), takeMoneyInfo.TakeMoney, 0) > 0)
            {
                //string ss = (GetLanguage("MessageTakeMoney").Replace("{username}", LoginUser.UserCode)).Replace("{time}", Convert.ToDateTime(journalInfo.JournalDate).ToString("yyyy年MM月dd日HH时mm分")).Replace("{timeEn}", Convert.ToDateTime(journalInfo.JournalDate).ToString("yyyy/MM/dd HH:mm"));//添加短信内容
                //SendMessage((int)LoginUser.UserID, LoginUser.PhoneNum, ss);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("successful") + "');window.location.href='TakeMoney.aspx';", true);//申请提现成功
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OperationFailed") + "');", true);//操作失败
            }
        }

        protected void txtTake_TextChanged(object sender, EventArgs e)
        {
            if (txtTake.Text.Trim() != "")
            {
                decimal value = (Convert.ToDecimal(txtTake.Text) * (1 - getParamAmount("ATM3") / 100));//手续费getParamAmount("ATM4")

                txtExtMoney.Value = value.ToString() + GetLanguage("USD");
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "change")
            {
                long iID = Convert.ToInt64(e.CommandArgument);
                lgk.Model.tb_takeMoney take = takeBLL.GetModel(iID);
                if (take == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordDeleted") + "');", true);//该记录已删除，无法再进行此操作
                    return;
                }
                if (take.Flag != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordApproved") + "');", true);//该记录已审核，无法再进行此操作
                    return;
                }
                lgk.Model.tb_user user = userBLL.GetModel(Convert.ToInt32(take.UserID));
                //加入流水账表
                lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                model.UserID = take.UserID;
                model.Remark = "取消提现";
                model.RemarkEn="Withdraw cash";
                model.InAmount = take.TakeMoney;
                model.OutAmount = 0;
                model.BalanceAmount = user.StockMoney + take.TakeMoney;
                model.JournalDate = DateTime.Now;
                model.JournalType = 4;
                model.Journal01 = take.UserID;

                if (journalBLL.Add(model) > 0 && UpdateAccount("StockMoney", take.UserID, take.TakeMoney, 1) > 0 && takeBLL.Delete(iID))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("CancellationSuccess") + "');window.location.href='TakeMoney.aspx';", true);//取消成功
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("FailedToCancel") + "');", true);//取消失败
                }
            }
        }

    }
}
