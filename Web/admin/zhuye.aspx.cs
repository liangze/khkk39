/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-5-17 15:59:27 
 * 文 件 名：		zhuye.cs 
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

namespace Web.admin
{
    public partial class zhuye : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //
            }
        }

        protected void lbtnSettle_Click(object sender, EventArgs e)
        {
            int iResult = bonusBLL.ExecProcedure("proc_bonusPayOne");
            
            if (iResult == 1)
            {
                MessageBox.Show(this, "奖金结算成功！");
            }
            else if (iResult == 0)
            {
                MessageBox.Show(this, "所有奖金已结算！");
            }
            else if (iResult == -1)
            {
                MessageBox.Show(this, "奖金结算失败！");
            }
        }

        protected void lbtnShareOut_Click(object sender, EventArgs e)
        {
            int iResult = bonusBLL.ExecProcedure("proc_Award_ShareOutBonus");

            if (iResult == 1)
            {
                MessageBox.Show(this, "发放持币奖成功！");
            }
            else if (iResult == -1)
            {
                MessageBox.Show(this, "发放持币奖失败！");
            }
        }

        protected void lbtnBuy_Click(object sender, EventArgs e)
        {   
                int iResult = bonusBLL.ExecProcedure("proc_Award_cunbi");

                if (iResult == 1)
                {
                    MessageBox.Show(this, "发放存币奖成功！");
                }
                else
                {
                    MessageBox.Show(this, "发放存币奖失败！");
                }                     
        }
    }
}
