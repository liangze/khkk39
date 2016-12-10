using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
namespace Web.user
{
    public partial class goldcoin04 :PageCore //System.Web.UI.Page
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

        /// <summary>
        /// 绑定币种
        /// </summary>
        //public void BindCurrency()
        //{
        //    if (currentCulture == "zh-cn")
        //    {
        //        dropCurrency.Items.Add(new ListItem("-请选择-", "0"));
        //        dropCurrency.Items.Add(new ListItem("商城点数", "1"));
        //        //dropCurrency.Items.Add(new ListItem("MDD钻币", "2"));
        //        //dropCurrency.Items.Add(new ListItem("购物币", "4"));
        //        //dropCurrency.Items.Add(new ListItem("注册币", "5"));
        //    }
        //    else
        //    {
        //        dropCurrency.Items.Add(new ListItem("-Please choose-", "0"));
        //        dropCurrency.Items.Add(new ListItem("Registration points", "1"));
        //        //dropCurrency.Items.Add(new ListItem("MDD Drill", "2"));
        //        //dropCurrency.Items.Add(new ListItem("Shopping currency", "4"));
        //        //dropCurrency.Items.Add(new ListItem("Registered currency", "5"));
        //    }
        //    //dropCurrency.Items.Add(new ListItem("平台费用", "3"));
        //}

        private void BindData()
        {
            bind_repeater(journalBLL.GetList(GetWhere()), Repeater1, "id desc", tr1,AspNetPager1);
        }

        private string GetWhere()
        {
            string strWhere = string.Format("u.UserID=" + getLoginID() + " AND (JournalType=7)");
            //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
            //if (dropCurrency.SelectedValue != "0")
            //{
            //    strWhere += " AND j.JournalType=" + dropCurrency.SelectedValue + "";
            //}

            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();
            if (GetLanguage("LoginLable") == "en-us")
            {
                strStartTime = this.txtStartEn.Text.Trim();
                strEndTime = this.txtEndEn.Text.Trim();
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),j.JournalDate,120) >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),j.JournalDate,120) <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),j.JournalDate,120) between '" + strStartTime + "' and '" + strEndTime + "' ");
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
            Response.Redirect("goldcoin04.aspx");
        }
    }
}