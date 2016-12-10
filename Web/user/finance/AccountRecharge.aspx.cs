using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
namespace Web.user.finance
{
    public partial class AccountRecharge : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.FirstPageText = GetLanguage("FirstPage");
            AspNetPager1.LastPageText = GetLanguage("LastPage");
            AspNetPager1.NextPageText = GetLanguage("NextPage");
            AspNetPager1.PrevPageText = GetLanguage("PrevPage");
         
            if (!IsPostBack)
            {

                BindCurrency();
                BindData();
                btnSubmit.Text = GetLanguage("Submit");//提交
                btnSubmit.OnClientClick = "javascript:return confirm('" + GetLanguage("RechargeConfirm") + "')";
                btnSearch.Text = GetLanguage("Search");//搜索
                
            }
        }

        private void BindCurrency()
        {
            if (GetLanguage("LoginLable") == "zh-cn")
            {
                dropCurrency.Items.Add(new ListItem("-请选择-", "0"));
                dropCurrency.Items.Add(new ListItem("激活点数", "1"));
                dropCurrency.Items.Add(new ListItem("注册点数", "2"));

                DropDownList1.Items.Add(new ListItem("-请选择-", "0"));
                DropDownList1.Items.Add(new ListItem("充值通道 1", "1"));
                DropDownList1.Items.Add(new ListItem("充值通道 2", "2"));
                DropDownList1.Items.Add(new ListItem("比特币地址", "3"));
                DropDownList1.Items.Add(new ListItem("莱特币地址", "4"));

                dropType.Items.Add(new ListItem("-请选择-", "0"));
                dropType.Items.Add(new ListItem("激活点数", "1"));
                dropType.Items.Add(new ListItem("注册点数", "2"));
            }
            else
            {
                dropCurrency.Items.Add(new ListItem("-Please Choose-", "0"));
                dropCurrency.Items.Add(new ListItem("Activation points", "1"));
                dropCurrency.Items.Add(new ListItem("Registration points", "2"));


                dropType.Items.Add(new ListItem("-Please choose-", "0"));
                dropType.Items.Add(new ListItem("Activation points", "1"));
                dropType.Items.Add(new ListItem("Registration points", "2"));

                DropDownList1.Items.Add(new ListItem("-Please choose-", "0"));
                DropDownList1.Items.Add(new ListItem("Recharge channel 1", "1"));
                DropDownList1.Items.Add(new ListItem("Recharge channel 2", "2"));
                DropDownList1.Items.Add(new ListItem("Bitcoin address", "3"));
                DropDownList1.Items.Add(new ListItem("Wright currency address", "4"));

            }
        }




        protected void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            string strUserCode = txtUserCode.Text.Trim();
            var user = userBLL.GetModel(" UserCode='" + strUserCode + "'");
            if (user != null)
            {
                txtTrueName.Text = user.TrueName;
            }
            else
            {
                txtTrueName.Text = string.Empty;
                MessageBox.Show(this, GetLanguage("numberIsExist"));//会员编号不存在
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long toUserID = 0;
            lgk.Model.tb_user userInfo = userBLL.GetModel(getLoginID());
            lgk.Model.tb_change changeInfo = new lgk.Model.tb_change();

            if (dropCurrency.SelectedValue == "0")
            {
                MessageBox.Show(this, "" + GetLanguage("Pleaseseleecharge") + "");//请选择币种类型
                return;
            }
            if (DropDownList1.SelectedValue == "0")
            {
                MessageBox.Show(this, "" + GetLanguage("PleaseRechargeaddress") + "");//请选择充值地址
                return;
            }

            int iTypeID = int.Parse(dropCurrency.SelectedValue);
            int iTyid = int.Parse(DropDownList1.SelectedValue);

            string strMoney = txtMoney.Text.Trim();
            if (string.IsNullOrEmpty(strMoney))
            {
                MessageBox.Show(this, "" + GetLanguage("kkkAmountcharge") + "");//充值金额不能为空
                return;
            }
            decimal iMoney = 0;
            if (!decimal.TryParse(strMoney, out iMoney))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("EnterValidAmount") + "');", true);//请输入有效金额
                return;
            }

            string strUserCode = txtUserCode.Text.Trim();
            if(!string.IsNullOrEmpty(strUserCode))
            {
                MessageBox.Show(this, "" + GetLanguage("PleaseNumber") + "");//请输入会员编号
                return;
            }
            var toUser = userBLL.GetModel(" UserCode='" + strUserCode + "'");
            if (toUser == null)
            {
                MessageBox.Show(this, GetLanguage("numberIsExist"));//会员编号不存在
                return;
            }
            else
            {
                toUserID = int.Parse(toUser.UserID.ToString());
            }

            if (toUserID <= 0)
            {
                MessageBox.Show(this, GetLanguage("rechargeobjectExist"));//充值对象不存在
                return;
            }
            //如果以选择图片
            //图片
            string fileName = FileUpload1.FileName;
            if (FileUpload1.HasFile)
            {

                
                //保存图片
                FileUpload1.SaveAs(Server.MapPath("../../Upload/" + fileName));

                //提示
               // divState.InnerHtml = "<h5>上传图片成功！</h5>";

            }
            else
            {
                //提示
                // divState.InnerHtml = "<h5>请选择上传图片！</h5>";
                MessageBox.Show(this, GetLanguage("QUploadDocument"));//请选择上传图片
                return;
            }

            lgk.Model.tb_remit remitInfo = new lgk.Model.tb_remit();
            remitInfo.UserID = userInfo.UserID;
            remitInfo.RechargeableDate = DateTime.Now;//汇款具体时间
            remitInfo.State = 0;
            remitInfo.AddDate = DateTime.Now;
            remitInfo.RemitMoney = iMoney;
            
            if (iTypeID == 1)
            {
                remitInfo.YuAmount = userInfo.GLmoney + iMoney;//激活点数
            }
            else if (iTypeID == 2)
            {
                remitInfo.YuAmount = userInfo.BonusAccount + iMoney;//注册点数
            }
            remitInfo.Remark = "";

            lgk.Model.tb_vk image = vkBLL.GetModel(iTyid);//
            remitInfo.BankName = image.vkname;//汇入账户
            remitInfo.BankAccount = image.walletaddress;//钱包地址
            remitInfo.BankAccountUser = "";// this.lblBankAccountUser.Text;

            remitInfo.Remit001 = iTypeID;//充值类型
            remitInfo.Remit002 = Convert.ToInt32(getLoginID());
            remitInfo.Remit003 = "";//strOutBank;//汇出银行
            remitInfo.Remit004 = "";//strOutAccount;//汇出账户
            remitInfo.Image = "../../Upload/" + fileName;
            remitInfo.PassDate = DateTime.Now;

            long iRemitID = remitBLL.Add(remitInfo);

            if (iRemitID > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("application") + "');window.location.href='AccountRecharge.aspx';", true);//申请汇款成功
            }
        }
        private string GetWhere()
        {
            string strWhere = "r.Remit002=" + getLoginID();

            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();
            if (dropType.SelectedValue != "0")
            {
                
                strWhere += " AND r.Remit001 = " + dropType.SelectedValue + "";
                string where = strWhere;
                if (strStartTime != "" && strEndTime == "")
                {
                    strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  >= '" + strStartTime + "' ");
                }
                else if (strStartTime == "" && strEndTime != "")
                {
                    strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  <= '" + strEndTime + "' ");
                }
                else if (strStartTime != "" && strEndTime != "")
                {
                    strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  between '" + strStartTime + "' and '" + strEndTime + "' ");
                }
                else if (strStartTime == "" && strEndTime == "")
                {
                    strWhere = where;
                }
            }
            if (dropType.SelectedValue == "0")
            {
                string where = strWhere;
                strWhere += " AND r.Remit001 = " + dropType.SelectedValue + "";
                
                if (strStartTime != "" && strEndTime == "")
                {
                    strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  >= '" + strStartTime + "' ");
                }
                else if (strStartTime == "" && strEndTime != "")
                {
                    strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  <= '" + strEndTime + "' ");
                }
                else if (strStartTime != "" && strEndTime != "")
                {
                    strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  between '" + strStartTime + "' and '" + strEndTime + "' ");
                }
                else if (strStartTime == "" && strEndTime == "")
                {
                     strWhere= where;
                }

            }
            return strWhere;

        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData()
        {
            //bind_repeater(changeBLL.GetDataSet(GetWhere()), Repeater1, "ChangeDate desc", tr1, AspNetPager1);
            bind_repeater(GetRemitList(GetWhere()), Repeater1, "AddDate desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 根据选择級別获取金額
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dropCurrency1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "1")
            {
                lgk.Model.tb_vk image = new lgk.Model.tb_vk();
                image = vkBLL.GetModel(1);
                vimg.ImageUrl = image.imgurl;
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                lgk.Model.tb_vk image = new lgk.Model.tb_vk();
                image = vkBLL.GetModel(2);
                vimg.ImageUrl = image.imgurl;
            }
            else if (DropDownList1.SelectedValue == "3")
            {
                lgk.Model.tb_vk image = new lgk.Model.tb_vk();
                image = vkBLL.GetModel(3);
                vimg.ImageUrl = image.imgurl;
            }
            else if (DropDownList1.SelectedValue == "4")
            {
                lgk.Model.tb_vk image = new lgk.Model.tb_vk();
                image = vkBLL.GetModel(4);
                vimg.ImageUrl = image.imgurl;
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long iID = Convert.ToInt64(e.CommandArgument);
           
            if (e.CommandName.Equals("Remove"))//删除  
            {
                lgk.Model.tb_remit remit = remitBLL.GetModel(iID);
                if (remit == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordDeleted") + "');", true);//该记录已删除，无法再进行此操作
                    return;
                }
                else
                {
                    if (remit.State == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordDeleted") + "');", true);
                        return;
                    }
                    if (remitBLL.Delete(iID))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("DeletedSuccessfully") + "');window.location.href='AccountRecharge.aspx';", true);//删除成功
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("DeleteFailed") + "');", true);//删除失败
                    }
                }
                
            }
            //if (e.CommandName.Equals("Detail"))
            //{
            //    Response.Redirect("AccountRecharImg.aspx?id=" + iID);
            //}
        }

    }
}