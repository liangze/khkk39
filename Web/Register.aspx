<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.Register" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <%=GetLanguage("registration")%>
    </title>
    <script type="text/javascript" src="JS/jquery-1.7.1.min.js"></script>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1" name="viewport" />
    <link href="../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/footable.core.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.ui.all.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/ui.fancytree.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.orgchart.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.steps.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.bxslider.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../static/js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="../static/js/footable.js"></script>
    <script type="text/javascript" src="../static/js/footable.paginate.js"></script>
    <script type="text/javascript" src="../static/js/footable.sort.js"></script>
    <script type="text/javascript" src="../static/js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../static/js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../static/js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript" src="../static/js/jquery.fancytree.js"></script>
    <script type="text/javascript" src="../static/js/jquery.orgchart.js"></script>
    <script type="text/javascript" src="../static/js/jquery.steps.min.js"></script>
    <script type="text/javascript" src="../static/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../static/js/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="../static/js/jquery.bxslider.min.js"></script>
    <script type="text/javascript" src="../static/js/jquery.idTabs.min.js"></script>
    <script type="text/javascript" src="../static/js/functions.js"></script>
    <script type="text/javascript">
        var _root = '';
    </script>

    <style type="text/css">
        .fancybox-margin {
            margin-right: 17px;
        }
    </style>
    <style type="text/css">
        .fancybox-margin {
            margin-right: 17px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#txtUserCode").val(" ");
            $("#txtUserCode").click(function () {
                $(this).val("");
            })
            $("#ddlQuestion").change(function () {
                $("#txtAnswer").val("");
            });
        })

        function hidd() {
            var value;
            var level = document.getElementById("dropLevel");
            //获取选中的城市名称
            for (i = 0; i < level.length; i++) {
                if (level[i].selected == true) {
                    value = level[i].value; //关键点
                }
            }
            if (value > 4) {
                $("#agentArea").show();
            } else {
                $("#agentArea").hide();
            }
            if (value > 1) {
                $("#Shop").show();
                $("#djq").hide();
            } else {
                $("#Shop").hide();
                $("#djq").show();
            }

        }
    </script>
    <style type="text/css">
        .style1 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server" class="stdform">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main_container">
            <div class="center_content">

                <h2>&nbsp&nbsp 会员注册
                </h2>
                <p>&nbsp&nbsp <font color="red">*为必填项</font></p>
                <h6>&nbsp&nbsp<%=GetLanguage("LoginInformation")%>：</h6>
                <div class="row-fluid">
                    <div class="span6">
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("UserName")%><!--用户名称-->：
                            </label>
                            <div class="field">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <input name="txtUserCode" type="text" id="txtUserCode" runat="server" class="boxx" />&nbsp;<asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" class="btn" Width="80px" />&nbsp;&nbsp;
                                    <asp:Button ID="btnValidate" runat="server" OnClick="btnValidate_Click" class="btn" Width="80px" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("LoginPassword")%>：<!--登陆密码-->
                            </label>
                            <div class="field">
                                <input name="txtPassword" type="password" id="txtPassword" runat="server" class="input_reg"
                                    value="1" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("ConfirmPass")%>：<!--确认密码-->
                            </label>
                            <div class="field">
                                <input name="txtRegPassword" type="password" id="txtRegPassword" runat="server" class="input_reg"
                                    value="1" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("PaymentpPassword")%><!--支付密码-->：
                            </label>
                            <div class="field">
                                <input name="txtSecondPassword" type="password" id="txtSecondPassword" runat="server" class="input_reg"
                                    value="1" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("ConfirmPass")%>：
                            </label>
                            <div class="field">
                                <input name="txtRegSecondPassword" type="password" id="txtRegSecondPassword" runat="server" class="input_reg"
                                    value="1" />
                            </div>
                        </div>

                    </div>
                </div>
                <h6>&nbsp&nbsp<%=GetLanguage("NetworkInformation")%>：</h6>
                <!--会员资料-->
                <div class="row-fluid">
                    <div class="span6">
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("MembershipLevels")%>：
                            </label>
                            <%--<div class="field">
                            <input name="txtLevel" type="text" id="txtLevel" runat="server" class="input_reg" disabled="disabled" />
                        </div>--%>
                            <div class="field">
                                <%--<select name="">
       				           <option value="">请选择</option>
       				            <option value="">普通会员</option>
       				           <option value="">普通会员</option>
       				           <option value="">普通会员</option>
       			            </select>--%>
                                <asp:DropDownList ID="LevelSelect" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("ReferenceNumber")%>：
                            </label>
                            <div class="field">
                                <input name="txtRecommendCode" type="text" id="txtRecommendCode" runat="server" class="input_reg" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label for="memid">
                                接点人<font color="red"></font> :
                            </label>
                            <div class="field">
                                <input type="text" name="txtParentCode" id="txtParentCode" value="" runat="server" />
                            </div>
                        </div>
                       
                        <div class="control-group">
                            <label for="memid">
                                安置区域 <font color="red"></font>:
                            </label>
                            <div class="field">

                                <input id="radMarketOne" type="radio" name="qy" value="" runat="server" />左区 		
       			<input id="radMarketTwo" type="radio" name="qy" value="" runat="server" />右区		
                            </div>
                        </div>
                    </div>
                </div>
                <h6>&nbsp&nbsp<%=GetLanguage("Banking")%>：</h6>
                <div class="row-fluid">
                    <div class="span6">
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("Depositary") %>：
                            </label>
                            <div class="field">
                                <asp:DropDownList ID="dropBank" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="dropProvince" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("BankBranch")%>：
                            </label>
                            <div class="field">
                                <input name="txtBankBranch" type="text" id="txtBankBranch" runat="server" class="input_reg" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("BankAccount")%>：
                            </label>
                            <div class="field">
                                <input name="txtBankAccount" type="text" id="txtBankAccount" runat="server" class="input_reg" value="" maxlength="19" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("AccountName")%>：
                            </label>
                            <div class="field">
                                <input name="txtBankAccountUser" type="text" id="txtBankAccountUser" runat="server" class="input_reg" />
                            </div>
                        </div>
                    </div>
                </div>
                <h6>&nbsp&nbsp<%=GetLanguage("Basic")%>：</h6>
                <div class="row-fluid">
                    <div class="span6">
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("Name")%>：
                            </label>
                            <div class="field">
                                <input name="txtTrueName" type="text" id="txtTrueName" runat="server" class="input_reg" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("IDNumber")%>：
                            </label>
                            <div class="field">
                                <input name="txtIdenCode" type="text" id="txtIdenCode" runat="server" class="input_reg" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span><%=GetLanguage("ContactPhone")%>：
                            </label>
                            <div class="field">
                                <input name="txtPhoneNum" type="text" id="txtPhoneNum" runat="server" class="input_reg" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label for="memid">
                                <span style="color: #f00;">*</span> <%=GetLanguage("Email")%>：
                            </label>
                            <div class="field">
                                <input name="txtEmail" type="text" id="txtEmail" runat="server" class="input_reg" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="action">
                    <asp:Button ID="btnSubmit" runat="server" class="btn" OnClick="btnSubmit_Click" />
                </div>
            </div>

        </div>


    </form>
</body>
</html>
