<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TakeMoney.aspx.cs" Inherits="Web.user.finance.TakeMoney" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员提现</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="right_content">
            <h2><%=GetLanguage("MembershipWithdrawal")%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("xianjin")%><!--现金币余额-->：</label>
                        <span class="field">
                            <input name="txtBonusAccount" id="txtBonusAccount" runat="server" type="text" disabled="disabled" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("WithdrawalAmount")%><!--提现金额-->：</label>
                        <span class="field">
                            <asp:TextBox ID="txtTake" precision="2" runat="server" AutoPostBack="True"
                                onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;"
                                OnTextChanged="txtTake_TextChanged"></asp:TextBox>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("ActualAmount")%><!--到账金额-->：</label>
                        <span class="field">
                            <input name="txtExtMoney" type="text" id="txtExtMoney" runat="server" disabled="disabled" /><!--元-->
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" class="btn" />
                    </p>
                </div>
            </div>
            <div>&nbsp;</div>

            <div class="filter">
                <div class="row-fluid">
                    <p class="span3" style="color: #6E0000; font-size: 24px; line-height: 20px; font-weight: bold;">
                        <%=GetLanguage("WithdrawalRecords")%><%--提现记录--%>
                    </p>
                </div>
            </div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("DateWithdrawal")%><!--提现日期-->：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                {%>
                            <asp:TextBox ID="txtStart" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                                else
                                {%>
                            <asp:TextBox ID="txtStartEn" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                {%>
                            <asp:TextBox ID="txtEnd" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                            <%}
                                else
                                {%>
                            <asp:TextBox ID="txtEndEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" class="btn" OnClick="btnSearch_Click" />
                    </p>
                </div>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <th align="center">
                            <%=GetLanguage("WithdrawalAmount")%><!--提现金额-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("WithdrawalFee")%><!--提现手续费-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("ActualAmount")%><!--到账金额-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("DateWithdrawal")%><!--提现日期-->
                        </th>
                        <th align="center">
                            <%=GetLanguage("State")%><!--状态-->
                        </th>
                        <th>
                            <%=GetLanguage("Operation")%><!--操作-->
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <%#Eval("TakeMoney")%>
                                </td>
                                <td align="center">
                                    <%#Eval("TakePoundage")%>
                                </td>
                                <td align="center">
                                    <%#Eval("RealityMoney")%>
                                </td>
                                <td align="center">
                                    <%#Eval("TakeTime")%>
                                </td>
                                <td align="center">
                                    <% if (Language == "zh-cn")
                                        { %>
                                    <%#Eval("Flag").ToString() == "0" ? "未发放" : "已发放"%>
                                    <% }
                                        else
                                        { %>
                                    <%#Eval("Flag").ToString() == "0" ? "Not released" : "Has been released"%>
                                    <% }%>
                                </td>
                                <td>&nbsp<asp:LinkButton ID="lbtnCancel" runat="server" class="btn" CommandName="change" Visible='<%#Eval("Flag").ToString() == "0" ? true : false%>'
                                    CommandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('确认取消提现吗？')"><%=GetLanguage("CancelWithdrawal")%><!--取消提现--></asp:LinkButton>
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
