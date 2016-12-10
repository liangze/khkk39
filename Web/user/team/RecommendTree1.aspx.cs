using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using DataAccess;

namespace Web.user.team
{
    public partial class RecommendTree1 : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
                

                this.TreeView1.Nodes.Add(getTree(getLoginID()));

               
            }
        }

        public TreeNode getTree(long uid)
        {
            lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
            if (userBLL.GetModel(uid) == null)
            {
                return null;
            }
            userInfo = userBLL.GetModel(uid);
            TreeNode node = new TreeNode();
            string strLevelName = levelBLL.GetLevelName(userInfo.LevelID, GetLanguage("LoginLable"));
            //是否开通
            string dd = "";
            if (userInfo.IsOpend == 0)
            {
                if (GetLanguage("LoginLable") == "zh-cn")
                {
                    dd = "[<span style='color:red;'>未开通</span>]";
                }
                else
                {
                    dd = "[<span style='color:red;'>Not Yet Opened</span>]";
                }
            }
            else if (userInfo.IsOpend == 2)
            {
                if (GetLanguage("LoginLable") == "zh-cn")
                {
                    dd = "[已开通]";
                }
                else
                {
                    dd = "[Opened]";
                }
            }

            if (uid == 2)
            {
                node.Text = userInfo.UserCode;
                node.ImageUrl = "../../images/ico_admin.gif";
                node.NavigateUrl = "RecommendTree.aspx?UserID=" + userInfo.UserID;
            }
            else
            {
                if (GetLanguage("LoginLable") == "zh-cn")
                {
                    node.Text = userInfo.UserCode + "[" + userInfo.TrueName + "][" + strLevelName + "]" + dd;
                }
                else
                {
                    node.Text = userInfo.UserCode + "[" + userInfo.TrueName + "][" + strLevelName + "]" + dd;
                }
                node.NavigateUrl = "RecommendTree.aspx?UserID=" + userInfo.UserID;
            }
            int dai = LoginUser.RecommendGenera + 3;
            IList<lgk.Model.tb_user> list = userBLL.GetModelList(" RecommendGenera<" + dai.ToString() + " AND RecommendID = " + userBLL.GetModel(uid).UserID);
            if (list == null)
            {
                return null;
            }
            foreach (lgk.Model.tb_user item in list)
            {
                node.ChildNodes.Add(getTree(Convert.ToInt32(item.UserID)));
            }
            return node;
        }


        private bool checkName(int p)
        {
            bool result = false;
            string strPath = DbHelperSQL.GetSingle("select RecommendPath from tb_user where UserID =" + getLoginID()).ToString();
            string strSql = string.Format("select count(0) from tb_user where RecommendPath like '%{0}%' and UserID={1}", getLoginID(), p);
            if (int.Parse(DbHelperSQL.GetSingle(strSql).ToString()) > 0)
            {
                result = true;
            }
            return result;
        }

        protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            Response.Write("<script>parent.document.all('mainFrame').style.height=document.body.scrollHeight+1;</script>");
        }

    }
}