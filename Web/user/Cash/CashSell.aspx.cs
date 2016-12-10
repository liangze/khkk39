using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.user.Cash
{
    public partial class Cashsell : PageCore
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            btnSubmit.Text = GetLanguage("Submit");
            lgk.Model.tb_globeParam Shares2 = paramBLL.GetModel("ParamName='Shares2'");// 获取出售注册点单价
            txtPrice.Text = Shares2.ParamVarchar + " $/" + GetLanguage("Registeredcurrency");

            if (!IsPostBack)
            {
                BindBank();
                txtnumber.Text = "";
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        /// <summary>
        /// 支付密码
        /// </summary>
        /// <returns></returns>
        protected bool validateSecondPass(string strPwd)
        {
            if (txtPayPassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Paymentempty") + "');", true);//支付密码不能为空
                return false;
            }
            if (PageValidate.GetMd5(txtPayPassword.Value.Trim()) != strPwd)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Paymentempty") + "');", true);//支付级密码不正确
                return false;
            }
            return true;
        }

        /// <summary>
        /// 绑定銀行
        /// </summary>
        private void BindBank()
        {
            #region 绑定银行所在地
            if (Language == "zh-cn")
            {
                bind_DropDownList(dropProvince, provinceBLL.GetList("").Tables[0], "provinceID", "province"); //銀行省份
            }
            else
            {
                bind_DropDownList(dropProvince, provinceBLL.GetList("").Tables[0], "provinceID", "provinceen"); //銀行省份
            }
            #endregion

            #region 绑定银行
            string strBankName = new lgk.BLL.tb_bankName().GetModel(1).BankName;
            string[] s = strBankName.Split('|');

            dropBank.Items.Clear();
            strBankName = s[0];
            if (s.Length < 2)
            {
                return;
            }
            if (currentCulture == "en-us")
            {
                strBankName = s[1];
            }
            string[] a = strBankName.Split(',');
            ListItem item_list = new ListItem();
            item_list.Value = "0";
            item_list.Text = GetLanguage("PleaseSselect");//"-请选择-"
            this.dropBank.Items.Add(item_list);
            foreach (string b in a)
            {
                ListItem item_list1 = new ListItem();
                item_list1.Value = b;
                item_list1.Text = b;
                this.dropBank.Items.Add(item_list1);
            }
            #endregion
        }
        protected bool RegValidate()
        {
            #region 银行信息验证
            if (this.dropBank.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseSelectBank") + "');", true);//请选择开户银行
                return false;
            }

            if (this.dropProvince.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Banklocation") + "');", true);//请选择银行所在地
                return false;
            }
            if (this.txtBankBranch.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("BankIsNull") + "');", true);//银行支行不能为空
                return false;
            }
            if (this.txtBankAccount.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("BankCardIsNull") + "');", true);//银行卡号不能为空
                return false;
            }

            if (this.txtBankAccountUser.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NameIsNull") + "');", true);//开户名不能为空
                return false;
            }
            return true;
            #endregion
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RegValidate())
            {


                decimal sheaer = getParamAmount("Shares3");//获取出售注册点数的倍数基数
                if (txtnumber.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Salenumberempty") + "！');", true);//出售数量不能为空
                    return;
                }
                int sellnum = 0;
                if (!int.TryParse(txtnumber.Text.Trim(), out sellnum))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("EnterValidAmount") + "！');", true);//请输入有效金额
                    return;
                }
                if (sellnum <= 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("EnterValidAmount") + "！');", true);//请输入有效金额
                    return;
                }
                if (sellnum % sheaer != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseInput") + "" + sheaer + "" + GetLanguage("Multiples") + "！');", true);//判断出售数量是否是110的倍数
                    return;
                }


                int iUnitNum = Convert.ToInt32(txtUnitNum.Value.Trim());//发布件数1
                lgk.Model.tb_globeParam Shares2 = paramBLL.GetModel("ParamName='Shares2'");
                decimal txtPrice = decimal.Parse(Shares2.ParamVarchar);//获取注册点单价
                decimal tal = Math.Round(txtPrice * (Convert.ToInt32(txtnumber.Text)), 4);//出售商品总价格

                lgk.Model.tb_globeParam Shares4 = paramBLL.GetModel("ParamName='Shares4'");//注册点数手续费参数
                int x = int.Parse(Shares4.ParamVarchar) * Convert.ToInt32(txtnumber.Text) / 100;//出售注册点收取手续费



                lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
                lgk.Model.Cashsell cashsellInfo = new lgk.Model.Cashsell();
                userInfo = userBLL.GetModel(getLoginID());
                #region 赋值给注册点数销售表实体
                cashsellInfo.Title = txtnumber.Text + "注册点数=" + tal + "$，物超所值！";
                cashsellInfo.UserID = getLoginID();
                cashsellInfo.Amount = tal;//商品价格
                cashsellInfo.Number = Convert.ToInt32(txtnumber.Text);//单件数量
                cashsellInfo.Price = txtPrice;//商品单价
                cashsellInfo.SaleNum = Convert.ToInt32(txtnumber.Text);//出售商品剩余量
                cashsellInfo.UnitNum = 1;//发布件数

                cashsellInfo.Charge = x;//每件所需手续费
                cashsellInfo.SellDate = DateTime.Now;//提交时间
                cashsellInfo.Remark = "";
                cashsellInfo.PurchaseID = 0;
                cashsellInfo.IsSell = 0;
                cashsellInfo.TypeID = 1;//出售商品金币类型 --1，是注册点数；2，是夸克币
                cashsellInfo.BankAccount = this.txtBankAccount.Value.Trim();
                cashsellInfo.BankAccountUser = this.txtBankAccountUser.Value.Trim();// "開户姓名";
                cashsellInfo.BankName = this.dropBank.SelectedValue;// "開户銀行";
                cashsellInfo.BankBranch = this.txtBankBranch.Value.Trim();// "支行名稱";
                cashsellInfo.BankInProvince = dropProvince.SelectedItem.Text;// "銀行所在省份";

                #endregion
                int number = 0;//出售数量
                if (!int.TryParse(txtnumber.Text.Trim(), out number))
                {
                    MessageBox.MyShow(this, GetLanguage("Pleasedata"));//请输入有效数据
                    return;
                }
                decimal BonusAccountin = userInfo.BonusAccount - number - x;//会员注册点账户余额

                #region 加入流水账表
                lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                journalInfo.UserID = cashsellInfo.UserID;
                journalInfo.Remark = "卖出注册点";
                journalInfo.RemarkEn = "Sell Circulating gold";
                journalInfo.InAmount = 0;
                journalInfo.OutAmount = cashsellInfo.Number * iUnitNum;//注册点数;
                journalInfo.BalanceAmount = BonusAccountin;// 此时注册点数账户结余
                journalInfo.JournalDate = DateTime.Now;
                journalInfo.JournalType = 1;//1是注册点数
                journalInfo.Journal01 = cashsellInfo.UserID;
                #endregion

                lgk.Model.tb_user maadel = LoginUser;
                if (validateSecondPass(maadel.SecondPassword))
                {

                    if (userInfo.BonusAccount < Convert.ToInt32(txtnumber.Text))
                    {
                        MessageBox.MyShow(this, GetLanguage("GoldInsufficient"));
                        return;
                    }
                    if (cashsellBLL.Add(cashsellInfo) > 0 && journalBLL.Add(journalInfo) > 0 && UpdateAccount("BonusAccount", getLoginID(), number + x, 0) > 0)
                    {

                        Response.Write("<script>alert('" + GetLanguage("Successful") + "');location.href='../Stock/eptransaction.aspx';</script>");
                        return;
                    }
                    else
                    {
                        MessageBox.MyShow(this, GetLanguage("OperationFailed"));
                        return;
                    }

                }
            }
        }
        protected void txtnumber_TextChanged(object sender, EventArgs e)
        {
            decimal Shares4 = getParamAmount("Shares4");//出售注册点收取手续费
            lgk.Model.tb_globeParam Shares2 = paramBLL.GetModel("ParamName='Shares2'");// 获取出售注册点单价
            decimal price = decimal.Parse(Shares2.ParamVarchar);
            //decimal price = 0;//注册点数单价
            //if(!decimal.TryParse(txtPrice.Text.Trim(), out price))
            //{
            //    MessageBox.MyShow(this, GetLanguage("Pleasedata"));//请输入有效数据
            //    return;
            //}
            int number = 0;//出售数量
            if (!int.TryParse(txtnumber.Text.Trim(), out number))
            {
                MessageBox.MyShow(this, GetLanguage("Pleasedata"));//请输入有效数据
                return;
            }
            decimal tolNumber = number + Shares4 * number / 100;
            lgk.Model.tb_user userInfo = userBLL.GetModel(getLoginID());
            if (userInfo.BonusAccount < tolNumber)
            {
                txtnumber.Text = "";
                MessageBox.MyShow(this, GetLanguage("NotRegistered"));//注册币账户余额不足
                return;
            }
            decimal tal = Math.Round(price * number, 4);//出售商品总价格
            txtFactorage.Value = (number * Shares4 / 100).ToString() + " " + GetLanguage("Registeredcurrency");//<!--注册点数-->";
            txttal.Value = tal.ToString() + " $";



        }


    }
}