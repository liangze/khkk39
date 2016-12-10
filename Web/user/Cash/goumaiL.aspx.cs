using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Cash
{
    public partial class goumaiL : PageCore
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
            string strWhere = "UserID=" + getLoginID() + " AND (TypeID=1)";
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

        // 用于点击搜索按钮后数据绑定
        private string GetWhere2()
        {
            string strWhere = "UserID=" + getLoginID()+ " AND (TypeID=1)";
            // lgk.Model.tb_user iuserid = new lgk.Model.tb_user();
            string usercode = name.Value.Trim();
          long iuserid = userBLL.GetUserID(usercode);
            if (name.Value.Trim() != "")
            {
                strWhere += "and SellUserID=" + iuserid;
            }
            return strWhere;
        }
        private void BindData2()
        {
            bind_repeater(cashbuyBLL.GetList(GetWhere2()), Repeater1, "BuyDate desc", tr1, AspNetPager1);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
            BindData2();
        }
    }
}