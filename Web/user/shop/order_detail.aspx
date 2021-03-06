﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_detail.aspx.cs" Inherits="Web.user.shop.order_detail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body class="bg">
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("OrderDetails")%><%--订单明细--%></h2>
            <div class="filter">
                <h2>
                    <%--<a href="Rail.aspx" class="butSize btn"><%=GetLanguage("ProductList")%><!--产品列表--></a>--%>
                    <a href="order.aspx" class="butSize btn"><%=GetLanguage("MyOrder")%><!--我的订单--></a>
                </h2>
            </div>
            <h6><%=GetLanguage("OrderInformation")%><!--订单信息--></h6>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("OrderNumber")%><!--订单号-->：</label>
                        <span class="field">
                            <input name="txtOrderCode" type="text" id="txtOrderCode" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("MembershipNumber")%><!--会员编号-->：</label>
                        <span class="field">
                            <input name="txtUserCode" type="text" id="txtUserCode" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("ConsigneeName")%><!--收货人姓名-->：</label>
                        <span class="field">
                            <input name="txtTrueName" type="text" id="txtTrueName" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("ContactPhone")%><!--联系电话-->：</label>
                        <span class="field">
                            <input name="txtPhone" type="text" id="txtPhone" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("ShopAddress")%><!--收货地址-->：</label>
                        <span class="field">
                            <input name="txtAddress" type="text" id="txtAddress" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnBack" runat="server" class="btn" OnClick="btnBack_Click" />
                    </p>
                </div>
            </div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("TheTotalAmount")%><!--总金额-->：</label>
                        <span class="field">
                            <input name="txtTotalAmount" type="text" id="txtTotalAmount" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("Express")%><!--快递公司-->：</label>
                        <span class="field">
                            <input name="txtExpress" type="text" id="txtExpress" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("ExpressOrder")%><!--快递单号-->：</label>
                        <span class="field">
                            <input name="txtExpressOrder" type="text" id="txtExpressOrder" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                </div>
            </div>
            <div class="filter">
                <div class="row-fluid">
                    <table class="styled">
                        <thead>
                            <tr>
                                <th align="center">
                                    <%=GetLanguage("ItemNumber")%><!--商品编号-->
                                </th>
                                <th align="center">
                                    <%=GetLanguage("CommodityName")%><!--商品名称-->
                                </th>
                                <th align="center">
                                    <%=GetLanguage("CommodityPrice")%><!--商品价格-->
                                </th>
                                <%--<th align="center">
                        <%=GetLanguage("ProductScore")%><!--商品积分-->
                    </th>--%>
                                <th align="center">
                                    <%=GetLanguage("PurchaseQuantity")%><!--购买数量-->
                                </th>
                                <th align="center">
                                    <%=GetLanguage("TheTotalAmount")%><!--总金额-->
                                </th>
                                <th align="center">
                                    <%=GetLanguage("DateOfPurchase")%><!--购买日期-->
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <%-- <td>
                                <a href='<%#Eval("ProcudeID","detail.aspx?type=1&id={0}&payment=2") %>' target="_blank"><img src='../../Upload/<%# Eval("Pic1") %>' width="100" height="100" alt=""/></a>
                            </td>--%>
                                        <td align="center">
                                            <%#Eval("GoodsCode")%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("GoodsName")%>
                                            <br />
                                            <span>尺码：<%# Eval("gSize") %></span><br /><span>颜色：<%# Eval("gColor") %></span></td>
                                        <td align="center">￥ <%#Eval("Price")%>
                                        </td>
                                        <%--<td>
                                <%#Eval("PV")%>
                            </td>--%>
                                        <td align="center">
                                            <%#Eval("OrderSum")%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("OrderTotal")%>
                                        </td>
                                        <td align="center">
                                            <%#Eval("OrderDate")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <tr runat="server" id="tr1">
                            <td colspan="6" align="center">
                                <div id="divno" runat="server" class="NoData">
                                    <span class="cBlack"><%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                                </div>
                            </td>
                        </tr>
                    </table>

                    <div class="pager">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页" OnPageChanged="AspNetPager1_PageChanged"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
