using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Web.user.Cash
{
    public partial class MyCashbuy : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long CashsellID = long.Parse(Request.QueryString["CashsellID"].ToString());
            lgk.Model.Cashsell model = cashsellBLL.GetModel(CashsellID);
            if(model != null)
            {
                txtnumber.Enabled = false;
                txtnumber.Text = model.SaleNum.ToString();
                ltPayment.Text = model.Amount.ToString();
                ltBankAccount.Text = userBLL.GetUserCode(model.UserID);
                ltTitle.Text = model.Title;
                Amount.Text = model.Price.ToString();
                ltNumber.Text = model.SaleNum.ToString();
                ltPrice.Text = model.Amount.ToString();
                txtBankBranch.Value = model.BankBranch;
                dropBank.Value = model.BankName;
                dropProvince.Value = model.BankInProvince;
                txtBankAccount.Value = model.BankAccount;
                txtBankAccountUser.Value = model.BankAccountUser;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Stock/eptransaction.aspx");
        }

        #region 处理输入数量（已注释）
        /// <summary>
        /// 处理输入数量（已注释）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void txtnumber_TextChanged(object sender, EventArgs e)
        //{
        //    int integer;

        //    if (Int32.TryParse(txtnumber.Text, out integer))
        //    {
        //        if (int.Parse(ltNumber.Text.Trim()) >= int.Parse(txtnumber.Text.Trim()))
        //        {
        //            decimal price = decimal.Parse(Amount.Text.Trim());
        //            decimal Number = decimal.Parse(txtnumber.Text.Trim());
        //            PaymentMone.Text = (price * Number).ToString();
        //            ltArrival.Text = txtnumber.Text;
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('" + GetLanguage("PurQuantity") + "');</script>");
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('" + GetLanguage("AmountErrors") + "');</script>");
        //        return;
        //    }
        //}
        #endregion

        /// <summary>
        /// 验证二级密码
        /// </summary>
        /// <returns></returns>
        protected bool validateSecondPass(string strPwd)
        {
            if (PaymentpPassword.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Paymentempty") + "');", true);//旧二级密码不能为空
                return false;
            }
            if (PageValidate.GetMd5(PaymentpPassword.Value) != strPwd)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("oldTwoPassCorrect") + "');", true);//旧二级密码不正确
                return false;
            }         
            return true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            long CashsellID = long.Parse(Request.QueryString["CashsellID"].ToString());
            lgk.Model.Cashsell model = cashsellBLL.GetModel(CashsellID);
            int  sellID =int.Parse( model.UserID.ToString());//获取卖家ID
            
            int SaleNum =model.SaleNum-Convert.ToInt32(txtnumber.Text);//购买后原来商品的剩余量
            //decimal PayMoney = model.Price * Convert.ToInt32(txtnumber.Text);//购买支付的金额
            decimal Amunt = model.Price * SaleNum;

            lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
            userInfo = userBLL.GetModel(getLoginID());

            //如果以选择图片
            //图片
           // string fileName = FileUpload1.FileName;
            string _fileName = "";
            string _name = "";
            
            if (FileUpload1.HasFile)
            {
                _fileName = (Server.MapPath("../../Upload/"));
                _name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.'));
                _fileName += _name;
                //保存图片
              //  FileUpload1.SaveAs(_fileName);

                
                FileUpload1.SaveAs(Server.MapPath("../../Upload/" + _name));
                if(!File.Exists(Server.MapPath("../../Upload/" + _name)))
                {
                    MessageBox.Show(this, GetLanguage("OperationFailed"));//操作失败
                    return;
                }
                

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
            //给卖家打款
           // decimal  dtockMoney = decimal.Parse(PaymentMone.Text);

            //加入交易记录
            lgk.Model.Cashbuy cashbuyinfo = new lgk.Model.Cashbuy();
            cashbuyinfo.Amount = model.Amount;
            cashbuyinfo.CashsellID = CashsellID;
            cashbuyinfo.BuyNum = model.SaleNum;
            cashbuyinfo.Number = 0;
            cashbuyinfo.SellUserID = sellID;//卖家ID
            cashbuyinfo.UserID= getLoginID();
            cashbuyinfo.Price = model.Price;
            cashbuyinfo.BuyDate = DateTime.Now;
            cashbuyinfo.IsBuy = 0;//等待发货
            cashbuyinfo.TypeID = 1;//商品金币类型 1，是注册点；2，是夸克币
            cashbuyinfo.BankAccount = model.BankAccount;// this.txtBankAccount.Value.Trim();
            cashbuyinfo.BankAccountUser = model.BankAccountUser;// this.txtBankAccountUser.Value.Trim();// "開户姓名";
            cashbuyinfo.BankName = model.BankName;// this.dropBank.SelectedValue;// "開户銀行";
            cashbuyinfo.BankBranch = model.BankBranch;// this.txtBankBranch.Value.Trim();// "支行名稱";
            cashbuyinfo.BankInProvince = model.BankInProvince;// dropProvince.SelectedItem.Text;// "銀行所在省份";
            cashbuyinfo.Image = "../../Upload/" + _name;
            long x= cashbuyBLL.Add(cashbuyinfo);
            //写入订单
            lgk.Model.Cashorder orderinfo = new lgk.Model.Cashorder();
            string code = DateTime.Now.ToString("yyyyMMddhhmmssffff");//订单编号
            orderinfo.BUserID = getLoginID();//买家ID
            orderinfo.SUserID = sellID;//卖家ID
            orderinfo.OrderCode = code;//订单编号
            orderinfo.CashbuyID = x;
            orderinfo.OrderDate = DateTime.Now;
            orderinfo.PayDate = DateTime.Now;
            orderinfo.SendDate = DateTime.Now;
            orderinfo.BRemark = "注册点交易";
            orderinfo.SRemark = "注册点交易";
            orderinfo.CashsellID = model.CashsellID;
            orderinfo.SStatus = 1;
            orderinfo.Status = 1;
            orderinfo.BStatus = 1;
            cashorderBLL.Add(orderinfo);//加入订单
            
            lgk.Model.tb_user maadel = LoginUser;
            if (validateSecondPass(maadel.SecondPassword))
            {
                if (cashsellBLL.UpdateUndo1(CashsellID,1))
                {
                    Response.Write("<script>alert('" + GetLanguage("Successful") + "');location.href='goumaiL.aspx';</script>");
                }
            }

        }
    }
   
}