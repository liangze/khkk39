using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
namespace Tradinghall.user
{
    public partial class kchart : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
           
            string strWhere = "SaleNum>'0' and IsSell=0  AND (TypeID=2)";
            string strWhere1 = "IsBuy=0 AND TypeID=2";
           // select top 5 u.Price,IsNull(sum(u.BuyNum), 0) as BuyNum FROM(select top 5 * from Cashbuy order by BuyDate desc) u GROUP BY u.Price order by u.Price desc
            //string strWhere3 = "Stata=0 AND TypeID=2";
            //bind_repeater(cashbuyBLL.GetList(5, strWhere1, "BuyDate desc"), repeaterBuy, " Price desc", trbuy);//购买列表
            bind_repeater(cashbuyBLL.GetList1(5, strWhere1, "Price desc"), repeaterBuy, "", trbuy);//购买列表（高--》低）
            bind_repeater(cashsellBLL.GetList1(5, strWhere, "Price asc"), repeaterSell, "", trsell);//卖出列表（低--》高）

            bind_repeater(cashsellBLL.CashBuyAndSellList(5, ""), Repeater1, " AddTime desc", trbuyandsell);

            decimal iMaxMoney = getParamAmount("MaxMoney");
            decimal iMinMoney = getParamAmount("MinMoney");
            decimal iMiddleMoney = (iMaxMoney + iMinMoney) * 5000;
            hdmoney.Value = iMiddleMoney.ToString();

            decimal iMaxPrice = getParamAmount("MaxPrice");
            decimal iMinPrice = getParamAmount("MinPrice");
            decimal iMiddlePrice = (iMaxPrice + iMinPrice) / 2;
            hdprice.Value = iMiddlePrice.ToString();
        }
    }
}