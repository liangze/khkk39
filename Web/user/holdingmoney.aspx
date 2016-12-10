<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="holdingmoney.aspx.cs" Inherits="Web.user.holdingmoney" %>

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
                    <%--<p class="span3">
                        <label><%=GetLanguage("CurrencyType")%><!--币种-->：</label>
                        <span class="field">
                            <asp:DropDownList ID="dropCurrency" runat="server"></asp:DropDownList>
                        </span>
                    </p>--%>
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
                        <asp:Button ID="btnSearch" runat="server" class="btn" OnClick="btnSearch_Click" />&nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" class="btn" Text="返回" OnClick="btnBack_Click" />
                    </p>
                </div>
               
            </div>
             <table class="styled" style="font-size: inherit;">
                <thead>
                    <tr>
                        <th align="center">
                            <%=GetLanguage("AwardName")%><!--奖项名称-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("BonusAmount")%><!--奖金金额-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("TaxDeduction")%><%--扣税--%>
                        </th>
                        <th align="center">
                            <%=GetLanguage("SettlementDate")%><!--结算日期-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("State")%><!--状态-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("Details")%><!--详情-->
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <%if (GetLanguage("LoginLable") == "zh-cn") %>
                                    <%{ %>
                                    <%#Eval("typename")%>
                                    <%}
                                      else
                                      { %>
                                    <%#Eval("typenameen")%>
                                    <%} %>
                                </td>
                                <td align="center">
                                    <%#Eval("amount")%><!--金额-->
                                </td>
                                <td align="center">
                                    <%#Eval("Revenue")%><!--扣税-->
                                </td>
                                <td align="center">
                                    <%#Eval("SttleTime")%><!--结算日期-->
                                </td>
                                <td align="center">

                                    <%if (GetLanguage("LoginLable") == "zh-cn") %>
                                    <%{ %>
                                    <%#Convert.ToInt32(Eval("IsSettled")) == 1 ? "已发放" : "未发放"%>
                                    <%}
                                      else
                                      { %>
                                    <%#Convert.ToInt32(Eval("IsSettled")) == 1 ? "Issue" : "Not issue"%>
                                    <%} %>
                                </td>
                                <td align="center">
                                    <%if (GetLanguage("LoginLable") == "zh-cn") %>
                                    <%{ %>
                                    <%#Eval("source")%><%-- 详情--%>
                                    <%}
                                      else
                                      { %>
                                    <%#Eval("sourceen")%><%-- 详情--%>
                                    <%} %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="8" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
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
    </form>
</body>
</html>
