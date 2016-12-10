using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin.finance
{
    public partial class CashTradeList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 16, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            bind_repeater(cashsellBLL.CashBuyAndSellList(0, GetWhere()), Repeater1, "AddTime desc", tr1, AspNetPager1);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            int iIsBorS = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "IsBorS"));//1是买入，2是卖出
            int iStata = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Stata"));//订单状态：1是已完成，0是挂单中，2是已撤销
            int iCashID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "CashID"));

            Literal ltStatus = (Literal)e.Item.FindControl("ltStatus");//卖家编号
            Literal Literal1 = (Literal)e.Item.FindControl("Literal1");//买家编号
          //  Literal Literal2 = (Literal)e.Item.FindControl("Literal2");//委托数量
            if (iIsBorS == 1)
            {
                lgk.Model.Cashbuy cashbuymodel = new lgk.Model.Cashbuy();
                cashbuymodel = cashbuyBLL.GetModel(iCashID);
                string SellUsercode = userBLL.GetUserCode(cashbuymodel.SellUserID);
                string Buyusercode = userBLL.GetUserCode(cashbuymodel.UserID);
               // Literal2.Text = cashbuymodel.BuyNum.ToString();
                if (SellUsercode != "")
                {
                    ltStatus.Text = SellUsercode;//卖家编号

                }
                if (Buyusercode != "")
                {
                    Literal1.Text = Buyusercode;
                }

            }
            if (iIsBorS == 2)
            {
                lgk.Model.Cashsell cashsellmodel = new lgk.Model.Cashsell();
                cashsellmodel = cashsellBLL.GetModel(iCashID);
                string SellUsercode = userBLL.GetUserCode(cashsellmodel.UserID);

                if (SellUsercode != "")
                {
                    ltStatus.Text = SellUsercode;//卖家编号

                }
                //if (iStata == 1)
                //{
                //    Literal2.Text = cashsellmodel.Number.ToString();
                //}
                //if (iStata == 0)
                //{
                //    Literal2.Text = cashsellmodel.SaleNum.ToString();
                //}
                //if (iStata == 2)
                //{
                //    Literal2.Text = cashsellmodel.SaleNum.ToString();
                //}

            }

        }

        private string GetWhere()
        {
            string strWhere = "", strOrderCode = "";
            // string strWhere = string.Format(" UserID=" + getLoginID()) + " AND (TypeID=2 )";
            strWhere = "TypeID=2";//1是注册点 ，2是夸克币

            #region 会员编号
            strOrderCode = txtOrderCode.Text.Trim();
            
            if (strOrderCode != "")
            {
                long UserID = userBLL.GetUserID(strOrderCode);
                strWhere += " AND UserID='" + UserID + "'";
            }
                
            #endregion

            #region 下定时间
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),AddTime,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),AddTime,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),AddTime,120)  between '" + strStartTime + "' AND '" + strEndTime + "'");
            }
            #endregion

            return strWhere;
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 分页提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                string re = e.CommandArgument.ToString();
                string[] reArr = re.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                //reArr[0]是CashID，reArr[1]是IsBorS
                int CashId = int.Parse(reArr[0]);
                if (int.Parse(reArr[1]) == 1)
                {

                    lgk.Model.Cashbuy Buymodel = cashbuyBLL.GetModel(CashId);
                    Buymodel.IsBuy = 2;
                    cashbuyBLL.Update(Buymodel);
                }
                else
                {

                    lgk.Model.Cashsell Selmodel = cashsellBLL.GetModel(CashId);
                    Selmodel.IsSell = 2;
                    cashsellBLL.Update(Selmodel);//更新订单状态
                    //更新卖家账户
                    long SelluserID = Selmodel.UserID;
                    UpdateAccount("User011", SelluserID, Selmodel.SaleNum, 1);

                    //加入流水账表
                    lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                    journalInfo.UserID = SelluserID;
                    journalInfo.Remark = "撤销挂卖";
                    journalInfo.RemarkEn = "撤销挂卖";
                    journalInfo.InAmount = Selmodel.SaleNum;
                    journalInfo.OutAmount = 0;//夸克币;

                    lgk.Model.tb_user usemodel = userBLL.GetModel(SelluserID);

                    journalInfo.BalanceAmount = usemodel.User011;// 此时夸克币账户结余
                    journalInfo.JournalDate = DateTime.Now;
                    journalInfo.JournalType = 8;//8是夸克币
                    journalInfo.Journal01 = SelluserID;//ID
                    journalBLL.Add(journalInfo);
                }

                Response.Write("<script>alert('" + GetLanguage("Successful") + "');location.href='CashTradeList.aspx';</script>");
               
            }
        }
    }
}