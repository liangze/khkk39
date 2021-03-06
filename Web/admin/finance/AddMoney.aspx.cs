﻿/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-5-23 12:06:36 
 * 文 件 名：		AddMoney.cs 
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
using System.Data;

namespace Web.admin.finance
{
    public partial class AddMoney : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 17, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            bind_repeater(GetRechangeList(GetWhere()), Repeater1, " RechargeDate desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();

            string strWhere = string.Format(" 1=1");
            if (this.txtCode.Text != "")
            {
                strWhere += " and u.UserCode like '%" + this.txtCode.Text.Trim() + "%'";
            }
            if (dropType.SelectedValue == "0")
            {
                strWhere += " ";
            }
            else if (dropType.SelectedValue == "1")
            {
                strWhere += " and r.RechargeStyle=1";
            }
            else if (dropType.SelectedValue == "2")
            {
                strWhere += " and r.RechargeStyle=0";
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),r.RechargeDate,120)  >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),r.RechargeDate,120)  <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),r.RechargeDate,120)  between '" + strStartTime + "' and '" + strEndTime + "' ");
            }
            return strWhere;
        }

        protected bool RegValidate()
        {
            #region 金币类型验证
            if (this.dropMoneyType.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择金币类型');", true);//请选择金币类型
                return false;
            }

            if (this.dropRechargeStyle.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择充值类型');", true);//请选择充值类型
                return false;
            }

            return true;
            #endregion
        }
        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
            lgk.Model.tb_recharge rechargeInfo = new lgk.Model.tb_recharge();

            #region 会员账号验证
            if (txtUserCode.Text == "")
            {
                MessageBox.MyShow(this, "请填写要充值的会员账号!");
                return;
            }
            if (!userBLL.Exists(this.txtUserCode.Text.Trim()))
            {
                MessageBox.MyShow(this, "该会员账号不存在!");
                return;
            }

            userInfo = userBLL.GetModel(GetUserID(this.txtUserCode.Text.Trim()));
            //if (userInfo.IsOpend != 2)
            //{
            //    MessageBox.MyShow(this, "会员未开通!");
            //    return;
            //}
            #endregion
            if (RegValidate())
            {
                #region 充值金额验证
                if (this.txtMoney.Text == "")
                {
                    MessageBox.MyShow(this, "充值金额不能为空!");
                    return;
                }
                else if (Convert.ToDouble(this.txtMoney.Text.Trim()) <= 0)
                {
                    MessageBox.MyShow(this, "金额需大于零!");
                    return;
                }
                decimal money = 0;//金额
                if (!decimal.TryParse(txtMoney.Text.Trim(), out money))
                {
                    MessageBox.MyShow(this, GetLanguage("Pleasedata"));//请输入有效 数据
                    return;
                }

                decimal dMoney = Convert.ToDecimal(txtMoney.Text.Trim());
                #endregion

                #region 充值实体
                int iRechargeStyle = int.Parse(dropMoneyType.SelectedValue);
                rechargeInfo.UserID = userInfo.UserID;
                rechargeInfo.RechargeStyle = Convert.ToInt32(dropRechargeStyle.SelectedValue);//1：增加
                rechargeInfo.RechargeType = iRechargeStyle;//journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                rechargeInfo.RechargeableMoney = dMoney;
                rechargeInfo.RechargeDate = DateTime.Now;
                rechargeInfo.Recharge001 = 1;  //后台充值
                rechargeInfo.Flag = 1;
                #endregion

                #region 加入流水账表
                lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                jmodel.UserID = userInfo.UserID;
                jmodel.JournalDate = DateTime.Now;

                if (rechargeInfo.RechargeStyle == 1)//增加
                {
                    if (rechargeInfo.RechargeType == 3)//佣金点数
                    {
                        rechargeInfo.YuAmount = userInfo.AllBonusAccount + dMoney;
                        jmodel.InAmount = dMoney;
                        jmodel.OutAmount = 0;
                        jmodel.BalanceAmount = userInfo.AllBonusAccount + dMoney;
                        jmodel.Remark = "后台充值佣金点数(增加)";
                        jmodel.JournalType = 3;
                        //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    }
                    else if (rechargeInfo.RechargeType == 1)//注册点数
                    {
                        rechargeInfo.YuAmount = userInfo.BonusAccount + dMoney;
                        jmodel.InAmount = Convert.ToDecimal(this.txtMoney.Text.Trim());
                        jmodel.OutAmount = 0;
                        jmodel.BalanceAmount = userInfo.BonusAccount + dMoney;
                        jmodel.Remark = "后台充值注册点数(增加)";
                        jmodel.JournalType = 1;
                        //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    }
                    else if (rechargeInfo.RechargeType == 5)//激活点数
                    {
                        rechargeInfo.YuAmount = userInfo.GLmoney + dMoney;
                        jmodel.InAmount = dMoney;
                        jmodel.OutAmount = 0;
                        jmodel.BalanceAmount = userInfo.GLmoney + dMoney;
                        jmodel.Remark = "后台充值激活点数(增加)";
                        jmodel.JournalType = 5;
                        //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，6、股权，7、商城点数，8、夸克币，9、持币，10、存币
                    }
                    else if (rechargeInfo.RechargeType == 2)//交易点数
                    {
                        rechargeInfo.YuAmount = userInfo.Emoney + dMoney;
                        jmodel.InAmount = dMoney;
                        jmodel.OutAmount = 0;
                        jmodel.BalanceAmount = userInfo.Emoney + dMoney;
                        jmodel.Remark = "后台充值交易点数(增加)";
                        jmodel.JournalType = 2;
                    }
                    else if (rechargeInfo.RechargeType == 8)//交易点数
                    {
                        rechargeInfo.YuAmount = userInfo.User011 + dMoney;
                        jmodel.InAmount = dMoney;
                        jmodel.OutAmount = 0;
                        jmodel.BalanceAmount = userInfo.User011 + dMoney;
                        jmodel.Remark = "后台充值夸克币(增加)";
                        jmodel.JournalType = 8;
                    }

                }
                if (rechargeInfo.RechargeStyle == 2)//扣除
                {
                    if (rechargeInfo.RechargeType == 3)
                    {
                        if (dMoney > userInfo.AllBonusAccount)
                        {
                            MessageBox.MyShow(this, "佣金点数余额不足!");
                            return;
                        }
                        rechargeInfo.YuAmount = userInfo.AllBonusAccount - dMoney;
                        jmodel.InAmount = 0;
                        jmodel.OutAmount = dMoney;
                        jmodel.BalanceAmount = userInfo.AllBonusAccount - dMoney;
                        jmodel.Remark = "后台充值佣金点数(减少)";
                        jmodel.JournalType = 3;
                        // //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，
                    }
                    else if (rechargeInfo.RechargeType == 1)
                    {
                        if (dMoney > userInfo.BonusAccount)
                        {
                            MessageBox.MyShow(this, "注册点数余额不足!");
                            return;
                        }
                        rechargeInfo.YuAmount = userInfo.BonusAccount - dMoney;
                        jmodel.InAmount = 0;
                        jmodel.OutAmount = dMoney;
                        jmodel.BalanceAmount = userInfo.BonusAccount - dMoney;
                        jmodel.Remark = "后台充值注册点数(减少)";
                        jmodel.JournalType = 1;
                        //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，
                    }
                    else if (rechargeInfo.RechargeType == 5)//激活点数
                    {
                        if (dMoney > userInfo.GLmoney)
                        {
                            MessageBox.MyShow(this, "激活点数余额不足!");
                            return;
                        }
                        rechargeInfo.YuAmount = userInfo.GLmoney - dMoney;
                        jmodel.InAmount = 0;
                        jmodel.OutAmount = dMoney;
                        jmodel.BalanceAmount = userInfo.GLmoney - dMoney;
                        jmodel.Remark = "后台充值激活点数(减少)";
                        jmodel.JournalType = 5;
                        // //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，
                    }
                    else if (rechargeInfo.RechargeType == 2)//交易点数
                    {
                        if (dMoney > userInfo.Emoney)
                        {
                            MessageBox.MyShow(this, "交易点数余额不足!");
                            return;
                        }
                        rechargeInfo.YuAmount = userInfo.Emoney - dMoney;
                        jmodel.InAmount = 0;
                        jmodel.OutAmount = dMoney;
                        jmodel.BalanceAmount = userInfo.Emoney - dMoney;
                        jmodel.Remark = "后台充值交易点数(减少)";
                        jmodel.JournalType = 2;
                    }
                    else if (rechargeInfo.RechargeType == 8)//交易点数
                    {
                        if (dMoney > userInfo.User011)
                        {
                            MessageBox.MyShow(this, "激活夸克币余额不足!");
                            return;
                        }
                        rechargeInfo.YuAmount = userInfo.User011 - dMoney;
                        jmodel.InAmount = 0;
                        jmodel.OutAmount = dMoney;
                        jmodel.BalanceAmount = userInfo.User011 - dMoney;
                        jmodel.Remark = "后台充值夸克币(减少)";
                        jmodel.JournalType = 8;
                    }

                }
                #endregion

                if (rechargeBLL.Add(rechargeInfo) > 0 && journalBLL.Add(jmodel) > 0)
                {
                    if (rechargeInfo.RechargeStyle == 1)
                    {
                        //journalType : 1、注册点数，2、交易点数，3、佣金点数，4、现金币，5、激活点数，
                        if (rechargeInfo.RechargeType == 3)
                        {
                            UpdateAccount("AllBonusAccount", rechargeInfo.UserID, rechargeInfo.RechargeableMoney, 1);//各人账户增加
                            UpdateSystemAccount("MoneyAccount", rechargeInfo.RechargeableMoney, 0);//公司账户减少
                        }
                        else if (rechargeInfo.RechargeType == 1)
                        {
                            UpdateAccount("BonusAccount", rechargeInfo.UserID, rechargeInfo.RechargeableMoney, 1);//各人账户增加
                            UpdateSystemAccount("MoneyAccount", rechargeInfo.RechargeableMoney, 0);//公司账户减少
                        }
                        else if (rechargeInfo.RechargeType == 5)
                        {
                            UpdateAccount("GLmoney", rechargeInfo.UserID, rechargeInfo.RechargeableMoney, 1);//各人账户增加
                            UpdateSystemAccount("MoneyAccount", rechargeInfo.RechargeableMoney, 0);//公司账户减少
                        }
                        else if (rechargeInfo.RechargeType == 8)
                        {
                            UpdateAccount("User011", rechargeInfo.UserID, rechargeInfo.RechargeableMoney, 1);//各人账户增加
                            UpdateSystemAccount("MoneyAccount", rechargeInfo.RechargeableMoney, 0);//公司账户减少
                        }
                        else if (rechargeInfo.RechargeType == 2)
                        {
                            UpdateAccount("Emoney", rechargeInfo.UserID, rechargeInfo.RechargeableMoney, 1);//各人账户增加
                            UpdateSystemAccount("MoneyAccount", rechargeInfo.RechargeableMoney, 0);//公司账户减少
                        }

                    }
                    else if (rechargeInfo.RechargeStyle == 2)
                    {
                        if (rechargeInfo.RechargeType == 3)
                        {
                            UpdateAccount("AllBonusAccount", rechargeInfo.UserID, rechargeInfo.RechargeableMoney, 0);//各人账户减少
                            UpdateSystemAccount("MoneyAccount", rechargeInfo.RechargeableMoney, 1);//公司账户增加
                        }
                        else if (rechargeInfo.RechargeType == 1)
                        {
                            UpdateAccount("BonusAccount", rechargeInfo.UserID, rechargeInfo.RechargeableMoney, 0);//各人账户减少
                            UpdateSystemAccount("MoneyAccount", rechargeInfo.RechargeableMoney, 1);//公司账户增加
                        }
                        else if (rechargeInfo.RechargeType == 5)
                        {
                            UpdateAccount("GLmoney", rechargeInfo.UserID, rechargeInfo.RechargeableMoney, 0);//各人账户减少
                            UpdateSystemAccount("MoneyAccount", rechargeInfo.RechargeableMoney, 1);//公司账户增加
                        }
                        else if (rechargeInfo.RechargeType == 8)
                        {
                            UpdateAccount("User011", rechargeInfo.UserID, rechargeInfo.RechargeableMoney, 0);//各人账户减少
                            UpdateSystemAccount("MoneyAccount", rechargeInfo.RechargeableMoney, 1);//公司账户增加
                        }
                        else if (rechargeInfo.RechargeType == 2)
                        {
                            UpdateAccount("Emoney", rechargeInfo.UserID, rechargeInfo.RechargeableMoney, 0);//各人账户减少
                            UpdateSystemAccount("MoneyAccount", rechargeInfo.RechargeableMoney, 1);//公司账户增加
                        }
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='AddMoney.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('充值失败!');", true);
                }
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
