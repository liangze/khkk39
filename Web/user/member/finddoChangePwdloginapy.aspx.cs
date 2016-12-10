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

namespace Web.user.member
{
    public partial class finddoChangePwdloginapy : PageCore// System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*spd.jumpUrl1(this.Page, 1);*///跳转三级密码

            //btnPwd.Text = GetLanguage("Modify");//确认修改
            btnSecond.Text = GetLanguage("Modify");
            //btnThree.Text = GetLanguage("Modify");

            if (!IsPostBack)
            {

            }
        }
       /// <summary>
      /// 获取登录用户的会员ID
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

        /// <summary>
        /// 验证二级密码
        /// </summary>
        /// <returns></returns>
        protected bool validateSecondPass(string strPwd)
        {
            
            if (txtNewSecondPwd.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NewTwoPassEmpty") + "');", true);//新二级密码不能为空
                return false;
            }
            if (txtNewSecondPwd.Value != txtRPSecondPwd.Value)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("TwoPassIncorrect") + "');", true);//两次输入的密码不正确
                return false;
            }

            return true;
        }

        // <summary>
        // 保存二级密码
        // </summary>
        // <param name = "sender" ></ param >
        // < param name="e"></param>
        protected void btnSecond_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user model = LoginUser;
            lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID());
            string PhoneNumber = userInfo.PhoneNum;
            String Mailbox = userInfo.Email;
              if(txtPhonMailNum.Value != userInfo.Email&&txtPhonMailNum.Value!=userInfo.PhoneNum)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("mailboxPonNumber") + "');", true);//手机号码或者邮箱不正确
            }
            
            if (validateSecondPass(model.SecondPassword))
            {
                if (UpdateUserPwd(model.UserID, "SecondPassword", PageValidate.GetMd5(txtNewSecondPwd.Value)) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("TwoPasswordChanged") + "');", true);//二级密码修改成功
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("TwoPasswordfailed") + "');", true);//二级密码修改失败
                }
            }
        }
    }
}
    