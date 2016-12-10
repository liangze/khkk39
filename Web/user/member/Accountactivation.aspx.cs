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
using System.Text.RegularExpressions;
using DataAccess;

namespace Web.user.member
{
    public partial class Accountactivation : PageCore //System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Text=GetLanguage("activatio");
            if (!IsPostBack)
            {
                //BindBank();
                //BindQuestion();

                ShowData();
                // btnSubmit.Text = GetLanguage("Submit");//提交

            }
        }
        private void ShowData()
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID());
            txtRegMoney.Value = userInfo.RegMoney.ToString();
            txtRegisterPoint.Value = userInfo.BonusAccount.ToString();
            txtActivationPoint.Value = userInfo.GLmoney.ToString();
            int ActivationState = userInfo.IsOpend;
            int x = ActivationState;
            
                if (ActivationState == 0)
                {
                    Button1.Visible = true;
                txtActivationState.Value = GetLanguage("Notactive"); //"not active";
                }
                if (ActivationState == 2)
                {
                    Button1.Visible = false;
                    txtActivationState.Value = GetLanguage("Alreadyactivated");
                }
            
               

            txtUserCode.Value = userInfo.UserCode;

            LevelName.Value = levelBLL.GetLevelName(userInfo.LevelID);
        }

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


        protected void Button_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID());
            string msg = null;
            try
            {
                msg = userBLL.proc_open(userInfo.UserID, 2, 0, 0);
                if (msg == null)
                {
                    msg = "激活失败";
                }
                else if (msg == "")
                {
                    msg = "激活成功";
                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + msg + "');", true);
                ShowData();
            }
            catch (Exception ex)
            {
                Library.LogHelper.SaveLog("激活失败！" + ex.Message, "open");
                Response.Write("<script>alert('激活失败')</script>;location.href='Accountactivation.aspx';");
            }
        }

    }
}