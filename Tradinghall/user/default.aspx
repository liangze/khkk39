<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Tradinghall.user._default" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=getParamVarchar("SystemName2")%></title>
    <link href="../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link rel="../shortcut icon" href="images/favicon.ico" type="images/x-icon" />
    <link href="../css/footable.core.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.ui.all.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/ui.fancytree.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.orgchart.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.steps.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.bxslider.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="../js/footable.js"></script>
    <script type="text/javascript" src="../js/footable.paginate.js"></script>

    <script type="text/javascript" src="../js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript" src="../js/jquery.fancytree.js"></script>
    <script type="text/javascript" src="../js/jquery.orgchart.js"></script>
    <script type="text/javascript" src="../js/jquery.steps.min.js"></script>
    <script type="text/javascript" src="../js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../js/jquery.lightbox-0.5.pack.js"></script>
    <script type="text/javascript" src="../js/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="../js/jquery.bxslider.min.js"></script>
    <script type="text/javascript" src="../js/jquery.idtabs.min.js"></script>
    <script type="text/javascript" src="../js/functions.js"></script>
    <style type="text/css">
        .row-fluid [class*="span"] {
            margin-left: 0;
        }
    </style>
    <script type="text/jscript">
        function focusAndSelect(obj) {
            obj.focus();
            obj.select();
        }
    </script>
</head>
<body>
    <div class="center_content">
        <div class="right_content">
            <h2>&nbsp;&nbsp;<%=GetLanguage("Welcome")%><%--欢迎--%>&nbsp;&nbsp;<%=LoginUser.UserCode%>
                <%=levelBLL.GetLevelName(LoginUser.LevelID)%>
                
            </h2>
            <form id="form2" runat="server">
                <div class="announce" style="height:46px;">
                    <%--<marquee loop="true" scrolldelay="150" direction="left" behavior="scroll">
                    
                     
            </marquee>--%>
                </div>
                <!--end of announcement-->
                <table width="100%" cellpadding="10">
                    <tbody>
                        <tr valign="top">
                            <td width="50%">
                                <div class="ico_body row-fluid collapse">
                                    <div class="span2 ico_head collapse_head">
                                        <img alt="" src="../static/img/ico_user_white.png" /><br />
                                        <%=GetLanguage("MemberInfo")%><!--会员信息-->
                                    </div>
                                    <!--end of span2-->
                                    <div class="span10 collapse_body">
                                        <div class="row-fluid">
                                            <div class="span4">
                                                <%=GetLanguage("Language")%><%--语言--%><p class="figure">
                                                    <asp:DropDownList ID="dropLanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropLanguage_SelectedIndexChanged" CssClass="valid">
                                                    </asp:DropDownList>
                                                </p>
                                            </div>
                                            <div class="span4">
                                                <%=GetLanguage("CommissionPoints")%><%--佣金点数--%><p class="figure"><%=LoginUser.AllBonusAccount%></p>
                                                <%--<%=GetBonusAllTotal(getLoginID(), "Amount")%>--%>
                                            </div>
                                            <div class="span4">
                                                <%=GetLanguage("Registeredcurrency")%><%--注册点数--%><p class="figure"><%=LoginUser.BonusAccount%></p>
                                            </div>
                                        </div>

                                        <div class="row-fluid">
                                            <div class="span4">
                                                <%=GetLanguage("TradingPoints")%><%--交易点数--%><p class="figure"><%=LoginUser.Emoney%></p>
                                            </div>
                                            <div class="span4">
                                                <%=GetLanguage("xianjin")%><%--现金币--%><p class="figure"><%=LoginUser.StockMoney%></p>
                                            </div>
                                            <div class="span4">
                                                <%=GetLanguage("ActivationPoints")%><%--激活点数--%><p class="figure"><%=LoginUser.GLmoney%></p>
                                            </div>
                                            <div class="span4">
                                                <%=GetLanguage("stockRight")%><%--股权--%><p class="figure"><%=LoginUser.StockAccount%></p>
                                            </div>
                                            <div class="span4">
                                                <%=GetLanguage("CurrencyBalance")%><%--商城点数--%>
                                                <p class="figure"><%=LoginUser.ShopAccount%></p>
                                            </div>
                                            <div class="span4">
                                                <%=GetLanguage("QuarkCoin")%><%--夸克币--%><p class="figure"><%=LoginUser.User011%> </p>
                                            </div>
                                            <div class="span4">
                                                <%=GetLanguage("chibi")%><%--持币--%><p class="figure"><%=LoginUser.User012%> </p>
                                            </div>
                                            <div class="span4">
                                                <%=GetLanguage("cunbi")%><%--存币--%><p class="figure"><%=LoginUser.User013%> </p>
                                            </div>

                                        </div>

                                    </div>

                                </div>

                            </td>
                        </tr>
                    </tbody>
                </table>
            </form>
        </div>
    </div>
</body>
</html>
