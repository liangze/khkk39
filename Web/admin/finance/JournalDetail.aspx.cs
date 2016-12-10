using System;
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

namespace Web.admin.finance
{
    public partial class JournalDetail : AdminPageBase//System.Web.UI.Page
    {
        protected int iJournalType = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 20, getLoginID());//权限

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            long iUserID = Convert.ToInt64(Request.QueryString["UserID"].ToString());
            iJournalType = Convert.ToInt32(Request.QueryString["JournalType"].ToString());

            string name = GoldTypeZhcn(Request.QueryString["JournalType"]);

            ltRemark.Text = name;
            ltIncome.Text = name;
            ltExpenditure.Text = name;
            ltBalance.Text = name;

            string strWhere = string.Format(" JournalType=" + iJournalType + " and j.UserID=" + iUserID);

            bind_repeater(journalBLL.GetList(strWhere), Repeater1, "ID desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
