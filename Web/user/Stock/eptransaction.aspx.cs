using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Stock
{
    public partial class eptransaction : PageCore //System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chousid.Value = GetLanguage("Sellregistropois");
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
        ///查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "IsSell=0 and UserID=" + getLoginID()+"AND(TypeID=1)";//会员卖出
            return strWhere;
        }
        private string GetWhere2()
        {
            string strWhere = "IsSell=0 and UserID<>" + getLoginID()+"AND(TypeID=1)";//会员可以购买
            return strWhere;
        }

        private void BindData()
        {
            bind_repeater(cashsellBLL.GetList(GetWhere()), Repeater1, "SellDate desc", tr1, AspNetPager1);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();

        }
        private void BindData2()
        {
            bind_repeater(cashsellBLL.GetList(GetWhere2()), Repeater2, "SellDate desc", tr2, AspNetPager2);
        }
        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindData2();

        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "change")
            {
                Response.Redirect("../Cash/MyCashbuy.aspx?CashsellID=" + e.CommandArgument.ToString());
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("FailedToCancel") + "');", true);//取消失败
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {


        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long icashsellID = Convert.ToInt64(e.CommandArgument);
            if (e.CommandName == "revoke")
            {
                lgk.Model.Cashsell cashsellInfo = cashsellBLL.GetModel(icashsellID);
                if(cashsellInfo != null)
                {
                    lgk.Model.tb_user userInfo = new lgk.Model.tb_user();//会员
                    userInfo = userBLL.GetModel(getLoginID());
                    #region 加入流水账表
                    // 注册点
                    decimal Nubme = cashsellInfo.SaleNum + cashsellInfo.Charge;
                    lgk.Model.tb_journal journInfo = new lgk.Model.tb_journal();
                    journInfo.UserID = getLoginID();
                    journInfo.Remark = "撤销挂卖";
                    journInfo.RemarkEn = "Cancel the sale";
                    journInfo.InAmount = cashsellInfo.SaleNum;
                    journInfo.OutAmount = 0;
                    journInfo.BalanceAmount = userInfo.BonusAccount + Nubme;//结余账户余额;
                    journInfo.JournalDate = DateTime.Now;
                    journInfo.JournalType = 1;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    journInfo.Journal01 = getLoginID();// 出售者ID
                    journalBLL.Add(journInfo);//增加一条数据
                    cashsellInfo.IsSell = 2;
                    cashsellBLL.Update(cashsellInfo);//更新挂单
                    UpdateAccount("BonusAccount", userInfo.UserID, Nubme, 1);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');location.href='eptransaction.aspx';", true);//取消失败
                    #endregion
                }

            }
        }
    }
}