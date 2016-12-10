using DataAccess;
using Library;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Register : AllCore// PageCore////System.Web.UI.Page
    {
       
        public int asd = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindQuesdtion();
                btnCreateUser.Text = GetLanguage("Build");//生成编号 
                btnValidate.Text = GetLanguage("detection");//检测编号
                btnSubmit.Text = GetLanguage("Submit");//提交
                BindBank();
                
                BindProvince();
                Level_DataBind();//页面加载时把会员等级进行绑定
                
            }
        }

        /// <summary>
        /// 注册接点人赋值
        /// </summary>
        public void BindQuesdtion()
        {

            string state = getStringRequest("state");
            string[] a;
            if (state != "" && state != null)
            {

                a = state.Split(',');
                if (int.Parse(a[1].Trim()) == 1)
                {
                    radMarketOne.Checked = true;
                    radMarketOne.Disabled = true;
                    radMarketTwo.Disabled = true;

                }
                else
                {
                    radMarketTwo.Checked = true;
                    radMarketTwo.Disabled = true;
                    radMarketOne.Disabled = true;

                }//注册区域
                txtParentCode.Value = GetUserCode(int.Parse(a[0].Trim()));//接点会员
                txtParentCode.Disabled = true;
                asd = int.Parse(a[2].Trim());

                //var data = userBLL.GetModel(getLoginID());

            }
            else
            {

            }

        }

        #region 绑定省
        /// <summary>
        /// 绑定省
        /// </summary>
        private void BindProvince()
        {
            bind_DropDownList(dropProvince, provinceBLL.GetList("").Tables[0], "provinceID", "province"); //銀行省份
        }
        #endregion

        /// <summary>
        /// 绑定密保问题
        /// </summary>
        //public void BindQuestion()
        //{
        //    IList<lgk.Model.tb_Security> myList = new lgk.BLL.tb_Security().GetModelList("");
        //    dropQuestion.Items.Clear();
        //    ListItem li = new ListItem();
        //    li.Value = "0";
        //    li.Text = "-请选择-";
        //    dropQuestion.Items.Add(li);
        //    foreach (lgk.Model.tb_Security item in myList)
        //    {
        //        ListItem items = new ListItem();
        //        items.Value = item.SecurityID.ToString();
        //        items.Text = item.Question;
        //        dropQuestion.Items.Add(items);
        //    }
        //}

        #region 绑定会员等级
        ///<summary>
        ///绑定会员等级
        ///</summary>
        public void Level_DataBind()
        {
            IList<lgk.Model.tb_level> myList = new lgk.BLL.tb_level().GetModelList("");
            LevelSelect.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            LevelSelect.Items.Add(li);
            foreach (lgk.Model.tb_level item in myList)
            {
                ListItem items = new ListItem();
                items.Value = item.LevelID.ToString();
                items.Text = item.LevelName;
                LevelSelect.Items.Add(items);
            }

        }
        #endregion

        #region 检查用户
        /// <summary>
        /// 检查用户
        /// </summary>
        /// <returns></returns>
        public string CheckUserID()
        {
            Random r = new Random();
            int strnum = 6;
            string strSQL = "";
            string UserID = "";
            UserID = "HF";
            for (int i = 0; i < strnum; i++)
            {
                UserID += r.Next(0, 9).ToString();
            }
            strSQL = "select count(*) From tb_user where UserCode like @UserCode + '%' ";
            SqlParameter[] parameters = {
                new SqlParameter("@UserCode", UserID)
            };
            if (int.Parse(DbHelperSQL.GetSingle(strSQL, parameters).ToString()) > 0)
            {
                return CheckUserID();
            }
            else
            {
                return UserID;
            }
        }
        #endregion

        #region 绑定银行
        /// <summary>
        /// 绑定银行
        /// </summary>
        private void BindBank()
        {
            //if (currentCulture == "en-us")
            //{
            //    txtLevel.Value = levelBLL.GetLevelName(LoginUser.LevelID, "en-us");
            //}
            //else
            //{
            //    txtLevel.Value = levelBLL.GetLevelName(LoginUser.LevelID, "");
            //}

            //decimal dRegMoney = getParamInt("Level1") * getParamAmount("billMoney");
            //txtRegMoney.Value = dRegMoney.ToString("0.00");

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
        }
        #endregion

        /// <summary>
        /// 判断是否在推荐会员下线
        /// </summary>
        /// <param name="pID">接点会员ID</param>
        /// <param name="reID">推荐会员ID</param>
        /// <returns></returns>
        private int FlagReg(int pID, int reID)
        {
            string strSql = @"select count(0) from tb_user where UserID =" + pID + " and UserPath like '%" + reID + "%'";
            if (Convert.ToInt32(DbHelperSQL.GetSingle(strSql)) > 0)
            {
                return 2;
            }
            return 1;
        }

        private int FlagLocation(int pID, int location, int isopen)
        {
            string strSql = "";
            strSql = @"select UserID from tb_user where ParentID =" + pID + " and Location=" + location;
            if (isopen != 0)
            {
                strSql = @"select UserID from tb_user where isopend<>0 and ParentID =" + pID + " and Location=" + location;
            }

            object obj = DbHelperSQL.GetSingle(strSql);
            if (obj != null)
            {
                return Convert.ToInt32(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 查询会员推荐数量/下线数量
        /// </summary>
        /// <param name="UserID">会员ID</param>
        /// <param name="Type">类型：r-直推，p-下线</param>
        /// <returns></returns>
        private int getnum(int UserID, string Type)
        {
            string strSql = "";
            if (Type == "r") { strSql = @"select count(0) from tb_user where RecommendID =" + UserID; }
            if (Type == "p") { strSql = @"select count(0) from tb_user where ParentID =" + UserID; }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql));
        }

        #region 确定推荐人，安置会员是否在同一条推荐线上
        /// <summary>
        /// 确定推荐人，安置会员是否在同一条推荐线上
        /// </summary>
        /// <param name="recommendPath"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        private bool OnSameLine(string recommendPath, string location)
        {
            string[] array = recommendPath.Split('-');
            int count = array.Length;
            for (int i = 0; i < count; i++)
            {
                if (array[i] == location)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RegValidate())
            {
                lgk.Model.tb_user m_user = new lgk.Model.tb_user();
                lgk.Model.tb_user ModelRecommend = userBLL.GetModel(GetUserID(this.txtRecommendCode.Value.Trim()));//推荐用户
                lgk.Model.tb_user ModelParent = userBLL.GetModel(GetUserID(this.txtParentCode.Value.Trim()));//父节点用户
                

                long agentUserID = 1;
                if (ModelRecommend.IsAgent == 1)
                {
                    agentUserID = ModelRecommend.UserID;
                }
                else
                {
                    agentUserID = getFirstAgent(ModelRecommend.UserID);
                }
                lgk.Model.tb_user ModelAgent = userBLL.GetModel(agentUserID);

                m_user.UserCode = txtUserCode.Value.Trim();//会员编号
                                                           //m_user.LevelID = 2;
                m_user.LevelID = int.Parse(LevelSelect.SelectedValue.ToString());//注册的会员等级 item.LevelID.ToString()
                m_user.RecommendID = ModelRecommend.UserID;//推荐人ID
                m_user.RecommendCode = ModelRecommend.UserCode;//推荐人编号
                m_user.RecommendPath = ModelRecommend.RecommendPath; //路径
                m_user.RecommendGenera = Convert.ToInt32(ModelRecommend.RecommendGenera + 1);//（推荐代数）第几代

                m_user.ParentID = ModelParent.UserID;//父节点ID
                m_user.ParentCode = ModelParent.UserCode;//父节点編號
                m_user.UserPath = ModelParent.UserPath; //路径
                m_user.Layer = ModelParent.Layer + 1;//属于多少层

                m_user.LeftBalance = 0;
                m_user.LeftNewScore = 0;
                m_user.RightBalance = 0;
                m_user.RightNewScore = 0;
                m_user.LeftScore = 0;
                m_user.RightScore = 0;

                m_user.Location = radMarketOne.Checked == true ? 1 : 2;//radMarketOne.Checked == true ? 1 : 2;
                m_user.User007 = m_user.Location == 1 ? "左区" : "右区";//m_user.Location == 1 ? "左区" : "右区";
                m_user.IsOpend = 0;//是否启用 0-未激活,1-新注册, 2-已激活
                m_user.IsLock = 0;//是否被冻結(0-否,1-冻結)

                m_user.IsAgent = 0;//是否报單中心(0-否，1-是)
                m_user.User006 = ModelAgent.UserCode;//txtAgentCode.Value.Trim();
                m_user.AgentsID = agentBLL.GetAgentsID(ModelAgent.UserCode);//

                m_user.Emoney = 0;//现金币账户
                m_user.BonusAccount = 0;//佣金币账户
                m_user.AllBonusAccount = 0;//累计獎金賬戶
                m_user.StockAccount = 0;//代金券
                m_user.StockMoney = 0;//红包积分
                m_user.GLmoney = 0;//购物币
                m_user.ShopAccount = 0;//存折账户

                decimal dRegMoney = getParamAmount("Level" + LevelSelect.SelectedValue);
                m_user.RegMoney = dRegMoney;
                m_user.RegTime = DateTime.Now;//注册時間
                m_user.BillCount = 1;// getParamInt("reg" + ddlLevel.SelectedValue);//注册单数
                m_user.Password = PageValidate.GetMd5(this.txtPassword.Value.Trim());//一级密码
                m_user.SecondPassword = PageValidate.GetMd5(this.txtSecondPassword.Value.Trim());//二级密码


                m_user.BankAccount = this.txtBankAccount.Value.Trim();// "銀行賬號";
                m_user.BankAccountUser = this.txtBankAccountUser.Value.Trim();// "開户姓名";
                m_user.BankName = this.dropBank.SelectedValue;// "開户銀行";
                m_user.BankBranch = this.txtBankBranch.Value.Trim();// "支行名稱";
                m_user.BankInProvince = dropProvince.SelectedItem.Text;// "銀行所在省份";
                m_user.BankInCity = "";//DropDownList1.SelectedItem.Text;// "銀行所在城市";

                m_user.NiceName = string.Empty;//txtNickName.Value.Trim();//昵称
                m_user.TrueName = this.txtTrueName.Value.Trim();// "姓名";
                m_user.IdenCode = this.txtIdenCode.Value.Trim();// "身份证號";
                string phoneNum = this.txtPhoneNum.Value.Trim();
                m_user.PhoneNum = string.IsNullOrEmpty(phoneNum) ? "" : phoneNum;// "手机號碼";
                                                                                 // m_user.Address = txtAddress.Value;//聯系地址
                                                                                 // m_user.QQnumer = txtQQnumer.Value.Trim();//QQ
                m_user.Email = txtEmail.Value.Trim();//电子邮箱
                m_user.User001 = 0;//
                
                m_user.User003 = 0;//
                m_user.User004 = 0;//
                
                m_user.User009 = "0";// question;//密保问题
                m_user.User010 = "0";// string.IsNullOrEmpty(question) ? string.Empty : txtAnswer.Text.Trim();//密保答案
                m_user.User011 = 0;
                m_user.User015 = 0;//
                m_user.User016 = 0;
                m_user.User017 = 0;
                m_user.User018 = 0;//--用户竞拍该扣未扣的奖金币

                int aid = GetUserID(txtUserCode.Value.Trim());
                if (aid > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("RegistrationFails") + "');", true);//注册失败，该会员编号已存在，请重新注册!
                }
                else
                {
                    string state = getStringRequest("state");
                    string[] a;
                    if (state != "" && state != null)
                    {
                        a = state.Split(',');
                        asd = int.Parse(a[2].Trim());
                    }
                    if (userBLL.Add(m_user) > 0)
                    {
                        lgk.Model.tb_user model = userBLL.GetModel(GetUserID(m_user.UserCode));
                        model.UserPath = model.UserPath + "-" + model.UserID.ToString();
                        model.RecommendPath = model.RecommendPath + "-" + model.UserID.ToString();

                        if (userBLL.Update(model))
                        {
                            Response.Redirect("RegSuccess2.aspx?usercode=" + m_user.UserCode + "&asd=" + asd);
                        }
                        else
                        {
                            userBLL.Delete(model.UserID);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('异常错误，注册失败！');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('异常错误，注册失败！');", true);
                    }
                }
            }
        }
        #endregion

        #region 注册验证
        /// <summary>
        /// 注册验证
        /// </summary>
        /// <returns></returns>
        protected bool RegValidate()
        {
            lgk.Model.tb_user ModelRecommend = new lgk.Model.tb_user();
            lgk.Model.tb_user ModelParent = new lgk.Model.tb_user();
            lgk.Model.tb_agent ModelAgent = new lgk.Model.tb_agent();

            #region 用户编号验证
            if (txtUserCode.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseNumber") + "');", true);//请输入会员编号
                return false;
            }
            if (!PageValidate.checkUserCode(txtUserCode.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("MemberNumber") + "');", true);//会员编号必须由6-10位的英文字母或数字组成
                return false;
            }

            if (GetUserID(txtUserCode.Value.Trim()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Memberexists") + "');", true);//该会员编号已存在,请重新输入!
                return false;
            }
            #endregion

            #region 密码验证
            if (txtPassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PasswordISNull") + "');", true);//登录密码不能为空
                return false;
            }

            if (txtRegPassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("ConfirmPasswordISNull") + "');", true);//确认密码不能为空
                return false;
            }
            if (!txtPassword.Value.Trim().Equals(txtRegPassword.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("TwoPasswordMatch") + "');", true);//两次输入的登录密码不一致
                return false;
            }
            if (txtSecondPassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("SecondaryISNUll") + "');", true);//二级密码不能为空
                return false;
            }

            if (txtRegSecondPassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("secondaryPasswordISNull") + "');", true);//确认二级密码不能为空
                return false;
            }
            if (!txtSecondPassword.Value.Trim().Equals(txtRegSecondPassword.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("TwoSecondaryMatch") + "');", true);//两次输入的二级密码不一致
                return false;
            }

            #endregion
            #endregion
            #region 会员等级验证
            if (this.LevelSelect.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Pleregistlevel") + "');", true);//会员等级验证
                return false;
            }
            #endregion

            #region 推荐人验证
            if (txtRecommendCode.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("ReferenceNumberIsnull") + "');", true);//推荐人编号不能为空
                return false;
            }
            else
            {
                string reName = this.txtRecommendCode.Value.Trim();
                ModelRecommend = userBLL.GetModel(GetUserID(reName));//推薦用户
                if (ModelRecommend == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("featuredNotExist") + "');", true);//该推荐会员不存在
                    return false;
                }
                if (ModelRecommend.IsOpend == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("MemberISNull") + "');", true);//该会员尚未开通，不能作为推荐会员
                    return false;
                }
            }
            #endregion

            #region 安置接点和区域验证
            string parName = this.txtParentCode.Value.Trim();
            if (txtParentCode.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PlacementIsnull") + "');", true);//安置会员编号不能为空
                return false;
            }
            else
            {

                ModelParent = userBLL.GetModel(GetUserID(parName));//父节点用户
                if (ModelParent == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PlacementIsexist") + "');", true);//该安置会员不存在
                    return false;
                }
                //else
                //{
                //    if (ModelParent.IsOpend == 0)
                //    {
                //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PlacementIsopen") + "');", true);//该安置会员未开通
                //        return false;
                //    }
                //}
            }
            if (radMarketOne.Checked != true && radMarketTwo.Checked != true)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseArea") + "');", true);//请选择注册区域
                return false;
            }

            int reNum = Convert.ToInt32(DbHelperSQL.GetSingle("select count(*) from tb_user where ParentID=" + GetUserID(parName)));
            if (reNum == 0)
            {
                if (radMarketTwo.Checked == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("RecommendFirst") + "');", true);//推荐会员推荐的第一人必须放在最左区
                    return false;
                }
            }

            int location = 0;
            if (radMarketOne.Checked == true) { location = 1; }
            if (radMarketTwo.Checked == true) { location = 2; }
            if (FlagLocation(GetUserID(this.txtParentCode.Value.Trim()), location, 0) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("hasMember") + "');", true);//该区域已有会员
                return false;
            }
            if ((location == 2 && FlagLocation(GetUserID(this.txtParentCode.Value.Trim()), 1, 0) == 1))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("leftIsnull") + "');", true);//该接点会员左区未有人，不能注册右区!
                return false;
            }

            if (ModelParent.IsOpend == 0 && location == 2)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该接点会员尚未开通，不能注册右区!');", true);
                return false;
            }
            #endregion

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
           

            #region 基本信息验证
            string trueName = this.txtTrueName.Value.Trim();
            if (trueName == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AccountIsNull") + "');", true);//姓名不能为空
                return false;
            }
            

            string IdenCode = this.txtIdenCode.Value.Trim();
            if (IdenCode == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("CardIDIsNull") + "');", true);//身份证号不能为空
                return false;
            }
            if (!PageValidate.RegexIden(IdenCode))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("CardIDMust") + "');", true);//身份证号格式错误
                return false;
            }
            int iIdenCode = userBLL.GetCount("IdenCode='" + IdenCode + "'");
            if (iIdenCode >= getParamInt("Level2"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("IdenCodeReg") + "');", true);//身份证号已被注册
                return false;
            }

            var phoneNum = this.txtPhoneNum.Value.Trim();
            if (string.IsNullOrEmpty(phoneNum))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PhoneMust") + "');", true);//联系电话不能为空
                return false;
            }
            if (!PageValidate.RegexPhone(phoneNum))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PhoneMust") + "');", true);//联系电话格式错误
                return false;
            }
            int iPhoneNum = userBLL.GetCount("PhoneNum='" + phoneNum + "'");
            if (iPhoneNum >= getParamInt("Level3"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PhoneReg") + "');", true);//联系电话已被注册
                return false;
            }
            var Email = this.txtEmail.Value.Trim();
            if (string.IsNullOrEmpty(Email))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Emailqq") + "');", true);//邮箱不能为空
                return false;
            }
           
            #endregion

            return true;
        }
        #endregion

        #region 自动生成用户编号
        /// <summary>
        /// 自动生成用户编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            UserCode code = new UserCode();
            string strUserCode = string.Empty;
            bool bFlag = true;
            while (bFlag)
            {
                strUserCode = code.GetCode();
                if (!userBLL.Exists(strUserCode))
                {
                    bFlag = false;
                }
            }
            txtUserCode.Value = strUserCode;
        }
        #endregion

        #region 检查用户编号是否可用
        /// <summary>
        /// 检查用户编号是否可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnValidate_Click(object sender, EventArgs e)
        {
            string strUserCode = txtUserCode.Value.Trim();
            if (strUserCode == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseNmae") + "');", true);//请输入用户名
                return;
            }
           
            if (userBLL.Exists(strUserCode))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("existsrNmae") + "');", true);//该用户名已存在
                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("availableNmae") + "');", true);//该用户名可用
                return;
            }
        }
        #endregion


    }
}


