<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doForgot.aspx.cs" Inherits="Tradinghall.doForgot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title><%=getParamVarchar("SystemName2")%></title>

    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/footable.core.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/jquery.ui.all.css" rel="stylesheet" type="text/css" media="all" />


    <link href="css/jquery.orgchart.css" rel="stylesheet" type="text/css" media="all" />

    <link href="css/jquery.steps.css" rel="stylesheet" type="text/css" media="all" />

    <link href="css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />

    <link href="css/jquery.bxslider.css" rel="stylesheet" type="text/css" media="all" />

    <script type="text/javascript" src="js/jquery-1.11.0.min.js"></script>

    <script type="text/javascript" src="js/footable.js"></script>

    <script type="text/javascript" src="js/footable.paginate.js"></script>

    <script type="text/javascript" src="js/footable.sort.js"></script>

    <script type="text/javascript" src="js/jquery.ui.core.js"></script>

    <script type="text/javascript" src="js/jquery.ui.widget.js"></script>

    <script type="text/javascript" src="js/jquery.ui.datepicker.js"></script>

    <script type="text/javascript" src="js/jquery.fancytree.js"></script>

    <script type="text/javascript" src="js/jquery.orgchart.js"></script>

    <script type="text/javascript" src="js/jquery.steps.min.js"></script>

    <script type="text/javascript" src="js/jquery.validate.min.js"></script>

    <script type="text/javascript" src="js/jquery.fancybox.pack.js"></script>

    <script type="text/javascript" src="js/jquery.bxslider.min.js"></script>

    <script type="text/javascript" src="js/jquery.idTabs.min.js"></script>

    <script type="text/javascript" src="js/functions.js"></script>

    <style>
        a.apk {
            font-weight: bold;
            font-size: 18px;
            width: 100%;
            text-align: center;
            display: block;
            margin-top: 20px;
            background-color: rgba(0,0,0,0.5);
            padding: 15px;
            border: 1px solid rgba(0,0,0,0.7);
            border-radius: 5px;
        }

            a.apk * {
                vertical-align: middle;
                margin-right: 10px;
            }

            a.apk img {
                width: 15%;
            }
    </style>

</head>
<body>
    <div class="login main_container" style="height: 900px;">
        <div class="header clearfix">
            <div class="header-img">
                <div class="logo">
                    <h1 style="text-align: right; width: 25%;">
                        <img src="images/picture/logo.png" width="100" />
                    </h1>
                </div>
                <!--end of logo-->
            </div>
        </div>
        <div class="right_content">
            <h2>
                <img  width="35" /><%=GetLanguage("ForgetPassword")%><%--忘记密码--%> <small class="pull-right" style="font-size: 12px;"></small></h2>
            <div class="panel">
                <form id="Form1" class="stdform" method="post" runat="server">
                    <div id="qinkog" class="row-fluid">
                        <div class="span8">
                            <div class="control-group">
                                <label for="Uidsy"><%=GetLanguage("Usernname")%><%--用户登录名--%></label>
                                <div class="field">
                                    <input id="TBUserName" name="TBUserName" value="" type="text" runat="server" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="Uidsy"><%=GetLanguage("ContactPhone")%>/<%=GetLanguage("EMail")%><%--手机号/邮箱--%></label>
                                <div class="field">
                                    <input name="txtPhonMailNum" id="txtPhonMailNum" runat="server" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="Uidpass"><%=GetLanguage("newpassword")%><%--新登录密码--%></label>
                                <div class="field">
                                    <input name="txtNewPwd" id="txtNewPwd" class="input_reg" runat="server" type="password" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="Uid"><%=GetLanguage("ConfirmPayPassword")%><%--确认密码--%></label>
                                <div class="field">
                                    <input name="txtRPNewPwd" id="txtRPNewPwd" class="input_reg" runat="server" type="password" />
                                </div>
                            </div>
                            <!--end of control group-->
                            <div class="control-group action">
                                <asp:Button ID="btnPwd" runat="server" class="btn" OnClick="btnPwd_Click" />
                                <%--<input type="submit" name="reset" value="重置" />--%>
                                <asp:Button ID="Resetsubmit" runat="server" class="btn" Text="" OnClick="reset_Click" />
                            </div>
                            <div class="control-group action">
                                <input id="rturen" type="button" name="button" value="" onclick="re()" runat="server" />
                            </div>
                        </div>
                        <!--end of span6-->
                        <div class="action">
                        </div>
                    </div>
                </form>
                <!--end of stdform-->
                <div class="footer">
                    <p>Copyright &copy; 2016 qrkctub.  All rights reserved.</p>
                </div>
            </div>
            <!--end of login area-->
        </div>
        <!--end of right content-->
        <div class="foot_container">
            <img src="images/login_shadow.png" class="foot_shadow" />
        </div>
    </div>
    <!--end of main container-->
</body>
<script type="text/javascript">
    function re() {
        window.location.href = "login.aspx";
    }
</script>
<script type="text/javascript">
    $("#txtPhonMailNum").blur(function () {
        var re = /^\w+@[a-z0-9]+\.[a-z]+$/i;
        var re2 = /^1[3|4|5|7|8]\d{9}$/;
        if (re.test($("#txtPhonMailNum").val()) || re2.test($("#txtPhonMailNum").val())) {
            alert("<%=GetLanguage("LegalInput")%>")
        } else {
            alert("<%=GetLanguage("LegalbeInput")%>")
        }
    })
</script>
</html>
