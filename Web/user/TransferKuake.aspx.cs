using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class TransferKuake : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCurrency();
                BindData();
            }
        }

        private void BindCurrency()
        {
            if (GetLanguage("LoginLable") == "zh-cn")
            {
                dropCurrency.Items.Add(new ListItem("-请选择-", "0"));
                dropCurrency.Items.Add(new ListItem("夸克币转存币", "1"));
            }
            else
            {
                dropCurrency.Items.Add(new ListItem("-Please choose-", "0"));
                dropCurrency.Items.Add(new ListItem("Currency to cunbi", "1"));
            }

            IList<lgk.Model.tb_globeParam> myList = new lgk.BLL.tb_globeParam().GetModelList(" ParamName like 'cunday%'");
            dropDay.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = GetLanguage("PleaseSselect");
            dropDay.Items.Add(li);
            foreach (lgk.Model.tb_globeParam item in myList)
            {
                ListItem items = new ListItem();
                items.Value = item.ParamName;
                items.Text = item.ParamVarchar;
                dropDay.Items.Add(items);
            }
        }

        private string GetWhere()
        {
            string strWhere = string.Format(" UserID=" + getLoginID());

            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();
            if (GetLanguage("LoginLable") == "en-us")
            {
                strStartTime = this.txtStartEn.Text.Trim();
                strEndTime = this.txtEndEn.Text.Trim();
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),AddTime,120) >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),AddTime,120) <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),AddTime,120) between '" + strStartTime + "' and '" + strEndTime + "' ");
            }
            return strWhere;
        }
        

        public void BindData()
        {
            bind_repeater(cunbiBLL.GetList(GetWhere()), Repeater1, "AddTime desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int iTransfer = Convert.ToInt32(dropCurrency.SelectedValue);
            if (iTransfer == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("ChooseTransfer")+ "');", true);
                return;
            }

            string strDay = dropDay.SelectedValue;
            if (strDay == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择存币天数');", true);
                return;
            }

            int iday = Convert.ToInt32(dropDay.SelectedItem.Text);
            decimal iRate = getParamAmount(strDay.Replace("day","_"));

            string strMoney = txtMoney.Text.Trim();
            if (string.IsNullOrEmpty(strMoney))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入转账金额');", true);
                return;
            }
            decimal iMoney = 0;
            if(!decimal.TryParse(strMoney, out iMoney))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入有效的转账金额');", true);
                return;
            }

            lgk.Model.tb_user userModel = LoginUser;

            if (iMoney > userModel.User011)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('夸克币余额不足');", true);
                return;
            }
            
            //进入tb_cunbi表（存币奖）
            lgk.Model.tb_cunbi cunbiModel = new lgk.Model.tb_cunbi();
            cunbiModel.UserID = LoginUser.UserID;
            cunbiModel.SettleDay = iday;
            cunbiModel.SurplusDay = iday;
            cunbiModel.Amount = iMoney;
            cunbiModel.States = 0;
            cunbiModel.AddTime = DateTime.Now;
            cunbiModel.c002 = iRate;

            if (cunbiBLL.Add(cunbiModel)>0)
            {
                //夸克币转到存币
                UpdateAccount("User011", userModel.UserID, iMoney, 0);//夸克币
                UpdateAccount("User013", userModel.UserID, iMoney, 1);//存币
                //加入流水账表(夸克币减少)
                lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                jmodel.UserID = userModel.UserID;
                jmodel.Remark = "夸克币转到存币";
                jmodel.RemarkEn = "Quark coin to cunbi";
                jmodel.InAmount = 0;
                jmodel.OutAmount = iMoney;
                jmodel.BalanceAmount = userBLL.GetMoney(userModel.UserID, "User011");
                jmodel.JournalDate = DateTime.Now;
                jmodel.JournalType = 8;
                jmodel.Journal01 = userModel.UserID;
                journalBLL.Add(jmodel);

                //加入流水账表(存币增加)
                lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                journalInfo.UserID = userModel.UserID;
                journalInfo.Remark = "获得存币";
                journalInfo.RemarkEn = "Get cunbi";
                journalInfo.InAmount = iMoney;
                journalInfo.OutAmount = 0;
                journalInfo.BalanceAmount = userBLL.GetMoney(userModel.UserID, "User013");
                journalInfo.JournalDate = DateTime.Now;
                journalInfo.JournalType = 10;
                journalInfo.Journal01 = userModel.UserID;
                journalBLL.Add(journalInfo);

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('添加成功');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('添加失败');", true);
            }
            BindData();
        }

    }
}