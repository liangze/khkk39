<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

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

    <script type="text/javascript" src="js/jquery.idtabs.min.js"></script>

    <script type="text/javascript" src="js/functions.js"></script>
    <script src="js/login.js?v=1.0" type="text/javascript"></script>

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
    <style type="text/css">
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

        .backdiv {
            width: 500px;
            overflow: hidden;
            border: 6px solid #ccc;
            padding: 15px;
            position: absolute;
            z-index: 400;
            background-color: #fff;
            display: none;
        }
    </style>
    <style type="text/css">
        .fancybox-margin {
            margin-right: 0px;
        }
    </style>
    <script type="text/javascript">
        String.prototype.Trim = function () {
            return this.replace(/(^\s*)|(\s*$)/g, "");
        }

        function ed(id) { return document.getElementById(id); }

        function CheckText() {
            if (ed("TBUserName").value.Trim() == "") {
                alert("<%=GetLanguage("PleasaccountNnumber")%>！");
                ed("TBUserName").focus();
                ed("checkCode").src = $("checkCode").src;
                return false;
            }
            if (ed("TBPassWord").value.Trim() == "") {
                alert("<%=GetLanguage("PleaseInputPassword")%>！");
                ed("TBPassWord").focus();
                ed("checkCode").src = $("checkCode").src;
                return false;
            }
            if (ed("TBCode").value.Trim() == "") {
                alert("<%=GetLanguage("PleasVerificationCode")%>！");
                ed("TBCode").focus();
                ed("checkCode").src = $("checkCode").src + "?";
                return false;
            }
            if (ed("checkCode").length < 6) {
                alert("<%=GetLanguage("PlesVericationCode")%>！");
                ed("checkCode").focus();
                ed("checkCode").src = $("checkCode").src + "?";
                return false;
            }
            return true;
        }
    </script>
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
            </div>
        </div>

        <div class="right_content">
            <h2>
                <img  width="35" /><%=GetLanguage("Memberlogin")%><%--会员登录--%> <small class="pull-right" style="font-size: 12px;"></small></h2>
            <div class="panel">
                <!--待定-->
                <form class="stdform" runat="server">
                    <asp:Panel runat="server" ID="Panel1" DefaultButton="btnLogin">
                    <div class="row-fluid">

                        <div class="span8">

                            <div class="control-group">

                                <label for="email"><%=GetLanguage("Usernname")%><%--登录用户名--%></label>

                                <div class="field">
                                    <input id="TBUserName" name="TBUserName" type="text" runat="server" />

                                </div>

                            </div>
                            <div class="control-group">

                                <label for="email"><%=GetLanguage("LoginPPassword")%><%--登录密码--%></label>

                                <div class="field">
                                    <input id="TBPassWord" name="TBPassWord" type="password" runat="server" />

                                </div>

                            </div>
                            <!--end of control group-->
                            <div class="control-group">

                                <label for="password"><%=GetLanguage("Language")%><%--语言--%></label>

                                <div class="field">
                                    <%--<select name="locale" onchange="window.location.href='loginen.aspx';" aria-invalid="false" class="valid">
                                        <option value="en_us">English</option>
                                        <option value="zh_cn" selected="selected">中文</option>
                                    </select>--%>         
                                        <asp:DropDownList ID="dropLanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropLanguage_SelectedIndexChanged" CssClass="valid">
                                            
                                        </asp:DropDownList>
                                    
                                </div>

                            </div>
                            <!--end of control group-->

                            <div class="control-group">

                                <label for="catcha">&nbsp;</label>

                                <div class="field">
                                    <input type="image" id="checkCode" style="width: 280px; height: 40px; border: 0px; /*background: 0; */ cursor: pointer;" onclick="createCode();" />
                                </div>

                            </div>
                            <!--end of control group-->



                            <div class="control-group">

                                <label for="catcha"><%=GetLanguage("VerificationCode")%><%--验代码--%></label>

                                <div class="field">
                                    <input id="TBCode" name="TBCode" type="text" autocomplete="off" size="7" runat="server" />
                                </div>

                            </div>
                            <!--end of control group-->
                            <div class="control-group action">
                                <asp:Button ID="btnLogin" runat="server" TabIndex="4" class="btn" OnClientClick="return CheckText();" OnClick="btnLogin_Click" Text="" />
                            </div>

                            <div class="control-group" style="text-align: center; overflow: hidden;">
                                <a href="doForgot.aspx" style=""><%=GetLanguage("ForgetPassword")%><%--忘记密码--%></a>
                                <%--<a href="Registe.aspx" style="float: right">用户注册</a>--%>
                            </div>
                        </div>


                        <!--待定-->

                        </asp:Panel>

                        <div class="action">
                        </div>

                </form>
                <!--end of stdform-->
                <div class="footer" style="margin-top: 360px;">
                    <p>Copyright &copy; 2016 qrkctub.  All rights reserved.</p>
                </div>
            </div>
            <!--end of login area-->
        </div>
    </div>
</body>
</html>
