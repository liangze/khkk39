﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goumaiL.aspx.cs" Inherits="Web.user.Cash.goumaiL" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("PurchaseList")%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("UserName")%><%--用户名称--%>:</label>
                        <span class="field">
                            <input type="text" id="name" name="DateFromname" runat="server" value="" />
                        </span>
                    </p>
                    <%--<p class="span3">
                        <label>类型: </label>
                        <span class="field">
                            <select name="Type">
                                <option value="10">全部</option>
                            </select>
                        </span>
                    </p>--%>
                    <p class="span3">
                        <label><%=GetLanguage("PurchaseTime")%><!--购买时间-->：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                {%>
                            <asp:TextBox ID="txtStart" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                                else
                                {%>
                            <asp:TextBox ID="txtStartEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                {%>
                            <asp:TextBox ID="txtEnd" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                            <%}
                                else
                                {%>
                            <asp:TextBox ID="txtEndEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" class="btn" Text="" OnClick="btnSearch_Click" />
                    </p>
                </div>
            </div>
            <table class="styled">
                <thead>
                    <tr>


                        <th style="text-align: center;"><%=GetLanguage("CommodityPrices")%><%--商品单价--%>
                        </th>
                        <th style="text-align: center;"><%=GetLanguage("PurchaseQuantity")%> <%--购买数量--%>
                        </th>
                        <th style="text-align: center;"><%=GetLanguage("TotalAmount")%> <%--总额--%>
                        </th>

                        <th style="text-align: center;"><%=GetLanguage("PurchaseTime")%><%--购买时间--%>
                        </th>

                        <th style="text-align: center;"><%=GetLanguage("State")%><%--状态--%>
                        </th>

                    </tr>
                </thead>

                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">

                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <%--<td style="text-align: center;">
                                    <%# userBLL.GetUserCode(long.Parse(Eval("Number").ToString())) %>
                                </td>--%>

                                <td style="text-align: center;">
                                    <%#Eval("Price")%>
                                </td>

                                <td style="text-align: center;">
                                    <%#Eval("BuyNum") %>
                                </td>

                                <td style="text-align: center;">
                                    <%#Eval("Amount")%>
                                </td>

                                <td style="text-align: center;">
                                    <%#Eval("BuyDate") %>
                                </td>
                                <td style="text-align: center;">

                                    <%if (GetLanguage("LoginLable") == "zh-cn")
                                        {%>
                                    <%#Convert.ToInt32(Eval("IsBuy")) == 1 ? "已完成" :Convert.ToInt32(Eval("IsBuy")) == 0 ? "等待发货":"交易取消"%>
                                    <%}
                                        else
                                        {%>
                                    <%#Convert.ToInt32(Eval("IsBuy")) == 1 ? "Completed" :Convert.ToInt32(Eval("IsBuy")) == 0 ? "Waiting for delivery":"Transaction cancellation"%>
                                    <%} %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="6">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="pager">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText=""
                    LastPageText="" NextPageText="" PrevPageText="" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
