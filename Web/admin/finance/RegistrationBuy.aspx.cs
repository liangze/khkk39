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
    public partial class RegistrationBuy : AdminPageBase
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
            bind_repeater(cashbuyBLL.GetList(GetWhere()), Repeater1, "BuyDate desc", tr1, AspNetPager1);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
        }

        private string GetWhere()
        {
            string strWhere = "", strOrderCode = "";

            //购买状态(0未付款，1已付款，2已完成，3已终止)

            //strWhere = "Status>=1";
            strWhere = "TypeID=1";//1是注册点 ，2是夸克币

            #region 买家编号
            strOrderCode = txtOrderCode.Text.Trim();
            long UserID = userBLL.GetUserID(strOrderCode);
            if (strOrderCode != "")
                strWhere += " AND UserID='" + UserID + "'";
            #endregion

            #region 下定时间
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OBuyDate,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120)  between '" + strStartTime + "' AND '" + strEndTime + "'");
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
    }
}