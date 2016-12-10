<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registe.aspx.cs" Inherits="Web.Registe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=GetLanguage("registration")%></title>
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
</head>
<body>
    <form id="form1" runat="server" class="stdform">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        <div class="main_container">
            <div class="header clearfix">
                <div class="logo">
                    <a href="index.aspx">
                        <img alt="" src="images/dlogo1.png" width="68px" /></a>
                </div>
                <!--end of logo-->
                <div class="menu">
                    <ul>
                        <li><a class="toggle_menu">
                            <img alt="" src="static/img/ico_menu.png" />
                            Menu</a></li>
                        <li><a class="toggle_setting">
                            <img alt="" src="static/img/ico_setting.png" />
                            Setting</a></li>
                    </ul>
                </div>
                <!--end of menu-->
                <div class="right_header">
                    <a href="Login.aspx"><span style="font-size: 16px; color: #fff;"><%=GetLanguage("Login")%></span></a>&nbsp;&nbsp;
                </div>
                <!--end of right header-->
            </div>
            <div class="center_content">
                <div class="left_content">
                    <div class="sidebarmenu">
                       
                        <%--<p class="footer">Copyright © 2015 CPM. All rights reserved.</p>--%>
                    </div>
                    <!--end of sidebarmenu-->
                </div>
                <iframe name="mainfrom" id="mainfrom" marginwidth="0" marginheight="0" src="<%=strUrl%>"
                    onload="this.height=mainfrom.document.body.scrollHeight < 560 ? 675 : mainfrom.document.body.scrollHeight;"
                    frameborder="0" width="100%" scrolling="auto"></iframe>
            </div>
            <!--end of center_content -->
        </div>
    </form>
</body>
</html>
