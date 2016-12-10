using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
namespace Web.user.Cash
{
    public partial class SaleList : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.FirstPageText = GetLanguage("FirstPage");
            AspNetPager1.LastPageText = GetLanguage("LastPage");
            AspNetPager1.NextPageText = GetLanguage("NextPage");
            AspNetPager1.PrevPageText = GetLanguage("PrevPage");
            btnSearch.Text = GetLanguage("Search");
            if (!IsPostBack)
            {
                BindData();

            }
        }
        private string GetWhere()
        {
            string strWhere = "SellUserID=" + getLoginID() + " AND (TypeID=1)";
            return strWhere;
        }
        private void BindData()
        {
            bind_repeater(cashbuyBLL.GetList(GetWhere()), Repeater1, "BuyDate desc", tr1, AspNetPager1);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "sure")
            {
                long iCashbuyID = Convert.ToInt64(e.CommandArgument);           
                lgk.Model.Cashbuy model = cashbuyBLL.GetModel(iCashbuyID);
                lgk.Model.tb_user Buymodel = userBLL.GetModel(model.UserID);
                decimal Number = model.BuyNum+ Buymodel.BonusAccount;

                UpdateAccount("BonusAccount", model.UserID, model.BuyNum, 1);
                //买家
                #region 加入流水账表
                lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                journalInfo.UserID = model.UserID;
                journalInfo.Remark = "购买注册点";
                journalInfo.RemarkEn = "Buy Circulating gold";
                journalInfo.InAmount = model.BuyNum;
                journalInfo.OutAmount = 0;//注册点数;
                journalInfo.BalanceAmount = Number;// 此时注册点数账户结余
                journalInfo.JournalDate = DateTime.Now;
                journalInfo.JournalType = 1;//1是注册点数
                journalInfo.Journal01 = model.SellUserID;//卖家ID
                journalBLL.Add(journalInfo);

                #endregion
                model.IsBuy = 1;
                cashbuyBLL.Update(model);
                Response.Write("<script>alert('" + GetLanguage("Successful") + "');location.href='SaleList.aspx';</script>");

            }
            if (e.CommandName == "Detail")
            {
                long iCashbuyID = Convert.ToInt64(e.CommandArgument);
                lgk.Model.Cashbuy model = cashbuyBLL.GetModel(iCashbuyID);
                lgk.Model.Cashsell Sellmodel = cashsellBLL.GetModel(model.CashsellID);
                int Number = model.BuyNum;
                decimal tolAount = model.Amount;
                model.IsBuy = 2;
                cashbuyBLL.Update(model);

                
                Sellmodel.IsSell = 0;
          
                cashsellBLL.Update(Sellmodel);

                Response.Write("<script>alert('" + GetLanguage("Successful") + "');location.href='SaleList.aspx';</script>");
            }
         
        }
    }

}