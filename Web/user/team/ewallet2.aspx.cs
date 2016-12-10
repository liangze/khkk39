using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.team
{
    public partial class ewallet2 : PageCore // System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.FirstPageText = GetLanguage("FirstPage");
            AspNetPager1.LastPageText = GetLanguage("LastPage");
            AspNetPager1.NextPageText = GetLanguage("NextPage");
            AspNetPager1.PrevPageText = GetLanguage("PrevPage");
            Button1.Text = GetLanguage("Submit");
            if (!IsPostBack)
            {
                Level_DataBind();//页面加载时把会员等级进行绑定
                ShowData();
                bind_pro();
            }
        }
        private void ShowData()
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID());
            txtUserCode.Value = userInfo.UserCode;
            txtTrueName.Value = userInfo.TrueName;
            LevelName.Value = levelBLL.GetLevelName(userInfo.LevelID, currentCulture);
            txtRegMoney.Value = userInfo.RegMoney.ToString();//注册金额
                                                             // txtCashCurrency.Value = userInfo.StockMoney.ToString();
            txtRegisterPoint.Value = userInfo.BonusAccount.ToString();//注册点数
            txtActivationPoints.Value = userInfo.GLmoney.ToString();//激活点数
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

        /// <summary>
        /// 会员等级绑定
        /// </summary>
        public void Level_DataBind()
        {
            IList<lgk.Model.tb_level> myList = new lgk.BLL.tb_level().GetModelList("");
            LevelSelect.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            if (GetLanguage("LoginLable") == "zh-cn")
            {
                li.Text = "-请选择-";
            }
            else
            {
                li.Text = "-Please select-";
            }

            LevelSelect.Items.Add(li);

            foreach (lgk.Model.tb_level item in myList)
            {
                ListItem items = new ListItem();
                items.Value = item.LevelID.ToString();
                items.Text = item.LevelName;
                LevelSelect.Items.Add(items);
            }
        }
        /// <summary>
        /// 会员升级补差额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LevelSelect_SelectedIndexChanged1(object sender, EventArgs e)
        {
            lgk.Model.tb_level userlevel = levelBLL.GetModel(int.Parse(LevelSelect.SelectedValue.ToString()));
            decimal dRegMoney = getParamAmount("Level" + LevelSelect.SelectedValue);//获取相应会员等级对应的注册金额
            int strPoundage = int.Parse(getParamVarchar("Poundage1"));
            int txtpounda = int.Parse(getParamVarchar("Poundage2"));
            lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID());
            decimal RegMoney = userInfo.RegMoney;//获取当前会员的注册金额
            decimal xregmoney = (dRegMoney - RegMoney) * strPoundage / 100;
            decimal xActivationPoint = (dRegMoney - RegMoney) * txtpounda / 100;
            if (userlevel != null)
            {
                if (xregmoney <= 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Empsdfdsts") + "');", true);//晋升级别不能小于或等于当前会员级别
                    return;
                }
                else
                {
                    txtPaymentRegPoint.Value = xregmoney.ToString();
                    txtPaymentActivationPoint.Value = xActivationPoint.ToString();
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Isdelect") + "');", true);//该会员不存在
                txtPaymentRegPoint.Value = "";
            }
        }
        private void bind_pro()
        {
            string strWhere = " 1=1 ";//1 会员晋升 2 开通报单中心
            lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID());
            string userid = userInfo.UserID.ToString();
            if (userid != "")
            {
                strWhere += " and p.UserID like '%" + userid + "%'";
            }
            bind_repeater(GetProList(strWhere), Repeater1, "AddDate desc", tr1, AspNetPager1);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind_pro();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID());
            lgk.Model.tb_userPro userpro = proBLL.GetModelByUserID(Convert.ToInt32(userInfo.UserID));
            if (userInfo.IsOpend == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("sssedwhfw") + "');", true);              
                return;
            }
            int endLevel = Convert.ToInt32(LevelSelect.SelectedValue.Trim());
            if (endLevel == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("sssedwhfw") + "');", true);
               
                return;
            }
            if (endLevel <= userInfo.LevelID)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Empsdfdsts") + "');", true);
              
                return;
            }
            decimal regPoint = decimal.Parse(txtPaymentRegPoint.Value.Trim());//获取页面中的缴纳注册点
            decimal actionPoint = decimal.Parse(txtPaymentActivationPoint.Value.Trim());//获取页面中的缴纳激活点
            if (regPoint > userInfo.BonusAccount)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhucfuz") + "');", true);
               
                return;
            }
            if (actionPoint > userInfo.GLmoney)
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("zhuAcccfuz") + "');", true);
                return;
               
            }
            if (txtPaymentRegPoint.Value.Trim() != null)
            {
                //记录升级表
                lgk.Model.tb_userPro upModel = new lgk.Model.tb_userPro();
                upModel.UserID = Convert.ToInt32(userInfo.UserID);
                upModel.LastLevel = userInfo.LevelID;
                upModel.Remark = "1";//0是后台升级，1是前台自助升级
                upModel.Flag = 0;
                upModel.Pro001 = 0;
                upModel.Pro003 = decimal.Parse(txtPaymentActivationPoint.Value.Trim());
                upModel.EndLevel = endLevel;
                upModel.ProMoney = decimal.Parse(txtPaymentRegPoint.Value.Trim());
                upModel.AddDate = DateTime.Now;
                upModel.FlagDate = DateTime.Now;
                // proBLL.Add(upModel);//插入升级记录数据
                //upModel.Pro008 = "1";//1会员晋升 2 报单中心 
                if (proBLL.Add(upModel) > 0 && flag_pro(Convert.ToInt32(userInfo.UserID), 1))
                {
                    UpdateAccount("BonusAccount", userInfo.UserID, regPoint, 0);//更新注册点数账户
                    UpdateAccount("GLmoney", userInfo.UserID, actionPoint, 0);//更新注册点数账户
                    //加入流水账表（注册点数减少）
                    lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                    jmodel.UserID = userInfo.UserID;
                    jmodel.Remark = "会员升级";
                    jmodel.RemarkEn = "Membership upgrade";
                    jmodel.InAmount = 0;
                    jmodel.OutAmount = regPoint;
                    jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                    jmodel.JournalDate = DateTime.Now;
                    jmodel.JournalType = 1;
                    jmodel.Journal01 = userInfo.UserID;
                    journalBLL.Add(jmodel);
                    //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    //加入流水账表(激活点数减少)
                    lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                    journalInfo.UserID = userInfo.UserID;
                    journalInfo.Remark = "会员升级";
                    journalInfo.RemarkEn = "Membership upgrade";
                    journalInfo.InAmount = 0;
                    journalInfo.OutAmount = actionPoint;
                    journalInfo.BalanceAmount = userBLL.GetMoney(getLoginID(), "GLmoney");
                    journalInfo.JournalDate = DateTime.Now;
                    journalInfo.JournalType = 5;
                    journalInfo.Journal01 = userInfo.UserID;
                    journalBLL.Add(journalInfo);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Memsromoscess") + "');window.location.href='ewallet2.aspx';", true);//会员前台台晋升成功
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OperationFailed") + "');", true);//会员前台台晋升失败
                    return;
                }

            }

        }

    }
}