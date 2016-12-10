﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goldcoin07.aspx.cs" Inherits="Web.user.goldcoin07" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("PersonalAccount")%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("Date")%>：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStart" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtStartEn" runat="server" class="input_select" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtEnd" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEndEn" runat="server" class="input_select" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" class="btn" OnClick="btnSearch_Click" />
                       
                        <asp:Button ID="btnBack" runat="server" class="btn" Text="" OnClick="btnBack_Click" />
                        
                        <a href="TransferKuake.aspx" class="btn"><%=GetLanguage("TurnCoinPurse")%><%--转存币钱包--%></a>
                    </p>
                </div>
                <fieldset class="legend">
                    <div class="row-fluid">
                        <div class="span4"><b><%=GetLanguage("delegType")%><%--类型--%>:</b> <%=GetLanguage("QuarkCoin")%><%--夸克币--%></div>
                        <!--end of span4-->
                        <div class="span4"><b><%=GetLanguage("Balance")%><%--结余--%>:</b> <%=LoginUser.User011%></div>
                        <!--end of span4-->
                    </div>
                </fieldset>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <th><%=GetLanguage("BusinessSummary")%></th>
                        <th><%=GetLanguage("AccountTypes")%></th>
                        <th><%=GetLanguage("CurrencyType")%><!--币种--></th>
                        <th><%=GetLanguage("AccountAmount")%></th>
                        <th><%=GetLanguage("Balance")%></th>
                        <th><%=GetLanguage("Date")%></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <%if (Language == "zh-cn") %>
                                    <%{ %>
                                    <%#Eval("Remark")%><%-- 详情--%>
                                    <%}
                                      else
                                      { %>
                                    <%#Eval("Remarken")%><%-- 详情--%>
                                    <%} %>
                                </td>
                                <td align="center"><%#AccountType(Eval("InAmount").ToString())%></td>
                                <td align="center"><%#GoldType(Eval("JournalType").ToString())%></td>
                                <td align="center">
                                    <%#AccountType(Eval("InAmount").ToString()) == "支出" ? Eval("OutAmount") : Eval("InAmount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BalanceAmount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("JournalDate")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="6" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img alt="" src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    <%=GetLanguage("Manager")%></span>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="pager">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="" OnPageChanged="AspNetPager1_PageChanged"
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
