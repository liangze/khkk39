using DataAccess;
using lgk.BLL;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.member
{
    public partial class MemberTree : PageCore //System.Web.UI.Page
    {
        private long x = 1;
        private int y = 2;
        private int z = 4;//3;
        private static int _selectPlatform = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //spd.jumpUrl(this.Page, 1);//跳转二级密码
            //spd.jumpUrl1(this.Page, 1);//跳转3级密码
            if (!IsPostBack)
            {
                BindTreeRe();
                x = GetUserID();
                ViewState["x"] = x;
                ViewState["y"] = y;
                ViewState["z"] = z;
            }
            else
            {
                x = int.Parse(ViewState["x"].ToString());
                y = int.Parse(ViewState["y"].ToString());
                z = int.Parse(ViewState["z"].ToString());
            }
            btnSearch.Text = GetLanguage("GoTo");//挑转
            btnMy.Text = GetLanguage("MyPedigree");//我的系谱图
            Button1.Text = GetLanguage("pre");//上一级
            Button2.Text = GetLanguage("next");//下一级
        }

        private void BindTreeRe()
        {
            long iUID = GetUserID();

            lgk.BLL.UserView uview = new UserView(iUID, y, z, _selectPlatform, 0, GetLanguage("LoginLable"),1);
            Literal1.Text = uview.AddTable();
        }

        private long GetUserID()
        {
            if (getIntRequest("tt") != 0)
            {
                return getLongRequest("tt");
            }
            return getLoginID();
        }

        private void BindTree()
        {
            UserView uview = new UserView(x, y, z, _selectPlatform, 0, GetLanguage("LoginLable"),1);
            Literal1.Text = uview.AddTable();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtUserCode.Text != "")
            {
                int xNode = GetUserID(txtUserCode.Text);
                if (xNode != 0)
                {

                    if (!getli(txtUserCode.Text))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NoLuck") + "');window.location.href='MemberTree.aspx?tt=0," + getLoginID() + "'", true);//没有查看权限
                    }
                    else
                    {
                        x = xNode;
                        ViewState["x"] = x;
                        BindTree();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NoSuchUser") + "');", true);//没有这个用户
                    BindTree();
                }
            }
        }

        private bool getli(string p)
        {
            string str = DbHelperSQL.GetSingle("select UserPath from tb_user where UserCode='" + p + "'").ToString();
            string[] strs = str.Split('-');
            //int uid = Convert.ToInt32(Request.Cookies["user"].Values["ID"]);
            for (int i = 0; i <= strs.Length - 1; i++)
            {
                if (strs[i] == getLoginID().ToString())
                {
                    return true;
                }
            }
            return false;
        }

        protected void btnMy_Click(object sender, EventArgs e)
        {
            x = getLoginID();
            ViewState["x"] = x;
            BindTree();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            z = z - 1;
            if (z < 2) z = 2;
            ViewState["z"] = z;
            BindTree();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "11", "parent.document.all('mainFrame').style.height=document.body.scrollHeight;", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            z = z + 1;
            ViewState["z"] = z;
            BindTree();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "11", "parent.document.all('mainFrame').style.height=document.body.scrollHeight;", true);
        }
        protected void Button2_Click1(object sender, EventArgs e)
        {
            Session["reg_usercode"] = LoginUser.UserCode;
            Response.Redirect("/Registers.aspx");
        }
    }
}