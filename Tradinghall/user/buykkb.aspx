<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buykkb.aspx.cs" Inherits="Tradinghall.user.buykkb" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" href="../images/favicon.ico" type="images/x-icon" />
    <link href="../css/mine.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/footable.core.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.ui.all.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/ui.fancytree.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.orgchart.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.steps.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.bxslider.css" rel="stylesheet" type="text/css" media="all" />
    <%--<script type="text/javascript" src="../js/jquery-1.11.0.min.js"></script>--%>
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
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/functions.js"></script>

</head>
<body>
    <form runat="server">
        <div class="main_container">
            <div class="center_content">
                <div class="right_content" style="height: 1000px">
                    <h2><%=GetLanguage("CommissionedBuy")%> <%--买入夸克币--%>
                    </h2>

                    <p />
                    <p></p>
                    <!-- main content start -->
                    <style type="text/css">
                        .table-responsive .table {
                            border: 1px solid #666;
                            font-size: 14px;
                        }

                        .table-responsive .table-bordered td, .table-responsive .table-bordered th {
                            border-color: #666;
                            vertical-align: middle;
                        }

                        .table .form-control {
                            background: none;
                        }

                        .table th {
                            font-size: 16px;
                            font-weight: 700;
                            background: #aaa;
                            text-align: center;
                        }
                    </style>
                    <div class="row">
                        <div class="col-sm-10">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6">
                                <div class="table-responsive">
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th colspan="2">立即买入</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><%=GetLanguage("Pursetype")%> <%--钱包类型--%>：</td>
                                                <td>
                                                    <select name="moneyType" id="moneyType" class="form-control">
                                                        <option value="1"><%=GetLanguage("TradingpointWallet")%> <%--交易点数钱包--%> </option>
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><%=GetLanguage("Quarkpursebalance")%> <%--夸克币钱包余额--%>：</td>
                                                <td>
                                                    <span id="Label1" class="form-control"><%=LoginUser.User011%></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><%=GetLanguage("BalanceTransacPoint")%> <%--交易点数钱包余额--%>：</td>
                                                <td>
                                                    <span id="Label2" class="form-control"><%=LoginUser.Emoney%></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><%=GetLanguage("Currentpric")%><%--当前价格--%>：</td>
                                                <td>
                                                    <input runat="server" value="" name="txtbuyprice" type="text" id="txtbuyprice" class="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><%=GetLanguage("PurchaseQuantity")%><%--购买数量--%>：</td>
                                                <td>
                                                    <input runat="server" value="" name="buyNum" type="text" id="buyNum" class="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><%=GetLanguage("PaymentpPassword")%><%--支付密码--%>：</td>
                                                <td>
                                                    <input runat="server" value="" name="paypwd" type="password" id="paypwd" class="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div class="text-center">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="" class="btn btn-primary" OnClick="btnSubmit_Click" />
                                                        <%if (currentCulture == "en-us")
                                                            {%>
                                                        <input type="reset" class="btn btn-default" value="Cancel" onclick="reset()" />
                                                        <%}
                                                            else
                                                            {%>
                                                        <input type="reset" class="btn btn-default" value="取消" onclick="reset()" />
                                                        <%} %>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-4">
                            <div class="table-responsive">
                                <table class="table table-bordered">
                                    <thead>
                                        <tr>
                                            <th class="text-success"><%=GetLanguage("buyPurchase")%><%--买入--%></th>
                                            <th><%=GetLanguage("Buyingprice")%><%--买入价--%></th>
                                            <th><%=GetLanguage("Commissionquantity")%><%--委单量--%></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater2" runat="server">
                                            <ItemTemplate>
                                                <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                    <td class="text-danger"><%=GetLanguage("maichuBuy")%><%--买--%>(<%# Container.ItemIndex+1 %>)</td>
                                                    <td>$<%#Eval("Price")%></td>
                                                    <td>
                                                        <%#Eval("BuyNum")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                    <tr id="tr2" runat="server">
                                        <td colspan="3">
                                            <div class="NoData">
                                                <span class="cBlack">
                                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                                    <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="pager" style="display:none" >
                                <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText="" OnPageChanged="AspNetPager2_PageChanged"
                                    LastPageText="" NextPageText="" PrevPageText="" AlwaysShow="True" InputBoxClass="pageinput"
                                    NumericButtonCount="3" PageSize="5" ShowInputBox="Never" ShowNavigationToolTip="True"
                                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                                </webdiyer:AspNetPager>

                            </div>
                        </div>

                        <div class="col-sm-4">
                            <div class="table-responsive">
                                <table class="table table-bordered">
                                    <thead>
                                        <tr>
                                            <th class="text-danger"><%=GetLanguage("maichu")%><%--卖出--%></th>
                                            <th><%=GetLanguage("SellingPrice")%><%--卖出价--%></th>
                                            <th><%=GetLanguage("Commissionquantity")%><%--委单量--%></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                    <td class="text-danger"><%=GetLanguage("maichuSell")%><%--卖--%>(<%# Container.ItemIndex+1 %>)</td>
                                                    <td>$<%#Eval("Price")%></td>
                                                    <td>
                                                        <%#Eval("SaleNum")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                    <tr id="tr1" runat="server">
                                        <td colspan="3">
                                            <div class="NoData">
                                                <span class="cBlack">
                                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                                    <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="pager" style="display:none">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="" OnPageChanged="AspNetPager1_PageChanged"
                                    LastPageText="" NextPageText="" PrevPageText="" AlwaysShow="True" InputBoxClass="pageinput"
                                    NumericButtonCount="3" PageSize="5" ShowInputBox="Never" ShowNavigationToolTip="True"
                                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                                </webdiyer:AspNetPager>

                            </div>
                        </div>
                    </div>
                    <!-- main content end -->


                    <input type="hidden" runat="server" id="hdsellid" />
                    <script type="text/javascript">
                        function sellp(a) {
                            var b = $("#hd_" + a).val();
                            $("#hdsellid").val(a);
                            $("#buyprice").text(b);
                            var c = $("#txtBuyNum").val();
                            if (c > 0) {
                                var d = c * b;
                                $("#needMoney").text(d.toFixed(2));
                            }
                        }

                        function selln() {
                            var a = $("#buyprice").text();
                            var b = $("#txtBuyNum").val();
                            if (a > 0 && b > 0) {
                                var c = a * b;
                                $("#needMoney").text(c.toFixed(2));
                            }
                        }

                    </script>


                </div>
                <!--end of right content-->
            </div>
            <!--end of center content-->

        </div>
    </form>
</body>
</html>
