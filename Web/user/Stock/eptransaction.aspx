<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eptransaction.aspx.cs" Inherits="Web.user.Stock.eptransaction" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" href="../../images/favicon.ico" type="images/x-icon" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/footable.core.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/jquery.ui.all.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/ui.fancytree.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/jquery.orgchart.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/jquery.steps.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/jquery.bxslider.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="../../js/footable.js"></script>
    <script type="text/javascript" src="../../js/footable.paginate.js"></script>

    <script type="text/javascript" src="../../js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript" src="../../js/jquery.fancytree.js"></script>
    <script type="text/javascript" src="../../js/jquery.orgchart.js"></script>
    <script type="text/javascript" src="../../js/jquery.steps.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.lightbox-0.5.pack.js"></script>
    <script type="text/javascript" src="../../js/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="../../js/jquery.bxslider.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.idtabs.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../js/functions.js"></script>
    <style type="text/css">
        .filter p input[type="button"] {
            background-color: rgb(60,0,0);
            background-image: -moz-linear-gradient(top, rgba(110,0,0,1) 0%, rgba(60,0,0,1) 100%);
            background-image: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(110,0,0,1)), color-stop(100%,rgba(60,0,0,1)));
            background-image: -webkit-linear-gradient(top, rgba(110,0,0,1) 0%,rgba(60,0,0,1) 100%);
            background-image: -o-linear-gradient(top, rgba(110,0,0,1) 0%,rgba(60,0,0,1) 100%);
            background-image: linear-gradient(to bottom, rgba(110,0,0,1) 0%,rgba(60,0,0,1) 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#6e0000', endColorstr='#3c0000',GradientType=0 );
            background-repeat: repeat-x;
            background-position: 0 0;
            width: 100%;
            border: 1px solid rgba(0,0,0,0.5);
            border-radius: 5px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            box-shadow: inset 0px 1px 0px rgba(255,255,255,0.5);
            -moz-box-shadow: inset 0px 1px 0px rgba(255,255,255,0.5);
            -webkit-box-shadow: inset 0px 1px 0px rgba(255,255,255,0.5);
            color: #FFFFFF;
            text-shadow: 1px 1px 0px rgba(0,0,0,0.5);
            padding: 6px 15px;
            cursor: pointer;
        }
    </style>
    <script>
        function focusAndSelect(obj) {
            obj.focus();
            obj.select();
        }
    </script>
    <script type="text/javascript">
        function doSubmit(thisForm) {
            if (thisForm.DateFrom.value == "") {
                alert("Invalid Date!");
                return false;

            } else if (thisForm.DateTo.value == "") {
                alert("Invalid Date!");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form runat="server">
        <div class="main_container">
            <div class="right_content" style="height: 1100px">
                <h2><%=GetLanguage("GoldTrading")%><%--EP交易--%>
                </h2>
                <p />
                <p></p>
                <div class="filter">
                    <div class="row-fluid">
                        <%-- <p class="span3">
                           <input type="button" value="购买注册点数" data-toggle="modal" data-target="#EP01" />
                            购买注册点数
                        </p>--%>
                        <h6><%=GetLanguage("PurchaseRegistr")%><%--购买注册点数--%></h6>

                    </div>
                    <!--end of row-fluid-->
                </div>
                <!--end of filter-->
                <div class="ctr table-responsive" style="overflow-x: auto;">
                    <table class="styled footable no-paging footable-loaded tablet breakpoint" data-page-size="10000">
                        <thead>
                            <tr>

                                <th style="text-align: center;"><%=GetLanguage("UserName")%> <%--用户名称--%>
                                </th>
                                <th style="text-align: center;"><%=GetLanguage("shijian")%> <%--出售日期--%>
                                </th>

                                <th style="text-align: center;"><%=GetLanguage("CommodityPrices")%><%--商品单价--%>
                                </th>
                                <th style="text-align: center;"><%=GetLanguage("TotalRegistration")%><%--总注册点数--%>
                                </th>
                                <th style="text-align: center;"><%=GetLanguage("TotalAmount")%> <%--总额--%>
                                </th>
                                <th style="text-align: center;"><%=GetLanguage("Buy")%> <%--购买--%>
                                </th>
                            </tr>
                        </thead>

                        <tbody>
                            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">

                                <ItemTemplate>
                                    <tr class="<%# (this.Repeater2.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                        <td style="text-align: center;">
                                            <%# userBLL.GetUserCode(long.Parse(Eval("UserID").ToString())) %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%#Eval("SellDate") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%#Eval("Price")%>
                                        </td>
                                        <td style="text-align: center;">
                                            <%#Eval("SaleNum") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%#Eval("Amount")%>
                                        </td>
                                        <td style="text-align: center;">&nbsp<asp:LinkButton ID="lbtnCancel" runat="server" class="btn" CommandName="change"
                                            CommandArgument='<%#Eval("CashsellID")%>' ><%=GetLanguage("BuyGold")%><!--确认购买--></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <tr id="tr2" runat="server">
                            <td colspan="6" align="center">
                                <div class="NoData">
                                    <span class="cBlack">
                                        <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                        <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="pager">
                    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText=""
                        LastPageText="" NextPageText="" PrevPageText="" AlwaysShow="True" InputBoxClass="pageinput"
                        NumericButtonCount="3" PageSize="5" ShowInputBox="Never" ShowNavigationToolTip="True"
                        SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                        SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                    </webdiyer:AspNetPager>

                </div>
                <div class="filter">
                    <div class="row-fluid">
                        <p class="span3">
                            <input type="button" id="chousid" value="出售注册点数" onclick="re()" runat="server" />

                        </p>

                    </div>
                    <script type="text/javascript">
                        function re() {
                            window.location.href = "../Cash/CashSell.aspx";
                        }
                    </script>
                    <!--end of row-fluid-->
                </div>
                <!--end of filter-->

                <br />
                <div class="ctr table-responsive" style="overflow-x: auto;">
                    <table class="styled footable no-paging footable-loaded tablet breakpoint" data-page-size="10000">
                        <thead>
                            <tr>

                                <th style="text-align: center;"><%=GetLanguage("UserName")%> <%--用户名称--%>
                                </th>
                                <th style="text-align: center;"><%=GetLanguage("shijian")%> <%--出售日期--%>
                                </th>

                                <th style="text-align: center;"><%=GetLanguage("CommodityPrices")%><%--商品单价--%>（$）
                                </th>
                                <th style="text-align: center;"><%=GetLanguage("TotalRegistration")%><%--总注册点数--%>
                                </th>
                                <th style="text-align: center;"><%=GetLanguage("TotalAmount")%> <%--总额--%>($)
                                </th>
                                <th style="text-align: center;"><%=GetLanguage("Factorage")%> <%--手续费--%><%=GetLanguage("Registeredcurrency")%><%--(注册点)--%>
                                </th>
                                <th style="text-align: center;">
                                    <%=GetLanguage("Operation")%> <%--操作--%>
                                </th>
                            </tr>
                        </thead>

                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                <ItemTemplate>
                                    <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                        <td style="text-align: center;">
                                            <%# userBLL.GetUserCode(long.Parse(Eval("UserID").ToString())) %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%#Eval("SellDate") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%#Eval("Price")%>
                                        </td>
                                        <td style="text-align: center;">
                                            <%#Eval("Number") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%#Eval("Amount")%>
                                        </td>
                                        <td style="text-align: center;">
                                            <%#Eval("Charge")%>
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:LinkButton ID="lbtnCancel" runat="server" class="btn" CommandName="revoke"
                                                CommandArgument='<%#Eval("CashsellID")%>'><%=GetLanguage("Revoke")%><!--撤销--></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <tr id="tr1" runat="server">
                            <td colspan="7">
                                <div class="NoData">
                                    <span class="cBlack">
                                        <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                        <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="pager">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText=""
                        LastPageText="" NextPageText="" PrevPageText="" AlwaysShow="True" InputBoxClass="pageinput"
                        NumericButtonCount="3" PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True"
                        SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                        SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                    </webdiyer:AspNetPager>

                </div>

            </div>
            <!--end of right content-->
        </div>
        <!--end of center content-->
    </form>
</body>
</html>
