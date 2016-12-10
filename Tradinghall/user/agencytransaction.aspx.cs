using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
namespace Tradinghall.user
{
    public partial class agencytransaction :PageCore// System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lgk.Model.tb_globeParam QuarkTra4 = paramBLL.GetModel("ParamName='QuarkTra4'");//获取挂售夸克币最低阶
            MiniPrice.Value = QuarkTra4.ParamVarchar+"$/"+GetLanguage("QuarkCoin");
            lgk.Model.tb_globeParam QuarkTra5 = paramBLL.GetModel("ParamName='QuarkTra5'");//获取挂售夸克币最高价
            MaxiPrice.Value = QuarkTra5.ParamVarchar + "$/" + GetLanguage("QuarkCoin");

            btnSubmit.Text = GetLanguage("SellImmediately");
            AspNetPager1.FirstPageText = GetLanguage("FirstPage");
            AspNetPager1.LastPageText = GetLanguage("LastPage");
            AspNetPager1.NextPageText = GetLanguage("NextPage");
            AspNetPager1.PrevPageText = GetLanguage("PrevPage");
            AspNetPager2.FirstPageText = GetLanguage("FirstPage");
            AspNetPager2.LastPageText = GetLanguage("LastPage");
            AspNetPager2.NextPageText = GetLanguage("NextPage");
            AspNetPager2.PrevPageText = GetLanguage("PrevPage");
            if (!IsPostBack)
            {
                BindData();
                BindData2();


            }
        }
        /// <summary>
        ///查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "SaleNum>'0' AND IsSell=0  AND (TypeID=2) group by Price";//and UserID<>" + getLoginID() +"
            return strWhere;
        }
        /// <summary>
        ///查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere1()
        {
            string strWhere1 = "IsBuy=0 AND TypeID=2 group by Price";//UserID<>" + getLoginID() +"
            return strWhere1;
        }

        private void BindData()
        {
            bind_repeater(cashsellBLL.GetList1(GetWhere()), Repeater1, "Price asc", tr1, AspNetPager1);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();

        }
        private void BindData2()
        {
            bind_repeater(cashbuyBLL.GetList1(GetWhere1()), Repeater2, "Price desc", tr2, AspNetPager2);
        }
        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindData2();

        }
        /// <summary>
        /// 验证二级密码
        /// </summary>
        /// <returns></returns>
        protected bool validateSecondPass(string strPwd)
        {
            if (paypwd.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OldTwoPassEmpty") + "');", true);//旧二级密码不能为空
                return false;
            }
            if (PageValidate.GetMd5(paypwd.Value.Trim()) != strPwd)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("oldTwoPassCorrect") + "');", true);//旧二级密码不正确
                return false;
            }
            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            lgk.Model.tb_user maadel = LoginUser;
            if (validateSecondPass(maadel.SecondPassword))
            {
                //decimal txtPrice = decimal.Parse(price.Value.Trim());//获取夸克币单价
                decimal txtPrice = 0;//单价
                if (!decimal.TryParse(price.Value.Trim(), out txtPrice))
                {
                    MessageBox.MyShow(this, GetLanguage("Pleasedata"));//请输入有效数据
                    return;
                }

                if (sellNum.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('"+GetLanguage("Salenumberempty")+"！');", true);//出售数量不能为空
                    return;
                }
                int number = 0;//出售数量
                if (!int.TryParse(sellNum.Value.Trim(), out number))
                {
                    MessageBox.MyShow(this, GetLanguage("Pleasedata"));//请输入有效数据
                    return;
                }
                if (int.Parse(sellNum.Value.Trim())<=0)
                {
                    MessageBox.MyShow(this, GetLanguage("Pleasedata"));//请输入有效数据
                    return;
                }
                if (txtPrice > getParamAmount("QuarkTra5"))//挂售夸克币最高价
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PriceInputError") + "！');", true);//出售数量不能为空
                    return;
                }
                if (txtPrice < getParamAmount("QuarkTra4"))//挂售夸克币最低阶
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PriceInputError") + "！');", true);//出售数量不能为空
                    return;
                }
                int iUnitNum = 1;//发布件数1

                lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
                lgk.Model.Cashsell cashsellInfo = new lgk.Model.Cashsell();
                userInfo = userBLL.GetModel(getLoginID());
                #region 赋值给金币销售表实体
                cashsellInfo.Title = sellNum.Value.Trim() + "夸克币=" + txtPrice * (Convert.ToInt32(sellNum.Value.Trim())) + "美元，物超所值！";
                cashsellInfo.UserID = getLoginID();
                cashsellInfo.Amount = txtPrice * (Convert.ToInt32(sellNum.Value.Trim()));//商品价格
                cashsellInfo.Number = Convert.ToInt32(sellNum.Value.Trim());//单件数量
                cashsellInfo.Price = txtPrice;//商品单价
                cashsellInfo.SaleNum = Convert.ToInt32(sellNum.Value.Trim());
                cashsellInfo.UnitNum = 1;//发布件数

                cashsellInfo.Charge = 0; //Convert.ToDecimal(sellNum.Value.Trim());//每件所需手续费
                cashsellInfo.SellDate = DateTime.Now;//提交时间
                cashsellInfo.Remark = "";
                cashsellInfo.PurchaseID = 0;
                cashsellInfo.IsSell = 0;//0是挂单中，1是已完成
                cashsellInfo.TypeID = 2;//出售商品金币类型 --1，是注册点数；2，是夸克币
                #endregion

                #region 加入流水账表
                lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                journalInfo.UserID = cashsellInfo.UserID;
                journalInfo.Remark = "卖出夸克币";
                journalInfo.RemarkEn = "Sell Quark coin";
                journalInfo.InAmount = 0;
                journalInfo.OutAmount = cashsellInfo.Number * iUnitNum;//+  txtshouxfei.Value.Trim();//出售数量
                journalInfo.BalanceAmount = userInfo.User011 - Convert.ToInt32(sellNum.Value.Trim());// - txtshouxfei.Value.Trim();
                journalInfo.JournalDate = DateTime.Now;
                journalInfo.JournalType = 8;//1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                journalInfo.Journal01 = cashsellInfo.UserID;
                #endregion

                decimal dBonusAccount = Convert.ToInt32(sellNum.Value.Trim());
                if (userInfo.User011 < dBonusAccount)
                {
                    MessageBox.MyShow(this, GetLanguage("GoldInsufficient"));
                    return;
                }
                if (cashsellBLL.Add(cashsellInfo) > 0 && journalBLL.Add(journalInfo) > 0 && UpdateAccount("User011", getLoginID(), dBonusAccount, 0) > 0)
                {
                    string iResult = cashsellBLL.ExecProcedure("Proc_CommissionedBuy",txtPrice, getLoginID());
                    Response.Write("<script>alert('" + GetLanguage("Successful") + "');location.href='agencytransaction.aspx';</script>");//
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OperationFailed") + "');location.href='agencytransaction.aspx';", true);//操作成功
                }
                    //MessageBox.MyShow(this, GetLanguage("OperationFailed"));
            }
        }
    }
}