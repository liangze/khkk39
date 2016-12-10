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

namespace Tradinghall
{
    public partial class doForgot : AllCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //long iUserID = Convert.ToInt64(Request["UserID"]);
            /*spd.jumpUrl1(this.Page, 1);*///跳转三级密码
            Resetsubmit.Text = GetLanguage("Reset");
            rturen.Value = GetLanguage("Return");
            btnPwd.Text = GetLanguage("Modify");//确认修改
            //btnSecond.Text = GetLanguage("Modify");
            //btnThree.Text = GetLanguage("Modify");

            if (!IsPostBack)
            {
                
            }
        }
   
        /// <summary>
        /// 验证登录密码
        /// </summary>
        /// <returns></returns>
        protected bool validatePass(string strPwd)
        {
            
            if (txtNewPwd.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NewPassEmpty") + "');", true);//新登录密码不能为空
                return false;
            }
            if (txtNewPwd.Value != txtRPNewPwd.Value)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("TwoPassIncorrect") + "');", true);//两次输入的密码不正确
                return false;
            }

            return true;
        }
        protected void reset_Click(object sender, EventArgs e)
        {
            TBUserName.Value = "";
            txtPhonMailNum.Value = "";
            txtNewPwd.Value = "";
            txtRPNewPwd.Value = "";
        }

        /// <summary>
        /// 保存登录密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPwd_Click(object sender, EventArgs e)
        {
            string iUserCode = TBUserName.Value.Trim();
          
            lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID(iUserCode));
            string PhoneNumber = userInfo.PhoneNum;
            String Mailbox = userInfo.Email;
            if (txtPhonMailNum.Value != userInfo.Email && txtPhonMailNum.Value != userInfo.PhoneNum)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("mailboxPonNumber") + "');", true);//手机号码或者邮箱不正确
            }
            if (validatePass(userInfo.Password))
            {
                if (UpdateUserPwd(userInfo.UserID, "Password", PageValidate.GetMd5(txtNewPwd.Value)) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PasswordChanged") + "');", true);//登录密码修改成功
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Passwordfailed") + "');", true);//登录密码修改失败
                }
            }
        }        
    }
}