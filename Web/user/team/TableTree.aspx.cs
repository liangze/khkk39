/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-12-5 15:31:25 
 * 文 件 名：		TableTree.cs 
 * CLR 版本: 		2.0.50727.3643 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.user.team
{
    public partial class TableTree : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.FirstPageText = GetLanguage("FirstPage");
            AspNetPager1.LastPageText = GetLanguage("LastPage");
            AspNetPager1.NextPageText = GetLanguage("NextPage");
            AspNetPager1.PrevPageText = GetLanguage("PrevPage");
            if (!IsPostBack)
            {
                btnSearch.Text = GetLanguage("Search");//搜索
                BindData();
            }

        }

        /// <summary>
        ///查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strStart = txtStart.Text.Trim();
            string strEnd = txtEnd.Text.Trim();

            string strWhere = " RecommendID = " + LoginUser.UserID;

            #region 会员编号姓名
            string strUserCode = this.txtUserCode.Value.Trim();
            if (!string.IsNullOrEmpty(strUserCode))
            {
                strWhere += " AND UserCode LIKE  '%" + strUserCode + "%'";
            }
            #endregion

            if (GetLanguage("LoginLable") == "en-us")
            {
                strStart = txtStartEn.Text.Trim();
                strEnd = txtEndEn.Text.Trim();
            }

            #region 注册时间
            if (strStart != "" && strEnd == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),RegTime,120) >= '" + strStart + "'");
            }
            else if (strStart == "" && strEnd != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),RegTime,120) <= '" + strEnd + "'");
            }
            else if (strStart != "" && strEnd != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),RegTime,120) BETWEEN '" + strStart + "' AND '" + strEnd + "'");
            }
            #endregion

            return strWhere;
        }

        private void BindData()
        {
            bind_repeater(userBLL.GetOpenList(GetWhere()), Repeater1, "OpenTime desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();

        }
        /// <summary>
        /// 获取登录会员的ID
        /// </summary>
        /// <returns></returns>
        private long GetUserID()
        {
            if (Request.QueryString["UserID"] != null)
            {
                return Convert.ToInt64(Request.QueryString["UserID"]);
            }
            else
            {
                return getLoginID();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long UserID = long.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_user model = userBLL.GetModel(UserID);//获取需要开通会员的信息
            
            if (e.CommandName == "open")
            {
                string msg = null;
                try
                {
                    msg = userBLL.proc_open(model.UserID, 2, 1, 0);
                    if (msg == null)
                    {
                        msg = "激活失败";
                    }
                    else if (msg == "")
                    {
                        msg = "激活成功";
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + msg + "');", true);
                }
                catch (Exception ex)
                {
                    Library.LogHelper.SaveLog("激活失败！" + ex.Message, "open");
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('激活失败!');", true);
                }
            }
            if (e.CommandName == "delete")
            {
                long iRecommendnum = userBLL.GetCount("RecommendID=" + UserID);
                long iParentnum = userBLL.GetCount("ParentID=" + UserID);
                if(iRecommendnum>0)
                {
                   // Response.Write("<script>alert('" + GetLanguage("Pleasedatadeleted") + "');</script>");//该会员已有推荐会员，不能删除!
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Pleasedatadeleted") + "'); window.location.href = 'TableTree.aspx'; ", true);

                    return;
                }
                if(iParentnum>0)
                {
                   // Response.Write("<script>alert('" + GetLanguage("Pleadeleted") + "');</script>");//该会员下已安置有其他会员，不能删除!
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Pleadeleted") + "'); window.location.href = 'TableTree.aspx'; ", true);
                   
                    return;
                }
                userBLL.Delete(UserID);
            }
                BindData();
        }
    }
}

