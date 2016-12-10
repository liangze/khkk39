using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tradinghall.user
{
    public partial class transactionrecords : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.FirstPageText= GetLanguage("FirstPage");
            AspNetPager1.LastPageText = GetLanguage("LastPage");
            AspNetPager1.NextPageText = GetLanguage("NextPage");
            AspNetPager1.PrevPageText = GetLanguage("PrevPage");
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            string strWhere = string.Format(" UserID=" + getLoginID())+" AND (TypeID=2 )";

            bind_repeater(cashsellBLL.CashBuyAndSellList(0, strWhere), Repeater1, "AddTime desc", tr1, AspNetPager1);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                string re = e.CommandArgument.ToString();
                string[] reArr = re.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries);
                //reArr[0]是CashID，reArr[1]是IsBorS
                int CashId = int.Parse(reArr[0]);
                if (int.Parse(reArr[1])==1)
                {
                    lgk.Model.Cashbuy Buymodel = cashbuyBLL.GetModel(CashId);
                    if(Buymodel.IsBuy == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Plesdsdsdta") + "');location.href='transactionrecords.aspx';", true);//订单交易已完成，不可撤销
                        return;
                    }
                    else if(Buymodel.IsBuy == 2)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Pleuuudata") + "');location.href='transactionrecords.aspx';", true);//订单交易已撤销，不需撤销
                        return;
                    }
                    else
                    {
                        Buymodel.IsBuy = 2;
                        cashbuyBLL.Update(Buymodel);

                        decimal returnEmoney = Buymodel.BuyNum * Buymodel.Price;//返还的交易点数
                        lgk.Model.tb_user userModel = userBLL.GetModel(Buymodel.UserID);
                        if(returnEmoney > 0)
                        {
                            lgk.Model.tb_journal journInfo = new lgk.Model.tb_journal();
                            journInfo.UserID = userModel.UserID;
                            journInfo.Remark = "撤销价格为（" + Buymodel.Price + "），数量为" + Buymodel.BuyNum + "个，返还交易点数";
                            journInfo.RemarkEn = "Cancels an order with a price of 1 and a quantity of 1, Return Trading points";
                            journInfo.InAmount = returnEmoney;//返还交易点数
                            journInfo.OutAmount = 0;
                            journInfo.BalanceAmount = userModel.Emoney + returnEmoney;//结余账户余额;
                            journInfo.JournalDate = DateTime.Now;
                            journInfo.JournalType = 2;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                            journInfo.Journal01 = userModel.UserID;//
                            journalBLL.Add(journInfo);//增加一条数据

                            UpdateAccount("User015", userModel.UserID, returnEmoney, 0);
                            UpdateAccount("Emoney", userModel.UserID, returnEmoney, 1);
                        }
                    }
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
               
                Response.Write("<script>alert('" + GetLanguage("Successful") + "');location.href='transactionrecords.aspx';</script>");
            }
        }

    }
}