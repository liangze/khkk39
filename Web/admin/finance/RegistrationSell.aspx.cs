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
    public partial class RegistrationSell : AdminPageBase
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
            bind_repeater(cashsellBLL.GetList(GetWhere()), Repeater1, "SellDate desc", tr1, AspNetPager1);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
        }

        private string GetWhere()
        {
            string strWhere = "", strOrderCode = "";
                    
            strWhere = "TypeID=1";//1是注册点 ，2是夸克币

            #region 会员编号
            strOrderCode = txtOrderCode.Text.Trim();
            long UserID= userBLL.GetUserID(strOrderCode);
            if (strOrderCode != "")
                strWhere += " AND UserID='" + UserID + "'";
            #endregion

            #region 出售时间
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),SellDate,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),SellDate,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),SellDate,120)  between '" + strStartTime + "' AND '" + strEndTime + "'");
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