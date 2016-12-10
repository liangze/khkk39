using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
namespace Web.user
{
    public partial class holdingmoney : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.FirstPageText = GetLanguage("FirstPage");
            AspNetPager1.LastPageText = GetLanguage("LastPage");
            AspNetPager1.NextPageText = GetLanguage("NextPage");
            AspNetPager1.PrevPageText = GetLanguage("PrevPage");
            btnBack.Text = GetLanguage("Return");
            if (!IsPostBack)
            {
                //BindCurrency();
                BindData();
                btnSearch.Text = GetLanguage("Search");//搜索
            }
        }

       
        private void BindData()
        {
            // bind_repeater(bonusBLL.GetList(GetWhere()), Repeater1, "id desc", tr1, AspNetPager1);
            bind_repeater(bo.GetUserBonus(GetWhere()), Repeater1, "SttleTime desc", tr1, AspNetPager1);
        }

        private string GetWhere()
        {
           
            string strWhere = string.Format(" b.TypeID =4 and b.Amount<>0  and b.UserID=" + getLoginID() + ""); ;
           
            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();
            if (GetLanguage("LoginLable") == "en-us")
            {
                strStartTime = this.txtStartEn.Text.Trim();
                strEndTime = this.txtEndEn.Text.Trim();
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),b.SttleTime,120) >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),b.SttleTime,120) <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),b.SttleTime,120) between '" + strStartTime + "' and '" + strEndTime + "' ");
            }
            return strWhere;
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
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("holdingmoney.aspx");
        }
    }
}