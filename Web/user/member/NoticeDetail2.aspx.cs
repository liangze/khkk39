using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.member
{
    public partial class NoticeDetail2 : PageCore //System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
                {
                    BindData(Request.QueryString["id"]);
                }

               
            }
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        protected void BindData(string id)
        {
            lgk.Model.tb_news newInfo = newsBLL.GetModel(Convert.ToInt64(id));
            if (newInfo != null)
            {
                ltTitle.Text = newInfo.NewsTitle;
                txtPublishTime.Value = newInfo.PublishTime.ToString("yyyy-MM-dd");
                txtPublisher.Value = newInfo.Publisher;
                ltContent.Text = newInfo.NewsContent;
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      
    }
}