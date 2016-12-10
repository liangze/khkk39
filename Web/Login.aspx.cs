/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-13 16:09:09 
 * 文 件 名：		Login.cs 
 * CLR 版本: 		2.0.50727.3053 
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

namespace Web
{
    public partial class Login : AllCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindLanguage();
            long iUserID = Convert.ToInt64(Request["UserID"]);
            btnLogin.Text = GetLanguage("Submit");

            if (!IsPostBack)
            {
               
                string host = Request.Url.Host;
                if (Request["name"] != null)
                {
                    //登录另一个域名
                    string UserName = Request.QueryString["name"];
                    lgk.Model.tb_user uModel = userBLL.GetModel(GetUserID(UserName));
                    if (uModel.Password != PageValidate.GetMd5(Request.QueryString["pwd"]))
                    {
                        return;//密码不对
                    }

                    UserUtil.Login(UserName, "A128076_user", false);
                    //放入cookie
                    HttpCookie UserCookie = new HttpCookie("A128076_user");
                    if (Request["id"] == null)
                    {
                        UserCookie["Id"] = GetUserID(UserName).ToString();
                    }
                    else
                    {
                        UserCookie["Id"] = Request.QueryString["id"];
                    }

                    UserCookie["name"] = UserName;
                    Response.AppendCookie(UserCookie);
                    HttpCookie CultureCookie = new HttpCookie("Culture");

                    CultureCookie.Value = "en-us";
                    Response.AppendCookie(CultureCookie);

                    Response.Redirect("/user/index.aspx");
                }

                if (string.IsNullOrEmpty(Request["adminid"]) == false)
                {
                    Security sec = new Security();//解密传递过来的参数
                    string admin = sec.DecryptQueryString(Request["adminid"].ToString());//Request["adminid"].ToString();//
                    RegexR reg = new RegexR();
                    if (reg.Nums(admin) == true)
                    {
                        AdminEnter(admin, iUserID);
                    }
                    else
                    {
                        bindLogin();
                    }
                }

            }
        }

        private void BindLanguage()
        {
            if (currentCulture == "en-us")
            {
               
                //dropLanguage.Items.Add(new ListItem("", "1"));
                dropLanguage.Items.Add(new ListItem("English", "0"));
                dropLanguage.Items.Add(new ListItem("中文", "2"));
            }
            else
            {
                
                dropLanguage.Items.Add(new ListItem("中文", "0"));
                dropLanguage.Items.Add(new ListItem("English", "1"));
                //dropLanguage.Items.Add(new ListItem("", "2"));
            }

        }
        protected void dropLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iLanguage = int.Parse(dropLanguage.SelectedValue);

            if (iLanguage == 1)
            {
                HttpCookie CultureCookie = new HttpCookie("Culture");
                CultureCookie.Value = "en-us";//英文
                Response.AppendCookie(CultureCookie);

                

                //登录系统
                //Response.Write("<script type='text/javascript'>window.parent.location.href='Login.aspx';</script>");
                Response.Redirect("Login.aspx");


            }
            else if (iLanguage == 2)
            {
                HttpCookie CultureCookie = new HttpCookie("Culture");
                CultureCookie.Value = "zh-cn";//中文
                Response.AppendCookie(CultureCookie);

                //  Response.Write("<script type='text/javascript'>window.parent.location.href='Login.aspx';</script>");
                Response.Redirect("Login.aspx");
            }

        }

        private void bindLogin()
        {
            if (Session["goto_uid"] != null)
            {
                lgk.Model.tb_user loginuser = userBLL.GetModel(Convert.ToInt64(Session["goto_uid"]));
                //放入cookie
                HttpCookie UserCookie = new HttpCookie("A128076_user");
                UserCookie["Id"] = loginuser.UserID.ToString();
                UserCookie["name"] = loginuser.UserCode;
                Response.AppendCookie(UserCookie);
                Session.Remove("goto_uid");
                Response.Redirect("user/index.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (setBLL.GetModel(1).IsOpenWeb == 0)
            {
                MessageBox.ShowAndRedirect(this, setBLL.GetModel(1).CloseWebRemark, "login.aspx");
            }
            else
            {
                if (this.TBUserName.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseNmae") + "!');", true);//请输入用户名
                    return;
                }
                if (this.TBUserName.Value.Trim() == "用户名")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseNmae") + "!');", true);//请输入用户名
                    return;
                }
                if (this.TBPassWord.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseInputPassword") + "!');", true);//请输入密码
                    return;
                }
                if (this.TBPassWord.Value.Trim() == "密码")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseInputPassword") + "!');", true);//请输入密码
                    return;
                }
                if (this.TBCode.Value.Trim() == "")
                {
                    MessageBox.Show(this, "" + GetLanguage("VerificationCodeEmpty") + "!");//验证码不能为空
                    return;
                }

                string xd = Session["CheckCode"] != null && Session["CheckCode"].ToString() != "" ? Session["CheckCode"].ToString() : "";
                if (xd.ToLower() != TBCode.Value.Trim().ToLower())
                {
                    MessageBox.Show(this, "" + GetLanguage("VerificationCodeError") + "");//验证码错误
                    return;
                }
                lgk.Model.tb_user user = userBLL.GetModel(GetUserID(TBUserName.Value.Trim()));
                if (user == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AccountPasswordError") + "!');", true);//账号或密码错误
                    return;
                }
                if (user.Password != PageValidate.GetMd5(TBPassWord.Value))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AccountPasswordError") + "!');", true);//账号或密码错误
                    return;
                }
                if (user.IsLock == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Accountfrozenlogon") + "!');", true);//账号已冻结不能登录
                    return;
                }
                string UserName = this.TBUserName.Value.Trim();
                UserUtil.Login(UserName, "A128076_user", false);
                //放入cookie
                HttpCookie UserCookie = new HttpCookie("A128076_user");
                UserCookie["Id"] = user.UserID.ToString();
                UserCookie["name"] = UserName;
                Response.AppendCookie(UserCookie);
                //HttpCookie CultureCookie = new HttpCookie("Culture");
                //CultureCookie.Value = "en-us";//中文
                //Response.AppendCookie(CultureCookie);

                //登录系统
                Response.Redirect("/user/index.aspx");
            }
        }

        protected void AdminEnter(string adminid, long iUserID)
        {
            lgk.Model.tb_user user = userBLL.GetModel(iUserID);

            UserUtil.Login(this.TBUserName.Value.Trim(), "A128076_user", false);
            Session["adminid"] = adminid;//管理员以会员身份登陆会员前台页面后，作出标记
            lgk.BLL.SecondPasswordBLL76.AdminId = Convert.ToInt32(adminid);//管理员以会员身份登陆会员前台页面后，作出标记

            //放入cookie
            HttpCookie UserCookie = new HttpCookie("A128076_user");
            UserCookie["Id"] = user.UserID.ToString();
            UserCookie["name"] = Convert.ToString(TBUserName.Value.Trim());
            Response.AppendCookie(UserCookie);
            Response.Redirect("user/index.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("user/passwordupdata.aspx");
        }
    }
}
