﻿using System;
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
    public partial class JournalAccount : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 20, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            string strWhere = string.Format("IsOpend > 0");

            if (this.textUserCode.Value != "")
            {
                strWhere += " and UserCode like '%" + this.textUserCode.Value.Trim() + "%'";
            }
            if (this.txtTrueName.Text != "")
            {
                strWhere += " and TrueName like '%" + this.txtTrueName.Text.Trim() + "%'";
            }
            bind_repeater(userBLL.GetList(strWhere), Repeater1, "Emoney desc,BonusAccount desc,isopend desc", tr1, AspNetPager1);
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long iUserID = Convert.ToInt64(e.CommandArgument);

            if (e.CommandName.Equals("ab_detail"))
            {
                Response.Redirect("JournalDetail.aspx?UserID=" + iUserID + "&JournalType=1");//佣金点数
            }
            if (e.CommandName.Equals("b_detail"))
            {
                Response.Redirect("JournalDetail.aspx?UserID=" + iUserID + "&JournalType=2");//注册点数
            }
            if (e.CommandName.Equals("e_detail"))
            {
                Response.Redirect("JournalDetail.aspx?UserID=" + iUserID + "&JournalType=3");//交易点数
            }
            if (e.CommandName.Equals("sm_detail"))
            {
                Response.Redirect("JournalDetail.aspx?UserID=" + iUserID + "&JournalType=4");//现金币
            }
            if (e.CommandName.Equals("gl_detail"))
            {
                Response.Redirect("JournalDetail.aspx?UserID=" + iUserID + "&JournalType=5");//激活点数
            }
            if (e.CommandName.Equals("sa_detail"))
            {
                Response.Redirect("JournalDetail.aspx?UserID=" + iUserID + "&JournalType=6");//股权
            }
            if (e.CommandName.Equals("sh_detail"))
            {
                Response.Redirect("JournalDetail.aspx?UserID=" + iUserID + "&JournalType=7");//商城点数
            }
            if (e.CommandName.Equals("u11_detail"))
            {
                Response.Redirect("JournalDetail.aspx?UserID=" + iUserID + "&JournalType=8");//夸克币
            }
            if (e.CommandName.Equals("u12_detail"))
            {
                Response.Redirect("JournalDetail.aspx?UserID=" + iUserID + "&JournalType=9");//持币
            }
            if (e.CommandName.Equals("u13_detail"))
            {
                Response.Redirect("JournalDetail.aspx?UserID=" + iUserID + "&JournalType=10");//存币
            }
        }
    }
}
