
using lgk.BLL;
using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.member
{
    public partial class sponsor : PageCore//System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTable();
            }

        }
        private string GetWhere()
        {
           // string strStart = txtStart.Text.Trim();
           // string strEnd = txtEnd.Text.Trim();

            string strWhere = " RecommendID = " + LoginUser.UserID;

           // #region 会员编号姓名
           // string strUserCode = this.txtUserCode.Value.Trim();
            //if (!string.IsNullOrEmpty(strUserCode))
            //{
            //    strWhere += " AND UserCode LIKE  '%" + strUserCode + "%'";
            //}
            //#endregion

            //if (GetLanguage("LoginLable") == "en-us")
            //{
            //    strStart = txtStartEn.Text.Trim();
            //    strEnd = txtEndEn.Text.Trim();
            //}
            return strWhere;
        }
        protected void BindTable()
        {

            //读取数据库数据
            // DataSet ds = Supplier.SupplierProduct.SearchOfSmallCard("21", "", searchValue, -1, 0, Class.LoginMsg.GetAgentCode(), Class.LoginMsg.GetCurrIp());
            DataSet ds = userBLL.GetOpenList(GetWhere());
            if (ds != null)
            {
                string tbInfo = "";
                string td = "";
                string tr = "";
                int dsCount = ds.Tables[0].Rows.Count;
                //hfdRowCount.Value = dsCount.ToString();
                int countSum = 0;
                for (int i = 0; i < dsCount; i++)
                {
                    //拼td
                    td = td + "<td class='search-resultt'><a href='GameCard02.aspx?smallid=" + ds.Tables[0].Rows[countSum]["f_smallcardid"].ToString() + "&&titlename=" + ds.Tables[0].Rows[countSum]["f_smallname"].ToString() + "'>" + ds.Tables[0].Rows[countSum]["f_smallname"].ToString() + "</a></td>";

                    countSum++;
                    if (countSum % 3 == 0)
                    {
                        //td组合tr
                        tr = tr + "<tr>" + td + "</tr>";
                        td = "";
                    }
                    if (countSum == dsCount)
                    {
                        int j = dsCount % 3;
                        if (j == 1)
                        {
                            td = td + "<td class='search-resultt'></td><td class='search-resultt'></td>";
                            tr = tr + "<tr>" + td + "</tr>";
                        }
                        else
                        {
                            td = td + "<td class='search-resultt'></td>";
                            tr = tr + "<tr>" + td + "</tr>";
                        }
                    }
                }
                //组成table
                tbInfo = "<table  cellpadding='0' cellspacing='0' border='1' bordercolor='Red' class='search1-result'>" + tr + "</table>";
                //页面控件赋值
                Literal1.Text = tbInfo;
            }

        }

    }
}