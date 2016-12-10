<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Tradinghall.user.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=getParamVarchar("SystemName2")%></title>
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
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

</head>
<body>
    <form id="form1" runat="server">
        <div class="main_container">
            <div class="header clearfix">
                <div class="logo">
                    <a href="index.aspx">
                        <img alt="" src="../images/dlogo1.png" width="68px" /></a>
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
                    <ul>
                        <li><a href="index.aspx"><%=GetLanguage("index")%> <%--首页--%></a></li>
                        <li><a href="http://www.qrkbestvip.com/Login.aspx"><%=GetLanguage("UserCenter")%><%--会员中心--%></a>

                       </li>
                        <li class="parent"><a href="javascript:void(0);">
                            <img alt="" src="../static/img/ico_user.png" /><%=LoginUser.UserCode%></a>
                            <ul>
                               <%-- <li><a href="member/PersonalInfo.aspx" target="mainfrom"><%=GetLanguage("MemberInformation")%><!--会员资料--></a></li>
                                <li><a href="member/ModifyPassWord.aspx" target="mainfrom"><%=GetLanguage("ModifyPassword")%><!--修改密码--></a></li>--%>
                                <%if (currentCulture == "en-us")
                                    {%>
                                <li><a href="../loginout.aspx" onclick="javascript:return confirm('Are you sure to exit?')" style="width: 120px;"><%=GetLanguage("Exit")%></a></li>
                                <%}
                                    else
                                    {%>
                                <li><a href="../loginout.aspx" onclick="javascript:return confirm('确定退出吗？')" style="width: 120px;"><%=GetLanguage("Exit")%></a></li>
                                <%} %>
                            </ul>
                        </li>
                    </ul>
                </div>
                <!--end of right header-->
            </div>
            <div class="center_content">
                <iframe name="mainfrom" id="mainfrom" marginwidth="0" marginheight="0" src="<%=strUrl%>"
                    onload="this.height=mainfrom.document.body.scrollHeight < 560 ? 800 : mainfrom.document.body.scrollHeight;"
                    frameborder="0" width="100%" scrolling="auto"></iframe>
                <div class="left_content">
                    <div class="sidebarmenu">
                        <ul>
                            <li class="parent"><a class="active"><%=GetLanguage("TradingFloor")%></a><%--交易大厅--%>
                                <ul ><%--style="display: block;"--%>
                                    <li><a href="index.aspx"><%=GetLanguage("index")%></a></li>
                                    <%--首页--%>

                                    <li><a href="kchart.aspx" target="mainfrom"><%=GetLanguage("KChart")%><%--K线图--%></a></li>
                                    <li><a href="transactionrecords.aspx" target="mainfrom"><%=GetLanguage("Tradingrecord")%><%--交易记录--%></a></li>
                                    <li><a href="agencytransaction.aspx" target="mainfrom"><%=GetLanguage("CommissionedSell")%><%--委托交易--%></a></li>
                                    <li><a href="buykkb.aspx" target="mainfrom"><%=GetLanguage("CommissionedBuy")%><%--买入夸克币--%></a></li>
                                    <li><a href="goldcoin07.aspx" target="mainfrom"><%=GetLanguage("CoinPurse")%><%--夸克币钱包--%></a></li>
                                </ul>
                            </li>
                            <%if (LoginUser.IsAgent == 1)
                                {%>

                            <%} %>
                        </ul>
                        <p class="footer">Copyright © 2016 CPM. All rights reserved.</p>
                    </div>
                    <!--end of sidebarmenu-->
                </div>

            </div>

            <!--end of center content-->
        </div>
    </form>
</body>
</html>
